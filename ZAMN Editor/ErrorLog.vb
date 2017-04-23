Public Class ErrorLog

    Private Shared iserror As Boolean = False

    Public Shared Sub Report()
        iserror = True
    End Sub

    Public Shared Function HasError() As Boolean
        Dim e As Boolean = iserror
        iserror = False
        Return e
    End Function

    Public Shared Sub CheckError(ByVal msg As String)
        If HasError() Then
            Throw New Exception(msg)
        End If
    End Sub
End Class
