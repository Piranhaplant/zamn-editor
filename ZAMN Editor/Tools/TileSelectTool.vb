Public Class TileSelectTool
    Inherits Tool

    Private selection As Selection
    Public pX As Integer = -1
    Public pY As Integer = -1

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        Me.SidePanel = SideContentType.Tiles
        Me.Status = "Click to select all tiles of the same type"
    End Sub

    Public Overrides Sub MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.MouseMove(e)
    End Sub

    Public Overrides Sub MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim nx As Integer = e.X \ 64
        Dim ny As Integer = e.Y \ 64
        If e.Button = MouseButtons.Left And nx < ed.EdControl.lvl.Width And ny < ed.EdControl.lvl.Height And nx >= 0 And ny >= 0 And (pX <> nx Or pY <> ny) Then
            pX = nx
            pY = ny
            selection.Clear()
            Dim curTileNum As Integer = ed.EdControl.lvl.Tiles(nx, ny)
            For m As Integer = 0 To ed.EdControl.lvl.Height - 1
                For l As Integer = 0 To ed.EdControl.lvl.Width - 1
                    If ed.EdControl.lvl.Tiles(l, m) = curTileNum Then
                        selection.selectPts(l, m) = True
                    End If
                Next
            Next
            selection.Refresh()
            selection.exists = True
            TilePicker.SelectedIndex = -1
            TilePicker.Invalidate()
            ed.EdControl.UpdateSelection()
            ed.EdControl.UndoMgr.merge = False
            ed.SetCopy(True)
        End If
    End Sub

    Public Overrides Sub MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        pX = -1
        pY = -1
    End Sub

    Public Overrides Sub Refresh()
        selection = ed.EdControl.selection
        ed.CheckCopy()
    End Sub

    Public Overrides Sub TileChanged()
        ed.EdControl.FillSelection()
    End Sub
End Class
