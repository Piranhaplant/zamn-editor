Public Class MonsterTool
    Inherits ObjectTool(Of Monster)

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        pasteChar = "M"
        SidePanel = SideContentType.Monsters
        typeName = "monster"
        UpdateCaptions()
        Me.Status = DefaultText
    End Sub

    Public Overrides Function RectOfT(ByVal obj As Monster) As System.Drawing.Rectangle
        Return obj.Rect(ed.EdControl.lvl.GFX)
    End Function

    Public Overrides Property X(ByVal obj As Monster) As Integer
        Get
            Return obj.x
        End Get
        Set(ByVal value As Integer)
            obj.x = value
        End Set
    End Property

    Public Overrides Property Y(ByVal obj As Monster) As Integer
        Get
            Return obj.y
        End Get
        Set(ByVal value As Integer)
            obj.y = value
        End Set
    End Property

    Public Overrides Function NewOfT(ByVal x As Integer, ByVal y As Integer) As Monster
        If MonsterPicker.SelectedIndex = -1 Then Return Nothing
        dragXOff = ed.EdControl.lvl.GFX.VictimImages(MonsterPicker.SelectedIndex).Width / 2
        dragYOff = ed.EdControl.lvl.GFX.VictimImages(MonsterPicker.SelectedIndex).Height / 2
        Return New Monster(20, x - ed.EdControl.lvl.GFX.VictimImages(MonsterPicker.SelectedIndex).Width / 2,
                           y - ed.EdControl.lvl.GFX.VictimImages(MonsterPicker.SelectedIndex).Height / 2, 0,
                           Pointers.SpritePtrs(MonsterPicker.SelectedIndex))
    End Function

    Public Overrides Function CloneT(ByVal o As Monster) As Monster
        Return New Monster(o)
    End Function

    Public Overrides Sub RefreshList()
        Me.levelList = ed.EdControl.lvl.objects.Monsters
    End Sub

    Public Overrides Function GetMoveAction(ByVal objs As System.Collections.Generic.List(Of Monster), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer) As Action
        Return New MoveMonsterAction(objs, dx, dy, stp)
    End Function

    Public Overrides Function GetChangeAction(ByVal objs As System.Collections.Generic.List(Of Monster), ByVal newType As Integer) As Action
        Return New ChangeMonsterTypeAction(objs, newType)
    End Function

    Public Overrides Function GetAddAction(ByVal objs As System.Collections.Generic.List(Of Monster)) As Action
        Return New AddMonsterAction(objs)
    End Function

    Public Overrides Function GetRemoveAction(ByVal objs As System.Collections.Generic.List(Of Monster)) As Action
        Return New RemoveMonsterAction(objs)
    End Function

    Public Overrides Function ToText(ByVal Objs As System.Collections.Generic.List(Of Monster)) As String
        Dim str As String = "3"
        For Each m As Monster In Objs
            str &= m.delay.ToString("X2") & m.X.ToString("X4") & m.Y.ToString("X4") & _
                   m.radius.ToString("X2") & m.ptr.ToString("X8")
        Next
        Return str
    End Function

    Public Overrides Function FromText(ByVal txt As String) As List(Of Monster)
        Dim Monsters As New List(Of Monster)
        Try
            Dim indx As Integer = 2
            Do Until indx > txt.Length
                Monsters.Add(New Monster(CInt("&H" & Mid(txt, indx, 2)), CInt("&H" & Mid(txt, indx + 2, 4)), _
                                         CInt("&H" & Mid(txt, indx + 6, 4)), CInt("&H" & Mid(txt, indx + 10, 2)), _
                                         CInt("&H" & Mid(txt, indx + 12, 8))))
                indx += 20
            Loop
        Catch
        End Try
        Return Monsters
    End Function
End Class
