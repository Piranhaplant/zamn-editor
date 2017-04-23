Public Class LevelGFX

    Public ItemImages As New List(Of Bitmap)
    Public VictimImages As New List(Of Bitmap)

    Public Sub New(ByVal s As IO.Stream, ByVal pal As Integer)
        Reload(s, pal)
    End Sub

    Public Sub Reload(ByVal s As IO.Stream, ByVal pal As Integer)
        s.Seek(Pointers.ItemGFX, IO.SeekOrigin.Begin)
        Dim gfx(3455) As Byte
        s.Read(gfx, 0, 3456)
        s.Seek(pal, IO.SeekOrigin.Begin)
        Dim plt As Color() = SNESGFX.ReadPalette(s, 256, True)
        ItemImages.Clear()
        For l As Integer = 0 To My.Resources.ItemPalettes.Length - 1
            Dim bmp As New Bitmap(16, 16)
            Dim gfxIndex As Integer = My.Resources.ItemIndexes(l) * &H20
            Dim pltIndex As Integer = My.Resources.ItemPalettes(l) * &H10
            SNESGFX.DrawTile(bmp, 0, 0, gfx, gfxIndex, plt, pltIndex, False, False)
            SNESGFX.DrawTile(bmp, 8, 0, gfx, gfxIndex + &H20, plt, pltIndex, False, False)
            SNESGFX.DrawTile(bmp, 0, 8, gfx, gfxIndex + &H40, plt, pltIndex, False, False)
            SNESGFX.DrawTile(bmp, 8, 8, gfx, gfxIndex + &H60, plt, pltIndex, False, False)
            ItemImages.Add(bmp)
        Next
        VictimImages.Clear()
        VictimImages.Add(My.Resources.UnknownVictim)
        Dim s2 As New IO.BinaryReader(New ByteArrayStream(My.Resources.VictimGFX))
        Do Until s2.BaseStream.Position >= s2.BaseStream.Length - 1
            Dim width As Integer = s2.ReadByte, height As Integer = s2.ReadByte
            Dim img As New Bitmap(width * 8, height * 8)
            Dim pos As Integer = s2.BaseStream.Position
            For p As Byte = 0 To 1
                For y As Integer = 0 To height - 1
                    For x As Integer = 0 To width - 1
                        Dim indx As Integer = s2.ReadInt32
                        If indx > 0 Then
                            If s2.ReadByte = p Then
                                s.Seek(indx, IO.SeekOrigin.Begin)
                                SNESGFX.DrawTile(img, x * 8 + s2.ReadSByte, y * 8 + s2.ReadSByte, s, plt, s2.ReadByte * 16, s2.ReadByte > 0, s2.ReadByte > 0)
                                'Hardcoded override for army guys face palette
                                If VictimImages.Count = 7 And y = 1 And (x = 0 Or x = 1) Then
                                    DrawArmyOverride(s, plt)
                                    If x = 1 Then ApplyOverride(img)
                                End If
                            Else
                                s2.BaseStream.Seek(5, IO.SeekOrigin.Current)
                            End If
                        End If
                    Next
                Next
                If p = 0 Then s2.BaseStream.Seek(pos, IO.SeekOrigin.Begin)
            Next
            'TODO: Actually have the copy stored in VictimGFX.bin
            If VictimImages.Count = 16 Then 'Second plant image
                VictimImages.Add(img)
            End If
            VictimImages.Add(img)
        Loop
        'Crop Zeke image because it's an extra tile tall
        VictimImages(40) = Crop(VictimImages(40), 16, 40)
        s.Close()
        s2.Close()
    End Sub

    Private OverrideNum As Integer = 0
    Private OverrideBmp As Bitmap = New Bitmap(16, 8)
    Private NewPalette As Color()

    Private Sub DrawArmyOverride(ByVal s As IO.FileStream, ByVal plt As Color())
        If OverrideNum = 0 Then
            NewPalette = plt.Clone()
            NewPalette(20) = plt(4)
            NewPalette(22) = plt(6)
        End If
        s.Seek(-&H20, IO.SeekOrigin.Current)
        SNESGFX.DrawTile(OverrideBmp, OverrideNum * 8, 0, s, NewPalette, 16, False, False)
        OverrideNum += 1
    End Sub

    Private Sub ApplyOverride(ByVal bmp As Bitmap)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.DrawImage(OverrideBmp.Clone(New Rectangle(7, 1, 8, 5), OverrideBmp.PixelFormat), 7, 9, 8, 5)
        End Using
        OverrideNum = 0
        OverrideBmp = New Bitmap(16, 8)
    End Sub

    Private Function Crop(ByVal img As Bitmap, ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim newImg As New Bitmap(width, height, img.PixelFormat)
        Using g As Graphics = Graphics.FromImage(newImg)
            g.DrawImage(img, 0, 0)
        End Using
        Return newImg
    End Function
End Class
