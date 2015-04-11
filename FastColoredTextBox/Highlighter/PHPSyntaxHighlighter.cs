using System;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Highlighter
{
    public class PHPSyntaxHighlighter : SyntaxHighlighter
    {
        public PHPSyntaxHighlighter()
        {
            InitStyleSchema();
            InitPHPRegex();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void HighlightSyntax(Range range)
        {
            throw new NotImplementedException();
        }

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            PHPAutoIndentNeeded(sender, args);
        }

        public override void setTextBoxParameter(FastColoredTextBox tb)
        {
            tb.CommentPrefix = "//";
            tb.LeftBracket = '(';
            tb.RightBracket = ')';
            tb.LeftBracket2 = '{';
            tb.RightBracket2 = '}';
            tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
            tb.AutoIndentCharsPatterns = @"^\s*\$[\w\.\[\]\'\""]+\s*(?<range>=)\s*(?<range>[^;]+);";
        }

        private void InitStyleSchema()
        {
            StringStyle = RedStyle;
            CommentStyle = GreenStyle;
            NumberStyle = RedStyle;
            VariableStyle = MaroonStyle;
            KeywordStyle = MagentaStyle;
            KeywordStyle2 = BlueStyle;
            KeywordStyle3 = GrayStyle;
        }

        private void InitPHPRegex()
        {
            PHPStringRegex = new Regex(@"""""|''|"".*?[^\\]""|'.*?[^\\]'", RegexCompiledOption);
            PHPNumberRegex = new Regex(@"\b\d+[\.]?\d*\b", RegexCompiledOption);
            PHPCommentRegex1 = new Regex(@"(//|#).*$", RegexOptions.Multiline | RegexCompiledOption);
            PHPCommentRegex2 = new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline | RegexCompiledOption);
            PHPCommentRegex3 = new Regex(@"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
            PHPVarRegex = new Regex(@"\$[a-zA-Z_\d]*\b", RegexCompiledOption);
            PHPKeywordRegex1 = new Regex(@"\b(die|echo|empty|exit|eval|include|include_once|isset|list|require|require_once|return|print|unset)\b", RegexCompiledOption);
            PHPKeywordRegex2 = new Regex(@"\b(abstract|and|array|as|break|case|catch|cfunction|class|clone|const|continue|declare|default|do|else|elseif|enddeclare|endfor|endforeach|endif|endswitch|endwhile|extends|final|for|foreach|function|global|goto|if|implements|instanceof|interface|namespace|new|or|private|protected|public|static|switch|throw|try|use|var|while|xor)\b", RegexCompiledOption);
            PHPKeywordRegex3 = new Regex(@"__CLASS__|__DIR__|__FILE__|__LINE__|__FUNCTION__|__METHOD__|__NAMESPACE__", RegexCompiledOption);
        }

        private void PHPSyntaxHighlight(Range range)
        {
            //clear style of changed range
            range.ClearStyle(StringStyle, CommentStyle, NumberStyle, VariableStyle, KeywordStyle, KeywordStyle2, KeywordStyle3);
            //string highlighting
            range.SetStyle(StringStyle, PHPStringRegex);
            //comment highlighting
            range.SetStyle(CommentStyle, PHPCommentRegex1);
            range.SetStyle(CommentStyle, PHPCommentRegex2);
            range.SetStyle(CommentStyle, PHPCommentRegex3);
            //number highlighting
            range.SetStyle(NumberStyle, PHPNumberRegex);
            //var highlighting
            range.SetStyle(VariableStyle, PHPVarRegex);
            //keyword highlighting
            range.SetStyle(KeywordStyle, PHPKeywordRegex1);
            range.SetStyle(KeywordStyle2, PHPKeywordRegex2);
            range.SetStyle(KeywordStyle3, PHPKeywordRegex3);

            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            range.SetFoldingMarkers("{", "}"); //allow to collapse brackets block
            range.SetFoldingMarkers(@"/\*", @"\*/"); //allow to collapse comment block
        }

        private void PHPAutoIndentNeeded(object sender, AutoIndentEventArgs args)
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
            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)")) //operator is unclosed
                {
                    args.Shift = args.TabLength;
                    return;
                }
        }

        #region private members
        private Regex PHPCommentRegex1, PHPCommentRegex2, PHPCommentRegex3;
        private Regex PHPKeywordRegex1, PHPKeywordRegex2, PHPKeywordRegex3;
        private Regex PHPNumberRegex;
        private Regex PHPStringRegex;
        private Regex PHPVarRegex;

        private Style StringStyle { get; set; }
        private Style CommentStyle { get; set; }
        private Style NumberStyle { get; set; }
        private Style VariableStyle { get; set; }
        private Style KeywordStyle { get; set; }
        private Style KeywordStyle2 { get; set; }
        private Style KeywordStyle3 { get; set; }
        #endregion
    }
}
