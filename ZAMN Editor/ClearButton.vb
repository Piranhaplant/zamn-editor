Public Class ClearButton

    Public mouseOver As Boolean = False

    Private Sub ClearButton_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If mouseOver Then
            e.Graphics.DrawImage(My.Resources.Clear2, 0, 0, 16, 16)
        Else
            e.Graphics.DrawImage(My.Resources.Clear, 0, 0, 16, 16)
        End If
    End Sub

    Private Sub ClearButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        mouseOver = True
        Me.Invalidate()
    End Sub

    Private Sub ClearButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        mouseOver = False
        Me.Invalidate()
    End Sub
End Class
