Public Class Item
    Inherits LevelObj

    Public Sub New()

    End Sub

    Public Sub New(ByVal x As UShort, ByVal y As UShort, ByVal type As Byte)
        Me.x = x
        Me.y = y
        Me.type = type
    End Sub

    Public Sub New(ByVal i As Item)
        Me.x = i.x
        Me.y = i.y
        Me.type = i.type
    End Sub

    Public Overrides Function Width(ByVal gfx As LevelGFX) As Integer
        Return 16
    End Function

    Public Overrides Function Height(ByVal gfx As LevelGFX) As Integer
        Return 16
    End Function

    Public Overrides Function Clone() As LevelObj
        Return New Item(Me)
    End Function

    Public Overrides Function ToString() As String
        Return "Item"
    End Function
End Class
