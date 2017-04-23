Public Class Selection
    Public XStart As Integer
    Public YStart As Integer
    Public width As Integer
    Public height As Integer
    Public erasing As Boolean
    Public exists As Boolean = False
    Public selectPts As Boolean(,)
    Public curX As Integer
    Public curY As Integer

    Private fullWidth As Integer
    Private fullHeight As Integer
    Private curRectExists As Boolean = False
    Private curSelectPts As Boolean(,)

    Public Sub New(ByVal width As Integer, ByVal height As Integer)
        fullWidth = width - 1
        fullHeight = height - 1
        ReDim selectPts(fullWidth, fullHeight)
        curSelectPts = selectPts.Clone()
    End Sub

    Public Sub Refresh()
        curSelectPts = selectPts.Clone()
        erasing = False
    End Sub

    Public Sub Clear()
        ReDim selectPts(fullWidth, fullHeight)
        curSelectPts = selectPts.Clone()
        exists = False
    End Sub

    Public Sub ApplySelection()
        If curRectExists Then
            ApplySelectionTo(selectPts)
        End If
    End Sub

    Private Sub ApplySelectionTo(ByVal s As Boolean(,))
        For l As Integer = curX To curX + width
            For m As Integer = curY To curY + height
                s(l, m) = Not erasing
            Next
        Next
    End Sub

    Public Sub StartRect(ByVal x As Integer, ByVal y As Integer, ByVal remove As Boolean)
        XStart = x
        YStart = y
        curX = x
        curY = y
        erasing = remove
        exists = True
        curRectExists = False
    End Sub

    Public Sub MoveTo(ByVal x As Integer, ByVal y As Integer)
        width = Math.Abs(x - XStart)
        height = Math.Abs(y - YStart)
        If x < XStart Then
            curX = XStart - width
        Else
            curX = XStart
        End If
        If y < YStart Then
            curY = YStart - height
        Else
            curY = YStart
        End If
        curRectExists = True
        curSelectPts = selectPts.Clone()
        ApplySelectionTo(curSelectPts)
    End Sub

    Public Function GetEraserRect() As Rectangle
        If erasing And curRectExists And Control.MouseButtons = MouseButtons.Left Then
            Return New Rectangle(curX * 64, curY * 64, (width + 1) * 64, (height + 1) * 64)
        End If
    End Function

    Public Function ToGP() As Drawing2D.GraphicsPath
        Dim gp As New Drawing2D.GraphicsPath
        Dim edges As New List(Of Edge)
        For y As Integer = 0 To fullHeight
            For x As Integer = 0 To fullWidth
                If curSelectPts(x, y) Then
                    If x = 0 OrElse Not curSelectPts(x - 1, y) Then 'Left edge
                        edges.Add(New Edge(New Point(x * 64, y * 64), New Point(x * 64, (y + 1) * 64)))
                    End If
                    If y = 0 OrElse Not curSelectPts(x, y - 1) Then 'Top edge
                        edges.Add(New Edge(New Point(x * 64, y * 64), New Point((x + 1) * 64, y * 64)))
                    End If
                    If x = fullWidth OrElse Not curSelectPts(x + 1, y) Then 'Right edge
                        edges.Add(New Edge(New Point((x + 1) * 64, y * 64), New Point((x + 1) * 64, (y + 1) * 64)))
                    End If
                    If y = fullHeight OrElse Not curSelectPts(x, y + 1) Then 'Bottom edge
                        edges.Add(New Edge(New Point(x * 64, (y + 1) * 64), New Point((x + 1) * 64, (y + 1) * 64)))
                    End If
                End If
            Next
        Next
        For Each pl As List(Of Point) In AttatchEdges(edges)
            If pl.Count > 2 Then
                gp.AddPolygon(pl.ToArray())
            End If
        Next
        Return gp
    End Function

    Private Function AttatchEdges(ByVal edges As List(Of Edge)) As List(Of List(Of Point))
        Dim pts As New List(Of List(Of Point))
        pts.Add(New List(Of Point))
        Dim curLst As List(Of Point) = pts(0)
        Dim curPt As Point
        Dim notFound As New Point(-1, -1)
        Do Until edges.Count = 0
            If curLst.Count = 0 Then
                curLst.Add(edges(0).Point1)
                curLst.Add(edges(0).Point2)
                edges.RemoveAt(0)
            End If
            curPt = FindEdge(edges, curLst(curLst.Count - 1))
            If curPt <> notFound Then
                curLst.Add(curPt)
            End If
            If curPt = curLst(0) Or curPt = notFound Then
                pts.Add(New List(Of Point))
                curLst = pts.Last()
            End If
        Loop
        Return pts
    End Function

    Private Function FindEdge(ByVal edges As List(Of Edge), ByVal pt As Point) As Point
        For Each Edge As Edge In edges
            If Edge.Point1 = pt Then
                edges.Remove(Edge)
                Return Edge.Point2
            ElseIf Edge.Point2 = pt Then
                edges.Remove(Edge)
                Return Edge.Point1
            End If
        Next
        Return New Point(-1, -1)
    End Function

    Public Function FindVisible() As Boolean
        For l As Integer = 0 To fullHeight
            For m As Integer = 0 To fullWidth
                If curSelectPts(m, l) Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function
End Class

Public Class Edge
    Public Point1 As Point
    Public Point2 As Point

    Public Sub New(ByVal pt1 As Point, ByVal pt2 As Point)
        Point1 = pt1
        Point2 = pt2
    End Sub
End Class