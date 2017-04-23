Public Class DList(Of T, T2)

    Public L1 As New List(Of T)
    Public L2 As New List(Of T2)

    Public Sub Add(ByVal first As T, ByVal second As T2)
        L1.Add(first)
        L2.Add(second)
    End Sub

    Public Function FromFirst(ByVal secondValue As T2) As T
        Return L1(L2.IndexOf(secondValue))
    End Function

    Public Function FromSecond(ByVal firstValue As T) As T2
        Return L2(L1.IndexOf(firstValue))
    End Function

    Public Sub SortByFirst()
        Dim first() As T = L1.ToArray
        Dim second() As T2 = L2.ToArray
        Array.Sort(first, second)
        L1 = first.ToList
        L2 = second.ToList
    End Sub

    Public Sub SortBySecond()
        Dim first() As T = L1.ToArray
        Dim second() As T2 = L2.ToArray
        Array.Sort(second, first)
        L1 = first.ToList
        L2 = second.ToList
    End Sub
End Class
