Public Class SpriteAction
    Inherits Action

    Public sprites As New List(Of LevelObj)

    Public Sub New(ByVal sprites As List(Of LevelObj))
        For Each obj As LevelObj In sprites
            Me.sprites.Add(obj)
        Next
    End Sub
End Class

Public Class AddSpriteAction
    Inherits SpriteAction

    Public Sub New(ByVal sprites As List(Of LevelObj))
        MyBase.New(sprites)
    End Sub

    Public Overrides Sub Undo()
        level.objects.Remove(sprites)
    End Sub

    Public Overrides Sub Redo()
        level.objects.Add(sprites)
    End Sub

    Public Overrides Function ToString() As String
        If sprites.Count = 1 Then
            Return "Add " & sprites(0).ToString()
        Else
            Return "Add " & sprites.Count.ToString() & " Sprites"
        End If
    End Function
End Class

Public Class RemoveSpriteAction
    Inherits SpriteAction

    Public Sub New(ByVal sprites As List(Of LevelObj))
        MyBase.New(sprites)
        For l As Integer = sprites.Count - 1 To 0 Step -1
            If TypeOf sprites(l) Is Victim Then
                Me.sprites.RemoveAt(l)
            End If
        Next
    End Sub

    Public Overrides Sub Undo()
        level.objects.Add(sprites)
    End Sub

    Public Overrides Sub Redo()
        level.objects.Remove(sprites)
    End Sub

    Public Overrides Function ToString() As String
        If sprites.Count = 1 Then
            Return "Remove " & sprites(0).ToString()
        Else
            Return "Remove " & sprites.Count.ToString() & " Sprites"
        End If
    End Function
End Class

Public Class MoveSpriteAction
    Inherits SpriteAction

    Public px As New List(Of Integer)
    Public py As New List(Of Integer)
    Public nx As New List(Of Integer)
    Public ny As New List(Of Integer)

    Public Sub New(ByVal sprites As List(Of LevelObj), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer)
        MyBase.New(sprites)
        If dx = 0 And dy = 0 Then
            cancelAction = True
            Return
        End If
        For Each obj As LevelObj In sprites
            px.Add(obj.X)
            py.Add(obj.Y)
            nx.Add(((obj.X + dx) \ stp) * stp)
            ny.Add(((obj.Y + dy) \ stp) * stp)
        Next
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To sprites.Count - 1
            sprites(l).X = px(l)
            sprites(l).Y = py(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For l As Integer = 0 To sprites.Count - 1
            sprites(l).X = nx(l)
            sprites(l).Y = ny(l)
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Dim act2 As MoveSpriteAction = act
        For l As Integer = 0 To sprites.Count - 1
            Me.nx(l) = act2.nx(l)
            Me.ny(l) = act2.ny(l)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If sprites.Count = 1 Then
            Return "Move " + sprites(0).ToString()
        Else
            Return "Move " & sprites.Count.ToString() & " sprites"
        End If
    End Function
End Class