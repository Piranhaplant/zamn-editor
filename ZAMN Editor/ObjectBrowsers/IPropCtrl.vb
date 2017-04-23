Public Interface IPropCtrl

    Sub SetEnabled(ByVal enabled As Boolean)
    Sub SetObject(ByVal obj As Object)
    Sub SetEditor(ByVal ed As Editor)
    ReadOnly Property GetHeight As Integer

End Interface
