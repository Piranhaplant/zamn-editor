Imports System.Drawing.Imaging

Public Class TitleGFX

    Public LetterImgs(&H5E) As Bitmap
    Public plt(&H3F) As Color
    Private widths As Integer() = {3, 2, 6}

    Public Sub New(ByVal fs As IO.FileStream)
        fs.Seek(Pointers.TitlePalette, IO.SeekOrigin.Begin)
        plt = SMDGFX.ReadPalette(fs, &H40, False)
        fs.Seek(Pointers.TitleGraphics, IO.SeekOrigin.Begin)
        Dim GFX As Byte() = ZAMNCompress.Decompress(fs)
        Dim LinGFX(511)(,) As Byte
        For l As Integer = 0 To &H1E8 'It used to go up to 511, but I think only 0x1E9 tiles actually exist
            LinGFX(l) = SMDGFX.GetTile(GFX, l * &H20)
        Next
        Dim tilePos(&H5E) As Point
        fs.Seek(Pointers.TitleCharWidth, IO.SeekOrigin.Begin)
        For l As Integer = 0 To &H5E
            tilePos(l) = New Point(fs.ReadByte, fs.ReadByte)
            If tilePos(l).X = 255 Then
                tilePos(l) = Point.Empty
            End If
        Next
        Dim curImg As Bitmap
        fs.Seek(Pointers.TitleTileMap, IO.SeekOrigin.Begin)
        Dim Map As Byte() = ZAMNCompress.Decompress(fs)

        For l As Integer = 0 To &H5E
            Dim index As Integer = tilePos(l).Y * &H600
            Dim width As Integer
            If tilePos(l).Y < 3 Then
                width = widths(tilePos(l).Y)
            End If
            curImg = New Bitmap(width * 8, 48, PixelFormat.Format8bppIndexed)
            Dim imgData As BitmapData = curImg.LockBits(New Rectangle(Point.Empty, curImg.Size), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed)
            index += width * tilePos(l).X * 2

            For y As Integer = 0 To 5
                For x As Integer = 0 To width - 1
                    SMDGFX.DrawTile(imgData, x * 8, y * 8, Map(index), Map(index + 1), LinGFX)
                    index += 2
                Next
                index += (&H100 - width * 2)
            Next
            curImg.UnlockBits(imgData)
            LetterImgs(l) = curImg
        Next
    End Sub
End Class
