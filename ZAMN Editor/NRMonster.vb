Public Class NRMonster
    Inherits LevelObj

    Public unused1 As UShort
    Public unused2 As UShort
    Public _ptr As Integer
    Public Property ptr As Integer
        Get
            Return _ptr
        End Get
        Set(value As Integer)
            _ptr = value
            UpdateIdx()
        End Set
    End Property
    Public _index As Integer
    Public Property index As Integer
        Get
            Return _index
        End Get
        Set(value As Integer)
            _index = value
            UpdatePtr()
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal x As UShort, ByVal y As UShort, ByVal unused1 As UShort, ByVal unused2 As UShort, ByVal ptr As Integer)
        Me.x = x
        Me.y = y
        Me.unused1 = unused1
        Me.unused2 = unused2
        _ptr = ptr
        UpdateIdx()
    End Sub

    Public Sub New(ByVal m As NRMonster)
        Me.x = m.x
        Me.y = m.y
        Me.unused1 = m.unused1
        Me.unused2 = m.unused2
        _ptr = m.ptr
        UpdateIdx()
    End Sub

    Public Overrides Function Clone() As LevelObj
        Return New NRMonster(Me)
    End Function

    Public Overrides Function Width(gfx As LevelGFX) As Integer
        Return gfx.VictimImages(_index).Width
    End Function

    Public Overrides Function Height(gfx As LevelGFX) As Integer
        Return gfx.VictimImages(_index).Height
    End Function

    Private Sub UpdatePtr()
        If _index > 0 Then
            _ptr = ZAMNEditor.Pointers.SpritePtrs(_index)
        Else
            _ptr = 0
        End If
    End Sub

    Private Sub UpdateIdx()
        _index = Array.IndexOf(ZAMNEditor.Pointers.SpritePtrs, _ptr)
        If _index = -1 Then _index = 0
    End Sub

    Public Overrides Function ToString() As String
        Return "Non-respawning Monster"
    End Function
End Class
