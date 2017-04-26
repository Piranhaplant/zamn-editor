Public Class LvlEdCtrl
    Public lvl As Level
    Public t As Tool
    Public TilePicker As TilesetBrowser
    Public ItemPicker As ItemBrowser
    Public VictimPicker As VictimBrowser
    Public NRMPicker As NRMBrowser
    Public MonsterPicker As MonsterBrowser
    Public BMonsterPicker As New BMonsterBrowser
    Public SpritePicker As SpriteBrowser

    Public Grid As Boolean
    Public priority As Boolean
    Public selection As Selection
    Public UndoMgr As UndoManager
    Public Active As Boolean

    Public fillBrush As SolidBrush
    Public eraserBrush As SolidBrush
    Public borderPen As Pen
    Public selectionGP As Drawing2D.GraphicsPath
    Public eraserRect As Rectangle
    Public forceMove As Boolean = False
    Public scrollEnd As Integer
    Public scrollDelta As Integer
    Public scrollTarget As ScrollBar
    Public dragViewX As Integer
    Public dragViewY As Integer

    Public zoom As Single = 1.0F
    Public zoomer As SmoothZoom

    Private smoothScolling As Boolean = False
    Private dragging As Boolean = False
    Private repaintRequested As Boolean = True

    'TESTING
    Public ContextTable As TableContextMenu
    Public ContextTableStrip As ToolStripDropDown

    Public Sub New()
        InitializeComponent()
        fillBrush = New SolidBrush(Color.FromArgb(96, 0, 0, 0))
        eraserBrush = New SolidBrush(Color.FromArgb(128, 255, 255, 255))
        borderPen = New Pen(Color.Black)
        borderPen.DashOffset = 0
        borderPen.DashPattern = New Single() {4, 4}
    End Sub

    Public Sub LoadLevel(ByVal lvl As Level)
        Me.lvl = lvl
        ItemPicker = New ItemBrowser(lvl.GFX)
        VictimPicker = New VictimBrowser(lvl.GFX)
        NRMPicker = New NRMBrowser(lvl.GFX)
        MonsterPicker = New MonsterBrowser(lvl.GFX)
        TilePicker = New TilesetBrowser(lvl.tileset)
        SpritePicker = New SpriteBrowser(lvl.GFX)
        selection = New Selection(lvl.Width, lvl.Height)
        UpdateScrollBars()
        Status.Text = "ZAMN Editor Beta v" & Application.ProductVersion

        'TESTING
        ContextTable = New TableContextMenu()
        For Each i As Image In lvl.GFX.VictimImages
            Dim item As TableContextMenuItem = New TableContextMenuItem()
            item.Image = i
            ContextTable.Items.Add(item)
        Next
        ContextTableStrip = New ContextMenuStrip()
        ContextTableStrip.Items.Add(New ToolStripControlHost(ContextTable))
    End Sub

    Public Sub SetSidePanel(ByVal ctrl As Control)
        SideContent.Controls.Clear()
        SideContent.Controls.Add(ctrl)
        ctrl.Dock = DockStyle.Fill
    End Sub

    Public Sub SetStatusText(ByVal txt As String)
        Status.Text = txt
    End Sub

    Public Sub SetZoom(ByVal zoomLevel As Single)
        If zoom = zoomLevel Then Return
        Dim centerX As Integer = (HScrl.Value * 2 + HScrl.LargeChange) / 2 / zoom
        Dim centerY As Integer = (VScrl.Value * 2 + VScrl.LargeChange) / 2 / zoom
        zoom = zoomLevel
        UpdateScrollBars()
        HScrl.Value = Math.Min(Math.Max(0, centerX * zoom - HScrl.LargeChange / 2), Math.Max(0, HScrl.Maximum - HScrl.LargeChange))
        VScrl.Value = Math.Min(Math.Max(0, centerY * zoom - VScrl.LargeChange / 2), Math.Max(0, VScrl.Maximum - VScrl.LargeChange))
    End Sub

    Public Sub Repaint()
        repaintRequested = True
    End Sub

    Public Sub UpdateSelection()
        selectionGP = selection.ToGP()
        eraserRect = selection.GetEraserRect()
        Repaint()
    End Sub

    Public Sub SetCursor(ByVal c As Cursor)
        canvas.Cursor = c
    End Sub

    Public Sub FillSelection()
        If selection.FindVisible() Then
            UndoMgr.Do(New FillSelectionAction(TilePicker.selectedTile))
        End If
    End Sub

    Public Sub UpdateScrollBars()
        If lvl Is Nothing Then Return
        HScrl.Maximum = lvl.Width * 64 * zoom
        VScrl.Maximum = lvl.Height * 64 * zoom
        HScrl.LargeChange = canvas.Width
        VScrl.LargeChange = canvas.Height
        HScrl.Value = Math.Min(HScrl.Value, Math.Max(0, HScrl.Maximum - HScrl.LargeChange))
        VScrl.Value = Math.Min(VScrl.Value, Math.Max(0, VScrl.Maximum - VScrl.LargeChange))
        HScrl.Enabled = (HScrl.Maximum > HScrl.LargeChange)
        VScrl.Enabled = (VScrl.Maximum > VScrl.LargeChange)
        Repaint()
    End Sub

    Private Sub canvas_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles canvas.Paint
        Render(e.Graphics, True)
    End Sub

    Public Sub Render(ByVal g As Graphics, ByVal forEditor As Boolean)
        If lvl Is Nothing Then Return
        'If zoom > 1 Then
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        'End If
        If forEditor Then
            g.TranslateTransform(-HScrl.Value, -VScrl.Value)
            g.ScaleTransform(zoom, zoom)
            For l As Integer = HScrl.Value \ (64 * zoom) To Math.Min(lvl.Width - 1, (HScrl.Value + canvas.Width) \ (64 * zoom) + 1)
                For m As Integer = VScrl.Value \ (64 * zoom) To Math.Min(lvl.Height - 1, (VScrl.Value + canvas.Height) \ (64 * zoom) + 1)
                    If priority Then
                        g.DrawImage(lvl.tileset.priorityImages(lvl.Tiles(l, m)), l * 64, m * 64)
                    Else
                        g.DrawImage(lvl.tileset.images(lvl.Tiles(l, m)), l * 64, m * 64)
                    End If
                Next
            Next
        Else
            For l As Integer = 0 To lvl.Width - 1
                For m As Integer = 0 To lvl.Height - 1
                    g.DrawImage(lvl.tileset.images(lvl.Tiles(l, m)), l * 64, m * 64)
                Next
            Next
        End If
        For Each v As Victim In lvl.objects.Victims
            Dim img As Bitmap = lvl.GFX.VictimImages(v.index)
            g.DrawImage(img, v.X, v.Y)
            If v.ptr > 2 Then
                g.DrawString(v.num.ToString, Me.Font, Brushes.Black, v.X + img.Width \ 2 - 3, v.Y + img.Height + 5)
                g.DrawString(v.num.ToString, Me.Font, Brushes.White, v.X + img.Width \ 2 - 4, v.Y + img.Height + 4)
            End If
        Next
        For Each m As NRMonster In lvl.objects.NRMonsters
            g.DrawImage(lvl.GFX.VictimImages(m.index), m.X, m.Y)
            If m.index = 0 Then
                g.DrawRectangle(Pens.Yellow, m.Rect(lvl.GFX))
            End If
        Next
        For Each m As Monster In lvl.objects.Monsters
            g.DrawImage(lvl.GFX.VictimImages(m.index), m.X, m.Y)
            If m.index = 0 Then
                g.DrawRectangle(Pens.Blue, m.Rect(lvl.GFX))
            End If
        Next
        For Each m As BossMonster In lvl.objects.BossMonsters
            Dim rect As Rectangle = m.Rect(Nothing)
            g.FillRectangle(Brushes.White, rect)
            g.DrawRectangle(Pens.Black, rect)
            g.DrawString(m.name, BossMonster.dispfont, Brushes.Black, rect.Location)
        Next
        For Each i As Item In lvl.objects.Items
            If i.Type < lvl.GFX.ItemImages.Count Then
                g.DrawImage(lvl.GFX.ItemImages(i.Type), i.X, i.Y)
            Else
                g.DrawImage(My.Resources.UnknownItem, i.X, i.Y)
            End If
        Next
        If forEditor Then
            If Grid Then
                For l As Integer = HScrl.Value \ (64 * zoom) To (HScrl.Value + HScrl.LargeChange) \ (64 * zoom)
                    g.DrawLine(Pens.White, l * 64, 0, l * 64, lvl.Height * 64)
                Next
                For l As Integer = VScrl.Value \ (64 * zoom) To (VScrl.Value + VScrl.LargeChange) \ (64 * zoom)
                    g.DrawLine(Pens.White, 0, l * 64, lvl.Width * 64, l * 64)
                Next
            End If
            If selectionGP IsNot Nothing And selection.exists Then
                g.FillPath(fillBrush, selectionGP)
                g.DrawPath(Pens.White, selectionGP)
                g.DrawPath(borderPen, selectionGP)
            End If
            If eraserRect <> Rectangle.Empty Then
                g.FillRectangle(eraserBrush, eraserRect)
                g.DrawRectangle(Pens.White, eraserRect)
                g.DrawRectangle(borderPen, eraserRect)
            End If
            If t IsNot Nothing Then
                t.Paint(g)
            End If
        End If
    End Sub

    Private Sub LvlEdCtrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        canvas.Focus()
    End Sub

    Private Sub LvlEdCtrl_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged, Me.DockChanged, canvas.SizeChanged
        UpdateScrollBars()
    End Sub

    Private Sub Scrolled(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrl.ValueChanged, VScrl.ValueChanged
        Repaint()
    End Sub

    Private Sub LvlEdCtrl_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If VScrl.Enabled Then
            DoMouseWheel(VScrl, -Math.Sign(e.Delta))
        ElseIf HScrl.Enabled Then
            DoMouseWheel(HScrl, -Math.Sign(e.Delta))
        End If
    End Sub

    Private Sub DoMouseWheel(ByVal scrollBar As ScrollBar, ByVal direction As Integer)
        scrollTarget = scrollBar
        Dim startValue As Integer
        scrollEnd = Math.Max(0, Math.Min(scrollBar.Maximum - scrollBar.LargeChange + 1, If(smoothScolling, scrollEnd, scrollBar.Value) + 64 * direction))
        startValue = scrollBar.Value
        scrollDelta = (scrollEnd - startValue) / 8
        smoothScolling = True
        DoMouseMove()
    End Sub

    Private Sub canvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseDown
        canvas.Focus()
        If e.Button = Windows.Forms.MouseButtons.Right Then
            'TESTING
            'ContextTable.LoadItems()
            'ContextTableStrip.Show(Me.PointToScreen(e.Location))
        End If
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            dragViewX = HScrl.Value + e.X
            dragViewY = VScrl.Value + e.Y
        End If
        If t Is Nothing Then Return
        t.MouseDown(CreateMouseEventArgs(e))
        dragging = True
    End Sub

    Private Sub canvas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseUp
        If t Is Nothing Then Return
        t.MouseUp(CreateMouseEventArgs(e))
        dragging = False
    End Sub

    Private Sub canvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            HScrl.Value = Math.Max(0, Math.Min(HScrl.Maximum - HScrl.LargeChange, dragViewX - e.X))
            VScrl.Value = Math.Max(0, Math.Min(VScrl.Maximum - VScrl.LargeChange, dragViewY - e.Y))
        End If
        If t Is Nothing Then Return
        t.MouseMove(CreateMouseEventArgs(e))
        If dragging And Not forceMove Then
            UpdateDrag()
        End If
        forceMove = False
    End Sub

    Private ArrowKeys As Keys() = {Keys.Up, Keys.Right, Keys.Down, Keys.Left}

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If t IsNot Nothing And canvas.Focused And ArrowKeys.Contains(keyData) Then
            t.KeyDown(New KeyEventArgs(keyData))
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub canvas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles canvas.KeyDown
        If t Is Nothing Then Return
        t.KeyDown(e)
    End Sub

    Private Sub canvas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles canvas.KeyUp
        If t Is Nothing Then Return
        t.KeyUp(e)
    End Sub

    Private Function CreateMouseEventArgs(ByVal e As MouseEventArgs)
        Return New MouseEventArgs(e.Button, e.Clicks, (e.X + HScrl.Value) / zoom, (e.Y + VScrl.Value) / zoom, e.Delta)
    End Function

    Public Sub DoMouseMove()
        Dim pt As Point = canvas.PointToClient(MousePosition)
        forceMove = True
        canvas_MouseMove(Me, New MouseEventArgs(Control.MouseButtons, 0, pt.X, pt.Y, 0))
    End Sub

    Private frameCounter As New Stopwatch
    Private borderCounter As Long = 0
    Private animateCounter As Long = 0

    Private Sub UpdateTimer_Tick(sender As System.Object, e As System.EventArgs) Handles UpdateTimer.Tick
        If Not frameCounter.IsRunning Then
            frameCounter.Start()
            Return
        End If

        borderCounter += frameCounter.ElapsedMilliseconds
        animateCounter += frameCounter.ElapsedMilliseconds
        frameCounter.Restart()

        If borderCounter > 50 Then
            UpdateBorder()
            borderCounter = 0
        End If
        If dragging Then
            UpdateDrag()
        End If
        If smoothScolling Then
            UpdateSmoothScroll()
        End If
        While animateCounter >= 17
            UpdateTileAnim()
            animateCounter -= 17
        End While
        If repaintRequested Then
            canvas.Invalidate()
            repaintRequested = False
        End If
    End Sub

    Private Sub UpdateBorder()
        If selection.exists Or TypeOf t Is PasteTilesTool AndAlso DirectCast(t, PasteTilesTool).pasting = True Then
            borderPen.DashOffset = (borderPen.DashOffset + 1) Mod 8
            Repaint()
        End If
    End Sub

    Private Sub UpdateDrag()
        Dim pt As Point = canvas.PointToClient(MousePosition)
        If pt.X > canvas.Width Then
            HScrl.Value = Math.Min(HScrl.Maximum - HScrl.LargeChange + 1, HScrl.Value + (pt.X - canvas.Width) \ 2)
            DoMouseMove()
        End If
        If pt.Y > canvas.Height Then
            VScrl.Value = Math.Min(VScrl.Maximum - VScrl.LargeChange + 1, VScrl.Value + (pt.Y - canvas.Height) \ 2)
            DoMouseMove()
        End If
        If pt.X < 0 Then
            HScrl.Value = Math.Max(0, HScrl.Value + pt.X \ 2)
            DoMouseMove()
        End If
        If pt.Y < 0 Then
            VScrl.Value = Math.Max(0, VScrl.Value + pt.Y \ 2)
            DoMouseMove()
        End If
    End Sub

    Private Sub UpdateSmoothScroll()
        If scrollEnd > scrollTarget.Value Then
            scrollTarget.Value = Math.Min(scrollEnd, scrollTarget.Value + scrollDelta)
        Else
            scrollTarget.Value = Math.Max(scrollEnd, scrollTarget.Value + scrollDelta)
        End If
        If scrollTarget.Value = scrollEnd Then
            smoothScolling = False
        End If
    End Sub

    Private Sub UpdateTileAnim()
        If Active And lvl.animation IsNot Nothing Then
            If lvl.animation.AdvanceFrame() Then
                Repaint()
                TilePicker.Invalidate(True)
            End If
        End If
    End Sub

    Private Sub SplitContainer1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.GotFocus
        canvas.Focus()
    End Sub
End Class
