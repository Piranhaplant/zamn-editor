Public Class Monster
    Inherits LevelObj

    Public delay As Byte
    Public radius As Byte
    Private _ptr As Integer
    Public Property ptr As Integer
        Get
            Return _ptr
        End Get
        Set(value As Integer)
            _ptr = value
            UpdateIdx()
        End Set
    End Property
    Private _index As Integer
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

    Public Sub New(ByVal radius As UShort, ByVal x As Integer, ByVal y As Integer, ByVal delay As UShort, ByVal ptr As Integer)
        Me.delay = delay
        Me.X = x
        Me.Y = y
        Me.radius = radius
        _ptr = ptr
        UpdateIdx()
    End Sub

    Public Sub New(ByVal m As Monster)
        Me.delay = m.delay
        Me.X = m.X
        Me.Y = m.Y
        Me.radius = m.radius
        _ptr = m.ptr
        UpdateIdx()
    End Sub

    Public Overrides Function Clone() As LevelObj
        Return New Monster(Me)
    End Function

    Public Overrides Function Width(ByVal gfx As LevelGFX) As Integer
        Return gfx.VictimImages(_index).Width
    End Function

    Public Overrides Function Height(ByVal gfx As LevelGFX) As Integer
        Return gfx.VictimImages(_index).Height
    End Function

    Private Sub UpdateIdx()
        _index = Array.IndexOf(ZAMNEditor.Pointers.SpritePtrs, _ptr)
        If _index = -1 Then _index = 0
    End Sub

    Private Sub UpdatePtr()
        If _index > 0 Then
            _ptr = ZAMNEditor.Pointers.SpritePtrs(_index)
        Else
            _ptr = 0
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return "Monster"
    End Function
End Class
