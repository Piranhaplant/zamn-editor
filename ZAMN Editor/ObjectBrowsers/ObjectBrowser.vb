Public Class ObjectBrowser

    Private bgBrush As Drawing2D.LinearGradientBrush
    Private borderPen As Pen
    Private selectedBrush As Drawing2D.LinearGradientBrush
    Private selectedGP As Drawing2D.GraphicsPath
    Public SelectedIndex As Integer = -1
    Public itemCt As Integer
    Public startIdx As Integer = 0
    Public toolTipText As String()
    Public gfx As LevelGFX
    Public ts As Tileset
    Public itemRect As List(Of Rectangle)
    Public totalHeight As Integer
    Public isSetup As Boolean = False
    Public WithEvents propCtrl As IPropCtrl
    Public ed As Editor
    Public Event ValueChanged(ByVal sender As Object, ByVal e As EventArgs)

    Public Overridable ReadOnly Property hasProperties As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overridable ReadOnly Property hasToolTips As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overridable Function ItemWidth(ByVal index As Integer) As Integer
        Return gfx.VictimImages(index).Width
    End Function

    Public Overridable Function ItemHeight(ByVal index As Integer) As Integer
        Return gfx.VictimImages(index).Height
    End Function

    Public Overridable ReadOnly Property LayoutHoriz As Boolean
        Get
            Return True
        End Get
    End Property

    Public Sub SetObject(ByVal obj As Object)
        If propCtrl Is Nothing Then Return
        propCtrl.SetObject(obj)
        propCtrl.SetEnabled(True)
    End Sub

    Public Sub ClearObject()
        If propCtrl Is Nothing Then Return
        propCtrl.SetEnabled(False)
    End Sub

    Public Sub New()
        InitializeComponent()
        Setup()
    End Sub

    Public Sub New(ByVal gfx As LevelGFX)
        InitializeComponent()
        Me.gfx = gfx
        Setup()
    End Sub

    Public Sub New(ByVal ts As Tileset)
        InitializeComponent()
        Me.ts = ts
        Setup()
    End Sub

    Private Sub Setup()
        Init()
        If propCtrl IsNot Nothing Then
            ExpandPanel1.Panel1.Controls.Add(propCtrl)
            ExpandPanel1.expandedHeight = propCtrl.GetHeight
        End If
        bgBrush = New Drawing2D.LinearGradientBrush(New Rectangle(Point.Empty, New Size(canvas.Width, canvas.Height)), SystemColors.ButtonHighlight, SystemColors.ButtonFace, Drawing2D.LinearGradientMode.Horizontal)
        borderPen = New Pen(Color.FromArgb(132, 172, 221))
        SplitContainer1.Panel2Collapsed = Not hasProperties
        isSetup = True
        ClearObject()
        UpdateScrollBar()
    End Sub

    Public Overridable Sub Init()

    End Sub

    Public Sub SetEditor(ByVal ed As Editor)
        Me.ed = ed
        If propCtrl IsNot Nothing Then
            propCtrl.SetEditor(ed)
        End If
    End Sub

    Protected Sub UpdateScrollBar()
        If isSetup Then
            UpdatePositions()
        End If
        VScrl.Maximum = totalHeight
        VScrl.LargeChange = Math.Max(1, canvas.Height)
        VScrl.SmallChange = 32
        VScrl.Value = Math.Min(VScrl.Value, Math.Max(0, VScrl.Maximum - VScrl.LargeChange + 1))
        VScrl.Enabled = (VScrl.Maximum > VScrl.LargeChange)
        Me.Invalidate(True)
    End Sub

    Public Sub UpdatePositions()
        itemRect = New List(Of Rectangle)
        Dim x As Integer = 8, y As Integer = 8
        If Not LayoutHoriz Then
            y = -8
        End If
        Dim width As Integer, height As Integer
        Dim rowHeight As Integer = 0
        Dim itemsOnRow As Integer = 0
        For l As Integer = 0 To itemCt
            width = ItemWidth(l + startIdx)
            If Not LayoutHoriz Then
                width = canvas.Width - 17
            End If
            height = ItemHeight(l + startIdx)
            If (x + width + 8 > canvas.Width And itemsOnRow > 0) Or Not LayoutHoriz Then
                x = 8
                y += rowHeight + 16
                rowHeight = 0
                itemsOnRow = 0
            End If
            itemRect.Add(New Rectangle(x, y, width, height))
            x += width + 16
            rowHeight = Math.Max(rowHeight, height)
            itemsOnRow += 1
        Next
        totalHeight = y + rowHeight + 8
        UpdateSelection()
    End Sub

    Public Sub ResetScrollBar()
        VScrl.Value = 0
        Me.Invalidate(True)
    End Sub

    Public Overridable Sub canvas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles canvas.Paint
        e.Graphics.FillRectangle(bgBrush, canvas.DisplayRectangle)
        e.Graphics.TranslateTransform(0, -VScrl.Value)
        For l As Integer = startIdx To startIdx + itemCt
            If l = SelectedIndex And selectedBrush IsNot Nothing Then
                e.Graphics.FillPath(selectedBrush, selectedGP)
                e.Graphics.DrawPath(borderPen, selectedGP)
            End If
            PaintObject(e.Graphics, itemRect(l - startIdx).X, itemRect(l - startIdx).Y, l)
        Next
    End Sub

    Public Overridable Sub PaintObject(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal num As Integer)
        g.DrawImage(gfx.VictimImages(num), x, y)
    End Sub

    Private Sub VScrl_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrl.ValueChanged
        Me.Invalidate(True)
    End Sub

    Private Sub ObjectBrowser_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged, Me.DockChanged, canvas.SizeChanged
        UpdateScrollBar()
        bgBrush = New Drawing2D.LinearGradientBrush(New Rectangle(Point.Empty, canvas.Size), SystemColors.ButtonHighlight, SystemColors.ButtonFace, Drawing2D.LinearGradientMode.Horizontal)
    End Sub

    Private Sub canvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseDown
        Dim actualPt As Point = New Point(e.X, e.Y + VScrl.Value)
        Dim rect As Rectangle
        For l As Integer = 0 To itemCt
            rect = New Rectangle(itemRect(l).X - 8, itemRect(l).Y - 8, itemRect(l).Width + 16, itemRect(l).Height + 16)
            If rect.Contains(actualPt) Then
                SelectedIndex = l + startIdx
                UpdateSelection()
                RaiseEvent ValueChanged(Me, EventArgs.Empty)
                Me.Invalidate(True)
                Return
            End If
        Next
    End Sub

    Private Sub canvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseMove
        If Not hasToolTips Then Return
        For l As Integer = 0 To itemCt
            If itemRect(l).Contains(e.Location) Then
                'ToolTips.SetToolTip(canvas, toolTipText(l))
                'ToolTips.Active = True
                Return
            End If
        Next
        ToolTips.SetToolTip(canvas, "")
    End Sub

    Private Sub canvas_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles canvas.MouseHover

    End Sub

    Public Sub UpdateSelection()
        If SelectedIndex = -1 Or SelectedIndex > itemCt + startIdx Then Return
        Dim l As Integer = SelectedIndex - startIdx
        Dim rect As New Rectangle(itemRect(l).X - 8, itemRect(l).Y - 8, itemRect(l).Width + 16, itemRect(l).Height + 16)
        selectedBrush = New Drawing2D.LinearGradientBrush(rect, Color.FromArgb(236, 245, 255), Color.FromArgb(208, 229, 255), Drawing2D.LinearGradientMode.Vertical)
        selectedGP = GetRoundRect(rect, 7)
    End Sub

    Public Sub ScollToSelected()
        If itemRect Is Nothing Or SelectedIndex = -1 Then Return
        UpdateSelection()
        VScrl.Value = Math.Max(0, Math.Min(VScrl.Maximum - VScrl.LargeChange + 1, itemRect(SelectedIndex - startIdx).Y - (VScrl.LargeChange - itemRect(SelectedIndex - startIdx).Height) \ 2))
        Me.Invalidate(True)
    End Sub

    Public Shared Function GetRoundRect(ByVal Rect As Rectangle, ByVal CurveRadius As Integer) As Drawing2D.GraphicsPath
        Dim gp As New Drawing2D.GraphicsPath
        Dim pt2x As Integer = Rect.X + Rect.Width - 1
        Dim pt2y As Integer = Rect.Y + Rect.Height - 1
        CurveRadius *= 2

        gp.AddArc(pt2x - CurveRadius, Rect.Y, CurveRadius, CurveRadius, 270, 90)
        gp.AddArc(pt2x - CurveRadius, pt2y - CurveRadius, CurveRadius, CurveRadius, 0, 90)
        gp.AddArc(Rect.X, pt2y - CurveRadius, CurveRadius, CurveRadius, 90, 90)
        gp.AddArc(Rect.X, Rect.Y, CurveRadius, CurveRadius, 180, 90)
        gp.CloseFigure()
        Return gp
    End Function
End Class
