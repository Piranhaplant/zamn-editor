Public Class MonsterBrowser
    Inherits ObjectBrowser

    Public Sub New(ByVal gfx As LevelGFX)
        MyBase.New(gfx)
    End Sub

    Public Overrides Sub Init()
        itemCt = 19
        startIdx = 20
        Dim mp As New MonsterProp
        mp.Dock = DockStyle.Fill
        propCtrl = mp
    End Sub
End Class
