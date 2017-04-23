<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasswordEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlPasswords = New System.Windows.Forms.Panel()
        Me.lblVictims = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPasswords
        '
        Me.pnlPasswords.Location = New System.Drawing.Point(28, 36)
        Me.pnlPasswords.Name = "pnlPasswords"
        Me.pnlPasswords.Size = New System.Drawing.Size(448, 250)
        Me.pnlPasswords.TabIndex = 0
        '
        'lblVictims
        '
        Me.lblVictims.AutoSize = True
        Me.lblVictims.Location = New System.Drawing.Point(235, 9)
        Me.lblVictims.Name = "lblVictims"
        Me.lblVictims.Size = New System.Drawing.Size(40, 13)
        Me.lblVictims.TabIndex = 1
        Me.lblVictims.Text = "Victims"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(346, 292)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(152, 23)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "Generate new passwords"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ZAMNEditor.My.Resources.Resources.LevelTxt
        Me.PictureBox1.Location = New System.Drawing.Point(9, 149)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(9, 25)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'PasswordEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 322)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.lblVictims)
        Me.Controls.Add(Me.pnlPasswords)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PasswordEditor"
        Me.ShowIcon = False
        Me.Text = "Password Editor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlPasswords As System.Windows.Forms.Panel
    Friend WithEvents lblVictims As System.Windows.Forms.Label
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
