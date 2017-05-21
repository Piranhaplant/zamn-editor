Public Class NRMonsterTool
    Inherits ObjectTool(Of NRMonster)

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        pasteChar = "N"
        SidePanel = SideContentType.NRMonsters
        typeName = "non-respawning monster"
        UpdateCaptions()
        Me.Status = DefaultText
    End Sub

    Public Overrides Function CloneT(ByVal o As NRMonster) As NRMonster
        Return New NRMonster(o)
    End Function

    Public Overrides Function FromText(ByVal txt As String) As System.Collections.Generic.List(Of NRMonster)
        Dim Monsters As New List(Of NRMonster)
        Try
            Dim indx As Integer = 2
            Do Until indx > txt.Length
                Monsters.Add(New NRMonster(CInt("&H" & Mid(txt, indx, 4)), CInt("&H" & Mid(txt, indx + 4, 4)), _
                                           CInt("&H" & Mid(txt, indx + 8, 4)), CInt("&H" & Mid(txt, indx + 12, 4)), _
                                           CInt("&H" & Mid(txt, indx + 16, 8))))
                indx += 24
            Loop
        Catch
        End Try
        Return Monsters
    End Function

    Public Overrides Function GetChangeAction(ByVal objs As System.Collections.Generic.List(Of NRMonster), ByVal newType As Integer) As Action
        Return New ChangeNRMTypeAction(objs, newType)
    End Function

    Public Overrides Function GetMoveAction(ByVal objs As System.Collections.Generic.List(Of NRMonster), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer) As Action
        Return New MoveNRMAction(objs, dx, dy, stp)
    End Function

    Public Overrides Function GetAddAction(ByVal objs As System.Collections.Generic.List(Of NRMonster)) As Action
        Return New AddNRMAction(objs)
    End Function

    Public Overrides Function GetRemoveAction(ByVal objs As System.Collections.Generic.List(Of NRMonster)) As Action
        Return New RemoveNRMAction(objs)
    End Function

    Public Overrides Function NewOfT(ByVal x As Integer, ByVal y As Integer) As NRMonster
        If NRMPicker.SelectedIndex = -1 Then Return Nothing
        dragXOff = ed.EdControl.lvl.GFX.VictimImages(NRMPicker.SelectedIndex).Width / 2
        dragYOff = ed.EdControl.lvl.GFX.VictimImages(NRMPicker.SelectedIndex).Height / 2
        Return New NRMonster(x - ed.EdControl.lvl.GFX.VictimImages(NRMPicker.SelectedIndex).Width / 2,
                             y - ed.EdControl.lvl.GFX.VictimImages(NRMPicker.SelectedIndex).Height / 2, 0, 0,
                             Pointers.SpritePtrs(NRMPicker.SelectedIndex))
    End Function

    Public Overrides Function RectOfT(ByVal obj As NRMonster) As System.Drawing.Rectangle
        Return obj.Rect(ed.EdControl.lvl.GFX)
    End Function

    Public Overrides Sub RefreshList()
        levelList = ed.EdControl.lvl.objects.NRMonsters
    End Sub

    Public Overrides Function ToText(ByVal Objs As System.Collections.Generic.List(Of NRMonster)) As String
        Dim str As String = "2"
        For Each m As NRMonster In Objs
            str &= m.X.ToString("X4") & m.Y.ToString("X4") & m.extra.ToString("X4") & _
                   m.unused.ToString("X4") & m.ptr.ToString("X8")
        Next
        Return str
    End Function

    Public Overrides Property X(ByVal obj As NRMonster) As Integer
        Get
            Return obj.x
        End Get
        Set(ByVal value As Integer)
            obj.x = value
        End Set
    End Property

    Public Overrides Property Y(ByVal obj As NRMonster) As Integer
        Get
            Return obj.y
        End Get
        Set(ByVal value As Integer)
            obj.y = value
        End Set
    End Property
End Class
