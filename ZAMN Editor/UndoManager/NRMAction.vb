Public Class NRMAction
    Inherits Action

    Public NRMs As New List(Of NRMonster)

    Public Sub New(ByVal nrms As List(Of NRMonster))
        For Each m As NRMonster In nrms
            Me.NRMs.Add(m)
        Next
        If nrms.Count = 0 Then
            cancelAction = True
        End If
    End Sub
End Class

Public Class AddNRMAction
    Inherits NRMAction

    Public Sub New(ByVal nrms As List(Of NRMonster))
        MyBase.New(nrms)
    End Sub

    Public Overrides Sub Undo()
        For Each m As NRMonster In NRMs
            level.objects.Remove(m)
        Next
        UpdateSelection()
    End Sub

    Public Overrides Sub Redo()
        For Each m As NRMonster In NRMs
            level.objects.Add(m)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If NRMs.Count = 1 Then
            Return "Add non-respawning monster"
        Else
            Return "Add " & NRMs.Count.ToString & " non-respawning monsters"
        End If
    End Function
End Class

Public Class RemoveNRMAction
    Inherits NRMAction

    Public Sub New(ByVal NRMs As List(Of NRMonster))
        MyBase.New(NRMs)
    End Sub

    Public Overrides Sub Undo()
        For Each m As NRMonster In NRMs
            level.objects.Add(m)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As NRMonster In NRMs
            level.objects.Remove(m)
        Next
        UpdateSelection()
    End Sub

    Public Overrides Function ToString() As String
        If NRMs.Count = 1 Then
            Return "Delete non-respawning monster"
        Else
            Return "Delete " & NRMs.Count.ToString & " non-respawning monsters"
        End If
    End Function
End Class

Public Class MoveNRMAction
    Inherits NRMAction

    Public px As New List(Of Integer)
    Public py As New List(Of Integer)
    Public nx As New List(Of Integer)
    Public ny As New List(Of Integer)

    Public Sub New(ByVal NRMs As List(Of NRMonster), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer)
        MyBase.New(NRMs)
        If dx = 0 And dy = 0 Then
            cancelAction = True
            Return
        End If
        For Each m As NRMonster In NRMs
            px.Add(m.x)
            py.Add(m.y)
            nx.Add(((m.x + dx) \ stp) * stp)
            ny.Add(((m.y + dy) \ stp) * stp)
        Next
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To NRMs.Count - 1
            NRMs(l).x = px(l)
            NRMs(l).y = py(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For l As Integer = 0 To NRMs.Count - 1
            NRMs(l).x = nx(l)
            NRMs(l).y = ny(l)
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Dim act2 As MoveNRMAction = act
        For l As Integer = 0 To NRMs.Count - 1
            Me.nx(l) = act2.nx(l)
            Me.ny(l) = act2.ny(l)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If NRMs.Count = 1 Then
            Return "Move non-respawning monster"
        Else
            Return "Move " & NRMs.Count.ToString & " non-respawning monsters"
        End If
    End Function
End Class

Public Class ChangeNRMTypeAction
    Inherits NRMAction

    Public newptr As Integer
    Public prevptr As New List(Of Integer)

    Public Sub New(ByVal NRMs As List(Of NRMonster), ByVal ptr As Integer)
        MyBase.New(NRMs)
        If NRMs.Count = 1 And NRMs(0).ptr = ptr Then
            cancelAction = True
            Return
        End If
        For Each m As NRMonster In NRMs
            prevptr.Add(m.ptr)
        Next
        newptr = ptr
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To NRMs.Count - 1
            NRMs(l).ptr = prevptr(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As NRMonster In NRMs
            m.ptr = newptr
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.newptr = CType(act, ChangeNRMTypeAction).newptr
    End Sub

    Public Overrides Function ToString() As String
        If NRMs.Count = 1 Then
            Return "Change non-respawning monster type"
        Else
            Return "Change " & NRMs.Count.ToString & " non-respawning monsters types"
        End If
    End Function
End Class

Public Class ChangeNRMExtraAction
    Inherits NRMAction

    Public newvalue As Integer
    Public prevvalue As New List(Of Integer)

    Public Sub New(ByVal NRMs As List(Of NRMonster), ByVal value As Integer)
        MyBase.New(NRMs)
        If NRMs.Count = 1 And NRMs(0).extra = value Then
            cancelAction = True
            Return
        End If
        For Each m As NRMonster In NRMs
            prevvalue.Add(m.extra)
        Next
        newvalue = value
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To NRMs.Count - 1
            NRMs(l).extra = prevvalue(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each m As NRMonster In NRMs
            m.extra = newvalue
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.newvalue = CType(act, ChangeNRMExtraAction).newvalue
    End Sub

    Public Overrides Function ToString() As String
        If NRMs.Count = 1 Then
            Return "Change non-respawning monster extra"
        Else
            Return "Change " & NRMs.Count.ToString & " non-respawning monsters extras"
        End If
    End Function
End Class