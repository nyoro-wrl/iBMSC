Imports System.Windows.Forms

Public Class UpdateAvailableDialog

    Public Sub New(ByVal title As String,
                   ByVal mainInstruction As String,
                   ByVal details As String,
                   ByVal openText As String,
                   ByVal skipText As String,
                   ByVal laterText As String,
                   ByVal ownerFont As Font)
        InitializeComponent()

        Text = title
        Font = ownerFont
        InfoPictureBox.Image = SystemIcons.Information.ToBitmap()
        MainInstructionLabel.Font = New Font(Font.FontFamily, Font.Size + 2.0!, FontStyle.Regular)
        MainInstructionLabel.Text = mainInstruction
        DetailsLabel.Text = details
        OpenButton.Text = openText
        SkipButton.Text = skipText
        LaterButton.Text = laterText
        ApplyButtonSize(OpenButton)
        ApplyButtonSize(SkipButton)
        ApplyButtonSize(LaterButton)
    End Sub

    Private Sub ApplyButtonSize(ByVal target As Button)
        Dim textSize As Size = TextRenderer.MeasureText(target.Text, Font, New Size(Integer.MaxValue, Integer.MaxValue), TextFormatFlags.SingleLine)
        target.Size = New Size(textSize.Width + 24, Math.Max(27, textSize.Height + 9))
    End Sub
End Class
