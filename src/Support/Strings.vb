Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Reflection
Imports System.Resources

Public Class Strings
    Private Shared ReadOnly ResourceAssembly As Assembly = GetType(Strings).Assembly
    Private Shared ReadOnly ResourceValues As New Dictionary(Of String, Dictionary(Of String, String))(StringComparer.OrdinalIgnoreCase)

    Public Shared Function [Get](ByVal key As String) As String
        Dim value As String = Nothing
        Dim xCultureName As String = SupportedCultureName(CultureInfo.CurrentUICulture)
        If xCultureName <> "" AndAlso TryGetValue(xCultureName, key, value) Then Return value
        If TryGetValue("", key, value) Then Return value

        Return key
    End Function

    Private Shared Function SupportedCultureName(ByVal culture As CultureInfo) As String
        If culture Is Nothing Then Return ""

        Dim xName As String = culture.Name.ToLowerInvariant()
        If xName = "ja" OrElse xName.StartsWith("ja-") Then Return "ja"
        If xName = "ko" OrElse xName.StartsWith("ko-") Then Return "ko"
        If xName = "zh-hans" OrElse xName = "zh-cn" OrElse xName = "zh-sg" Then Return "zh-Hans"

        Return ""
    End Function

    Private Shared Function TryGetValue(ByVal cultureName As String, ByVal key As String, ByRef value As String) As Boolean
        Dim xValues As Dictionary(Of String, String) = GetResourceValues(cultureName)
        Return xValues.TryGetValue(key, value)
    End Function

    Private Shared Function GetResourceValues(ByVal cultureName As String) As Dictionary(Of String, String)
        SyncLock ResourceValues
            If ResourceValues.ContainsKey(cultureName) Then Return ResourceValues(cultureName)

            Dim xValues As Dictionary(Of String, String) = LoadResourceValues(cultureName)
            ResourceValues(cultureName) = xValues
            Return xValues
        End SyncLock
    End Function

    Private Shared Function LoadResourceValues(ByVal cultureName As String) As Dictionary(Of String, String)
        Dim xValues As New Dictionary(Of String, String)
        Dim xResourceName As String = "nBMSC.Strings" & If(cultureName = "", "", "." & cultureName) & ".resources"
        Dim xStream As IO.Stream = ResourceAssembly.GetManifestResourceStream(xResourceName)
        If xStream Is Nothing Then Return xValues

        Using xStream
            Using xReader As New ResourceReader(xStream)
                For Each xEntry As DictionaryEntry In xReader
                    If TypeOf xEntry.Value Is String Then xValues(CStr(xEntry.Key)) = CStr(xEntry.Value)
                Next
            End Using
        End Using

        Return xValues
    End Function


    Public Shared ReadOnly Property OK As String
        Get
            Return Strings.Get("OK")
        End Get
    End Property
    Public Shared ReadOnly Property Cancel As String
        Get
            Return Strings.Get("Cancel")
        End Get
    End Property
    Public Shared ReadOnly Property None As String
        Get
            Return Strings.Get("None")
        End Get
    End Property

    Public Class StatusBar
        Public Shared ReadOnly Property Length As String
            Get
                Return Strings.Get("StatusBar.Length")
            End Get
        End Property
        Public Shared ReadOnly Property LongNote As String
            Get
                Return Strings.Get("StatusBar.LongNote")
            End Get
        End Property
        Public Shared ReadOnly Property Hidden As String
            Get
                Return Strings.Get("StatusBar.Hidden")
            End Get
        End Property
        Public Shared ReadOnly Property LandMine As String
            Get
                Return Strings.Get("StatusBar.LandMine")
            End Get
        End Property
        Public Shared ReadOnly Property Err As String
            Get
                Return Strings.Get("StatusBar.Error")
            End Get
        End Property
    End Class

    Public Class Messages
        Public Shared ReadOnly Property Err As String
            Get
                Return Strings.Get("Messages.Err")
            End Get
        End Property
        Public Shared ReadOnly Property SaveOnExit As String
            Get
                Return Strings.Get("Messages.SaveOnExit")
            End Get
        End Property
        Public Shared ReadOnly Property SaveOnExit1 As String
            Get
                Return Strings.Get("Messages.SaveOnExit1")
            End Get
        End Property
        Public Shared ReadOnly Property SaveOnExit2 As String
            Get
                Return Strings.Get("Messages.SaveOnExit2")
            End Get
        End Property
        Public Shared ReadOnly Property PromptEnter As String
            Get
                Return Strings.Get("Messages.PromptEnter")
            End Get
        End Property
        Public Shared ReadOnly Property PromptEnterNumeric As String
            Get
                Return Strings.Get("Messages.PromptEnterNumeric")
            End Get
        End Property
        Public Shared ReadOnly Property PromptEnterMeasure As String
            Get
                Return Strings.Get("Messages.PromptEnterMeasure")
            End Get
        End Property
        Public Shared ReadOnly Property GoToMeasureTitle As String
            Get
                Return Strings.Get("Messages.GoToMeasureTitle")
            End Get
        End Property
        Public Shared ReadOnly Property PromptEnterBPM As String
            Get
                Return Strings.Get("Messages.PromptEnterBPM")
            End Get
        End Property
        Public Shared ReadOnly Property PromptEnterSTOP As String
            Get
                Return Strings.Get("Messages.PromptEnterSTOP")
            End Get
        End Property
        Public Shared ReadOnly Property PromptEnterSCROLL As String
            Get
                Return Strings.Get("Messages.PromptEnterSCROLL")
            End Get
        End Property
        Public Shared ReadOnly Property PromptSlashValue As String
            Get
                Return Strings.Get("Messages.PromptSlashValue")
            End Get
        End Property
        Public Shared ReadOnly Property InvalidLabel As String
            Get
                Return Strings.Get("Messages.InvalidLabel")
            End Get
        End Property
        Public Shared ReadOnly Property CannotFind As String
            Get
                Return Strings.Get("Messages.CannotFind")
            End Get
        End Property
        Public Shared ReadOnly Property PleaseRespecifyPath As String
            Get
                Return Strings.Get("Messages.PleaseRespecifyPath")
            End Get
        End Property
        Public Shared ReadOnly Property PlayerNotFound As String
            Get
                Return Strings.Get("Messages.PlayerNotFound")
            End Get
        End Property
        Public Shared ReadOnly Property PreviewDelError As String
            Get
                Return Strings.Get("Messages.PreviewDelError")
            End Get
        End Property
        Public Shared ReadOnly Property NegativeFactorError As String
            Get
                Return Strings.Get("Messages.NegativeFactorError")
            End Get
        End Property
        Public Shared ReadOnly Property NegativeDivisorError As String
            Get
                Return Strings.Get("Messages.NegativeDivisorError")
            End Get
        End Property
        Public Shared ReadOnly Property EraserObsolete As String
            Get
                Return Strings.Get("Messages.EraserObsolete")
            End Get
        End Property
        Public Shared ReadOnly Property SaveWarning As String
            Get
                Return Strings.Get("Messages.SaveWarning")
            End Get
        End Property
        Public Shared ReadOnly Property NoteOverlapError As String
            Get
                Return Strings.Get("Messages.NoteOverlapError")
            End Get
        End Property
        Public Shared ReadOnly Property BPMOverflowError As String
            Get
                Return Strings.Get("Messages.BPMOverflowError")
            End Get
        End Property
        Public Shared ReadOnly Property STOPOverflowError As String
            Get
                Return Strings.Get("Messages.STOPOverflowError")
            End Get
        End Property
        Public Shared ReadOnly Property SCROLLOverflowError As String
            Get
                Return Strings.Get("Messages.SCROLLOverflowError")
            End Get
        End Property
        Public Shared ReadOnly Property SavedFileWillContainErrors As String
            Get
                Return Strings.Get("Messages.SavedFileWillContainErrors")
            End Get
        End Property
        Public Shared ReadOnly Property FileAssociationPrompt As String
            Get
                Return Strings.Get("Messages.FileAssociationPrompt")
            End Get
        End Property
        Public Shared ReadOnly Property FileAssociationError As String
            Get
                Return Strings.Get("Messages.FileAssociationError")
            End Get
        End Property
        Public Shared ReadOnly Property RestoreDefaultSettings As String
            Get
                Return Strings.Get("Messages.RestoreDefaultSettings")
            End Get
        End Property
        Public Shared ReadOnly Property RestoreAutosavedFile As String
            Get
                Return Strings.Get("Messages.RestoreAutosavedFile")
            End Get
        End Property
        Public Shared ReadOnly Property UpdateCheckTitle As String
            Get
                Return Strings.Get("Messages.UpdateCheckTitle")
            End Get
        End Property
        Public Shared ReadOnly Property UpdateAvailable As String
            Get
                Return Strings.Get("Messages.UpdateAvailable")
            End Get
        End Property
        Public Shared ReadOnly Property UpdateLatest As String
            Get
                Return Strings.Get("Messages.UpdateLatest")
            End Get
        End Property
        Public Shared ReadOnly Property UpdateCheckFailed As String
            Get
                Return Strings.Get("Messages.UpdateCheckFailed")
            End Get
        End Property
        Public Shared ReadOnly Property UpdateVersionUnsupported As String
            Get
                Return Strings.Get("Messages.UpdateVersionUnsupported")
            End Get
        End Property
        Public Shared ReadOnly Property UpdateOpenRelease As String
            Get
                Return Strings.Get("Messages.UpdateOpenRelease")
            End Get
        End Property
        Public Shared ReadOnly Property UpdateLater As String
            Get
                Return Strings.Get("Messages.UpdateLater")
            End Get
        End Property
        Public Shared ReadOnly Property UpdateSkipVersion As String
            Get
                Return Strings.Get("Messages.UpdateSkipVersion")
            End Get
        End Property
    End Class

    Public Class FileType
        Public Shared ReadOnly Property _all As String
            Get
                Return Strings.Get("FileType._all")
            End Get
        End Property

        Public Shared ReadOnly Property _bms As String
            Get
                Return Strings.Get("FileType._bms")
            End Get
        End Property
        Public Shared ReadOnly Property BMS As String
            Get
                Return Strings.Get("FileType.BMS")
            End Get
        End Property
        Public Shared ReadOnly Property BME As String
            Get
                Return Strings.Get("FileType.BME")
            End Get
        End Property
        Public Shared ReadOnly Property BML As String
            Get
                Return Strings.Get("FileType.BML")
            End Get
        End Property
        Public Shared ReadOnly Property PMS As String
            Get
                Return Strings.Get("FileType.PMS")
            End Get
        End Property
        Public Shared ReadOnly Property TXT As String
            Get
                Return Strings.Get("FileType.TXT")
            End Get
        End Property

        Public Shared ReadOnly Property NBMSC As String
            Get
                Return Strings.Get("FileType.NBMSC")
            End Get
        End Property
        Public Shared ReadOnly Property BMSON As String
            Get
                Return Strings.Get("FileType.BMSON")
            End Get
        End Property
        Public Shared ReadOnly Property XML As String
            Get
                Return Strings.Get("FileType.XML")
            End Get
        End Property
        Public Shared ReadOnly Property THEME_XML As String
            Get
                Return Strings.Get("FileType.THEME_XML")
            End Get
        End Property

        Public Shared ReadOnly Property _audio As String
            Get
                Return Strings.Get("FileType._audio")
            End Get
        End Property
        Public Shared ReadOnly Property _wave As String
            Get
                Return Strings.Get("FileType._wave")
            End Get
        End Property
        Public Shared ReadOnly Property WAV As String
            Get
                Return Strings.Get("FileType.WAV")
            End Get
        End Property
        Public Shared ReadOnly Property OGG As String
            Get
                Return Strings.Get("FileType.OGG")
            End Get
        End Property
        Public Shared ReadOnly Property MP3 As String
            Get
                Return Strings.Get("FileType.MP3")
            End Get
        End Property
        Public Shared ReadOnly Property FLAC As String
            Get
                Return Strings.Get("FileType.FLAC")
            End Get
        End Property
        Public Shared ReadOnly Property MID As String
            Get
                Return Strings.Get("FileType.MID")
            End Get
        End Property

        Public Shared ReadOnly Property _image As String
            Get
                Return Strings.Get("FileType._image")
            End Get
        End Property
        Public Shared ReadOnly Property _movie As String
            Get
                Return Strings.Get("FileType._movie")
            End Get
        End Property
        Public Shared ReadOnly Property BMP As String
            Get
                Return Strings.Get("FileType.BMP")
            End Get
        End Property
        Public Shared ReadOnly Property PNG As String
            Get
                Return Strings.Get("FileType.PNG")
            End Get
        End Property
        Public Shared ReadOnly Property JPG As String
            Get
                Return Strings.Get("FileType.JPG")
            End Get
        End Property
        Public Shared ReadOnly Property GIF As String
            Get
                Return Strings.Get("FileType.GIF")
            End Get
        End Property
        Public Shared ReadOnly Property MPG As String
            Get
                Return Strings.Get("FileType.MPG")
            End Get
        End Property
        Public Shared ReadOnly Property AVI As String
            Get
                Return Strings.Get("FileType.AVI")
            End Get
        End Property
        Public Shared ReadOnly Property MP4 As String
            Get
                Return Strings.Get("FileType.MP4")
            End Get
        End Property
        Public Shared ReadOnly Property WMV As String
            Get
                Return Strings.Get("FileType.WMV")
            End Get
        End Property
        Public Shared ReadOnly Property WEBM As String
            Get
                Return Strings.Get("FileType.WEBM")
            End Get
        End Property

        Public Shared ReadOnly Property EXE As String
            Get
                Return Strings.Get("FileType.EXE")
            End Get
        End Property
    End Class

    Public Class fStatistics
        Public Shared ReadOnly Property Title As String
            Get
                Return Strings.Get("Statistics.Title")
            End Get
        End Property
        Public Shared ReadOnly Property lBPM As String
            Get
                Return Strings.Get("Statistics.lBPM")
            End Get
        End Property
        Public Shared ReadOnly Property lSTOP As String
            Get
                Return Strings.Get("Statistics.lSTOP")
            End Get
        End Property
        Public Shared ReadOnly Property lSCROLL As String
            Get
                Return Strings.Get("Statistics.lSCROLL")
            End Get
        End Property
        Public Shared ReadOnly Property lA As String
            Get
                Return Strings.Get("Statistics.lA")
            End Get
        End Property
        Public Shared ReadOnly Property lD As String
            Get
                Return Strings.Get("Statistics.lD")
            End Get
        End Property
        Public Shared ReadOnly Property lBGM As String
            Get
                Return Strings.Get("Statistics.lBGM")
            End Get
        End Property
        Public Shared ReadOnly Property lTotal As String
            Get
                Return Strings.Get("Statistics.lTotal")
            End Get
        End Property
        Public Shared ReadOnly Property lShort As String
            Get
                Return Strings.Get("Statistics.lShort")
            End Get
        End Property
        Public Shared ReadOnly Property lLong As String
            Get
                Return Strings.Get("Statistics.lLong")
            End Get
        End Property
        Public Shared ReadOnly Property lLnObj As String
            Get
                Return Strings.Get("Statistics.lLnObj")
            End Get
        End Property
        Public Shared ReadOnly Property lHidden As String
            Get
                Return Strings.Get("Statistics.lHidden")
            End Get
        End Property
        Public Shared ReadOnly Property lLandMine As String
            Get
                Return Strings.Get("Statistics.lLandMine")
            End Get
        End Property
        Public Shared ReadOnly Property lErrors As String
            Get
                Return Strings.Get("Statistics.lErrors")
            End Get
        End Property
    End Class

    Public Class fopPlayer
        Public Shared ReadOnly Property Title As String
            Get
                Return Strings.Get("PlayerOptions.Title")
            End Get
        End Property
        Public Shared ReadOnly Property Add As String
            Get
                Return Strings.Get("PlayerOptions.Add")
            End Get
        End Property
        Public Shared ReadOnly Property Remove As String
            Get
                Return Strings.Get("PlayerOptions.Remove")
            End Get
        End Property
        Public Shared ReadOnly Property Path As String
            Get
                Return Strings.Get("PlayerOptions.Path")
            End Get
        End Property
        Public Shared ReadOnly Property PlayFromBeginning As String
            Get
                Return Strings.Get("PlayerOptions.PlayFromBeginning")
            End Get
        End Property
        Public Shared ReadOnly Property PlayFromHere As String
            Get
                Return Strings.Get("PlayerOptions.PlayFromHere")
            End Get
        End Property
        Public Shared ReadOnly Property StopPlaying As String
            Get
                Return Strings.Get("PlayerOptions.StopPlaying")
            End Get
        End Property
        Public Shared ReadOnly Property References As String
            Get
                Return Strings.Get("PlayerOptions.References")
            End Get
        End Property
        Public Shared ReadOnly Property DirectoryOfApp As String
            Get
                Return Strings.Get("PlayerOptions.DirectoryOfApp")
            End Get
        End Property
        Public Shared ReadOnly Property CurrMeasure As String
            Get
                Return Strings.Get("PlayerOptions.CurrMeasure")
            End Get
        End Property
        Public Shared ReadOnly Property FileName As String
            Get
                Return Strings.Get("PlayerOptions.FileName")
            End Get
        End Property
        Public Shared ReadOnly Property RestoreDefault As String
            Get
                Return Strings.Get("PlayerOptions.RestoreDefault")
            End Get
        End Property
    End Class

    Public Class fopVisual
        Public Shared ReadOnly Property Title As String
            Get
                Return Strings.Get("VisualOptions.Title")
            End Get
        End Property
        Public Shared ReadOnly Property Width As String
            Get
                Return Strings.Get("VisualOptions.Width")
            End Get
        End Property
        Public Shared ReadOnly Property Caption As String
            Get
                Return Strings.Get("VisualOptions.Caption")
            End Get
        End Property
        Public Shared ReadOnly Property Note As String
            Get
                Return Strings.Get("VisualOptions.Note")
            End Get
        End Property
        Public Shared ReadOnly Property Label As String
            Get
                Return Strings.Get("VisualOptions.Label")
            End Get
        End Property
        Public Shared ReadOnly Property LongNote As String
            Get
                Return Strings.Get("VisualOptions.LongNote")
            End Get
        End Property
        Public Shared ReadOnly Property LongNoteLabel As String
            Get
                Return Strings.Get("VisualOptions.LongNoteLabel")
            End Get
        End Property
        Public Shared ReadOnly Property Bg As String
            Get
                Return Strings.Get("VisualOptions.Bg")
            End Get
        End Property
        Public Shared ReadOnly Property ColumnCaption As String
            Get
                Return Strings.Get("VisualOptions.ColumnCaption")
            End Get
        End Property
        Public Shared ReadOnly Property ColumnCaptionFont As String
            Get
                Return Strings.Get("VisualOptions.ColumnCaptionFont")
            End Get
        End Property
        Public Shared ReadOnly Property Background As String
            Get
                Return Strings.Get("VisualOptions.Background")
            End Get
        End Property
        Public Shared ReadOnly Property Grid As String
            Get
                Return Strings.Get("VisualOptions.Grid")
            End Get
        End Property
        Public Shared ReadOnly Property SubGrid As String
            Get
                Return Strings.Get("VisualOptions.SubGrid")
            End Get
        End Property
        Public Shared ReadOnly Property VerticalLine As String
            Get
                Return Strings.Get("VisualOptions.VerticalLine")
            End Get
        End Property
        Public Shared ReadOnly Property MeasureBarLine As String
            Get
                Return Strings.Get("VisualOptions.MeasureBarLine")
            End Get
        End Property
        Public Shared ReadOnly Property BGMWaveform As String
            Get
                Return Strings.Get("VisualOptions.BGMWaveform")
            End Get
        End Property
        Public Shared ReadOnly Property NoteHeight As String
            Get
                Return Strings.Get("VisualOptions.NoteHeight")
            End Get
        End Property
        Public Shared ReadOnly Property NoteLabel As String
            Get
                Return Strings.Get("VisualOptions.NoteLabel")
            End Get
        End Property
        Public Shared ReadOnly Property MeasureLabel As String
            Get
                Return Strings.Get("VisualOptions.MeasureLabel")
            End Get
        End Property
        Public Shared ReadOnly Property LabelVerticalShift As String
            Get
                Return Strings.Get("VisualOptions.LabelVerticalShift")
            End Get
        End Property
        Public Shared ReadOnly Property LabelHorizontalShift As String
            Get
                Return Strings.Get("VisualOptions.LabelHorizontalShift")
            End Get
        End Property
        Public Shared ReadOnly Property LongNoteLabelHorizontalShift As String
            Get
                Return Strings.Get("VisualOptions.LongNoteLabelHorizontalShift")
            End Get
        End Property
        Public Shared ReadOnly Property HiddenNoteOpacity As String
            Get
                Return Strings.Get("VisualOptions.HiddenNoteOpacity")
            End Get
        End Property
        Public Shared ReadOnly Property NoteBorderOnMouseOver As String
            Get
                Return Strings.Get("VisualOptions.NoteBorderOnMouseOver")
            End Get
        End Property
        Public Shared ReadOnly Property NoteBorderOnSelection As String
            Get
                Return Strings.Get("VisualOptions.NoteBorderOnSelection")
            End Get
        End Property
        Public Shared ReadOnly Property NoteBorderOnAdjustingLength As String
            Get
                Return Strings.Get("VisualOptions.NoteBorderOnAdjustingLength")
            End Get
        End Property
        Public Shared ReadOnly Property SelectionBoxBorder As String
            Get
                Return Strings.Get("VisualOptions.SelectionBoxBorder")
            End Get
        End Property
        Public Shared ReadOnly Property TSCursor As String
            Get
                Return Strings.Get("VisualOptions.TSCursor")
            End Get
        End Property
        Public Shared ReadOnly Property TSSplitView As String
            Get
                Return Strings.Get("VisualOptions.TSSplitView")
            End Get
        End Property
        Public Shared ReadOnly Property TSCursorSensitivity As String
            Get
                Return Strings.Get("VisualOptions.TSCursorSensitivity")
            End Get
        End Property
        Public Shared ReadOnly Property TSMouseOverBorder As String
            Get
                Return Strings.Get("VisualOptions.TSMouseOverBorder")
            End Get
        End Property
        Public Shared ReadOnly Property TSFill As String
            Get
                Return Strings.Get("VisualOptions.TSFill")
            End Get
        End Property
        Public Shared ReadOnly Property TSBPM As String
            Get
                Return Strings.Get("VisualOptions.TSBPM")
            End Get
        End Property
        Public Shared ReadOnly Property TSBPMFont As String
            Get
                Return Strings.Get("VisualOptions.TSBPMFont")
            End Get
        End Property
        Public Shared ReadOnly Property MiddleSensitivity As String
            Get
                Return Strings.Get("VisualOptions.MiddleSensitivity")
            End Get
        End Property
    End Class

    Public Class fopGeneral
        Public Shared ReadOnly Property Title As String
            Get
                Return Strings.Get("GeneralOptions.Title")
            End Get
        End Property
        Public Shared ReadOnly Property MouseWheel As String
            Get
                Return Strings.Get("GeneralOptions.MouseWheel")
            End Get
        End Property
        Public Shared ReadOnly Property InputTextEncoding As String
            Get
                Return Strings.Get("GeneralOptions.InputTextEncoding")
            End Get
        End Property
        Public Shared ReadOnly Property OutputTextEncoding As String
            Get
                Return Strings.Get("GeneralOptions.OutputTextEncoding")
            End Get
        End Property
        'Public Shared SortingMethod As String = "Sorting Method"
        'Public Shared sortBubble As String = "One-directional Bubble Sort"
        'Public Shared sortInsertion As String = "Insertion Sort"
        'Public Shared sortQuick As String = "Quick Sort"
        'Public Shared sortQuickD3 As String = "Quick Sort d3"
        'Public Shared sortHeap As String = "Heap Sort"
        Public Shared ReadOnly Property PageUpDown As String
            Get
                Return Strings.Get("GeneralOptions.PageUpDown")
            End Get
        End Property
        Public Shared ReadOnly Property MiddleButton As String
            Get
                Return Strings.Get("GeneralOptions.MiddleButton")
            End Get
        End Property
        Public Shared ReadOnly Property MiddleButtonAuto As String
            Get
                Return Strings.Get("GeneralOptions.MiddleButtonAuto")
            End Get
        End Property
        Public Shared ReadOnly Property MiddleButtonDrag As String
            Get
                Return Strings.Get("GeneralOptions.MiddleButtonDrag")
            End Get
        End Property
        Public Shared ReadOnly Property AssociateFileType As String
            Get
                Return Strings.Get("GeneralOptions.AssociateFileType")
            End Get
        End Property
        Public Shared ReadOnly Property MaxGridPartition As String
            Get
                Return Strings.Get("GeneralOptions.MaxGridPartition")
            End Get
        End Property
        Public Shared ReadOnly Property BeepWhileSaved As String
            Get
                Return Strings.Get("GeneralOptions.BeepWhileSaved")
            End Get
        End Property
        Public Shared ReadOnly Property NewBMSUseBase62 As String
            Get
                Return Strings.Get("GeneralOptions.NewBMSUseBase62")
            End Get
        End Property
        Public Shared ReadOnly Property AutoFocusOnMouseEnter As String
            Get
                Return Strings.Get("GeneralOptions.AutoFocusOnMouseEnter")
            End Get
        End Property
        Public Shared ReadOnly Property DisableFirstClick As String
            Get
                Return Strings.Get("GeneralOptions.DisableFirstClick")
            End Get
        End Property
        Public Shared ReadOnly Property AutoSave As String
            Get
                Return Strings.Get("GeneralOptions.AutoSave")
            End Get
        End Property
        Public Shared ReadOnly Property minutes As String
            Get
                Return Strings.Get("GeneralOptions.minutes")
            End Get
        End Property
        Public Shared ReadOnly Property StopPreviewOnClick As String
            Get
                Return Strings.Get("GeneralOptions.StopPreviewOnClick")
            End Get
        End Property
        Public Shared ReadOnly Property SkipClippedMeasure As String
            Get
                Return Strings.Get("GeneralOptions.SkipClippedMeasure")
            End Get
        End Property
        Public Shared ReadOnly Property LaneHighlight As String
            Get
                Return Strings.Get("GeneralOptions.LaneHighlight")
            End Get
        End Property
        Public Shared ReadOnly Property MinimumBGMLanes As String
            Get
                Return Strings.Get("GeneralOptions.MinimumBGMLanes")
            End Get
        End Property
        Public Shared ReadOnly Property UndoRedoMemoryLimit As String
            Get
                Return Strings.Get("GeneralOptions.UndoRedoMemoryLimit")
            End Get
        End Property
    End Class

    Public Class Encoding
        Public Shared ReadOnly Property Auto As String
            Get
                Return Strings.Get("Encoding.Auto")
            End Get
        End Property
        Public Shared ReadOnly Property SystemDefault As String
            Get
                Return Strings.Get("Encoding.SystemDefault")
            End Get
        End Property
        Public Shared ReadOnly Property Base62 As String
            Get
                Return Strings.Get("Encoding.Base62")
            End Get
        End Property
        Public Shared ReadOnly Property ReloadWithEncoding As String
            Get
                Return Strings.Get("Encoding.ReloadWithEncoding")
            End Get
        End Property
    End Class

    Public Class fFind
        Public Shared ReadOnly Property NoteRange As String
            Get
                Return Strings.Get("Find.NoteRange")
            End Get
        End Property
        Public Shared ReadOnly Property MeasureRange As String
            Get
                Return Strings.Get("Find.MeasureRange")
            End Get
        End Property
        Public Shared ReadOnly Property LabelRange As String
            Get
                Return Strings.Get("Find.LabelRange")
            End Get
        End Property
        Public Shared ReadOnly Property ValueRange As String
            Get
                Return Strings.Get("Find.ValueRange")
            End Get
        End Property
        Public Shared ReadOnly Property to_ As String
            Get
                Return Strings.Get("Find.to")
            End Get
        End Property
        Public Shared ReadOnly Property Selected As String
            Get
                Return Strings.Get("Find.Selected")
            End Get
        End Property
        Public Shared ReadOnly Property UnSelected As String
            Get
                Return Strings.Get("Find.UnSelected")
            End Get
        End Property
        Public Shared ReadOnly Property ShortNote As String
            Get
                Return Strings.Get("Find.ShortNote")
            End Get
        End Property
        Public Shared ReadOnly Property LongNote As String
            Get
                Return Strings.Get("Find.LongNote")
            End Get
        End Property
        Public Shared ReadOnly Property Hidden As String
            Get
                Return Strings.Get("Find.Hidden")
            End Get
        End Property
        Public Shared ReadOnly Property LandMine As String
            Get
                Return Strings.Get("Find.LandMine")
            End Get
        End Property
        Public Shared ReadOnly Property Visible As String
            Get
                Return Strings.Get("Find.Visible")
            End Get
        End Property
        Public Shared ReadOnly Property Column As String
            Get
                Return Strings.Get("Find.Column")
            End Get
        End Property
        Public Shared ReadOnly Property SelectAll As String
            Get
                Return Strings.Get("Find.SelectAll")
            End Get
        End Property
        Public Shared ReadOnly Property SelectInverse As String
            Get
                Return Strings.Get("Find.SelectInverse")
            End Get
        End Property
        Public Shared ReadOnly Property UnselectAll As String
            Get
                Return Strings.Get("Find.UnselectAll")
            End Get
        End Property
        Public Shared ReadOnly Property Operation As String
            Get
                Return Strings.Get("Find.Operation")
            End Get
        End Property
        Public Shared ReadOnly Property ReplaceWithLabel As String
            Get
                Return Strings.Get("Find.ReplaceWithLabel")
            End Get
        End Property
        Public Shared ReadOnly Property ReplaceWithValue As String
            Get
                Return Strings.Get("Find.ReplaceWithValue")
            End Get
        End Property
        Public Shared ReadOnly Property Select_ As String
            Get
                Return Strings.Get("Find.Select")
            End Get
        End Property
        Public Shared ReadOnly Property Unselect_ As String
            Get
                Return Strings.Get("Find.Unselect")
            End Get
        End Property
        Public Shared ReadOnly Property Delete_ As String
            Get
                Return Strings.Get("Find.Delete")
            End Get
        End Property
        Public Shared ReadOnly Property Close_ As String
            Get
                Return Strings.Get("Find.Close")
            End Get
        End Property
    End Class

    Public Class fImportBMSON
        Public Shared ReadOnly Property Message As String
            Get
                Return Strings.Get("ImportBMSON.Message")
            End Get
        End Property
    End Class

    Public Class FileAssociation
        Public Shared ReadOnly Property BMS As String
            Get
                Return Strings.Get("FileAssociation.BMS")
            End Get
        End Property
        Public Shared ReadOnly Property BME As String
            Get
                Return Strings.Get("FileAssociation.BME")
            End Get
        End Property
        Public Shared ReadOnly Property BML As String
            Get
                Return Strings.Get("FileAssociation.BML")
            End Get
        End Property
        Public Shared ReadOnly Property PMS As String
            Get
                Return Strings.Get("FileAssociation.PMS")
            End Get
        End Property
        Public Shared ReadOnly Property NBMSC As String
            Get
                Return Strings.Get("FileAssociation.NBMSC")
            End Get
        End Property
        Public Shared ReadOnly Property Open As String
            Get
                Return Strings.Get("FileAssociation.Open")
            End Get
        End Property
        Public Shared ReadOnly Property Preview As String
            Get
                Return Strings.Get("FileAssociation.Preview")
            End Get
        End Property
        Public Shared ReadOnly Property ViewCode As String
            Get
                Return Strings.Get("FileAssociation.ViewCode")
            End Get
        End Property
    End Class
End Class
