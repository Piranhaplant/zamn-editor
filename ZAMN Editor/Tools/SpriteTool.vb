Public Class SpriteTool
    Inherits Tool

    Public levelList As LevelObjList

    Public selectedObjs As List(Of LevelObj)
    Public selectedObj As LevelObj
    Public allSelectedObjs As New Dictionary(Of LvlEdCtrl, List(Of LevelObj))
    Public XStart As Integer
    Public YStart As Integer
    Public width As Integer
    Public height As Integer
    Public removing As Boolean
    Public created As Boolean

    Public curSelObjs As New List(Of LevelObj)
    Public selecting As Boolean = False
    Public curX As Integer
    Public curY As Integer
    Public dragXOff As Integer
    Public dragYOff As Integer
    Public borderPen As New Pen(Color.Black)
    Public darkBrush As New SolidBrush(Color.FromArgb(92, 0, 0, 0))

    Public DefaultText As String = "asdf"
    Public ShiftText As String = "asdf"
    Public CtrlText As String = "asdf"
    Public AltText As String = "asdf"
    Public MoveText As String = "asdf"

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        Me.Status = DefaultText
        borderPen.DashPattern = New Single() {4, 4}
        SidePanel = SideContentType.Sprites
    End Sub

    Public Overrides Sub Refresh()
        levelList = ed.EdControl.lvl.objects
        If Not allSelectedObjs.ContainsKey(ed.EdControl) Then
            allSelectedObjs.Add(ed.EdControl, New List(Of LevelObj))
        End If
        selectedObjs = allSelectedObjs(ed.EdControl)
    End Sub

    Public Overrides Sub MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim addobj As Boolean = False
        For l As Integer = levelList.Count - 1 To 0 Step -1 'Find obj under mouse
            Dim o As LevelObj = levelList(l)
            If o.Rect(ed.EdControl.lvl.GFX).Contains(e.Location) And o.Selectable() Then
                If Control.ModifierKeys = Keys.Alt Then
                    selectedObjs.Remove(o)
                    selecting = False
                    selectedObj = Nothing
                    Repaint()
                    Return
                End If
                If Not selectedObjs.Contains(o) Then
                    If Control.ModifierKeys <> Keys.Shift Then
                        selectedObjs.Clear()
                    End If
                    selectedObjs.Add(o)
                End If
                selectedObj = o
                dragXOff = e.X - o.X
                dragYOff = e.Y - o.Y
                addobj = True
                Exit For
            End If
        Next
        curSelObjs.Clear()
        If addobj Then 'Move selected obj
            XStart = selectedObj.X
            YStart = selectedObj.Y
        Else 'Create a selection rectangle
            If Control.ModifierKeys <> Keys.Shift And Control.ModifierKeys <> Keys.Alt Then
                selectedObjs.Clear()
                ed.SetCopy(False)
            End If
            XStart = e.X
            YStart = e.Y
            curX = e.X
            curY = e.Y
            width = 0
            height = 0
            removing = (Control.ModifierKeys = Keys.Alt)
        End If
        selecting = Not addobj
        If Control.ModifierKeys = Keys.Control Then 'And removable Then 'Add a new obj
            If selectedObjs.Count = 0 Then
                'TODO: Add code for creating a new object
                'Dim o As LevelObj = NewOfT(e.X, e.Y)
                'If o IsNot Nothing Then
                '    selectedObjs.Clear()
                '    selectedObjs.Add(o)
                '    selectedObj = o
                '    created = True
                'End If
            Else 'Clone the current obj
                Dim newObjs As New List(Of LevelObj)
                For Each o As LevelObj In selectedObjs
                    newObjs.Add(o.Clone())
                Next
                selectedObj = newObjs(selectedObjs.IndexOf(selectedObj))
                selectedObjs = newObjs
                created = True
            End If
            levelList.Add(selectedObjs)
            selecting = False
        End If
        ed.SetCopy(CanCopy())
        UpdateProperties()
        Repaint()
    End Sub

    Public Overrides Sub MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If selecting Then
                width = Math.Abs(e.X - XStart)
                height = Math.Abs(e.Y - YStart)
                If e.X < XStart Then
                    curX = XStart - width
                Else
                    curX = XStart
                End If
                If e.Y < YStart Then
                    curY = YStart - height
                Else
                    curY = YStart
                End If
                Dim selRect As New Rectangle(curX, curY, width, height)
                curSelObjs.Clear()
                For Each o As LevelObj In levelList.Everything 'Find objs in selection rectangle
                    If selRect.IntersectsWith(o.Rect(ed.EdControl.lvl.GFX)) And o.Selectable() Then
                        curSelObjs.Add(o)
                    End If
                Next
                ed.SetCopy(selectedObjs.Count > 0 Or curSelObjs.Count > 0)
            ElseIf selectedObj IsNot Nothing Then
                Dim minX As Integer = Integer.MaxValue
                Dim minY As Integer = Integer.MaxValue
                Dim stp As Integer = 1
                If Control.ModifierKeys = Keys.Shift Then
                    stp = 8
                End If
                For Each o As LevelObj In selectedObjs
                    If o.X < minX Then minX = o.X
                    If o.Y < minY Then minY = o.Y
                Next
                Dim XDelta As Integer = Math.Max(-minX, e.X - (selectedObj.X + dragXOff))
                Dim YDelta As Integer = Math.Max(-minY, e.Y - (selectedObj.Y + dragYOff))
                If created Then
                    ed.EdControl.UndoMgr.Perform(New MoveSpriteAction(selectedObjs, XDelta, YDelta, stp))
                Else
                    ed.EdControl.UndoMgr.Do(New MoveSpriteAction(selectedObjs, XDelta, YDelta, stp))
                End If
                Me.Status = String.Format(MoveText, selectedObj.X - XStart, selectedObj.Y - YStart)
                UpdateStatus()
            End If
            UpdateProperties()
            Repaint()
        End If
    End Sub

    Public Overrides Sub MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        For Each o As LevelObj In curSelObjs
            If removing Then
                If selectedObjs.Contains(o) Then
                    selectedObjs.Remove(o)
                End If
            Else
                If Not selectedObjs.Contains(o) Then
                    selectedObjs.Add(o)
                End If
            End If
        Next
        If created Then
            ed.EdControl.UndoMgr.Do(New AddSpriteAction(selectedObjs), False)
            created = False
        End If
        curSelObjs.Clear()
        selecting = False
        ResetStatus()
        UpdateProperties()
        Repaint()
        ed.EdControl.UndoMgr.merge = False
    End Sub

    Public Overrides Sub KeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete And selectedObjs.Count > 0 Then
            ed.EdControl.UndoMgr.Do(New RemoveSpriteAction(selectedObjs))
            selectedObjs.Clear()
            Repaint()
        End If
        If selectedObjs.Count > 0 Then
            If e.KeyCode = Keys.Up Then
                ed.EdControl.UndoMgr.Do(New MoveSpriteAction(selectedObjs, 0, -1, 1))
                UpdateProperties()
            ElseIf e.KeyCode = Keys.Right Then
                ed.EdControl.UndoMgr.Do(New MoveSpriteAction(selectedObjs, 1, 0, 1))
                UpdateProperties()
            ElseIf e.KeyCode = Keys.Down Then
                ed.EdControl.UndoMgr.Do(New MoveSpriteAction(selectedObjs, 0, 1, 1))
                UpdateProperties()
            ElseIf e.KeyCode = Keys.Left Then
                ed.EdControl.UndoMgr.Do(New MoveSpriteAction(selectedObjs, -1, 0, 1))
                UpdateProperties()
            End If
        End If
        ResetStatus()
    End Sub

    Public Overrides Sub KeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        ResetStatus()
    End Sub

    Private Sub ResetStatus()
        If Control.MouseButtons = MouseButtons.Left Then Return
        If Control.ModifierKeys = Keys.Shift Then
            Me.Status = ShiftText
        ElseIf Control.ModifierKeys = Keys.Control Then
            Me.Status = CtrlText
        ElseIf Control.ModifierKeys = Keys.Alt Then
            Me.Status = AltText
        Else
            Me.Status = DefaultText
        End If
        UpdateStatus()
    End Sub

    'TODO: All the stuff for changing object type
    'Public Overrides Sub BMonsterChanged()
    '    If selectedObjs.Count > 0 And SidePanel = SideContentType.BossMonsters Then
    '        ed.EdControl.UndoMgr.Do(GetChangeAction(selectedObjs, Ptr.BossMonsters(BMonsterPicker.SelectedIndex)))
    '        UpdateProperties()
    '        Repaint()
    '    End If
    'End Sub

    'Public Overrides Sub ItemChanged()
    '    If selectedObjs.Count > 0 And SidePanel = SideContentType.Items Then
    '        ed.EdControl.UndoMgr.Do(GetChangeAction(selectedObjs, ItemPicker.SelectedIndex))
    '        UpdateProperties()
    '        Repaint()
    '    End If
    'End Sub

    'Public Overrides Sub MonsterChanged()
    '    If selectedObjs.Count > 0 And SidePanel = SideContentType.Monsters Then
    '        ed.EdControl.UndoMgr.Do(GetChangeAction(selectedObjs, Ptr.SpritePtrs(MonsterPicker.SelectedIndex)))
    '        UpdateProperties()
    '        Repaint()
    '    End If
    'End Sub

    'Public Overrides Sub NRMChanged()
    '    If selectedObjs.Count > 0 And SidePanel = SideContentType.NRMonsters Then
    '        ed.EdControl.UndoMgr.Do(GetChangeAction(selectedObjs, Ptr.SpritePtrs(NRMPicker.SelectedIndex)))
    '        UpdateProperties()
    '        Repaint()
    '    End If
    'End Sub

    'Public Overrides Sub VictimChanged()
    '    If selectedObjs.Count > 0 And SidePanel = SideContentType.Victims Then
    '        ed.EdControl.UndoMgr.Do(GetChangeAction(selectedObjs, Ptr.SpritePtrs(VictimPicker.SelectedIndex)))
    '        UpdateProperties()
    '        Repaint()
    '    End If
    'End Sub

    Public Overrides Sub Paint(ByVal g As System.Drawing.Graphics)
        If selecting Then
            g.DrawRectangle(Pens.White, curX, curY, width, height)
            g.DrawRectangle(borderPen, curX, curY, width, height)
        End If
        For Each o As LevelObj In selectedObjs
            If Not curSelObjs.Contains(o) Then
                g.FillRectangle(darkBrush, o.Rect(ed.EdControl.lvl.GFX))
                g.DrawRectangle(Pens.White, o.Rect(ed.EdControl.lvl.GFX))
            End If
        Next
        If Not removing Then
            For Each o As LevelObj In curSelObjs
                g.FillRectangle(darkBrush, o.Rect(ed.EdControl.lvl.GFX))
                g.DrawRectangle(Pens.White, o.Rect(ed.EdControl.lvl.GFX))
            Next
        End If
    End Sub

    Public Overrides Sub RemoveEdCtrl(ByVal e As LvlEdCtrl)
        allSelectedObjs.Remove(e)
    End Sub

    Public Overrides Function SelectAll(ByVal selected As Boolean) As Boolean
        curSelObjs.Clear()
        selecting = False
        selectedObjs.Clear()
        selectedObj = Nothing
        If selected Then
            For Each o As LevelObj In levelList.Everything
                If o.Selectable() Then
                    selectedObjs.Add(o)
                End If
            Next
        End If
        Return False
    End Function

    'Public Overrides Function Copy() As Boolean
    '    If removable Then
    '        Clipboard.SetText(Shrd.FormatCopyStr(pasteChar & ToText(selectedObjs)))
    '        Return False
    '    End If
    'End Function

    'Public Overrides Function Cut() As Boolean
    '    If removable Then
    '        Copy()
    '        ed.EdControl.UndoMgr.Do(GetRemoveAction(selectedObjs))
    '        selectedObjs.Clear()
    '        Return False
    '    End If
    'End Function

    'Public Overrides Function Paste() As Boolean
    '    If removable Then
    '        Dim clipTxt As String = Shrd.UnFormatCopyStr(Clipboard.GetText)
    '        If Not clipTxt.StartsWith(pasteChar) Then Return False
    '        clipTxt = Mid(clipTxt, 2)
    '        selectedObjs = FromText(clipTxt)
    '        Dim MinX As Integer = Integer.MaxValue, MinY As Integer = Integer.MaxValue
    '        Dim MaxX As Integer = 0, MaxY As Integer = 0
    '        Dim r As Rectangle
    '        For Each o As LevelObj In selectedObjs
    '            r = RectOfT(o)
    '            If r.X < MinX Then MinX = r.X
    '            If r.Y < MinY Then MinY = r.Y
    '            If r.Right > MaxX Then MaxX = r.Right
    '            If r.Bottom > MaxY Then MaxY = r.Bottom
    '        Next
    '        Dim dx As Integer = (ed.EdControl.canvas.Width / ed.EdControl.zoom - (MaxX - MinX)) \ 2 + ed.EdControl.HScrl.Value * ed.EdControl.zoom - MinX
    '        Dim dy As Integer = (ed.EdControl.canvas.Height / ed.EdControl.zoom - (MaxY - MinY)) \ 2 + ed.EdControl.VScrl.Value * ed.EdControl.zoom - MinY
    '        For Each o As LevelObj In selectedObjs
    '            X(o) += dx
    '            Y(o) += dy
    '        Next
    '        ed.EdControl.UndoMgr.Do(GetAddAction(selectedObjs))
    '        Return False
    '    End If
    'End Function

    Public Sub UpdateProperties()
        If selectedObjs.Count = 1 Then
            Browser.SetObject(selectedObj)
        Else
            Browser.ClearObject()
        End If
    End Sub

    'Public MustOverride Function ToText(ByVal Objs As List(Of LevelObj)) As String
    'Public MustOverride Function FromText(ByVal txt As String) As List(Of LevelObj)
End Class
