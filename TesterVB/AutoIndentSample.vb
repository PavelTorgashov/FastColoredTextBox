Imports System.Text.RegularExpressions

Public Class AutoIndentSample

    Private Sub fastColoredTextBox1_AutoIndentNeeded(ByVal sender As System.Object, ByVal e As FastColoredTextBoxNS.AutoIndentEventArgs) Handles fastColoredTextBox1.AutoIndentNeeded
        ' if current line is "begin" then next
        ' line shift to right
        If e.LineText.Trim() = "begin" Then
            e.ShiftNextLines = e.TabLength
            Return
        End If
        ' if current line is "end" then current
        ' and next line shift to left
        If e.LineText.Trim() = "end" Then
            e.Shift = -e.TabLength
            e.ShiftNextLines = -e.TabLength
            Return
        End If
        ' if previous line contains "then" or "else", 
        ' and current line do not contain "begin"
        ' then shift current line to right
        If Regex.IsMatch(e.PrevLineText, "\b(then|else)\b") AndAlso Not Regex.IsMatch(e.LineText, "\bbegin\b") Then
            e.Shift = e.TabLength
            Return
        End If
    End Sub

End Class