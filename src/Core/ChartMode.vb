Option Strict On

Imports System.IO

Namespace Editor
    Public Enum ChartMode
        Key7 = 0
        Key5 = 1
        Key9 = 2
        Key24 = 3
    End Enum

    Public Class ThemeModeSetting
        Public Property ModeName As String
        Public Property ThemePath As String

        Public Sub New()
            ModeName = ""
            ThemePath = ""
        End Sub

        Public Sub New(ByVal modeName As String, ByVal themePath As String)
            Me.ModeName = modeName
            Me.ThemePath = themePath
        End Sub
    End Class

    Public NotInheritable Class ChartModes
        Private Sub New()
        End Sub

        Private Shared ReadOnly ModeValues() As ChartMode = {
            ChartMode.Key7,
            ChartMode.Key5,
            ChartMode.Key9,
            ChartMode.Key24
        }

        Public Shared Function Count() As Integer
            Return ModeValues.Length
        End Function

        Public Shared Function FromIndex(ByVal index As Integer) As ChartMode
            If index < 0 OrElse index >= ModeValues.Length Then Return ChartMode.Key7
            Return ModeValues(index)
        End Function

        Public Shared Function IndexOf(ByVal mode As ChartMode) As Integer
            For i As Integer = 0 To ModeValues.Length - 1
                If ModeValues(i) = mode Then Return i
            Next

            Return 0
        End Function

        Public Shared Function DisplayName(ByVal mode As ChartMode) As String
            Select Case mode
                Case ChartMode.Key5
                    Return "5key"
                Case ChartMode.Key9
                    Return "9key"
                Case ChartMode.Key24
                    Return "24key"
            End Select

            Return "7key"
        End Function

        Public Shared Function SettingValue(ByVal mode As ChartMode) As String
            Return DisplayName(mode)
        End Function

        Public Shared Function Parse(ByVal value As String, ByVal fallback As ChartMode) As ChartMode
            If value Is Nothing Then Return fallback

            Dim xValue As String = value.Trim().ToLowerInvariant().Replace("-", "").Replace("_", "")
            Select Case xValue
                Case "5", "5key", "key5"
                    Return ChartMode.Key5
                Case "9", "9key", "key9", "pms"
                    Return ChartMode.Key9
                Case "24", "24key", "key24"
                    Return ChartMode.Key24
                Case "7", "7key", "key7"
                    Return ChartMode.Key7
            End Select

            Return fallback
        End Function

        Public Shared Function ThemeFileName(ByVal mode As ChartMode) As String
            Return DisplayName(mode) & ".xml"
        End Function

        Public Shared Function DetectFromBms(ByVal filePath As String, ByVal hasPlayableNotes As Boolean, ByVal has24KeyNotes As Boolean, ByVal has7KeyNotes As Boolean, ByVal has5KeyNotes As Boolean) As ChartMode
            If Not String.IsNullOrEmpty(filePath) AndAlso String.Equals(Path.GetExtension(filePath), ".pms", StringComparison.OrdinalIgnoreCase) Then
                Return ChartMode.Key9
            End If

            If hasPlayableNotes AndAlso has24KeyNotes Then Return ChartMode.Key24
            If hasPlayableNotes AndAlso has7KeyNotes Then Return ChartMode.Key7
            If hasPlayableNotes AndAlso has5KeyNotes Then Return ChartMode.Key5
            Return ChartMode.Key7
        End Function

        Public Shared Sub ObserveBmsChannel(ByVal channel As String, ByVal noteValue As String, ByRef hasPlayableNotes As Boolean, ByRef has24KeyNotes As Boolean, ByRef has7KeyNotes As Boolean, ByRef has5KeyNotes As Boolean)
            If noteValue Is Nothing OrElse noteValue = "00" Then Return
            If Not IsPlayableBmsChannel(channel) Then Return

            hasPlayableNotes = True

            If Is24KeyBmsChannel(channel) Then
                has24KeyNotes = True
            ElseIf Is7KeyBmsChannel(channel) Then
                has7KeyNotes = True
            ElseIf Is5KeyBmsChannel(channel) Then
                has5KeyNotes = True
            End If
        End Sub

        Public Shared Function IsPlayableBmsChannel(ByVal channel As String) As Boolean
            If channel Is Nothing Then Return False

            Dim xChannel As String = channel.Trim().ToUpperInvariant()
            If xChannel.Length <> 2 Then Return False

            Dim xGroup As Char = xChannel.Chars(0)
            Dim xLane As Char = xChannel.Chars(1)
            If "12345678DE".IndexOf(xGroup) < 0 Then Return False
            Return "123456789ABCDEFGHIJKLMNOPQ".IndexOf(xLane) >= 0
        End Function

        Public Shared Function Is24KeyBmsChannel(ByVal channel As String) As Boolean
            If Not IsPlayableBmsChannel(channel) Then Return False

            Dim xLane As Char = channel.Trim().ToUpperInvariant().Chars(1)
            Return xLane = "7"c OrElse "ABCDEFGHIJKLMNOPQ".IndexOf(xLane) >= 0
        End Function

        Public Shared Function Is7KeyBmsChannel(ByVal channel As String) As Boolean
            If Not IsPlayableBmsChannel(channel) Then Return False

            Dim xLane As Char = channel.Trim().ToUpperInvariant().Chars(1)
            Return xLane = "8"c OrElse xLane = "9"c
        End Function

        Public Shared Function Is5KeyBmsChannel(ByVal channel As String) As Boolean
            If Not IsPlayableBmsChannel(channel) Then Return False

            Dim xLane As Char = channel.Trim().ToUpperInvariant().Chars(1)
            Return "123456".IndexOf(xLane) >= 0
        End Function
    End Class
End Namespace
