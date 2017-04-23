Public Class Editor

    Public r As ROM
    Public EdControl As LvlEdCtrl
    Public CurTool As Tool
    Public PTool As Tool
    Public WithEvents TilePaste As PasteTilesTool
    Public zoomLevel As Single = 1
    Public openLevels As New List(Of Integer)
    Private updateTab As Boolean = True
    Private EditingTools As Tool()
    Private LevelItems As ToolStripItem()

    Private Sub Editor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Settings.Initialized Then
            Me.Location = My.Settings.Location
            Me.Size = My.Settings.Size
            If My.Settings.Maximized Then
                Me.WindowState = FormWindowState.Maximized
            End If
        End If
        EditingTools = New Tool() {New PaintbrushTool(Me), New TileSuggestTool(Me), New RectangleSelectTool(Me), New PencilSelectTool(Me), _
                                   New TileSelectTool(Me), New ItemTool(Me), New VictimTool(Me), New NRMonsterTool(Me), New MonsterTool(Me), New BossMonsterTool(Me),
                                   New SpriteTool(Me)}
        LevelItems = New ToolStripItem() {FileSave, SaveTool, EditPaste, PasteTool, EditSelectAll, EditSelectNone, ViewGrid, ViewNextFrame, ViewRestartAnimation, _
                                          ViewPriority, LevelExport, LevelImport, LevelCopy, LevelPaste, LevelEditTitle, LevelSettingsM, LevelSaveAsPNG}
        TilePaste = New PasteTilesTool(Me)
        TileSuggestList.LoadAll()
        If My.Settings.RecentROMs <> "" Then
            RecentROMs.Items = StringToList(My.Settings.RecentROMs)
        End If
        If My.Application.CommandLineArgs.Count > 0 Then
            LoadROM(My.Application.CommandLineArgs(0))
        End If
        ViewAnimate.Checked = My.Settings.Animate
    End Sub

    Private Sub Editor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If SaveMsgBox.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Editor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Settings.Initialized = True
        If Me.WindowState = FormWindowState.Maximized Then
            My.Settings.Maximized = True
            My.Settings.Location = Me.RestoreBounds.Location
            My.Settings.Size = Me.RestoreBounds.Size
        Else
            My.Settings.Maximized = False
            My.Settings.Location = Me.Location
            My.Settings.Size = Me.Size
        End If
        My.Settings.RecentROMs = ListToString(RecentROMs.Items)
    End Sub

    Private Sub FileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileOpen.Click, OpenTool.Click
        If OpenROM.ShowDialog = DialogResult.OK Then
            RecentROMs.Add(OpenROM.FileName)
            LoadROM(OpenROM.FileName)
        End If
    End Sub

    Private Sub RecentROMs_ItemClicked(ByVal sender As Object, ByVal e As ItemClickedEventArgs) Handles RecentROMs.ItemClicked
        LoadROM(e.Text)
    End Sub

    Public Sub LoadROM(ByVal path As String)
        If SaveMsgBox.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If
#If DEBUG Then
        LevelDebugTools.Visible = True
#End If
        r = New ROM(path)
        If r.failed Then Return
        FileOpenLevel.Enabled = True
        OpenLevelTool.Enabled = True
        EditPasswords.Enabled = True
        EmulatorRunROM.Enabled = (My.Settings.Emulator <> "")
        OpenLevel.LoadROM(r)
        Tabs.CloseAll()
    End Sub

    Private Sub FileOpenLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileOpenLevel.Click, OpenLevelTool.Click
        Dim levelOpened As Boolean = False
        If OpenLevel.ShowDialog = DialogResult.OK Then
            LoadingLevel.Start(r, OpenLevel.levelNums, OpenLevel.levelNames)
            For Each l As Level In LoadingLevel.lvls
                If Not openLevels.Contains(l.num) Then
                    levelOpened = True
                    EdControl = New LvlEdCtrl
                    updateTab = False
                    Dim tp As TabPage = Tabs.AddXPage(If(l.name.StartsWith("Level"), Mid(l.name, 1, InStrN(l.name, " ", 2) - 2), _
                                                      If(l.name.StartsWith("ERROR:"), "ERROR", l.name)))
                    tp.Controls.Add(EdControl)
                    EdControl.Dock = DockStyle.Fill
                    EdControl.LoadLevel(l)
                    EdControl.UndoMgr = New UndoManager(UndoTool, RedoTool, EdControl)
                    EdControl.Animate = ViewAnimate.Checked
                    'Receive keypresses used for special shortcut keys
                    AddHandler EdControl.canvas.KeyDown, AddressOf LvlEdCtrl_canvas_KeyDown
                    UndoTool.Enabled = False
                    RedoTool.Enabled = False
                    UndoTool.DropDownItems.Clear()
                    RedoTool.DropDownItems.Clear()
                    openLevels.Add(l.num)
                End If
            Next
            If levelOpened Then
                SetTool(CurTool)
                UpdateEdControl()
                updateTab = True
                TSContainer.ContentPanel.BackColor = SystemColors.Control
                For Each item As ToolStripItem In LevelItems
                    item.Enabled = True
                Next
                EmulatorFromLevel.Enabled = EmulatorRunROM.Enabled
                Tabs.Visible = True
                EdControl.Focus()
            End If
        End If
    End Sub

    Private Sub FileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileSave.Click, SaveTool.Click
        r.SaveLevel(EdControl.lvl)
        EdControl.UndoMgr.Clean()
    End Sub

    Private Sub FileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileExit.Click
        Me.Close()
    End Sub

    Private Sub EmulatorRunROM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmulatorRunROM.Click
        Process.Start(My.Settings.Emulator, """" & r.path & """")
    End Sub

    Private Sub EmulatorFromLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmulatorFromLevel.Click
        Dim emuName As String = LCase(Mid(My.Settings.Emulator, InStrRev(My.Settings.Emulator, "\") + 1))
        Dim outputFile As String = Mid(r.path, 1, InStrRev(r.path, ".") - 1)
        If emuName.Contains("bsnes") Then
            If SaveStateEditor.ShowDialog(EdControl.lvl, My.Resources.BSNES, Pointers.RAMStartBsnes, outputFile & "-1.bst") = Windows.Forms.DialogResult.OK Then
                EmulatorRunROM_Click(sender, e)
            End If
        Else
            MsgBox("Save state generation is only supported for bsnes v084.")
        End If
    End Sub

    Private Sub EmulatorSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmulatorSetup.Click
        If OpenEmulator.ShowDialog() = Windows.Forms.DialogResult.OK Then
            My.Settings.Emulator = OpenEmulator.FileName
            EmulatorRunROM.Enabled = r IsNot Nothing
            EmulatorFromLevel.Enabled = Tabs.tabctrl.TabCount > 0
        End If
    End Sub

    Private Sub EditUndo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditUndo.Click
        UndoTool.PerformButtonClick()
    End Sub

    Private Sub EditRedo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditRedo.Click
        RedoTool.PerformButtonClick()
    End Sub

    Private Sub UndoTool_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UndoTool.EnabledChanged
        EditUndo.Enabled = UndoTool.Enabled
    End Sub

    Private Sub RedoTool_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RedoTool.EnabledChanged
        EditRedo.Enabled = RedoTool.Enabled
    End Sub

    Private Sub EditCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditCopy.Click, CopyTool.Click
        If EdControl Is Nothing Then Return
        If CurTool.Copy() Then
            Clipboard.SetText(ZAMNClip.ToClip(CopyTiles()))
        End If
    End Sub

    Private Sub EditCut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditCut.Click, CutTool.Click
        If EdControl Is Nothing Then Return
        If CurTool.Cut() Then
            Clipboard.SetText(ZAMNClip.ToClip(CopyTiles()))
        End If
        EdControl.Repaint()
    End Sub

    Private Sub EditPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditPaste.Click, PasteTool.Click
        If EdControl Is Nothing Or CurTool Is Nothing Then Return
        If Not ZAMNClip.IsClip(Clipboard.GetText) Then Return
        If CurTool.Paste() Then
            PTool = CurTool
            SetTool(TilePaste)
            CurTool.Paste()
        End If
        EdControl.Repaint()
    End Sub

    Private Sub TilePaste_DonePasting(ByVal sender As Object, ByVal e As System.EventArgs) Handles TilePaste.DonePasting
        SetTool(PTool)
    End Sub

    Private Sub EditSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSelectAll.Click
        If CurTool Is Nothing Then Return
        If CurTool.SelectAll(True) Then
            SelectAll(True)
        End If
        SetCopy(CurTool.CanCopy())
        EdControl.Repaint()
    End Sub

    Private Sub EditSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSelectNone.Click
        If CurTool Is Nothing Then Return
        If CurTool.SelectAll(False) Then
            SelectAll(False)
        End If
        SetCopy(False)
        EdControl.Repaint()
    End Sub

    Private Sub EditPasswords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPasswords.Click
        PasswordEditor.ShowDialog(Me)
    End Sub

    Public Sub SelectAll(ByVal selected As Boolean)
        For m As Integer = 0 To EdControl.lvl.Height - 1
            For l As Integer = 0 To EdControl.lvl.Width - 1
                EdControl.selection.selectPts(l, m) = selected
            Next
        Next
        EdControl.selection.exists = selected
        EdControl.selection.Refresh()
        EdControl.UpdateSelection()
        SetCopy(selected)
    End Sub

    Private Sub ViewGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewGrid.Click
        EdControl.Grid = ViewGrid.Checked
        EdControl.Focus()
        EdControl.Repaint()
    End Sub

    Private Sub ViewPriority_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewPriority.Click
        UpdateEdControl()
        EdControl.TilePicker.Invalidate(True)
    End Sub

    Private Sub ViewAnimate_Click(sender As System.Object, e As System.EventArgs) Handles ViewAnimate.Click
        My.Settings.Animate = ViewAnimate.Checked
        If EdControl IsNot Nothing Then
            EdControl.Animate = ViewAnimate.Checked
        End If
    End Sub

    Private Sub ViewNextFrame_Click(sender As System.Object, e As System.EventArgs) Handles ViewNextFrame.Click
        If EdControl.lvl.animation IsNot Nothing Then
            EdControl.lvl.animation.NextFrame()
            UpdateEdControl()
            EdControl.TilePicker.Invalidate(True)
        End If
    End Sub

    Private Sub ViewRestartAnimation_Click(sender As System.Object, e As System.EventArgs) Handles ViewRestartAnimation.Click
        If EdControl.lvl.animation IsNot Nothing Then
            EdControl.lvl.animation.Reset()
            UpdateEdControl()
            EdControl.TilePicker.Invalidate(True)
        End If
    End Sub

    Private Sub LevelImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LevelImport.Click
        If ImportLevel.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fs As New IO.FileStream(ImportLevel.FileName, IO.FileMode.Open, IO.FileAccess.Read)
            Dim newLvl As New Level(fs, EdControl.lvl.name, EdControl.lvl.num, True, New IO.FileStream(r.path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))
            If newLvl.Width * newLvl.Height > EdControl.lvl.Width * EdControl.lvl.Height Then
                If MsgBox("You are importing a level with a background that is bigger than the current level. This will overwrite background data from a different level. Are you sure you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return
                End If
            End If
            EdControl.lvl = newLvl
            UpdateEdControl()
            EdControl.TilePicker.LoadTileset(EdControl.lvl.tileset)
        End If
    End Sub

    Private Sub LevelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LevelExport.Click
        If ExportLevel.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim data As Byte() = EdControl.lvl.ToFile()
            Dim fs As New IO.FileStream(ExportLevel.FileName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.Read)
            fs.Write(data, 0, data.Length)
        End If
    End Sub

    Private Sub LevelCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LevelCopy.Click
        Clipboard.SetText(ZAMNClip.ToClip("L" & ZAMNClip.ToText(EdControl.lvl.ToFile())))
    End Sub

    Private Sub LevelPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LevelPaste.Click
        If Not ZAMNClip.IsClip(Clipboard.GetText) Then Return
        Dim txt As String = ZAMNClip.FromClip(Clipboard.GetText)
        If Not txt.StartsWith("L") Then Return
        Dim data As Byte() = ZAMNClip.FromText(Mid(txt, 2))
        Dim fs As New ByteArrayStream(data)
        Dim newLvl As New Level(fs, EdControl.lvl.name, EdControl.lvl.num, True, New IO.FileStream(r.path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))
        If newLvl.Width * newLvl.Height > EdControl.lvl.Width * EdControl.lvl.Height Then
            If MsgBox("You are pasting a level with a background that is bigger than the current level. This will overwrite background data from a different level. Are you sure you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return
            End If
        End If
        EdControl.lvl = newLvl
        UpdateEdControl()
    End Sub

    Private Sub LevelEditTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LevelEditTitle.Click
        TitlePageEditor.ShowDialog(Me)
    End Sub

    Private Sub LevelSettingsM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LevelSettingsM.Click
        LevelSettings.ShowDialog(Me)
    End Sub

    Private Sub LevelSaveAsPNG_Click(sender As System.Object, e As System.EventArgs) Handles LevelSaveAsPNG.Click
        If SavePNG.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim bitmap As New Bitmap(EdControl.lvl.Width * 64, EdControl.lvl.Height * 64)
            Dim g As Graphics = Graphics.FromImage(bitmap)
            EdControl.Render(g, False)
            g.Dispose()
            Try
                bitmap.Save(SavePNG.FileName)
            Catch ex As Exception
                MsgBox("Could not save PNG:" & Environment.NewLine & ex.Message)
            End Try
        End If
    End Sub

    Private Sub HelpContents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpContents.Click
        Dim path As String = My.Application.Info.DirectoryPath & "\Help\index.html"
        If My.Computer.FileSystem.FileExists(path) Then
            System.Diagnostics.Process.Start(path)
        Else
            MsgBox("Help file could not be found.")
        End If
    End Sub

    Private Sub HelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpAbout.Click
        MsgBox("ZAMN Editor Beta v" & Application.ProductVersion & Environment.NewLine & "Icons are from or modified from Silk Icon set. http://www.famfamfam.com/lab/icons/silk/" & Environment.NewLine & Environment.NewLine & "Copyright © 2017 Piranhaplant", MsgBoxStyle.Information, "About")
    End Sub

    Private Sub Tools_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Tools.ItemClicked
        Dim indx As Integer = Tools.Items.IndexOf(e.ClickedItem)
        Dim indx2 As Integer = Tools.Items.IndexOf(BrushTool)
        If indx >= indx2 Then
            indx2 = indx - indx2
            SwitchToTool(ToolsMenu.DropDownItems(indx2), e.ClickedItem, EditingTools(indx2))
        End If
    End Sub

    Private Sub ToolsMenu_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolsMenu.DropDownItemClicked
        Dim indx As Integer = ToolsMenu.DropDownItems.IndexOf(e.ClickedItem)
        If indx < EditingTools.Length Then
            Dim indx2 As Integer = indx + Tools.Items.IndexOf(BrushTool)
            SwitchToTool(e.ClickedItem, Tools.Items(indx2), EditingTools(indx))
        End If
    End Sub

    Private Sub UncheckTools()
        For Each Item As ToolStripMenuItem In ToolsMenu.DropDownItems
            Item.Checked = False
        Next
        For l As Integer = Tools.Items.IndexOf(BrushTool) To Tools.Items.Count - 1
            CType(Tools.Items(l), ToolStripButton).Checked = False
        Next
    End Sub

    Private Sub SwitchToTool(ByVal item1 As ToolStripMenuItem, ByVal item2 As ToolStripButton, ByVal t As Tool)
        If Not item1.Checked Then
            UncheckTools()
            item1.Checked = True
            item2.Checked = True
            SetTool(t)
        End If
        If EdControl IsNot Nothing Then
            EdControl.Focus()
        End If
    End Sub

    Public Sub SetTool(ByVal t As Tool)
        If EdControl Is Nothing Or t Is Nothing Then Return
        Select Case t.SidePanel
            Case SideContentType.Tiles
                t.SetBrowser(EdControl.TilePicker)
                EdControl.SetSidePanel(EdControl.TilePicker)
                EdControl.TilePicker.SetAll()
            Case SideContentType.Items
                t.SetBrowser(EdControl.ItemPicker)
                EdControl.SetSidePanel(EdControl.ItemPicker)
            Case SideContentType.Victims
                t.SetBrowser(EdControl.VictimPicker)
                EdControl.SetSidePanel(EdControl.VictimPicker)
            Case SideContentType.NRMonsters
                t.SetBrowser(EdControl.NRMPicker)
                EdControl.SetSidePanel(EdControl.NRMPicker)
            Case SideContentType.Monsters
                t.SetBrowser(EdControl.MonsterPicker)
                EdControl.SetSidePanel(EdControl.MonsterPicker)
            Case SideContentType.BossMonsters
                t.SetBrowser(EdControl.BMonsterPicker)
                EdControl.SetSidePanel(EdControl.BMonsterPicker)
            Case SideContentType.Sprites
                t.SetBrowser(EdControl.SpritePicker)
                EdControl.SetSidePanel(EdControl.SpritePicker)
        End Select
        If CurTool IsNot Nothing Then
            CurTool.active = False
        End If
        t.active = True
        CurTool = t
        EdControl.t = t
        EdControl.SetStatusText(t.Status)
        t.Refresh()
        EdControl.Repaint()
    End Sub

    Public Sub UpdateEdControl()
        If EdControl Is Nothing Then Return
        EdControl.Grid = ViewGrid.Checked
        EdControl.priority = ViewPriority.Checked
        EdControl.zoom = zoomLevel
        EdControl.UpdateScrollBars()
        EdControl.Focus()
        EdControl.Repaint()
        EdControl.UndoMgr.ReAddItems()
    End Sub

    Public Sub SetCopy(ByVal enabled As Boolean)
        EditCopy.Enabled = enabled
        EditCut.Enabled = enabled
        CopyTool.Enabled = enabled
        CutTool.Enabled = enabled
    End Sub

    Public Sub CheckCopy()
        SetCopy(EdControl.selection.FindVisible())
    End Sub

    Private Sub Tabs_TabSelected(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tabs.TabSelected
        If updateTab Then
            EdControl.Animate = False
            EdControl = Tabs.SelectedTab.Controls(0)
            EdControl.Animate = ViewAnimate.Checked
            SetTool(CurTool)
            UpdateEdControl()
        End If
    End Sub

    Private Sub Tabs_TabClosed(ByVal sender As Object, ByVal e As TabEventArgs) Handles Tabs.TabClosed
        If (Not e.closeAll) AndAlso SaveMsgBox.ShowDialog(Me, True) = Windows.Forms.DialogResult.Cancel Then
            e.cancel = True
            Return
        End If
        openLevels.Remove(DirectCast(e.Tab.Controls(0), LvlEdCtrl).lvl.num)
        For Each t As Tool In EditingTools
            t.RemoveEdCtrl(e.Tab.Controls(0))
        Next
    End Sub

    Private Sub Tabs_TabsClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tabs.TabsClosed
        For Each i As ToolStripItem In LevelItems
            i.Enabled = False
        Next
        Tabs.Visible = False
        TSContainer.ContentPanel.BackColor = SystemColors.AppWorkspace
        UndoTool.DropDownItems.Clear()
        RedoTool.DropDownItems.Clear()
        UndoTool.Enabled = False
        RedoTool.Enabled = False
        CopyTool.Enabled = False
        CutTool.Enabled = False
        EmulatorFromLevel.Enabled = False
    End Sub

    Private ZoomLevels As Single() = {0.1F, 0.25F, 1.0F / 3.0F, 0.5F, 2.0F / 3.0F, 0.75F, 1.0F, 1.5F, 2.0F, 3.0F, 4.0F, 6.0F, 8.0F}
    Private ZoomUpdate As Boolean = False

    Private Sub ViewZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewZoomIn.Click
        For l As Integer = 0 To ZoomLevels.Length - 2
            If zoomLevel >= ZoomLevels(l) And zoomLevel < ZoomLevels(l + 1) Then
                SetZoom(ZoomLevels(l + 1))
                Return
            End If
        Next
    End Sub

    Private Sub ViewZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewZoomOut.Click
        For l As Integer = 0 To ZoomLevels.Length - 2
            If zoomLevel > ZoomLevels(l) And zoomLevel <= ZoomLevels(l + 1) Then
                SetZoom(ZoomLevels(l))
                Return
            End If
        Next
    End Sub

    Private Sub Zoom1Tool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Zoom1Tool.Click
        SetZoom(1.0F)
    End Sub

    Private Sub Zoom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Zoom.TextChanged
        If ZoomUpdate Then Return
        Dim zoomText As String = Zoom.Text
        If zoomText.EndsWith("%") Then
            zoomText = Mid(zoomText, 1, zoomText.Length - 1)
        End If
        Dim newZoom As Single
        If Single.TryParse(zoomText, newZoom) AndAlso newZoom >= 1 AndAlso newZoom <= 10000 Then
            SetZoom(newZoom / 100)
        End If
    End Sub

    Public Sub SetZoom(ByVal zoomlvl As Single)
        ZoomUpdate = True
        zoomLevel = zoomlvl
        Zoom.Text = (zoomlvl * 100).ToString() & "%"
        ZoomUpdate = False
        If EdControl Is Nothing Then Return
        EdControl.SetZoom(zoomlvl)
    End Sub

    Private toolKeys As Keys() = {Keys.P, Keys.S, Keys.R, Keys.C, Keys.T, Keys.I, Keys.V, Keys.N, Keys.M, Keys.B}

    Private Sub LvlEdCtrl_canvas_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyData
            Case Keys.Control Or Keys.Add
                ViewZoomIn_Click(sender, e)
            Case Keys.Control Or Keys.Subtract
                ViewZoomOut_Click(sender, e)
        End Select
        If toolKeys.Contains(e.KeyData) Then
            Dim indx As Integer = Array.IndexOf(toolKeys, e.KeyData)
            SwitchToTool(ToolsMenu.DropDownItems(indx), Tools.Items(Tools.Items.IndexOf(BrushTool) + indx), EditingTools(indx))
        End If
    End Sub

    Private Function ListToString(ByVal items As List(Of String)) As String
        Dim str As String = ""
        For Each i As String In items
            str &= i & "|"
        Next
        Return str
    End Function

    Private Function StringToList(ByVal str As String) As List(Of String)
        Dim items As New List(Of String)
        Dim str2 As String = str
        Dim indx As Integer
        Do
            indx = InStr(str2, "|")
            If indx = 0 Then Exit Do
            items.Add(Mid(str2, 1, indx - 1))
            str2 = Mid(str2, indx + 1)
        Loop
        Return items
    End Function

    Public Shared Function InStrN(ByVal str As String, ByVal find As String, ByVal n As Integer) As Integer
        Dim p As Integer = 1
        Do While InStr(p, str, find) > 0 And n > 0
            p = InStr(p, str, find) + 1
            n -= 1
        Loop
        Return p - 1
    End Function

    Private Function CopyTiles() As String
        Dim str As String
        Dim xStart As Integer = EdControl.lvl.Width
        Dim yStart As Integer = EdControl.lvl.Height
        Dim xEnd As Integer = -1
        Dim yEnd As Integer = -1
        For y As Integer = 0 To EdControl.lvl.Height - 1
            For x As Integer = 0 To EdControl.lvl.Width - 1
                If EdControl.selection.selectPts(x, y) Then
                    If x < xStart Then xStart = x
                    If y < yStart Then yStart = y
                    If x > xEnd Then xEnd = x
                    If y > yEnd Then yEnd = y
                End If
            Next
        Next
        str = "T" & (xEnd - xStart + 1).ToString("X2") & (yEnd - yStart + 1).ToString("X2")
        For y As Integer = yStart To yEnd
            For x As Integer = xStart To xEnd
                If EdControl.selection.selectPts(x, y) Then
                    str &= (EdControl.lvl.Tiles(x, y)).ToString("X2")
                Else
                    str &= "--"
                End If
            Next
        Next
        Return str
    End Function

    Private Sub DebugCopyTileset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebugCopyTileset.Click
        Dim img As New Bitmap(64 * 16, 64 * 16)
        Using g As Graphics = Graphics.FromImage(img)
            For l As Integer = 0 To 255
                g.DrawImage(EdControl.lvl.tileset.images(l), (l Mod 16) * 64, (l \ 16) * 64)
            Next
        End Using
        Clipboard.SetImage(img)
    End Sub

    Private Function DebugCommonElements(Of T)(ByVal List1 As List(Of T), ByVal List2 As List(Of T)) As List(Of T)
        Dim nl As New List(Of T)
        For Each i As T In List1
            If List2.Contains(i) Then
                nl.Add(i)
            End If
        Next
        Return nl
    End Function

    Private Function DebugCommonElements(Of T)(ByVal List1 As List(Of T), ByVal List2 As List(Of T), ByRef freqList1 As List(Of Double), ByVal freqList2 As List(Of Double)) As List(Of T)
        Dim nl As New List(Of T)
        Dim nfreql As New List(Of Double)
        Dim idx As Integer
        For l As Integer = 0 To List1.Count - 1
            idx = List2.IndexOf(List1(l))
            If idx > -1 Then
                nl.Add(List1(l))
                nfreql.Add((freqList1(l) + freqList2(idx)) / 2)
            End If
        Next
        freqList1 = nfreql
        Return nl
    End Function

    Private Function DebugRandFromList(Of T)(ByVal lst As List(Of T), ByVal freqList As List(Of Double), ByVal r As Random) As T
        Dim sum As Double = 0
        For Each n As Double In freqList
            sum += n
        Next
        Dim randNum As Double = r.NextDouble * sum
        sum = 0
        For l As Integer = 0 To lst.Count - 1
            If randNum > sum And randNum < sum + freqList(l) Then
                Return lst(l)
            End If
            sum += freqList(l)
        Next
        Return lst.Last
    End Function

    Private Sub DebugFillSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebugFillSelection.Click
        Dim r As New Random
        Dim sugList As List(Of Byte)
        Dim tempSugList As List(Of Byte)
        Dim probList As List(Of Double)
        Dim fails As Integer = 0
        With EdControl.lvl
            Dim tilesetNum As Integer = Array.IndexOf(Pointers.SuggestTilesets, .tileset.address) + Pointers.SuggestTilesets.Length
            For y As Integer = 0 To .Height - 1
                For x As Integer = 0 To .Width - 1
                    If EdControl.selection.selectPts(x, y) Then
                        sugList = New List(Of Byte)
                        For l As Integer = 0 To 255
                            sugList.Add(l)
                        Next
                        probList = TileSuggestList.GetProbList(tilesetNum, 0, sugList)
                        If x > 0 Then
                            tempSugList = TileSuggestList.GetList(tilesetNum, .Tiles(x - 1, y), 2)
                            sugList = DebugCommonElements(sugList, tempSugList, probList, TileSuggestList.GetProbList(tilesetNum, 2, tempSugList))
                        End If
                        If y > 0 Then
                            tempSugList = TileSuggestList.GetList(tilesetNum, .Tiles(x, y - 1), 3)
                            sugList = DebugCommonElements(sugList, tempSugList, probList, TileSuggestList.GetProbList(tilesetNum, 3, tempSugList))
                        End If
                        If x < .Width - 1 AndAlso Not EdControl.selection.selectPts(x + 1, y) Then
                            tempSugList = TileSuggestList.GetList(tilesetNum, .Tiles(x + 1, y), 0)
                            sugList = DebugCommonElements(sugList, tempSugList, probList, TileSuggestList.GetProbList(tilesetNum, 0, tempSugList))
                        End If
                        If y < .Height - 1 AndAlso Not EdControl.selection.selectPts(x, y + 1) Then
                            tempSugList = TileSuggestList.GetList(tilesetNum, .Tiles(x, y + 1), 1)
                            sugList = DebugCommonElements(sugList, tempSugList, probList, TileSuggestList.GetProbList(tilesetNum, 1, tempSugList))
                        End If
                        If sugList.Count > 0 Then
                            .Tiles(x, y) = DebugRandFromList(sugList, probList, r)
                        Else
                            x -= 2
                            fails += 1
                            If fails Mod 100 = 0 Then
                                x = -1
                            End If
                            If fails Mod 1000 = 0 Then
                                y -= 1
                            End If
                            If x < -1 Then
                                y -= 1
                                x = -1
                            End If
                        End If
                    End If
                Next
            Next
        End With
        EdControl.Repaint()
    End Sub

    Private Sub DebugDecompress_Click(sender As System.Object, e As System.EventArgs) Handles DebugDecompress.Click
        Dim str As String = InputBox("Address of compressed data (hexadecimal):")
        Dim address As Integer = Integer.Parse(str, Globalization.NumberStyles.AllowHexSpecifier)

        Dim s As New IO.FileStream(r.path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
        s.Seek(address, IO.SeekOrigin.Begin)
        Dim data() As Byte = ZAMNCompress.Decompress(s)

        Dim save As New SaveFileDialog
        save.Filter = "Binary files (*.bin)|*.bin|All Files (*.*)|*.*"
        If save.ShowDialog() = Windows.Forms.DialogResult.OK Then
            IO.File.WriteAllBytes(save.FileName, data)
        End If
    End Sub

    Private Sub DebugCompress_Click(sender As System.Object, e As System.EventArgs) Handles DebugCompress.Click
        Dim open As New OpenFileDialog
        open.Filter = "Binary files (*.bin)|*.bin|All Files (*.*)|*.*"
        If open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim data() As Byte = IO.File.ReadAllBytes(open.FileName)
            Dim compressed() As Byte = ZAMNCompress.Compress(data)

            Dim save As New SaveFileDialog
            save.Filter = open.Filter
            If save.ShowDialog() = Windows.Forms.DialogResult.OK Then
                IO.File.WriteAllBytes(save.FileName, compressed)
            End If
        End If
    End Sub

    Private Sub DebugFixTileAnim_Click(sender As System.Object, e As System.EventArgs) Handles DebugFixTileAnim.Click
        r.FixTileAnim()
    End Sub
End Class
