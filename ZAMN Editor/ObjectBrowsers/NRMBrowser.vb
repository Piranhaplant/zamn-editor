Public Class NRMBrowser
    Inherits ObjectBrowser

    Public Sub New(ByVal gfx As LevelGFX)
        MyBase.New(gfx)
    End Sub

    Public Overrides Sub Init()
        itemCt = 7
        startIdx = 12
        Dim mp As New NRMProp
        mp.Dock = DockStyle.Fill
        propCtrl = mp
    End Sub
End Class
