Public Class NRMProp
    Implements IPropCtrl

    Public m As NRMonster
    Public ml As List(Of NRMonster)
    Public ed As Editor
    Public init As Boolean

    Public ReadOnly Property GetHeight As Integer Implements IPropCtrl.GetHeight
        Get
            Return 100
        End Get
    End Property

    Public Sub SetEditor(ByVal ed As Editor) Implements IPropCtrl.SetEditor
        Me.ed = ed
    End Sub

    Public Sub SetEnabled(ByVal enabled As Boolean) Implements IPropCtrl.SetEnabled
        nudX.Enabled = enabled
        nudY.Enabled = enabled
        addr.Enabled = enabled
    End Sub

    Public Sub SetObject(ByVal obj As Object) Implements IPropCtrl.SetObject
        If TypeOf obj Is NRMonster Then
            m = obj
            ml = UndoManager.CreateList(m)
            init = True
            nudX.Value = m.x
            nudY.Value = m.y
            addr.Value = m.ptr
            init = False
        End If
    End Sub

    Private Sub nudX_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudX.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New MoveNRMAction(ml, nudX.Value - m.x, 0, 1))
    End Sub

    Private Sub nudY_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudY.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New MoveNRMAction(ml, 0, nudY.Value - m.y, 1))
    End Sub

    Private Sub addr_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles addr.ValueChanged
        If init Or ed Is Nothing Then Return
        ed.EdControl.UndoMgr.Do(New ChangeNRMTypeAction(ml, addr.Value))
    End Sub
End Class
