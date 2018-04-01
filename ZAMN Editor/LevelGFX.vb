Public Class LevelGFX

    Public ItemImages As New List(Of Bitmap)
    Public VictimImages As New List(Of Bitmap)

    Public Sub New(ByVal s As IO.Stream, ByVal pal As Integer)
        Reload(s, pal)
    End Sub

    Public Sub Reload(ByVal s As IO.Stream, ByVal pal As Integer)
        s.Seek(Pointers.ItemGFX, IO.SeekOrigin.Begin)
        Dim gfx(3712) As Byte
        s.Read(gfx, 0, 3712)
        s.Seek(pal + 4, IO.SeekOrigin.Begin)
        Dim plt As Color() = SMDGFX.ReadPalette(s, 64, True)
        ItemImages.Clear()
        For l As Integer = 0 To My.Resources.ItemPalettes.Length - 1
            Dim bmp As New Bitmap(16, 16)
            Dim gfxIndex As Integer = My.Resources.ItemIndexes(l) * &H20
            Dim pltIndex As Integer = My.Resources.ItemPalettes(l) * &H10
            SMDGFX.DrawTile(bmp, 0, 0, gfx, gfxIndex, plt, pltIndex, False, False)
            SMDGFX.DrawTile(bmp, 0, 8, gfx, gfxIndex + &H20, plt, pltIndex, False, False)
            SMDGFX.DrawTile(bmp, 8, 0, gfx, gfxIndex + &H40, plt, pltIndex, False, False)
            SMDGFX.DrawTile(bmp, 8, 8, gfx, gfxIndex + &H60, plt, pltIndex, False, False)
            ItemImages.Add(bmp)
        Next
        VictimImages.Clear()
        VictimImages.Add(My.Resources.UnknownVictim)
        Dim s2 As New IO.BinaryReader(New ByteArrayStream(My.Resources.VictimGFX))
        Do Until s2.BaseStream.Position >= s2.BaseStream.Length - 1
            Dim width As Integer = s2.ReadByte, height As Integer = s2.ReadByte
            Dim displayWidth As Integer = s2.ReadByte, displayHeight As Integer = s2.ReadByte
            Dim img As New Bitmap(displayWidth * 8, displayHeight * 8)
            Dim pos As Integer = s2.BaseStream.Position
            For p As Byte = 0 To 1
                For y As Integer = 0 To height - 1
                    For x As Integer = 0 To width - 1
                        Dim indx As Integer = s2.ReadInt32
                        If indx > 0 Then
                            If (s2.ReadByte <> 0) = (p <> 0) Then
                                s.Seek(indx, IO.SeekOrigin.Begin)
                                SMDGFX.DrawTile(img, x * 8 + s2.ReadSByte, y * 8 + s2.ReadSByte, s, plt, s2.ReadByte * 16, s2.ReadByte > 0, s2.ReadByte > 0)
                            Else
                                s2.BaseStream.Seek(5, IO.SeekOrigin.Current)
                            End If
                        End If
                    Next
                Next
                If p = 0 Then s2.BaseStream.Seek(pos, IO.SeekOrigin.Begin)
            Next
            VictimImages.Add(img)
        Loop
        s.Close()
        s2.Close()
    End Sub
End Class
