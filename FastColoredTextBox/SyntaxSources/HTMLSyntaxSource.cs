using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class HTMLSyntaxSource : SyntaxHighlighter
    {
        public HTMLSyntaxSource(FastColoredTextBox textbox) : base(textbox)
        {
            Init();
        }

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            var tb = sender as FastColoredTextBox;
            tb.CalcAutoIndentShiftByCodeFolding(sender, args);
        }

        public override void Init()
        {
            Textbox.CommentPrefix = null;
            Textbox.LeftBracket = '<';
            Textbox.RightBracket = '>';
            Textbox.LeftBracket2 = '(';
            Textbox.RightBracket2 = ')';
            Textbox.AutoIndentCharsPatterns = @"";

            AddStyle("Comment1", 
                PredefinedStyles.GreenStyle, 
                new Regex(@"(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | RegexCompiledOption));
            AddStyle("Comment2",
                PredefinedStyles.GreenStyle, 
                new Regex(@"(<!--.*?-->)|(.*-->)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption));
            AddStyle("Tag Bracket", 
                PredefinedStyles.BlueStyle, 
                new Regex(@"<|/>|</|>", RegexCompiledOption));
            AddStyle("Tag Name", 
                PredefinedStyles.MaroonStyle, 
                new Regex(@"<(?<range>[!\w:]+)", RegexCompiledOption));
            AddStyle("End Tag", 
                PredefinedStyles.MaroonStyle, 
                new Regex(@"</(?<range>[\w:]+)>", RegexCompiledOption));
            AddStyle("Attribute", 
                PredefinedStyles.RedStyle, 
                new Regex(@"(?<range>[\w\d\-]{1,20}?)='[^']*'|(?<range>[\w\d\-]{1,20})=""[^""]*""|(?<range>[\w\d\-]{1,20})=[\w\d\-]{1,20}", RegexCompiledOption));
            AddStyle("Attribute Value", 
                PredefinedStyles.MagentaStyle, 
                new Regex(@"[\w\d\-]{1,20}?=(?<range>'[^']*')|[\w\d\-]{1,20}=(?<range>""[^""]*"")|[\w\d\-]{1,20}=(?<range>[\w\d\-]{1,20})", RegexCompiledOption));
            AddStyle("Entity", 
                PredefinedStyles.RedStyle, 
                new Regex(@"\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});", RegexCompiledOption | RegexOptions.IgnoreCase));
            AddFoldingRule("<head", "</head>", RegexOptions.IgnoreCase);
            AddFoldingRule("<body", "</body>", RegexOptions.IgnoreCase);
            AddFoldingRule("<table", "</table>", RegexOptions.IgnoreCase);
            AddFoldingRule("<form", "</form>", RegexOptions.IgnoreCase);
            AddFoldingRule("<div", "</div>", RegexOptions.IgnoreCase);
            AddFoldingRule("<script", "</script>", RegexOptions.IgnoreCase);
            AddFoldingRule("<tr", "</tr>", RegexOptions.IgnoreCase);
        }
    }
}
