Imports Microsoft.VisualBasic

' <summary>
' Reads byte array as stream of bits
' </summary>
Public Class BitReader

    Public Position As Integer = 0
    Private source() As Byte

    Sub New(ByVal source() As Byte)

        Me.source = source
    End Sub



    ReadOnly Property Length As Integer
        Get
            Return source.Length * 8
        End Get
    End Property

    ' <summary>
    ' Reads bitCount bits from stream And return as UInt32
    ' </summary>
    Public Function Read(ByVal bitCount As Integer) As UInteger
        Dim res As UInteger = 0

        For i As Integer = 0 To bitCount - 1
            Dim bit As Integer = Read()
            If bit < 0 Then
                Throw New System.Exception("Can not read needed count of the bits")
            End If
            res = (res << 1) Or bit
        Next
        Return res
    End Function


    ' <summary>
    ' Reads one bit from stream
    ' </summary>
    Public Function Read() As SByte
        If Position >= Length Then
            Return -1
        End If
        Dim i As Integer = Position \ 8
        Dim j As Integer = Position Mod 8
        Position += 1
        Return (source(i) >> (7 - j)) And 1
    End Function

    ' <summary>
    ' Moves Position
    ' </summary>
    Public Function Seek(shift As Integer) As Boolean
        Position += shift
        If Position < 0 Then
            Position = 0
            Return False
        End If
        If Position >= Length Then
            Position = Length - 1
            Return False
        End If
        Return True
    End Function
End Class


