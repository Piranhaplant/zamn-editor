Public Class ItemBrowser
    Inherits ObjectBrowser

    Public errorItems As Integer() = {9, 14, 25}

    Public Sub New(ByVal gfx As LevelGFX)
        MyBase.New(gfx)
    End Sub

    Public Overrides Function ItemWidth(ByVal index As Integer) As Integer
        Return 16
    End Function

    Public Overrides Function ItemHeight(ByVal index As Integer) As Integer
        Return 16
    End Function

    Public Overrides ReadOnly Property hasToolTips As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Init()
        itemCt = gfx.ItemImages.Count - 1
        toolTipText = {"Squirtgun", "Fire extinguisher", "Bubble gun", "Weed whacker", "Key", "Speed shoes", "Monster potion", _
                       "Blue potion", "Mystery potion", "Beta gray mystery potion. DO NOT USE", "Hamburger, heals 3 health", _
                       "Soda cans", "Tomatoes", "Popsicles", "Beta banana item. DO NOT USE", "Heath Kit", "Plates", "Silverware", _
                       "Ancient Artifact", "Bazooka", "Footballs", "Flamethrower", "Pandora's box", "Skeleton key", "Clowns", _
                       "Key pile dropped when one player dies. DO NOT USE", "Leads to a bonus level if secret bonus is enabled, or a point bonus if not", _
                       "Gives the player an extra life", "Gold", "Money"}
        Dim ip As New ItemProp
        ip.Dock = DockStyle.Fill
        propCtrl = ip
    End Sub

    Public Overrides Sub PaintObject(ByVal g As System.Drawing.Graphics, ByVal x As Integer, ByVal y As Integer, ByVal num As Integer)
        g.DrawImage(gfx.ItemImages(num), x, y)
        If errorItems.Contains(num) Then
            g.DrawImage(My.Resources.ErrorImg, x + 8, y + 8)
        End If
    End Sub
End Class