Public Class SmoothZoom

    Public zoomEnd As Single
    Public startWidth As Integer
    Public xDelta As Single
    Public yDelta As Single
    Public widthDelta As Single
    Public heightDelta As Single

    Public curX As Single
    Public curY As Single
    Public curWidth As Single
    Public curHeight As Single
    Public curZoom As Single
    Public frameNum As Integer = 0

    Public curBounds As RectangleF
    Public newBounds As RectangleF

    Public Sub New(ByVal curZoom As Single, ByVal newZoom As Single, ByVal HScroll As Integer, ByVal VScroll As Integer, ByVal width As Integer, ByVal height As Integer, ByVal totalHeight As Integer, ByVal totalWidth As Integer)
        zoomEnd = newZoom
        startWidth = width
        curBounds = New RectangleF(HScroll / curZoom, VScroll / curZoom, width / curZoom, height / curZoom)
        Dim newWidth As Single = curBounds.Width * (curZoom / newZoom)
        Dim newHeight As Single = curBounds.Height * (curZoom / newZoom)
        Dim xDelta As Single = curBounds.Width * (curZoom / newZoom) - curBounds.Width
        Dim yDelta As Single = curBounds.Height * (curZoom / newZoom) - curBounds.Height
        newBounds = New RectangleF(curBounds.X - xDelta / 2, curBounds.Y - yDelta / 2, curBounds.Width + xDelta, curBounds.Height + yDelta)
        If newBounds.Right > totalWidth Then
            newBounds.X += totalWidth - newBounds.Right
        End If
        If newBounds.Bottom > totalHeight Then
            newBounds.Y += totalHeight - newBounds.Bottom
        End If
        If newBounds.X < 0 Then
            newBounds.X = 0
        End If
        If newBounds.Y < 0 Then
            newBounds.Y = 0
        End If
        curX = curBounds.X
        curY = curBounds.Y
        curWidth = curBounds.Width
        curHeight = curBounds.Height
        'Transition the zoom over 10 frames
        Me.xDelta = (newBounds.X - curBounds.X) / 10
        Me.yDelta = (newBounds.Y - curBounds.Y) / 10
        widthDelta = (newBounds.Width - curBounds.Width) / 10
        heightDelta = (newBounds.Height - curBounds.Height) / 10
    End Sub

    Public Sub Tick()
        curX += xDelta
        curY += yDelta
        curWidth += widthDelta
        curHeight += heightDelta
        curZoom = startWidth / curWidth
        frameNum = (frameNum + 1) Mod 10
    End Sub

    Public Function IsDone() As Boolean
        Return frameNum = 0
    End Function
End Class
