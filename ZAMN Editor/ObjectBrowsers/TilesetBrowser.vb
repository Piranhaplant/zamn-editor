Public Class TilesetBrowser
    Inherits ObjectBrowser

    Public tiles As List(Of Byte)
    Public selectedTile As Integer

    Public Shared NumFont As New Font("Small Fonts", 9)

    Public Sub New(ByVal ts As Tileset)
        MyBase.New(ts)
    End Sub

    Public Overrides Sub Init()
        SetAll()
        selectedTile = -1
        SelectedIndex = -1
    End Sub

    Public Overrides Function ItemWidth(ByVal index As Integer) As Integer
        Return 72
    End Function

    Public Overrides Function ItemHeight(ByVal index As Integer) As Integer
        Return 64
    End Function

    Public Overrides ReadOnly Property hasProperties As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Sub PaintObject(ByVal g As System.Drawing.Graphics, ByVal x As Integer, ByVal y As Integer, ByVal num As Integer)
        If ed.EdControl.priority Then
            g.DrawImage(ts.priorityImages(tiles(num)), x, y)
        Else
            g.DrawImage(ts.images(tiles(num)), x, y)
        End If
        g.DrawString(Hex(tiles(num) \ &H10), NumFont, Brushes.Black, x + 68, y)
        g.DrawString(Hex(tiles(num) Mod &H10), NumFont, Brushes.Black, x + 68, y + 12)
    End Sub

    Public Sub LoadTileset(ByVal ts As Tileset)
        Me.ts = ts
        SetAll()
        UpdateScrollBar()
    End Sub

    Private Sub TilesetBrowser_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ValueChanged
        If SelectedIndex = -1 Then
            selectedTile = -1
            Return
        End If
        selectedTile = tiles(SelectedIndex)
    End Sub

    Public Sub SetTiles(ByVal tiles As List(Of Byte))
        tiles.Sort()
        Me.tiles = tiles
        itemCt = tiles.Count - 1
        UpdateScrollBar()
        ResetScrollBar()
    End Sub

    Public Sub SetAll()
        If itemCt = 255 Then Return
        SelectedIndex = selectedTile
        If tiles Is Nothing Then
            tiles = New List(Of Byte)
        End If
        tiles.Clear()
        tiles.Capacity = 256
        For l As Integer = 0 To 255
            tiles.Add(l)
        Next
        itemCt = 255
        UpdateScrollBar()
        ScollToSelected()
    End Sub
End Class
