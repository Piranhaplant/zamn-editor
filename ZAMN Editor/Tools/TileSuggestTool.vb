Public Class TileSuggestTool
    Inherits Tool

    Private TilesetNum As Integer
    Private XStart As Integer = -1
    Private YStart As Integer = -1
    Private XEnd As Integer = -1
    Private YEnd As Integer = -1
    Private pX As Integer = -1
    Private pY As Integer = -1
    Private Direction As Integer = -1
    Private starting As Boolean = False
    Private linePen As New Pen(Color.White, 2)

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        Me.SidePanel = SideContentType.Tiles
        Me.Status = "Click a tile and drag to an adjacent tile to show all possible tiles"
    End Sub

    Public Overrides Sub MouseDown(ByVal e As MouseEventArgs)
        starting = True
        Direction = -1
        Me.MouseMove(e)
    End Sub

    Public Overrides Sub MouseMove(ByVal e As MouseEventArgs)
        Dim nx As Integer = e.X \ 64
        Dim ny As Integer = e.Y \ 64
        If (nx <> pX Or ny <> pY) And e.Button = MouseButtons.Left And _
        nx < ed.EdControl.lvl.Width And ny < ed.EdControl.lvl.Height And nx >= 0 And ny >= 0 Then
            If starting Then
                XStart = nx
                YStart = ny
                starting = False
            End If
            pX = nx
            pY = ny
            XEnd = nx
            YEnd = ny
            Direction = -1
            If nx = XStart - 1 And ny = YStart Then
                Direction = 0
            ElseIf ny = YStart - 1 And nx = XStart Then
                Direction = 1
            ElseIf nx = XStart + 1 And ny = YStart Then
                Direction = 2
            ElseIf ny = YStart + 1 And nx = XStart Then
                Direction = 3
            End If
            Repaint()
        End If
    End Sub

    Public Overrides Sub MouseUp(ByVal e As MouseEventArgs)
        If Direction = -1 Then
            XStart = -1
            Repaint()
            TilePicker.SetAll()
        Else
            TilePicker.SetTiles(TileSuggestList.GetList(TilesetNum, ed.EdControl.lvl.Tiles(XStart, YStart), Direction))
            TilePicker.SelectedIndex = -1
            TilePicker.Invalidate()
        End If
        pX = -1
        ed.EdControl.UndoMgr.merge = False
    End Sub

    Public Overrides Sub Paint(ByVal g As Graphics)
        If XStart > -1 Then
            g.DrawImage(My.Resources.Circle, XStart * 64 + 28, YStart * 64 + 28, 8, 8)
        End If
        If Direction > -1 Then
            g.DrawLine(linePen, XStart * 64 + 32, YStart * 64 + 32, XEnd * 64 + 32, YEnd * 64 + 32)
            Dim b As Bitmap = My.Resources.Arrow
            b.RotateFlip(Direction)
            g.DrawImage(b, XEnd * 64 + 26, YEnd * 64 + 26, 12, 12)
        End If
    End Sub

    Public Overrides Sub Refresh()
        XStart = -1
        Direction = -1
        TilesetNum = Array.IndexOf(Pointers.SuggestTilesets, ed.EdControl.lvl.tileset.address)
    End Sub

    Public Overrides Sub TileChanged()
        If Direction > -1 Then
            ed.EdControl.UndoMgr.Do(New TileSuggestAction(XEnd, YEnd, TilePicker.SelectedTile))
            Repaint()
        End If
    End Sub
End Class
