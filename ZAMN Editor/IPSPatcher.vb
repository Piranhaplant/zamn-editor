Imports System.IO

Public Class IPSPatcher

    Public Shared Sub ApplyPatch(ByVal patch As Stream, ByVal target As Stream)
        Dim header(4) As Byte
        patch.Read(header, 0, 5)
        Dim headerString As String = System.Text.Encoding.ASCII.GetString(header)
        If headerString <> "PATCH" Then
            Throw New Exception("Input file was not a valid IPS patch")
        End If
        While patch.Position < patch.Length
            Dim rle As Boolean = False
            Dim rleByte As Byte
            Dim position As Integer = patch.ReadByte() * &H10000 + patch.ReadByte() * &H100 + patch.ReadByte()
            If position = &H454F46 Then 'EOF
                Exit While
            End If
            Dim size As Integer = patch.ReadByte() * &H100 + patch.ReadByte()
            If size = 0 Then
                size = patch.ReadByte() * &H100 + patch.ReadByte()
                rleByte = patch.ReadByte()
                rle = True
            End If
            If position + size > target.Length Then
                target.SetLength(position + size)
            End If
            target.Seek(position, SeekOrigin.Begin)
            For i As Integer = 0 To size - 1
                If rle Then
                    target.WriteByte(rleByte)
                Else
                    target.WriteByte(patch.ReadByte())
                End If
            Next
        End While
    End Sub

    Public Shared Function CreatePatch(ByVal clean As Stream, ByVal modified As Stream) As Byte()
        Dim patch As New List(Of Byte)(modified.Length \ &H10000)
        patch.AddRange(System.Text.Encoding.ASCII.GetBytes("PATCH")) 'Patch header
        While Not modified.Position = modified.Length
            
        End While
        Return patch.ToArray()
    End Function

    Private Shared Function findChangeBlock(ByVal clean As Stream, ByVal modified As Stream) As List(Of Byte)
        Dim l As New List(Of Byte)
        Do

        Loop
    End Function
End Class
