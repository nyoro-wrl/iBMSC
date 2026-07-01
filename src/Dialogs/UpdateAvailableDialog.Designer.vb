<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdateAvailableDialog
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.RootLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.ContentLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.InfoPictureBox = New System.Windows.Forms.PictureBox()
        Me.MessageLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.MainInstructionLabel = New System.Windows.Forms.Label()
        Me.DetailsLabel = New System.Windows.Forms.Label()
        Me.ButtonPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.LaterButton = New System.Windows.Forms.Button()
        Me.SkipButton = New System.Windows.Forms.Button()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.RootLayout.SuspendLayout()
        Me.ContentPanel.SuspendLayout()
        Me.ContentLayout.SuspendLayout()
        CType(Me.InfoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MessageLayout.SuspendLayout()
        Me.ButtonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RootLayout
        '
        Me.RootLayout.AutoSize = True
        Me.RootLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.RootLayout.ColumnCount = 1
        Me.RootLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RootLayout.Controls.Add(Me.ContentPanel, 0, 0)
        Me.RootLayout.Controls.Add(Me.ButtonPanel, 0, 1)
        Me.RootLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RootLayout.Location = New System.Drawing.Point(0, 0)
        Me.RootLayout.Name = "RootLayout"
        Me.RootLayout.RowCount = 2
        Me.RootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.RootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.RootLayout.Size = New System.Drawing.Size(430, 142)
        Me.RootLayout.TabIndex = 0
        '
        'ContentPanel
        '
        Me.ContentPanel.AutoSize = True
        Me.ContentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ContentPanel.BackColor = System.Drawing.SystemColors.Window
        Me.ContentPanel.Controls.Add(Me.ContentLayout)
        Me.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentPanel.Location = New System.Drawing.Point(0, 0)
        Me.ContentPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.Padding = New System.Windows.Forms.Padding(22, 14, 22, 18)
        Me.ContentPanel.Size = New System.Drawing.Size(430, 91)
        Me.ContentPanel.TabIndex = 0
        '
        'ContentLayout
        '
        Me.ContentLayout.AutoSize = True
        Me.ContentLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ContentLayout.ColumnCount = 2
        Me.ContentLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.ContentLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ContentLayout.Controls.Add(Me.InfoPictureBox, 0, 0)
        Me.ContentLayout.Controls.Add(Me.MessageLayout, 1, 0)
        Me.ContentLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentLayout.Location = New System.Drawing.Point(22, 14)
        Me.ContentLayout.Name = "ContentLayout"
        Me.ContentLayout.RowCount = 1
        Me.ContentLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ContentLayout.Size = New System.Drawing.Size(386, 59)
        Me.ContentLayout.TabIndex = 0
        '
        'InfoPictureBox
        '
        Me.InfoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.InfoPictureBox.Margin = New System.Windows.Forms.Padding(0, 0, 14, 0)
        Me.InfoPictureBox.Name = "InfoPictureBox"
        Me.InfoPictureBox.Size = New System.Drawing.Size(32, 32)
        Me.InfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.InfoPictureBox.TabIndex = 0
        Me.InfoPictureBox.TabStop = False
        '
        'MessageLayout
        '
        Me.MessageLayout.AutoSize = True
        Me.MessageLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MessageLayout.ColumnCount = 1
        Me.MessageLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.MessageLayout.Controls.Add(Me.MainInstructionLabel, 0, 0)
        Me.MessageLayout.Controls.Add(Me.DetailsLabel, 0, 1)
        Me.MessageLayout.Location = New System.Drawing.Point(46, 0)
        Me.MessageLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.MessageLayout.Name = "MessageLayout"
        Me.MessageLayout.RowCount = 2
        Me.MessageLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.MessageLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.MessageLayout.Size = New System.Drawing.Size(340, 59)
        Me.MessageLayout.TabIndex = 1
        '
        'MainInstructionLabel
        '
        Me.MainInstructionLabel.AutoSize = True
        Me.MainInstructionLabel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.MainInstructionLabel.Location = New System.Drawing.Point(0, 0)
        Me.MainInstructionLabel.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.MainInstructionLabel.Name = "MainInstructionLabel"
        Me.MainInstructionLabel.Size = New System.Drawing.Size(117, 15)
        Me.MainInstructionLabel.TabIndex = 0
        Me.MainInstructionLabel.Text = "Update is available"
        '
        'DetailsLabel
        '
        Me.DetailsLabel.AutoSize = True
        Me.DetailsLabel.Location = New System.Drawing.Point(0, 21)
        Me.DetailsLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.DetailsLabel.Name = "DetailsLabel"
        Me.DetailsLabel.Size = New System.Drawing.Size(44, 15)
        Me.DetailsLabel.TabIndex = 1
        Me.DetailsLabel.Text = "Details"
        '
        'ButtonPanel
        '
        Me.ButtonPanel.AutoSize = True
        Me.ButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ButtonPanel.Controls.Add(Me.LaterButton)
        Me.ButtonPanel.Controls.Add(Me.SkipButton)
        Me.ButtonPanel.Controls.Add(Me.OpenButton)
        Me.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.ButtonPanel.Location = New System.Drawing.Point(0, 91)
        Me.ButtonPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Padding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.ButtonPanel.Size = New System.Drawing.Size(430, 51)
        Me.ButtonPanel.TabIndex = 1
        Me.ButtonPanel.WrapContents = False
        '
        'LaterButton
        '
        Me.LaterButton.DialogResult = System.Windows.Forms.DialogResult.No
        Me.LaterButton.Location = New System.Drawing.Point(337, 8)
        Me.LaterButton.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.LaterButton.Name = "LaterButton"
        Me.LaterButton.Size = New System.Drawing.Size(69, 27)
        Me.LaterButton.TabIndex = 2
        Me.LaterButton.Text = "Later"
        Me.LaterButton.UseVisualStyleBackColor = True
        '
        'SkipButton
        '
        Me.SkipButton.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.SkipButton.Location = New System.Drawing.Point(239, 8)
        Me.SkipButton.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.SkipButton.Name = "SkipButton"
        Me.SkipButton.Size = New System.Drawing.Size(92, 27)
        Me.SkipButton.TabIndex = 1
        Me.SkipButton.Text = "Skip"
        Me.SkipButton.UseVisualStyleBackColor = True
        '
        'OpenButton
        '
        Me.OpenButton.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.OpenButton.Location = New System.Drawing.Point(141, 8)
        Me.OpenButton.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(92, 27)
        Me.OpenButton.TabIndex = 0
        Me.OpenButton.Text = "Open"
        Me.OpenButton.UseVisualStyleBackColor = True
        '
        'UpdateAvailableDialog
        '
        Me.AcceptButton = Me.OpenButton
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.LaterButton
        Me.ClientSize = New System.Drawing.Size(430, 142)
        Me.Controls.Add(Me.RootLayout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdateAvailableDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Update"
        Me.RootLayout.ResumeLayout(False)
        Me.RootLayout.PerformLayout()
        Me.ContentPanel.ResumeLayout(False)
        Me.ContentPanel.PerformLayout()
        Me.ContentLayout.ResumeLayout(False)
        Me.ContentLayout.PerformLayout()
        CType(Me.InfoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MessageLayout.ResumeLayout(False)
        Me.MessageLayout.PerformLayout()
        Me.ButtonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RootLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel
    Friend WithEvents ContentLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents InfoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents MessageLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MainInstructionLabel As System.Windows.Forms.Label
    Friend WithEvents DetailsLabel As System.Windows.Forms.Label
    Friend WithEvents ButtonPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents OpenButton As System.Windows.Forms.Button
    Friend WithEvents SkipButton As System.Windows.Forms.Button
    Friend WithEvents LaterButton As System.Windows.Forms.Button
End Class
