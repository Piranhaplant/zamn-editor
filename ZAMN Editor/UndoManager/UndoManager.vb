Public Class UndoManager
    Private undo As ToolStripSplitButton
    Private redo As ToolStripSplitButton
    Private EdControl As LvlEdCtrl

    Public UActions As New Stack(Of Action)()
    Public RActions As New Stack(Of Action)()
    Public merge As Boolean = True
    Public savePos As Integer = 0

    Private actionCount As Integer

    Public Sub New(ByVal UndoButton As ToolStripSplitButton, ByVal RedoButton As ToolStripSplitButton, ByVal editor As LvlEdCtrl)
        undo = UndoButton
        redo = RedoButton
        EdControl = editor

        AddHandler undo.ButtonClick, AddressOf onUndoLast
        AddHandler redo.ButtonClick, AddressOf onRedoLast
    End Sub

    Public Shared Function CreateList(Of T)(ByVal item As T) As List(Of T)
        Dim l As New List(Of T)
        l.Add(item)
        Return l
    End Function

    Public Sub [Do](ByVal act As Action, Optional ByVal performAction As Boolean = True)
        'Determine if the actions should be merged
        If merge AndAlso UActions.Count > 0 AndAlso UActions.Peek().CanMerge AndAlso UActions.Peek().GetType().Equals(act.GetType()) Then
            act.SetEdControl(EdControl)
            If act.cancelAction Then Return
            act.DoRedo(False)
            UActions.Peek().Merge(act)
            act = Nothing
        Else
            act.SetEdControl(EdControl)
            If act.cancelAction Then Return
            UActions.Push(act)
            Dim item As New ToolStripMenuItem(act.ToString())
            AddHandler item.MouseEnter, AddressOf updateActCount
            AddHandler item.Click, AddressOf onUndoActions
            undo.DropDownItems.Insert(0, item)
        End If
        If UActions.Count <= savePos Then
            savePos = -1
        End If
        If redo.DropDownItems.Count > 0 Then
            redo.DropDownItems.Clear()
            RActions.Clear()
        End If
        undo.Enabled = True
        redo.Enabled = False
        If act IsNot Nothing And performAction Then
            act.DoRedo(False)
        End If
        merge = True
    End Sub

    Public Sub Perform(ByVal act As Action)
        act.SetEdControl(EdControl)
        If act.cancelAction Then Return
        act.DoRedo(False)
    End Sub

    Public Sub Clean()
        savePos = UActions.Count
    End Sub

    Public ReadOnly Property Dirty
        Get
            Return savePos <> UActions.Count
        End Get
    End Property

    Private Sub onUndoLast(ByVal sender As Object, ByVal e As EventArgs)
        UndoLast(False)
    End Sub

    Public Sub UndoLast(ByVal multiple As Boolean)
        If UActions.Count > 0 Then
            undo.DropDownItems.RemoveAt(0)
            Dim item As New ToolStripMenuItem(UActions.Peek().ToString())
            AddHandler item.MouseEnter, AddressOf updateActCount
            AddHandler item.Click, AddressOf onRedoActions
            redo.DropDownItems.Insert(0, item)
            UActions.Peek().DoUndo(multiple)
            RActions.Push(UActions.Pop())
            undo.Enabled = undo.DropDownItems.Count > 0
            redo.Enabled = True
        End If
    End Sub

    Private Sub onUndoActions(ByVal sender As Object, ByVal e As EventArgs)
        UndoActions(actionCount)
    End Sub

    Public Sub UndoActions(ByVal count As Integer)
        For l As Integer = 0 To count - 1
            UndoLast(l < count - 1)
        Next
    End Sub

    Private Sub onRedoLast(ByVal sender As Object, ByVal e As EventArgs)
        RedoLast(False)
    End Sub

    Public Sub RedoLast(ByVal multiple As Boolean)
        If RActions.Count > 0 Then
            redo.DropDownItems.RemoveAt(0)
            Dim item As New ToolStripMenuItem(RActions.Peek().ToString())
            AddHandler item.MouseEnter, AddressOf updateActCount
            AddHandler item.Click, AddressOf onUndoActions
            undo.DropDownItems.Insert(0, item)
            RActions.Peek().DoRedo(multiple)
            UActions.Push(RActions.Pop())
            redo.Enabled = redo.DropDownItems.Count > 0
            undo.Enabled = True
        End If
    End Sub

    Private Sub onRedoActions(ByVal sender As Object, ByVal e As EventArgs)
        RedoActions(actionCount)
    End Sub

    Public Sub RedoActions(ByVal count As Integer)
        For l As Integer = 0 To count - 1
            RedoLast(l < count - 1)
        Next
    End Sub

    Public Sub ReAddItems()
        undo.DropDownItems.Clear()
        For Each act As Action In UActions
            undo.DropDownItems.Add(act.ToString())
        Next
        undo.Enabled = UActions.Count > 0
        redo.DropDownItems.Clear()
        For Each act As Action In RActions
            redo.DropDownItems.Add(act.ToString())
        Next
        redo.Enabled = RActions.Count > 0
    End Sub

    Private Sub updateActCount(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        actionCount = CType(item.OwnerItem, ToolStripSplitButton).DropDownItems.IndexOf(item) + 1
    End Sub
End Class

Public Class Action
    Public EdControl As LvlEdCtrl
    Public level As Level

    Public Sub New()
    End Sub
    Public Sub DoUndo(ByVal multiple As Boolean)
        Me.Undo()
        'If TypeOf Me Is ChangeSpriteTypeAction OrElse Not multiple Then
        Me.AfterAction()
        EdControl.Repaint()
        'End If
    End Sub
    Public Sub DoRedo(ByVal multiple As Boolean)
        Me.Redo()
        'If TypeOf Me Is ChangeSpriteTypeAction OrElse Not multiple Then
        Me.AfterAction()
        EdControl.Repaint()
        'End If
    End Sub
    Public Overridable Sub Undo()
    End Sub
    Public Overridable Sub Redo()
    End Sub
    Public Overridable Sub AfterAction()
    End Sub
    Public Overridable Sub AfterSetEdControl()
    End Sub
    Public Overridable ReadOnly Property CanMerge() As Boolean
        Get
            Return False
        End Get
    End Property
    Public Overridable Sub Merge(ByVal act As Action)
    End Sub
    Public Sub SetEdControl(ByVal EdControl As LvlEdCtrl)
        Me.EdControl = EdControl
        Me.level = EdControl.lvl
        Me.AfterSetEdControl()
    End Sub
    Public cancelAction As Boolean
End Class
