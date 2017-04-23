Public Class RecentFilesList
    Inherits ToolStripMenuItem

    Private _Items As New List(Of String)
    Private _MaxItems As Integer = 10
    Private _MaxLength As Integer = 60

    Property Items() As List(Of String)
        Get
            Return _Items
        End Get
        Set(ByVal value As List(Of String))
            _Items = value
            RefreshItems()
        End Set
    End Property
    Property MaxItems() As Integer
        Get
            Return _MaxItems
        End Get
        Set(ByVal value As Integer)
            _MaxItems = value
            RefreshItems()
        End Set
    End Property
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
        End Set
    End Property

    Event ItemClicked(ByVal sender As Object, ByVal e As ItemClickedEventArgs)

    Public Sub RefreshItems()
        Me.DropDownItems.Clear()
        Dim str As String
        Dim endstr As String
        For l As Integer = 0 To _Items.Count - 1
            str = _Items(l)
            If str.Length > _MaxLength Then
                endstr = Mid(str, str.Length - (_MaxLength - 4)) ', _MaxLength - 3)
                If InStr(endstr, "\") Then
                    str = Mid(str, 1, 3) & "..." & Mid(endstr, InStr(endstr, "\"), endstr.Length - InStr(endstr, "\") + 1)
                Else
                    str = Mid(str, 1, 3) & "..." & Mid(str, InStrRev(str, "\"), str.Length - InStrRev(str, "\") + 1)
                End If
            End If
            Me.DropDownItems.Add(l + 1 & "  " & str, Nothing, New EventHandler(AddressOf ItemClickedE))
        Next
        Me.Enabled = Items.Count > 0
    End Sub

    Private Sub ItemClickedE(ByVal sender As Object, ByVal e As EventArgs)
        Dim tsmi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        For l As Integer = 0 To _Items.Count - 1
            If tsmi Is Me.DropDownItems(l) Then
                RaiseEvent ItemClicked(tsmi, New ItemClickedEventArgs(l, _Items(l)))
                Promote(l)
                Exit For
            End If
        Next
    End Sub

    Public Sub Add(ByVal text As String)
        Dim indx As Integer = _Items.IndexOf(text)
        If indx = -1 Then
            _Items.Insert(0, text)
            If _Items.Count > _MaxItems Then
                _Items.RemoveAt(_MaxItems)
            End If
        Else
            Promote(indx)
        End If
        RefreshItems()
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index < _Items.Count And index >= 0 Then
            _Items.RemoveAt(index)
            RefreshItems()
        End If
    End Sub

    Public Sub Clear()
        _Items.Clear()
        RefreshItems()
    End Sub

    Public Sub Promote(ByVal index As Integer)
        If index < _Items.Count And index >= 0 Then
            Dim txt As String = _Items(index)
            Remove(index)
            Add(txt)
        End If
    End Sub
End Class

Public Class ItemClickedEventArgs
    Inherits EventArgs

    Private _ItemIndex As Integer
    Private _Text As String

    Property ItemIndex() As Integer
        Get
            Return _ItemIndex
        End Get
        Set(ByVal value As Integer)
            _ItemIndex = value
        End Set
    End Property
    Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property

    Public Sub New(ByVal ItemIndex As Integer, ByVal Text As String)
        _ItemIndex = ItemIndex
        _Text = Text
    End Sub
End Class