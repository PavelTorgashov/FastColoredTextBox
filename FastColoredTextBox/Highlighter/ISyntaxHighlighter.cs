using System;

namespace FastColoredTextBoxNS
{
    interface ISyntaxHighlighter : IDisposable
    {
        void HighlightSyntax(Range range);
        void AutoIndentNeeded(object sender, AutoIndentEventArgs args);
    }
}