Public Class TableContextMenuItem

    Public Property DropDown As TableContextMenu
    Public Property LayoutMode As TableContextLayoutMode = TableContextLayoutMode.Grid

    Public Property ImgPadding As Integer = 4
    Private _Image As Image
    Public Property Image As Image
        Get
            Return _Image
        End Get
        Set(value As Image)
            _Image = value
            Me.Width = value.Width + ImgPadding * 2
            Me.Height = value.Height + ImgPadding * 2
        End Set
    End Property

    Private hovered As Boolean = False

    Public Sub New()
        InitializeComponent()

        Me.Width = 20
        Me.Height = 20
    End Sub

    Private Sub TableContextMenuItem_MouseEnter(sender As Object, e As System.EventArgs) Handles Me.MouseEnter
        hovered = True
        Me.Invalidate()
    End Sub

    Private Sub TableContextMenuItem_MouseLeave(sender As Object, e As System.EventArgs) Handles Me.MouseLeave
        hovered = False
        Me.Invalidate()
    End Sub

    Private Sub TableContextMenuItem_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If hovered Then
            e.Graphics.FillRectangle(SystemBrushes.GradientActiveCaption, Me.ClientRectangle)
            e.Graphics.DrawRectangle(SystemPens.MenuHighlight, Me.ClientRectangle)
        End If
        If _Image IsNot Nothing Then
            e.Graphics.DrawImage(_Image, ImgPadding, ImgPadding)
        End If
    End Sub

End Class

Public Enum TableContextLayoutMode
    Grid
    Bar
End Enum