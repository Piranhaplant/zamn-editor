<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Editor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Editor))
        Me.TSContainer = New System.Windows.Forms.ToolStripContainer()
        Me.Tabs = New ZAMNEditor.Tabs()
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecentROMs = New ZAMNEditor.RecentFilesList()
        Me.FileOpenLevel = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileEmulator = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmulatorRunROM = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmulatorFromLevel = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmulatorSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSelectNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditPasswords = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewGrid = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewPriority = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewAnimate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewNextFrame = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewRestartAnimation = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewZoomIn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewZoomOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.LevelMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.LevelExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.LevelImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.LevelCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.LevelPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.LevelEditTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.LevelSettingsM = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.LevelSaveAsPNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.LevelDebugTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugCopyTileset = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugFillSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugDecompress = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugCompress = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugFixTileAnim = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsPaintBrush = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsTileSuggest = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsRectangleSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsPencilSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsTileSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsVictims = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsNRMonsters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMonsters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsBossMonsters = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpritesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpContents = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tools = New System.Windows.Forms.ToolStrip()
        Me.OpenTool = New System.Windows.Forms.ToolStripButton()
        Me.OpenLevelTool = New System.Windows.Forms.ToolStripButton()
        Me.SaveTool = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CutTool = New System.Windows.Forms.ToolStripButton()
        Me.CopyTool = New System.Windows.Forms.ToolStripButton()
        Me.PasteTool = New System.Windows.Forms.ToolStripButton()
        Me.UndoTool = New System.Windows.Forms.ToolStripSplitButton()
        Me.RedoTool = New System.Windows.Forms.ToolStripSplitButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Zoom1Tool = New System.Windows.Forms.ToolStripButton()
        Me.Zoom = New System.Windows.Forms.ToolStripComboBox()
        Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BrushTool = New System.Windows.Forms.ToolStripButton()
        Me.TileSgstTool = New System.Windows.Forms.ToolStripButton()
        Me.RectangleTool = New System.Windows.Forms.ToolStripButton()
        Me.PencilTool = New System.Windows.Forms.ToolStripButton()
        Me.TileSlctTool = New System.Windows.Forms.ToolStripButton()
        Me.ItemTool = New System.Windows.Forms.ToolStripButton()
        Me.VictimTool = New System.Windows.Forms.ToolStripButton()
        Me.NRMTool = New System.Windows.Forms.ToolStripButton()
        Me.MonTool = New System.Windows.Forms.ToolStripButton()
        Me.BMonTool = New System.Windows.Forms.ToolStripButton()
        Me.SprTool = New System.Windows.Forms.ToolStripButton()
        Me.OpenROM = New System.Windows.Forms.OpenFileDialog()
        Me.ImportLevel = New System.Windows.Forms.OpenFileDialog()
        Me.ExportLevel = New System.Windows.Forms.SaveFileDialog()
        Me.OpenEmulator = New System.Windows.Forms.OpenFileDialog()
        Me.SavePNG = New System.Windows.Forms.SaveFileDialog()
        Me.TSContainer.ContentPanel.SuspendLayout()
        Me.TSContainer.TopToolStripPanel.SuspendLayout()
        Me.TSContainer.SuspendLayout()
        Me.MainMenu.SuspendLayout()
        Me.Tools.SuspendLayout()
        Me.SuspendLayout()
        '
        'TSContainer
        '
        '
        'TSContainer.BottomToolStripPanel
        '
        Me.TSContainer.BottomToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        '
        'TSContainer.ContentPanel
        '
        Me.TSContainer.ContentPanel.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.TSContainer.ContentPanel.Controls.Add(Me.Tabs)
        Me.TSContainer.ContentPanel.Size = New System.Drawing.Size(625, 386)
        Me.TSContainer.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'TSContainer.LeftToolStripPanel
        '
        Me.TSContainer.LeftToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TSContainer.Location = New System.Drawing.Point(0, 0)
        Me.TSContainer.Name = "TSContainer"
        '
        'TSContainer.RightToolStripPanel
        '
        Me.TSContainer.RightToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TSContainer.Size = New System.Drawing.Size(625, 435)
        Me.TSContainer.TabIndex = 0
        Me.TSContainer.Text = "ToolStripContainer1"
        '
        'TSContainer.TopToolStripPanel
        '
        Me.TSContainer.TopToolStripPanel.Controls.Add(Me.MainMenu)
        Me.TSContainer.TopToolStripPanel.Controls.Add(Me.Tools)
        Me.TSContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        '
        'Tabs
        '
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 0)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.Size = New System.Drawing.Size(625, 386)
        Me.Tabs.TabIndex = 1
        Me.Tabs.Text = "Tabs1"
        Me.Tabs.Visible = False
        '
        'MainMenu
        '
        Me.MainMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu, Me.ViewMenu, Me.LevelMenu, Me.ToolsMenu, Me.HelpMenu})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MainMenu.Size = New System.Drawing.Size(625, 24)
        Me.MainMenu.TabIndex = 0
        Me.MainMenu.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileOpen, Me.RecentROMs, Me.FileOpenLevel, Me.toolStripSeparator2, Me.FileSave, Me.toolStripSeparator4, Me.FileEmulator, Me.toolStripSeparator3, Me.FileExit})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "&File"
        '
        'FileOpen
        '
        Me.FileOpen.Image = Global.ZAMNEditor.My.Resources.Resources.Folder
        Me.FileOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FileOpen.Name = "FileOpen"
        Me.FileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.FileOpen.Size = New System.Drawing.Size(173, 22)
        Me.FileOpen.Text = "&Open"
        '
        'RecentROMs
        '
        Me.RecentROMs.Enabled = False
        Me.RecentROMs.Items = CType(resources.GetObject("RecentROMs.Items"), System.Collections.Generic.List(Of String))
        Me.RecentROMs.MaxItems = 5
        Me.RecentROMs.MaxLength = 60
        Me.RecentROMs.Name = "RecentROMs"
        Me.RecentROMs.Size = New System.Drawing.Size(173, 22)
        Me.RecentROMs.Text = "&Recent ROMs"
        '
        'FileOpenLevel
        '
        Me.FileOpenLevel.Enabled = False
        Me.FileOpenLevel.Image = Global.ZAMNEditor.My.Resources.Resources.BlueFolder
        Me.FileOpenLevel.Name = "FileOpenLevel"
        Me.FileOpenLevel.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.FileOpenLevel.Size = New System.Drawing.Size(173, 22)
        Me.FileOpenLevel.Text = "Open &Level"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(170, 6)
        '
        'FileSave
        '
        Me.FileSave.Enabled = False
        Me.FileSave.Image = Global.ZAMNEditor.My.Resources.Resources.Save
        Me.FileSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FileSave.Name = "FileSave"
        Me.FileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.FileSave.Size = New System.Drawing.Size(173, 22)
        Me.FileSave.Text = "&Save"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(170, 6)
        '
        'FileEmulator
        '
        Me.FileEmulator.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmulatorRunROM, Me.EmulatorFromLevel, Me.EmulatorSetup})
        Me.FileEmulator.Name = "FileEmulator"
        Me.FileEmulator.Size = New System.Drawing.Size(173, 22)
        Me.FileEmulator.Text = "&Emulator"
        '
        'EmulatorRunROM
        '
        Me.EmulatorRunROM.Enabled = False
        Me.EmulatorRunROM.Name = "EmulatorRunROM"
        Me.EmulatorRunROM.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.EmulatorRunROM.Size = New System.Drawing.Size(175, 22)
        Me.EmulatorRunROM.Text = "&Run ROM"
        '
        'EmulatorFromLevel
        '
        Me.EmulatorFromLevel.Enabled = False
        Me.EmulatorFromLevel.Name = "EmulatorFromLevel"
        Me.EmulatorFromLevel.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.EmulatorFromLevel.Size = New System.Drawing.Size(175, 22)
        Me.EmulatorFromLevel.Text = "Run From &Level"
        '
        'EmulatorSetup
        '
        Me.EmulatorSetup.Name = "EmulatorSetup"
        Me.EmulatorSetup.Size = New System.Drawing.Size(175, 22)
        Me.EmulatorSetup.Text = "&Setup Emulator..."
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(170, 6)
        '
        'FileExit
        '
        Me.FileExit.Name = "FileExit"
        Me.FileExit.Size = New System.Drawing.Size(173, 22)
        Me.FileExit.Text = "E&xit"
        '
        'EditMenu
        '
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditUndo, Me.EditRedo, Me.toolStripSeparator5, Me.EditCut, Me.EditCopy, Me.EditPaste, Me.toolStripSeparator6, Me.EditSelectAll, Me.EditSelectNone, Me.toolStripSeparator9, Me.EditPasswords})
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(39, 20)
        Me.EditMenu.Text = "&Edit"
        '
        'EditUndo
        '
        Me.EditUndo.Enabled = False
        Me.EditUndo.Image = Global.ZAMNEditor.My.Resources.Resources.Undo
        Me.EditUndo.Name = "EditUndo"
        Me.EditUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.EditUndo.Size = New System.Drawing.Size(211, 22)
        Me.EditUndo.Text = "&Undo"
        '
        'EditRedo
        '
        Me.EditRedo.Enabled = False
        Me.EditRedo.Image = Global.ZAMNEditor.My.Resources.Resources.Redo
        Me.EditRedo.Name = "EditRedo"
        Me.EditRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.EditRedo.Size = New System.Drawing.Size(211, 22)
        Me.EditRedo.Text = "&Redo"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(208, 6)
        '
        'EditCut
        '
        Me.EditCut.Enabled = False
        Me.EditCut.Image = Global.ZAMNEditor.My.Resources.Resources.Cut
        Me.EditCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditCut.Name = "EditCut"
        Me.EditCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.EditCut.Size = New System.Drawing.Size(211, 22)
        Me.EditCut.Text = "Cu&t"
        '
        'EditCopy
        '
        Me.EditCopy.Enabled = False
        Me.EditCopy.Image = Global.ZAMNEditor.My.Resources.Resources.Copy
        Me.EditCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditCopy.Name = "EditCopy"
        Me.EditCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.EditCopy.Size = New System.Drawing.Size(211, 22)
        Me.EditCopy.Text = "&Copy"
        '
        'EditPaste
        '
        Me.EditPaste.Enabled = False
        Me.EditPaste.Image = Global.ZAMNEditor.My.Resources.Resources.Paste
        Me.EditPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditPaste.Name = "EditPaste"
        Me.EditPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.EditPaste.Size = New System.Drawing.Size(211, 22)
        Me.EditPaste.Text = "&Paste"
        '
        'toolStripSeparator6
        '
        Me.toolStripSeparator6.Name = "toolStripSeparator6"
        Me.toolStripSeparator6.Size = New System.Drawing.Size(208, 6)
        '
        'EditSelectAll
        '
        Me.EditSelectAll.Enabled = False
        Me.EditSelectAll.Name = "EditSelectAll"
        Me.EditSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.EditSelectAll.Size = New System.Drawing.Size(211, 22)
        Me.EditSelectAll.Text = "Select &All"
        '
        'EditSelectNone
        '
        Me.EditSelectNone.Enabled = False
        Me.EditSelectNone.Name = "EditSelectNone"
        Me.EditSelectNone.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.EditSelectNone.Size = New System.Drawing.Size(211, 22)
        Me.EditSelectNone.Text = "Select &None"
        '
        'toolStripSeparator9
        '
        Me.toolStripSeparator9.Name = "toolStripSeparator9"
        Me.toolStripSeparator9.Size = New System.Drawing.Size(208, 6)
        '
        'EditPasswords
        '
        Me.EditPasswords.Enabled = False
        Me.EditPasswords.Name = "EditPasswords"
        Me.EditPasswords.Size = New System.Drawing.Size(211, 22)
        Me.EditPasswords.Text = "Pass&words..."
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewGrid, Me.ViewPriority, Me.ToolStripSeparator12, Me.ViewAnimate, Me.ViewNextFrame, Me.ViewRestartAnimation, Me.toolStripSeparator7, Me.ViewZoomIn, Me.ViewZoomOut})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(44, 20)
        Me.ViewMenu.Text = "&View"
        '
        'ViewGrid
        '
        Me.ViewGrid.CheckOnClick = True
        Me.ViewGrid.Enabled = False
        Me.ViewGrid.Name = "ViewGrid"
        Me.ViewGrid.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.ViewGrid.Size = New System.Drawing.Size(198, 22)
        Me.ViewGrid.Text = "&Grid"
        '
        'ViewPriority
        '
        Me.ViewPriority.CheckOnClick = True
        Me.ViewPriority.Enabled = False
        Me.ViewPriority.Name = "ViewPriority"
        Me.ViewPriority.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.ViewPriority.Size = New System.Drawing.Size(198, 22)
        Me.ViewPriority.Text = "&Solid Tiles Only"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(195, 6)
        '
        'ViewAnimate
        '
        Me.ViewAnimate.Checked = True
        Me.ViewAnimate.CheckOnClick = True
        Me.ViewAnimate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewAnimate.Name = "ViewAnimate"
        Me.ViewAnimate.Size = New System.Drawing.Size(198, 22)
        Me.ViewAnimate.Text = "&Animate"
        '
        'ViewNextFrame
        '
        Me.ViewNextFrame.Enabled = False
        Me.ViewNextFrame.Name = "ViewNextFrame"
        Me.ViewNextFrame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ViewNextFrame.Size = New System.Drawing.Size(198, 22)
        Me.ViewNextFrame.Text = "&Next Frame"
        '
        'ViewRestartAnimation
        '
        Me.ViewRestartAnimation.Enabled = False
        Me.ViewRestartAnimation.Name = "ViewRestartAnimation"
        Me.ViewRestartAnimation.Size = New System.Drawing.Size(198, 22)
        Me.ViewRestartAnimation.Text = "&Restart Animation"
        '
        'toolStripSeparator7
        '
        Me.toolStripSeparator7.Name = "toolStripSeparator7"
        Me.toolStripSeparator7.Size = New System.Drawing.Size(195, 6)
        '
        'ViewZoomIn
        '
        Me.ViewZoomIn.Name = "ViewZoomIn"
        Me.ViewZoomIn.ShortcutKeyDisplayString = "Ctrl++"
        Me.ViewZoomIn.Size = New System.Drawing.Size(198, 22)
        Me.ViewZoomIn.Text = "Zoom &In"
        '
        'ViewZoomOut
        '
        Me.ViewZoomOut.Name = "ViewZoomOut"
        Me.ViewZoomOut.ShortcutKeyDisplayString = "Ctrl+-"
        Me.ViewZoomOut.Size = New System.Drawing.Size(198, 22)
        Me.ViewZoomOut.Text = "Zoom &Out"
        '
        'LevelMenu
        '
        Me.LevelMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LevelExport, Me.LevelImport, Me.LevelCopy, Me.LevelPaste, Me.toolStripSeparator10, Me.LevelEditTitle, Me.LevelSettingsM, Me.ToolStripSeparator13, Me.LevelSaveAsPNG, Me.LevelDebugTools})
        Me.LevelMenu.Name = "LevelMenu"
        Me.LevelMenu.Size = New System.Drawing.Size(46, 20)
        Me.LevelMenu.Text = "&Level"
        '
        'LevelExport
        '
        Me.LevelExport.Enabled = False
        Me.LevelExport.Name = "LevelExport"
        Me.LevelExport.Size = New System.Drawing.Size(156, 22)
        Me.LevelExport.Text = "&Export"
        '
        'LevelImport
        '
        Me.LevelImport.Enabled = False
        Me.LevelImport.Name = "LevelImport"
        Me.LevelImport.Size = New System.Drawing.Size(156, 22)
        Me.LevelImport.Text = "&Import"
        '
        'LevelCopy
        '
        Me.LevelCopy.Enabled = False
        Me.LevelCopy.Name = "LevelCopy"
        Me.LevelCopy.Size = New System.Drawing.Size(156, 22)
        Me.LevelCopy.Text = "&Copy as Text"
        '
        'LevelPaste
        '
        Me.LevelPaste.Enabled = False
        Me.LevelPaste.Name = "LevelPaste"
        Me.LevelPaste.Size = New System.Drawing.Size(156, 22)
        Me.LevelPaste.Text = "&Paste from Text"
        '
        'toolStripSeparator10
        '
        Me.toolStripSeparator10.Name = "toolStripSeparator10"
        Me.toolStripSeparator10.Size = New System.Drawing.Size(153, 6)
        '
        'LevelEditTitle
        '
        Me.LevelEditTitle.Enabled = False
        Me.LevelEditTitle.Name = "LevelEditTitle"
        Me.LevelEditTitle.Size = New System.Drawing.Size(156, 22)
        Me.LevelEditTitle.Text = "Edit &Title..."
        '
        'LevelSettingsM
        '
        Me.LevelSettingsM.Enabled = False
        Me.LevelSettingsM.Name = "LevelSettingsM"
        Me.LevelSettingsM.Size = New System.Drawing.Size(156, 22)
        Me.LevelSettingsM.Text = "&Settings..."
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(153, 6)
        '
        'LevelSaveAsPNG
        '
        Me.LevelSaveAsPNG.Enabled = False
        Me.LevelSaveAsPNG.Name = "LevelSaveAsPNG"
        Me.LevelSaveAsPNG.Size = New System.Drawing.Size(156, 22)
        Me.LevelSaveAsPNG.Text = "Save as PNG..."
        '
        'LevelDebugTools
        '
        Me.LevelDebugTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DebugCopyTileset, Me.DebugFillSelection, Me.DebugDecompress, Me.DebugCompress, Me.DebugFixTileAnim})
        Me.LevelDebugTools.Name = "LevelDebugTools"
        Me.LevelDebugTools.Size = New System.Drawing.Size(156, 22)
        Me.LevelDebugTools.Text = "Debug Tools"
        Me.LevelDebugTools.Visible = False
        '
        'DebugCopyTileset
        '
        Me.DebugCopyTileset.Name = "DebugCopyTileset"
        Me.DebugCopyTileset.Size = New System.Drawing.Size(188, 22)
        Me.DebugCopyTileset.Text = "Copy Tileset Image"
        '
        'DebugFillSelection
        '
        Me.DebugFillSelection.Name = "DebugFillSelection"
        Me.DebugFillSelection.Size = New System.Drawing.Size(188, 22)
        Me.DebugFillSelection.Text = "Random Fill Selection"
        '
        'DebugDecompress
        '
        Me.DebugDecompress.Name = "DebugDecompress"
        Me.DebugDecompress.Size = New System.Drawing.Size(188, 22)
        Me.DebugDecompress.Text = "Decompress"
        '
        'DebugCompress
        '
        Me.DebugCompress.Name = "DebugCompress"
        Me.DebugCompress.Size = New System.Drawing.Size(188, 22)
        Me.DebugCompress.Text = "Compress"
        '
        'DebugFixTileAnim
        '
        Me.DebugFixTileAnim.Name = "DebugFixTileAnim"
        Me.DebugFixTileAnim.Size = New System.Drawing.Size(188, 22)
        Me.DebugFixTileAnim.Text = "Fix Tile Animations"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsPaintBrush, Me.ToolsTileSuggest, Me.ToolsRectangleSelect, Me.ToolsPencilSelect, Me.ToolsTileSelect, Me.ToolsItem, Me.ToolsVictims, Me.ToolsNRMonsters, Me.ToolsMonsters, Me.ToolsBossMonsters, Me.SpritesToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(48, 20)
        Me.ToolsMenu.Text = "&Tools"
        '
        'ToolsPaintBrush
        '
        Me.ToolsPaintBrush.Image = Global.ZAMNEditor.My.Resources.Resources.Brush
        Me.ToolsPaintBrush.Name = "ToolsPaintBrush"
        Me.ToolsPaintBrush.ShortcutKeyDisplayString = "P"
        Me.ToolsPaintBrush.Size = New System.Drawing.Size(234, 22)
        Me.ToolsPaintBrush.Text = "&Paint Brush"
        '
        'ToolsTileSuggest
        '
        Me.ToolsTileSuggest.Image = Global.ZAMNEditor.My.Resources.Resources.lightbulb
        Me.ToolsTileSuggest.Name = "ToolsTileSuggest"
        Me.ToolsTileSuggest.ShortcutKeyDisplayString = "S"
        Me.ToolsTileSuggest.Size = New System.Drawing.Size(234, 22)
        Me.ToolsTileSuggest.Text = "Tile &Suggest"
        '
        'ToolsRectangleSelect
        '
        Me.ToolsRectangleSelect.Image = Global.ZAMNEditor.My.Resources.Resources.Selection
        Me.ToolsRectangleSelect.Name = "ToolsRectangleSelect"
        Me.ToolsRectangleSelect.ShortcutKeyDisplayString = "R"
        Me.ToolsRectangleSelect.Size = New System.Drawing.Size(234, 22)
        Me.ToolsRectangleSelect.Text = "&Rectangle Select"
        '
        'ToolsPencilSelect
        '
        Me.ToolsPencilSelect.Image = Global.ZAMNEditor.My.Resources.Resources.PencilSelect
        Me.ToolsPencilSelect.Name = "ToolsPencilSelect"
        Me.ToolsPencilSelect.ShortcutKeyDisplayString = "C"
        Me.ToolsPencilSelect.Size = New System.Drawing.Size(234, 22)
        Me.ToolsPencilSelect.Text = "Pen&cil Select"
        '
        'ToolsTileSelect
        '
        Me.ToolsTileSelect.Image = Global.ZAMNEditor.My.Resources.Resources.TileSelect
        Me.ToolsTileSelect.Name = "ToolsTileSelect"
        Me.ToolsTileSelect.ShortcutKeyDisplayString = "T"
        Me.ToolsTileSelect.Size = New System.Drawing.Size(234, 22)
        Me.ToolsTileSelect.Text = "&Tile Select"
        '
        'ToolsItem
        '
        Me.ToolsItem.Image = Global.ZAMNEditor.My.Resources.Resources.FirstAidKit
        Me.ToolsItem.Name = "ToolsItem"
        Me.ToolsItem.ShortcutKeyDisplayString = "I"
        Me.ToolsItem.Size = New System.Drawing.Size(234, 22)
        Me.ToolsItem.Text = "&Items"
        '
        'ToolsVictims
        '
        Me.ToolsVictims.Image = Global.ZAMNEditor.My.Resources.Resources.Dog
        Me.ToolsVictims.Name = "ToolsVictims"
        Me.ToolsVictims.ShortcutKeyDisplayString = "V"
        Me.ToolsVictims.Size = New System.Drawing.Size(234, 22)
        Me.ToolsVictims.Text = "&Victims"
        '
        'ToolsNRMonsters
        '
        Me.ToolsNRMonsters.Image = Global.ZAMNEditor.My.Resources.Resources.Chainsaw
        Me.ToolsNRMonsters.Name = "ToolsNRMonsters"
        Me.ToolsNRMonsters.ShortcutKeyDisplayString = "N"
        Me.ToolsNRMonsters.Size = New System.Drawing.Size(234, 22)
        Me.ToolsNRMonsters.Text = "&Non-Respawning Monsters"
        '
        'ToolsMonsters
        '
        Me.ToolsMonsters.Image = Global.ZAMNEditor.My.Resources.Resources.Zombie
        Me.ToolsMonsters.Name = "ToolsMonsters"
        Me.ToolsMonsters.ShortcutKeyDisplayString = "M"
        Me.ToolsMonsters.Size = New System.Drawing.Size(234, 22)
        Me.ToolsMonsters.Text = "&Monsters"
        '
        'ToolsBossMonsters
        '
        Me.ToolsBossMonsters.Image = Global.ZAMNEditor.My.Resources.Resources.DrTongue
        Me.ToolsBossMonsters.Name = "ToolsBossMonsters"
        Me.ToolsBossMonsters.ShortcutKeyDisplayString = "B"
        Me.ToolsBossMonsters.Size = New System.Drawing.Size(234, 22)
        Me.ToolsBossMonsters.Text = "&Boss Monsters"
        '
        'SpritesToolStripMenuItem
        '
        Me.SpritesToolStripMenuItem.Name = "SpritesToolStripMenuItem"
        Me.SpritesToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.SpritesToolStripMenuItem.Text = "Sprites"
        Me.SpritesToolStripMenuItem.Visible = False
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpContents, Me.toolStripSeparator11, Me.HelpAbout})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(44, 20)
        Me.HelpMenu.Text = "&Help"
        '
        'HelpContents
        '
        Me.HelpContents.Name = "HelpContents"
        Me.HelpContents.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.HelpContents.Size = New System.Drawing.Size(150, 22)
        Me.HelpContents.Text = "&Contents..."
        '
        'toolStripSeparator11
        '
        Me.toolStripSeparator11.Name = "toolStripSeparator11"
        Me.toolStripSeparator11.Size = New System.Drawing.Size(147, 6)
        '
        'HelpAbout
        '
        Me.HelpAbout.Name = "HelpAbout"
        Me.HelpAbout.Size = New System.Drawing.Size(150, 22)
        Me.HelpAbout.Text = "&About"
        '
        'Tools
        '
        Me.Tools.Dock = System.Windows.Forms.DockStyle.None
        Me.Tools.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenTool, Me.OpenLevelTool, Me.SaveTool, Me.toolStripSeparator, Me.CutTool, Me.CopyTool, Me.PasteTool, Me.UndoTool, Me.RedoTool, Me.toolStripSeparator1, Me.Zoom1Tool, Me.Zoom, Me.toolStripSeparator8, Me.BrushTool, Me.TileSgstTool, Me.RectangleTool, Me.PencilTool, Me.TileSlctTool, Me.ItemTool, Me.VictimTool, Me.NRMTool, Me.MonTool, Me.BMonTool, Me.SprTool})
        Me.Tools.Location = New System.Drawing.Point(3, 24)
        Me.Tools.Name = "Tools"
        Me.Tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Tools.Size = New System.Drawing.Size(562, 25)
        Me.Tools.TabIndex = 1
        '
        'OpenTool
        '
        Me.OpenTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenTool.Image = Global.ZAMNEditor.My.Resources.Resources.Folder
        Me.OpenTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenTool.Name = "OpenTool"
        Me.OpenTool.Size = New System.Drawing.Size(23, 22)
        Me.OpenTool.Text = "&Open"
        '
        'OpenLevelTool
        '
        Me.OpenLevelTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenLevelTool.Enabled = False
        Me.OpenLevelTool.Image = Global.ZAMNEditor.My.Resources.Resources.BlueFolder
        Me.OpenLevelTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenLevelTool.Name = "OpenLevelTool"
        Me.OpenLevelTool.Size = New System.Drawing.Size(23, 22)
        Me.OpenLevelTool.Text = "Open Level"
        '
        'SaveTool
        '
        Me.SaveTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveTool.Enabled = False
        Me.SaveTool.Image = Global.ZAMNEditor.My.Resources.Resources.Save
        Me.SaveTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveTool.Name = "SaveTool"
        Me.SaveTool.Size = New System.Drawing.Size(23, 22)
        Me.SaveTool.Text = "&Save"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'CutTool
        '
        Me.CutTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutTool.Enabled = False
        Me.CutTool.Image = Global.ZAMNEditor.My.Resources.Resources.Cut
        Me.CutTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutTool.Name = "CutTool"
        Me.CutTool.Size = New System.Drawing.Size(23, 22)
        Me.CutTool.Text = "C&ut"
        '
        'CopyTool
        '
        Me.CopyTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyTool.Enabled = False
        Me.CopyTool.Image = Global.ZAMNEditor.My.Resources.Resources.Copy
        Me.CopyTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyTool.Name = "CopyTool"
        Me.CopyTool.Size = New System.Drawing.Size(23, 22)
        Me.CopyTool.Text = "&Copy"
        '
        'PasteTool
        '
        Me.PasteTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteTool.Enabled = False
        Me.PasteTool.Image = Global.ZAMNEditor.My.Resources.Resources.Paste
        Me.PasteTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteTool.Name = "PasteTool"
        Me.PasteTool.Size = New System.Drawing.Size(23, 22)
        Me.PasteTool.Text = "&Paste"
        '
        'UndoTool
        '
        Me.UndoTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UndoTool.Enabled = False
        Me.UndoTool.Image = Global.ZAMNEditor.My.Resources.Resources.Undo
        Me.UndoTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoTool.Name = "UndoTool"
        Me.UndoTool.Size = New System.Drawing.Size(32, 22)
        Me.UndoTool.Text = "Undo"
        '
        'RedoTool
        '
        Me.RedoTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RedoTool.Enabled = False
        Me.RedoTool.Image = Global.ZAMNEditor.My.Resources.Resources.Redo
        Me.RedoTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RedoTool.Name = "RedoTool"
        Me.RedoTool.Size = New System.Drawing.Size(32, 22)
        Me.RedoTool.Text = "Redo"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Zoom1Tool
        '
        Me.Zoom1Tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Zoom1Tool.Image = Global.ZAMNEditor.My.Resources.Resources.MagnifyingGlass
        Me.Zoom1Tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Zoom1Tool.Name = "Zoom1Tool"
        Me.Zoom1Tool.Size = New System.Drawing.Size(23, 22)
        Me.Zoom1Tool.Text = "Zoom 100%"
        '
        'Zoom
        '
        Me.Zoom.Items.AddRange(New Object() {"100%", "75%", "50%"})
        Me.Zoom.Name = "Zoom"
        Me.Zoom.Size = New System.Drawing.Size(75, 25)
        Me.Zoom.Text = "100%"
        '
        'toolStripSeparator8
        '
        Me.toolStripSeparator8.Name = "toolStripSeparator8"
        Me.toolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'BrushTool
        '
        Me.BrushTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BrushTool.Image = Global.ZAMNEditor.My.Resources.Resources.Brush
        Me.BrushTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BrushTool.Name = "BrushTool"
        Me.BrushTool.Size = New System.Drawing.Size(23, 22)
        Me.BrushTool.Text = "Paint Brush"
        '
        'TileSgstTool
        '
        Me.TileSgstTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TileSgstTool.Image = Global.ZAMNEditor.My.Resources.Resources.lightbulb
        Me.TileSgstTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TileSgstTool.Name = "TileSgstTool"
        Me.TileSgstTool.Size = New System.Drawing.Size(23, 22)
        Me.TileSgstTool.Text = "Tile Suggest"
        '
        'RectangleTool
        '
        Me.RectangleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RectangleTool.Image = Global.ZAMNEditor.My.Resources.Resources.Selection
        Me.RectangleTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RectangleTool.Name = "RectangleTool"
        Me.RectangleTool.Size = New System.Drawing.Size(23, 22)
        Me.RectangleTool.Text = "Rectangle Select"
        '
        'PencilTool
        '
        Me.PencilTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PencilTool.Image = Global.ZAMNEditor.My.Resources.Resources.PencilSelect
        Me.PencilTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PencilTool.Name = "PencilTool"
        Me.PencilTool.Size = New System.Drawing.Size(23, 22)
        Me.PencilTool.Text = "Pencil Select"
        '
        'TileSlctTool
        '
        Me.TileSlctTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TileSlctTool.Image = Global.ZAMNEditor.My.Resources.Resources.TileSelect
        Me.TileSlctTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TileSlctTool.Name = "TileSlctTool"
        Me.TileSlctTool.Size = New System.Drawing.Size(23, 22)
        Me.TileSlctTool.Text = "Tile Select"
        '
        'ItemTool
        '
        Me.ItemTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ItemTool.Image = Global.ZAMNEditor.My.Resources.Resources.FirstAidKit
        Me.ItemTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItemTool.Name = "ItemTool"
        Me.ItemTool.Size = New System.Drawing.Size(23, 22)
        Me.ItemTool.Text = "Item Tool"
        '
        'VictimTool
        '
        Me.VictimTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.VictimTool.Image = Global.ZAMNEditor.My.Resources.Resources.Dog
        Me.VictimTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.VictimTool.Name = "VictimTool"
        Me.VictimTool.Size = New System.Drawing.Size(23, 22)
        Me.VictimTool.Text = "Victim Tool"
        '
        'NRMTool
        '
        Me.NRMTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NRMTool.Image = Global.ZAMNEditor.My.Resources.Resources.Chainsaw
        Me.NRMTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NRMTool.Name = "NRMTool"
        Me.NRMTool.Size = New System.Drawing.Size(23, 22)
        Me.NRMTool.Text = "Non-Respawning Monster Tool"
        '
        'MonTool
        '
        Me.MonTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MonTool.Image = Global.ZAMNEditor.My.Resources.Resources.Zombie
        Me.MonTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MonTool.Name = "MonTool"
        Me.MonTool.Size = New System.Drawing.Size(23, 22)
        Me.MonTool.Text = "Monster Tool"
        '
        'BMonTool
        '
        Me.BMonTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BMonTool.Image = Global.ZAMNEditor.My.Resources.Resources.DrTongue
        Me.BMonTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BMonTool.Name = "BMonTool"
        Me.BMonTool.Size = New System.Drawing.Size(23, 22)
        Me.BMonTool.Text = "Boss Monsters"
        '
        'SprTool
        '
        Me.SprTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SprTool.Image = CType(resources.GetObject("SprTool.Image"), System.Drawing.Image)
        Me.SprTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SprTool.Name = "SprTool"
        Me.SprTool.Size = New System.Drawing.Size(23, 22)
        Me.SprTool.Text = "Sprites"
        Me.SprTool.Visible = False
        '
        'OpenROM
        '
        Me.OpenROM.DefaultExt = "smc"
        Me.OpenROM.Filter = "SNES ROM Files (*.sfc;*.smc)|*.sfc;*.smc|All Files (*.*)|*.*"
        '
        'ImportLevel
        '
        Me.ImportLevel.Filter = "ZAMN Level Files (*.zl)|*.zl"
        '
        'ExportLevel
        '
        Me.ExportLevel.Filter = "ZAMN Level Files (*.zl)|*.zl"
        '
        'OpenEmulator
        '
        Me.OpenEmulator.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*"
        '
        'SavePNG
        '
        Me.SavePNG.Filter = "PNG Images (*.png)|*.png|All Files (*.*)|*.*"
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 435)
        Me.Controls.Add(Me.TSContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Editor"
        Me.Text = "ZAMN Level Editor"
        Me.TSContainer.ContentPanel.ResumeLayout(False)
        Me.TSContainer.TopToolStripPanel.ResumeLayout(False)
        Me.TSContainer.TopToolStripPanel.PerformLayout()
        Me.TSContainer.ResumeLayout(False)
        Me.TSContainer.PerformLayout()
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.Tools.ResumeLayout(False)
        Me.Tools.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TSContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditRedo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tools As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileOpenLevel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenROM As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BrushTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewGrid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tabs As ZAMNEditor.Tabs
    Friend WithEvents ToolsRectangleSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RectangleTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsPencilSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PencilTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents TileSlctTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsTileSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSelectNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsTileSuggest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileSgstTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ItemTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VictimTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsVictims As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewPriority As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenLevelTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents NRMTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsNRMonsters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RecentROMs As ZAMNEditor.RecentFilesList
    Friend WithEvents ToolsMonsters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsPaintBrush As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolsBossMonsters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BMonTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditPasswords As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LevelMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LevelImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LevelExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LevelSettingsM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportLevel As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ExportLevel As System.Windows.Forms.SaveFileDialog
    Friend WithEvents LevelCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LevelPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoTool As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents RedoTool As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents LevelEditTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LevelDebugTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebugCopyTileset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpContents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebugFillSelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileEmulator As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmulatorRunROM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmulatorFromLevel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmulatorSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenEmulator As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Zoom1Tool As System.Windows.Forms.ToolStripButton
    Friend WithEvents Zoom As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ViewZoomIn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewZoomOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SprTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents SpritesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebugDecompress As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebugCompress As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebugFixTileAnim As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewAnimate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewNextFrame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewRestartAnimation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LevelSaveAsPNG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SavePNG As System.Windows.Forms.SaveFileDialog

End Class
