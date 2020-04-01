using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class LuaSyntaxSources : SyntaxHighlighter
    {
        public LuaSyntaxSources(FastColoredTextBox textbox) : base(textbox)
        {
            Init();
        }
        public override void Init()
        {
            Textbox.CommentPrefix = "--";
            Textbox.LeftBracket = '(';
            Textbox.RightBracket = ')';
            Textbox.LeftBracket2 = '{';
            Textbox.RightBracket2 = '}';
            Textbox.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            Textbox.AutoIndentCharsPatterns
                = @"
^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>.+)
";

            AddStyle("String",
                PredefinedStyles.BrownStyle,
                new Regex(@"""""|''|"".*?[^\\]""|'.*?[^\\]'", RegexCompiledOption));
            AddStyle("Comment",
                PredefinedStyles.GreenStyle,
                new Regex(@"--.*$", RegexOptions.Multiline | RegexCompiledOption));
            AddStyle("Comment2",
                PredefinedStyles.GreenStyle,
                new Regex(@"(--\[\[.*?\]\])|(--\[\[.*)", RegexOptions.Singleline | RegexCompiledOption));
            AddStyle("Comment3",
                PredefinedStyles.GreenStyle,
                new Regex(@"(--\[\[.*?\]\])|(.*\]\])", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption));
            AddStyle("Number",
                PredefinedStyles.MagentaStyle,
                new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b", RegexCompiledOption));
            AddStyle("Keyword",
                PredefinedStyles.BlueBoldStyle,
                new Regex(@"\b(and|break|do|else|elseif|end|false|for|function|if|in|local|nil|not|or|repeat|return|then|true|until|while)\b", RegexCompiledOption));
            AddStyle("Functions",
                PredefinedStyles.MaroonStyle,
                new Regex(@"\b(assert|collectgarbage|dofile|error|getfenv|getmetatable|ipairs|load|loadfile|loadstring|module|next|pairs|pcall|print|rawequal|rawget|rawset|require|select|setfenv|setmetatable|tonumber|tostring|type|unpack|xpcall)\b", RegexCompiledOption));

            AddFoldingRule("{", "}"); //allow to collapse brackets block
            AddFoldingRule(@"--\[\[", @"\]\]"); //allow to collapse comment block
        }
        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
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
    }
}
