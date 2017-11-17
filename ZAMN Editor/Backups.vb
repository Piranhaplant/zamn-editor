Module Backups

    Private Const backupDir As String = "Backups"
    Private currentBackups As New Dictionary(Of Integer, String)

    Public Sub BackupLevel(lvl As Level)
        Try
            If currentBackups.ContainsKey(lvl.num) Then
                IO.File.Delete(currentBackups(lvl.num))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
        Try
            Dim data As Byte() = lvl.ToFile()
            Dim filename As String = lvl.name.Replace(":", "") & "_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".zl"
            Dim path As String = IO.Path.Combine(My.Application.Info.DirectoryPath, backupDir, filename)
            IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(path))
            Debug.WriteLine("Saving level " & lvl.num & " to " & path)

            IO.File.WriteAllBytes(path, data)
            currentBackups(lvl.num) = path
            My.Settings.BackupsExist = True
            My.Settings.Save()
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub RemoveBackup(lvl As Level)
        Try
            If currentBackups.ContainsKey(lvl.num) Then
                IO.File.Delete(currentBackups(lvl.num))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
        currentBackups.Remove(lvl.num)
        If currentBackups.Count = 0 Then
            My.Settings.BackupsExist = False
            My.Settings.Save()
        End If
    End Sub

    Public Sub CheckForBackupsOnStart()
        If My.Settings.BackupsExist Then
            MsgBox("The application did not shut down correctly, and levels with unsaved changes have been saved in:" & Environment.NewLine & Environment.NewLine & _
                   IO.Path.Combine(My.Application.Info.DirectoryPath, backupDir))
            My.Settings.BackupsExist = False
            My.Settings.Save()
        End If
    End Sub

    Public Sub RemoveAllBackupsOnExit()
        Try
            For Each path As String In currentBackups.Values
                IO.File.Delete(path)
            Next
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
        My.Settings.BackupsExist = False
        My.Settings.Save()
    End Sub
End Module
