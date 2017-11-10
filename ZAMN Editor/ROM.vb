Imports System.IO

Public Class ROM

    Public path As String
    Public regLvlCount As Integer
    Public maxLvlNum As Integer
    Public bonusLvls As New List(Of Integer)
    Public names As New Dictionary(Of Integer, String)
    Public failed As Boolean = False
    Public TitlePageGFX As TitleGFX

    Public hacked As Boolean = False

    Private Shared offsetPos As Integer() = {&H1C, &H1E, &H20, &H36, &H38, &H3A}

    Public Sub New(ByVal path As String)
#If Not Debug Then
        Try
#End If
        Me.path = path
        Dim s As New FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read)
        If HasHeader(s) Then
            RemoveHeader(s)
            MsgBox("This ROM had a header which was automatically removed")
        End If
        s.Seek(Pointers.LevelPointers, SeekOrigin.Begin)
        regLvlCount = s.ReadByte() + s.ReadByte() * &H100 - 1
        maxLvlNum = regLvlCount
        s.Seek(Pointers.BonusLvlNums, SeekOrigin.Begin)
        Dim num As Integer
        Dim curLvl As Integer = 0
        For l As Integer = 0 To maxLvlNum
            num = s.ReadByte() + s.ReadByte() * &H100
            If num <> 0 Then
                bonusLvls.Add(num)
                maxLvlNum = Math.Max(maxLvlNum, num)
            End If
            curLvl += 1
        Next
        TitlePageGFX = New TitleGFX(s)
        'Get level names
        Dim ptrs As DList(Of Integer, Integer) = GetAllLvlPtrs(s)
        For l As Integer = 0 To ptrs.L1.Count - 1
            Try
                names.Add(ptrs.L1(l), GetLevelTitle(s, ptrs.L2(l)))
            Catch ex As Exception
                names.Add(ptrs.L1(l), "ERROR: " & ex.Message)
            End Try
        Next

        'Testing 4 byte level pointers

        's.Seek(0, SeekOrigin.Begin)
        'If s.ReadByte <> 159 Then
        '    s.Seek(Pointers.LevelPointers + 2, SeekOrigin.Begin)
        '    Dim lenDiff As Integer = (maxLvlNum + 1) * 2
        '    InsertBytes(s, lenDiff)
        '    'Dim ptrs As DList(Of Integer, Integer) = GetAllLvlPtrs(s)
        '    s.Seek(Pointers.LevelPointers + 2, SeekOrigin.Begin)
        '    For l As Integer = 0 To maxLvlNum
        '        If ptrs.L1.IndexOf(l) > -1 Then
        '            s.Write(Pointers.ToArray(ptrs.FromSecond(l) + lenDiff), 0, 4)
        '            ptrs.L2(ptrs.L1.IndexOf(l)) += lenDiff
        '        Else
        '            s.Seek(4, SeekOrigin.Current)
        '        End If
        '    Next
        '    For l As Integer = 0 To ptrs.L1.Count - 1
        '        For m As Integer = 0 To offsetPos.Length - 1
        '            s.Seek(ptrs.L2(l) + offsetPos(m), SeekOrigin.Begin)
        '            Dim ptr As Integer = s.ReadByte + s.ReadByte * &H100 + lenDiff
        '            s.Seek(-2, SeekOrigin.Current)
        '            s.WriteByte(ptr Mod &H100)
        '            s.WriteByte(ptr \ &H100)
        '        Next
        '    Next
        '    'Apply the hack patch
        '    Dim patch As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ZAMNEditor.ROMExpand.ips")
        '    IPSPatcher.ApplyPatch(patch, s)
        '    patch.Close()

        '    s.Seek(0, SeekOrigin.Begin)
        '    s.WriteByte(159)
        'End If
        'hacked = True

        s.Close()
#If Not Debug Then
        Catch ex As Exception
            failed = True
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
#End If
    End Sub

    Public Shared Function HasHeader(ByVal s As IO.Stream) As Boolean
        Dim extraBytes As Integer = s.Length Mod &H8000L
        Return extraBytes = &H200
    End Function

    Public Shared Sub RemoveHeader(ByVal s As IO.Stream)
        Dim extraBytes As Integer = s.Length Mod &H8000L
        s.Seek(0, IO.SeekOrigin.Begin)
        InsertBytes(s, -extraBytes)
        s.SetLength(s.Length - extraBytes)
    End Sub

    Public Shared Sub InsertBytes(ByVal s As IO.Stream, ByVal byteCount As Integer)
        If byteCount < 0 Then
            s.Seek(-byteCount, IO.SeekOrigin.Current)
        End If
        Dim rest(s.Length - s.Position - 1) As Byte
        Dim start As Long = s.Position
        s.Read(rest, 0, rest.Length)
        s.Seek(start + byteCount, IO.SeekOrigin.Begin)
        s.Write(rest, 0, rest.Length)
    End Sub

    Public Function GetLevelTitle(ByVal s As Stream, ByVal ptr As Integer)
        s.Seek(ptr + &H36, SeekOrigin.Begin)
        Pointers.GoToRelativePointer(s, &H9F)
        Dim TP1 As New TitlePage(s)
        s.Seek(ptr + &H38, SeekOrigin.Begin)
        Pointers.GoToRelativePointer(s, &H9F)
        Dim TP2 As New TitlePage(s)
        Return TitlePage.FormatTitleString(TP1.ToString & " " & TP2.ToString)
    End Function

    Public Function GetLvlPtr(ByVal num As Integer, ByVal s As Stream) As Integer
        If hacked Then
            s.Seek(Pointers.LevelPointers + 2 + num * 4, SeekOrigin.Begin)
            Return Pointers.ReadPointer(s)
        Else
            s.Seek(Pointers.LevelPointers + 2 + num * 2, SeekOrigin.Begin)
            Return Pointers.ReadRelativePointer(s, &H9F)
        End If
    End Function

    Public Function GotoLvlPtr(ByVal num As Integer, ByVal s As Stream) As Integer
        s.Seek(GetLvlPtr(num, s), SeekOrigin.Begin)
    End Function

    Public Function GetLevel(ByVal num As Integer, ByVal name As String) As Level
        Dim s As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
        GotoLvlPtr(num, s)
        Dim l As New Level(s, name, num)
        s.Close()
        Return l
    End Function

    Public Function GetAllLvlPtrs(ByVal s As Stream) As DList(Of Integer, Integer)
        Dim ptrs As New DList(Of Integer, Integer)
        For l As Integer = 0 To regLvlCount
            ptrs.Add(l, GetLvlPtr(l, s))
        Next
        For Each num As Integer In bonusLvls
            ptrs.Add(num, GetLvlPtr(num, s))
        Next
        Return ptrs
    End Function

    Public Sub FixTileAnim()
        Dim s As New FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read)
        Dim ptrs As DList(Of Integer, Integer) = GetAllLvlPtrs(s)
        For Each ptr As Integer In ptrs.L2
            s.Seek(ptr, SeekOrigin.Begin)
            FixTileAnim(s)
        Next
        s.Close()
    End Sub

    Public Sub FixTileAnim(ByVal s As Stream)
        s.Seek(&H3C, SeekOrigin.Current)
        Dim mainPointerPos As Integer = -1
        Dim mainPointer As Integer
        Dim bossType As Integer = Pointers.ReadPointer(s)
        While bossType > 0
            If bossType = Pointers.SpBossMonsters(1) Then
                mainPointerPos = s.Position
                mainPointer = Pointers.ReadPointer(s)
            Else
                s.Seek(4, SeekOrigin.Current)
            End If
            bossType = Pointers.ReadPointer(s)
        End While
        If mainPointerPos > 0 Then
            'Dim mainPointer As Integer = s.Position
            's.Seek(mainPointerPos, SeekOrigin.Begin)
            's.Write(Pointers.ToArray(mainPointer), 0, 4)
            s.Seek(mainPointer, SeekOrigin.Begin)

            Dim subPointers As New List(Of Integer)
            Dim subPointer As Integer
            Dim subPointerCt As Integer = -1
            Do
                subPointerCt += 1
                subPointer = s.ReadByte() + s.ReadByte() * &H100
            Loop While subPointer > 0
            For i As Integer = 1 To subPointerCt
                subPointers.Add(s.Position)
                Dim value As Integer
                Do
                    value = s.ReadByte() + s.ReadByte() * &H100
                Loop While value < &HFFFE
            Next

            s.Seek(mainPointer, SeekOrigin.Begin)
            For Each p As Integer In subPointers
                p = p Mod &H10000
                s.WriteByte(p Mod &H100)
                s.WriteByte(p \ &H100)
            Next
        End If
    End Sub

    Public Sub SaveLevel(ByVal lvl As Level)
        Dim fs As FileStream
        Try
            fs = New FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read)
        Catch ex As Exception
            MsgBox("Error accessing ROM file." & Environment.NewLine & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Return
        End Try
        'Create a backup in case something goes wrong while saving
        Dim ROMSize As Long = fs.Length
        Dim backup(ROMSize - 1) As Byte
        fs.Read(backup, 0, ROMSize)
#If Not Debug Then
        Try
#End If
        Dim data As LevelWriteData = lvl.GetWriteData()
        'Dim fs2 As New FileStream(Application.StartupPath + "\lvl.bin", FileMode.Create)
        'fs2.Write(data.data, 0, data.data.Length)
        'fs2.Close()
        Dim ptrs As DList(Of Integer, Integer) = GetAllLvlPtrs(fs)
        ptrs.SortBySecond()
        Dim lvlPtr As Integer = GetLvlPtr(lvl.num, fs)
        fs.Seek(lvlPtr + 4, SeekOrigin.Begin) 'Get the pointer to the level background data
        Pointers.GoToPointer(fs)
        Dim SNESAddr As Byte() = Pointers.ToArray(fs.Position)
        data.data(4) = SNESAddr(0)
        data.data(5) = SNESAddr(1)
        data.data(6) = SNESAddr(2)
        For y As Integer = 0 To lvl.Height - 1
            For x As Integer = 0 To lvl.Width - 1
                fs.WriteByte(lvl.Tiles(x, y))
                fs.WriteByte(0)
            Next
        Next
        fs.Seek(lvlPtr, SeekOrigin.Begin)
        For l As Integer = 0 To 5
            SNESAddr = Pointers.ToArray(data.addrOffsets(l) + lvlPtr)
            data.data(offsetPos(l)) = SNESAddr(0)
            data.data(offsetPos(l) + 1) = SNESAddr(1)
        Next
        Dim lenDiff As Integer = 0
        If ptrs.L2.LastIndexOf(lvlPtr) < ptrs.L2.Count - 1 Then
            lenDiff = data.data.Length - (ptrs.L2(ptrs.L2.LastIndexOf(lvlPtr) + 1) - lvlPtr)
            InsertBytes(fs, lenDiff)
        End If
        fs.Seek(lvlPtr, SeekOrigin.Begin)
        fs.Write(data.data, 0, data.data.Length)
        fs.Seek(lvlPtr + &H3C, SeekOrigin.Begin)
        Dim tempptr As Integer
        Dim bossIndex As Integer = 0
        Do 'set pointers for special boss monsters
            tempptr = Pointers.ReadPointer(fs)
                If Pointers.SpBossMonsters.Contains(tempptr) And bossIndex < data.bossDataPtr.Count Then
                    fs.Write(Pointers.ToArray(data.bossDataPtr(bossIndex) + lvlPtr), 0, 4)
                    bossIndex += 1
                ElseIf tempptr = -1 Then
                    Exit Do
                Else
                    fs.Seek(4, SeekOrigin.Current)
                End If
            Loop
        'Hacky way to make sure the tile animations don't get messed up
        fs.Seek(lvlPtr, SeekOrigin.Begin)
        FixTileAnim(fs)
        Dim donePtrs As New List(Of Integer)
        For l As Integer = ptrs.L2.LastIndexOf(lvlPtr) + 1 To ptrs.L2.Count - 1 'update level pointers
            fs.Seek(Pointers.LevelPointers + 2 + ptrs.L1(l) * 2, SeekOrigin.Begin)
            Dim NewPtr As Integer = fs.ReadByte + fs.ReadByte * &H100 + lenDiff
            fs.Seek(-2, SeekOrigin.Current)
            fs.WriteByte(NewPtr Mod &H100)
            fs.WriteByte(NewPtr \ &H100)
            If Not donePtrs.Contains(NewPtr) Then
                donePtrs.Add(NewPtr)
                NewPtr += &HF0000
                fs.Seek(NewPtr, SeekOrigin.Begin)
                Dim NewPtr2 As Integer
                For m As Integer = 0 To 5 'Update pointers within level files
                    fs.Seek(NewPtr + offsetPos(m), SeekOrigin.Begin)
                    NewPtr2 = fs.ReadByte + fs.ReadByte * &H100 + lenDiff
                    If NewPtr2 > 0 And NewPtr2 > lenDiff Then
                        fs.Seek(-2, SeekOrigin.Current)
                        fs.WriteByte(NewPtr2 Mod &H100)
                        fs.WriteByte(NewPtr2 \ &H100)
                    End If
                Next
                fs.Seek(NewPtr + &H3C, SeekOrigin.Begin)
                Do 'Update special boss monsters
                    NewPtr2 = Pointers.ReadPointer(fs)
                    If Pointers.SpBossMonsters.Contains(NewPtr2) Then
                        Dim NewPtr3 As Integer = Pointers.ReadPointer(fs) + lenDiff
                        fs.Seek(-4, SeekOrigin.Current)
                        fs.Write(Pointers.ToArray(NewPtr3), 0, 4)
                        If NewPtr2 = Pointers.SpBossMonsters(1) And NewPtr3 > NewPtr Then 'Update the tile animation pointers
                            Dim prevPos As Integer = fs.Position
                            fs.Seek(NewPtr3, SeekOrigin.Begin)
                            NewPtr2 = fs.ReadByte + fs.ReadByte * &H100 + lenDiff
                            While NewPtr2 > 0 And NewPtr2 > lenDiff
                                fs.Seek(-2, SeekOrigin.Current)
                                fs.WriteByte(NewPtr2 Mod &H100)
                                fs.WriteByte(NewPtr2 \ &H100)
                                NewPtr2 = fs.ReadByte + fs.ReadByte * &H100 + lenDiff
                            End While
                            fs.Seek(prevPos, SeekOrigin.Begin)
                        End If
                    ElseIf NewPtr2 = -1 Then
                        Exit Do
                    Else
                        fs.Seek(4, SeekOrigin.Current)
                    End If
                Loop
            End If
        Next
        fs.SetLength(ROMSize)
        names(lvl.num) = GetLevelTitle(fs, lvlPtr)
        OpenLevel.SetName(lvl.num, names(lvl.num))
#If Not Debug Then
        Catch ex As Exception
            MsgBox("Error saving level." & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "Error")
            'Restore the backup
            fs.Seek(0, SeekOrigin.Begin)
            fs.Write(backup, 0, ROMSize)
        End Try
#End If
        fs.Close()
    End Sub
End Class
