Public Class PasswordEditor

    Public passwords(129) As String
    Dim path As String

    Private lvlNames As String() = {"5", "9", "13", "17", "21", "25", "29", "33", "37", "41", "45", "Credit", "Bonus"}

    Public Overloads Function ShowDialog(ByVal ed As Editor)
        path = ed.r.path
        Dim s As New IO.FileStream(ed.r.path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
        LoadPasswords(s)
        s.Close()
        Return (Me.ShowDialog())
    End Function

    Private Sub pnlPasswords_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlPasswords.Paint
        e.Graphics.DrawLine(Pens.Black, 36, 0, 36, 250)
        e.Graphics.DrawLine(Pens.Black, 0, 14, 448, 14)
        For l As Integer = 0 To lvlNames.Length - 1
            e.Graphics.DrawString(lvlNames(l), Me.Font, Brushes.Black, 0, (l + 1) * 18 + 2)
        Next
        For l As Integer = 1 To 10
            e.Graphics.DrawString(l.ToString, Me.Font, Brushes.Black, l * 40 + 2, 0)
        Next
        For lvl As Integer = 0 To 12
            For victims As Integer = 0 To 9
                e.Graphics.DrawString(passwords(lvl * 10 + victims), Me.Font, Brushes.Black, victims * 40 + 42, lvl * 18 + 20)
            Next
        Next
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim s As New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.ReadWrite, IO.FileShare.Read)
        Do
            s.Seek(Pointers.Passwords, IO.SeekOrigin.Begin)
            Dim rand As New Random()
            For l As Integer = 0 To 25
                s.WriteByte(CByte(rand.Next(0, 20)))
            Next
            For l As Integer = 0 To 19
                s.WriteByte(CByte(rand.Next(2, 18)))
            Next
            s.Seek(20, IO.SeekOrigin.Current)
            Dim values As Byte() = {0, 1, 2, &HFF, &HFE}
            For l As Integer = 0 To 25
                s.WriteByte(values(rand.Next(0, 4)))
            Next
            Try
                LoadPasswords(s)
                Exit Do
            Catch ex As Exception
                Debug.WriteLine("Password Generation Failed")
            End Try
        Loop
        s.Close()
        pnlPasswords.Invalidate()
    End Sub

    Private Sub LoadPasswords(ByVal s As IO.Stream)
        Dim table1(25) As Byte
        Dim table2(19) As Byte
        Dim table3(25) As Byte
        Dim c(20) As Byte
        Dim Chars(20) As Char
        s.Seek(Pointers.Passwords, IO.SeekOrigin.Begin)
        s.Read(table1, 0, 26)
        s.Read(table2, 0, 20)
        s.Read(c, 0, 21)
        For l As Integer = 0 To 20
            Chars(l) = Chr(c(l))
        Next
        s.Read(table3, 0, 26)
        Dim v1 As Integer, v2 As Integer
        For lvl As Integer = 0 To 12
            For victims As Integer = 0 To 9
                v1 = (CInt(table2(victims * 2)) + table3(lvl * 2)) And &HFF
                v2 = (CInt(table2(victims * 2 + 1)) + table3(lvl * 2 + 1)) And &HFF
                passwords(lvl * 10 + victims) = Chars(v1) & Chars(table1(lvl * 2 + 1)) & Chars(table1(lvl * 2)) & Chars(v2)
            Next
        Next
    End Sub
End Class