Imports System.Drawing.Imaging

Public Class TileAnimation

    Private tileset As Tileset
    Private animations As New List(Of List(Of UShort))
    Private loopAnim As New List(Of Boolean)
    Private tilePositions As New List(Of List(Of TilePos))
    Private curFrame As Integer = 0
    Private totalFrames As Integer = 0

    Public Sub New(ByVal tileset As Tileset, ByVal tileAnimBoss As BossMonster)
        Me.tileset = tileset
        Dim i As Integer = 0
        Dim value As Integer = -1
        Do While value <> 0 And i < tileAnimBoss.exData.Length - 1
            value = tileAnimBoss.exData(i) + tileAnimBoss.exData(i + 1) * &H100
            i += 2
        Loop

        Dim curAnim As New List(Of UShort)
        Do While i < tileAnimBoss.exData.Length - 1
            value = tileAnimBoss.exData(i) + tileAnimBoss.exData(i + 1) * &H100
            If value >= &HFFFE Then
                loopAnim.Add(value = &HFFFF)
                animations.Add(curAnim)
                curAnim = New List(Of UShort)
            Else
                curAnim.Add(value)
            End If
            i += 2
        Loop

        For Each anim As List(Of UShort) In animations
            Dim curTotalFrames As Integer = 0
            For f As Integer = 1 To anim.Count - 1 Step 2
                curTotalFrames += anim(f)
            Next
            If curTotalFrames > totalFrames Then
                totalFrames = curTotalFrames
            End If
        Next

        For Each anim As List(Of UShort) In animations
            Dim startTile As UShort = anim(0)
            Dim tilePosList As New List(Of TilePos)

            For t As Integer = 0 To &HFF
                For m As Integer = t * &H80 To t * &H80 + &H7F Step 2
                    Dim g As Integer = tileset.map16(m)
                    If (tileset.map16(m + 1) And 1) = 1 Then
                        g += &H100
                    End If
                    If g = startTile Then
                        Dim x As Integer = ((m Mod &H80) \ 2) Mod 8
                        Dim y As Integer = ((m Mod &H80) \ 2) \ 8
                        tilePosList.Add(New TilePos(t, x, y))
                    End If
                Next
            Next
            tilePositions.Add(tilePosList)
        Next
    End Sub

    Public Function AdvanceFrame(Optional ByVal doLoop As Boolean = True) As Boolean
        curFrame += 1
        If curFrame = &H100000 Then
            curFrame = &H10000
        End If

        Dim animated As Boolean = False

        For i As Integer = 0 To animations.Count - 1
            Dim data As BitmapData = Nothing
            For t As Integer = 0 To tilePositions(i).Count - 1
                Dim animTile = GetTileForFrame(animations(i), curFrame, loopAnim(i) And doLoop)
                If animTile > -1 And animTile < tileset.LinGFX.Length Then
                    Dim pos As TilePos = tilePositions(i)(t)
                    data = tileset.images(pos.tileNum).LockBits(New Rectangle(0, 0, 64, 64), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed)
                    SNESGFX.DrawTile(data, pos.x * 8, pos.y * 8, tileset.map16(pos.tileNum * &H80 + (pos.y * 8 + pos.x) * 2 + 1) And &HFE, animTile, tileset.LinGFX)
                    tileset.images(pos.tileNum).UnlockBits(data)
                    animated = True
                End If
            Next
        Next
        Return animated
    End Function

    Private Function GetTileForFrame(ByVal anim As List(Of UShort), ByVal frame As Integer, ByVal doLoop As Boolean) As Integer
        Dim frameCount As Integer = 0
        For i As Integer = 0 To anim.Count - 2 Step 2
            frameCount += anim(i + 1)
        Next
        If frame = frameCount And Not doLoop Then
            Return anim(anim.Count - 1)
        End If
        If frame > frameCount And Not doLoop Then
            Return -1
        End If
        frame = frame Mod frameCount
        For i As Integer = 0 To anim.Count - 2 Step 2
            If frame = 0 Then
                If i = 0 And doLoop Then
                    Return anim(anim.Count - 1)
                Else
                    Return anim(i)
                End If
            End If
            frame -= anim(i + 1)
        Next
        Return -1
    End Function

    Public Sub NextFrame()
        If animations.Count = 0 OrElse (curFrame >= totalFrames AndAlso Not loopAnim(0)) Then
            Return
        End If
        Dim i As Integer = 0 'Just in case something goes wrong, don't want to loop forever
        Do Until AdvanceFrame() Or i = &H10000
            i += 1
        Loop
    End Sub

    Public Sub Reset()
        curFrame = -1
        AdvanceFrame(False)
    End Sub

    Private Class TilePos
        Public tileNum As Integer
        Public x As Integer
        Public y As Integer

        Public Sub New(ByVal tileNum As Integer, ByVal x As Integer, ByVal y As Integer)
            Me.tileNum = tileNum
            Me.x = x
            Me.y = y
        End Sub
    End Class
End Class
