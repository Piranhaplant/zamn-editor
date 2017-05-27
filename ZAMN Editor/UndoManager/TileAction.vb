Public Class PaintTileAction
    Inherits Action

    Public points As New List(Of Point)
    Public pType As New List(Of Integer)
    Public tileType As Integer

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal tileType As Integer)
        Me.points.Add(New Point(x, y))
        Me.tileType = tileType
    End Sub

    Public Overrides Sub AfterSetEdControl()
        pType.Add(level.Tiles(points(0).X, points(0).Y))
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To points.Count - 1
            level.Tiles(points(l).X, points(l).Y) = pType(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For l As Integer = 0 To points.Count - 1
            level.Tiles(points(l).X, points(l).Y) = tileType
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Dim act2 As PaintTileAction = DirectCast(act, PaintTileAction)
        If Not (points.Contains(act2.points(0))) Then
            points.Add(act2.points(0))
            pType.Add(act2.pType(0))
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return "Paint tiles"
    End Function
End Class

Public Class TileSuggestAction
    Inherits Action

    Public x As Integer
    Public y As Integer
    Public pType As Integer
    Public tileType As Integer

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal tileType As Integer)
        Me.x = x
        Me.y = y
        Me.tileType = tileType
    End Sub

    Public Overrides Sub AfterSetEdControl()
        pType = level.Tiles(x, y)
    End Sub

    Public Overrides Sub Undo()
        level.Tiles(x, y) = pType
    End Sub

    Public Overrides Sub Redo()
        level.Tiles(x, y) = tileType
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.tileType = DirectCast(act, TileSuggestAction).tileType
    End Sub

    Public Overrides Function ToString() As String
        Return "Change tile"
    End Function
End Class

Public Class FillSelectionAction
    Inherits Action

    Public selected As Boolean(,)
    Public oldTileTypes As Integer(,)
    Public newTileType As Integer

    Public Sub New(ByVal newTileType As Integer)
        Me.newTileType = newTileType
    End Sub

    Public Overrides Sub AfterSetEdControl()
        selected = EdControl.selection.selectPts.Clone()
        oldTileTypes = EdControl.lvl.Tiles.Clone()
    End Sub

    Public Overrides Sub Undo()
        For y As Integer = 0 To EdControl.lvl.Height - 1
            For x As Integer = 0 To EdControl.lvl.Width - 1
                If selected(x, y) Then
                    EdControl.lvl.Tiles(x, y) = oldTileTypes(x, y)
                End If
            Next
        Next
    End Sub

    Public Overrides Sub Redo()
        For y As Integer = 0 To EdControl.lvl.Height - 1
            For x As Integer = 0 To EdControl.lvl.Width - 1
                If selected(x, y) Then
                    EdControl.lvl.Tiles(x, y) = newTileType
                End If
            Next
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.newTileType = DirectCast(act, FillSelectionAction).newTileType
    End Sub

    Public Overrides Function ToString() As String
        Return "Fill Selection"
    End Function
End Class

Public Class PasteTilesAction
    Inherits Action

    Public newTiles As Integer(,)
    Public oldTiles As Integer(,)
    Public x As Integer
    Public y As Integer
    Public width As Integer
    Public height As Integer

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal newTiles As Integer(,))
        Me.x = x
        Me.y = y
        Me.newTiles = newTiles
        Me.width = newTiles.GetLength(0) - 1
        Me.height = newTiles.GetLength(1) - 1
        ReDim oldTiles(width, height)
    End Sub

    Public Overrides Sub AfterSetEdControl()
        width = Math.Min(width, EdControl.lvl.Width - 1)
        height = Math.Min(height, EdControl.lvl.Height - 1)
        For yp As Integer = 0 To height
            For xp As Integer = 0 To width
                oldTiles(xp, yp) = level.Tiles(xp + x, yp + y)
            Next
        Next
    End Sub

    Public Overrides Sub Redo()
        For yp As Integer = 0 To height
            For xp As Integer = 0 To width
                If newTiles(xp, yp) > -1 Then
                    level.Tiles(xp + x, yp + y) = newTiles(xp, yp)
                End If
            Next
        Next
    End Sub

    Public Overrides Sub Undo()
        For yp As Integer = 0 To height
            For xp As Integer = 0 To width
                If newTiles(xp, yp) > -1 Then
                    level.Tiles(xp + x, yp + y) = oldTiles(xp, yp)
                End If
            Next
        Next
    End Sub

    Public Overrides Function ToString() As String
        Return "Paste Tiles"
    End Function
End Class