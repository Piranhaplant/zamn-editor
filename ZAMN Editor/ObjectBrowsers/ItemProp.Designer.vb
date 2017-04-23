<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemProp
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
        Me.nudNum = New System.Windows.Forms.NumericUpDown()
        Me.lblNum = New System.Windows.Forms.Label()
        CType(Me.nudY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudY
        '
        Me.nudY.Location = New System.Drawing.Point(41, 29)
        Me.nudY.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudY.Name = "nudY"
        Me.nudY.Size = New System.Drawing.Size(52, 20)
        Me.nudY.TabIndex = 9
        '
        'nudX
        '
        Me.nudX.Location = New System.Drawing.Point(41, 3)
        Me.nudX.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudX.Name = "nudX"
        Me.nudX.Size = New System.Drawing.Size(52, 20)
        Me.nudX.TabIndex = 8
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(18, 31)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(17, 13)
        Me.lblY.TabIndex = 7
        Me.lblY.Text = "Y:"
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(18, 5)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(17, 13)
        Me.lblX.TabIndex = 6
        Me.lblX.Text = "X:"
        '
        'nudNum
        '
        Me.nudNum.Location = New System.Drawing.Point(41, 55)
        Me.nudNum.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudNum.Name = "nudNum"
        Me.nudNum.Size = New System.Drawing.Size(52, 20)
        Me.nudNum.TabIndex = 11
        '
        'lblNum
        '
        Me.lblNum.AutoSize = True
        Me.lblNum.Location = New System.Drawing.Point(3, 57)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(32, 13)
        Me.lblNum.TabIndex = 10
        Me.lblNum.Text = "Num:"
        '
        'ItemProp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.nudNum)
        Me.Controls.Add(Me.lblNum)
        Me.Controls.Add(Me.nudY)
        Me.Controls.Add(Me.nudX)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.lblX)
        Me.Name = "ItemProp"
        Me.Size = New System.Drawing.Size(150, 80)
        CType(Me.nudY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudY As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudX As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents nudNum As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblNum As System.Windows.Forms.Label

End Class
