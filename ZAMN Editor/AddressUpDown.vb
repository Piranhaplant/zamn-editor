Public Class AddressUpDown

    Private curType As Boolean

    Public Sub New()
        InitializeComponent()
        ChangeToType(My.Settings.DefaultAddrType)
    End Sub

    Public Property Value As Integer
        Get
            If curType Then
                Return nudHex.Value
            Else
                Return (Bank.Value - &H80) * &H8000 + Part2.Value - &H8000
            End If
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Me.Value = 0
                Return
            End If
            If curType Then
                nudHex.Value = value
            Else
                Dim bnk As Integer = value \ &H8000
                Bank.Value = bnk + &H80
                Part2.Value = value - bnk * &H8000 + &H8000
            End If
        End Set
    End Property

    Public Event ValueChanged(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub nud_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Bank.ValueChanged, Part2.ValueChanged, nudHex.ValueChanged
        RaiseEvent ValueChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub DropButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropButton.Click
        DisplayType.Show(MousePosition)
    End Sub

    Private Sub TypeSNES_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TypeSNES.Click
        ChangeToType(False)
    End Sub

    Private Sub TypeHex_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TypeHex.Click
        ChangeToType(True)
    End Sub

    Private Sub ChangeToType(ByVal type As Boolean)
        TypeSNES.Checked = False
        TypeHex.Checked = False
        Panel1.Visible = False
        nudHex.Visible = False
        If type Then
            TypeHex.Checked = True
            nudHex.Visible = True
        Else
            TypeSNES.Checked = True
            Panel1.Visible = True
        End If
        Dim pAddr As Integer = Me.Value
        curType = type
        Me.Value = pAddr
    End Sub

    Private Sub TypeSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TypeSave.Click
        My.Settings.DefaultAddrType = curType
        My.Settings.Save()
    End Sub
End Class
