Imports System.Text.RegularExpressions

Public Class AutocompleteSample2

    Private popupMenu As AutocompleteMenu
    Private keywords As String() = {"abstract", "as", "base", "bool", "break", "byte", _
     "case", "catch", "char", "checked", "class", "const", _
     "continue", "decimal", "default", "delegate", "do", "double", _
     "else", "enum", "event", "explicit", "extern", "false", _
     "finally", "fixed", "float", "for", "foreach", "goto", _
     "if", "implicit", "in", "int", "interface", "internal", _
     "is", "lock", "long", "namespace", "new", "null", _
     "object", "operator", "out", "override", "params", "private", _
     "protected", "public", "readonly", "ref", "return", "sbyte", _
     "sealed", "short", "sizeof", "stackalloc", "static", "string", _
     "struct", "switch", "this", "throw", "true", "try", _
     "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", _
     "using", "virtual", "void", "volatile", "while", "add", _
     "alias", "ascending", "descending", "dynamic", "from", "get", _
     "global", "group", "into", "join", "let", "orderby", _
     "partial", "remove", "select", "set", "value", "var", _
     "where", "yield"}
    Private methods As String() = {"Equals()", "GetHashCode()", "GetType()", "ToString()"}
    Private snippets As String() = {"if(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}", "if(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}" & vbLf & "else" & vbLf & "{" & vbLf & ";" & vbLf & "}", "for(^;;)" & vbLf & "{" & vbLf & ";" & vbLf & "}", "while(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}", "do${" & vbLf & "^;" & vbLf & "}while();", "switch(^)" & vbLf & "{" & vbLf & "case : break;" & vbLf & "}"}
    Private declarationSnippets As String() = {"public class ^" & vbLf & "{" & vbLf & "}", "private class ^" & vbLf & "{" & vbLf & "}", "internal class ^" & vbLf & "{" & vbLf & "}", "public struct ^" & vbLf & "{" & vbLf & ";" & vbLf & "}", "private struct ^" & vbLf & "{" & vbLf & ";" & vbLf & "}", "internal struct ^" & vbLf & "{" & vbLf & ";" & vbLf & "}", _
     "public void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "private void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "internal void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "protected void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "public ^{ get; set; }", "private ^{ get; set; }", _
     "internal ^{ get; set; }", "protected ^{ get; set; }"}

    Public Sub New()
        InitializeComponent()

        'create autocomplete popup menu
        popupMenu = New AutocompleteMenu(fctb)
        popupMenu.Items.ImageList = imageList1
        popupMenu.SearchPattern = "[\w\.:=!<>]"
        '
        BuildAutocompleteMenu()
    End Sub

    Private Sub BuildAutocompleteMenu()
        Dim items As New List(Of AutocompleteItem)()

        For Each item As String In snippets
            items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 1})
        Next
        For Each item As String In declarationSnippets
            items.Add(New DeclarationSnippet(item) With {.ImageIndex = 0})
        Next
        For Each item As String In methods
            items.Add(New MethodAutocompleteItem(item) With {.ImageIndex = 2})
        Next
        For Each item As String In keywords
            items.Add(New AutocompleteItem(item))
        Next

        items.Add(New InsertSpaceSnippet())
        items.Add(New InsertSpaceSnippet("^(\w+)([=<>!:]+)(\w+)$"))
        items.Add(New InsertEnterSnippet())

        'set as autocomplete source
        popupMenu.Items.SetAutocompleteItems(items)
    End Sub

    ''' <summary>
    ''' This item appears when any part of snippet text is typed
    ''' </summary>
    Private Class DeclarationSnippet
        Inherits SnippetAutocompleteItem
        Public Sub New(ByVal snippet As String)
            MyBase.New(snippet)
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim pattern = Regex.Escape(fragmentText)
            If Regex.IsMatch(Text, "\b" & pattern, RegexOptions.IgnoreCase) Then
                Return CompareResult.Visible
            End If
            Return CompareResult.Hidden
        End Function
    End Class

    ''' <summary>
    ''' Divides numbers and words: "123AND456" -> "123 AND 456"
    ''' Or "i=2" -> "i = 2"
    ''' </summary>
    Private Class InsertSpaceSnippet
        Inherits AutocompleteItem
        Private pattern As String

        Public Sub New(ByVal pattern As String)
            MyBase.New("")
            Me.pattern = pattern
        End Sub


        Public Sub New()
            Me.New("^(\d+)([a-zA-Z_]+)(\d*)$")
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            If Regex.IsMatch(fragmentText, pattern) Then
                Text = InsertSpaces(fragmentText)
                If Text <> fragmentText Then
                    Return CompareResult.Visible
                End If
            End If
            Return CompareResult.Hidden
        End Function

        Public Function InsertSpaces(ByVal fragment As String) As String
            Dim m = Regex.Match(fragment, pattern)
            If m Is Nothing Then
                Return fragment
            End If
            If m.Groups(1).Value = "" AndAlso m.Groups(3).Value = "" Then
                Return fragment
            End If
            Return (m.Groups(1).Value & " " & m.Groups(2).Value & " " & m.Groups(3).Value).Trim()
        End Function

        Public Overrides Property ToolTipTitle() As String
            Get
                Return Text
            End Get
            Set(ByVal value As String)
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Inerts line break after '}'
    ''' </summary>
    Private Class InsertEnterSnippet
        Inherits AutocompleteItem
        Private enterPlace As Place = Place.Empty

        Public Sub New()
            MyBase.New("[Line break]")
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim r = Parent.Fragment.Clone()
            While r.Start.iChar > 0
                If r.CharBeforeStart = "}"c Then
                    enterPlace = r.Start
                    Return CompareResult.Visible
                End If

                r.GoLeftThroughFolded()
            End While

            Return CompareResult.Hidden
        End Function

        Public Overrides Function GetTextForReplace() As String
            'extend range
            Dim r As Range = Parent.Fragment
            Dim [end] As Place = r.[End]
            r.Start = enterPlace
            r.[End] = r.[End]
            'insert line break
            Return Environment.NewLine + r.Text
        End Function

        Public Overrides Sub OnSelected(ByVal popupMenu As AutocompleteMenu, ByVal e As SelectedEventArgs)
            MyBase.OnSelected(popupMenu, e)
            If Parent.Fragment.tb.AutoIndent Then
                Parent.Fragment.tb.DoAutoIndent()
            End If
        End Sub

        Public Overrides Property ToolTipTitle() As String
            Get
                Return "Insert line break after '}'"
            End Get
            Set(ByVal value As String)
            End Set
        End Property
    End Class
End Class