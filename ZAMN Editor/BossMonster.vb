Public Class BossMonster
    Inherits LevelObj

    Public _ptr As Integer
    Public Property ptr As Integer
        Get
            Return _ptr
        End Get
        Set(value As Integer)
            _ptr = value
            UpdateName()
        End Set
    End Property
    Public name As String
    Public exData As Byte()

    Public Shared dispfont As New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point)

    Public Sub New()

    End Sub

    Public Sub New(ByVal ptr As Integer, ByVal x As Integer, ByVal y As Integer)
        _ptr = ptr
        Me.X = x
        Me.Y = y
        UpdateName()
    End Sub

    Public Sub New(ByVal ptr As Integer, ByVal s As IO.Stream, ByVal dataLen As Integer)
        _ptr = ptr
        ReDim exData(dataLen - 1)
        For l As Integer = 0 To dataLen - 1
            exData(l) = s.ReadByte
        Next
    End Sub

    Public Sub New(ByVal ptr As Integer, ByVal exData As Byte())
        _ptr = ptr
        Me.exData = exData
    End Sub

    Public Sub New(ByVal m As BossMonster)
        _ptr = m.ptr
        Me.X = m.X
        Me.Y = m.Y
        Me.name = m.name
    End Sub

    Public Overrides Function Clone() As LevelObj
        Return New BossMonster(Me)
    End Function

    Public Overrides Property Type As Integer
        Get
            Return _ptr
        End Get
        Set(value As Integer)
            _ptr = value
        End Set
    End Property

    Public Overrides Function Width(ByVal gfx As LevelGFX) As Integer
        Return TextRenderer.MeasureText(name, dispfont).Width
    End Function

    Public Overrides Function Height(ByVal gfx As LevelGFX) As Integer
        Return TextRenderer.MeasureText(name, dispfont).Height
    End Function

    Private Sub UpdateName()
        Dim indx As Integer = Array.IndexOf(ZAMNEditor.Pointers.BossMonsters, _ptr)
        If indx > -1 Then
            name = ZAMNEditor.Pointers.BossMonsterNames(indx)
        Else
            name = "Unknown: 0x" & Hex(_ptr)
        End If
    End Sub

    Public Function GetBGPalette() As Integer
        If exData IsNot Nothing AndAlso exData.Length >= 4 Then
            Return Pointers.ToInteger(exData, 0)
        Else
            Return -1
        End If
    End Function

    Public Function GetSpritePalette() As Integer
        If exData IsNot Nothing AndAlso exData.Length >= 8 Then
            Return Pointers.ToInteger(exData, 4)
        Else
            Return -1
        End If
    End Function

    Public Overrides Function Selectable() As Boolean
        Return Not ZAMNEditor.Pointers.SpBossMonsters.Contains(ptr)
    End Function

    Public Overrides Function ToString() As String
        Return "Boss Monster: " + name
    End Function
End Class
