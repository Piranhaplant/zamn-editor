Public Class Level
    Public name As String
    Public num As Integer
    Public tileset As Tileset
    Public Tiles As Integer(,)
    Public Width As UShort
    Public Height As UShort
    Public objects As LevelObjList = New LevelObjList
    Public p1Start As Point
    Public p2Start As Point
    Public music As UShort
    Public unknown As UShort
    Public sounds As UShort
    Public unknown3 As UShort
    Public page1 As TitlePage
    Public page2 As TitlePage
    Public bonuses As New List(Of Integer)
    Public spritePal As Integer
    Public GFX As LevelGFX
    Public animation As TileAnimation

    Public Sub New(ByVal s As IO.Stream, ByVal name As String, ByVal num As Integer, Optional ByVal import As Boolean = False, Optional ByVal romStream As IO.Stream = Nothing)
        Me.name = name
        Me.num = num
        ErrorLog.HasError() 'Clear error in case there was one

        If import Then
            s.Seek(14, IO.SeekOrigin.Begin)
        End If

        Dim startAddr As Long = s.Position
        Debug.WriteLine(num & " " & name & ": 0x" + Hex(startAddr))
        If import Then
            Dim tiles As Integer = Pointers.ReadPointer(s)
            s.Seek(4, IO.SeekOrigin.Current)
            tileset = New Tileset(romStream, tiles, Pointers.ReadPointer(s), Pointers.ReadPointer(s), Pointers.ReadPointer(s), Pointers.ReadPointer(s), Pointers.ReadPointer(s))
        Else
            tileset = New Tileset(s)
        End If
        s.Seek(startAddr + &H22, IO.SeekOrigin.Begin)
        Width = s.ReadByte() + s.ReadByte() * &H100
        Height = s.ReadByte() + s.ReadByte() * &H100
        ReDim Tiles(Width - 1, Height - 1)
        unknown = s.ReadByte + s.ReadByte * &H100
        unknown3 = s.ReadByte + s.ReadByte * &H100
        p1Start = New Point(s.ReadByte + s.ReadByte * &H100, s.ReadByte + s.ReadByte * &H100)
        p2Start = New Point(s.ReadByte + s.ReadByte * &H100, s.ReadByte + s.ReadByte * &H100)
        music = s.ReadByte + s.ReadByte * &H100
        sounds = s.ReadByte + s.ReadByte * &H100
        s.Seek(startAddr + &H14, IO.SeekOrigin.Begin)
        spritePal = Pointers.ReadPointer(s)
        If import Then
            s.Seek(4, IO.SeekOrigin.Begin)
            s.Seek(s.ReadByte + s.ReadByte * &H100 + 14, IO.SeekOrigin.Begin)
        Else
            s.Seek(startAddr + &H20, IO.SeekOrigin.Begin)
            Pointers.GoToRelativePointer(s, &H9F)
        End If
        If Not ErrorLog.HasError Then
            Do
                Dim v As Integer = s.ReadByte + s.ReadByte * &H100
                If v = 0 Then Exit Do
                objects.Add(New Item(v - 8, s.ReadByte + s.ReadByte * &H100 - 8, s.ReadByte \ 2))
            Loop
        End If
        If import Then
            s.Seek(2, IO.SeekOrigin.Begin)
            s.Seek(s.ReadByte + s.ReadByte * &H100 + 14, IO.SeekOrigin.Begin)
        Else
            s.Seek(startAddr + &H1E, IO.SeekOrigin.Begin)
            Pointers.GoToRelativePointer(s, &H9F)
        End If
        If Not ErrorLog.HasError Then
            For n As Integer = 1 To 10
                Dim vic As New Victim(s.ReadByte + s.ReadByte * &H100, s.ReadByte + s.ReadByte * &H100, s.ReadByte + s.ReadByte * &H100, _
                                      s.ReadByte + s.ReadByte * &H100, Pointers.ReadPointer(s))
                vic.x -= Pointers.SpriteOffsets(vic.index * 2)
                vic.y -= Pointers.SpriteOffsets(vic.index * 2 + 1)
                objects.Add(vic)
            Next
            objects.Add(New Victim(p1Start.X - 8, p1Start.Y - 39, 0, 0, 1))
            objects.Add(New Victim(p2Start.X - 16, p2Start.Y - 42, 0, 0, 2))
            Do
                Dim x As Integer = s.ReadByte + s.ReadByte * &H100
                If x = 0 Then Exit Do
                Dim mon As New NRMonster(x, s.ReadByte + s.ReadByte * &H100, s.ReadByte + s.ReadByte * &H100, _
                                         s.ReadByte + s.ReadByte * &H100, Pointers.ReadPointer(s))
                mon.x -= Pointers.SpriteOffsets(mon.index * 2)
                mon.y -= Pointers.SpriteOffsets(mon.index * 2 + 1)
                objects.Add(mon)
            Loop
        End If
        If import Then
            s.Seek(0, IO.SeekOrigin.Begin)
            s.Seek(s.ReadByte + s.ReadByte * &H100 + 14, IO.SeekOrigin.Begin)
        Else
            s.Seek(startAddr + 28, IO.SeekOrigin.Begin)
            Pointers.GoToRelativePointer(s, &H9F)
        End If
        If Not ErrorLog.HasError Then
            Do
                Dim radius As Integer = s.ReadByte
                Dim x1 As Integer = s.ReadByte
                If x1 = 0 And radius = 0 Then Exit Do
                Dim mon As New Monster(radius, x1 + s.ReadByte * &H100, s.ReadByte + s.ReadByte * &H100, _
                                       s.ReadByte, Pointers.ReadPointer(s))
                mon.x -= Pointers.SpriteOffsets(mon.index * 2)
                mon.y -= Pointers.SpriteOffsets(mon.index * 2 + 1)
                objects.Add(mon)
            Loop
        End If
        If import Then
            s.Seek(6, IO.SeekOrigin.Begin)
            s.Seek(s.ReadByte + s.ReadByte * &H100 + 14, IO.SeekOrigin.Begin)
            page1 = New TitlePage(s)
            s.Seek(8, IO.SeekOrigin.Begin)
            s.Seek(s.ReadByte + s.ReadByte * &H100 + 14, IO.SeekOrigin.Begin)
            page2 = New TitlePage(s)
        Else
            s.Seek(startAddr + &H36, IO.SeekOrigin.Begin)
            Pointers.GoToRelativePointer(s, &H9F)
            ErrorLog.CheckError("Level is missing title page 1.")
            page1 = New TitlePage(s)
            s.Seek(startAddr + &H38, IO.SeekOrigin.Begin)
            Pointers.GoToRelativePointer(s, &H9F)
            ErrorLog.CheckError("Level is missing title page 2.")
            page2 = New TitlePage(s)
        End If
        If import Then
            s.Seek(10, IO.SeekOrigin.Begin)
            s.Seek(s.ReadByte + s.ReadByte * &H100 + 14, IO.SeekOrigin.Begin)
        Else
            s.Seek(startAddr + &H3A, IO.SeekOrigin.Begin)
            Pointers.GoToRelativePointer(s, &H9F)
        End If
        If Not ErrorLog.HasError Then
            Do
                Dim n As Integer = s.ReadByte + s.ReadByte * &H100
                If n = 0 Then Exit Do
                bonuses.Add(n)
            Loop
        End If
        s.Seek(startAddr + &H3C, IO.SeekOrigin.Begin)
        Do
            Dim ptr As Integer = Pointers.ReadPointer(s)
            If ptr = -1 Then Exit Do
            If ZAMNEditor.Pointers.SpBossMonsters.Contains(ptr) Then
                Dim curaddr As Integer = s.Position
                If import Then
                    Dim bossDataPtr = s.ReadByte() + s.ReadByte() * &H100
                    If bossDataPtr > 0 Then
                        s.Seek(bossDataPtr + 14, IO.SeekOrigin.Begin)
                    Else
                        'Ignore if it has no pointer (which means it came from an older version of the editor)
                        s.Seek(curaddr + 4, IO.SeekOrigin.Begin)
                        Continue Do
                    End If
                Else
                    Pointers.GoToPointer(s)
                End If
                Select Case ptr
                    Case ZAMNEditor.Pointers.SpBossMonsters(0)
                        objects.Add(New BossMonster(ptr, s, 8))
                    Case ZAMNEditor.Pointers.SpBossMonsters(1)
                        Dim value As Integer, count As Integer, passed As Boolean = False
                        Dim newData As New List(Of Byte)
                        If s.Position > curaddr Then
                            Do
                                value = s.ReadByte + s.ReadByte * &H100
                                If value < 0 Or newData.Count > &H200 Then
                                    newData.Clear()
                                    newData.Add(0)
                                    newData.Add(0)
                                    Exit Do
                                End If
                                If value = 0 Then passed = True
                                If passed And (value = &HFFFF Or value = &HFFFE) Then count -= 1
                                If Not passed Then count += 1
                                newData.Add(value Mod &H100)
                                newData.Add(value \ &H100)
                                If passed And count = 0 Then Exit Do
                            Loop
                            objects.Add(New BossMonster(ptr, newData.ToArray()))
                            Debug.WriteLine("Tile animation size: " + newData.Count.ToString())
                        End If
                End Select
                s.Seek(curaddr + 4, IO.SeekOrigin.Begin)
            Else
                objects.Add(New BossMonster(ptr, s.ReadByte + s.ReadByte * &H100, s.ReadByte + s.ReadByte * &H100))
            End If
        Loop
        If import Then
            s.Seek(12, IO.SeekOrigin.Begin)
            s.Seek(s.ReadByte + s.ReadByte * &H100, IO.SeekOrigin.Begin)
        Else
            s.Seek(startAddr + 4, IO.SeekOrigin.Begin)
            Pointers.GoToPointer(s)
            ErrorLog.CheckError("Level has no background data.")
        End If
        For l As Integer = 0 To Width * Height - 1
            Tiles(l Mod Width, l \ Width) = (s.ReadByte() + s.ReadByte() * &H100) And &HFF
        Next
        If import Then
            GFX = New LevelGFX(romStream, spritePal)
        Else
            GFX = New LevelGFX(s, spritePal)
        End If
        s.Close()

        UpdateTileAnimation()
    End Sub

    Public Function GetWriteData() As LevelWriteData
        p1Start = New Point(objects.Victims(10).X + 8, objects.Victims(10).Y + 39)
        p2Start = New Point(objects.Victims(11).X + 16, objects.Victims(11).Y + 42)
        Dim file As New List(Of Byte)
        Dim addrOffsets(5) As Integer
        Dim bossPtrs As New List(Of Integer)
        file.AddRange(Pointers.ToArray(tileset.address))
        file.AddRange(New Byte() {0, 0, 0, 0})
        file.AddRange(Pointers.ToArray(tileset.collisionAddr))
        file.AddRange(Pointers.ToArray(tileset.gfxAddr))
        file.AddRange(Pointers.ToArray(tileset.paletteAddr))
        file.AddRange(Pointers.ToArray(spritePal))
        file.AddRange(Pointers.ToArray(tileset.pltAnimAddr))
        file.AddRange(New Byte() {0, 0, 0, 0, 0, 0, _
                                  Width Mod &H100, Width \ &H100, _
                                  Height Mod &H100, Height \ &H100, _
                                  unknown Mod &H100, unknown \ &H100, _
                                  unknown3 Mod &H100, unknown3 \ &H100, _
                                  p1Start.X Mod &H100, p1Start.X \ &H100, p1Start.Y Mod &H100, p1Start.Y \ &H100, _
                                  p2Start.X Mod &H100, p2Start.X \ &H100, p2Start.Y Mod &H100, p2Start.Y \ &H100, _
                                  music Mod &H100, music \ &H100, _
                                  sounds Mod &H100, sounds \ &H100, _
                                  0, 0, 0, 0, 0, 0})
        For Each m As BossMonster In objects.BossMonsters
            file.AddRange(Pointers.ToArray(m.ptr))
            file.AddRange(New Byte() {m.X Mod &H100, m.X \ &H100, m.Y Mod &H100, m.Y \ &H100})
        Next
        file.AddRange(New Byte() {0, 0, 0, 0})
        For Each m As BossMonster In objects.BossMonsters
            If Pointers.SpBossMonsters.Contains(m.ptr) Then
                bossPtrs.Add(file.Count)
                file.AddRange(m.exData)
            End If
        Next
        Dim x As UShort, y As UShort
        'Monster data
        addrOffsets(0) = file.Count
        For Each m As Monster In objects.Monsters
            x = m.X + Pointers.SpriteOffsets(m.index * 2)
            y = m.Y + Pointers.SpriteOffsets(m.index * 2 + 1)
            file.AddRange(New Byte() {m.delay, x Mod &H100, x \ &H100, y Mod &H100, y \ &H100, m.radius})
            file.AddRange(Pointers.ToArray(m.ptr))
        Next
        file.AddRange(New Byte() {0, 0})
        'Victim data
        addrOffsets(1) = file.Count
        For Each v As Victim In objects.Victims
            If v.ptr > 2 Then
                x = v.X + Pointers.SpriteOffsets(v.index * 2)
                y = v.Y + Pointers.SpriteOffsets(v.index * 2 + 1)
                Dim num As UShort = IIf(v.num = 10, 16, v.num)
                file.AddRange(New Byte() {x Mod &H100, x \ &H100, y Mod &H100, y \ &H100, v.unused Mod &H100, v.unused \ &H100, _
                                          num Mod &H100, num \ &H100})
                file.AddRange(Pointers.ToArray(v.ptr))
            End If
        Next
        'NRMonster data
        For Each m As NRMonster In objects.NRMonsters
            x = m.X + Pointers.SpriteOffsets(m.index * 2)
            y = m.Y + Pointers.SpriteOffsets(m.index * 2 + 1)
            file.AddRange(New Byte() {x Mod &H100, x \ &H100, y Mod &H100, y \ &H100, m.extra Mod &H100, m.extra \ &H100, _
                                      m.unused Mod &H100, m.unused \ &H100})
            file.AddRange(Pointers.ToArray(m.ptr))
        Next
        file.AddRange(New Byte() {0, 0})
        'Item data
        addrOffsets(2) = file.Count
        For Each i As Item In objects.Items
            x = i.X + 8
            y = i.Y + 8
            file.AddRange(New Byte() {x Mod &H100, x \ &H100, y Mod &H100, y \ &H100, i.Type * 2})
        Next
        file.AddRange(New Byte() {0, 0})
        'Level titles
        addrOffsets(3) = file.Count
        page1.Write(file, 1)
        addrOffsets(4) = file.Count
        page2.Write(file, 0)
        'Bonuses
        addrOffsets(5) = file.Count
        For Each b As Integer In bonuses
            file.AddRange(New Byte() {b Mod &H100, b \ &H100})
        Next
        file.AddRange(New Byte() {0, 0})
        Return New LevelWriteData(file, addrOffsets, bossPtrs)
    End Function

    Public Function ToFile() As Byte()
        Dim data As LevelWriteData = GetWriteData()
        Dim file(0) As Byte
        Dim fs As New ByteArrayStream(file)
        For l As Integer = 0 To 5
            fs.WriteByte(data.addrOffsets(l) Mod &H100)
            fs.WriteByte(data.addrOffsets(l) \ &H100)
        Next
        fs.WriteByte(0)
        fs.WriteByte(0)
        fs.Write(data.data, 0, data.data.Length)
        fs.Seek(12, IO.SeekOrigin.Begin)
        fs.WriteByte(fs.Length Mod &H100)
        fs.WriteByte(fs.Length \ &H100)
        fs.Seek(0, IO.SeekOrigin.End)
        For y As Integer = 0 To Height - 1
            For x As Integer = 0 To Width - 1
                fs.WriteByte(Tiles(x, y))
                fs.WriteByte(0)
            Next
        Next

        fs.Seek(14 + &H3C, IO.SeekOrigin.Begin)
        Dim tempptr As Integer
        Dim bossIndex As Integer = 0
        Do 'set pointers for special boss monsters
            tempptr = Pointers.ReadPointer(fs)
            If Pointers.SpBossMonsters.Contains(tempptr) And bossIndex < data.bossDataPtr.Count Then
                fs.WriteByte(data.bossDataPtr(bossIndex) Mod &H100)
                fs.WriteByte(data.bossDataPtr(bossIndex) \ &H100)
                fs.Seek(2, IO.SeekOrigin.Current)
                bossIndex += 1
            ElseIf tempptr = -1 Then
                Exit Do
            Else
                fs.Seek(4, IO.SeekOrigin.Current)
            End If
        Loop

        Return fs.array
    End Function

    Public Sub UpdateTileAnimation()
        If animation IsNot Nothing Then
            animation.Reset()
            animation = Nothing
        End If
        For Each boss As BossMonster In objects.BossMonsters
            If boss.Type = ZAMNEditor.Pointers.SpBossMonsters(1) Then
                animation = New TileAnimation(tileset, boss)
                Return
            End If
        Next
    End Sub
End Class
