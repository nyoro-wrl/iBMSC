Option Strict On

Imports System
Imports nBMSC
Imports nBMSC.Editor

Module TestRunner
    Private Passed As Integer
    Private Failed As Integer

    Public Function Main() As Integer
        Run("definition label conversion", AddressOf DefinitionLabelConversion)
        Run("channel label conversion", AddressOf ChannelLabelConversion)
        Run("label validation", AddressOf LabelValidation)
        Run("version tag parsing", AddressOf VersionTagParsing)
        Run("undo redo serialization", AddressOf UndoRedoSerialization)

        Console.WriteLine()
        Console.WriteLine("Passed: " & Passed.ToString())
        Console.WriteLine("Failed: " & Failed.ToString())

        If Failed > 0 Then
            Return 1
        End If

        Return 0
    End Function

    Private Sub Run(ByVal name As String, ByVal test As Action)
        Try
            test()
            Passed += 1
            Console.WriteLine("[PASS] " & name)
        Catch ex As Exception
            Failed += 1
            Console.WriteLine("[FAIL] " & name)
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub DefinitionLabelConversion()
        AssertEqual("00", Functions.C10to36(0), "zero should be 00")
        AssertEqual("0A", Functions.C10to36(10), "10 should be 0A")
        AssertEqual("0z", Functions.C10to36(61), "61 should be 0z")
        AssertEqual("10", Functions.C10to36(62), "62 should be 10")
        AssertEqual("zz", Functions.C10to36(Functions.MaxDefinition), "max definition should be zz")
        AssertEqual("00", Functions.C10to36(-1), "negative values should clamp to 00")
        AssertEqual("zz", Functions.C10to36(Functions.MaxDefinition + 1), "too large values should clamp")
        AssertEqual(0, Functions.C36to10("00"), "00 should be 0")
        AssertEqual(3843, Functions.C36to10("zz"), "zz should be max definition")
    End Sub

    Private Sub ChannelLabelConversion()
        AssertEqual("00", Functions.C10to36Channel(0), "zero channel should be 00")
        AssertEqual("0Z", Functions.C10to36Channel(35), "35 should be 0Z")
        AssertEqual("10", Functions.C10to36Channel(36), "36 should be 10")
        AssertEqual("ZZ", Functions.C10to36Channel(Functions.MaxBase36Definition), "max channel should be ZZ")
        AssertEqual(1295, Functions.C36ChannelTo10("ZZ"), "ZZ should be max channel")
        AssertEqual(1295, Functions.C36ChannelTo10("zz"), "channel parsing should ignore case")
    End Sub

    Private Sub LabelValidation()
        AssertTrue(Functions.IsBase36("0AZ9"), "uppercase base36 should be valid")
        AssertFalse(Functions.IsBase36("0Az"), "lowercase should not be valid base36")
        AssertTrue(Functions.IsBase62("0Az"), "mixed case base62 should be valid")
        AssertFalse(Functions.IsBase62("0A-"), "symbols should not be valid base62")
    End Sub

    Private Sub VersionTagParsing()
        Dim version As Version = Nothing

        AssertTrue(UpdateChecker.TryParseVersionTag("5.1.0", version), "plain version should parse")
        AssertEqual(New Version(5, 1, 0), version, "plain version value")

        version = Nothing
        AssertTrue(UpdateChecker.TryParseVersionTag("v5.1.0", version), "v-prefixed version should parse")
        AssertEqual(New Version(5, 1, 0), version, "v-prefixed version value")

        version = Nothing
        AssertFalse(UpdateChecker.TryParseVersionTag("5.1", version), "major.minor should not parse")
        AssertFalse(UpdateChecker.TryParseVersionTag("5.1.0.0", version), "four part versions should not parse")
        AssertFalse(UpdateChecker.TryParseVersionTag("", version), "empty versions should not parse")
    End Sub

    Private Sub UndoRedoSerialization()
        Dim note As New Note(3, 192.0R, 120000, 48.0R, True, False, True)
        Dim move As New UndoRedo.MoveNote(note, 6, 384.0R)
        Dim roundTripMove As UndoRedo.MoveNote = DirectCast(UndoRedo.fromBytes(move.toBytes()), UndoRedo.MoveNote)

        AssertEqual(UndoRedo.opMoveNote, roundTripMove.ofType(), "move command type")
        AssertEqual(6, roundTripMove.NColumnIndex, "move command target column")
        AssertApprox(384.0R, roundTripMove.NVPosition, "move command target position")
        AssertEqual(note.ColumnIndex, roundTripMove.note.ColumnIndex, "note column")
        AssertApprox(note.VPosition, roundTripMove.note.VPosition, "note position")
        AssertEqual(note.Value, roundTripMove.note.Value, "note value")
        AssertEqual(note.LongNote, roundTripMove.note.LongNote, "note long flag")
        AssertApprox(note.Length, roundTripMove.note.Length, "note length")
        AssertEqual(note.Hidden, roundTripMove.note.Hidden, "note hidden flag")
        AssertEqual(note.Landmine, roundTripMove.note.Landmine, "note landmine flag")

        Dim updatedNote As Note = note
        updatedNote.Value = 130000
        Dim noteChange As New UndoRedo.ChangeNote(note, updatedNote)
        Dim roundTripNoteChange As UndoRedo.ChangeNote = DirectCast(UndoRedo.fromBytes(noteChange.toBytes()), UndoRedo.ChangeNote)

        AssertEqual(UndoRedo.opChangeNote, roundTripNoteChange.ofType(), "note change command type")
        AssertEqual(note.Value, roundTripNoteChange.note.Value, "note change old value")
        AssertEqual(updatedNote.Value, roundTripNoteChange.NNote.Value, "note change new value")

        Dim longNote As New UndoRedo.LongNoteModify(note, 128.0R, 96.0R)
        Dim roundTripLongNote As UndoRedo.LongNoteModify = DirectCast(UndoRedo.fromBytes(longNote.toBytes()), UndoRedo.LongNoteModify)

        AssertEqual(UndoRedo.opLongNoteModify, roundTripLongNote.ofType(), "long note command type")
        AssertApprox(128.0R, roundTripLongNote.NVPosition, "long note target position")
        AssertApprox(96.0R, roundTripLongNote.NLongNote, "long note target length")

        Dim measureLength As New UndoRedo.ChangeMeasureLength(256.0R, New Integer() {2, 4})
        Dim roundTripMeasureLength As UndoRedo.ChangeMeasureLength = DirectCast(UndoRedo.fromBytes(measureLength.toBytes()), UndoRedo.ChangeMeasureLength)

        AssertEqual(UndoRedo.opChangeMeasureLength, roundTripMeasureLength.ofType(), "measure length command type")
        AssertApprox(256.0R, roundTripMeasureLength.Value, "measure length value")
        AssertEqual(2, roundTripMeasureLength.Indices.Length, "measure length index count")
        AssertEqual(2, roundTripMeasureLength.Indices(0), "measure length first index")
        AssertEqual(4, roundTripMeasureLength.Indices(1), "measure length second index")

        Dim selection As New UndoRedo.ChangeTimeSelection(10.0R, 20.0R, 30.0R, True)
        Dim roundTripSelection As UndoRedo.ChangeTimeSelection = DirectCast(UndoRedo.fromBytes(selection.toBytes()), UndoRedo.ChangeTimeSelection)

        AssertEqual(UndoRedo.opChangeTimeSelection, roundTripSelection.ofType(), "time selection command type")
        AssertApprox(10.0R, roundTripSelection.SelStart, "time selection start")
        AssertApprox(20.0R, roundTripSelection.SelLength, "time selection length")
        AssertApprox(30.0R, roundTripSelection.SelHalf, "time selection half")
        AssertTrue(roundTripSelection.Selected, "time selection selected flag")

        Dim change As New UndoRedo.DefinitionChange(False, 62, "kick.wav")
        Dim roundTripChange As UndoRedo.DefinitionChange = DirectCast(UndoRedo.fromBytes(change.toBytes()), UndoRedo.DefinitionChange)

        AssertEqual(UndoRedo.opDefinitionChange, roundTripChange.ofType(), "definition command type")
        AssertFalse(roundTripChange.IsWav, "definition command target")
        AssertEqual(62, roundTripChange.Index, "definition command index")
        AssertEqual("kick.wav", roundTripChange.Value, "definition command value")
    End Sub

    Private Sub AssertTrue(ByVal condition As Boolean, ByVal message As String)
        If Not condition Then
            Throw New InvalidOperationException(message)
        End If
    End Sub

    Private Sub AssertFalse(ByVal condition As Boolean, ByVal message As String)
        If condition Then
            Throw New InvalidOperationException(message)
        End If
    End Sub

    Private Sub AssertEqual(Of T)(ByVal expected As T, ByVal actual As T, ByVal message As String)
        If Not EqualityComparer(Of T).Default.Equals(expected, actual) Then
            Throw New InvalidOperationException(message & ": expected <" & expected.ToString() & "> but was <" & actual.ToString() & ">")
        End If
    End Sub

    Private Sub AssertApprox(ByVal expected As Double, ByVal actual As Double, ByVal message As String)
        If Math.Abs(expected - actual) > 0.0000001R Then
            Throw New InvalidOperationException(message & ": expected <" & expected.ToString() & "> but was <" & actual.ToString() & ">")
        End If
    End Sub
End Module
