Public Class ZAMNCompress

    Public Shared Function Decompress(ByVal s As IO.Stream) As Byte()
        Dim result As New List(Of Byte)
        Dim dict(&HFFF) As Byte
        Dim bytesLeft As Integer = s.ReadByte + s.ReadByte * &H100 'First 2 bytes are the compressed size
        Dim writeDictPos As Integer = &HFEE 'The dictionary starts at 0xFEE for some reason
        Dim readDictPos As Integer
        Dim bitsLeft As Integer = 0
        Dim writeByte As Byte 'The byte that will specify how to read from the file
        Dim curByte As Byte 'Used to temporarily hold data
        Do
            If bitsLeft = 0 Then 'When all the bits are used
                bitsLeft = 8 'Reset
                If ReadNext(s, writeByte, bytesLeft) Then Exit Do 'And get a new byte
            End If
            bitsLeft -= 1
            If (writeByte And 1) = 1 Then 'If the current bit is one
                If ReadNext(s, curByte, bytesLeft) Then Exit Do 'Simply read a byte from the file
                result.Add(curByte) 'And put it in the result
                dict(writeDictPos) = curByte 'And the dictionary
                writeDictPos = (writeDictPos + 1) And &HFFF 'Increment the dictionary index, but not over 0xFFF
            Else 'If the current bit is 0
                If ReadNext(s, readDictPos, bytesLeft) OrElse ReadNext(s, curByte, bytesLeft) Then Exit Do
                readDictPos = ((curByte And &HF0) * 16) Or readDictPos 'These 3 nybbles specify a read position from the dictionary
                For l As Integer = 0 To (curByte And &HF) + 2 'The last nybble is how many bytes to read
                    curByte = dict(readDictPos)
                    dict(writeDictPos) = curByte
                    result.Add(curByte)
                    writeDictPos = (writeDictPos + 1) And &HFFF
                    readDictPos = (readDictPos + 1) And &HFFF
                Next
            End If
            writeByte >>= 1 'Move to the next bit
        Loop
        Return result.ToArray()
    End Function

    Private Shared Function ReadNext(ByVal s As IO.Stream, ByRef result As Integer, ByRef bytesLeft As Integer) As Boolean
        If bytesLeft = 0 Then Return True
        bytesLeft -= 1
        result = s.ReadByte()
        Return False
    End Function

    Public Shared Function Compress(ByVal data As Byte()) As Byte()
        Dim result As New List(Of Byte)(data.Length \ 2) 'Making the default size be half that of the original data
        Dim dict(&HFFF) As Byte
        Dim dictIndex As Integer = &HFEE
        Dim dataIndex As Integer = 0
        Dim formatByte As Byte
        Dim formatBitCt As Integer = 0
        Dim formatByteIndex As Integer = 2 'The first format byte will be after the file size

        Dim findDictPos As Integer, findDictLen As Integer
        Dim findRepSize As Integer, findRepLen As Integer

        result.Add(0) 'The final size will be put here
        result.Add(0)
        result.Add(0) 'And one more to hold the first format byte
        Do Until dataIndex = data.Length
            formatByte >>= 1
            formatBitCt += 1
            FindInDict(dict, data, dataIndex, findDictPos, findDictLen) 'Search for a dictionary match
            FindRepeat(data, dataIndex, findRepSize, findRepLen) 'Search for a repeating pattern
            If findRepLen - findRepSize > findDictLen And findRepLen >= 3 Then 'Most efficient to insert a data repeat
                'Write the data to be repeated
                For i As Integer = 0 To findRepSize - 1
                    result.Add(data(dataIndex + i))
                    formatByte = formatByte Or &H80 'Set the bit in the format byte
                    If formatBitCt = 8 Then 'If the format byte is full
                        result(formatByteIndex) = formatByte
                        formatByte = 0
                        formatBitCt = 0
                        formatByteIndex = result.Count
                        result.Add(0) 'Placeholder for next format byte
                    End If
                    formatByte >>= 1
                    formatBitCt += 1
                Next
                'Tell it to repeat
                result.Add(dictIndex And &HFF) 'Write the dictionary pos
                result.Add(((dictIndex And &HF00) >> 4) + (findRepLen - 3)) 'Write the rest of the pos, and the length
                For i As Integer = 0 To findRepLen + findRepSize - 1 'Insert the new data to the dictionary
                    dict((dictIndex + i) And &HFFF) = data(dataIndex + (i Mod findRepSize))
                Next
                dictIndex = (dictIndex + findRepLen + findRepSize) And &HFFF
                dataIndex += findRepLen + findRepSize
            ElseIf findDictPos > -1 Then 'Insert a load from the dictionary
                For i As Integer = 0 To findDictLen - 1 'Write the new bytes to the dictionary
                    dict(dictIndex) = dict((findDictPos + i) And &HFFF)
                    dictIndex = (dictIndex + 1) And &HFFF
                Next
                dataIndex += findDictLen
                result.Add(findDictPos And &HFF)
                result.Add(((findDictPos And &HF00) >> 4) + (findDictLen - 3))
            Else 'Just insert the byte by itself
                result.Add(data(dataIndex))
                dict(dictIndex) = data(dataIndex)
                dictIndex = (dictIndex + 1) And &HFFF
                dataIndex += 1
                formatByte = formatByte Or &H80
            End If
            If formatBitCt = 8 Or dataIndex = data.Length Then 'Format byte is full
                formatByte >>= (8 - formatBitCt) 'If the file has ended, but there is still part of a format byte left
                result(formatByteIndex) = formatByte 'Insert the format byte to the file
                formatByte = 0 'Reset it
                formatBitCt = 0
                formatByteIndex = result.Count
                result.Add(0) 'Make a placeholder for the next one
            End If
        Loop

        Dim len As Integer = result.Count - 2 'Don't cout the first two bytes themselves
        result(0) = len And &HFF
        result(1) = (len And &HFF00) >> 8
        Return result.ToArray()
    End Function

    'This will find the longest match in the dictionary
    Private Shared Sub FindInDict(ByVal dict As Byte(), ByVal data As Byte(), ByVal index As Integer, ByRef outPos As Integer, ByRef outLen As Integer)
        Dim maxMatchCt As Integer = 0
        Dim maxMatchPos As Integer = -1
        For idict As Integer = 0 To dict.Length - 1
            If dict(idict) = data(index) Then
                Dim i2 As Integer = 0
                For i2 = 0 To 17
                    If index + i2 >= data.Length Then Exit For
                    If dict((idict + i2) And &HFFF) <> data(index + i2) Then Exit For
                Next
                If i2 > maxMatchCt And i2 > 2 Then
                    maxMatchCt = i2
                    maxMatchPos = idict
                End If
            End If
        Next
        outPos = maxMatchPos
        outLen = maxMatchCt
    End Sub

    'This will find longest repeating sequence
    Private Shared Sub FindRepeat(ByVal data As Byte(), ByVal index As Integer, ByRef dataSize As Integer, ByRef totalSize As Integer)
        Dim maxSize As Integer = 1
        Dim maxDataSize As Integer = 0
        For dsize As Integer = 1 To 8
            Dim tsize As Integer
            For tsize = dsize To dsize + 17
                If index + tsize >= data.Length Then Exit For
                If data(index + tsize) <> data(index + (tsize Mod dsize)) Then Exit For
            Next
            If tsize - dsize > maxDataSize Then
                maxDataSize = tsize - dsize
                maxSize = dsize
            End If
        Next
        dataSize = maxSize
        totalSize = maxDataSize
    End Sub
End Class
