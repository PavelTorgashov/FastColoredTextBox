using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class LuaSyntax : ILanguage
    {
        public List<Rule> Rules { get; protected set; }

		public string Name { get; protected set; }

        public string CommentPrefix { get; protected set; }

        public char LeftBracket { get; set; }
        public char RightBracket { get; set; }

        public char LeftBracket2 { get; set; }
        public char RightBracket2 { get; set; }

        public BracketsHighlightStrategy BracketsHighlightStrategy { get; protected set; }

        public string AutoIndentCharsPatterns { get; protected set; }

        public List<Marker> FoldingMarkers { get; protected set; }



        public LuaSyntax()
        {
			Name = "Lua";

            Rules = new List<Rule>() {
                new Rule(KeywordRegex(), KeywordStyle()),
                new Rule( StringRegex(),  StringStyle()),
                new Rule( NumberRegex(),  NumberStyle()),

                new Rule( CommentRegex(), CommentStyle()),
                new Rule(CommentRegex2(), CommentStyle()),
                new Rule(CommentRegex3(), CommentStyle()),

                new Rule(FunctionRegex(), FunctionStyle()),
            };

            CommentPrefix = "--";
            LeftBracket = '(';
            RightBracket = ')';
            LeftBracket2 = '{';
            RightBracket2 = '}';

            BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            AutoIndentCharsPatterns = @"^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>.+)";

            FoldingMarkers = new List<Marker>()
            {
                new Marker(      "{",     "}"),            // allow to collapse brackets block
                new Marker(@"--\[\[", @"\]\]"),  // allow to collapse comment block
            };
        }



        public Regex KeywordRegex()
        {
            return new Regex(
                    @"\b(quest|and|break|do|else|elseif|end|false|for|function|if|in|local|nil|not|or|repeat|return|then|true|until|while)\b",
                    SyntaxHighlighter.RegexCompiledOption);
        }

        public Style KeywordStyle()
        {
            return Styles.BlueBoldStyle;
        }

        public Regex StringRegex()
        {
            return new Regex(@"""""|''|"".*?[^\\]""|'.*?[^\\]'", SyntaxHighlighter.RegexCompiledOption);
        }

        public Style StringStyle()
        {
            return Styles.BrownStyle;
        }

        public Regex NumberRegex()
        {
            return new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b", SyntaxHighlighter.RegexCompiledOption);
        }

        public Style NumberStyle()
        {
            return Styles.MagentaStyle;
        }

        public Regex CommentRegex()
        {
            return new Regex(@"--.*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
        }

        public Regex CommentRegex2()
        {
            return new Regex(@"(--\[\[.*?\]\])|(--\[\[.*)", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
        }

        public Regex CommentRegex3()
        {
            return new Regex(@"(--\[\[.*?\]\])|(.*\]\])", RegexOptions.Singleline | RegexOptions.RightToLeft | SyntaxHighlighter.RegexCompiledOption);
        }

        public Style CommentStyle()
        {
            return Styles.GreenStyle;
        }

        public Regex FunctionRegex()
        {
            return new Regex(
                    @"\b(assert|collectgarbage|dofile|error|getfenv|getmetatable|ipairs|load|loadfile|loadstring|module|next|pairs|pcall|print|rawequal|rawget|rawset|require|select|setfenv|setmetatable|tonumber|tostring|type|unpack|xpcall)\b",
                    SyntaxHighlighter.RegexCompiledOption);
        }

        public Style FunctionStyle()
        {
            return Styles.MaroonStyle;
        }

        public void AutoIndentNeeded(AutoIndentEventArgs args)
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

        public Style[] GetStyles()
        {
            var styles = new Style[Rules.Count];

            for (int i = 0; i < styles.Length; i++)
                styles[i] = Rules[i].Style;

            return styles;
        }
    }
}
