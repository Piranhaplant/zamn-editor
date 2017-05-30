Public Class Tool

    Public ed As Editor
    Public SidePanel As SideContentType
    Public WithEvents Browser As ObjectBrowser
    Public WithEvents TilePicker As TilesetBrowser
    Public WithEvents ItemPicker As ItemBrowser
    Public WithEvents VictimPicker As VictimBrowser
    Public WithEvents NRMPicker As NRMBrowser
    Public WithEvents MonsterPicker As MonsterBrowser
    Public WithEvents BMonsterPicker As BMonsterBrowser
    Public Status As String
    Public active As Boolean = False

    Public Sub New(ByVal ed As Editor)
        Me.ed = ed
    End Sub
    Public Overridable Sub Paint(ByVal g As Graphics)

    End Sub
    Public Overridable Sub MouseDown(ByVal e As MouseEventArgs)

    End Sub
    Public Overridable Sub MouseUp(ByVal e As MouseEventArgs)

    End Sub
    Public Overridable Sub MouseMove(ByVal e As MouseEventArgs)

    End Sub
    Public Overridable Sub KeyDown(ByVal e As KeyEventArgs)

    End Sub
    Public Overridable Sub KeyUp(ByVal e As KeyEventArgs)

    End Sub
    Public Overridable Sub TileChanged()

    End Sub
    Public Overridable Sub ItemChanged()

    End Sub
    Public Overridable Sub VictimChanged()

    End Sub
    Public Overridable Sub NRMChanged()

    End Sub
    Public Overridable Sub MonsterChanged()

    End Sub
    Public Overridable Sub BMonsterChanged()

    End Sub
    Public Overridable Sub Refresh()
        ed.CheckCopy()
    End Sub
    Public Overridable Sub RemoveEdCtrl(ByVal e As LvlEdCtrl)

    End Sub
    Public Overridable Function SelectAll(ByVal selected As Boolean) As Boolean
        Return True
    End Function
    Public Overridable Function Copy() As Boolean
        Return True
    End Function
    Public Overridable Function Cut() As Boolean
        Return True
    End Function
    Public Overridable Function Paste() As Boolean
        Return True
    End Function
    Public Overridable Function CanCopy() As Boolean
        Return True
    End Function
    Public Overridable Sub UpdateSelection()
        'Tools should override this function and remove any object from the selection if they do not exist in the level anymore
    End Sub

    Private Sub TilePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TilePicker.ValueChanged
        If active Then TileChanged()
    End Sub
    Private Sub ItemPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemPicker.ValueChanged
        If active Then ItemChanged()
    End Sub
    Private Sub VictimPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VictimPicker.ValueChanged
        If active Then VictimChanged()
    End Sub
    Private Sub NRMPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NRMPicker.ValueChanged
        If active Then NRMChanged()
    End Sub
    Private Sub MonsterPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonsterPicker.ValueChanged
        If active Then MonsterChanged()
    End Sub
    Private Sub BMonsterPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BMonsterPicker.ValueChanged
        If active Then BMonsterChanged()
    End Sub

    Public Sub SetBrowser(ByVal Browser As ObjectBrowser)
        Me.Browser = Browser
        Browser.SetEditor(ed)
        If TypeOf Browser Is TilesetBrowser Then
            TilePicker = Browser
        ElseIf TypeOf Browser Is ItemBrowser Then
            ItemPicker = Browser
        ElseIf TypeOf Browser Is VictimBrowser Then
            VictimPicker = Browser
        ElseIf TypeOf Browser Is NRMBrowser Then
            NRMPicker = Browser
        ElseIf TypeOf Browser Is MonsterBrowser Then
            MonsterPicker = Browser
        ElseIf TypeOf Browser Is BMonsterBrowser Then
            BMonsterPicker = Browser
        End If
    End Sub

    Public Sub Repaint()
        ed.EdControl.Repaint()
    End Sub
    Public Sub UpdateStatus()
        If ed.EdControl Is Nothing Then Return
        ed.EdControl.SetStatusText(Status)
    End Sub

    Public Sub SetCursor(ByVal cur As Cursor)
        ed.EdControl.canvas.Cursor = cur
    End Sub
End Class

Public Enum SideContentType
    Tiles
    Items
    Victims
    NRMonsters
    Monsters
    BossMonsters
    Sprites
End Enum