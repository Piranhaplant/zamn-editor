Public Class ViewImage

    Public Overloads Function ShowDialog(ByVal img As Bitmap) As DialogResult
        PictureBox1.Image = img
        Return Me.ShowDialog()
    End Function
End Class