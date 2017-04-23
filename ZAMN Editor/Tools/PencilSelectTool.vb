Public Class PencilSelectTool
    Inherits Tool

    Private selection As Selection
    Public pX As Integer = -1
    Public pY As Integer = -1
    Public erasing As Boolean

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        Me.SidePanel = SideContentType.Tiles
        Me.Status = "Click to select tiles. Hold alt to unselect tiles"
    End Sub

    Public Overrides Sub MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        erasing = Control.ModifierKeys = Keys.Alt
        Me.MouseMove(e)
    End Sub

    Public Overrides Sub MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim nx As Integer = e.X \ 64
        Dim ny As Integer = e.Y \ 64
        If e.Button = MouseButtons.Left And nx < ed.EdControl.lvl.Width _
        And ny < ed.EdControl.lvl.Height And nx >= 0 And ny >= 0 And (pX <> nx Or pY <> ny) Then
            pX = nx
            pY = ny
            selection.selectPts(nx, ny) = Not erasing
            selection.Refresh()
            selection.exists = True
            TilePicker.SelectedIndex = -1
            TilePicker.Invalidate()
            ed.EdControl.UpdateSelection()
            ed.EdControl.UndoMgr.merge = False
            If erasing Then
                ed.CheckCopy()
            Else
                ed.SetCopy(True)
            End If
        End If
    End Sub

    Public Overrides Sub MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        pX = -1
        pY = -1
    End Sub

    Public Overrides Sub Refresh()
        selection = ed.EdControl.selection
    End Sub

    Public Overrides Sub TileChanged()
        ed.EdControl.FillSelection()
    End Sub
End Class
