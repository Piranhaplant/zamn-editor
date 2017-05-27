Public Class PasteTilesTool
    Inherits Tool

    Public NewTiles As Integer(,)
    Public width As Integer
    Public height As Integer
    Public xPos As Integer
    Public yPos As Integer
    Public xPosT As Integer
    Public yPosT As Integer
    Public pasting As Boolean = False
    Public moving As Boolean = False
    Public DragXOff As Integer
    Public DragYOff As Integer
    Public FinalX As Integer
    Public FinalY As Integer
    Public deltaX As Decimal
    Public deltaY As Decimal
    Public ending As Boolean = False
    Public selection As Selection
    Public gp As Drawing2D.GraphicsPath
    Public WithEvents moveTmr As New Timer

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        moveTmr.Interval = 1
    End Sub

    Public Event DonePasting(ByVal sender As Object, ByVal e As EventArgs)

    Public Overrides Function Paste() As Boolean
        pasting = False
        Dim txt As String = ZAMNClip.FromClip(Clipboard.GetText)
        If txt.StartsWith("T") Then
            txt = Mid(txt, 2)
            ed.SelectAll(False)
            width = CInt("&H" & Mid(txt, 1, 2))
            height = CInt("&H" & Mid(txt, 3, 2))
            ReDim NewTiles(width - 1, height - 1)
            selection = New Selection(width, height)
            For l As Integer = 0 To txt.Length - 6 Step 2
                Dim l2 As Integer = l \ 2
                If txt(l + 5) = "-" Then
                    NewTiles(l2 Mod width, l2 \ width) = -1
                Else
                    NewTiles(l2 Mod width, l2 \ width) = CInt("&H" & Mid(txt, l + 5, 2))
                    selection.selectPts(l2 Mod width, l2 \ width) = True
                End If
            Next
            selection.Refresh()
            gp = selection.ToGP
            pasting = True
            xPosT = Math.Ceiling(ed.EdControl.HScrl.Value / 64)
            yPosT = Math.Ceiling(ed.EdControl.VScrl.Value / 64)
            xPos = xPosT * 64
            yPos = yPosT * 64
            MoveGP(gp, xPos, yPos)
            Repaint()
        Else
            RaiseEvent DonePasting(Me, EventArgs.Empty)
        End If
    End Function

    Public Sub MoveGP(ByVal gp As Drawing2D.GraphicsPath, ByVal dX As Integer, ByVal dY As Integer)
        If dX = 0 And dY = 0 Then Return
        Dim matrix As New Drawing2D.Matrix
        matrix.Translate(dX, dY)
        gp.Transform(matrix)
        matrix.Dispose()
    End Sub

    Public Overrides Sub Paint(ByVal g As System.Drawing.Graphics)
        For y As Integer = 0 To height - 1
            For x As Integer = 0 To width - 1
                If NewTiles(x, y) > -1 Then
                    g.DrawImage(ed.EdControl.lvl.tileset.images(NewTiles(x, y)), xPos + x * 64, yPos + y * 64)
                End If
            Next
        Next
        g.FillPath(ed.EdControl.fillBrush, gp)
        g.DrawPath(Pens.White, gp)
        g.DrawPath(ed.EdControl.borderPen, gp)
    End Sub

    Public Overrides Sub MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If moving Then
            Dim px As Integer = xPos, py As Integer = yPos
            xPos = Math.Max(0, Math.Min((ed.EdControl.lvl.Width - width) * 64, e.X - DragXOff))
            yPos = Math.Max(0, Math.Min((ed.EdControl.lvl.Height - height) * 64, e.Y - DragYOff))
            MoveGP(gp, xPos - px, yPos - py)
            Repaint()
        Else
            Dim x As Integer = (e.X - xPos) \ 64
            Dim y As Integer = (e.Y - yPos) \ 64
            If pasting And e.X >= xPos And x < width And e.Y >= yPos And y < height AndAlso NewTiles(x, y) > -1 Then
                SetCursor(Cursors.SizeAll)
            Else
                SetCursor(Cursors.Arrow)
            End If
        End If
    End Sub

    Public Overrides Sub MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim x As Integer = (e.X - xPos) \ 64
        Dim y As Integer = (e.Y - yPos) \ 64
        If pasting And e.X >= xPos And x < width And e.Y >= yPos And y < height AndAlso NewTiles(x, y) > -1 Then
            moving = True
            DragXOff = e.X - xPos
            DragYOff = e.Y - yPos
            moveTmr.Stop()
            Return
        End If
        If moveTmr.Enabled Then
            xPos = FinalX
            yPos = FinalY
            xPosT = xPos \ 64
            yPosT = yPos \ 64
            moveTmr.Stop()
        End If
        RaiseEvent DonePasting(Me, EventArgs.Empty)
    End Sub

    Public Overrides Sub MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        moving = False
        If xPos Mod 64 < 32 Then
            FinalX = Math.Floor(xPos / 64) * 64
        Else
            FinalX = Math.Ceiling(xPos / 64) * 64
        End If
        If yPos Mod 64 < 32 Then
            FinalY = Math.Floor(yPos / 64) * 64
        Else
            FinalY = Math.Ceiling(yPos / 64) * 64
        End If
        Repaint()
        DragXOff = FinalX - xPos
        DragYOff = FinalY - yPos
        If Math.Abs(DragXOff) < Math.Abs(DragYOff) Then
            deltaX = Math.Sign(DragXOff) * Math.Abs(DragXOff / DragYOff) * 2
            deltaY = Math.Sign(DragYOff) * 2
        ElseIf DragXOff <> 0 Or DragYOff <> 0 Then
            deltaY = Math.Sign(DragYOff) * Math.Abs(DragYOff / DragXOff) * 2
            deltaX = Math.Sign(DragXOff) * 2
        End If
        DragXOff = xPos
        DragYOff = yPos
        xPosT = 0
        moveTmr.Start()
    End Sub

    Private Sub PasteTilesTool_DonePasting(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DonePasting
        If pasting Then
            ed.EdControl.UndoMgr.Do(New PasteTilesAction(xPosT, yPosT, NewTiles))
            SetCursor(Cursors.Arrow)
        End If
        pasting = False
    End Sub

    Private Sub moveTmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles moveTmr.Tick
        If xPos = FinalX And yPos = FinalY Then
            moveTmr.Stop()
            xPosT = xPos \ 64
            yPosT = yPos \ 64
        Else
            Dim px As Integer = xPos, py As Integer = yPos
            xPosT += 10
            xPos = DragXOff + deltaX * xPosT
            yPos = DragYOff + deltaY * xPosT
            If deltaX > 0 Then
                xPos = Math.Min(xPos, FinalX)
            Else
                xPos = Math.Max(xPos, FinalX)
            End If
            If deltaY > 0 Then
                yPos = Math.Min(yPos, FinalY)
            Else
                yPos = Math.Max(yPos, FinalY)
            End If
            MoveGP(gp, xPos - px, yPos - py)
        End If
        Repaint()
    End Sub
End Class
