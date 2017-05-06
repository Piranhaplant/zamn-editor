Public Class LevelSettings

    Public lvl As Level
    Public ed As Editor
    Private tileAnim As Byte() = Nothing

    Public Overloads Function ShowDialog(ByVal ed As Editor) As DialogResult
        Me.lvl = ed.EdControl.lvl
        Me.ed = ed
        'Tiles
        addrTiles.Value = lvl.tileset.address
        cboTiles.SelectedIndex = Array.IndexOf(Pointers.Tilesets, lvl.tileset.address)
        If cboTiles.SelectedIndex <> -1 Then
            radTilesAuto.Checked = True
        Else
            radTilesMan.Checked = True
        End If
        'Palette
        addrPal.Value = lvl.tileset.paletteAddr
        UpdatePals()
        Dim palIdx As Integer = Array.IndexOf(Pointers.Palettes, lvl.tileset.paletteAddr)
        If palIdx >= cboTiles.SelectedIndex * 5 And palIdx <= cboTiles.SelectedIndex * 5 + 4 Then
            cboPal.SelectedIndex = palIdx Mod 5
        End If
        If cboPal.Items.Count > 0 And cboPal.SelectedIndex > -1 Then
            radPalAuto.Checked = True
        Else
            radPalMan.Checked = True
        End If
        'Graphics
        addrGFX.Value = lvl.tileset.gfxAddr
        If Array.IndexOf(Pointers.Graphics, lvl.tileset.gfxAddr) = cboTiles.SelectedIndex Then
            radGFXAuto.Checked = True
        Else
            radGFXMan.Checked = True
        End If
        'Collision
        addrCol.Value = lvl.tileset.collisionAddr
        If Array.IndexOf(Pointers.Collision, lvl.tileset.collisionAddr) = cboTiles.SelectedIndex Then
            radColAuto.Checked = True
        Else
            radColMan.Checked = True
        End If
        'Unknown
        nudUnk.Value = lvl.unknown
        If Array.IndexOf(Pointers.Unknown, lvl.unknown) = cboTiles.SelectedIndex Or Array.LastIndexOf(Pointers.Unknown, lvl.unknown) = cboTiles.SelectedIndex Then
            radUnkAuto.Checked = True
        Else
            radUnkMan.Checked = True
        End If
        'Sprite palette
        addrSPal.Value = lvl.spritePal
        If lvl.spritePal = Pointers.SpritePlt Then
            radSPalAuto.Checked = True
        Else
            radSPalMan.Checked = True
        End If
        'Palette Animation
        addrPAnim.Value = lvl.tileset.pltAnimAddr
        cboPltAnim.SelectedIndex = Array.IndexOf(Pointers.PltAnim, lvl.tileset.pltAnimAddr)
        If cboPltAnim.SelectedIndex <> -1 Then
            radPAnimAuto.Checked = True
        Else
            radPAnimMan.Checked = True
        End If
        'Music
        nudMusic.Value = lvl.music
        If lvl.music >= 2 And lvl.music <= 11 Then
            cboMusic.SelectedIndex = lvl.music - 2
        End If
        If cboMusic.SelectedIndex <> -1 Then
            radMusicAuto.Checked = True
        Else
            radMusicMan.Checked = True
        End If
        'Sounds
        nudSounds.Value = lvl.sounds
        If lvl.sounds < cboSounds.Items.Count Then
            cboSounds.SelectedIndex = lvl.sounds
            radSoundsAuto.Checked = True
        Else
            radSoundsMan.Checked = True
        End If
        'Unknown3
        nudUnk3.Value = lvl.unknown3
        If lvl.unknown3 = &H1FF Then
            radUnk3Auto.Checked = True
        Else
            radUnk3Man.Checked = True
        End If
        'Bonuses
        lvl.bonuses.Sort()
        lstCustomBonuses.Items.Clear()
        For l As Integer = 0 To lstBonuses.Items.Count - 1
            lstBonuses.SetItemChecked(l, False)
        Next
        For Each b As Integer In lvl.bonuses
            If b >= 4 And b <= 32 And b Mod 2 = 0 Then
                lstBonuses.SetItemChecked(b \ 2 - 2, True)
            Else
                lstCustomBonuses.Items.Add(Hex(b))
            End If
        Next
        chkPltFade.Checked = False
        For Each m As BossMonster In lvl.objects.BossMonsters
            'Palette fade
            If m.ptr = Pointers.SpBossMonsters(0) Then
                chkPltFade.Checked = True
                addrPalF.Value = m.GetBGPalette
                palIdx = Array.IndexOf(Pointers.Palettes, addrPalF.Value)
                If palIdx >= cboTiles.SelectedIndex * 5 And palIdx <= cboTiles.SelectedIndex * 5 + 4 Then
                    cboPalF.SelectedIndex = If((palIdx Mod 5) >= cboPalF.Items.Count, -1, palIdx Mod 5)
                End If
                If cboPalF.Items.Count > 0 And cboPalF.SelectedIndex > -1 Then
                    radPalAutoF.Checked = True
                Else
                    radPalManF.Checked = True
                End If
                addrSPalF.Value = m.GetSpritePalette
                If addrSPalF.Value = Pointers.SpritePlt Then
                    radSPalAutoF.Checked = True
                Else
                    radSPalManF.Checked = True
                End If
            End If
            'Tile Animation
            If m.ptr = Pointers.SpBossMonsters(1) Then
                btnDeleteTileAnim.Enabled = True
                btnExportTileAnim.Enabled = True
                tileAnim = m.exData
            End If
        Next

        Return Me.ShowDialog()
    End Function

    Private Sub UpdatePals()
        cboPal.Items.Clear()
        cboPalF.Items.Clear()
        If cboTiles.SelectedIndex = -1 Then Return
        Dim startIdx As Integer = cboTiles.SelectedIndex * 5
        For l As Integer = startIdx To startIdx + 4
            If Pointers.Palettes(l) <> 0 Then
                cboPal.Items.Add(Pointers.PalNames(l))
                cboPalF.Items.Add(Pointers.PalNames(l))
            End If
        Next
    End Sub

    Private Sub radAuto_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radColAuto.CheckedChanged, radPalAutoF.CheckedChanged, _
        radGFXAuto.CheckedChanged, radMusicAuto.CheckedChanged, radPalAuto.CheckedChanged, radSPalAuto.CheckedChanged, radPAnimAuto.CheckedChanged, _
        radTilesAuto.CheckedChanged, radSoundsAuto.CheckedChanged, radUnk3Auto.CheckedChanged, radUnkAuto.CheckedChanged, radSPalAutoF.CheckedChanged
        Dim rad As Control = sender
        For Each ctrl As Control In rad.Parent.Controls
            If TypeOf ctrl Is AddressUpDown Or TypeOf ctrl Is NumericUpDown Then
                ctrl.Enabled = False
            End If
            If TypeOf ctrl Is ComboBox Then
                ctrl.Enabled = True
            End If
        Next
        'Update values
        If cboTiles.SelectedIndex > -1 Then
            If radTilesAuto.Checked Then addrTiles.Value = Pointers.Tilesets(cboTiles.SelectedIndex)
            If cboPal.SelectedIndex > -1 And radPalAuto.Checked Then addrPal.Value = Pointers.Palettes(cboTiles.SelectedIndex * 5 + cboPal.SelectedIndex)
            If radGFXAuto.Checked Then addrGFX.Value = Pointers.Graphics(cboTiles.SelectedIndex)
            If radColAuto.Checked Then addrCol.Value = Pointers.Collision(cboTiles.SelectedIndex)
            If radUnkAuto.Checked Then nudUnk.Value = Pointers.Unknown(cboTiles.SelectedIndex)
            If cboPalF.SelectedIndex > -1 And radPalAutoF.Checked Then addrPalF.Value = Pointers.Palettes(cboTiles.SelectedIndex * 5 + cboPalF.SelectedIndex)
        End If
        If radSPalAuto.Checked Then addrSPal.Value = Pointers.SpritePlt
        If cboPltAnim.SelectedIndex > -1 And radPAnimAuto.Checked Then addrPAnim.Value = Pointers.PltAnim(cboPltAnim.SelectedIndex)
        If cboMusic.SelectedIndex > -1 And radMusicAuto.Checked Then nudMusic.Value = cboMusic.SelectedIndex + 2
        If cboSounds.SelectedIndex > -1 And radSoundsAuto.Checked Then nudSounds.Value = cboSounds.SelectedIndex
        If radUnk3Auto.Checked Then nudUnk3.Value = 511
        If radSPalAutoF.Checked Then addrSPalF.Value = Pointers.SpritePlt
    End Sub

    Private Sub radMan_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radColMan.CheckedChanged, radPalManF.CheckedChanged, _
        radGFXMan.CheckedChanged, radMusicMan.CheckedChanged, radPalMan.CheckedChanged, radPAnimMan.CheckedChanged, radSPalMan.CheckedChanged, _
        radTilesMan.CheckedChanged, radSoundsMan.CheckedChanged, radUnk3Man.CheckedChanged, radUnkMan.CheckedChanged, radSPalManF.CheckedChanged
        Dim rad As Control = sender
        For Each ctrl As Control In rad.Parent.Controls
            If TypeOf ctrl Is ComboBox Then
                ctrl.Enabled = False
            End If
            If TypeOf ctrl Is AddressUpDown Or TypeOf ctrl Is NumericUpDown Then
                ctrl.Enabled = True
            End If
        Next
    End Sub

    Private Sub cboMusic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMusic.SelectedIndexChanged
        If cboMusic.SelectedIndex = -1 Then Return
        nudMusic.Value = cboMusic.SelectedIndex + 2
    End Sub

    Private Sub cboSounds_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSounds.SelectedIndexChanged
        If cboSounds.SelectedIndex = -1 Then Return
        nudSounds.Value = cboSounds.SelectedIndex
    End Sub

    Private Sub cboPal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPal.SelectedIndexChanged
        If cboPal.SelectedIndex = -1 Then Return
        addrPal.Value = Pointers.Palettes(cboTiles.SelectedIndex * 5 + cboPal.SelectedIndex)
    End Sub

    Private Sub cboPalF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPalF.SelectedIndexChanged
        If cboPalF.SelectedIndex = -1 Then Return
        addrPalF.Value = Pointers.Palettes(cboTiles.SelectedIndex * 5 + cboPalF.SelectedIndex)
    End Sub

    Private Sub cboPltAnim_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPltAnim.SelectedIndexChanged
        If cboPltAnim.SelectedIndex = -1 Then Return
        addrPAnim.Value = Pointers.PltAnim(cboPltAnim.SelectedIndex)
    End Sub

    Private Sub cboTiles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTiles.SelectedIndexChanged
        If cboTiles.SelectedIndex = -1 Then Return
        If radGFXAuto.Checked Then addrGFX.Value = Pointers.Graphics(cboTiles.SelectedIndex)
        If radColAuto.Checked Then addrCol.Value = Pointers.Collision(cboTiles.SelectedIndex)
        If radUnkAuto.Checked Then nudUnk.Value = Pointers.Unknown(cboTiles.SelectedIndex)
        UpdatePals()
        If radPalMan.Checked = True Then Return
        cboPal.SelectedIndex = 0
        addrTiles.Value = Pointers.Tilesets(cboTiles.SelectedIndex)
    End Sub

    Private Sub chkPltFade_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPltFade.CheckedChanged
        grpPltFade.Enabled = chkPltFade.Checked
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim reloadTileset As Boolean = False
        Dim reloadSprites As Boolean = False
        If lvl.tileset.address <> addrTiles.Value Or lvl.tileset.paletteAddr <> addrPal.Value Or lvl.tileset.gfxAddr <> addrGFX.Value Or lvl.tileset.collisionAddr <> addrCol.Value Then
            reloadTileset = True
        End If
        If lvl.spritePal <> addrSPal.Value Then
            reloadSprites = True
        End If
        lvl.tileset.address = addrTiles.Value
        lvl.tileset.paletteAddr = addrPal.Value
        lvl.tileset.gfxAddr = addrGFX.Value
        lvl.tileset.collisionAddr = addrCol.Value
        lvl.unknown = nudUnk.Value
        lvl.spritePal = addrSPal.Value
        lvl.tileset.pltAnimAddr = addrPAnim.Value
        If cboPltAnim.SelectedIndex = 0 And radPAnimAuto.Checked Then lvl.tileset.pltAnimAddr = -1
        lvl.music = nudMusic.Value
        lvl.sounds = nudSounds.Value
        lvl.unknown3 = nudUnk3.Value
        lvl.bonuses.Clear()
        For l As Integer = 0 To lstBonuses.Items.Count - 1
            If lstBonuses.GetItemChecked(l) Then
                lvl.bonuses.Add(l * 2 + 4)
            End If
        Next
        For Each i As String In lstCustomBonuses.Items
            lvl.bonuses.Add(CInt("&H" & i))
        Next
        Dim m As Integer = 0
        Do Until m = lvl.objects.BossMonsters.Count
            If lvl.objects.BossMonsters(m).ptr = Pointers.SpBossMonsters(0) Then
                lvl.objects.BossMonsters.RemoveAt(m)
            ElseIf lvl.objects.BossMonsters(m).ptr = Pointers.SpBossMonsters(1) Then
                lvl.objects.BossMonsters.RemoveAt(m)
            Else
                m += 1
            End If
        Loop
        If chkPltFade.Checked Then
            Dim exData(7) As Byte
            Array.Copy(Pointers.ToArray(addrPalF.Value), 0, exData, 0, 4)
            Array.Copy(Pointers.ToArray(addrSPalF.Value), 0, exData, 4, 4)
            lvl.objects.BossMonsters.Add(New BossMonster(Pointers.SpBossMonsters(0), exData))
        End If
        If tileAnim IsNot Nothing Then
            lvl.objects.BossMonsters.Add(New BossMonster(Pointers.SpBossMonsters(1), tileAnim))
        End If
        lvl.UpdateTileAnimation()

        If reloadTileset Then
            Dim s As New IO.FileStream(ed.r.path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            lvl.tileset.Reload(s)
            ed.EdControl.TilePicker.LoadTileset(ed.EdControl.lvl.tileset)
            s.Close()
        End If
        If reloadSprites Then
            Dim s As New IO.FileStream(ed.r.path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            lvl.GFX.Reload(s, lvl.spritePal)
            s.Close()
        End If
        ed.EdControl.UndoMgr.ForceDirty()
        ed.EdControl.Repaint()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        btnApply_Click(sender, e)
        Me.Close()
    End Sub

    Private Sub btnAddBonus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBonus.Click
        If Not lstCustomBonuses.Items.Contains(Hex(nudCustBonus.Value)) And Not (nudCustBonus.Value >= 4 And nudCustBonus.Value <= 32 And nudCustBonus.Value Mod 2 = 0) Then
            lstCustomBonuses.Items.Add(Hex(nudCustBonus.Value))
        End If
    End Sub

    Private Sub btnDeleteBonus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBonus.Click
        Dim items As New List(Of String)
        For Each i As String In lstCustomBonuses.SelectedItems
            items.Add(i)
        Next
        For Each i As String In items
            lstCustomBonuses.Items.Remove(i)
        Next
    End Sub

    Private Sub btnDeleteTileAnim_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteTileAnim.Click
        btnDeleteTileAnim.Enabled = False
        btnExportTileAnim.Enabled = False
        tileAnim = Nothing
    End Sub

    Private Sub btnExportTileAnim_Click(sender As System.Object, e As System.EventArgs) Handles btnExportTileAnim.Click
        If saveTileAnim.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For i As Integer = 0 To tileAnim.Length - 2 Step 2
                If tileAnim(i) = 0 And tileAnim(i + 1) = 0 Then
                    Try
                        Dim fs As New IO.FileStream(saveTileAnim.FileName, IO.FileMode.Create, IO.FileAccess.Write)
                        fs.Write(tileAnim, i + 2, tileAnim.Length - (i + 2))
                        fs.Close()
                    Catch ex As Exception
                        MsgBox("Failed to export:" & Environment.NewLine & ex.Message)
                    End Try
                    Return
                End If
            Next
            MsgBox("Tile animation was empty so nothing was exported.")
        End If
    End Sub

    Dim tileAnimPresets As String() = {"d9010700f9000700e0000700d901ffffd1010700d301070075010700d101ffffcb010700de0107008e010700cb01ffffa80107008d010700a3010700a801ffff", _
                                       "d9010700f9000700e0000700d901ffffe5010700e6010700d2010700e501ffffde0107008e010700cb010700de01ffffdd010700be010700dd01ffffed010700ee010700ef010700ed01ffff", _
                                       "2301640021012900230109002301ffff22016700f3002700220108002201ffff1f006a00560003007b001e00560003001f0008001f00ffff54006d0056001e0054000b005400ffff34016400550032003401ffff", _
                                       "c501030065005000c6010300cb010300c5010300c6010300cc010300cb010300c5010300c6010300cc010300c601ffffc801030065003c00c8010300c9010300c8010300c9010300c8010300c9010300c8010300c9010300c8010300c901ffffc701030065005000c7011b00c701ffffc901030066013c00c9010300c8010300c9010300c8010300c9010300c8010300c9010300c8010300c9010300c801ffffcc01030065000300cb010300c5010300c6010300cc010300cb010300c5010300c601030065006400cb010300cc01ffffcd011b0065006400cd010300cd01ffff", _
                                       "c0015a00c3010500c4010500e5015a00c4010500c3010500c0016400c001ffffc1015a00c4010500c3010500c1016400c1015a00c3010500c4010500e501ffffc2016400c2015a00c3010500c4010500e5015a00c4010500c3010500c201ffff5e0064005e006400180064001800ffff5f006400180064005f0064001800ffff", _
                                       "c0015a00c3010500c4010500e5015a00c4010500c3010500c0016400c001ffffc1015a00c4010500c3010500c1012800c1012800c3010500c4010500e501ffffc2016400c2015a00c3010500c4010500e5015a00c4010500c3010500c201ffff5e0064005e006400180064001800ffff5f006400180064005f0064001800ffff", _
                                       "f301bc02ff01f401fd01c800f801fefff401d007fc018e01f901fefff501ed0afd016400fa01fefff6011c0cfb01feff7400860bff013200fd01c800fc01fefff701480dff01feff", _
                                       "f301c409ff019808fd01c800f801fefff401d80efc014a04f901fefff501f511fd012c01fa01fefff6012413fb01feff74008e12ff01c800fd01c800fc01fefff7015014ff01feff", _
                                       "f301e40cff019808fd01c800f801fefff401f811fc014a04f901fefff5011515fd012c01fa01fefff6014416fb01feff7400ae15ff01c800fd01c800fc01fefff7017017ff01feff"}

    Private Sub btnPresetTileAnim_Click(sender As System.Object, e As System.EventArgs) Handles btnPresetTileAnim.Click
        If cboTileAnim.SelectedIndex > -1 Then
            Dim preset As String = tileAnimPresets(cboTileAnim.SelectedIndex)
            Dim presetArray(preset.Length \ 2 - 1) As Byte
            For i As Integer = 0 To presetArray.Length - 1
                presetArray(i) = CByte("&H" & preset.Substring(i * 2, 2))
            Next
            UseTileAnim(presetArray)
            cboTileAnim.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnImportTileAnim_Click(sender As System.Object, e As System.EventArgs) Handles btnImportTileAnim.Click
        If openTileAnim.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                Dim data As Byte() = IO.File.ReadAllBytes(openTileAnim.FileName)
                UseTileAnim(data)
            Catch ex As Exception
                MsgBox("Failed to import:" & Environment.NewLine & ex.Message)
            End Try
        End If
    End Sub

    Private Sub UseTileAnim(ByVal data As Byte())
        Dim count As Integer = 0
        For i As Integer = 0 To data.Length - 2 Step 2
            If data(i) + data(i + 1) * &H100 >= &HFFFE Then
                count += 1
            End If
        Next
        tileAnim = New Byte(count * 2 + 2 + data.Length - 1) {}
        For i As Integer = 0 To count - 1
            tileAnim(i * 2) = &H11 'Any value other than 0 would work here
            tileAnim(i * 2 + 1) = &H11
        Next
        tileAnim(count * 2) = 0
        tileAnim(count * 2 + 1) = 0
        Array.Copy(data, 0, tileAnim, count * 2 + 2, data.Length)

        btnDeleteTileAnim.Enabled = True
        btnExportTileAnim.Enabled = True
    End Sub
End Class
