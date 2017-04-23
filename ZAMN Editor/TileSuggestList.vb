Public Class TileSuggestList
    Public Shared Lists As Byte()() = {My.Resources.Grass, My.Resources.Mall, My.Resources.Pyramid, My.Resources.GrassR}
    Public Shared Data As New List(Of List(Of List(Of List(Of Byte))))
    Public Shared ConnectsTo As New List(Of List(Of List(Of List(Of Integer))))
    Public Shared AllDataLists As New List(Of List(Of List(Of Byte)))
    Public Shared ProbFiles As Byte()() = {My.Resources.GrassProb, My.Resources.Mall, My.Resources.Pyramid}
    Public Shared Probability As Double()()

    Public Shared Sub LoadAll()
        Dim s As IO.BinaryReader
        For Each list In Lists
            s = New IO.BinaryReader(New ByteArrayStream(list))
            Data.Add(New List(Of List(Of List(Of Byte))))
            ConnectsTo.Add(New List(Of List(Of List(Of Integer))))
            AllDataLists.Add(New List(Of List(Of Byte)))
            For dir As Integer = 0 To 3
                Data.Last.Add(New List(Of List(Of Byte)))
                ConnectsTo.Last.Add(New List(Of List(Of Integer)))
                For l As Integer = 1 To s.ReadInt32
                    Data.Last.Last.Add(New List(Of Byte))
                    ConnectsTo.Last.Last.Add(New List(Of Integer))
                    For m As Integer = 1 To s.ReadInt32
                        ConnectsTo.Last.Last.Last.Add(s.ReadInt32)
                    Next
                    For m As Integer = 1 To s.ReadInt32
                        Data.Last.Last.Last.Add(s.ReadByte)
                    Next
                    AllDataLists.Last.Add(Data.Last.Last.Last)
                Next
            Next
        Next
        LoadProbs()
    End Sub

    Public Shared Function GetList(ByVal tilesetNum As Integer, ByVal startTileNum As Byte, ByVal direction As Integer) As List(Of Byte)
        Dim l As New List(Of Byte)
        If tilesetNum > -1 Then
            Dim index As Integer
            For m As Integer = 0 To Data(tilesetNum)(direction).Count - 1
                If Data(tilesetNum)(direction)(m).Contains(startTileNum) Then
                    index = m
                    Exit For
                End If
            Next
            For Each i As Integer In ConnectsTo(tilesetNum)(direction)(index)
                l.AddRange(AllDataLists(tilesetNum)(i))
            Next
        End If
        Return l
    End Function

    Public Shared Sub LoadProbs()
        Dim s As IO.BinaryReader
        ReDim Probability(ProbFiles.Length - 1)
        For l As Integer = 0 To ProbFiles.Length - 1
            ReDim Probability(l)(511)
            s = New IO.BinaryReader(New ByteArrayStream(ProbFiles(l)))
            For m As Integer = 0 To 511
                Probability(l)(m) = s.ReadDouble
            Next
        Next
    End Sub

    Public Shared Function GetProbList(ByVal tilesetNum As Integer, ByVal direction As Integer, ByVal lst As List(Of Byte)) As List(Of Double)
        Dim probList As New List(Of Double)
        For Each b As Byte In lst
            probList.Add(Probability(tilesetNum Mod Pointers.SuggestTilesets.Length)(b + (direction Mod 2) * 256))
        Next
        Return probList
    End Function
End Class

'Hedges connect to other hedges (top and bottom)
'Hedges connect to walls (top and bottom)