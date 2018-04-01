<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddressUpDown
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.lblDollars = New System.Windows.Forms.Label()
        Me.lblColon = New System.Windows.Forms.Label()
        Me.Address = New System.Windows.Forms.NumericUpDown()
        Me.DropButton = New System.Windows.Forms.Button()
        Me.DisplayType = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TypeSNES = New System.Windows.Forms.ToolStripMenuItem()
        Me.TypeHex = New System.Windows.Forms.ToolStripMenuItem()
        Me.Separator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TypeSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.nudHex = New System.Windows.Forms.NumericUpDown()
        CType(Me.Address, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DisplayType.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.nudHex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDollars
        '
        Me.lblDollars.AutoSize = True
        Me.lblDollars.Location = New System.Drawing.Point(2, 3)
        Me.lblDollars.Name = "lblDollars"
        Me.lblDollars.Size = New System.Drawing.Size(13, 13)
        Me.lblDollars.TabIndex = 1
        Me.lblDollars.Text = "$"
        '
        'lblColon
        '
        Me.lblColon.AutoSize = True
        Me.lblColon.Location = New System.Drawing.Point(44, 3)
        Me.lblColon.Name = "lblColon"
        Me.lblColon.Size = New System.Drawing.Size(10, 13)
        Me.lblColon.TabIndex = 2
        Me.lblColon.Text = ":"
        '
        'Address
        '
        Me.Address.Hexadecimal = True
        Me.Address.Location = New System.Drawing.Point(0, 0)
        Me.Address.Maximum = New Decimal(New Integer() {1048576, 0, 0, 0})
        Me.Address.Name = "Address"
        Me.Address.Size = New System.Drawing.Size(112, 20)
        Me.Address.TabIndex = 4
        '
        'DropButton
        '
        Me.DropButton.Image = Global.ZAMNEditor.My.Resources.Resources.DropArrow
        Me.DropButton.Location = New System.Drawing.Point(131, 0)
        Me.DropButton.Name = "DropButton"
        Me.DropButton.Size = New System.Drawing.Size(15, 20)
        Me.DropButton.TabIndex = 5
        Me.DropButton.UseVisualStyleBackColor = True
        '
        'DisplayType
        '
        Me.DisplayType.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TypeSNES, Me.TypeHex, Me.Separator1, Me.TypeSave})
        Me.DisplayType.Name = "DisplayType"
        Me.DisplayType.Size = New System.Drawing.Size(153, 76)
        '
        'TypeSNES
        '
        Me.TypeSNES.Name = "TypeSNES"
        Me.TypeSNES.Size = New System.Drawing.Size(152, 22)
        Me.TypeSNES.Text = "SNES LoROM"
        '
        'TypeHex
        '
        Me.TypeHex.Name = "TypeHex"
        Me.TypeHex.Size = New System.Drawing.Size(152, 22)
        Me.TypeHex.Text = "Hexadecimal"
        '
        'Separator1
        '
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Size = New System.Drawing.Size(149, 6)
        '
        'TypeSave
        '
        Me.TypeSave.Name = "TypeSave"
        Me.TypeSave.Size = New System.Drawing.Size(152, 22)
        Me.TypeSave.Text = "Save as default"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Address)
        Me.Panel1.Controls.Add(Me.lblColon)
        Me.Panel1.Location = New System.Drawing.Point(18, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 20)
        Me.Panel1.TabIndex = 6
        '
        'nudHex
        '
        Me.nudHex.Hexadecimal = True
        Me.nudHex.Location = New System.Drawing.Point(18, 0)
        Me.nudHex.Maximum = New Decimal(New Integer() {4194815, 0, 0, 0})
        Me.nudHex.Name = "nudHex"
        Me.nudHex.Size = New System.Drawing.Size(112, 20)
        Me.nudHex.TabIndex = 5
        '
        'AddressUpDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DropButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.nudHex)
        Me.Controls.Add(Me.lblDollars)
        Me.Name = "AddressUpDown"
        Me.Size = New System.Drawing.Size(147, 20)
        CType(Me.Address, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DisplayType.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudHex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDollars As System.Windows.Forms.Label
    Friend WithEvents lblColon As System.Windows.Forms.Label
    Friend WithEvents Address As System.Windows.Forms.NumericUpDown
    Friend WithEvents DropButton As System.Windows.Forms.Button
    Friend WithEvents DisplayType As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TypeSNES As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TypeHex As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TypeSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents nudHex As System.Windows.Forms.NumericUpDown

End Class
