<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TitlePageEdCtrl
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
        Me.canvas = New System.Windows.Forms.PictureBox()
        CType(Me.canvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'canvas
        '
        Me.canvas.BackColor = System.Drawing.Color.Black
        Me.canvas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.canvas.Location = New System.Drawing.Point(0, 0)
        Me.canvas.Name = "canvas"
        Me.canvas.Size = New System.Drawing.Size(256, 224)
        Me.canvas.TabIndex = 0
        Me.canvas.TabStop = False
        '
        'TitlePageEdCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.canvas)
        Me.Name = "TitlePageEdCtrl"
        Me.Size = New System.Drawing.Size(256, 224)
        CType(Me.canvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents canvas As System.Windows.Forms.PictureBox

End Class
