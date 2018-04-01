Public Class TitleFontSelector

    Public charPadding As Integer = 4

    Public Event CharSelected(ByVal sender As Object, ByVal e As EventArgs)

    Private _SelectedIndex As Integer = -1
    Public Property SelectedIndex As Integer
        Get
            Return _SelectedIndex
        End Get
        Set(value As Integer)
            _SelectedIndex = value
            Me.Invalidate()
        End Set
    End Property

    Private gfx As TitleGFX
    Private curPlt As Integer
    Private rects As List(Of Rectangle)

    Public Sub LoadGFX(ByVal gfx As TitleGFX)
        Me.gfx = gfx

        rects = New List(Of Rectangle)
        Dim x As Integer = 0
        Dim y As Integer = 0
        For Each i As Image In gfx.LetterImgs
            If x + i.Width + charPadding * 2 > Me.Width And x > 0 Then
                y += i.Height + charPadding * 2
                x = 0
            End If
            rects.Add(New Rectangle(x, y, i.Width + charPadding * 2, i.Height + charPadding * 2))
            x += i.Width + +charPadding * 2
        Next
        Me.Invalidate()
    End Sub

    Public Sub SetPalette(ByVal plt As Integer)
        curPlt = plt
        Me.Invalidate()
    End Sub

    Private Sub TitleFontSelector_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        For i As Integer = 0 To rects.Count - 1
            If rects(i).Contains(e.Location) Then
                SelectedIndex = i
                Me.Invalidate()
                RaiseEvent CharSelected(Me, EventArgs.Empty)
                Return
            End If
        Next
    End Sub

    Private Sub TitleFontSelector_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If gfx Is Nothing Then Return
        For i As Integer = 0 To gfx.LetterImgs.Length - 1
            SMDGFX.DrawWithPlt(e.Graphics, rects(i).X + charPadding, rects(i).Y + charPadding, gfx.LetterImgs(i), gfx.plt, curPlt * &H10, &H10)
            If i = SelectedIndex Then
                e.Graphics.DrawRectangle(Pens.White, rects(i))
            End If
        Next
    End Sub
End Class