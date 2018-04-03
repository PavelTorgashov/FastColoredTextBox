using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public abstract class Syntax
    {
        /// <summary>
        /// Rules for built in language keywords
        /// </summary>
        public Regex KeywordRegex { get; protected set; }

        /// <summary>
        /// Rules for the different comment types for example: /* , //, --, #
        /// </summary>
        public List<Regex> CommentsRegex { get; protected set; }

        public string CommentPrefix { get; protected set; }

        public char LeftBracket { get; protected set; }

        public char RightBracket { get; protected set; }

        public char LeftBracket2 { get; protected set; }
        
        public char RightBracket2 { get; protected set; }

        /// <summary>
        /// Stylesfor Comments, Strings, etc.
        /// </summary>
        public List<Style> Styles { get; protected set; }

        public Regex FunctionRegex { get; protected set; }
        
        public BracketsHighlightStrategy BracketsHighlightStrategy { get; protected set; }

        public Syntax()
        {
            CommentsRegex = new List<Regex>();
            Styles = new List<Style>();
        }
    }
}
