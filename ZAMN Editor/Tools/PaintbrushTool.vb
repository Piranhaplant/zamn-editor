Public Class PaintbrushTool
    Inherits Tool

    Private pX As Integer = -1
    Private pY As Integer = -1
    Private selecting As Boolean = False

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        Me.SidePanel = SideContentType.Tiles
        Me.Status = "Click to paint tiles.  Hold Ctrl to select a tile type."
    End Sub

    Public Overrides Sub MouseDown(ByVal e As MouseEventArgs)
        selecting = (Control.ModifierKeys = Keys.Control)
        Me.MouseMove(e)
    End Sub

    Public Overrides Sub MouseMove(ByVal e As MouseEventArgs)
        Dim nx As Integer = e.X \ 64
        Dim ny As Integer = e.Y \ 64
        If (nx <> pX Or ny <> pY) And e.Button = MouseButtons.Left And _
        nx < ed.EdControl.lvl.Width And ny < ed.EdControl.lvl.Height And nx >= 0 And ny >= 0 Then
            If selecting Then
                TilePicker.SelectedIndex = ed.EdControl.lvl.Tiles(nx, ny)
                TilePicker.selectedTile = TilePicker.SelectedIndex
                TilePicker.ScollToSelected()
            ElseIf TilePicker.SelectedIndex > -1 Then
                ed.EdControl.UndoMgr.Do(New PaintTileAction(nx, ny, TilePicker.SelectedIndex))
                Repaint()
            End If
            pX = nx
            pY = ny
        End If
    End Sub

    Public Overrides Sub MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        pX = -1
        pY = -1
        ed.EdControl.UndoMgr.merge = False
        selecting = False
    End Sub
End Class
