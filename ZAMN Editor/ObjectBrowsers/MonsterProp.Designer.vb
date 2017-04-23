<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonsterProp
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
        Me.nudY = New System.Windows.Forms.NumericUpDown()
        Me.nudX = New System.Windows.Forms.NumericUpDown()
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.lblRadius = New System.Windows.Forms.Label()
        Me.nudRadius = New System.Windows.Forms.NumericUpDown()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.nudDelay = New System.Windows.Forms.NumericUpDown()
        Me.addr = New ZAMNEditor.AddressUpDown()
        Me.lblAddr = New System.Windows.Forms.Label()
        CType(Me.nudY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRadius, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudY
        '
        Me.nudY.Location = New System.Drawing.Point(52, 29)
        Me.nudY.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudY.Name = "nudY"
        Me.nudY.Size = New System.Drawing.Size(52, 20)
        Me.nudY.TabIndex = 9
        '
        'nudX
        '
        Me.nudX.Location = New System.Drawing.Point(52, 3)
        Me.nudX.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudX.Name = "nudX"
        Me.nudX.Size = New System.Drawing.Size(52, 20)
        Me.nudX.TabIndex = 8
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(29, 31)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(17, 13)
        Me.lblY.TabIndex = 7
        Me.lblY.Text = "Y:"
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(29, 5)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(17, 13)
        Me.lblX.TabIndex = 6
        Me.lblX.Text = "X:"
        '
        'lblRadius
        '
        Me.lblRadius.AutoSize = True
        Me.lblRadius.Location = New System.Drawing.Point(3, 57)
        Me.lblRadius.Name = "lblRadius"
        Me.lblRadius.Size = New System.Drawing.Size(43, 13)
        Me.lblRadius.TabIndex = 10
        Me.lblRadius.Text = "Radius:"
        '
        'nudRadius
        '
        Me.nudRadius.Location = New System.Drawing.Point(52, 55)
        Me.nudRadius.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudRadius.Name = "nudRadius"
        Me.nudRadius.Size = New System.Drawing.Size(52, 20)
        Me.nudRadius.TabIndex = 11
        '
        'lblDelay
        '
        Me.lblDelay.AutoSize = True
        Me.lblDelay.Location = New System.Drawing.Point(9, 83)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(37, 13)
        Me.lblDelay.TabIndex = 12
        Me.lblDelay.Text = "Delay:"
        '
        'nudDelay
        '
        Me.nudDelay.Location = New System.Drawing.Point(52, 81)
        Me.nudDelay.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudDelay.Name = "nudDelay"
        Me.nudDelay.Size = New System.Drawing.Size(52, 20)
        Me.nudDelay.TabIndex = 13
        '
        'addr
        '
        Me.addr.Location = New System.Drawing.Point(0, 127)
        Me.addr.Name = "addr"
        Me.addr.Size = New System.Drawing.Size(147, 20)
        Me.addr.TabIndex = 15
        Me.addr.Value = 512
        '
        'lblAddr
        '
        Me.lblAddr.AutoSize = True
        Me.lblAddr.Location = New System.Drawing.Point(3, 108)
        Me.lblAddr.Name = "lblAddr"
        Me.lblAddr.Size = New System.Drawing.Size(43, 13)
        Me.lblAddr.TabIndex = 14
        Me.lblAddr.Text = "Pointer:"
        '
        'MonsterProp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.addr)
        Me.Controls.Add(Me.lblAddr)
        Me.Controls.Add(Me.nudDelay)
        Me.Controls.Add(Me.lblDelay)
        Me.Controls.Add(Me.nudRadius)
        Me.Controls.Add(Me.lblRadius)
        Me.Controls.Add(Me.nudY)
        Me.Controls.Add(Me.nudX)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.lblX)
        Me.Name = "MonsterProp"
        CType(Me.nudY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRadius, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudY As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudX As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents lblRadius As System.Windows.Forms.Label
    Friend WithEvents nudRadius As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDelay As System.Windows.Forms.Label
    Friend WithEvents nudDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents addr As ZAMNEditor.AddressUpDown
    Friend WithEvents lblAddr As System.Windows.Forms.Label

End Class
