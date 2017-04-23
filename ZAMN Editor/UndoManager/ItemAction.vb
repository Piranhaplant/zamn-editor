Public Class ItemAction
    Inherits Action

    Public items As New List(Of Item)

    Public Sub New(ByVal items As List(Of Item))
        For Each i As Item In items
            Me.items.Add(i)
        Next
    End Sub
End Class

Public Class AddItemAction
    Inherits ItemAction

    Public Sub New(ByVal items As List(Of Item))
        MyBase.New(items)
    End Sub

    Public Overrides Sub Undo()
        For Each i As Item In items
            level.objects.Remove(i)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each i As Item In items
            level.objects.Add(i)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If items.Count = 1 Then
            Return "Add item"
        Else
            Return "Add " & items.Count.ToString & " items"
        End If
    End Function
End Class

Public Class RemoveItemAction
    Inherits ItemAction

    Public Sub New(ByVal items As List(Of Item))
        MyBase.New(items)
    End Sub

    Public Overrides Sub Undo()
        For Each i As Item In items
            level.objects.Add(i)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each i As Item In items
            level.objects.Remove(i)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If items.Count = 1 Then
            Return "Delete item"
        Else
            Return "Delete " & items.Count.ToString & " items"
        End If
    End Function
End Class

Public Class MoveItemAction
    Inherits ItemAction

    Public px As New List(Of Integer)
    Public py As New List(Of Integer)
    Public nx As New List(Of Integer)
    Public ny As New List(Of Integer)

    Public Sub New(ByVal items As List(Of Item), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer)
        MyBase.New(items)
        If dx = 0 And dy = 0 Then
            cancelAction = True
            Return
        End If
        For Each i As Item In items
            px.Add(i.x)
            py.Add(i.y)
            nx.Add(((i.x + dx) \ stp) * stp)
            ny.Add(((i.y + dy) \ stp) * stp)
        Next
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To items.Count - 1
            items(l).x = px(l)
            items(l).y = py(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For l As Integer = 0 To items.Count - 1
            items(l).x = nx(l)
            items(l).y = ny(l)
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Dim act2 As MoveItemAction = act
        For l As Integer = 0 To items.Count - 1
            Me.nx(l) = act2.nx(l)
            Me.ny(l) = act2.ny(l)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If items.Count = 1 Then
            Return "Move item"
        Else
            Return "Move " & items.Count.ToString & " items"
        End If
    End Function
End Class

Public Class ChangeItemTypeAction
    Inherits ItemAction

    Public newType As Integer
    Public prevType As New List(Of Integer)

    Public Sub New(ByVal items As List(Of Item), ByVal type As Integer)
        MyBase.New(items)
        For Each i As Item In items
            prevType.Add(i.type)
        Next
        newType = type
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To items.Count - 1
            items(l).type = prevType(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each i As Item In items
            i.type = newType
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.newType = CType(act, ChangeItemTypeAction).newType
    End Sub

    Public Overrides Function ToString() As String
        If items.Count = 1 Then
            Return "Change item type"
        Else
            Return "Change " & items.Count.ToString & " items types"
        End If
    End Function
End Class