Public Class VictimBrowser
    Inherits ObjectBrowser

    Public Sub New(ByVal gfx As LevelGFX)
        MyBase.New(gfx)
    End Sub

    Public Overrides Sub Init()
        itemCt = 10
        startIdx = 1
        Dim vp As New VictimProp
        vp.Dock = DockStyle.Fill
        propCtrl = vp
    End Sub
End Class