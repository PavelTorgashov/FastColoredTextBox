using System;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Highlighter
{
    public class LuaSyntaxHighlighter : SyntaxHighlighter
    {
        public LuaSyntaxHighlighter()
        {
            InitStyleSchema();
            InitLuaRegex();
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
            LuaAutoIndentNeeded(sender,args);
        }

        public override void setTextBoxParameter(FastColoredTextBox tb)
        {
            tb.CommentPrefix = "--";
            tb.LeftBracket = '(';
            tb.RightBracket = ')';
            tb.LeftBracket2 = '{';
            tb.RightBracket2 = '}';
            tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
            tb.AutoIndentCharsPatterns = @"^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>.+)";
        }

        private void InitStyleSchema()
        {
            StringStyle = BrownStyle;
            CommentStyle = GreenStyle;
            NumberStyle = MagentaStyle;
            KeywordStyle = BlueBoldStyle;
            FunctionsStyle = MaroonStyle;
        }

        private void InitLuaRegex()
        {
            LuaStringRegex = new Regex(@"""""|''|"".*?[^\\]""|'.*?[^\\]'", RegexCompiledOption);
            LuaCommentRegex1 = new Regex(@"--.*$", RegexOptions.Multiline | RegexCompiledOption);
            LuaCommentRegex2 = new Regex(@"(--\[\[.*?\]\])|(--\[\[.*)", RegexOptions.Singleline | RegexCompiledOption);
            LuaCommentRegex3 = new Regex(@"(--\[\[.*?\]\])|(.*\]\])", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
            LuaNumberRegex = new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b", RegexCompiledOption);
            LuaKeywordRegex = new Regex(@"\b(and|break|do|else|elseif|end|false|for|function|if|in|local|nil|not|or|repeat|return|then|true|until|while)\b", RegexCompiledOption);
            LuaFunctionsRegex = new Regex(@"\b(assert|collectgarbage|dofile|error|getfenv|getmetatable|ipairs|load|loadfile|loadstring|module|next|pairs|pcall|print|rawequal|rawget|rawset|require|select|setfenv|setmetatable|tonumber|tostring|type|unpack|xpcall)\b", RegexCompiledOption);
        }

        private void LuaSyntaxHighlight(Range range)
        {
            //clear style of changed range
            range.ClearStyle(StringStyle, CommentStyle, NumberStyle, KeywordStyle, FunctionsStyle);
            //string highlighting
            range.SetStyle(StringStyle, LuaStringRegex);
            //comment highlighting
            range.SetStyle(CommentStyle, LuaCommentRegex1);
            range.SetStyle(CommentStyle, LuaCommentRegex2);
            range.SetStyle(CommentStyle, LuaCommentRegex3);
            //number highlighting
            range.SetStyle(NumberStyle, LuaNumberRegex);
            //keyword highlighting
            range.SetStyle(KeywordStyle, LuaKeywordRegex);
            //functions highlighting
            range.SetStyle(FunctionsStyle, LuaFunctionsRegex);
            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            range.SetFoldingMarkers("{", "}"); //allow to collapse brackets block
            range.SetFoldingMarkers(@"--\[\[", @"\]\]"); //allow to collapse comment block
        }

        private void LuaAutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            //end of block
            if (Regex.IsMatch(args.LineText, @"^\s*(end|until)\b"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            // then ...
            if (Regex.IsMatch(args.LineText, @"\b(then)\s*\S+"))
                return;
            //start of operator block
            if (Regex.IsMatch(args.LineText, @"^\s*(function|do|for|while|repeat|if)\b"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }

            //Statements else, elseif, case etc
            if (Regex.IsMatch(args.LineText, @"^\s*(else|elseif)\b", RegexOptions.IgnoreCase))
            {
                args.Shift = -args.TabLength;
                return;
            }
        }

        #region private members
        private Regex LuaCommentRegex1, LuaCommentRegex2, LuaCommentRegex3;
        private Regex LuaKeywordRegex;
        private Regex LuaNumberRegex;
        private Regex LuaStringRegex;
        private Regex LuaFunctionsRegex;

        private Style StringStyle { get; set; }
        private Style CommentStyle { get; set; }
        private Style NumberStyle { get; set; }
        private Style KeywordStyle { get; set; }
        private Style FunctionsStyle { get; set; }
        #endregion
    }
}
