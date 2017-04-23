<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LvlEdCtrl
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
        Me.VScrl = New System.Windows.Forms.VScrollBar()
        Me.HScrl = New System.Windows.Forms.HScrollBar()
        Me.canvas = New System.Windows.Forms.PictureBox()
        Me.SideContent = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.UpdateTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.canvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'VScrl
        '
        Me.VScrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrl.LargeChange = 8
        Me.VScrl.Location = New System.Drawing.Point(471, 0)
        Me.VScrl.Maximum = 8
        Me.VScrl.Name = "VScrl"
        Me.VScrl.Size = New System.Drawing.Size(17, 383)
        Me.VScrl.SmallChange = 8
        Me.VScrl.TabIndex = 0
        '
        'HScrl
        '
        Me.HScrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrl.LargeChange = 8
        Me.HScrl.Location = New System.Drawing.Point(-1, 383)
        Me.HScrl.Maximum = 8
        Me.HScrl.Name = "HScrl"
        Me.HScrl.Size = New System.Drawing.Size(472, 17)
        Me.HScrl.SmallChange = 8
        Me.HScrl.TabIndex = 1
        '
        'canvas
        '
        Me.canvas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.canvas.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.canvas.Location = New System.Drawing.Point(0, 0)
        Me.canvas.Name = "canvas"
        Me.canvas.Size = New System.Drawing.Size(471, 383)
        Me.canvas.TabIndex = 2
        Me.canvas.TabStop = False
        '
        'SideContent
        '
        Me.SideContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SideContent.Location = New System.Drawing.Point(0, 0)
        Me.SideContent.Name = "SideContent"
        Me.SideContent.Size = New System.Drawing.Size(150, 400)
        Me.SideContent.TabIndex = 3
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 400)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(644, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(135, 17)
        Me.Status.Text = "ZAMN Editor Beta v0.9.2"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SideContent)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.canvas)
        Me.SplitContainer1.Panel2.Controls.Add(Me.VScrl)
        Me.SplitContainer1.Panel2.Controls.Add(Me.HScrl)
        Me.SplitContainer1.Size = New System.Drawing.Size(642, 400)
        Me.SplitContainer1.SplitterDistance = 150
        Me.SplitContainer1.TabIndex = 5
        '
        'UpdateTimer
        '
        Me.UpdateTimer.Enabled = True
        Me.UpdateTimer.Interval = 1
        '
        'LvlEdCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Name = "LvlEdCtrl"
        Me.Size = New System.Drawing.Size(644, 422)
        CType(Me.canvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VScrl As System.Windows.Forms.VScrollBar
    Friend WithEvents HScrl As System.Windows.Forms.HScrollBar
    Friend WithEvents canvas As System.Windows.Forms.PictureBox
    Friend WithEvents SideContent As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents UpdateTimer As System.Windows.Forms.Timer

End Class
