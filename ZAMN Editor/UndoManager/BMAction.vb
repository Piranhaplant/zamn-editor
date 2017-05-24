Public Class BMAction
    Inherits Action

    Public BossMonsters As New List(Of BossMonster)

    Public Sub New(ByVal bossmonsters As List(Of BossMonster))
        For Each m As BossMonster In bossmonsters
            Me.BossMonsters.Add(m)
        Next
    End Sub
End Class

Public Class AddBMAction
    Inherits BMAction

    Public Sub New(ByVal bossmonsters As List(Of BossMonster))
        MyBase.New(bossmonsters)
    End Sub

    Public Overrides Sub Undo()
        For Each m As BossMonster In BossMonsters
            level.objects.Remove(m)
        Next
        UpdateSelection()
    End Sub

    Public Overrides Sub Redo()
        For Each m As BossMonster In BossMonsters
            level.objects.Add(m)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If BossMonsters.Count = 1 Then
            Return "Add boss monster"
        Else
            Return "Add " & BossMonsters.Count.ToString & " boss monsters"
        End If
    End Function
End Class

Public Class RemoveBMAction
    Inherits BMAction

    Public Sub New(ByVal bossmonsters As List(Of BossMonster))
        MyBase.New(bossmonsters)
    End Sub

    Public Overrides Sub Undo()
        For Each m As BossMonster In BossMonsters
            level.objects.Add(m)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As BossMonster In BossMonsters
            level.objects.Remove(m)
        Next
        UpdateSelection()
    End Sub

    Public Overrides Function ToString() As String
        If BossMonsters.Count = 1 Then
            Return "Remove boss monster"
        Else
            Return "Remove " & BossMonsters.Count.ToString & " boss monsters"
        End If
    End Function
End Class

Public Class MoveBMAction
    Inherits BMAction

    Public px As New List(Of Integer)
    Public py As New List(Of Integer)
    Public nx As New List(Of Integer)
    Public ny As New List(Of Integer)

    Public Sub New(ByVal bossmonsters As List(Of BossMonster), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer)
        MyBase.New(bossmonsters)
        If dx = 0 And dy = 0 Then
            cancelAction = True
            Return
        End If
        For Each m As BossMonster In bossmonsters
            px.Add(m.x)
            py.Add(m.y)
            nx.Add(((m.x + dx) \ stp) * stp)
            ny.Add(((m.y + dy) \ stp) * stp)
        Next
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To BossMonsters.Count - 1
            BossMonsters(l).x = px(l)
            BossMonsters(l).y = py(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For l As Integer = 0 To BossMonsters.Count - 1
            BossMonsters(l).x = nx(l)
            BossMonsters(l).y = ny(l)
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Dim act2 As MoveBMAction = act
        For l As Integer = 0 To BossMonsters.Count - 1
            Me.nx(l) = act2.nx(l)
            Me.ny(l) = act2.ny(l)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If BossMonsters.Count = 1 Then
            Return "Move boss monster"
        Else
            Return "Move " & BossMonsters.Count.ToString & " boss monsters"
        End If
    End Function
End Class

Public Class ChangeBMTypeAction
    Inherits BMAction

    Public newPtr As Integer
    Public prevPtr As New List(Of Integer)

    Public Sub New(ByVal bossmonsters As List(Of BossMonster), ByVal newPtr As Integer)
        MyBase.New(bossmonsters)
        If bossmonsters.Count = 1 And bossmonsters(0).ptr = newPtr Then
            cancelAction = True
            Return
        End If
        For Each m As BossMonster In bossmonsters
            prevPtr.Add(m.ptr)
        Next
        Me.newPtr = newPtr
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To BossMonsters.Count - 1
            BossMonsters(l).ptr = prevPtr(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As BossMonster In BossMonsters
            m.ptr = newPtr
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.newPtr = CType(act, ChangeBMTypeAction).newPtr
    End Sub

    Public Overrides Function ToString() As String
        If BossMonsters.Count = 1 Then
            Return "Change boss monster type"
        Else
            Return "Change " & BossMonsters.Count.ToString & " boss monsters types"
        End If
    End Function
End Class