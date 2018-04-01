Public Class Pointers
    Public Const LevelPointers As Integer = &H296B0 '+
    Public Const BonusLvlNums As Integer = &H9D7A '+
    Public Const Passwords As Integer = &H1314A '-
    Public Const ItemGFX As Integer = &H7DB84 '+
    Public Const TitlePalette As Integer = &H11018C '+
    Public Const TitleGraphics As Integer = &H95B5C '+
    Public Const TitleCharWidth As Integer = &H27D02 '+
    Public Const TitleTileMap As Integer = &H977E2 '+
    Public Const SpritePlt As Integer = &HE40AA '+
    Public Shared BossMonsters As Integer() = {&H2012A, &H2142A, &H23E14, &H23E1E, &H220E2} '+
    Public Shared BossMonsterNames As String() = {"UFO", "Giant Baby", "Desert Snakeoid", "Grass Snakeoid", "Giant Spider"}
    Public Shared SpBossMonsters As Integer() = {&H31DC, &H261E} '+'Palette fade, Tile animation'+
    Public Shared SuggestTilesets As Integer() = {&HD8000, &HE36EF, &HDBCB5, &HD4000, &HE0000}
    Public Shared SpritePtrs As Integer() = {-1, &H12B7E, &H11E44, &H12668, &H128EE, &H12748, &H11CF0, &H12164, &H11F7C, &H1236C, &H129EC, &H12550,
                                             &H1E91C, &H1ABB6, &H1DB98, &H1ADCA, &H1F1CC, &H1F1D6, &H22BFE, &H1F908,
                                             &H15296, &H1540C, &H15872, &H16C86, &H16D6C, &H162BE, &H16346, &H1614E, &H1861A, &H18B92, &H19C5E,
                                             &H19E10, &H19D34, &H174B6, &H17A8E, &H1B1A8, &H1CE4A, &H1CF32, &H1B698, &H227B8, 1, 2}
    Public Shared SpriteOffsets As Integer() = {0, 0, 24, 47, 17, 29, 13, 38, 17, 38, 29, 40, 31, 63, 16, 47, 16, 29, 14, 32, 16, 37, 28, 44,
                                                15, 48, 14, 46, 24, 63, 9, 31, 21, 31, 21, 31, 18, 42, 16, 48,
                                                20, 47, 20, 47, 16, 55, 16, 35, 16, 35, 15, 44, 15, 44, 14, 65, 16, 31, 8, 15, 19, 21,
                                                26, 26, 19, 21, 17, 34, 24, 30, 9, 22, 8, 16, 16, 32, 12, 16, 8, 12}
    'PLACEHOLDER, Tourist, Baby, Teacher, Explorer, Pool, Barbeque, Army, Trampoline, Dog, Cheerleader, Dr. Bug
    'Dracula, Chainsaw, Frankenstein, Fire, Plant, Plant 2, Dr. Tongue, Credit Level enemy head
    'Zombie, Fast Zombie, Mummy, Clone, Fast Clone, Martian, Martian, Werewolf, Chuckie, Fire guy, Hole Ant,
    ' Hiding Ant, Hole Red Ant, Football, Blob, Mushroom, Fast Squidman, Squidman, Tentacle, Spider


    Public Shared Musics As UShort() = {&H2, &H5, &H28, &H2A, &H2C, &H2D, &H2E, &H2F, &H6, &H3, &H1} '+
    Public Shared Tilesets As Integer() = {&HBB5A2, &HD36A2, &HCB5A2, &HDB6A2, &HC35A2} '+
    Public Shared Palettes As Integer() = {&HE40AA, &HE41B6, &HE422A, &HE4130, 0,'+
                                    &HE45E6, &HE466C, &HE3F9E, &HE3E8E, &HE3E08,
                                    &HE4454, &HE41B6, &HE4560, &HE44DA, &HE3CFC,
                                    &HE46F2, &HE4884, &HE4778, &HE490A, &HE47FE,
                                    &HE423C, &HE42C2, &HE4348, &HE43CE, &HE4024}
    Public Shared PalNames As String() = {"Standard", "Fall", "Winter", "Night", "",
                                   "Mall", "Factory", "Test1", "Test2", "Test3",
                                   "Standard", "Night", "Bright", "Dark", "Test5",
                                   "Office", "Light Office", "Dark Office", "Cave", "Dark Cave",
                                   "Pyramid", "Beach", "Dark Beach", "Cave", "Test"}
    Public Shared Graphics As Integer() = {&H9E07A, &HA514C, &HA2BA6, &HA7588, &HA05B8} '+Grass, Mall, Castle, Office, Beach
    Public Shared Collision As Integer() = {&HE36A2, &HE3A9C, &HE3950, &HE3BF0, &HE37F2} '+
    Public Shared Unknown As UShort() = {&H70US, &H69US, &H70US, &H57US, &H59US}
    Public Shared PltAnim As Integer() = {-1, &H3364, -1, &H3294, &H32FE, &H33BE} 'Castle, Grass, Beach, Pyramid, Fire Cave
    Public Shared Boss As Integer() = {-1, &H2012A, &H2142A, &H23E14, &H23E1E, &H31DC, &H261E, &H220E2} '+

    Public Const RAMStartBsnes As Integer = &H2A67
    Public Const RAMLevelNum As Integer = &H1E7C
    Public Const RAMWeaponQty As Integer = &H1CCC
    Public Const RAMStartingVictims As Integer = &H1D50
    Public Const RAMRemainingVictims As Integer = &H1D52

    Public Shared Function ReadPointer(ByVal s As IO.Stream) As Integer
        Return (s.ReadByte << 24) + (s.ReadByte << 16) + (s.ReadByte << 8) + s.ReadByte
    End Function

    Public Shared Sub GoToPointer(ByVal s As IO.Stream)
        Dim addr As Integer = ReadPointer(s)
        If addr = -1 Then
            ErrorLog.Report()
        Else
            s.Seek(addr, IO.SeekOrigin.Begin)
        End If
    End Sub

    Public Shared Function ToInteger(ByVal arr As Byte(), ByVal idx As Integer) As Integer
        Return (CInt(arr(idx)) << 24) + (CInt(arr(idx + 1)) << 16) + (CInt(arr(idx + 2)) << 8) + arr(idx + 3)
    End Function

    '    Public Shared Function ReadRelativePointer(ByVal s As IO.Stream, ByVal bank As Byte) As Integer
    '    Dim part2 As Integer = s.ReadByte + s.ReadByte * &H100
    '   If bank < &H80 Or part2 < &H8000 Then
    '    Return -1
    '   End If
    '   Return (bank - &H80) * &H8000 + part2 - &H8000
    '   End Function

    '    Public Shared Sub GoToRelativePointer(ByVal s As IO.Stream, ByVal bank As Byte)
    '   Dim addr As Integer = ReadRelativePointer(s, bank)
    '  If addr = -1 Then
    '         ErrorLog.Report()
    'Else
    '       s.Seek(addr, IO.SeekOrigin.Begin)
    'End If
    'End Sub

    Public Shared Function ToArray(ByVal address As Integer) As Byte()
        If address = 0 Or address = -1 Then
            Return New Byte() {0, 0, 0, 0}
        End If
        Dim b1 As Byte = (address >> 24) And &HFF
        Dim b2 As Byte = (address >> 16) And &HFF
        Dim b3 As Byte = (address >> 8) And &HFF
        Dim b4 As Byte = address And &HFF
        Return New Byte() {b1, b2, b3, b4}
    End Function
End Class
