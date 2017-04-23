Public Class OpenLevel

    Public levelNums As Integer()
    Public levelNames As String()
    Public allNames As String()
    Public allNums As Integer()
    Public curNames As New List(Of String)
    Public curNums As New List(Of Integer)
    Private r As ROM
    Private selectedNums As New List(Of Integer)
    Private updating As Boolean = False

    Public Sub LoadROM(ByVal r As ROM)
        Me.r = r
        levels.Items.Clear()
        allNames = r.names.Values.ToArray()
        allNums = r.names.Keys.ToArray()
        curNames.AddRange(allNames)
        curNums.AddRange(allNums)
        levels.Items.AddRange(allNames)
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If levels.SelectedIndices.Count = 0 Then
            MsgBox("Select a level", MsgBoxStyle.Information, "Select a level")
            Return
        End If
        ReDim levelNums(levels.SelectedIndices.Count - 1)
        ReDim levelNames(levels.SelectedIndices.Count - 1)
        For l As Integer = 0 To levelNames.Length - 1
            levelNums(l) = curNums(levels.SelectedIndices(l))
            levelNames(l) = curNames(levels.SelectedIndices(l))
        Next
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub SetName(ByVal num As Integer, ByVal name As String)
        allNames(Array.IndexOf(allNums, num)) = name
        If curNums.Contains(num) Then
            Dim index As Integer = curNums.IndexOf(num)
            curNames(index) = name
            levels.Items(index) = name
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        curNames.Clear()
        curNums.Clear()
        Dim searchText As String = LCase(txtSearch.Text)
        For l As Integer = 0 To allNames.Length - 1
            If LCase(allNames(l)).Contains(searchText) Then
                curNames.Add(allNames(l))
                curNums.Add(allNums(l))
            End If
        Next
        updating = True
        levels.Items.Clear()
        levels.Items.AddRange(curNames.ToArray())
        For Each i As Integer In selectedNums
            levels.SelectedIndices.Add(curNums.IndexOf(i))
        Next
        updating = False
    End Sub

    Private Sub ClearButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearButton1.Click
        txtSearch.Text = ""
    End Sub

    Private Sub levels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles levels.SelectedIndexChanged
        If updating Then Return
        selectedNums.Clear()
        For Each i As Integer In levels.SelectedIndices
            selectedNums.Add(curNums(i))
        Next
    End Sub

    Private Sub levels_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles levels.MouseDoubleClick
        OK.PerformClick()
    End Sub
End Class