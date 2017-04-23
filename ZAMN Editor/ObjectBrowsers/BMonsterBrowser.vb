Public Class BMonsterBrowser
    Inherits ObjectBrowser

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides Function ItemWidth(ByVal index As Integer) As Integer

    End Function

    Public Overrides Function ItemHeight(ByVal index As Integer) As Integer
        Return 13
    End Function

    Public Overrides ReadOnly Property LayoutHoriz As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Sub Init()
        itemCt = 4
        Dim mp As New BMonsterProp
        mp.Dock = DockStyle.Fill
        propCtrl = mp
    End Sub

    Public Overrides Sub PaintObject(ByVal g As System.Drawing.Graphics, ByVal x As Integer, ByVal y As Integer, ByVal num As Integer)
        g.DrawString(Pointers.BossMonsterNames(num), BossMonster.dispfont, Brushes.Black, x, y)
    End Sub
End Class
