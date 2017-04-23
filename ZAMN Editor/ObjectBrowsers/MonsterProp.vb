Public Class MonsterProp
    Implements IPropCtrl

    Public m As Monster
    Public ml As List(Of Monster)
    Public ed As Editor
    Public init As Boolean

    Public ReadOnly Property GetHeight As Integer Implements IPropCtrl.GetHeight
        Get
            Return 150
        End Get
    End Property

    Public Sub SetEditor(ByVal ed As Editor) Implements IPropCtrl.SetEditor
        Me.ed = ed
    End Sub

    Public Sub SetEnabled(ByVal enabled As Boolean) Implements IPropCtrl.SetEnabled
        nudX.Enabled = enabled
        nudY.Enabled = enabled
        nudRadius.Enabled = enabled
        nudDelay.Enabled = enabled
        addr.Enabled = enabled
    End Sub

    Public Sub SetObject(ByVal obj As Object) Implements IPropCtrl.SetObject
        If TypeOf obj Is Monster Then
            m = obj
            ml = UndoManager.CreateList(m)
            init = True
            nudX.Value = Math.Max(0, m.x)
            nudY.Value = Math.Max(0, m.y)
            nudRadius.Value = m.radius
            nudDelay.Value = m.delay
            addr.Value = m.ptr
            init = False
        End If
    End Sub

    Private Sub nudX_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudX.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New MoveMonsterAction(ml, nudX.Value - m.x, 0, 1))
    End Sub

    Private Sub nudY_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudY.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New MoveMonsterAction(ml, 0, nudY.Value - m.y, 1))
    End Sub

    Private Sub nudRadius_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudRadius.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New ChangeMonsterRadiusAction(ml, nudRadius.Value))
    End Sub

    Private Sub nudDelay_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudDelay.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New ChangeMonsterDelayAction(ml, nudDelay.Value))
    End Sub

    Private Sub addr_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles addr.ValueChanged
        If init Or ed Is Nothing Then Return
        ed.EdControl.UndoMgr.Do(New ChangeMonsterTypeAction(ml, addr.Value))
    End Sub
End Class
