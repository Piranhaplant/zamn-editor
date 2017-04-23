<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingLevel
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
        Me.Progress = New System.Windows.Forms.ProgressBar()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.LoadText = New System.Windows.Forms.Label()
        Me.Loader = New System.ComponentModel.BackgroundWorker()
        Me.FailedPanel = New System.Windows.Forms.Panel()
        Me.OK = New System.Windows.Forms.Button()
        Me.FailedText = New System.Windows.Forms.Label()
        Me.FailedList = New System.Windows.Forms.ListBox()
        Me.FailedPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Progress
        '
        Me.Progress.Location = New System.Drawing.Point(25, 24)
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(330, 23)
        Me.Progress.Step = 1
        Me.Progress.TabIndex = 0
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(280, 68)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 1
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'LoadText
        '
        Me.LoadText.AutoSize = True
        Me.LoadText.Location = New System.Drawing.Point(22, 73)
        Me.LoadText.Name = "LoadText"
        Me.LoadText.Size = New System.Drawing.Size(54, 13)
        Me.LoadText.TabIndex = 2
        Me.LoadText.Text = "Loading..."
        '
        'Loader
        '
        Me.Loader.WorkerReportsProgress = True
        Me.Loader.WorkerSupportsCancellation = True
        '
        'FailedPanel
        '
        Me.FailedPanel.Controls.Add(Me.OK)
        Me.FailedPanel.Controls.Add(Me.FailedText)
        Me.FailedPanel.Controls.Add(Me.FailedList)
        Me.FailedPanel.Location = New System.Drawing.Point(1, 1)
        Me.FailedPanel.Name = "FailedPanel"
        Me.FailedPanel.Size = New System.Drawing.Size(370, 221)
        Me.FailedPanel.TabIndex = 3
        Me.FailedPanel.Visible = False
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(284, 190)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(75, 23)
        Me.OK.TabIndex = 6
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyleBackColor = True
        '
        'FailedText
        '
        Me.FailedText.Location = New System.Drawing.Point(11, 187)
        Me.FailedText.Name = "FailedText"
        Me.FailedText.Size = New System.Drawing.Size(267, 31)
        Me.FailedText.TabIndex = 5
        Me.FailedText.Text = "These level files contained errors and could not be opened."
        '
        'FailedList
        '
        Me.FailedList.FormattingEnabled = True
        Me.FailedList.HorizontalScrollbar = True
        Me.FailedList.Location = New System.Drawing.Point(11, 11)
        Me.FailedList.Name = "FailedList"
        Me.FailedList.Size = New System.Drawing.Size(348, 173)
        Me.FailedList.TabIndex = 4
        '
        'LoadingLevel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 216)
        Me.ControlBox = False
        Me.Controls.Add(Me.FailedPanel)
        Me.Controls.Add(Me.LoadText)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Progress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoadingLevel"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Loading..."
        Me.FailedPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Progress As System.Windows.Forms.ProgressBar
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents LoadText As System.Windows.Forms.Label
    Friend WithEvents Loader As System.ComponentModel.BackgroundWorker
    Friend WithEvents FailedPanel As System.Windows.Forms.Panel
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents FailedText As System.Windows.Forms.Label
    Friend WithEvents FailedList As System.Windows.Forms.ListBox
End Class
