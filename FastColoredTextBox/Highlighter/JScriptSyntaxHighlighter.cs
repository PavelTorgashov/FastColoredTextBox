using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Highlighter
{
    class JScriptSyntaxHighlighter : SyntaxHighlighter
    {
        public JScriptSyntaxHighlighter()
        {
            InitStyleSchema();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void HighlightSyntax(Range range)
        {
            JScriptSyntaxHighlight(range);
        }

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            JScriptAutoIndentNeeded(sender, args);
        }

        public override void setTextBoxParameter(FastColoredTextBox tb)
        {
            tb.CommentPrefix = "//";
            tb.LeftBracket = '(';
            tb.RightBracket = ')';
            tb.LeftBracket2 = '{';
            tb.RightBracket2 = '}';
            tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            tb.AutoIndentCharsPatterns = @"^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;]+);";
        }

        private void InitStyleSchema()
        {
            StringStyle = BrownStyle;
            CommentStyle = GreenStyle;
            NumberStyle = MagentaStyle;
            KeywordStyle = BlueStyle;
        }

        private void InitJScriptRegex()
        {
            JScriptStringRegex = new Regex(@"""""|''|"".*?[^\\]""|'.*?[^\\]'", RegexCompiledOption);
            JScriptCommentRegex1 = new Regex(@"//.*$", RegexOptions.Multiline | RegexCompiledOption);
            JScriptCommentRegex2 = new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline | RegexCompiledOption);
            JScriptCommentRegex3 = new Regex(@"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
            JScriptNumberRegex = new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b", RegexCompiledOption);
            JScriptKeywordRegex = new Regex(@"\b(true|false|break|case|catch|const|continue|default|delete|do|else|export|for|function|if|in|instanceof|new|null|return|switch|this|throw|try|var|void|while|with|typeof)\b", RegexCompiledOption);
        }

        private void JScriptSyntaxHighlight(Range range)
        {
            if (JScriptStringRegex == null)
                InitJScriptRegex();

            //clear style of changed range
            range.ClearStyle(StringStyle, CommentStyle, NumberStyle, KeywordStyle);
            //string highlighting
            range.SetStyle(StringStyle, JScriptStringRegex);
            //comment highlighting
            range.SetStyle(CommentStyle, JScriptCommentRegex1);
            range.SetStyle(CommentStyle, JScriptCommentRegex2);
            range.SetStyle(CommentStyle, JScriptCommentRegex3);
            //number highlighting
            range.SetStyle(NumberStyle, JScriptNumberRegex);
            //keyword highlighting
            range.SetStyle(KeywordStyle, JScriptKeywordRegex);
            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            range.SetFoldingMarkers("{", "}"); //allow to collapse brackets block
            range.SetFoldingMarkers(@"/\*", @"\*/"); //allow to collapse comment block
        }

        private void JScriptAutoIndentNeeded(object sender, AutoIndentEventArgs args)
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
        private Regex JScriptCommentRegex1, JScriptCommentRegex2, JScriptCommentRegex3;
        private Regex JScriptKeywordRegex;
        private Regex JScriptNumberRegex;
        private Regex JScriptStringRegex;

        private Style StringStyle { get; set; }
        private Style CommentStyle { get; set; }
        private Style NumberStyle { get; set; }
        private Style KeywordStyle { get; set; }
        #endregion
    }
}
