<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ColumnOptionView
    Inherits System.Windows.Forms.UserControl

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
        Me.ColumnWidthInput = New System.Windows.Forms.NumericUpDown()
        Me.ColumnTitleInput = New System.Windows.Forms.TextBox()
        Me.SNoteButton = New System.Windows.Forms.Button()
        Me.STextButton = New System.Windows.Forms.Button()
        Me.LNoteButton = New System.Windows.Forms.Button()
        Me.LTextButton = New System.Windows.Forms.Button()
        Me.BGButton = New System.Windows.Forms.Button()
        CType(Me.ColumnWidthInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColumnWidthInput
        '
        Me.ColumnWidthInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ColumnWidthInput.Location = New System.Drawing.Point(0, 12)
        Me.ColumnWidthInput.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.ColumnWidthInput.Name = "ColumnWidthInput"
        Me.ColumnWidthInput.Size = New System.Drawing.Size(33, 23)
        Me.ColumnWidthInput.TabIndex = 0
        '
        'ColumnTitleInput
        '
        Me.ColumnTitleInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ColumnTitleInput.Location = New System.Drawing.Point(0, 34)
        Me.ColumnTitleInput.Name = "ColumnTitleInput"
        Me.ColumnTitleInput.Size = New System.Drawing.Size(33, 23)
        Me.ColumnTitleInput.TabIndex = 1
        '
        'SNoteButton
        '
        Me.SNoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SNoteButton.Location = New System.Drawing.Point(0, 63)
        Me.SNoteButton.Name = "SNoteButton"
        Me.SNoteButton.Size = New System.Drawing.Size(33, 66)
        Me.SNoteButton.TabIndex = 2
        Me.SNoteButton.UseVisualStyleBackColor = False
        '
        'STextButton
        '
        Me.STextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.STextButton.Location = New System.Drawing.Point(0, 128)
        Me.STextButton.Name = "STextButton"
        Me.STextButton.Size = New System.Drawing.Size(33, 66)
        Me.STextButton.TabIndex = 3
        Me.STextButton.UseVisualStyleBackColor = False
        '
        'LNoteButton
        '
        Me.LNoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LNoteButton.Location = New System.Drawing.Point(0, 193)
        Me.LNoteButton.Name = "LNoteButton"
        Me.LNoteButton.Size = New System.Drawing.Size(33, 66)
        Me.LNoteButton.TabIndex = 4
        Me.LNoteButton.UseVisualStyleBackColor = False
        '
        'LTextButton
        '
        Me.LTextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LTextButton.Location = New System.Drawing.Point(0, 258)
        Me.LTextButton.Name = "LTextButton"
        Me.LTextButton.Size = New System.Drawing.Size(33, 66)
        Me.LTextButton.TabIndex = 5
        Me.LTextButton.UseVisualStyleBackColor = False
        '
        'BGButton
        '
        Me.BGButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BGButton.Location = New System.Drawing.Point(0, 323)
        Me.BGButton.Name = "BGButton"
        Me.BGButton.Size = New System.Drawing.Size(33, 66)
        Me.BGButton.TabIndex = 6
        Me.BGButton.UseVisualStyleBackColor = False
        '
        'ColumnOptionView
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.BGButton)
        Me.Controls.Add(Me.LTextButton)
        Me.Controls.Add(Me.LNoteButton)
        Me.Controls.Add(Me.STextButton)
        Me.Controls.Add(Me.SNoteButton)
        Me.Controls.Add(Me.ColumnTitleInput)
        Me.Controls.Add(Me.ColumnWidthInput)
        Me.Name = "ColumnOptionView"
        Me.Size = New System.Drawing.Size(33, 389)
        CType(Me.ColumnWidthInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ColumnWidthInput As System.Windows.Forms.NumericUpDown
    Friend WithEvents ColumnTitleInput As System.Windows.Forms.TextBox
    Friend WithEvents SNoteButton As System.Windows.Forms.Button
    Friend WithEvents STextButton As System.Windows.Forms.Button
    Friend WithEvents LNoteButton As System.Windows.Forms.Button
    Friend WithEvents LTextButton As System.Windows.Forms.Button
    Friend WithEvents BGButton As System.Windows.Forms.Button
End Class
