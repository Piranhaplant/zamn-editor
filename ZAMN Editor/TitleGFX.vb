Imports System.Drawing.Imaging

Public Class TitleGFX

    Public LetterImgs(&H5E) As Bitmap
    Public plt(&H80) As Color
    Private widths As Integer() = {3, 2, 6}

    Public Sub New(ByVal fs As IO.FileStream)
        fs.Seek(Pointers.TitlePalette, IO.SeekOrigin.Begin)
        plt = SNESGFX.ReadPalette(fs, &H80, False)
        fs.Seek(Pointers.TitleGraphics, IO.SeekOrigin.Begin)
        Dim GFX As Byte() = ZAMNCompress.Decompress(fs)
        Dim LinGFX(GFX.Length \ &H20 - 1)(,) As Byte
        For l As Integer = 0 To LinGFX.Length - 1
            LinGFX(l) = SNESGFX.PlanarToLinear(GFX, l * &H20)
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
        For l As Integer = 0 To &H5E
            Dim index As Integer = Pointers.TitleTileMap + tilePos(l).Y * &H600
            Dim width As Integer
            If tilePos(l).Y < 3 Then
                width = widths(tilePos(l).Y)
            End If
            curImg = New Bitmap(width * 8, 48, PixelFormat.Format8bppIndexed)
            Dim imgData As BitmapData = curImg.LockBits(New Rectangle(Point.Empty, curImg.Size), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed)
            index += width * tilePos(l).X * 2
            fs.Seek(index, IO.SeekOrigin.Begin)
            For y As Integer = 0 To 5
                For x As Integer = 0 To width - 1
                    Dim t As Byte = fs.ReadByte
                    SNESGFX.DrawTile(imgData, x * 8, y * 8, fs.ReadByte, t, LinGFX)
                Next
                fs.Seek(&H100 - width * 2, IO.SeekOrigin.Current)
            Next
            curImg.UnlockBits(imgData)
            LetterImgs(l) = curImg
        Next
    End Sub
End Class
