Public Class VictimAction
    Inherits Action

    Public victims As New List(Of Victim)

    Public Sub New(ByVal victims As List(Of Victim))
        For Each v As Victim In victims
            Me.victims.Add(v)
        Next
    End Sub
End Class

Public Class MoveVictimAction
    Inherits VictimAction

    Public px As New List(Of Integer)
    Public py As New List(Of Integer)
    Public nx As New List(Of Integer)
    Public ny As New List(Of Integer)

    Public Sub New(ByVal victims As List(Of Victim), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer)
        MyBase.New(victims)
        If dx = 0 And dy = 0 Then
            cancelAction = True
            Return
        End If
        For Each v As Victim In victims
            px.Add(v.x)
            py.Add(v.y)
            nx.Add(((v.x + dx) \ stp) * stp)
            ny.Add(((v.y + dy) \ stp) * stp)
        Next
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To victims.Count - 1
            victims(l).x = px(l)
            victims(l).y = py(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For l As Integer = 0 To victims.Count - 1
            victims(l).x = nx(l)
            victims(l).y = ny(l)
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Dim act2 As MoveVictimAction = act
        For l As Integer = 0 To victims.Count - 1
            Me.nx(l) = act2.nx(l)
            Me.ny(l) = act2.ny(l)
        Next
    End Sub

    Public Overrides Function ToString() As String
        If victims.Count = 1 Then
            Return "Move victim"
        Else
            Return "Move " & victims.Count.ToString & " victims"
        End If
    End Function
End Class

Public Class ChangeVictimTypeAction
    Inherits VictimAction

    Public newPtr As Integer
    Public prevPtr As New List(Of Integer)

    Public Sub New(ByVal victims As List(Of Victim), ByVal newPtr As Integer)
        MyBase.New(victims)
        If victims.Count = 1 And victims(0).ptr = newPtr Then
            cancelAction = True
            Return
        End If
        For Each v As Victim In victims
            prevPtr.Add(v.ptr)
        Next
        Me.newPtr = newPtr
    End Sub

    Public Overrides Sub Undo()
        For l As Integer = 0 To victims.Count - 1
            victims(l).ptr = prevPtr(l)
        Next
    End Sub

    Public Overrides Sub Redo()
        For Each v As Victim In victims
            If v.ptr > 2 Then
                v.ptr = newPtr
            End If
        Next
    End Sub

    Public Overrides ReadOnly Property CanMerge As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Merge(ByVal act As Action)
        Me.newPtr = CType(act, ChangeVictimTypeAction).newPtr
    End Sub

    Public Overrides Function ToString() As String
        If victims.Count = 1 Then
            Return "Change victim type"
        Else
            Return "Change " & victims.Count.ToString & " victims types"
        End If
    End Function
End Class