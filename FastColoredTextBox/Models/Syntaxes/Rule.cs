using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class Rule
    {
        public Regex Regex { get; private set; }

        public Style Style { get; private set; }

        public Rule(Regex regex, Style style)
        {
            Regex = regex;
            Style = style;
        }
    }
}
