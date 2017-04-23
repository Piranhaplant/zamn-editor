Public Class ItemTool
    Inherits ObjectTool(Of Item)

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        pasteChar = "I"
        SidePanel = SideContentType.Items
        typeName = "item"
        UpdateCaptions()
        Me.Status = DefaultText
    End Sub

    Public Overrides Function CloneT(ByVal o As Item) As Item
        Return New Item(o)
    End Function

    Public Overrides Function FromText(ByVal txt As String) As System.Collections.Generic.List(Of Item)
        Dim items As New List(Of Item)
        Try
            Dim indx As Integer = 2
            Do Until indx > txt.Length
                items.Add(New Item(CInt("&H" & Mid(txt, indx, 4)), CInt("&H" & Mid(txt, indx + 4, 4)), _
                                   CInt("&H" & Mid(txt, indx + 8, 2))))
                indx += 10
            Loop
        Catch
        End Try
        Return items
    End Function

    Public Overrides Function GetChangeAction(ByVal objs As System.Collections.Generic.List(Of Item), ByVal newType As Integer) As Action
        Return New ChangeItemTypeAction(objs, newType)
    End Function

    Public Overrides Function GetMoveAction(ByVal objs As System.Collections.Generic.List(Of Item), ByVal dx As Integer, ByVal dy As Integer, ByVal stp As Integer) As Action
        Return New MoveItemAction(objs, dx, dy, stp)
    End Function

    Public Overrides Function GetAddAction(ByVal objs As System.Collections.Generic.List(Of Item)) As Action
        Return New AddItemAction(objs)
    End Function

    Public Overrides Function GetRemoveAction(ByVal objs As System.Collections.Generic.List(Of Item)) As Action
        Return New RemoveItemAction(objs)
    End Function

    Public Overrides Function NewOfT(ByVal x As Integer, ByVal y As Integer) As Item
        If ItemPicker.SelectedIndex = -1 Then Return Nothing
        dragXOff = 8
        dragYOff = 8
        Return New Item(x - 8, y - 8, ItemPicker.SelectedIndex)
    End Function

    Public Overrides Function RectOfT(ByVal obj As Item) As System.Drawing.Rectangle
        Return obj.Rect(Nothing)
    End Function

    Public Overrides Sub RefreshList()
        levelList = ed.EdControl.lvl.objects.Items
    End Sub

    Public Overrides Function ToText(ByVal Objs As System.Collections.Generic.List(Of Item)) As String
        Dim str As String = "0"
        For Each i As Item In Objs
            str &= i.X.ToString("X4") & i.Y.ToString("X4") & i.Type.ToString("X2")
        Next
        Return str
    End Function

    Public Overrides Property X(ByVal obj As Item) As Integer
        Get
            Return obj.x
        End Get
        Set(ByVal value As Integer)
            obj.x = value
        End Set
    End Property

    Public Overrides Property Y(ByVal obj As Item) As Integer
        Get
            Return obj.y
        End Get
        Set(ByVal value As Integer)
            obj.y = value
        End Set
    End Property
End Class
