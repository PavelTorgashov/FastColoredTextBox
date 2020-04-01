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
                new TextStyle(Brushes.Green, null, FontStyle.Italic), 
                new Regex(@"(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | RegexCompiledOption));
            AddStyle("Comment2",
                StyleSchema["Comment1"].Style, 
                new Regex(@"(<!--.*?-->)|(.*-->)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption));
            AddStyle("Tag Bracket", 
                new TextStyle(Brushes.Blue, null, FontStyle.Regular), 
                new Regex(@"<|/>|</|>", RegexCompiledOption));
            AddStyle("Tag Name", 
                new TextStyle(Brushes.Maroon, null, FontStyle.Regular), 
                new Regex(@"<(?<range>[!\w:]+)", RegexCompiledOption));
            AddStyle("End Tag", 
                StyleSchema["Tag Name"].Style, 
                new Regex(@"</(?<range>[\w:]+)>", RegexCompiledOption));
            AddStyle("Attribute", 
                new TextStyle(Brushes.Red, null, FontStyle.Regular), 
                new Regex(@"(?<range>[\w\d\-]{1,20}?)='[^']*'|(?<range>[\w\d\-]{1,20})=""[^""]*""|(?<range>[\w\d\-]{1,20})=[\w\d\-]{1,20}", RegexCompiledOption));
            AddStyle("Attribute Value", 
                StyleSchema["Tag"].Style, 
                new Regex(@"[\w\d\-]{1,20}?=(?<range>'[^']*')|[\w\d\-]{1,20}=(?<range>""[^""]*"")|[\w\d\-]{1,20}=(?<range>[\w\d\-]{1,20})", RegexCompiledOption));
            AddStyle("Entity", 
                StyleSchema["Attribute"].Style, 
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
