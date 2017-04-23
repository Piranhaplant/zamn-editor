Public Class SaveMsgBox

    Public ed As Editor

    Public Overloads Function ShowDialog(ByVal ed As Editor, Optional ByVal singlePage As Boolean = False) As DialogResult
        Me.ed = ed
        levelList.Items.Clear()
        If singlePage Then
            If ed.Tabs.SelectedTab.Controls.Count > 0 AndAlso TypeOf ed.Tabs.SelectedTab.Controls(0) Is LvlEdCtrl Then
                Dim Edcontrol As LvlEdCtrl = ed.Tabs.SelectedTab.Controls(0)
                If Edcontrol.UndoMgr.Dirty Then
                    levelList.Items.Add(Edcontrol.lvl.name)
                    levelList.SetItemChecked(0, True)
                End If
            End If
        Else
            For Each tp As TabPage In ed.Tabs.tabctrl.TabPages
                If tp.Controls.Count > 0 AndAlso TypeOf tp.Controls(0) Is LvlEdCtrl Then
                    Dim EdControl As LvlEdCtrl = tp.Controls(0)
                    If EdControl.UndoMgr.Dirty Then
                        levelList.Items.Add(EdControl.lvl.name)
                        levelList.SetItemChecked(levelList.Items.Count - 1, True)
                    End If
                End If
            Next
        End If
        If levelList.Items.Count > 0 Then
            Return Me.ShowDialog()
        Else
            Return Windows.Forms.DialogResult.Yes
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim idx As Integer = 0
        For Each tp As TabPage In ed.Tabs.tabctrl.TabPages
            If tp.Controls.Count > 0 AndAlso TypeOf tp.Controls(0) Is LvlEdCtrl Then
                Dim EdControl As LvlEdCtrl = tp.Controls(0)
                If EdControl.UndoMgr.Dirty And levelList.GetItemChecked(idx) Then
                    ed.r.SaveLevel(EdControl.lvl)
                    idx = Math.Min(idx + 1, levelList.Items.Count - 1)
                End If
            End If
        Next
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnDontSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDontSave.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class