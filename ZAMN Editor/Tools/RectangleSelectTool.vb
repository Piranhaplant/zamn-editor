Public Class RectangleSelectTool
    Inherits Tool

    Private selection As Selection
    Private selecting As Boolean = False
    Public pX As Integer = -1
    Public pY As Integer = -1

    Private Const DefaultText As String = "Click to create a rectangle selection. Hold shift to add to the selection. Hold alt to remove from the selection."
    Private Const ShiftText As String = "Click to add a rectangle to the selection."
    Private Const AltText As String = "Click to remove a rectangle from the selection."
    Private Const DragText As String = "Rectangle {0}x{1}"

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        Me.SidePanel = SideContentType.Tiles
        Me.Status = DefaultText
    End Sub

    Public Overrides Sub MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim nx As Integer = e.X \ 64
        Dim ny As Integer = e.Y \ 64
        If e.Button = MouseButtons.Left And nx < ed.EdControl.lvl.Width And ny < ed.EdControl.lvl.Height And nx >= 0 And ny >= 0 Then
            If Control.ModifierKeys <> Keys.Shift And Control.ModifierKeys <> Keys.Alt Then
                selection.Clear()
                ed.SetCopy(False)
            End If
            selection.StartRect(nx, ny, (Control.ModifierKeys And Keys.Alt) <> Keys.None)
            ed.EdControl.UpdateSelection()
            ed.EdControl.UndoMgr.merge = False
            selecting = True
        End If
    End Sub

    Public Overrides Sub MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim nx As Integer = Math.Min(ed.EdControl.lvl.Width - 1, Math.Max(0, e.X \ 64))
        Dim ny As Integer = Math.Min(ed.EdControl.lvl.Height - 1, Math.Max(0, e.Y \ 64))
        If e.Button = MouseButtons.Left And selecting And (pX <> nx Or pY <> ny) Then
            selection.MoveTo(nx, ny)
            pX = nx
            pY = ny
            TilePicker.SelectedIndex = -1
            TilePicker.Invalidate()
            ed.EdControl.UpdateSelection()
            ed.EdControl.UndoMgr.merge = False
            If selection.erasing Then
                ed.CheckCopy()
            Else
                ed.SetCopy(True)
            End If
            Me.Status = String.Format(DragText, selection.width + 1, selection.height + 1)
            UpdateStatus()
        End If
    End Sub

    Public Overrides Sub MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If selecting Then
            pX = -1
            pY = -1
            selection.ApplySelection()
            ed.EdControl.UpdateSelection()
            ed.EdControl.UndoMgr.merge = False
            selecting = False
            ResetStatus()
        End If
    End Sub

    Public Overrides Sub Refresh()
        selection = ed.EdControl.selection
        ed.CheckCopy()
    End Sub

    Public Overrides Sub TileChanged()
        ed.EdControl.FillSelection()
    End Sub

    Public Overrides Sub KeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        ResetStatus()
    End Sub

    Public Overrides Sub KeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        ResetStatus()
    End Sub

    Private Sub ResetStatus()
        If Control.MouseButtons = MouseButtons.Left Then Return
        If Control.ModifierKeys = Keys.Shift Then
            Me.Status = ShiftText
        ElseIf Control.ModifierKeys = Keys.Alt Then
            Me.Status = AltText
        Else
            Me.Status = DefaultText
        End If
        UpdateStatus()
    End Sub
End Class