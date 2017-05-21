<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NRMProp
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
        Me.addr = New ZAMNEditor.AddressUpDown()
        Me.nudY = New System.Windows.Forms.NumericUpDown()
        Me.nudX = New System.Windows.Forms.NumericUpDown()
        Me.lblAddr = New System.Windows.Forms.Label()
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.nudExtra = New System.Windows.Forms.NumericUpDown()
        Me.lblExtra = New System.Windows.Forms.Label()
        CType(Me.nudY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'addr
        '
        Me.addr.Location = New System.Drawing.Point(0, 102)
        Me.addr.Name = "addr"
        Me.addr.Size = New System.Drawing.Size(147, 20)
        Me.addr.TabIndex = 12
        Me.addr.Value = 512
        '
        'nudY
        '
        Me.nudY.Location = New System.Drawing.Point(43, 29)
        Me.nudY.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudY.Name = "nudY"
        Me.nudY.Size = New System.Drawing.Size(52, 20)
        Me.nudY.TabIndex = 11
        '
        'nudX
        '
        Me.nudX.Location = New System.Drawing.Point(43, 3)
        Me.nudX.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudX.Name = "nudX"
        Me.nudX.Size = New System.Drawing.Size(52, 20)
        Me.nudX.TabIndex = 10
        '
        'lblAddr
        '
        Me.lblAddr.AutoSize = True
        Me.lblAddr.Location = New System.Drawing.Point(3, 83)
        Me.lblAddr.Name = "lblAddr"
        Me.lblAddr.Size = New System.Drawing.Size(43, 13)
        Me.lblAddr.TabIndex = 9
        Me.lblAddr.Text = "Pointer:"
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(3, 31)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(17, 13)
        Me.lblY.TabIndex = 8
        Me.lblY.Text = "Y:"
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(3, 5)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(17, 13)
        Me.lblX.TabIndex = 7
        Me.lblX.Text = "X:"
        '
        'nudExtra
        '
        Me.nudExtra.Location = New System.Drawing.Point(43, 55)
        Me.nudExtra.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudExtra.Name = "nudExtra"
        Me.nudExtra.Size = New System.Drawing.Size(52, 20)
        Me.nudExtra.TabIndex = 14
        '
        'lblExtra
        '
        Me.lblExtra.AutoSize = True
        Me.lblExtra.Location = New System.Drawing.Point(3, 57)
        Me.lblExtra.Name = "lblExtra"
        Me.lblExtra.Size = New System.Drawing.Size(34, 13)
        Me.lblExtra.TabIndex = 13
        Me.lblExtra.Text = "Extra:"
        '
        'NRMProp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.nudExtra)
        Me.Controls.Add(Me.lblExtra)
        Me.Controls.Add(Me.addr)
        Me.Controls.Add(Me.nudY)
        Me.Controls.Add(Me.nudX)
        Me.Controls.Add(Me.lblAddr)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.lblX)
        Me.Name = "NRMProp"
        Me.Size = New System.Drawing.Size(150, 129)
        CType(Me.nudY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents addr As ZAMNEditor.AddressUpDown
    Friend WithEvents nudY As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudX As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAddr As System.Windows.Forms.Label
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents nudExtra As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblExtra As System.Windows.Forms.Label

End Class
