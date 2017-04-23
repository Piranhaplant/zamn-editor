Public Class Tabs
    Inherits Control

    Public WithEvents tabctrl As TabControl
    Public SelectedTab As TabPage
    Public Event TabSelected(ByVal sender As Object, ByVal e As EventArgs)
    Public Event TabsClosed(ByVal sender As Object, ByVal e As EventArgs)
    Public Event TabClosed(ByVal sender As Object, ByVal e As TabEventArgs)

    Public Sub New()
        InitializeComponent()
        tabctrl = New TabControl
        tabctrl.Dock = DockStyle.Fill
        Me.Controls.Add(tabctrl)
    End Sub

    Public Function AddXPage(ByVal txt As String) As TabPage
        tabctrl.TabPages.Add(txt & "     ")
        Dim tp As TabPage = tabctrl.TabPages(tabctrl.TabPages.Count - 1)
        Dim x As New XButton(tp)
        x.Location = New Point(tabctrl.GetTabRect(tabctrl.TabPages.Count - 1).Right - 16, 4)
        Me.Controls.Add(x)
        x.BringToFront()
        AddHandler x.Closing, AddressOf TabClosing
        tabctrl.SelectedTab = tp
        tabctrl_SelectedIndexChanged(Nothing, Nothing)
        Return tp
    End Function

    Private Sub tabctrl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabctrl.Layout
        ReAlignAll()
    End Sub

    Private Sub tabctrl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabctrl.SelectedIndexChanged
        SelectedTab = tabctrl.SelectedTab
        If SelectedTab IsNot Nothing Then
            ReAlignAll()
            RaiseEvent TabSelected(sender, e)
        End If
    End Sub

    Private Sub TabClosing(ByVal sender As Object, ByVal e As TabEventArgs)
        RaiseEvent TabClosed(sender, e)
        If e.cancel Then Return
        If tabctrl.TabPages.Count = 1 Then
            RaiseEvent TabsClosed(Me, EventArgs.Empty)
        End If
    End Sub

    Public Sub ReAlignAll()
        For l As Integer = 0 To Me.Controls.Count - 2
            CType(Me.Controls(l), XButton).ReAlign()
        Next
    End Sub

    Public Sub CloseAll()
        For l As Integer = 0 To tabctrl.TabPages.Count - 1
            Dim e As New TabEventArgs(tabctrl.TabPages(0))
            e.closeAll = True
            RaiseEvent TabClosed(Me, e)
            tabctrl.TabPages.RemoveAt(0)
            Me.Controls.RemoveAt(0)
        Next
        RaiseEvent TabsClosed(Me, EventArgs.Empty)
    End Sub
End Class

Public Class XButton
    Inherits Control

    Private curImg As Bitmap
    Private WithEvents page As TabPage
    Public Event Closing(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New()
        Me.New(Nothing)
    End Sub

    Public Sub New(ByVal tp As TabPage)
        page = tp
        Me.Size = New Size(12, 12)
        curImg = My.Resources.X
    End Sub

    Private Sub XButton_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawImage(curImg, 0, 0, 12, 12)
    End Sub

    Private Sub XButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        curImg = My.Resources.X2
        Me.Invalidate()
    End Sub

    Private Sub XButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        curImg = My.Resources.X
        Me.Invalidate()
    End Sub

    Private Sub XButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        curImg = My.Resources.X3
        Me.Invalidate()
    End Sub

    Private Sub XButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.X >= 0 And e.Y >= 0 And e.X <= 12 And e.Y <= 12 Then
            CType(page.Parent, TabControl).SelectTab(page)
            Dim tabE As New TabEventArgs(page)
            RaiseEvent Closing(Me, tabE)
            If tabE.cancel Then Return
            page.Parent.Controls.Remove(page)
            Dim p As Control = Me.Parent
            Me.Parent.Controls.Remove(Me)
            CType(p, Tabs).ReAlignAll()
        End If
        curImg = My.Resources.X2
        Me.Invalidate()
    End Sub

    Public Sub ReAlign()
        Dim tc As TabControl = CType(page.Parent, TabControl)
        If tc Is Nothing Then Return
        If tc.SelectedTab Is page Then
            Me.Location = New Point(tc.GetTabRect(tc.TabPages.IndexOf(page)).Right - 17, 4)
        Else
            Me.Location = New Point(tc.GetTabRect(tc.TabPages.IndexOf(page)).Right - 18, 6)
        End If
    End Sub
End Class

Public Class TabEventArgs
    Inherits EventArgs

    Public Tab As TabPage
    Public cancel As Boolean = False
    Public closeAll As Boolean = False

    Public Sub New(ByVal tp As TabPage)
        Me.Tab = tp
    End Sub
End Class