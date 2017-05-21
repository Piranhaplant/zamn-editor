Public Class Pointers
    Public Const LevelPointers As Integer = &HF8000
    Public Const BonusLvlNums As Integer = &H1517E
    Public Const Passwords As Integer = &H1314A
    Public Const ItemGFX As Integer = &H32400
    Public Const TitlePalette As Integer = &H1F08C
    Public Const TitleGraphics As Integer = &H94F80
    Public Const TitleCharWidth As Integer = &H12F37
    Public Const TitleTileMap As Integer = &HB5641
    Public Const SpritePlt As Integer = &HF0F76
    Public Shared BossMonsters As Integer() = {&H1073C, &H11569, &H128BB, &H128C3, &H1AD33}
    Public Shared BossMonsterNames As String() = {"UFO", "Giant Baby", "Desert Snakeoid", "Grass Snakeoid", "Giant Spider"}
    Public Shared SpBossMonsters As Integer() = {&H12B95, &H157CF} 'Palette fade, Tile animation
    Public Shared SuggestTilesets As Integer() = {&HD8000, &HE36EF, &HDBCB5, &HD4000, &HE0000}
    Public Shared SpritePtrs As Integer() = {-1, &H19FE2, &H19776, &H19C6D, &H19E15, &H19D00, &H19699, &H1993D, &H19843, &H19A89, &H19EBE, &H19BAD, _
                                             &H16F36, &H983A, &HA455, &H1725D, &HD2F1, &HD2F9, &H1B55E, &H1B7F6, _
                                             &H87F8, &H88CA, &H8C17, &H8E89, &H8F1F, &H99DF, &H9A3E, &HABF5, &HB2B0, &HB664, &HC1FB, _
                                             &HC321, &HC3B6, &HC87B, &HCCCF, &HD704, &HE481, &HE51A, &H1190F, &H1B277, 1, 2}
    Public Shared SpriteOffsets As Integer() = {0, 0, 24, 47, 17, 29, 13, 38, 17, 38, 29, 40, 31, 63, 16, 47, 16, 29, 14, 32, 16, 37, 28, 44, _
                                                15, 48, 14, 46, 24, 63, 9, 31, 21, 31, 21, 31, 18, 42, 16, 48, _
                                                20, 47, 20, 47, 16, 55, 16, 35, 16, 35, 15, 44, 15, 44, 14, 65, 16, 31, 8, 15, 19, 21, _
                                                26, 26, 19, 21, 17, 34, 24, 30, 9, 22, 8, 16, 16, 32, 12, 16, 8, 12}
    'PLACEHOLDER, Tourist, Baby, Teacher, Explorer, Pool, Barbeque, Army, Trampoline, Dog, Cheerleader, Dr. Bug
    'Dracula, Chainsaw, Frankenstein, Fire, Plant, Plant 2, Dr. Tongue, Credit Level enemy head
    'Zombie, Fast Zombie, Mummy, Clone, Fast Clone, Martian, Martian, Werewolf, Chuckie, Fire guy, Hole Ant,
    ' Hiding Ant, Hole Red Ant, Football, Blob, Mushroom, Fast Squidman, Squidman, Tentacle, Spider

    Public Shared Tilesets As Integer() = {&HD8000, &HE36EF, &HD4000, &HE0000, &HDBCB5}
    Public Shared Palettes As Integer() = {&HF0E76, &HF1076, &HF1176, &HF1276, 0, _
                                    &HF1C76, &HF1D76, 0, 0, 0, _
                                    &HF1876, &HF1976, &HF1A76, &HF1B76, 0, _
                                    &HF1E76, &HF2076, &HF2176, &HF2276, &HF1F76, _
                                    &HF1476, &HF1576, &HF1676, &HF1776, 0}
    Public Shared PalNames As String() = {"Standard", "Fall", "Winter", "Night", "", _
                                   "Mall", "Factory", "", "", "", _
                                   "Standard", "Night", "Bright", "Dark", "", _
                                   "Office", "Light Office", "Dark Office", "Cave", "Dark Cave", _
                                   "Pyramid", "Beach", "Dark Beach", "Cave", ""}
    Public Shared Graphics As Integer() = {&HC0000, &HCC000, &HC8000, &HD0000, &HC4000}
    Public Shared Collision As Integer() = {&HDF4D1, &HE6EAB, &HE6AAB, &HE72AB, &HDF8D1}
    Public Shared Unknown As UShort() = {&H70US, &H69US, &H70US, &H57US, &H59US}
    Public Shared PltAnim As Integer() = {-1, &H20AD, &H20EF, &H2137, &H2222, &H2264}
    Public Shared Boss As Integer() = {-1, &H1072C, &H11569, &H128BB, &H128C3, &H12B95, &H157CF, &H1AD33}

    Public Const RAMStartBsnes As Integer = &H2A67
    Public Const RAMLevelNum As Integer = &H1E7C
    Public Const RAMWeaponQty As Integer = &H1CCC
    Public Const RAMStartingVictims As Integer = &H1D50
    Public Const RAMRemainingVictims As Integer = &H1D52

    Public Shared Function ReadPointer(ByVal s As IO.Stream) As Integer
        Dim part2 As Integer = s.ReadByte() + s.ReadByte() * &H100
        Dim Banknum As Integer = s.ReadByte()
        s.ReadByte()
        If Banknum < &H80 Or part2 < &H8000 Then
            Return -1
        End If
        Return (Banknum - &H80) * &H8000 + part2 - &H8000
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
        Dim part2 As Integer = arr(idx) + arr(idx + 1) * &H100
        Dim Banknum As Integer = arr(idx + 2)
        If Banknum < &H80 Or part2 < &H8000 Then
            Return -1
        End If
        Return (Banknum - &H80) * &H8000 + part2 - &H8000
    End Function

    Public Shared Function ReadRelativePointer(ByVal s As IO.Stream, ByVal bank As Byte) As Integer
        Dim part2 As Integer = s.ReadByte + s.ReadByte * &H100
        If bank < &H80 Or part2 < &H8000 Then
            Return -1
        End If
        Return (bank - &H80) * &H8000 + part2 - &H8000
    End Function

    Public Shared Sub GoToRelativePointer(ByVal s As IO.Stream, ByVal bank As Byte)
        Dim addr As Integer = ReadRelativePointer(s, bank)
        If addr = -1 Then
            ErrorLog.Report()
        Else
            s.Seek(addr, IO.SeekOrigin.Begin)
        End If
    End Sub

    Public Shared Function ToArray(ByVal address As Integer) As Byte()
        If address = 0 Or address = -1 Then
            Return New Byte() {0, 0, 0, 0}
        End If
        Dim bank As Integer = address \ &H8000
        Dim part2 As Integer = address - bank * &H8000 + &H8000
        Return New Byte() {part2 Mod &H100, part2 \ &H100, bank + &H80, 0}
    End Function
End Class
