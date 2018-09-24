Imports System.Drawing.Imaging

Public Class TitlePageEdCtrl

    Public tp As TitlePage
    Public wordRects As List(Of Rectangle)
    Public gfx As TitleGFX
    Public selectedIndex As Integer = -1
    Public selectedWord As Word
    Public selectedChar As Integer = -1 'Advanced editing
    Public inserting As Boolean 'Advanced editing
    Public dragging As Boolean = False
    Public dragXOff As Integer
    Public dragYOff As Integer

    Private _showBorder As Boolean = True
    Public Property ShowBorder As Boolean
        Get
            Return _showBorder
        End Get
        Set(value As Boolean)
            _showBorder = value
            canvas.Invalidate()
        End Set
    End Property
    Private _advancedEditing As Boolean = False
    Public Property AdvancedEditing
        Get
            Return _advancedEditing
        End Get
        Set(value)
            _advancedEditing = value
            If selectedIndex > -1 Then
                selectedChar = 0
                inserting = False
            End If
            canvas.Invalidate()
        End Set
    End Property

    Public Event WordSelected(ByVal sender As Object, ByVal w As Word)

    Public Sub LoadTP(ByVal tp As TitlePage, ByVal gfx As TitleGFX)
        Me.tp = tp
        Me.gfx = gfx
        LoadAllWordRects()
    End Sub

    Public Sub SelectNone()
        selectedIndex = -1
        selectedWord = Nothing
        selectedChar = -1
        canvas.Invalidate()
    End Sub

    Public Sub Delete()
        tp.words.Remove(selectedWord)
        wordRects.RemoveAt(selectedIndex)
        SelectNone()
    End Sub

    Public Sub Add(ByVal plt As Integer)
        Dim w As New Word
        w.x = 1
        w.y = 1
        w.font = plt
        w.chars = TitlePageEditor.StrToTitle("NEW", False)
        tp.words.Add(w)
        wordRects.Add(GetWordRect(w))
        selectedWord = w
        selectedIndex = wordRects.Count - 1
        canvas.Invalidate()
        RaiseEvent WordSelected(Me, w)
    End Sub

    Public Sub AlignCenter()
        selectedWord.x = Math.Max(0, (256 - wordRects(selectedIndex).Width) \ 16)
        wordRects(selectedIndex) = GetWordRect(selectedWord)
        canvas.Invalidate()
    End Sub

    Public Sub AlignMiddle()
        selectedWord.y = 11
        wordRects(selectedIndex) = GetWordRect(selectedWord)
        canvas.Invalidate()
    End Sub

    Public Sub MoveUp()
        If selectedIndex < tp.words.Count - 1 Then
            tp.words.Remove(selectedWord)
            tp.words.Insert(selectedIndex + 1, selectedWord)
            LoadAllWordRects()
            canvas.Invalidate()
        End If
    End Sub

    Public Sub MoveDown()
        If selectedIndex > 0 Then
            tp.words.Remove(selectedWord)
            tp.words.Insert(selectedIndex - 1, selectedWord)
            LoadAllWordRects()
            canvas.Invalidate()
        End If
    End Sub

    Public Sub MoveTop()
        tp.words.Remove(selectedWord)
        tp.words.Add(selectedWord)
        LoadAllWordRects()
        canvas.Invalidate()
    End Sub

    Public Sub MoveBottom()
        tp.words.Remove(selectedWord)
        tp.words.Insert(0, selectedWord)
        LoadAllWordRects()
        canvas.Invalidate()
    End Sub

    Public Sub TypeChar(ByVal c As Byte)
        If Not _advancedEditing Then Return
        If selectedWord Is Nothing Then Return
        If inserting Then
            selectedWord.chars.Insert(selectedChar, c + &H20)
        Else
            selectedWord.chars(selectedChar) = c + &H20
        End If
        selectedChar += 1
        If selectedChar = selectedWord.chars.Count Then
            inserting = True
        End If
        wordRects(selectedIndex) = GetWordRect(selectedWord)
        canvas.Invalidate()
    End Sub

    Public Sub UpdateSelection()
        If selectedWord IsNot Nothing Then
            wordRects(selectedIndex) = GetWordRect(selectedWord)
            If selectedChar >= selectedWord.chars.Count Then
                selectedChar = selectedWord.chars.Count
                inserting = True
            End If
            canvas.Invalidate()
        End If
    End Sub

    Public Sub LoadAllWordRects()
        wordRects = New List(Of Rectangle)
        For l As Integer = 0 To tp.words.Count - 1
            wordRects.Add(GetWordRect(tp.words(l)))
        Next
    End Sub

    Public Function GetWordRect(ByVal w As Word) As Rectangle
        If gfx Is Nothing Then Return Rectangle.Empty
        Dim width As Integer = 0
        For l As Integer = 0 To w.chars.Count - 1
            If w.chars(l) >= &H20 And w.chars(l) <= &H7F Then
                width += gfx.LetterImgs(w.chars(l) - &H20).Width
            End If
        Next
        Return New Rectangle(w.x * 8, w.y * 8, width, 48)
    End Function

    Public Sub DrawWord(ByVal g As Graphics, ByVal w As Word)
        Dim curX As Integer = w.x * 8
        For l As Integer = 0 To w.chars.Count 'Not -1 because the insert caret can be at the very end
            Dim idx As Integer = 0
            If l < w.chars.Count Then
                idx = w.chars(l) - &H20
            End If
            If idx >= 0 And idx <= &H5F Then
                If l < w.chars.Count Then
                    SNESGFX.DrawWithPlt(g, curX, w.y * 8, gfx.LetterImgs(idx), gfx.plt, w.font * &H10, &H20)
                End If
                If selectedChar = l And w Is selectedWord And _advancedEditing Then
                    If inserting Then
                        g.DrawImage(My.Resources.Caret, curX - 4, w.y * 8 + 1)
                    Else
                        g.DrawRectangle(Pens.White, New Rectangle(curX + 1, w.y * 8 + 1, gfx.LetterImgs(idx).Width - 2, gfx.LetterImgs(idx).Height - 2))
                    End If
                End If
                curX += gfx.LetterImgs(idx).Width
            End If
        Next
    End Sub

    Private Sub canvas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles canvas.Paint
        If tp IsNot Nothing And gfx IsNot Nothing Then
            For l As Integer = 0 To tp.words.Count - 1
                DrawWord(e.Graphics, tp.words(l))
                If _showBorder Then
                    e.Graphics.DrawRectangle(Pens.Gray, wordRects(l))
                End If
            Next
            If selectedIndex > -1 And Not _advancedEditing Then
                Dim rect As Rectangle = wordRects(selectedIndex)
                e.Graphics.DrawRectangle(Pens.White, rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2)
            End If
        End If
    End Sub

    Private Sub canvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseDown
        Me.Focus()
        For l As Integer = wordRects.Count - 1 To 0 Step -1
            If wordRects(l).Contains(e.Location) Then
                selectedIndex = l
                selectedWord = tp.words(selectedIndex)
                dragXOff = e.X - wordRects(l).X
                dragYOff = e.Y - wordRects(l).Y
                dragging = True
                If _advancedEditing Then
                    Dim curX As Integer = wordRects(l).X
                    For i As Integer = 0 To selectedWord.chars.Count - 1
                        If e.Location.X < curX + 4 Then
                            selectedChar = i
                            inserting = True
                            Exit For
                        End If
                        curX += gfx.LetterImgs(selectedWord.chars(i) - &H20).Width
                        If e.Location.X > curX - 4 And e.Location.X <= curX Then
                            selectedChar = i + 1
                            inserting = True
                            Exit For
                        ElseIf e.Location.X < curX Then
                            selectedChar = i
                            inserting = False
                            Exit For
                        End If
                    Next
                End If
                Exit For
            End If
        Next
        If Not dragging Then
            selectedIndex = -1
            selectedWord = Nothing
            selectedChar = -1
        End If
        canvas.Invalidate()
        RaiseEvent WordSelected(Me, selectedWord)
    End Sub

    Private Sub canvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseMove
        If dragging Then
            Dim x As Integer = Math.Max(0, Math.Min(256 - wordRects(selectedIndex).Width, e.X - dragXOff)) \ 8
            Dim y As Integer = Math.Max(0, Math.Min(176, e.Y - dragYOff)) \ 8
            If e.X <> selectedWord.x Or e.Y <> selectedWord.y Then
                selectedWord.x = x
                selectedWord.y = y
                wordRects(selectedIndex) = GetWordRect(selectedWord)
                canvas.Invalidate()
            End If
        End If
    End Sub

    Private Sub canvas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseUp
        dragging = False
    End Sub
End Class
