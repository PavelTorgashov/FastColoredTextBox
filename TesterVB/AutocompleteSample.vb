Public Class AutocompleteSample

    Dim popupMenu As FastColoredTextBoxNS.AutocompleteMenu

    Public Sub New()
        InitializeComponent()

        'create autocomplete popup menu
        popupMenu = New FastColoredTextBoxNS.AutocompleteMenu(fastColoredTextBox1)

        popupMenu.MinFragmentLength = 2

        'generate 456976 words
        Dim randomWords As List(Of String) = New List(Of String)
        Dim codeA As Integer = Asc("a")
        For i As Integer = 0 To 25
            For j As Integer = 0 To 25
                For k As Integer = 0 To 25
                    For l As Integer = 0 To 25
                        randomWords.Add(Chr(i + codeA) + Chr(j + codeA) + Chr(k + codeA) + Chr(l + codeA))
                    Next
                Next
            Next
        Next

        'set words as autocomplete source
        popupMenu.Items.SetAutocompleteItems(randomWords)
    End Sub
End Class
