using System;
using System.Collections.Generic;
using System.Text;

namespace FastColoredTextBoxNS.Highlighter
{
    public class CustomSyntaxHighlighter : SyntaxHighlighter
    {

        public CustomSyntaxHighlighter() { }

        public override void HighlightSyntax(Range range) { }

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args) { }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void setTextBoxParameter(FastColoredTextBox tb) { }
    }
}
