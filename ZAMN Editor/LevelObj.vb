Public MustInherit Class LevelObj

    Public Property X As Integer
    Public Property Y As Integer
    Public MustOverride Function Width(ByVal gfx As LevelGFX) As Integer
    Public MustOverride Function Height(ByVal gfx As LevelGFX) As Integer
    Public Overridable Property Type As Integer

    Public Property Location As Point
        Get
            Return New Point(X, Y)
        End Get
        Set(value As Point)
            X = value.X
            Y = value.Y
        End Set
    End Property

    Public Function Size(ByVal gfx As LevelGFX) As Size
        Return New Size(Width(gfx), Height(gfx))
    End Function

    Public Function Rect(ByVal gfx As LevelGFX) As Rectangle
        Return New Rectangle(X + 1, Y + 1, Width(gfx) - 1, Height(gfx) - 1)
    End Function

    Public MustOverride Function Clone() As LevelObj

    Public Overridable Function Selectable() As Boolean
        Return True
    End Function
End Class