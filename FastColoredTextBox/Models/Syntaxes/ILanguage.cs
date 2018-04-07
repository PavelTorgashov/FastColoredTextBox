using System;
using System.Collections.Generic;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public interface ILanguage : ISyntax
    {
        List<Rule> Rules { get; }

        string CommentPrefix { get; }

        char LeftBracket { get; set; }
        char RightBracket { get; set; }

        char LeftBracket2 { get; set; }
        char RightBracket2 { get; set; }

        string AutoIndentCharsPatterns { get; }
        
        List<Marker> FoldingMarkers { get; }

        void AutoIndentNeeded(AutoIndentEventArgs args);

        Style[] GetStyles();
    }
}
