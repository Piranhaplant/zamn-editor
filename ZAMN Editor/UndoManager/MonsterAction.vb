Public Class MonsterAction
    Inherits Action

    Public Monsters As New List(Of Monster)

    Public Sub New(ByVal monsters As List(Of Monster))
        For Each m As Monster In monsters
            Me.Monsters.Add(m)
        Next
    End Sub
End Class

Public Class AddMonsterAction
    Inherits MonsterAction

    Public Sub New(ByVal monsters As List(Of Monster))
        MyBase.New(monsters)
    End Sub

    Public Overrides Sub Undo()
        For Each m As Monster In Monsters
            level.objects.Remove(m)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As Monster In Monsters
            level.objects.Add(m)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If Monsters.Count = 1 Then
            Return "Add monster"
        Else
            Return "Add " & Monsters.Count.ToString & " monsters"
        End If
    End Function
End Class

Public Class RemoveMonsterAction
    Inherits MonsterAction

    Public Sub New(ByVal monsters As List(Of Monster))
        MyBase.New(monsters)
    End Sub

    Public Overrides Sub Undo()
        For Each m As Monster In Monsters
            level.objects.Add(m)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As Monster In Monsters
            level.objects.Remove(m)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If Monsters.Count = 1 Then
            Return "Remove monster"
        Else
            Return "Remove " & Monsters.Count.ToString & " monsters"
        End If
    End Function
End Class

Public Class MoveMonsterAction
    Inherits MonsterAction

    Public px As New List(Of Integer)
    Public py As New List(Of Integer)
    Public nx As New List(Of Integer)
    Public ny As New List(Of Integer)

    Public Sub New(ByVal monsters As List(Of Monster), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer)
        MyBase.New(monsters)
        If dx = 0 And dy = 0 Then
            cancelAction = True
            Return
        End If
        For Each m As Monster In monsters
            px.Add(m.x)
            py.Add(m.y)
            nx.Add(((m.x + dx) \ stp) * stp)
            ny.Add(((m.y + dy) \ stp) * stp)
        Next
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To Monsters.Count - 1
            Monsters(l).x = px(l)
            Monsters(l).y = py(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For l As Integer = 0 To Monsters.Count - 1
            Monsters(l).x = nx(l)
            Monsters(l).y = ny(l)
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Dim act2 As MoveMonsterAction = act
        For l As Integer = 0 To Monsters.Count - 1
            Me.nx(l) = act2.nx(l)
            Me.ny(l) = act2.ny(l)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If Monsters.Count = 1 Then
            Return "Move monster"
        Else
            Return "Move " & Monsters.Count.ToString & " monsters"
        End If
    End Function
End Class

Public Class ChangeMonsterTypeAction
    Inherits MonsterAction

    Public newptr As Integer
    Public prevptr As New List(Of Integer)

    Public Sub New(ByVal monsters As List(Of Monster), ByVal ptr As Integer)
        MyBase.New(monsters)
        If monsters.Count = 1 And monsters(0).ptr = ptr Then
            cancelAction = True
            Return
        End If
        For Each m As Monster In monsters
            prevptr.Add(m.ptr)
        Next
        newptr = ptr
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To Monsters.Count - 1
            Monsters(l).ptr = prevptr(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As Monster In Monsters
            m.ptr = newptr
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.newptr = CType(act, ChangeMonsterTypeAction).newptr
    End Sub

    Public Overrides Function ToString() As String
        If Monsters.Count = 1 Then
            Return "Change monster type"
        Else
            Return "Change " & Monsters.Count.ToString & " monsters types"
        End If
    End Function
End Class

Public Class ChangeMonsterRadiusAction
    Inherits MonsterAction

    Public newRadius As Integer
    Public prevRadius As New List(Of Integer)

    Public Sub New(ByVal monsters As List(Of Monster), ByVal radius As Integer)
        MyBase.New(monsters)
        For Each m As Monster In monsters
            prevRadius.Add(m.radius)
        Next
        newRadius = radius
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To Monsters.Count - 1
            Monsters(l).radius = prevRadius(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As Monster In Monsters
            m.radius = newRadius
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.newRadius = CType(act, ChangeMonsterRadiusAction).newRadius
    End Sub

    Public Overrides Function ToString() As String
        If Monsters.Count = 1 Then
            Return "Change monster radius"
        Else
            Return "Change " & Monsters.Count.ToString & " monsters radii"
        End If
    End Function
End Class

Public Class ChangeMonsterDelayAction
    Inherits MonsterAction

    Public newDelay As Integer
    Public prevDelay As New List(Of Integer)

    Public Sub New(ByVal monsters As List(Of Monster), ByVal delay As Integer)
        MyBase.New(monsters)
        For Each m As Monster In monsters
            prevDelay.Add(m.radius)
        Next
        newDelay = delay
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To Monsters.Count - 1
            Monsters(l).delay = prevDelay(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As Monster In Monsters
            m.delay = newDelay
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.newDelay = CType(act, ChangeMonsterDelayAction).newDelay
    End Sub

    Public Overrides Function ToString() As String
        If Monsters.Count = 1 Then
            Return "Change monster delay"
        Else
            Return "Change " & Monsters.Count.ToString & " monsters delays"
        End If
    End Function
End Class