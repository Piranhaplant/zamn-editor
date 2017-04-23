Public Class Victim
    Inherits LevelObj

    Public num As Integer
    Public unused As Integer
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

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal unused As Integer, ByVal num As Integer, ByVal ptr As Integer)
        Me.X = x
        Me.Y = y
        Me.unused = unused
        Me.num = num
        If num = 16 Then
            Me.num = 10
        End If
        _ptr = ptr
        UpdateIdx()
    End Sub

    Public Sub New(ByVal v As Victim)
        Me.X = v.X
        Me.Y = v.Y
        Me.unused = v.unused
        _ptr = v.ptr
        Me.num = v.num
        UpdateIdx()
    End Sub

    Public Overrides Function Width(gfx As LevelGFX) As Integer
        Return gfx.VictimImages(_index).Width
    End Function

    Public Overrides Function Height(gfx As LevelGFX) As Integer
        Return gfx.VictimImages(_index).Height
    End Function

    Private Sub UpdatePtr()
        If _index > 0 Then
            _ptr = ZAMNEditor.Pointers.SpritePtrs(_index)
        End If
    End Sub

    Private Sub UpdateIdx()
        _index = Array.IndexOf(ZAMNEditor.Pointers.SpritePtrs, _ptr)
        If _index = -1 Then _index = 0
    End Sub

    'Doesn't do anything because victims can't be cloned
    Public Overrides Function Clone() As LevelObj
        Return Nothing
    End Function

    Public Overrides Function ToString() As String
        Return "Victim"
    End Function
End Class
