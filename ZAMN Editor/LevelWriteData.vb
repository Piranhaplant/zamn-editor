Public Class LevelWriteData

    Public data As Byte()
    Public addrOffsets As Integer()
    Public bossDataPtr As List(Of Integer)

    Public Sub New(ByVal data As List(Of Byte), ByVal addrOffsets As Integer(), ByVal bossDataPtr As List(Of Integer))
        Me.data = data.ToArray
        Me.addrOffsets = addrOffsets
        Me.bossDataPtr = bossDataPtr
    End Sub
End Class
