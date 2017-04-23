Public Class SpriteBrowser
    Inherits ObjectBrowser

    Public errorItems As Integer() = {9, 14, 25}

    Public Sub New(ByVal gfx As LevelGFX)
        MyBase.New(gfx)
    End Sub

    'Note: Extra ones and threes are added and subtracted to account for the the placeholder victim, Zeke, and Julie in the victim images
    Public Overrides Function ItemWidth(ByVal index As Integer) As Integer
        If index < gfx.ItemImages.Count Then
            Return 16
        ElseIf index < gfx.ItemImages.Count + gfx.VictimImages.Count - 3 Then
            Return gfx.VictimImages(index - gfx.ItemImages.Count + 1).Width
        Else
            Return canvas.Width - 17
        End If
    End Function

    Public Overrides Function ItemHeight(ByVal index As Integer) As Integer
        If index < gfx.ItemImages.Count Then
            Return 16
        ElseIf index < gfx.ItemImages.Count + gfx.VictimImages.Count - 3 Then
            Return gfx.VictimImages(index - gfx.ItemImages.Count + 1).Height
        Else
            Return 13
        End If
    End Function

    Public Overrides Sub Init()
        itemCt = gfx.ItemImages.Count + gfx.VictimImages.Count + Pointers.BossMonsters.Length - 4
    End Sub

    Public Overrides ReadOnly Property hasProperties As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Sub PaintObject(ByVal g As System.Drawing.Graphics, ByVal x As Integer, ByVal y As Integer, ByVal num As Integer)
        If num < gfx.ItemImages.Count Then
            g.DrawImage(gfx.ItemImages(num), x, y)
            If errorItems.Contains(num) Then
                g.DrawImage(My.Resources.ErrorImg, x + 8, y + 8)
            End If
        ElseIf num < gfx.ItemImages.Count + gfx.VictimImages.Count - 3 Then
            g.DrawImage(gfx.VictimImages(num - gfx.ItemImages.Count + 1), x, y)
        Else
            g.DrawString(Pointers.BossMonsterNames(num - gfx.ItemImages.Count - gfx.VictimImages.Count + 3), BossMonster.dispfont, Brushes.Black, x, y)
        End If
    End Sub
End Class