using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class JSONSyntaxSource : SyntaxHighlighter
    {
        public JSONSyntaxSource(FastColoredTextBox textbox) : base(textbox)
        {
            Init();
        }
        public override void Init()
        {
            Textbox.LeftBracket = '[';
            Textbox.RightBracket = ']';
            Textbox.LeftBracket2 = '{';
            Textbox.RightBracket2 = '}';
            Textbox.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            Textbox.AutoIndentCharsPatterns
                = @"
^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;]+);
";

            AddStyle("Keyword",
                PredefinedStyles.BlueStyle,
                new Regex(@"(?<range>""([^\\""]|\\"")*"")\s*:", RegexCompiledOption));
            AddStyle("String",
                PredefinedStyles.BrownStyle,
                new Regex(@"""([^\\""]|\\"")*""", RegexCompiledOption));
            AddStyle("Number",
                PredefinedStyles.MagentaStyle,
                new Regex(@"\b(\d+[\.]?\d*|true|false|null)\b", RegexCompiledOption));

            AddFoldingRule("{", "}"); //allow to collapse brackets block
            AddFoldingRule(@"\[", @"\]"); //allow to collapse comment block
        }
    }
}
