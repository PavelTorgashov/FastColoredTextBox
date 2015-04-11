using System;

namespace FastColoredTextBoxNS
{
    public interface ISyntaxHighlighter : IDisposable
    {
        void HighlightSyntax(Range range);
        void AutoIndentNeeded(object sender, AutoIndentEventArgs args);
    }
}