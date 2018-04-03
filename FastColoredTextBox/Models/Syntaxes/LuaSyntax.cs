using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class LuaSyntax : Syntax
    {
        public LuaSyntax()
        {
            KeywordRegex =
                new Regex(
                    @"\b(and|break|do|else|elseif|end|false|for|function|if|in|local|nil|not|or|repeat|return|then|true|until|while)\b",
                    SyntaxHighlighter.RegexCompiledOption);

            CommentPrefix = "--";

            LeftBracket = '(';
            RightBracket = ')';

            LeftBracket2 = '{';
            RightBracket2 = '}';

            BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
        }
    }
}
