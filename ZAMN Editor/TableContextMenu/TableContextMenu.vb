Imports System.Runtime.InteropServices

Public Class TableContextMenu

    Public Property AutoHeight As Boolean = True
    Public Property Items As List(Of TableContextMenuItem)

    Public Sub New()
        InitializeComponent()

        Items = New List(Of TableContextMenuItem)
    End Sub

    Public Sub LoadItems()
        LayoutItems()
        ReaddItems()
    End Sub

    Public Sub ReaddItems()
        Me.Controls.Clear()
        For Each i As TableContextMenuItem In Items
            Me.Controls.Add(i)
        Next
    End Sub

    Public Sub LayoutItems()
        Dim finalPts As New List(Of Point)
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim nextY As Integer = 0

        For l As Integer = 0 To Items.Count - 1
            Dim i As TableContextMenuItem = Items(l)
            If i.LayoutMode = TableContextLayoutMode.Bar Then
                x = 0
                y = nextY
                finalPts.Add(New Point(x, y))
                i.Width = Me.Width
                y += i.Height
                nextY = y
            Else
                If x + i.Width > Me.Width And x > 0 Then
                    y = nextY
                    x = 0
                    finalPts.Add(New Point(x, y))
                    x += i.Width
                    nextY += i.Height
                Else
                    finalPts.Add(New Point(x, y))
                    x += i.Width
                    nextY = Math.Max(nextY, y + i.Height)
                End If
            End If
        Next

        If AutoHeight Then
            Me.Height = nextY
        End If
        'Change their positions at the end because it prevents flickering
        For l As Integer = 0 To Items.Count - 1
            Items(l).Location = finalPts(l)
        Next
    End Sub

    Private Sub TableContextMenu_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        If Items IsNot Nothing Then
            LayoutItems()
        End If
        Me.Invalidate()
    End Sub

    'Private Sub TableContextMenu_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    '    e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, 0, 0, Me.Width - 1, Me.Height - 1)
    'End Sub

    'Private Sub MainForm_Activated(sender As Object, e As System.EventArgs)
    '    Me.Hide()
    'End Sub

    'Private Const CS_DROPSHADOW As Integer = &H20000
    'Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
    '        Return cp
    '    End Get
    'End Property

    ''Here's some windows only code that will make the form behave like a proper pop-up for
    ''http://stackoverflow.com/questions/8669368/how-to-make-a-popup-hint-drop-down-popup-window-in-winforms
    ''Additionally it will make it resize using the standard windows resizing
    ''http://stackoverflow.com/questions/2575216/resize-winform-with-no-border

    'Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
    '    Get
    '        Return True
    '    End Get
    'End Property

    'Private _activating As Boolean = False

    'Private Const WM_NCACTIVATE As Integer = &H86
    'Private Const WM_NCHITTEST As Integer = &H84

    'Private Const HTRIGHT As Integer = 11
    'Private Const HTBOTTOM As Integer = 15
    'Private Const HTBOTTOMRIGHT As Integer = 17

    'Private Const gripSize As Integer = 4

    '<DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    'Public Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    'End Function

    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    ' The popup needs to be activated for the user to interact with it,
    '    ' but we want to keep the owner window's appearance the same.
    '    If m.Msg = WM_NCACTIVATE AndAlso Not _activating AndAlso (m.WParam <> IntPtr.Zero) Then
    '        ' The popup is being activated, ensure parent keeps activated appearance
    '        _activating = True
    '        SendMessage(Me.Owner.Handle, WM_NCACTIVATE, 1, 0)
    '        _activating = False
    '        ' Call base.WndProc here if you want the appearance of the popup to change
    '    ElseIf m.Msg = WM_NCHITTEST Then
    '        Dim pos As New Point(m.LParam.ToInt32() And &HFFFF, m.LParam.ToInt32() >> 16)
    '        pos = Me.PointToClient(pos)
    '        'Dim vScrollSize As Integer = IIf(Me.VerticalScroll.Visible, SystemInformation.VerticalScrollBarWidth, 0)
    '        'Dim hScrollSize As Integer = IIf(Me.HorizontalScroll.Visible, SystemInformation.HorizontalScrollBarHeight, 0)
    '        Dim sizeX As Boolean = pos.X >= Me.ClientSize.Width - gripSize ' + vScrollSize
    '        Dim sizeY As Boolean = pos.Y >= Me.ClientSize.Height - gripSize ' + hScrollSize
    '        If sizeX And sizeY And SizableX And SizableY Then
    '            m.Result = HTBOTTOMRIGHT
    '        ElseIf sizeX And SizableX Then
    '            m.Result = HTRIGHT
    '        ElseIf sizeY And SizableY Then
    '            m.Result = HTBOTTOM
    '        Else
    '            MyBase.WndProc(m)
    '        End If
    '    Else
    '        MyBase.WndProc(m)
    '    End If
    'End Sub
End Class