Imports System.Windows.Forms

Public Class fLoadFileProgress
    Dim xPath(-1) As String
    Dim CancelPressed As Boolean = False
    Dim IsSaved As Boolean = False
    Dim CurrentFileIndex As Integer = 0
    Dim CurrentFilePath As String = ""
    Dim LastProgressUpdate As DateTime = DateTime.MinValue
    Dim ShowDelayMilliseconds As Integer = 0
    Dim ShowStartedAt As DateTime = DateTime.MinValue
    Dim IsProgressVisible As Boolean = True
    Dim IsClosingAfterLoad As Boolean = False

    Public Sub New(ByVal xxPath() As String,
                   ByVal xIsSaved As Boolean,
                   Optional ByVal TopMost As Boolean = True,
                   Optional ByVal xShowDelayMilliseconds As Integer = 0,
                   Optional ByVal xShowApplicationName As Boolean = False)
        InitializeComponent()
        prog.Minimum = 0
        prog.Maximum = 1000
        xPath = xxPath
        IsSaved = xIsSaved
        Me.TopMost = TopMost
        If xShowApplicationName Then
            Me.Text = My.Application.Info.Title & " - " & Me.Text
            Me.Icon = MainWindow.Icon
            Me.ShowIcon = True
            Me.ShowInTaskbar = True
            Me.ControlBox = True
            Me.MinimizeBox = True
        End If

        ShowDelayMilliseconds = xShowDelayMilliseconds
        IsProgressVisible = ShowDelayMilliseconds <= 0
        ApplyProgressVisibility()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        CancelPressed = True
        Cancel_Button.Enabled = False
    End Sub

    Private Sub fLoadFileProgress_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim xInProcessLoadStarted As Boolean = False
        Dim xInProcessLoadCompleted As Boolean = False
        ShowStartedAt = DateTime.UtcNow
        ApplyProgressVisibility()

        Try
            For xI1 As Integer = 0 To UBound(xPath)
                BeginFile(xI1, xPath(xI1))
                CheckCanceled()

                If xI1 = 0 AndAlso IsSaved Then
                    xInProcessLoadStarted = True
                    xInProcessLoadCompleted = False
                    MainWindow.ReadFile(xPath(xI1), Me)
                    xInProcessLoadCompleted = True
                Else
                    ReportProgress("Starting separate process", 0, True)
                    System.Diagnostics.Process.Start(Application.ExecutablePath, """" & xPath(xI1) & """") 'Shell("""" & Application.ExecutablePath & """ """ & xPaths(xI1) & """") '
                    ReportProgress("Done", 100, True)
                End If

                CheckCanceled()
            Next

            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As OperationCanceledException
            If xInProcessLoadStarted AndAlso Not xInProcessLoadCompleted Then MainWindow.ResetCanceledLoad()
            DialogResult = Windows.Forms.DialogResult.Cancel
        Finally
            IsClosingAfterLoad = True
            Me.Close()
        End Try
    End Sub

    Private Sub fLoadFileProgress_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If IsClosingAfterLoad OrElse e.CloseReason <> CloseReason.UserClosing Then Return

        CancelPressed = True
        Cancel_Button.Enabled = False
        e.Cancel = True
    End Sub

    Private Sub fLoadFileProgress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Font = MainWindow.Font
        Me.Cancel_Button.DialogResult = Windows.Forms.DialogResult.None
        Me.Cancel_Button.Text = Strings.Cancel
        ApplyProgressVisibility()
    End Sub

    Private Sub ApplyProgressVisibility()
        Me.Opacity = IIf(IsProgressVisible, 1.0R, 0.0R)
    End Sub

    Private Sub ShowProgressIfDelayed()
        If IsProgressVisible Then Return
        If ShowStartedAt = DateTime.MinValue Then Return
        If (DateTime.UtcNow - ShowStartedAt).TotalMilliseconds < ShowDelayMilliseconds Then Return

        IsProgressVisible = True
        ApplyProgressVisibility()
        Me.Refresh()
    End Sub

    Friend Sub BeginFile(ByVal xIndex As Integer, ByVal xCurrentPath As String)
        CurrentFileIndex = xIndex
        CurrentFilePath = xCurrentPath
        ReportProgress("Reading file", 0, True)
    End Sub

    Friend Sub ReportProgress(ByVal xStatus As String, ByVal xPercent As Integer, Optional ByVal xForce As Boolean = False)
        If xPercent < 0 Then xPercent = 0
        If xPercent > 100 Then xPercent = 100

        Dim xNow As DateTime = DateTime.UtcNow
        If Not xForce AndAlso (xNow - LastProgressUpdate).TotalMilliseconds < 50 Then Return

        LastProgressUpdate = xNow
        Label1.Text = "Currently loading ( " & (CurrentFileIndex + 1) & " / " & (UBound(xPath) + 1) & " ): " & CurrentFilePath & vbCrLf & xStatus & " ( " & xPercent & "% )"

        Dim xFileCount As Integer = Math.Max(1, xPath.Length)
        Dim xOverall As Integer = CInt(((CurrentFileIndex * 100 + xPercent) / (xFileCount * 100.0R)) * prog.Maximum)
        If xOverall < prog.Minimum Then xOverall = prog.Minimum
        If xOverall > prog.Maximum Then xOverall = prog.Maximum
        prog.Value = xOverall

        ShowProgressIfDelayed()
        Application.DoEvents()
    End Sub

    Friend Sub CheckCanceled()
        If CancelPressed Then Throw New OperationCanceledException()
    End Sub
End Class
