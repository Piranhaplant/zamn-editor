Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class SMDGFX

    Public Shared Function RGBtoSMDLo(ByVal RGB As Color) As Byte
        Return (RGB.G \ 16 * &H10 + RGB.R \ 16)
    End Function

    Public Shared Function RGBtoSMDHi(ByVal RGB As Color) As Byte
        Return (RGB.B \ 16 )
    End Function

    Public Shared Function SMDtoRGB(ByVal HiByte As Byte, ByVal LoByte As Byte) As Color
        Dim v As Integer = LoByte + &H100 * HiByte
		Return Color.FromArgb((v Mod &H10) * 16, ((v \ &H10) Mod &H10) * 16, ((v \ &H100) Mod &H10) * 16)
    End Function

    Public Shared Function ReadPalette(ByVal s As IO.Stream, ByVal colorCount As Integer, ByVal transparant As Boolean) As Color()
        Dim plt(colorCount - 1) As Color
        For l As Integer = 0 To colorCount - 1
            plt(l) = SMDtoRGB(s.ReadByte, s.ReadByte)
            If transparant AndAlso l Mod 16 = 0 Then
                plt(l) = Color.FromArgb(0, plt(l))
            End If
        Next
        Return plt
    End Function

    Public Shared Function GetTile(ByVal bytes As Byte(), ByVal index As Integer) As Byte(,)
        Dim result(7, 7) As Byte
        Dim line As Integer = 0
        Dim bit As Integer = 0
		For l As Integer = index To index + &H1F Step 4
			For x As Integer = 0 to 7
				If (x Mod 2) = 0 Then
                    result(line, x) = bytes(l + (x \ 2)) \ &H10
                Else
                    result(line, x) = bytes(l + (x \ 2)) Mod &H10
                End If
			Next
			line += 1
		Next
        Return result
    End Function

    Public Shared Sub DrawTile(ByVal bmp As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal gfx As Byte(), ByVal gfxindex As Integer, ByVal palette As Color(), ByVal palIndex As Integer, ByVal xFlip As Boolean, ByVal yFlip As Boolean)
        Dim tile As Byte(,) = GetTile(gfx, gfxindex)
        Dim xStep As Integer = 1, yStep As Integer = 1
        If xFlip Then
            x += 7
            xStep = -1
        End If
        Dim xOrig As Integer = x
        If yFlip Then
            y += 7
            yStep = -1
        End If
        For l As Integer = 0 To 7
            For m As Integer = 0 To 7
                If palette(palIndex + tile(l, m)).A > 0 Then
                    If x >= bmp.Width Then
                        x = bmp.Width - 1
                    End If
                    bmp.SetPixel(x, y, palette(palIndex + tile(l, m)))
                End If
                x += xStep
            Next
            y += yStep
            x = xOrig
        Next
    End Sub

    Public Shared Sub DrawTile(ByVal bmp As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal s As IO.Stream, ByVal palette As Color(), ByVal palIndex As Integer, ByVal xFlip As Boolean, ByVal yFlip As Boolean)
        Dim gfx(31) As Byte
        s.Read(gfx, 0, 32)
        If x < 0 Then
            x = 0
        End If
        If y < 0 Then
            y = 0
        End If
        DrawTile(bmp, x, y, gfx, 0, palette, palIndex, xFlip, yFlip)
    End Sub

    Public Shared Sub DrawTile(ByVal bmp As BitmapData, ByVal x As Integer, ByVal y As Integer, ByVal data As Byte, ByVal tileIndex As Integer, ByVal tiles As Byte()(,))
        Dim palIndex As Byte = &H10 * ((data \ 32) And 3)
        If (data And 1) = 1 Then tileIndex += &H100
        Dim xFlip As Boolean = (data And 8) > 1
        Dim yFlip As Boolean = (data And &H10) > 1
        Dim xStep As Integer = 1, yStep As Integer = 1
        If xFlip Then
            x += 7
            xStep = -1
        End If
        Dim xOrig As Integer = x
        If yFlip Then
            y += 7
            yStep = -1
        End If
        For l As Integer = 0 To 7
            For m As Integer = 0 To 7
                Marshal.WriteByte(bmp.Scan0, y * bmp.Stride + x, palIndex + tiles(tileIndex)(l, m))
                x += xStep
            Next
            y += yStep
            x = xOrig
        Next
    End Sub

    Public Shared Sub FillPalette(ByVal bmp As Bitmap, ByVal colors As Color())
        Dim pal As ColorPalette = bmp.Palette
        For l As Integer = 0 To colors.Length - 1
            pal.Entries(l) = colors(l)
        Next
        bmp.Palette = pal
    End Sub

    Public Shared Sub MakePltTransparent(ByVal bmp As Bitmap)
        Dim pal As ColorPalette = bmp.Palette
        For l As Integer = 0 To pal.Entries.Length - 1 Step 16
            pal.Entries(l) = Color.Transparent
        Next
        bmp.Palette = pal
    End Sub

    Public Shared Sub DrawWithPlt(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal bmp As Bitmap, ByVal plt As Color(), ByVal colorIdx As Integer, ByVal colorCount As Integer)
        Dim pal As ColorPalette = bmp.Palette
        For l As Integer = 0 To colorCount - 1
            pal.Entries(l) = plt((l + colorIdx) Mod plt.Length)
        Next
        bmp.Palette = pal
        g.DrawImage(bmp, x, y)
    End Sub
End Class
