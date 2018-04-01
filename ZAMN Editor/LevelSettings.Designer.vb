<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LevelSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grpTileset = New System.Windows.Forms.GroupBox()
        Me.pnlUnk = New System.Windows.Forms.Panel()
        Me.radUnkAuto = New System.Windows.Forms.RadioButton()
        Me.radUnkMan = New System.Windows.Forms.RadioButton()
        Me.nudUnk = New System.Windows.Forms.NumericUpDown()
        Me.pnlCol = New System.Windows.Forms.Panel()
        Me.radColAuto = New System.Windows.Forms.RadioButton()
        Me.radColMan = New System.Windows.Forms.RadioButton()
        Me.pnlGFX = New System.Windows.Forms.Panel()
        Me.radGFXAuto = New System.Windows.Forms.RadioButton()
        Me.radGFXMan = New System.Windows.Forms.RadioButton()
        Me.pnlPal = New System.Windows.Forms.Panel()
        Me.radPalAuto = New System.Windows.Forms.RadioButton()
        Me.cboPal = New System.Windows.Forms.ComboBox()
        Me.radPalMan = New System.Windows.Forms.RadioButton()
        Me.pnlTiles = New System.Windows.Forms.Panel()
        Me.cboTiles = New System.Windows.Forms.ComboBox()
        Me.radTilesAuto = New System.Windows.Forms.RadioButton()
        Me.radTilesMan = New System.Windows.Forms.RadioButton()
        Me.lblUnknown = New System.Windows.Forms.Label()
        Me.lblCollision = New System.Windows.Forms.Label()
        Me.lblGraphics = New System.Windows.Forms.Label()
        Me.lblPalette = New System.Windows.Forms.Label()
        Me.lblTiles = New System.Windows.Forms.Label()
        Me.grpOther = New System.Windows.Forms.GroupBox()
        Me.pnlUnk3 = New System.Windows.Forms.Panel()
        Me.nudUnk3 = New System.Windows.Forms.NumericUpDown()
        Me.radUnk3Auto = New System.Windows.Forms.RadioButton()
        Me.radUnk3Man = New System.Windows.Forms.RadioButton()
        Me.pnlMusic = New System.Windows.Forms.Panel()
        Me.cboMusic = New System.Windows.Forms.ComboBox()
        Me.radMusicMan = New System.Windows.Forms.RadioButton()
        Me.nudMusic = New System.Windows.Forms.NumericUpDown()
        Me.radMusicAuto = New System.Windows.Forms.RadioButton()
        Me.pnlPAnim = New System.Windows.Forms.Panel()
        Me.cboPltAnim = New System.Windows.Forms.ComboBox()
        Me.radPAnimAuto = New System.Windows.Forms.RadioButton()
        Me.radPAnimMan = New System.Windows.Forms.RadioButton()
        Me.pnlSPal = New System.Windows.Forms.Panel()
        Me.radSPalAuto = New System.Windows.Forms.RadioButton()
        Me.radSPalMan = New System.Windows.Forms.RadioButton()
        Me.lblMusic = New System.Windows.Forms.Label()
        Me.lblUnknown3 = New System.Windows.Forms.Label()
        Me.lblPalAnim = New System.Windows.Forms.Label()
        Me.lblSpritePal = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.grpBonuses = New System.Windows.Forms.GroupBox()
        Me.btnDeleteBonus = New System.Windows.Forms.Button()
        Me.btnAddBonus = New System.Windows.Forms.Button()
        Me.nudCustBonus = New System.Windows.Forms.NumericUpDown()
        Me.lstCustomBonuses = New System.Windows.Forms.ListBox()
        Me.lblCustomBonuses = New System.Windows.Forms.Label()
        Me.lstBonuses = New System.Windows.Forms.CheckedListBox()
        Me.grpPltFade = New System.Windows.Forms.GroupBox()
        Me.pnlPalF = New System.Windows.Forms.Panel()
        Me.radPalAutoF = New System.Windows.Forms.RadioButton()
        Me.cboPalF = New System.Windows.Forms.ComboBox()
        Me.radPalManF = New System.Windows.Forms.RadioButton()
        Me.lblPaletteF = New System.Windows.Forms.Label()
        Me.chkPltFade = New System.Windows.Forms.CheckBox()
        Me.grpTileAnimation = New System.Windows.Forms.GroupBox()
        Me.btnPresetTileAnim = New System.Windows.Forms.Button()
        Me.cboTileAnim = New System.Windows.Forms.ComboBox()
        Me.btnImportTileAnim = New System.Windows.Forms.Button()
        Me.btnExportTileAnim = New System.Windows.Forms.Button()
        Me.btnDeleteTileAnim = New System.Windows.Forms.Button()
        Me.saveTileAnim = New System.Windows.Forms.SaveFileDialog()
        Me.openTileAnim = New System.Windows.Forms.OpenFileDialog()
        Me.addrTiles = New System.Windows.Forms.NumericUpDown()
        Me.addrPal = New System.Windows.Forms.NumericUpDown()
        Me.addrGFX = New System.Windows.Forms.NumericUpDown()
        Me.addrCol = New System.Windows.Forms.NumericUpDown()
        Me.addrSPal = New System.Windows.Forms.NumericUpDown()
        Me.addrPAnim = New System.Windows.Forms.NumericUpDown()
        Me.addrPalF = New System.Windows.Forms.NumericUpDown()
        Me.AddressUpDown8 = New ZAMNEditor.AddressUpDown()
        Me.AddressUpDown6 = New ZAMNEditor.AddressUpDown()
        Me.AddressUpDown5 = New ZAMNEditor.AddressUpDown()
        Me.AddressUpDown4 = New ZAMNEditor.AddressUpDown()
        Me.AddressUpDown3 = New ZAMNEditor.AddressUpDown()
        Me.AddressUpDown2 = New ZAMNEditor.AddressUpDown()
        Me.AddressUpDown1 = New ZAMNEditor.AddressUpDown()
        Me.grpTileset.SuspendLayout()
        Me.pnlUnk.SuspendLayout()
        CType(Me.nudUnk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCol.SuspendLayout()
        Me.pnlGFX.SuspendLayout()
        Me.pnlPal.SuspendLayout()
        Me.pnlTiles.SuspendLayout()
        Me.grpOther.SuspendLayout()
        Me.pnlUnk3.SuspendLayout()
        CType(Me.nudUnk3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMusic.SuspendLayout()
        CType(Me.nudMusic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPAnim.SuspendLayout()
        Me.pnlSPal.SuspendLayout()
        Me.grpBonuses.SuspendLayout()
        CType(Me.nudCustBonus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPltFade.SuspendLayout()
        Me.pnlPalF.SuspendLayout()
        Me.grpTileAnimation.SuspendLayout()
        CType(Me.addrTiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.addrPal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.addrGFX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.addrCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.addrSPal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.addrPAnim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.addrPalF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpTileset
        '
        Me.grpTileset.Controls.Add(Me.pnlUnk)
        Me.grpTileset.Controls.Add(Me.pnlCol)
        Me.grpTileset.Controls.Add(Me.pnlGFX)
        Me.grpTileset.Controls.Add(Me.pnlPal)
        Me.grpTileset.Controls.Add(Me.pnlTiles)
        Me.grpTileset.Controls.Add(Me.lblUnknown)
        Me.grpTileset.Controls.Add(Me.lblCollision)
        Me.grpTileset.Controls.Add(Me.lblGraphics)
        Me.grpTileset.Controls.Add(Me.lblPalette)
        Me.grpTileset.Controls.Add(Me.lblTiles)
        Me.grpTileset.Location = New System.Drawing.Point(12, 12)
        Me.grpTileset.Name = "grpTileset"
        Me.grpTileset.Size = New System.Drawing.Size(378, 165)
        Me.grpTileset.TabIndex = 0
        Me.grpTileset.TabStop = False
        Me.grpTileset.Text = "Tileset"
        '
        'pnlUnk
        '
        Me.pnlUnk.Controls.Add(Me.radUnkAuto)
        Me.pnlUnk.Controls.Add(Me.radUnkMan)
        Me.pnlUnk.Controls.Add(Me.nudUnk)
        Me.pnlUnk.Location = New System.Drawing.Point(65, 134)
        Me.pnlUnk.Name = "pnlUnk"
        Me.pnlUnk.Size = New System.Drawing.Size(307, 21)
        Me.pnlUnk.TabIndex = 5
        '
        'radUnkAuto
        '
        Me.radUnkAuto.AutoSize = True
        Me.radUnkAuto.Location = New System.Drawing.Point(3, 3)
        Me.radUnkAuto.Name = "radUnkAuto"
        Me.radUnkAuto.Size = New System.Drawing.Size(72, 17)
        Me.radUnkAuto.TabIndex = 19
        Me.radUnkAuto.TabStop = True
        Me.radUnkAuto.Text = "Automatic"
        Me.radUnkAuto.UseVisualStyleBackColor = True
        '
        'radUnkMan
        '
        Me.radUnkMan.AutoSize = True
        Me.radUnkMan.Location = New System.Drawing.Point(142, 5)
        Me.radUnkMan.Name = "radUnkMan"
        Me.radUnkMan.Size = New System.Drawing.Size(14, 13)
        Me.radUnkMan.TabIndex = 20
        Me.radUnkMan.TabStop = True
        Me.radUnkMan.UseVisualStyleBackColor = True
        '
        'nudUnk
        '
        Me.nudUnk.Hexadecimal = True
        Me.nudUnk.Location = New System.Drawing.Point(180, 0)
        Me.nudUnk.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudUnk.Name = "nudUnk"
        Me.nudUnk.Size = New System.Drawing.Size(77, 20)
        Me.nudUnk.TabIndex = 21
        '
        'pnlCol
        '
        Me.pnlCol.Controls.Add(Me.AddressUpDown4)
        Me.pnlCol.Controls.Add(Me.addrCol)
        Me.pnlCol.Controls.Add(Me.radColAuto)
        Me.pnlCol.Controls.Add(Me.radColMan)
        Me.pnlCol.Location = New System.Drawing.Point(65, 107)
        Me.pnlCol.Name = "pnlCol"
        Me.pnlCol.Size = New System.Drawing.Size(307, 21)
        Me.pnlCol.TabIndex = 5
        '
        'radColAuto
        '
        Me.radColAuto.AutoSize = True
        Me.radColAuto.Location = New System.Drawing.Point(3, 3)
        Me.radColAuto.Name = "radColAuto"
        Me.radColAuto.Size = New System.Drawing.Size(72, 17)
        Me.radColAuto.TabIndex = 15
        Me.radColAuto.TabStop = True
        Me.radColAuto.Text = "Automatic"
        Me.radColAuto.UseVisualStyleBackColor = True
        '
        'radColMan
        '
        Me.radColMan.AutoSize = True
        Me.radColMan.Location = New System.Drawing.Point(142, 3)
        Me.radColMan.Name = "radColMan"
        Me.radColMan.Size = New System.Drawing.Size(14, 13)
        Me.radColMan.TabIndex = 16
        Me.radColMan.TabStop = True
        Me.radColMan.UseVisualStyleBackColor = True
        '
        'pnlGFX
        '
        Me.pnlGFX.Controls.Add(Me.AddressUpDown3)
        Me.pnlGFX.Controls.Add(Me.addrGFX)
        Me.pnlGFX.Controls.Add(Me.radGFXAuto)
        Me.pnlGFX.Controls.Add(Me.radGFXMan)
        Me.pnlGFX.Location = New System.Drawing.Point(65, 80)
        Me.pnlGFX.Name = "pnlGFX"
        Me.pnlGFX.Size = New System.Drawing.Size(307, 21)
        Me.pnlGFX.TabIndex = 5
        '
        'radGFXAuto
        '
        Me.radGFXAuto.AutoSize = True
        Me.radGFXAuto.Location = New System.Drawing.Point(3, 3)
        Me.radGFXAuto.Name = "radGFXAuto"
        Me.radGFXAuto.Size = New System.Drawing.Size(72, 17)
        Me.radGFXAuto.TabIndex = 10
        Me.radGFXAuto.TabStop = True
        Me.radGFXAuto.Text = "Automatic"
        Me.radGFXAuto.UseVisualStyleBackColor = True
        '
        'radGFXMan
        '
        Me.radGFXMan.AutoSize = True
        Me.radGFXMan.Location = New System.Drawing.Point(142, 3)
        Me.radGFXMan.Name = "radGFXMan"
        Me.radGFXMan.Size = New System.Drawing.Size(14, 13)
        Me.radGFXMan.TabIndex = 12
        Me.radGFXMan.TabStop = True
        Me.radGFXMan.UseVisualStyleBackColor = True
        '
        'pnlPal
        '
        Me.pnlPal.Controls.Add(Me.AddressUpDown2)
        Me.pnlPal.Controls.Add(Me.addrPal)
        Me.pnlPal.Controls.Add(Me.radPalAuto)
        Me.pnlPal.Controls.Add(Me.cboPal)
        Me.pnlPal.Controls.Add(Me.radPalMan)
        Me.pnlPal.Location = New System.Drawing.Point(65, 53)
        Me.pnlPal.Name = "pnlPal"
        Me.pnlPal.Size = New System.Drawing.Size(307, 21)
        Me.pnlPal.TabIndex = 5
        '
        'radPalAuto
        '
        Me.radPalAuto.AutoSize = True
        Me.radPalAuto.Location = New System.Drawing.Point(3, 3)
        Me.radPalAuto.Name = "radPalAuto"
        Me.radPalAuto.Size = New System.Drawing.Size(14, 13)
        Me.radPalAuto.TabIndex = 5
        Me.radPalAuto.TabStop = True
        Me.radPalAuto.UseVisualStyleBackColor = True
        '
        'cboPal
        '
        Me.cboPal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPal.FormattingEnabled = True
        Me.cboPal.Location = New System.Drawing.Point(23, 0)
        Me.cboPal.Name = "cboPal"
        Me.cboPal.Size = New System.Drawing.Size(103, 21)
        Me.cboPal.TabIndex = 6
        '
        'radPalMan
        '
        Me.radPalMan.AutoSize = True
        Me.radPalMan.Location = New System.Drawing.Point(142, 3)
        Me.radPalMan.Name = "radPalMan"
        Me.radPalMan.Size = New System.Drawing.Size(14, 13)
        Me.radPalMan.TabIndex = 7
        Me.radPalMan.TabStop = True
        Me.radPalMan.UseVisualStyleBackColor = True
        '
        'pnlTiles
        '
        Me.pnlTiles.Controls.Add(Me.AddressUpDown1)
        Me.pnlTiles.Controls.Add(Me.addrTiles)
        Me.pnlTiles.Controls.Add(Me.cboTiles)
        Me.pnlTiles.Controls.Add(Me.radTilesAuto)
        Me.pnlTiles.Controls.Add(Me.radTilesMan)
        Me.pnlTiles.Location = New System.Drawing.Point(65, 26)
        Me.pnlTiles.Name = "pnlTiles"
        Me.pnlTiles.Size = New System.Drawing.Size(307, 21)
        Me.pnlTiles.TabIndex = 2
        '
        'cboTiles
        '
        Me.cboTiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTiles.FormattingEnabled = True
        Me.cboTiles.Items.AddRange(New Object() {"Grass", "Mall/Factory", "Castle", "Office", "Beach/Pyramid"})
        Me.cboTiles.Location = New System.Drawing.Point(23, 0)
        Me.cboTiles.Name = "cboTiles"
        Me.cboTiles.Size = New System.Drawing.Size(103, 21)
        Me.cboTiles.TabIndex = 2
        '
        'radTilesAuto
        '
        Me.radTilesAuto.AutoSize = True
        Me.radTilesAuto.Location = New System.Drawing.Point(3, 3)
        Me.radTilesAuto.Name = "radTilesAuto"
        Me.radTilesAuto.Size = New System.Drawing.Size(14, 13)
        Me.radTilesAuto.TabIndex = 1
        Me.radTilesAuto.TabStop = True
        Me.radTilesAuto.UseVisualStyleBackColor = True
        '
        'radTilesMan
        '
        Me.radTilesMan.AutoSize = True
        Me.radTilesMan.Location = New System.Drawing.Point(142, 3)
        Me.radTilesMan.Name = "radTilesMan"
        Me.radTilesMan.Size = New System.Drawing.Size(14, 13)
        Me.radTilesMan.TabIndex = 3
        Me.radTilesMan.TabStop = True
        Me.radTilesMan.UseVisualStyleBackColor = True
        '
        'lblUnknown
        '
        Me.lblUnknown.AutoSize = True
        Me.lblUnknown.Location = New System.Drawing.Point(6, 139)
        Me.lblUnknown.Name = "lblUnknown"
        Me.lblUnknown.Size = New System.Drawing.Size(56, 13)
        Me.lblUnknown.TabIndex = 18
        Me.lblUnknown.Text = "Unknown:"
        '
        'lblCollision
        '
        Me.lblCollision.AutoSize = True
        Me.lblCollision.Location = New System.Drawing.Point(6, 112)
        Me.lblCollision.Name = "lblCollision"
        Me.lblCollision.Size = New System.Drawing.Size(48, 13)
        Me.lblCollision.TabIndex = 14
        Me.lblCollision.Text = "Collision:"
        '
        'lblGraphics
        '
        Me.lblGraphics.AutoSize = True
        Me.lblGraphics.Location = New System.Drawing.Point(6, 85)
        Me.lblGraphics.Name = "lblGraphics"
        Me.lblGraphics.Size = New System.Drawing.Size(52, 13)
        Me.lblGraphics.TabIndex = 9
        Me.lblGraphics.Text = "Graphics:"
        '
        'lblPalette
        '
        Me.lblPalette.AutoSize = True
        Me.lblPalette.Location = New System.Drawing.Point(6, 56)
        Me.lblPalette.Name = "lblPalette"
        Me.lblPalette.Size = New System.Drawing.Size(43, 13)
        Me.lblPalette.TabIndex = 4
        Me.lblPalette.Text = "Palette:"
        '
        'lblTiles
        '
        Me.lblTiles.AutoSize = True
        Me.lblTiles.Location = New System.Drawing.Point(6, 29)
        Me.lblTiles.Name = "lblTiles"
        Me.lblTiles.Size = New System.Drawing.Size(32, 13)
        Me.lblTiles.TabIndex = 1
        Me.lblTiles.Text = "Tiles:"
        '
        'grpOther
        '
        Me.grpOther.Controls.Add(Me.pnlUnk3)
        Me.grpOther.Controls.Add(Me.pnlMusic)
        Me.grpOther.Controls.Add(Me.pnlPAnim)
        Me.grpOther.Controls.Add(Me.pnlSPal)
        Me.grpOther.Controls.Add(Me.lblMusic)
        Me.grpOther.Controls.Add(Me.lblUnknown3)
        Me.grpOther.Controls.Add(Me.lblPalAnim)
        Me.grpOther.Controls.Add(Me.lblSpritePal)
        Me.grpOther.Location = New System.Drawing.Point(12, 183)
        Me.grpOther.Name = "grpOther"
        Me.grpOther.Size = New System.Drawing.Size(378, 140)
        Me.grpOther.TabIndex = 1
        Me.grpOther.TabStop = False
        Me.grpOther.Text = "Other"
        '
        'pnlUnk3
        '
        Me.pnlUnk3.Controls.Add(Me.nudUnk3)
        Me.pnlUnk3.Controls.Add(Me.radUnk3Auto)
        Me.pnlUnk3.Controls.Add(Me.radUnk3Man)
        Me.pnlUnk3.Location = New System.Drawing.Point(65, 107)
        Me.pnlUnk3.Name = "pnlUnk3"
        Me.pnlUnk3.Size = New System.Drawing.Size(307, 21)
        Me.pnlUnk3.TabIndex = 4
        '
        'nudUnk3
        '
        Me.nudUnk3.Hexadecimal = True
        Me.nudUnk3.Location = New System.Drawing.Point(180, 0)
        Me.nudUnk3.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudUnk3.Name = "nudUnk3"
        Me.nudUnk3.Size = New System.Drawing.Size(77, 20)
        Me.nudUnk3.TabIndex = 36
        '
        'radUnk3Auto
        '
        Me.radUnk3Auto.AutoSize = True
        Me.radUnk3Auto.Location = New System.Drawing.Point(0, 4)
        Me.radUnk3Auto.Name = "radUnk3Auto"
        Me.radUnk3Auto.Size = New System.Drawing.Size(72, 17)
        Me.radUnk3Auto.TabIndex = 27
        Me.radUnk3Auto.TabStop = True
        Me.radUnk3Auto.Text = "Automatic"
        Me.radUnk3Auto.UseVisualStyleBackColor = True
        '
        'radUnk3Man
        '
        Me.radUnk3Man.AutoSize = True
        Me.radUnk3Man.Location = New System.Drawing.Point(142, 2)
        Me.radUnk3Man.Name = "radUnk3Man"
        Me.radUnk3Man.Size = New System.Drawing.Size(14, 13)
        Me.radUnk3Man.TabIndex = 28
        Me.radUnk3Man.TabStop = True
        Me.radUnk3Man.UseVisualStyleBackColor = True
        '
        'pnlMusic
        '
        Me.pnlMusic.Controls.Add(Me.cboMusic)
        Me.pnlMusic.Controls.Add(Me.radMusicMan)
        Me.pnlMusic.Controls.Add(Me.nudMusic)
        Me.pnlMusic.Controls.Add(Me.radMusicAuto)
        Me.pnlMusic.Location = New System.Drawing.Point(65, 80)
        Me.pnlMusic.Name = "pnlMusic"
        Me.pnlMusic.Size = New System.Drawing.Size(307, 21)
        Me.pnlMusic.TabIndex = 5
        '
        'cboMusic
        '
        Me.cboMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMusic.DropDownWidth = 130
        Me.cboMusic.FormattingEnabled = True
        Me.cboMusic.Items.AddRange(New Object() {"Evening of the Undead", "Title Screen", "Pyramid of Fear", "Terror in Aisle Five", "Zombie Panic", "Chainsaw Mayhem", "Mars Needs Cheerleaders", "Dr. Tongue's Castle", "Mushroom men", "The son of Dr. Tongue", "Unused Song"})
        Me.cboMusic.Location = New System.Drawing.Point(23, 0)
        Me.cboMusic.Name = "cboMusic"
        Me.cboMusic.Size = New System.Drawing.Size(103, 21)
        Me.cboMusic.TabIndex = 35
        '
        'radMusicMan
        '
        Me.radMusicMan.AutoSize = True
        Me.radMusicMan.Location = New System.Drawing.Point(142, 3)
        Me.radMusicMan.Name = "radMusicMan"
        Me.radMusicMan.Size = New System.Drawing.Size(14, 13)
        Me.radMusicMan.TabIndex = 32
        Me.radMusicMan.TabStop = True
        Me.radMusicMan.UseVisualStyleBackColor = True
        '
        'nudMusic
        '
        Me.nudMusic.Hexadecimal = True
        Me.nudMusic.Location = New System.Drawing.Point(180, 1)
        Me.nudMusic.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudMusic.Name = "nudMusic"
        Me.nudMusic.Size = New System.Drawing.Size(77, 20)
        Me.nudMusic.TabIndex = 33
        '
        'radMusicAuto
        '
        Me.radMusicAuto.AutoSize = True
        Me.radMusicAuto.Location = New System.Drawing.Point(3, 3)
        Me.radMusicAuto.Name = "radMusicAuto"
        Me.radMusicAuto.Size = New System.Drawing.Size(14, 13)
        Me.radMusicAuto.TabIndex = 34
        Me.radMusicAuto.TabStop = True
        Me.radMusicAuto.UseVisualStyleBackColor = True
        '
        'pnlPAnim
        '
        Me.pnlPAnim.Controls.Add(Me.AddressUpDown6)
        Me.pnlPAnim.Controls.Add(Me.addrPAnim)
        Me.pnlPAnim.Controls.Add(Me.cboPltAnim)
        Me.pnlPAnim.Controls.Add(Me.radPAnimAuto)
        Me.pnlPAnim.Controls.Add(Me.radPAnimMan)
        Me.pnlPAnim.Location = New System.Drawing.Point(65, 53)
        Me.pnlPAnim.Name = "pnlPAnim"
        Me.pnlPAnim.Size = New System.Drawing.Size(307, 21)
        Me.pnlPAnim.TabIndex = 5
        '
        'cboPltAnim
        '
        Me.cboPltAnim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPltAnim.FormattingEnabled = True
        Me.cboPltAnim.Items.AddRange(New Object() {"None", "Castle", "Grass", "Beach", "Pyramid", "Fire Cave"})
        Me.cboPltAnim.Location = New System.Drawing.Point(23, 0)
        Me.cboPltAnim.Name = "cboPltAnim"
        Me.cboPltAnim.Size = New System.Drawing.Size(103, 21)
        Me.cboPltAnim.TabIndex = 9
        '
        'radPAnimAuto
        '
        Me.radPAnimAuto.AutoSize = True
        Me.radPAnimAuto.Location = New System.Drawing.Point(3, 3)
        Me.radPAnimAuto.Name = "radPAnimAuto"
        Me.radPAnimAuto.Size = New System.Drawing.Size(14, 13)
        Me.radPAnimAuto.TabIndex = 23
        Me.radPAnimAuto.TabStop = True
        Me.radPAnimAuto.UseVisualStyleBackColor = True
        '
        'radPAnimMan
        '
        Me.radPAnimMan.AutoSize = True
        Me.radPAnimMan.Location = New System.Drawing.Point(142, 3)
        Me.radPAnimMan.Name = "radPAnimMan"
        Me.radPAnimMan.Size = New System.Drawing.Size(14, 13)
        Me.radPAnimMan.TabIndex = 24
        Me.radPAnimMan.TabStop = True
        Me.radPAnimMan.UseVisualStyleBackColor = True
        '
        'pnlSPal
        '
        Me.pnlSPal.Controls.Add(Me.AddressUpDown5)
        Me.pnlSPal.Controls.Add(Me.addrSPal)
        Me.pnlSPal.Controls.Add(Me.radSPalAuto)
        Me.pnlSPal.Controls.Add(Me.radSPalMan)
        Me.pnlSPal.Location = New System.Drawing.Point(65, 26)
        Me.pnlSPal.Name = "pnlSPal"
        Me.pnlSPal.Size = New System.Drawing.Size(307, 21)
        Me.pnlSPal.TabIndex = 5
        '
        'radSPalAuto
        '
        Me.radSPalAuto.AutoSize = True
        Me.radSPalAuto.Location = New System.Drawing.Point(3, 3)
        Me.radSPalAuto.Name = "radSPalAuto"
        Me.radSPalAuto.Size = New System.Drawing.Size(72, 17)
        Me.radSPalAuto.TabIndex = 19
        Me.radSPalAuto.TabStop = True
        Me.radSPalAuto.Text = "Automatic"
        Me.radSPalAuto.UseVisualStyleBackColor = True
        '
        'radSPalMan
        '
        Me.radSPalMan.AutoSize = True
        Me.radSPalMan.Location = New System.Drawing.Point(142, 3)
        Me.radSPalMan.Name = "radSPalMan"
        Me.radSPalMan.Size = New System.Drawing.Size(14, 13)
        Me.radSPalMan.TabIndex = 20
        Me.radSPalMan.TabStop = True
        Me.radSPalMan.UseVisualStyleBackColor = True
        '
        'lblMusic
        '
        Me.lblMusic.AutoSize = True
        Me.lblMusic.Location = New System.Drawing.Point(6, 83)
        Me.lblMusic.Name = "lblMusic"
        Me.lblMusic.Size = New System.Drawing.Size(38, 13)
        Me.lblMusic.TabIndex = 30
        Me.lblMusic.Text = "Music:"
        '
        'lblUnknown3
        '
        Me.lblUnknown3.AutoSize = True
        Me.lblUnknown3.Location = New System.Drawing.Point(6, 113)
        Me.lblUnknown3.Name = "lblUnknown3"
        Me.lblUnknown3.Size = New System.Drawing.Size(56, 13)
        Me.lblUnknown3.TabIndex = 26
        Me.lblUnknown3.Text = "Unknown:"
        '
        'lblPalAnim
        '
        Me.lblPalAnim.AutoSize = True
        Me.lblPalAnim.Location = New System.Drawing.Point(6, 51)
        Me.lblPalAnim.Name = "lblPalAnim"
        Me.lblPalAnim.Size = New System.Drawing.Size(56, 26)
        Me.lblPalAnim.TabIndex = 22
        Me.lblPalAnim.Text = "Palette" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Animation:"
        '
        'lblSpritePal
        '
        Me.lblSpritePal.AutoSize = True
        Me.lblSpritePal.Location = New System.Drawing.Point(6, 21)
        Me.lblSpritePal.Name = "lblSpritePal"
        Me.lblSpritePal.Size = New System.Drawing.Size(43, 26)
        Me.lblSpritePal.TabIndex = 18
        Me.lblSpritePal.Text = "Sprite" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Palette:"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(494, 436)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(494, 494)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(494, 465)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 4
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'grpBonuses
        '
        Me.grpBonuses.Controls.Add(Me.btnDeleteBonus)
        Me.grpBonuses.Controls.Add(Me.btnAddBonus)
        Me.grpBonuses.Controls.Add(Me.nudCustBonus)
        Me.grpBonuses.Controls.Add(Me.lstCustomBonuses)
        Me.grpBonuses.Controls.Add(Me.lblCustomBonuses)
        Me.grpBonuses.Controls.Add(Me.lstBonuses)
        Me.grpBonuses.Location = New System.Drawing.Point(396, 12)
        Me.grpBonuses.Name = "grpBonuses"
        Me.grpBonuses.Size = New System.Drawing.Size(173, 355)
        Me.grpBonuses.TabIndex = 5
        Me.grpBonuses.TabStop = False
        Me.grpBonuses.Text = "Bonuses"
        '
        'btnDeleteBonus
        '
        Me.btnDeleteBonus.Image = Global.ZAMNEditor.My.Resources.Resources.Delete
        Me.btnDeleteBonus.Location = New System.Drawing.Point(132, 327)
        Me.btnDeleteBonus.Name = "btnDeleteBonus"
        Me.btnDeleteBonus.Size = New System.Drawing.Size(33, 23)
        Me.btnDeleteBonus.TabIndex = 9
        Me.btnDeleteBonus.UseVisualStyleBackColor = True
        '
        'btnAddBonus
        '
        Me.btnAddBonus.Image = Global.ZAMNEditor.My.Resources.Resources.Add
        Me.btnAddBonus.Location = New System.Drawing.Point(93, 327)
        Me.btnAddBonus.Name = "btnAddBonus"
        Me.btnAddBonus.Size = New System.Drawing.Size(33, 23)
        Me.btnAddBonus.TabIndex = 8
        Me.btnAddBonus.UseVisualStyleBackColor = True
        '
        'nudCustBonus
        '
        Me.nudCustBonus.Hexadecimal = True
        Me.nudCustBonus.Location = New System.Drawing.Point(6, 328)
        Me.nudCustBonus.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudCustBonus.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCustBonus.Name = "nudCustBonus"
        Me.nudCustBonus.Size = New System.Drawing.Size(81, 20)
        Me.nudCustBonus.TabIndex = 6
        Me.nudCustBonus.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lstCustomBonuses
        '
        Me.lstCustomBonuses.FormattingEnabled = True
        Me.lstCustomBonuses.Location = New System.Drawing.Point(6, 267)
        Me.lstCustomBonuses.Name = "lstCustomBonuses"
        Me.lstCustomBonuses.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstCustomBonuses.Size = New System.Drawing.Size(159, 56)
        Me.lstCustomBonuses.TabIndex = 7
        '
        'lblCustomBonuses
        '
        Me.lblCustomBonuses.AutoSize = True
        Me.lblCustomBonuses.Location = New System.Drawing.Point(6, 251)
        Me.lblCustomBonuses.Name = "lblCustomBonuses"
        Me.lblCustomBonuses.Size = New System.Drawing.Size(45, 13)
        Me.lblCustomBonuses.TabIndex = 6
        Me.lblCustomBonuses.Text = "Custom:"
        '
        'lstBonuses
        '
        Me.lstBonuses.CheckOnClick = True
        Me.lstBonuses.FormattingEnabled = True
        Me.lstBonuses.Items.AddRange(New Object() {"All Victims Saved", "Ten Cheerleader", "Massive Destruction", "Pass Completion", "Weed Cutting", "No Bazooka Fired", "Monster Frozen", "Extermination", "Chainsaw Begone", "Fish Fry", "Frankenstein Destroyed", "Martian Bubbled", "Alien Invasion Repulsed", "Vampire Destroyed", "Secret Bonus"})
        Me.lstBonuses.Location = New System.Drawing.Point(6, 19)
        Me.lstBonuses.Name = "lstBonuses"
        Me.lstBonuses.Size = New System.Drawing.Size(159, 229)
        Me.lstBonuses.TabIndex = 0
        '
        'grpPltFade
        '
        Me.grpPltFade.Controls.Add(Me.pnlPalF)
        Me.grpPltFade.Controls.Add(Me.lblPaletteF)
        Me.grpPltFade.Enabled = False
        Me.grpPltFade.Location = New System.Drawing.Point(12, 354)
        Me.grpPltFade.Name = "grpPltFade"
        Me.grpPltFade.Size = New System.Drawing.Size(378, 55)
        Me.grpPltFade.TabIndex = 6
        Me.grpPltFade.TabStop = False
        '
        'pnlPalF
        '
        Me.pnlPalF.Controls.Add(Me.AddressUpDown8)
        Me.pnlPalF.Controls.Add(Me.addrPalF)
        Me.pnlPalF.Controls.Add(Me.radPalAutoF)
        Me.pnlPalF.Controls.Add(Me.cboPalF)
        Me.pnlPalF.Controls.Add(Me.radPalManF)
        Me.pnlPalF.Location = New System.Drawing.Point(65, 20)
        Me.pnlPalF.Name = "pnlPalF"
        Me.pnlPalF.Size = New System.Drawing.Size(307, 21)
        Me.pnlPalF.TabIndex = 9
        '
        'radPalAutoF
        '
        Me.radPalAutoF.AutoSize = True
        Me.radPalAutoF.Checked = True
        Me.radPalAutoF.Location = New System.Drawing.Point(3, 3)
        Me.radPalAutoF.Name = "radPalAutoF"
        Me.radPalAutoF.Size = New System.Drawing.Size(14, 13)
        Me.radPalAutoF.TabIndex = 5
        Me.radPalAutoF.TabStop = True
        Me.radPalAutoF.UseVisualStyleBackColor = True
        '
        'cboPalF
        '
        Me.cboPalF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPalF.FormattingEnabled = True
        Me.cboPalF.Location = New System.Drawing.Point(23, 0)
        Me.cboPalF.Name = "cboPalF"
        Me.cboPalF.Size = New System.Drawing.Size(103, 21)
        Me.cboPalF.TabIndex = 6
        '
        'radPalManF
        '
        Me.radPalManF.AutoSize = True
        Me.radPalManF.Location = New System.Drawing.Point(142, 3)
        Me.radPalManF.Name = "radPalManF"
        Me.radPalManF.Size = New System.Drawing.Size(14, 13)
        Me.radPalManF.TabIndex = 7
        Me.radPalManF.UseVisualStyleBackColor = True
        '
        'lblPaletteF
        '
        Me.lblPaletteF.AutoSize = True
        Me.lblPaletteF.Location = New System.Drawing.Point(6, 23)
        Me.lblPaletteF.Name = "lblPaletteF"
        Me.lblPaletteF.Size = New System.Drawing.Size(43, 13)
        Me.lblPaletteF.TabIndex = 8
        Me.lblPaletteF.Text = "Palette:"
        '
        'chkPltFade
        '
        Me.chkPltFade.AutoSize = True
        Me.chkPltFade.Location = New System.Drawing.Point(21, 353)
        Me.chkPltFade.Name = "chkPltFade"
        Me.chkPltFade.Size = New System.Drawing.Size(86, 17)
        Me.chkPltFade.TabIndex = 7
        Me.chkPltFade.Text = "Palette Fade"
        Me.chkPltFade.UseVisualStyleBackColor = True
        '
        'grpTileAnimation
        '
        Me.grpTileAnimation.Controls.Add(Me.btnPresetTileAnim)
        Me.grpTileAnimation.Controls.Add(Me.cboTileAnim)
        Me.grpTileAnimation.Controls.Add(Me.btnImportTileAnim)
        Me.grpTileAnimation.Controls.Add(Me.btnExportTileAnim)
        Me.grpTileAnimation.Controls.Add(Me.btnDeleteTileAnim)
        Me.grpTileAnimation.Location = New System.Drawing.Point(12, 441)
        Me.grpTileAnimation.Name = "grpTileAnimation"
        Me.grpTileAnimation.Size = New System.Drawing.Size(378, 78)
        Me.grpTileAnimation.TabIndex = 8
        Me.grpTileAnimation.TabStop = False
        Me.grpTileAnimation.Text = "Tile Animation"
        '
        'btnPresetTileAnim
        '
        Me.btnPresetTileAnim.Location = New System.Drawing.Point(168, 19)
        Me.btnPresetTileAnim.Name = "btnPresetTileAnim"
        Me.btnPresetTileAnim.Size = New System.Drawing.Size(85, 23)
        Me.btnPresetTileAnim.TabIndex = 9
        Me.btnPresetTileAnim.Text = "Use Preset"
        Me.btnPresetTileAnim.UseVisualStyleBackColor = True
        '
        'cboTileAnim
        '
        Me.cboTileAnim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTileAnim.FormattingEnabled = True
        Me.cboTileAnim.Items.AddRange(New Object() {"Mall", "Factory", "Pyramid", "Castle electricity", "Castle spikes", "Castle spikes (unsynced)", "Castle weeds (fast)", "Castle weeds (slow)", "Castle weeds (very slow)"})
        Me.cboTileAnim.Location = New System.Drawing.Point(6, 19)
        Me.cboTileAnim.Name = "cboTileAnim"
        Me.cboTileAnim.Size = New System.Drawing.Size(156, 21)
        Me.cboTileAnim.TabIndex = 9
        '
        'btnImportTileAnim
        '
        Me.btnImportTileAnim.Location = New System.Drawing.Point(303, 19)
        Me.btnImportTileAnim.Name = "btnImportTileAnim"
        Me.btnImportTileAnim.Size = New System.Drawing.Size(69, 23)
        Me.btnImportTileAnim.TabIndex = 10
        Me.btnImportTileAnim.Text = "Import"
        Me.btnImportTileAnim.UseVisualStyleBackColor = True
        '
        'btnExportTileAnim
        '
        Me.btnExportTileAnim.Enabled = False
        Me.btnExportTileAnim.Location = New System.Drawing.Point(303, 46)
        Me.btnExportTileAnim.Name = "btnExportTileAnim"
        Me.btnExportTileAnim.Size = New System.Drawing.Size(69, 23)
        Me.btnExportTileAnim.TabIndex = 9
        Me.btnExportTileAnim.Text = "Export"
        Me.btnExportTileAnim.UseVisualStyleBackColor = True
        '
        'btnDeleteTileAnim
        '
        Me.btnDeleteTileAnim.Enabled = False
        Me.btnDeleteTileAnim.Location = New System.Drawing.Point(6, 46)
        Me.btnDeleteTileAnim.Name = "btnDeleteTileAnim"
        Me.btnDeleteTileAnim.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteTileAnim.TabIndex = 9
        Me.btnDeleteTileAnim.Text = "Delete"
        Me.btnDeleteTileAnim.UseVisualStyleBackColor = True
        '
        'saveTileAnim
        '
        Me.saveTileAnim.Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*"
        '
        'openTileAnim
        '
        Me.openTileAnim.Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*"
        '
        'addrTiles
        '
        Me.addrTiles.Hexadecimal = True
        Me.addrTiles.Location = New System.Drawing.Point(180, 3)
        Me.addrTiles.Maximum = New Decimal(New Integer() {4194304, 0, 0, 0})
        Me.addrTiles.Name = "addrTiles"
        Me.addrTiles.Size = New System.Drawing.Size(124, 20)
        Me.addrTiles.TabIndex = 4
        '
        'addrPal
        '
        Me.addrPal.Hexadecimal = True
        Me.addrPal.Location = New System.Drawing.Point(180, 3)
        Me.addrPal.Maximum = New Decimal(New Integer() {4194304, 0, 0, 0})
        Me.addrPal.Name = "addrPal"
        Me.addrPal.Size = New System.Drawing.Size(124, 20)
        Me.addrPal.TabIndex = 5
        '
        'addrGFX
        '
        Me.addrGFX.Hexadecimal = True
        Me.addrGFX.Location = New System.Drawing.Point(180, 2)
        Me.addrGFX.Maximum = New Decimal(New Integer() {4194304, 0, 0, 0})
        Me.addrGFX.Name = "addrGFX"
        Me.addrGFX.Size = New System.Drawing.Size(124, 20)
        Me.addrGFX.TabIndex = 8
        '
        'addrCol
        '
        Me.addrCol.Hexadecimal = True
        Me.addrCol.Location = New System.Drawing.Point(180, 0)
        Me.addrCol.Maximum = New Decimal(New Integer() {4194304, 0, 0, 0})
        Me.addrCol.Name = "addrCol"
        Me.addrCol.Size = New System.Drawing.Size(124, 20)
        Me.addrCol.TabIndex = 13
        '
        'addrSPal
        '
        Me.addrSPal.Hexadecimal = True
        Me.addrSPal.Location = New System.Drawing.Point(180, 3)
        Me.addrSPal.Maximum = New Decimal(New Integer() {4194304, 0, 0, 0})
        Me.addrSPal.Name = "addrSPal"
        Me.addrSPal.Size = New System.Drawing.Size(124, 20)
        Me.addrSPal.TabIndex = 17
        '
        'addrPAnim
        '
        Me.addrPAnim.Hexadecimal = True
        Me.addrPAnim.Location = New System.Drawing.Point(180, 0)
        Me.addrPAnim.Maximum = New Decimal(New Integer() {4194304, 0, 0, 0})
        Me.addrPAnim.Name = "addrPAnim"
        Me.addrPAnim.Size = New System.Drawing.Size(124, 20)
        Me.addrPAnim.TabIndex = 21
        '
        'addrPalF
        '
        Me.addrPalF.Hexadecimal = True
        Me.addrPalF.Location = New System.Drawing.Point(180, 1)
        Me.addrPalF.Maximum = New Decimal(New Integer() {4194304, 0, 0, 0})
        Me.addrPalF.Name = "addrPalF"
        Me.addrPalF.Size = New System.Drawing.Size(124, 20)
        Me.addrPalF.TabIndex = 25
        '
        'AddressUpDown8
        '
        Me.AddressUpDown8.Location = New System.Drawing.Point(162, -2)
        Me.AddressUpDown8.Name = "AddressUpDown8"
        Me.AddressUpDown8.Size = New System.Drawing.Size(18, 23)
        Me.AddressUpDown8.TabIndex = 28
        Me.AddressUpDown8.Value = 0
        '
        'AddressUpDown6
        '
        Me.AddressUpDown6.Location = New System.Drawing.Point(162, 1)
        Me.AddressUpDown6.Name = "AddressUpDown6"
        Me.AddressUpDown6.Size = New System.Drawing.Size(18, 23)
        Me.AddressUpDown6.TabIndex = 22
        Me.AddressUpDown6.Value = 0
        '
        'AddressUpDown5
        '
        Me.AddressUpDown5.Location = New System.Drawing.Point(162, 3)
        Me.AddressUpDown5.Name = "AddressUpDown5"
        Me.AddressUpDown5.Size = New System.Drawing.Size(18, 23)
        Me.AddressUpDown5.TabIndex = 21
        Me.AddressUpDown5.Value = 0
        '
        'AddressUpDown4
        '
        Me.AddressUpDown4.Location = New System.Drawing.Point(162, 0)
        Me.AddressUpDown4.Name = "AddressUpDown4"
        Me.AddressUpDown4.Size = New System.Drawing.Size(18, 23)
        Me.AddressUpDown4.TabIndex = 13
        Me.AddressUpDown4.Value = 0
        '
        'AddressUpDown3
        '
        Me.AddressUpDown3.Location = New System.Drawing.Point(162, 5)
        Me.AddressUpDown3.Name = "AddressUpDown3"
        Me.AddressUpDown3.Size = New System.Drawing.Size(18, 23)
        Me.AddressUpDown3.TabIndex = 9
        Me.AddressUpDown3.Value = 0
        '
        'AddressUpDown2
        '
        Me.AddressUpDown2.Location = New System.Drawing.Point(162, 3)
        Me.AddressUpDown2.Name = "AddressUpDown2"
        Me.AddressUpDown2.Size = New System.Drawing.Size(18, 23)
        Me.AddressUpDown2.TabIndex = 8
        Me.AddressUpDown2.Value = 0
        '
        'AddressUpDown1
        '
        Me.AddressUpDown1.Location = New System.Drawing.Point(162, 1)
        Me.AddressUpDown1.Name = "AddressUpDown1"
        Me.AddressUpDown1.Size = New System.Drawing.Size(18, 23)
        Me.AddressUpDown1.TabIndex = 4
        Me.AddressUpDown1.Value = 0
        '
        'LevelSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(581, 534)
        Me.Controls.Add(Me.grpTileAnimation)
        Me.Controls.Add(Me.chkPltFade)
        Me.Controls.Add(Me.grpPltFade)
        Me.Controls.Add(Me.grpBonuses)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpOther)
        Me.Controls.Add(Me.grpTileset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LevelSettings"
        Me.ShowIcon = False
        Me.Text = "Level Settings"
        Me.grpTileset.ResumeLayout(False)
        Me.grpTileset.PerformLayout()
        Me.pnlUnk.ResumeLayout(False)
        Me.pnlUnk.PerformLayout()
        CType(Me.nudUnk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCol.ResumeLayout(False)
        Me.pnlCol.PerformLayout()
        Me.pnlGFX.ResumeLayout(False)
        Me.pnlGFX.PerformLayout()
        Me.pnlPal.ResumeLayout(False)
        Me.pnlPal.PerformLayout()
        Me.pnlTiles.ResumeLayout(False)
        Me.pnlTiles.PerformLayout()
        Me.grpOther.ResumeLayout(False)
        Me.grpOther.PerformLayout()
        Me.pnlUnk3.ResumeLayout(False)
        Me.pnlUnk3.PerformLayout()
        CType(Me.nudUnk3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMusic.ResumeLayout(False)
        Me.pnlMusic.PerformLayout()
        CType(Me.nudMusic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPAnim.ResumeLayout(False)
        Me.pnlPAnim.PerformLayout()
        Me.pnlSPal.ResumeLayout(False)
        Me.pnlSPal.PerformLayout()
        Me.grpBonuses.ResumeLayout(False)
        Me.grpBonuses.PerformLayout()
        CType(Me.nudCustBonus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPltFade.ResumeLayout(False)
        Me.grpPltFade.PerformLayout()
        Me.pnlPalF.ResumeLayout(False)
        Me.pnlPalF.PerformLayout()
        Me.grpTileAnimation.ResumeLayout(False)
        CType(Me.addrTiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.addrPal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.addrGFX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.addrCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.addrSPal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.addrPAnim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.addrPalF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpTileset As System.Windows.Forms.GroupBox
    Friend WithEvents lblTiles As System.Windows.Forms.Label
    Friend WithEvents radTilesMan As System.Windows.Forms.RadioButton
    Friend WithEvents cboTiles As System.Windows.Forms.ComboBox
    Friend WithEvents radTilesAuto As System.Windows.Forms.RadioButton
    Friend WithEvents radColMan As System.Windows.Forms.RadioButton
    Friend WithEvents radColAuto As System.Windows.Forms.RadioButton
    Friend WithEvents lblCollision As System.Windows.Forms.Label
    Friend WithEvents radGFXMan As System.Windows.Forms.RadioButton
    Friend WithEvents radGFXAuto As System.Windows.Forms.RadioButton
    Friend WithEvents lblGraphics As System.Windows.Forms.Label
    Friend WithEvents radPalMan As System.Windows.Forms.RadioButton
    Friend WithEvents cboPal As System.Windows.Forms.ComboBox
    Friend WithEvents radPalAuto As System.Windows.Forms.RadioButton
    Friend WithEvents lblPalette As System.Windows.Forms.Label
    Friend WithEvents nudUnk As System.Windows.Forms.NumericUpDown
    Friend WithEvents radUnkMan As System.Windows.Forms.RadioButton
    Friend WithEvents radUnkAuto As System.Windows.Forms.RadioButton
    Friend WithEvents lblUnknown As System.Windows.Forms.Label
    Friend WithEvents grpOther As System.Windows.Forms.GroupBox
    Friend WithEvents cboMusic As System.Windows.Forms.ComboBox
    Friend WithEvents radMusicAuto As System.Windows.Forms.RadioButton
    Friend WithEvents nudMusic As System.Windows.Forms.NumericUpDown
    Friend WithEvents radMusicMan As System.Windows.Forms.RadioButton
    Friend WithEvents lblMusic As System.Windows.Forms.Label
    Friend WithEvents radUnk3Man As System.Windows.Forms.RadioButton
    Friend WithEvents radUnk3Auto As System.Windows.Forms.RadioButton
    Friend WithEvents lblUnknown3 As System.Windows.Forms.Label
    Friend WithEvents radPAnimMan As System.Windows.Forms.RadioButton
    Friend WithEvents radPAnimAuto As System.Windows.Forms.RadioButton
    Friend WithEvents lblPalAnim As System.Windows.Forms.Label
    Friend WithEvents radSPalMan As System.Windows.Forms.RadioButton
    Friend WithEvents radSPalAuto As System.Windows.Forms.RadioButton
    Friend WithEvents lblSpritePal As System.Windows.Forms.Label
    Friend WithEvents pnlUnk As System.Windows.Forms.Panel
    Friend WithEvents pnlCol As System.Windows.Forms.Panel
    Friend WithEvents pnlGFX As System.Windows.Forms.Panel
    Friend WithEvents pnlPal As System.Windows.Forms.Panel
    Friend WithEvents pnlTiles As System.Windows.Forms.Panel
    Friend WithEvents pnlUnk3 As System.Windows.Forms.Panel
    Friend WithEvents pnlMusic As System.Windows.Forms.Panel
    Friend WithEvents pnlPAnim As System.Windows.Forms.Panel
    Friend WithEvents pnlSPal As System.Windows.Forms.Panel
    Friend WithEvents cboPltAnim As System.Windows.Forms.ComboBox
    Friend WithEvents nudUnk3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents grpBonuses As System.Windows.Forms.GroupBox
    Friend WithEvents nudCustBonus As System.Windows.Forms.NumericUpDown
    Friend WithEvents lstCustomBonuses As System.Windows.Forms.ListBox
    Friend WithEvents lblCustomBonuses As System.Windows.Forms.Label
    Friend WithEvents lstBonuses As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnAddBonus As System.Windows.Forms.Button
    Friend WithEvents btnDeleteBonus As System.Windows.Forms.Button
    Friend WithEvents grpPltFade As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPalF As System.Windows.Forms.Panel
    Friend WithEvents radPalAutoF As System.Windows.Forms.RadioButton
    Friend WithEvents cboPalF As System.Windows.Forms.ComboBox
    Friend WithEvents radPalManF As System.Windows.Forms.RadioButton
    Friend WithEvents lblPaletteF As System.Windows.Forms.Label
    Friend WithEvents chkPltFade As System.Windows.Forms.CheckBox
    Friend WithEvents grpTileAnimation As System.Windows.Forms.GroupBox
    Friend WithEvents btnPresetTileAnim As System.Windows.Forms.Button
    Friend WithEvents cboTileAnim As System.Windows.Forms.ComboBox
    Friend WithEvents btnImportTileAnim As System.Windows.Forms.Button
    Friend WithEvents btnExportTileAnim As System.Windows.Forms.Button
    Friend WithEvents btnDeleteTileAnim As System.Windows.Forms.Button
    Friend WithEvents saveTileAnim As System.Windows.Forms.SaveFileDialog
    Friend WithEvents openTileAnim As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AddressUpDown1 As AddressUpDown
    Friend WithEvents addrCol As NumericUpDown
    Friend WithEvents addrGFX As NumericUpDown
    Friend WithEvents addrPal As NumericUpDown
    Friend WithEvents addrTiles As NumericUpDown
    Friend WithEvents addrPAnim As NumericUpDown
    Friend WithEvents addrSPal As NumericUpDown
    Friend WithEvents addrPalF As NumericUpDown
    Friend WithEvents AddressUpDown4 As AddressUpDown
    Friend WithEvents AddressUpDown3 As AddressUpDown
    Friend WithEvents AddressUpDown2 As AddressUpDown
    Friend WithEvents AddressUpDown6 As AddressUpDown
    Friend WithEvents AddressUpDown5 As AddressUpDown
    Friend WithEvents AddressUpDown8 As AddressUpDown
End Class
