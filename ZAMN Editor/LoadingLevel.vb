Public Class LoadingLevel

    Public lvls As List(Of Level)
    Public names As String()
    Public l As Integer
    Public failed As List(Of String)

    Public Sub Start(ByVal r As ROM, ByVal nums As Integer(), ByVal names As String())
        Progress.Value = 0
        Progress.Maximum = nums.Length - 1
        Me.names = names
        l = 0
        failed = New List(Of String)
        Me.Size = New Size(382, 136)
        FailedPanel.Visible = False
        Loader.RunWorkerAsync(New LoadLevelArgs(r, nums, names))
        Me.ShowDialog()
    End Sub

    Private Sub Loader_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Loader.DoWork
        Dim args As LoadLevelArgs = CType(e.Argument, LoadLevelArgs)
        Dim lvls As New List(Of Level)
        For l As Integer = 0 To args.names.Length - 1
#If Not Debug Then
            Try
#End If
            Loader.ReportProgress(0)
            lvls.Add(args.r.GetLevel(args.nums(l), args.names(l)))
            Loader.ReportProgress(1)
            If Loader.CancellationPending Then
                Exit For
            End If
#If Not Debug Then
            Catch ex As Exception
                Loader.ReportProgress(2, args.names(l) & ": " & ex.Message)
            End Try
#End If
        Next
        e.Result = lvls
    End Sub

    Private Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Loader.CancelAsync()
    End Sub

    Private Sub Loader_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Loader.ProgressChanged
        If e.ProgressPercentage = 0 Then
            LoadText.Text = names(l)
            l += 1
        ElseIf e.ProgressPercentage = 1 Then
            Progress.PerformStep()
        Else
            failed.Add(CStr(e.UserState))
        End If
    End Sub

    Private Sub Loader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Loader.RunWorkerCompleted
        lvls = CType(e.Result, List(Of Level))
        If failed.Count > 0 Then
            Me.Size = New Size(377, 251)
            FailedPanel.Visible = True
            FailedList.Items.Clear()
            For Each name As String In failed
                FailedList.Items.Add(name)
            Next
        Else
            Me.Close()
        End If
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Close()
    End Sub
End Class

Public Class LoadLevelArgs
    Public r As ROM
    Public names As String()
    Public nums As Integer()

    Public Sub New(ByVal r As ROM, ByVal nums As Integer(), ByVal names As String())
        Me.r = r
        Me.nums = nums
        Me.names = names
    End Sub
End Class