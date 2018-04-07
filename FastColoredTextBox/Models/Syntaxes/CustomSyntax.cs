using System.Collections.Generic;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class CustomSyntax : ILanguage
    {
		public string Name { get; protected set; }

        public List<Rule> Rules { get; protected set; }

        public string CommentPrefix { get; }

        public char LeftBracket { get; set; }

        public char RightBracket { get; set; }

        public char LeftBracket2 { get; set; }

        public char RightBracket2 { get; set; }

        public string AutoIndentCharsPatterns { get; }

        public List<Marker> FoldingMarkers { get; }

        public BracketsHighlightStrategy BracketsHighlightStrategy { get; }



        public CustomSyntax()
        {
			Name = "Custom";

            Rules = new List<Rule>();

            CommentPrefix = "\x0";

            LeftBracket   = Bracket.Disabled;
            RightBracket  = Bracket.Disabled;
            LeftBracket2  = Bracket.Disabled;
            RightBracket2 = Bracket.Disabled;

            AutoIndentCharsPatterns = @"^\s*[\w\.]+\s*(?<range>=)\s*(?<range>[^;]+);";

            FoldingMarkers = new List<Marker>();

            BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy1;
        }



        public void AutoIndentNeeded(AutoIndentEventArgs args)
        {
            
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
