using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class JScriptSyntaxSource : SyntaxHighlighter
    {
        public JScriptSyntaxSource(FastColoredTextBox textbox) : base(textbox)
        {
            Init();
        }

        public override void Init()
        {
            Textbox.CommentPrefix = "//";
            Textbox.LeftBracket = '(';
            Textbox.RightBracket = ')';
            Textbox.LeftBracket2 = '{';
            Textbox.RightBracket2 = '}';
            Textbox.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            Textbox.AutoIndentCharsPatterns
                = @"
^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;]+);
";

            AddStyle("String",
                PredefinedStyles.BrownStyle,
                new Regex(@"""""|''|"".*?[^\\]""|'.*?[^\\]'", RegexCompiledOption));
            AddStyle("Comment",
                PredefinedStyles.GreenStyle,
                new Regex(@"//.*$", RegexOptions.Multiline | RegexCompiledOption));
            AddStyle("Comment2",
                PredefinedStyles.GreenStyle,
                new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline | RegexCompiledOption));
            AddStyle("Comment3",
                PredefinedStyles.GreenStyle,
                new Regex(@"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption));
            AddStyle("Number",
                PredefinedStyles.MagentaStyle,
                new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b", RegexCompiledOption));
            AddStyle("Keyword",
                PredefinedStyles.BlueStyle,
                new Regex(
                    @"\b(true|false|break|case|catch|const|continue|default|delete|do|else|export|for|function|if|in|instanceof|new|null|return|switch|this|throw|try|var|void|while|with|typeof)\b",
                    RegexCompiledOption));

            AddFoldingRule("{", "}"); //allow to collapse brackets block
            AddFoldingRule(@"/\*", @"\*/"); //allow to collapse comment block
        }
        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
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
    }
}
