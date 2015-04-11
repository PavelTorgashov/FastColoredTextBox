using System;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS.Highlighter;

namespace FastColoredTextBoxNS
{
    class CSharpSyntaxHighlighter : SyntaxHighlighter
    {
        public CSharpSyntaxHighlighter()
        {
            InitStyleSchema();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void HighlightSyntax(Range range)
        {
            CSharpSyntaxHighlight(range);
        }

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            CSharpAutoIndentNeeded(sender, args);
        }

        public override void setTextBoxParameter(FastColoredTextBox tb)
        {
            tb.CommentPrefix = "//";
            tb.LeftBracket = '(';
            tb.RightBracket = ')';
            tb.LeftBracket2 = '{';
            tb.RightBracket2 = '}';
            tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            tb.AutoIndentCharsPatterns = @"^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;]+);^\s*(case|default)\s*[^:]*(?<range>:)\s*(?<range>[^;]+);";
        }

        private void InitStyleSchema()
        {
            StringStyle = BrownStyle;
            CommentStyle = GreenStyle;
            NumberStyle = MagentaStyle;
            AttributeStyle = GreenStyle;
            ClassNameStyle = BoldStyle;
            KeywordStyle = BlueStyle;
            CommentTagStyle = GrayStyle;
        }

        private void InitCSharpRegex()
        {
            CSharpStringRegex =
                new Regex(
                    @"
                            # Character definitions:
                            '
                            (?> # disable backtracking
                              (?:
                                \\[^\r\n]|    # escaped meta char
                                [^'\r\n]      # any character except '
                              )*
                            )
                            '?
                            |
                            # Normal string & verbatim strings definitions:
                            (?<verbatimIdentifier>@)?         # this group matches if it is an verbatim string
                            ""
                            (?> # disable backtracking
                              (?:
                                # match and consume an escaped character including escaped double quote ("") char
                                (?(verbatimIdentifier)        # if it is a verbatim string ...
                                  """"|                         #   then: only match an escaped double quote ("") char
                                  \\.                         #   else: match an escaped sequence
                                )
                                | # OR
            
                                # match any char except double quote char ("")
                                [^""]
                              )*
                            )
                            ""
                        ",
                    RegexOptions.ExplicitCapture | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexCompiledOption
                    ); //thanks to rittergig for this regex

            CSharpCommentRegex1 = new Regex(@"//.*$", RegexOptions.Multiline | RegexCompiledOption);
            CSharpCommentRegex2 = new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline | RegexCompiledOption);
            CSharpCommentRegex3 = new Regex(@"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
            CSharpNumberRegex = new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b", RegexCompiledOption);
            CSharpAttributeRegex = new Regex(@"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline | RegexCompiledOption);
            CSharpClassNameRegex = new Regex(@"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b", RegexCompiledOption);
            CSharpKeywordRegex = new Regex( @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b",
                    RegexCompiledOption);
        }

        private void CSharpSyntaxHighlight(Range range)
        {
            if (CSharpStringRegex == null)
                InitCSharpRegex();

            //clear style of changed range
            range.ClearStyle(StringStyle, CommentStyle, NumberStyle, AttributeStyle, ClassNameStyle, KeywordStyle);
            //

            //string highlighting
            range.SetStyle(StringStyle, CSharpStringRegex);
            //comment highlighting
            range.SetStyle(CommentStyle, CSharpCommentRegex1);
            range.SetStyle(CommentStyle, CSharpCommentRegex2);
            range.SetStyle(CommentStyle, CSharpCommentRegex3);
            //number highlighting
            range.SetStyle(NumberStyle, CSharpNumberRegex);
            //attribute highlighting
            range.SetStyle(AttributeStyle, CSharpAttributeRegex);
            //class name highlighting
            range.SetStyle(ClassNameStyle, CSharpClassNameRegex);
            //keyword highlighting
            range.SetStyle(KeywordStyle, CSharpKeywordRegex);

            // TODO: hier muss ein html syntaxhighlighter benutzt werden
            //find document comments
            foreach (Range r in range.GetRanges(@"^\s*///.*$", RegexOptions.Multiline))
            {
                //remove C# highlighting from this fragment
                r.ClearStyle(StyleIndex.All);
                r.SetStyle(CommentStyle);
                HtmlHighlighter.HighlightSyntax(r);
            }

            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            range.SetFoldingMarkers("{", "}"); //allow to collapse brackets block
            range.SetFoldingMarkers(@"#region\b", @"#endregion\b"); //allow to collapse #region blocks
            range.SetFoldingMarkers(@"/\*", @"\*/"); //allow to collapse comment block
        }

        private void CSharpAutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            //block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{.*\}[^""']*$"))
                return;
            //start of block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //end of block {}
            if (Regex.IsMatch(args.LineText, @"}[^""']*$"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //label
            if (Regex.IsMatch(args.LineText, @"^\s*\w+\s*:\s*($|//)") &&
                !Regex.IsMatch(args.LineText, @"^\s*default\s*:"))
            {
                args.Shift = -args.TabLength;
                return;
            }
            //some statements: case, default
            if (Regex.IsMatch(args.LineText, @"^\s*(case|default)\b.*:\s*($|//)"))
            {
                args.Shift = -args.TabLength / 2;
                return;
            }
            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)")) //operator is unclosed
                {
                    args.Shift = args.TabLength;
                    return;
                }
        }

        #region private members
        private Regex CSharpAttributeRegex, CSharpClassNameRegex;
        private Regex CSharpCommentRegex1, CSharpCommentRegex2, CSharpCommentRegex3;
        private Regex CSharpKeywordRegex;
        private Regex CSharpNumberRegex;
        private Regex CSharpStringRegex;

        private Style StringStyle { get; set; }
        private Style CommentStyle { get; set; }
        private Style NumberStyle { get; set; }
        private Style AttributeStyle { get; set; }
        private Style ClassNameStyle { get; set; }
        private Style KeywordStyle { get; set; }
        private Style CommentTagStyle { get; set; }

        private static readonly HtmlSyntaxHighlighter HtmlHighlighter = new HtmlSyntaxHighlighter();
        #endregion
    }
}
