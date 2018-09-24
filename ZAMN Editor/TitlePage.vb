Public Class TitlePage

    Public words As New List(Of Word)

    Public Sub New(ByVal s As IO.Stream)
        Do
            words.Add(New Word(s))
            If words.Last.last Then Exit Do
        Loop
    End Sub

    Public Sub New(ByVal tp As TitlePage)
        For Each w As Word In tp.words
            words.Add(New Word(w))
        Next
    End Sub

    Public Sub Write(ByVal lst As List(Of Byte), ByVal pageNum As Byte)
        For Each w As Word In words
            lst.AddRange(New Byte() {w.x, w.y, w.font, pageNum})
            For Each c As Integer In w.chars
                lst.Add(c)
            Next
            lst.Add(&HFF)
            If w Is words.Last Then
                lst(lst.Count - 1) = 0
            End If
        Next
    End Sub

    Public Overrides Function ToString() As String
        Dim str As String = ""
        For Each w As Word In words.OrderBy(Function(x) x)
            str &= w.ToString & " "
        Next
        Return str.Trim()
    End Function

    Public Shared Function FormatTitleString(ByVal str As String) As String
        str = str.Replace("LEVEI", "LEVEL")
        If str.Contains("CREDIT") Then
            str = Mid(str, InStrRev(str, "CREDIT"))
            str = ReplaceFirst(str, "LEVEL", "LEVEL:")
        ElseIf str.Contains("BONUS") Then
            str = Mid(str, InStrRev(str, "BONUS"))
            str = ReplaceFirst(str, "LEVEL", "LEVEL:")
        ElseIf str.Contains("LEVEL") Then
            str = Mid(str, InStrRev(str, "LEVEL"))
            Dim p As Integer = InStr(InStr(str, " ") + 1, str, " ") - 1
            str = Mid(str, 1, p) & ":" & Mid(str, p + 1)
        End If
        str = ProperCase(str.Replace("  ", " "))
        Return str
    End Function

    Private Shared nameLCase As String() = {"The", "A", "An", "And", "But", "As", "At", "By", "For", "From", "In", "Into", "Of", "Off", "On", "Onto", "Over", "Past", "To", "Upon", "With", "Vs"}

    Public Shared Function ProperCase(ByVal str As String) As String
        str = str.Trim()
        If String.IsNullOrEmpty(str) Then
            Return str
        End If
        Dim pos As Integer = 1
        Dim len As Integer
        Dim rstr As String = UCase(str(0)) & LCase(Mid(str, 2))
        Do While InStr(pos, rstr, " ") > 0
            pos = InStr(pos, rstr, " ")
            rstr = Mid(rstr, 1, pos) & UCase(rstr(pos)) & Mid(rstr, pos + 2)
            pos += 1
        Loop
        For l As Integer = 0 To nameLCase.Length - 1
            len = nameLCase(l).Length
            pos = 1
            Do While InStr(pos, rstr, nameLCase(l))
                pos = InStr(pos, rstr, nameLCase(l))
                If (pos >= 3 AndAlso rstr(pos - 3) <> ":") And (pos = rstr.Length - len + 1 OrElse rstr(pos + len - 1) = " ") Then
                    rstr = Mid(rstr, 1, pos - 1) & LCase(nameLCase(l)) & Mid(rstr, pos + len)
                End If
                pos += 1
            Loop
        Next
        Return rstr
    End Function

    Public Shared Function ReplaceFirst(ByVal str As String, ByVal findStr As String, ByVal replaceStr As String) As String
        Dim pos As Integer = InStr(str, findStr)
        If pos > 0 Then
            Return Mid(str, 1, pos - 1) & replaceStr & Mid(str, pos + findStr.Length)
        End If
        Return str
    End Function
End Class

Public Class Word
    Implements IComparable(Of Word)

    Public x As Byte
    Public y As Byte
    Public font As Byte
    Public chars As New List(Of Byte)
    Public last As Boolean

    Public Shared Strs As String() = {"", "", "", "", "", "", "", "", "", "", "", "", "", "F", "", "", _
                                      "J", "", "", "H", "", "", "N", "", "", "L", "", "", "P", "", "", "", _
                                      " ", "NT", "TH", "TE", "STE", "IT", "ET", "ST", "RT", "TO", "NTS", "TY", "CTO", "T", "TA", "PTS", _
                                      "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "O", "Q", "", "", "", "", _
                                      "", "A", "B", "C", "D", "E", "F", "G", "H", "A", "J", "K", "L", "M", "N", "O", _
                                      "P", "R", "R", "S", "P", "U", "EI", "LI", "X", "Y", "Z", "E", "S", "M", "", "", _
                                      "", "R", "E", "E", "I", "O", "S", "!", "F", "E", "R", "", "L", "E", "W", "", _
                                      "I", "R", "H", "H", "T", "V", "E", "", "I", "", "O", "N", "", " ", "", ""}

    Public Sub New(ByVal s As IO.Stream)
        Me.x = s.ReadByte
        Me.y = s.ReadByte
        Me.font = s.ReadByte
        s.ReadByte() 'skip page number
        Do
            Dim num As Byte = s.ReadByte
            If num = &HFF Or num = 0 Then
                last = (num = 0)
                Return
            End If
            chars.Add(num)
        Loop
    End Sub

    Public Sub New(ByVal w As Word)
        Me.x = w.x
        Me.y = w.y
        Me.font = w.font
        For Each b As Byte In w.chars
            Me.chars.Add(b)
        Next
    End Sub

    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Dim str As String = ""
        For l As Integer = 0 To chars.Count - 1
            If l > 0 AndAlso (chars(l) = &H2E And chars(l - 1) <> &H7B) Then
                str &= "ITA"
            Else
                str &= Strs(chars(l))
            End If
        Next
        Return str
    End Function

    Public Function CompareTo(other As Word) As Integer Implements System.IComparable(Of Word).CompareTo
        Dim value As Integer = y.CompareTo(other.y)
        If value = 0 Then
            value = x.CompareTo(other.x)
        End If
        Return value
    End Function
End Class