Public Class VictimProp
    Implements IPropCtrl

    Public v As Victim
    Public vl As List(Of Victim)
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
        If TypeOf obj Is Victim Then
            v = obj
            vl = UndoManager.CreateList(v)
            init = True
            nudX.Value = Math.Max(0, v.x)
            nudY.Value = Math.Max(0, v.y)
            addr.Value = v.ptr
            init = False
        End If
    End Sub

    Private Sub nudX_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudX.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New MoveVictimAction(vl, nudX.Value - v.x, 0, 1))
    End Sub

    Private Sub nudY_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudY.ValueChanged
        If init Then Return
        ed.EdControl.UndoMgr.Do(New MoveVictimAction(vl, 0, nudY.Value - v.y, 1))
    End Sub

    Private Sub addr_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles addr.ValueChanged
        If init Or ed Is Nothing Then Return
        ed.EdControl.UndoMgr.Do(New ChangeVictimTypeAction(vl, addr.Value))
    End Sub
End Class
