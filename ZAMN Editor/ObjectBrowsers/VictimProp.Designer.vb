<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VictimProp
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
        Me.lblX = New System.Windows.Forms.Label()
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblAddr = New System.Windows.Forms.Label()
        Me.nudX = New System.Windows.Forms.NumericUpDown()
        Me.nudY = New System.Windows.Forms.NumericUpDown()
        Me.addr = New ZAMNEditor.AddressUpDown()
        CType(Me.nudX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(3, 5)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(17, 13)
        Me.lblX.TabIndex = 0
        Me.lblX.Text = "X:"
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(3, 31)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(17, 13)
        Me.lblY.TabIndex = 1
        Me.lblY.Text = "Y:"
        '
        'lblAddr
        '
        Me.lblAddr.AutoSize = True
        Me.lblAddr.Location = New System.Drawing.Point(3, 57)
        Me.lblAddr.Name = "lblAddr"
        Me.lblAddr.Size = New System.Drawing.Size(43, 13)
        Me.lblAddr.TabIndex = 2
        Me.lblAddr.Text = "Pointer:"
        '
        'nudX
        '
        Me.nudX.Location = New System.Drawing.Point(26, 3)
        Me.nudX.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudX.Name = "nudX"
        Me.nudX.Size = New System.Drawing.Size(52, 20)
        Me.nudX.TabIndex = 4
        '
        'nudY
        '
        Me.nudY.Location = New System.Drawing.Point(26, 29)
        Me.nudY.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudY.Name = "nudY"
        Me.nudY.Size = New System.Drawing.Size(52, 20)
        Me.nudY.TabIndex = 5
        '
        'addr
        '
        Me.addr.Location = New System.Drawing.Point(0, 76)
        Me.addr.Name = "addr"
        Me.addr.Size = New System.Drawing.Size(147, 20)
        Me.addr.TabIndex = 6
        Me.addr.Value = 512
        '
        'VictimProp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.addr)
        Me.Controls.Add(Me.nudY)
        Me.Controls.Add(Me.nudX)
        Me.Controls.Add(Me.lblAddr)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.lblX)
        Me.Name = "VictimProp"
        Me.Size = New System.Drawing.Size(150, 100)
        CType(Me.nudX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents lblAddr As System.Windows.Forms.Label
    Friend WithEvents nudX As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudY As System.Windows.Forms.NumericUpDown
    Friend WithEvents addr As ZAMNEditor.AddressUpDown

End Class
