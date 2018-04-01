Public Class ZAMNCompress

    Shared bitReader As BitReader

    '   LZSS Parameters
    Const N = 4096 'Sliding Window Length
    Const F = 60 'Length of String
    Const THRESHOLD = 2
    Const NODENIL = N 'End of tree's node

    Shared text_buf(N + F - 1)
    Shared mathc_position As Integer
    Shared match_length As Integer

    'Huffman Parameters
    Const N_CHAR = (256 - THRESHOLD + F)
    Const T = (N_CHAR * 2 - 1)
    Const R = (T - 1)
    Const MAX_FREQ = &H8000

    Structure Node
        Dim Dad As Integer
        Dim LSon As Integer
        Dim RSon As Integer
    End Structure


    Shared d_code As Byte() = {
         &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
         &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
         &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
         &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
         &H1, &H1, &H1, &H1, &H1, &H1, &H1, &H1,
         &H1, &H1, &H1, &H1, &H1, &H1, &H1, &H1,
         &H2, &H2, &H2, &H2, &H2, &H2, &H2, &H2,
         &H2, &H2, &H2, &H2, &H2, &H2, &H2, &H2,
         &H3, &H3, &H3, &H3, &H3, &H3, &H3, &H3,
         &H3, &H3, &H3, &H3, &H3, &H3, &H3, &H3,
         &H4, &H4, &H4, &H4, &H4, &H4, &H4, &H4,
         &H5, &H5, &H5, &H5, &H5, &H5, &H5, &H5,
         &H6, &H6, &H6, &H6, &H6, &H6, &H6, &H6,
         &H7, &H7, &H7, &H7, &H7, &H7, &H7, &H7,
         &H8, &H8, &H8, &H8, &H8, &H8, &H8, &H8,
         &H9, &H9, &H9, &H9, &H9, &H9, &H9, &H9,
         &HA, &HA, &HA, &HA, &HA, &HA, &HA, &HA,
         &HB, &HB, &HB, &HB, &HB, &HB, &HB, &HB,
         &HC, &HC, &HC, &HC, &HD, &HD, &HD, &HD,
         &HE, &HE, &HE, &HE, &HF, &HF, &HF, &HF,
         &H10, &H10, &H10, &H10, &H11, &H11, &H11, &H11,
         &H12, &H12, &H12, &H12, &H13, &H13, &H13, &H13,
         &H14, &H14, &H14, &H14, &H15, &H15, &H15, &H15,
         &H16, &H16, &H16, &H16, &H17, &H17, &H17, &H17,
         &H18, &H18, &H19, &H19, &H1A, &H1A, &H1B, &H1B,
         &H1C, &H1C, &H1D, &H1D, &H1E, &H1E, &H1F, &H1F,
         &H20, &H20, &H21, &H21, &H22, &H22, &H23, &H23,
         &H24, &H24, &H25, &H25, &H26, &H26, &H27, &H27,
         &H28, &H28, &H29, &H29, &H2A, &H2A, &H2B, &H2B,
         &H2C, &H2C, &H2D, &H2D, &H2E, &H2E, &H2F, &H2F,
         &H30, &H31, &H32, &H33, &H34, &H35, &H36, &H37,
         &H38, &H39, &H3A, &H3B, &H3C, &H3D, &H3E, &H3F
        }
    Shared d_len As Byte() = {
         &H3, &H3, &H3, &H3, &H3, &H3, &H3, &H3,
         &H3, &H3, &H3, &H3, &H3, &H3, &H3, &H3,
         &H3, &H3, &H3, &H3, &H3, &H3, &H3, &H3,
         &H3, &H3, &H3, &H3, &H3, &H3, &H3, &H3,
         &H4, &H4, &H4, &H4, &H4, &H4, &H4, &H4,
         &H4, &H4, &H4, &H4, &H4, &H4, &H4, &H4,
         &H4, &H4, &H4, &H4, &H4, &H4, &H4, &H4,
         &H4, &H4, &H4, &H4, &H4, &H4, &H4, &H4,
         &H4, &H4, &H4, &H4, &H4, &H4, &H4, &H4,
         &H4, &H4, &H4, &H4, &H4, &H4, &H4, &H4,
         &H5, &H5, &H5, &H5, &H5, &H5, &H5, &H5,
         &H5, &H5, &H5, &H5, &H5, &H5, &H5, &H5,
         &H5, &H5, &H5, &H5, &H5, &H5, &H5, &H5,
         &H5, &H5, &H5, &H5, &H5, &H5, &H5, &H5,
         &H5, &H5, &H5, &H5, &H5, &H5, &H5, &H5,
         &H5, &H5, &H5, &H5, &H5, &H5, &H5, &H5,
         &H5, &H5, &H5, &H5, &H5, &H5, &H5, &H5,
         &H5, &H5, &H5, &H5, &H5, &H5, &H5, &H5,
         &H6, &H6, &H6, &H6, &H6, &H6, &H6, &H6,
         &H6, &H6, &H6, &H6, &H6, &H6, &H6, &H6,
         &H6, &H6, &H6, &H6, &H6, &H6, &H6, &H6,
         &H6, &H6, &H6, &H6, &H6, &H6, &H6, &H6,
         &H6, &H6, &H6, &H6, &H6, &H6, &H6, &H6,
         &H6, &H6, &H6, &H6, &H6, &H6, &H6, &H6,
         &H7, &H7, &H7, &H7, &H7, &H7, &H7, &H7,
         &H7, &H7, &H7, &H7, &H7, &H7, &H7, &H7,
         &H7, &H7, &H7, &H7, &H7, &H7, &H7, &H7,
         &H7, &H7, &H7, &H7, &H7, &H7, &H7, &H7,
         &H7, &H7, &H7, &H7, &H7, &H7, &H7, &H7,
         &H7, &H7, &H7, &H7, &H7, &H7, &H7, &H7,
         &H8, &H8, &H8, &H8, &H8, &H8, &H8, &H8,
         &H8, &H8, &H8, &H8, &H8, &H8, &H8, &H8
        }

    Shared freq(T + 1) As UInteger 'cumulative freq table
    Shared prnt(T + N_CHAR) As UShort
    Shared son(T) As UShort
    Shared Tree(N + 256) As Node

    Shared getlen As Byte = 0
    Shared getbuf As UInteger = 0

    Shared Sub InitTree()
        Dim i As Integer
        For i = N + 1 To N + 256
            Tree(i).LSon = NODENIL
            Tree(i).RSon = NODENIL
        Next
        For i = 0 To N - 1
            Tree(i).Dad = NODENIL

        Next
    End Sub

    '{-initialize freq tree}
    Private Shared Sub StartHuff()
        Dim i, j As UShort

        For i = 0 To N_CHAR - 1
            freq(i) = 1
            son(i) = i + T
            prnt(i + T) = i
        Next
        i = 0
        j = N_CHAR
        While j <= R
            freq(j) = freq(i) + freq(i + 1)
            son(j) = i
            prnt(i) = j
            prnt(i + 1) = j
            i += 2
            j += 1
        End While
        freq(T) = &HFFFF
        prnt(R) = 0
    End Sub

    '{-reconstruct freq tree }
    Private Shared Sub reconst()

        Dim i, j, k, f, l As UShort
        '  {-halven cumulative freq for leaf nodes}
        j = 0
        For i = 0 To T - 1
            If son(i) >= T Then
                freq(j) = (freq(i) + 1) >> 1
                son(j) = son(i)
                j += 1
            End If
        Next
        ' {-make a tree : first, connect children nodes}
        i = 0
        For j = N_CHAR To T - 1
            k = i + 1
            f = freq(i) + freq(k)
            freq(j) = f
            k = j - 1
            While (f < freq(k))
                k -= 1
            End While
            k += 1
            l = (j - k) * 2
            System.Array.Copy(freq, k, freq, k + 1, l)
            freq(k) = f
            System.Array.Copy(son, k, son, k + 1, l)
            son(k) = i
            i += 2
        Next
        '  {-connect parent nodes}
        For i = 0 To T - 1
            k = son(i)
            prnt(k) = i
            If k < T Then
                prnt(k + 1) = i
            End If
        Next
    End Sub

    '{-update freq tree}
    Private Shared Sub update(ByVal c As UShort)

        Dim i, j, k, l As UShort

        If freq(R) = MAX_FREQ Then
            reconst()
        End If
        c = prnt(c + T)
        Do
            freq(c) += 1
            k = freq(c)
            ' {-swap nodes to keep the tree freq-ordered}
            l = c + 1
            If (k > freq(l)) Then
                While k > freq(l + 1)
                    l += 1
                End While
                freq(c) = freq(l)
                freq(l) = k

                i = son(c)
                prnt(i) = l
                If (i < T) Then
                    prnt(i + 1) = l
                End If
                j = son(l)
                son(l) = i
                prnt(j) = c
                If j < T Then
                    prnt(j + 1) = c
                End If
                son(c) = j
                c = l
            End If
            c = prnt(c)
        Loop Until c = 0 ' do it until reaching the root

    End Sub


    Private Shared Sub EncodeChar(ByVal c As UShort)
        Dim code, len, k As UShort
        code = 0
        len = 0
        k = prnt(c + T)
        '{-search connections from leaf node to the root}
        Do
            code = code << 1
            '{-if node's address is odd, output 1 else output 0}
            If (k And 1) > 0 Then
                code += &H8000
            End If
            len += 1
            k = prnt(k)
        Loop Until k = R
        'PutCode(len, code)
        update(c)
    End Sub

    Private Shared Sub EncodePosition(ByVal c As UShort)
        Dim i As UShort
        '//-output upper 6 bits with encoding
        i = c >> 6
        'PutCode(p_len(i), p_code(i) << 8)
        '  //-output lower 6 bits directly
        'PutCode(6, (c And &H3F) >> 10)
    End Sub

    Private Shared Function DecodePosition() As UShort
        Dim i, j, c As UShort
        'decode upper 6 bits from given table
        i = bitReader.Read(8)
        c = d_code(i)
        c <<= 6
        j = d_len(i)
        'input lower 6 bits directly
        j -= 2
        While j > 0
            j -= 1
            i = (i << 1) Or bitReader.Read
        End While
        Return c Or (i And &H3F)
    End Function

    Private Shared Function DecodeChar() As UShort
        Dim c As UShort
        c = son(R)
        'start searching tree from the root to leaves.
        'Choose Node #(son[]) if input bit = 0
        'Else choose #(son[]+1) (input bit = 1)
        While c < T
            c = son(c + bitReader.Read)
        End While
        c -= T
        update(c)
        Return c
    End Function

    Public Shared Function Decompress(ByVal s As IO.Stream) As Byte()
        Dim result As New List(Of Byte)
        Dim dict(&HFFF) As Byte
        Dim bytesLeft As Integer = s.ReadByte * &H100 + s.ReadByte 'First 2 bytes are the compressed size
        Dim writeDictPos As Integer = N - F 'The dictionary starts at &HFEE for some reason
        Dim readDictPos As Integer
        Dim bitsLeft As Integer = 0
        Dim buffer(bytesLeft) As Byte 'Buffer for compressed data
        bitReader = New BitReader(buffer)
        s.Read(buffer, 0, bytesLeft)

        For i As Integer = 0 To writeDictPos - 1
            dict(i) = 32
        Next
        StartHuff()
        Dim count As Integer = 0
        Dim c As UShort
        Dim j, k As UShort
        While count < bytesLeft
            c = DecodeChar()
            If c < 256 Then
                result.Add(c And &HFF) 'And put it in the result
                dict(writeDictPos) = c 'And the dictionary
                writeDictPos = (writeDictPos + 1) And &HFFF 'Increment the dictionary index, but not over &HFFF
                count += 1
            Else
                readDictPos = (writeDictPos - DecodePosition() - 1) And &HFFF
                j = c - 255 + THRESHOLD
                For k = 0 To j - 1
                    c = dict((readDictPos + k) And &HFFF)
                    result.Add(c)
                    dict(writeDictPos) = c
                    writeDictPos = (writeDictPos + 1) And &HFFF 'Increment the dictionary index, but not over &HFFF
                    count += 1
                Next
            End If
        End While

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
