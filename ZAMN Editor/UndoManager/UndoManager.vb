Public Class UndoManager
    Private Const MaxToolStripItems As Integer = 20

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
            act.DoRedo()
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
            If undo.DropDownItems.Count > MaxToolStripItems Then
                undo.DropDownItems.RemoveAt(undo.DropDownItems.Count - 1)
            End If
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
            act.DoRedo()
        End If
        merge = True
    End Sub

    Public Sub Perform(ByVal act As Action)
        act.SetEdControl(EdControl)
        If act.cancelAction Then Return
        act.DoRedo()
    End Sub

    Public Sub Clean()
        savePos = UActions.Count
    End Sub

    Public Sub ForceDirty()
        savePos = -1
    End Sub

    Public ReadOnly Property Dirty
        Get
            Return savePos <> UActions.Count
        End Get
    End Property

    Public Sub UndoLast()
        If UActions.Count > 0 Then
            Dim act As Action = UActions.Pop()
            undo.DropDownItems.RemoveAt(0)
            If undo.DropDownItems.Count < UActions.Count Then
                undo.DropDownItems.Add(CreateUndoToolStripItem(UActions(undo.DropDownItems.Count)))
            End If
            redo.DropDownItems.Insert(0, CreateRedoToolStripItem(act))
            If redo.DropDownItems.Count > MaxToolStripItems Then
                redo.DropDownItems.RemoveAt(redo.DropDownItems.Count - 1)
            End If
            act.DoUndo()
            RActions.Push(act)
            undo.Enabled = undo.DropDownItems.Count > 0
            redo.Enabled = True
            merge = False
        End If
    End Sub

    Private Sub onUndoActions(ByVal sender As Object, ByVal e As EventArgs)
        UndoActions(actionCount)
    End Sub

    Public Sub UndoActions(ByVal count As Integer)
        For l As Integer = 0 To count - 1
            UndoLast()
        Next
    End Sub

    Public Sub RedoLast()
        If RActions.Count > 0 Then
            Dim act As Action = RActions.Pop()
            redo.DropDownItems.RemoveAt(0)
            If redo.DropDownItems.Count < RActions.Count Then
                redo.DropDownItems.Add(CreateRedoToolStripItem(RActions(redo.DropDownItems.Count)))
            End If
            undo.DropDownItems.Insert(0, CreateUndoToolStripItem(act))
            If undo.DropDownItems.Count > MaxToolStripItems Then
                undo.DropDownItems.RemoveAt(undo.DropDownItems.Count - 1)
            End If
            act.DoRedo()
            UActions.Push(act)
            redo.Enabled = redo.DropDownItems.Count > 0
            undo.Enabled = True
            merge = False
        End If
    End Sub

    Private Sub onRedoActions(ByVal sender As Object, ByVal e As EventArgs)
        RedoActions(actionCount)
    End Sub

    Public Sub RedoActions(ByVal count As Integer)
        For l As Integer = 0 To count - 1
            RedoLast()
        Next
    End Sub

    Public Sub ReAddItems()
        undo.DropDownItems.Clear()
        For Each act As Action In UActions
            undo.DropDownItems.Add(CreateUndoToolStripItem(act))
            If undo.DropDownItems.Count = MaxToolStripItems Then
                Exit For
            End If
        Next
        undo.Enabled = UActions.Count > 0
        redo.DropDownItems.Clear()
        For Each act As Action In RActions
            redo.DropDownItems.Add(CreateRedoToolStripItem(act))
            If redo.DropDownItems.Count = MaxToolStripItems Then
                Exit For
            End If
        Next
        redo.Enabled = RActions.Count > 0
    End Sub

    Private Sub updateActCount(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        actionCount = CType(item.OwnerItem, ToolStripSplitButton).DropDownItems.IndexOf(item) + 1
    End Sub

    Private Function CreateUndoToolStripItem(ByVal act As Action) As ToolStripMenuItem
        Dim item As New ToolStripMenuItem(act.ToString())
        AddHandler item.MouseEnter, AddressOf updateActCount
        AddHandler item.Click, AddressOf onUndoActions
        Return item
    End Function

    Private Function CreateRedoToolStripItem(ByVal act As Action) As ToolStripMenuItem
        Dim item As New ToolStripMenuItem(act.ToString())
        AddHandler item.MouseEnter, AddressOf updateActCount
        AddHandler item.Click, AddressOf onRedoActions
        Return item
    End Function
End Class

Public Class Action
    Public EdControl As LvlEdCtrl
    Public level As Level

    Public Sub New()
    End Sub
    Public Sub DoUndo()
        Me.Undo()
        Me.AfterAction()
        EdControl.Repaint()
    End Sub
    Public Sub DoRedo()
        Me.Redo()
        Me.AfterAction()
        EdControl.Repaint()
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
