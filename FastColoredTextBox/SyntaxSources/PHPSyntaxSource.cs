using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class PHPSyntaxSource : SyntaxHighlighter
    {
        public PHPSyntaxSource (FastColoredTextBox textbox) : base(textbox)
        { 
            Init();
        }

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            //block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{.*\}[^""']*$"))
                return;
            //start of block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //end of block {}
            if (Regex.IsMatch(args.LineText, @"}[^""']*$"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)")) //operator is unclosed
                {
                    args.Shift = args.TabLength;
                    return;
                }
        }

        public override void Init()
        {
            Textbox.CommentPrefix = "//";
            Textbox.LeftBracket = '(';
            Textbox.RightBracket = ')';
            Textbox.LeftBracket2 = '{';
            Textbox.RightBracket2 = '}';
            Textbox.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            Textbox.AutoIndentCharsPatterns = @"^\s*\$[\w\.\[\]\'\""]+\s*(?<range>=)\s*(?<range>[^;]+);";

            AddStyle("String",
                PredefinedStyles.RedStyle,
                new Regex(@"""""|''|"".*?[^\\]""|'.*?[^\\]'", RegexCompiledOption));
            AddStyle("Comment",
                PredefinedStyles.GreenStyle,
                new Regex(@"(//|#).*$", RegexOptions.Multiline | RegexCompiledOption));
            AddStyle("Comment2",
                PredefinedStyles.GreenStyle,
                new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline | RegexCompiledOption));
            AddStyle("Comment3",
                PredefinedStyles.GreenStyle,
                new Regex(@"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption));
            AddStyle("Number",
                PredefinedStyles.RedStyle,
                new Regex(@"\b\d+[\.]?\d*\b", RegexCompiledOption));
            AddStyle("Variable",
                PredefinedStyles.MaroonStyle,
                new Regex(@"\$[a-zA-Z_\d]*\b", RegexCompiledOption));
            AddStyle("Keyword",
                PredefinedStyles.MagentaStyle,
                new Regex(@"\b(die|echo|empty|exit|eval|include|include_once|isset|list|require|require_once|return|print|unset)\b", RegexCompiledOption));
            AddStyle("Keyword2",
                PredefinedStyles.BlueStyle,
                new Regex(@"\b(abstract|and|array|as|break|case|catch|cfunction|class|clone|const|continue|declare|default|do|else|elseif|enddeclare|endfor|endforeach|endif|endswitch|endwhile|extends|final|for|foreach|function|global|goto|if|implements|instanceof|interface|namespace|new|or|private|protected|public|static|switch|throw|try|use|var|while|xor)\b", RegexCompiledOption));
            AddStyle("Keyword3",
                PredefinedStyles.GrayStyle,
                new Regex(@"__CLASS__|__DIR__|__FILE__|__LINE__|__FUNCTION__|__METHOD__|__NAMESPACE__", RegexCompiledOption));

            AddFoldingRule("{", "}");
            AddFoldingRule(@"/\*", @"\*/");
        }
    }
}
