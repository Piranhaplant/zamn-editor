Public Class ZAMNClip

    Public Shared Function ToClip(ByVal str As String) As String
        Return "ZAMNClip|" & str & "|EndClip"
    End Function

    Public Shared Function IsClip(ByVal str As String) As Boolean
        str = Trim(str)
        Return str.StartsWith("ZAMNClip|") And (InStr(10, str, "|") > 0)
    End Function

    Public Shared Function FromClip(ByVal str As String) As String
        str = Trim(str)
        Return Mid(str, 10, InStr(10, str, "|") - 10)
    End Function

    Public Shared Function ToText(ByVal data As Byte()) As String
        Dim str As String = ""
        For l As Integer = 0 To data.Length - 1
            str &= data(l).ToString("X2")
        Next
        Return str
    End Function

    Public Shared Function FromText(ByVal str As String) As Byte()
        Dim data(str.Length \ 2 - 1) As Byte
        For l As Integer = 0 To data.Length - 1
            data(l) = CByte("&H" & Mid(str, l * 2 + 1, 2))
        Next
        Return data
    End Function

End Class
