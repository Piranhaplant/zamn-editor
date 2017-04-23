Public Class ItemProp
    Implements IPropCtrl

    Public i As Item
    Public il As List(Of Item)
    Public ed As Editor
    Public init As Boolean

    Public ReadOnly Property GetHeight As Integer Implements IPropCtrl.GetHeight
        Get
            Return 80
        End Get
    End Property

    Public Sub SetEditor(ByVal ed As Editor) Implements IPropCtrl.SetEditor
        Me.ed = ed
    End Sub

    Public Sub SetEnabled(ByVal enabled As Boolean) Implements IPropCtrl.SetEnabled
        nudX.Enabled = enabled
        nudY.Enabled = enabled
        nudNum.Enabled = enabled
    End Sub

    Public Sub SetObject(ByVal obj As Object) Implements IPropCtrl.SetObject
        If TypeOf obj Is Item Then
            i = obj
            il = UndoManager.CreateList(i)
            init = True
            nudX.Value = i.x
            nudY.Value = i.y
            nudNum.Value = i.type
            init = False
        End If
    End Sub

    Private Sub nudX_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudX.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New MoveItemAction(il, nudX.Value - i.x, 0, 1))
    End Sub

    Private Sub nudY_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudY.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New MoveItemAction(il, 0, nudY.Value - i.y, 1))
    End Sub

    Private Sub nudNum_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudNum.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New ChangeItemTypeAction(il, nudNum.Value))
    End Sub
End Class
