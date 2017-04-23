<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial MustInherit Class ObjectBrowser
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.canvas = New System.Windows.Forms.PictureBox()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.ExpandPanel1 = New ZAMNEditor.ExpandPanel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.canvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VScrl
        '
        Me.VScrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrl.Location = New System.Drawing.Point(123, 0)
        Me.VScrl.Name = "VScrl"
        Me.VScrl.Size = New System.Drawing.Size(17, 310)
        Me.VScrl.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.canvas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.VScrl)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ExpandPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(140, 339)
        Me.SplitContainer1.SplitterDistance = 310
        Me.SplitContainer1.TabIndex = 2
        '
        'canvas
        '
        Me.canvas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.canvas.Location = New System.Drawing.Point(0, 0)
        Me.canvas.Name = "canvas"
        Me.canvas.Size = New System.Drawing.Size(123, 310)
        Me.canvas.TabIndex = 2
        Me.canvas.TabStop = False
        '
        'ToolTips
        '
        Me.ToolTips.ShowAlways = True
        '
        'ExpandPanel1
        '
        Me.ExpandPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ExpandPanel1.Name = "ExpandPanel1"
        Me.ExpandPanel1.Size = New System.Drawing.Size(140, 25)
        Me.ExpandPanel1.TabIndex = 0
        '
        'ObjectBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Name = "ObjectBrowser"
        Me.Size = New System.Drawing.Size(140, 339)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.canvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VScrl As System.Windows.Forms.VScrollBar
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents canvas As System.Windows.Forms.PictureBox
    Friend WithEvents ExpandPanel1 As ZAMNEditor.ExpandPanel
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip

End Class
