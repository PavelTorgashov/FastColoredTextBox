Imports System.Text.RegularExpressions
Imports System.IO
Imports FastColoredTextBoxNS


''' <summary>
''' Note: this example is deprecated. See project Tester for newest code samples.
''' </summary>

Public Class PowerfulSample

    Dim lang As String = "VB"

    Dim BlueStyle As TextStyle = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
    Dim BoldStyle As TextStyle = New TextStyle(Nothing, Nothing, FontStyle.Bold Or FontStyle.Underline)
    Dim GrayStyle As TextStyle = New TextStyle(Brushes.Gray, Nothing, FontStyle.Regular)
    Dim MagentaStyle As TextStyle = New TextStyle(Brushes.Magenta, Nothing, FontStyle.Regular)
    Dim GreenStyle As TextStyle = New TextStyle(Brushes.Green, Nothing, FontStyle.Italic)
    Dim BrownStyle As TextStyle = New TextStyle(Brushes.Brown, Nothing, FontStyle.Italic)
    Dim MaroonStyle As TextStyle = New TextStyle(Brushes.Maroon, Nothing, FontStyle.Regular)
    Dim SameWordsStyle As MarkerStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(40, Color.Gray)))

    Public Sub New()
        InitializeComponent()
        InitStylesPriority()
    End Sub


    Private Sub InitStylesPriority()
        FastColoredTextBox1.ClearStylesBuffer()
        'add this style explicitly for drawing under other styles
        FastColoredTextBox1.AddStyle(SameWordsStyle)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FastColoredTextBox1.Text = "" & vbCrLf &
"#Region ""Char""" & vbCrLf &
"   " & vbCrLf &
"   ''' <summary>" & vbCrLf &
"   ''' Char and style" & vbCrLf &
"   ''' </summary>" & vbCrLf &
"   Public Structure CharStyle" & vbCrLf &
"       Public c As Char" & vbCrLf &
"       Public style As StyleIndex" & vbCrLf &
"   " & vbCrLf &
"       Public Sub CharStyle(ByVal ch As Char)" & vbCrLf &
"           c = ch" & vbCrLf &
"           Style = StyleIndex.None" & vbCrLf &
"       End Sub" & vbCrLf &
"   " & vbCrLf &
"   End Structure" & vbCrLf &
"   " & vbCrLf &
"#End Region"
        'move caret to start text
        FastColoredTextBox1.Selection.Start = Place.Empty
        FastColoredTextBox1.DoCaretVisible()
        FastColoredTextBox1.IsChanged = False
        FastColoredTextBox1.ClearUndo()
    End Sub

    Private Sub FastColoredTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) Handles FastColoredTextBox1.TextChanged
        'For sample, we will highlight the syntax of C# manually, although could use built-in highlighter
        If lang = "CSharp" Then
            CSharpSyntaxHighlight(e)
        End If
    End Sub

    Private Sub CSharpSyntaxHighlight(ByVal e As TextChangedEventArgs)
        FastColoredTextBox1.LeftBracket = "("
        FastColoredTextBox1.RightBracket = ")"
        FastColoredTextBox1.LeftBracket2 = "\x0"
        FastColoredTextBox1.RightBracket2 = "\x0"
        'clear style of changed range
        e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle)
        'string highlighting
        e.ChangedRange.SetStyle(BrownStyle, """.*?""|'.+?'")
        'comment highlighting
        e.ChangedRange.SetStyle(GreenStyle, "//.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(GreenStyle, "(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline)
        e.ChangedRange.SetStyle(GreenStyle, "(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline Or RegexOptions.RightToLeft)
        'number highlighting
        e.ChangedRange.SetStyle(MagentaStyle, "\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b")
        'attribute highlighting
        e.ChangedRange.SetStyle(GrayStyle, "^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline)
        'class name highlighting
        e.ChangedRange.SetStyle(BoldStyle, "\b(class|struct|enum|interface)\s+(?<range>\w+?)\b")
        'keyword highlighting
        e.ChangedRange.SetStyle(BlueStyle, "\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b")

        'clear folding markers
        e.ChangedRange.ClearFoldingMarkers()
        'set folding markers
        e.ChangedRange.SetFoldingMarkers("{", "}") 'allow to collapse brackets block
        e.ChangedRange.SetFoldingMarkers("#region\b", "#endregion\b") 'allow to collapse #region blocks
        e.ChangedRange.SetFoldingMarkers("/\*", "\*/") 'allow to collapse comment block
    End Sub

    Private Sub miCSharp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCSharp.Click, sQLToolStripMenuItem.Click, pHPToolStripMenuItem.Click, miVB.Click, hTMLToolStripMenuItem.Click
        'set language
        lang = CType(sender, ToolStripMenuItem).Text

        FastColoredTextBox1.ClearStylesBuffer()
        FastColoredTextBox1.Range.ClearStyle(StyleIndex.All)
        InitStylesPriority()

        Select Case lang
            Case "CSharp"
                FastColoredTextBox1.Language = Language.Custom
                FastColoredTextBox1.CommentPrefix = "//"
                'call OnTextChanged for refresh syntax highlighting
                FastColoredTextBox1.OnTextChanged()
            Case "VB" : FastColoredTextBox1.Language = Language.VB
            Case "HTML" : FastColoredTextBox1.Language = Language.HTML
            Case "SQL" : FastColoredTextBox1.Language = Language.SQL
            Case "PHP" : FastColoredTextBox1.Language = Language.PHP
        End Select

        FastColoredTextBox1.OnSyntaxHighlight(New TextChangedEventArgs(FastColoredTextBox1.Range))
    End Sub

    Private Sub miLanguage_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLanguage.DropDownOpening
        For Each mi As ToolStripMenuItem In miLanguage.DropDownItems
            mi.Checked = (mi.Text = lang)
        Next
    End Sub

    Private Sub findToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles findToolStripMenuItem.Click
        FastColoredTextBox1.ShowFindDialog()
    End Sub

    Private Sub replaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles replaceToolStripMenuItem.Click
        FastColoredTextBox1.ShowReplaceDialog()
    End Sub

    Private Sub hTMLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hTMLToolStripMenuItem1.Click
        Dim sfd As SaveFileDialog = New SaveFileDialog()
        sfd.Filter = "HTML|*.html"
        If sfd.ShowDialog() = DialogResult.OK Then
            File.WriteAllText(sfd.FileName, FastColoredTextBox1.Html)
        End If

    End Sub
End Class
