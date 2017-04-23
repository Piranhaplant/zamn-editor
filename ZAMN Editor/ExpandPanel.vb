Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class ExpandPanel
    Inherits UserControl

    Private path As GraphicsPath
    Private rect As Rectangle
    Private gradient As LinearGradientBrush
    Private gradientH As LinearGradientBrush
    Private gradientB As LinearGradientBrush
    Private arrowImg As Bitmap
    Private splitter As SplitContainer

    Private expanding As Boolean = False
    Private panelImg As Bitmap
    Private fadeImg As Bitmap
    Private WithEvents fadeTimer As New Timer
    Private curFadePx As Integer

    Private inSplitter As Boolean
    Private mouseOver As Boolean = False
    Private mouseButton As Boolean = False
    Public expanded As Boolean = False
    Public expandedHeight As Integer = 100
    Public expandSpeed As Integer = 5

    Private Sub ExpandPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If path Is Nothing Then
            RefreshPath()
        End If
        If mouseOver And Not expanding Then
            If mouseButton Then
                e.Graphics.FillPath(gradientB, path)
            Else
                e.Graphics.FillPath(gradientH, path)
            End If
        Else
            e.Graphics.FillPath(gradient, path)
        End If
        e.Graphics.DrawPath(Pens.Black, path)
        TextRenderer.DrawText(e.Graphics, "Properties", Me.Font, rect, Color.Black, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter)
        e.Graphics.DrawImage(arrowImg, Me.Width - 16, 10, 7, 4)
        If expanding And fadeImg IsNot Nothing Then
            e.Graphics.DrawImage(fadeImg, Panel1.Location)
        End If
    End Sub

    Private Sub ExpandPanel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        mouseOver = True
        Me.Invalidate()
    End Sub

    Private Sub ExpandPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        mouseOver = False
        Me.Invalidate()
    End Sub

    Private Sub ExpandPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        mouseButton = True
        Me.Invalidate()
    End Sub

    Private Sub ExpandPanel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        mouseButton = False
        Me.Invalidate()
        If rect.Contains(e.Location) And inSplitter And Not expanding Then
            StartExpand()
        End If
    End Sub

    Private Sub StartExpand()
        fadeTimer.Interval = 1
        Panel1.Size = New Size(Me.Width, expandedHeight)
        panelImg = New Bitmap(Me.Width, expandedHeight)
        Panel1.DrawToBitmap(panelImg, Panel1.DisplayRectangle)
        Panel1.Visible = False
        curFadePx = 0
        expanding = True
        arrowImg.RotateFlip(RotateFlipType.RotateNoneFlipY)
        fadeTimer.Start()
    End Sub

    Private Sub fadeTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles fadeTimer.Tick
        curFadePx += expandSpeed
        If expanded Then
            splitter.SplitterDistance += expandSpeed
        Else
            splitter.SplitterDistance -= expandSpeed
        End If
        Dim opacity As Single
        If expanded Then
            opacity = (expandedHeight - curFadePx) / expandedHeight
        Else
            opacity = curFadePx / expandedHeight
        End If
        fadeImg = SetImgOpacity(panelImg, opacity)
        Me.Invalidate()
        If curFadePx >= expandedHeight Then
            fadeTimer.Stop()
            Panel1.Visible = True
            expanding = False
            expanded = Not expanded
            Return
        End If
    End Sub

    Private Sub ExpandPanel_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ParentChanged
        inSplitter = TypeOf Me.Parent Is SplitterPanel
        If inSplitter Then
            splitter = Me.Parent.Parent
        Else
            splitter = Nothing
        End If
    End Sub

    Private Sub ExpandPanel_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        RefreshPath()
    End Sub

    Private Sub RefreshPath()
        If arrowImg Is Nothing Then
            arrowImg = My.Resources.DropArrow
            If Not expanded Then
                arrowImg.RotateFlip(RotateFlipType.RotateNoneFlipY)
            End If
        End If
        rect = New Rectangle(0, 0, Me.Width, Panel1.Location.Y)
        gradient = New LinearGradientBrush(rect, SystemColors.Control, SystemColors.ControlDark, LinearGradientMode.Vertical)
        gradientH = New LinearGradientBrush(rect, SystemColors.ControlLight, SystemColors.Control, LinearGradientMode.Vertical)
        gradientB = New LinearGradientBrush(rect, SystemColors.ControlDark, SystemColors.Control, LinearGradientMode.Vertical)
        path = GetRoundRectTop(rect, 7)
    End Sub

    Private Function SetImgOpacity(ByVal imgPic As Image, ByVal imgOpac As Single) As Image
        Dim bmpPic As New Bitmap(imgPic.Width, imgPic.Height)
        Dim gfxPic As Graphics = Graphics.FromImage(bmpPic)
        Dim cmxPic As New ColorMatrix()
        cmxPic.Matrix33 = imgOpac

        Dim iaPic As New ImageAttributes()
        iaPic.SetColorMatrix(cmxPic, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)
        gfxPic.DrawImage(imgPic, New Rectangle(0, 0, bmpPic.Width, bmpPic.Height), 0, 0, imgPic.Width, imgPic.Height, GraphicsUnit.Pixel, iaPic)
        gfxPic.Dispose()

        Return bmpPic
    End Function

    Public Shared Function GetRoundRectTop(ByVal Rect As Rectangle, ByVal CurveRadius As Integer) As Drawing2D.GraphicsPath
        Dim gp As New Drawing2D.GraphicsPath
        Dim pt2x As Integer = Rect.X + Rect.Width - 1
        Dim pt2y As Integer = Rect.Y + Rect.Height - 1
        CurveRadius *= 2

        gp.AddArc(Rect.X, Rect.Y, CurveRadius, CurveRadius, 180, 90)
        gp.AddArc(pt2x - CurveRadius, Rect.Y, CurveRadius, CurveRadius, 270, 90)
        gp.AddLine(pt2x, pt2y, Rect.X, pt2y)
        gp.CloseFigure()
        Return gp
    End Function
End Class