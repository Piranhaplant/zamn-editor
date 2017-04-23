Public Class BossMonsterTool
    Inherits ObjectTool(Of BossMonster)

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        pasteChar = "B"
        SidePanel = SideContentType.BossMonsters
        typeName = "boss monster"
        UpdateCaptions()
        Me.Status = DefaultText
    End Sub

    Public Overrides Function CloneT(ByVal o As BossMonster) As BossMonster
        Return New BossMonster(o)
    End Function

    Public Overrides Function FromText(ByVal txt As String) As System.Collections.Generic.List(Of BossMonster)
        Dim Monsters As New List(Of BossMonster)
        Try
            Dim indx As Integer = 2
            Do Until indx > txt.Length
                Monsters.Add(New BossMonster(CInt("&H" & Mid(txt, indx, 4)), CInt("&H" & Mid(txt, indx + 4, 4)), CInt("&H" & Mid(txt, indx + 8, 8))))
                indx += 16
            Loop
        Catch
        End Try
        Return Monsters
    End Function

    Public Overrides Function GetChangeAction(ByVal objs As System.Collections.Generic.List(Of BossMonster), ByVal newType As Integer) As Action
        Return New ChangeBMTypeAction(objs, newType)
    End Function

    Public Overrides Function GetMoveAction(ByVal objs As System.Collections.Generic.List(Of BossMonster), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer) As Action
        Return New MoveBMAction(objs, dx, dy, stp)
    End Function

    Public Overrides Function GetAddAction(ByVal objs As System.Collections.Generic.List(Of BossMonster)) As Action
        Return New AddBMAction(objs)
    End Function

    Public Overrides Function GetRemoveAction(ByVal objs As System.Collections.Generic.List(Of BossMonster)) As Action
        Return New RemoveBMAction(objs)
    End Function

    Public Overrides Function NewOfT(ByVal x As Integer, ByVal y As Integer) As BossMonster
        If BMonsterPicker.SelectedIndex = -1 Then Return Nothing
        Dim m As New BossMonster(Pointers.BossMonsters(BMonsterPicker.SelectedIndex), x, y)
        Dim rect As Rectangle = m.Rect(Nothing)
        dragXOff = rect.Width \ 2
        dragYOff = rect.Height \ 2
        m.x -= dragXOff
        m.y -= dragYOff
        Return m
    End Function

    Public Overrides Function RectOfT(ByVal obj As BossMonster) As System.Drawing.Rectangle
        Return obj.Rect(Nothing)
    End Function

    Public Overrides Sub RefreshList()
        levelList = ed.EdControl.lvl.objects.BossMonsters
    End Sub

    Public Overrides Function ToText(ByVal Objs As System.Collections.Generic.List(Of BossMonster)) As String
        Dim str As String = "4"
        For Each m As BossMonster In Objs
            str &= m.X.ToString("X4") & m.Y.ToString("X4") & m.ptr.ToString("X8")
        Next
        Return str
    End Function

    Public Overrides Property X(ByVal obj As BossMonster) As Integer
        Get
            Return obj.x
        End Get
        Set(ByVal value As Integer)
            obj.x = value
        End Set
    End Property

    Public Overrides Property Y(ByVal obj As BossMonster) As Integer
        Get
            Return obj.y
        End Get
        Set(ByVal value As Integer)
            obj.y = value
        End Set
    End Property

    Public Overrides Function IsSelectable(ByVal obj As BossMonster) As Boolean
        Return Not Pointers.SpBossMonsters.Contains(obj.ptr)
    End Function
End Class
