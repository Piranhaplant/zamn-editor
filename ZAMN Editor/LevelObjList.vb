Public Class LevelObjList

    Public Everything As New List(Of LevelObj)
    Public Items As New List(Of Item)
    Public Victims As New List(Of Victim)
    Public NRMonsters As New List(Of NRMonster)
    Public Monsters As New List(Of Monster)
    Public BossMonsters As New List(Of BossMonster)

    Public Sub Add(ByVal obj As LevelObj)
        If TypeOf obj Is Item Then
            Items.Add(obj)
        ElseIf TypeOf obj Is Victim Then
            Victims.Add(obj)
        ElseIf TypeOf obj Is NRMonster Then
            NRMonsters.Add(obj)
        ElseIf TypeOf obj Is Monster Then
            Monsters.Add(obj)
        ElseIf TypeOf obj Is BossMonster Then
            BossMonsters.Add(obj)
        Else
            Throw New ArgumentException("Object was not a known type of LevelObj", "obj")
        End If
        Everything.Add(obj)
    End Sub

    Public Sub Add(ByVal objs As List(Of LevelObj))
        For Each obj As LevelObj In objs
            Add(obj)
        Next
    End Sub

    Public Sub Clear()
        Items.Clear()
        Victims.Clear()
        NRMonsters.Clear()
        Monsters.Clear()
        BossMonsters.Clear()
        Everything.Clear()
    End Sub

    Public ReadOnly Property Count
        Get
            Return Everything.Count
        End Get
    End Property

    Public Sub Remove(ByVal obj As LevelObj)
        If TypeOf obj Is Item Then
            Items.Remove(obj)
        ElseIf TypeOf obj Is Victim Then
            Victims.Remove(obj)
        ElseIf TypeOf obj Is NRMonster Then
            NRMonsters.Remove(obj)
        ElseIf TypeOf obj Is Monster Then
            Monsters.Remove(obj)
        ElseIf TypeOf obj Is BossMonster Then
            BossMonsters.Remove(obj)
        Else
            Throw New ArgumentException("Object was not a known type of LevelObj", "obj")
        End If
        Everything.Remove(obj)
    End Sub

    Public Sub Remove(ByVal objs As List(Of LevelObj))
        For Each obj As LevelObj In objs
            Remove(obj)
        Next
    End Sub

    Public Sub RemoveAt(ByVal index As Integer)
        Remove(Everything(index))
    End Sub

    Default Public Property Item(ByVal index As Integer) As LevelObj
        Get
            Return Everything(index)
        End Get
        Set(value As LevelObj)
            If TypeOf value Is Item Then
                Items(Items.IndexOf(Everything(index))) = value
            ElseIf TypeOf value Is Victim Then
                Victims(Victims.IndexOf(Everything(index))) = value
            ElseIf TypeOf value Is NRMonster Then
                NRMonsters(NRMonsters.IndexOf(Everything(index))) = value
            ElseIf TypeOf value Is Monster Then
                Monsters(Monsters.IndexOf(Everything(index))) = value
            ElseIf TypeOf value Is BossMonster Then
                BossMonsters(BossMonsters.IndexOf(Everything(index))) = value
            Else
                Throw New ArgumentException("Object was not a known type of LevelObj", "value")
            End If
            Everything(index) = value
        End Set
    End Property

End Class
