using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class CSharpSyntaxSource : SyntaxHighlighter
    {
        Style TagContentStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        Regex TagContentRegex = new Regex(@"<[^>]+>", RegexCompiledOption);

        public CSharpSyntaxSource(FastColoredTextBox textbox) : base(textbox)
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
            //label
            if (Regex.IsMatch(args.LineText, @"^\s*\w+\s*:\s*($|//)") &&
                !Regex.IsMatch(args.LineText, @"^\s*default\s*:"))
            {
                args.Shift = -args.TabLength;
                return;
            }
            //some statements: case, default
            if (Regex.IsMatch(args.LineText, @"^\s*(case|default)\b.*:\s*($|//)"))
            {
                args.Shift = -args.TabLength / 2;
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
            //Brackets
            Textbox.CommentPrefix = "//";
            Textbox.LeftBracket = '(';
            Textbox.RightBracket = ')';
            Textbox.LeftBracket2 = '{';
            Textbox.RightBracket2 = '}';
            Textbox.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            Textbox.AutoIndentCharsPatterns = @"^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);^\s*(case|default)\s*[^:]*(?<range>:)\s*(?<range>[^;]+);";

            //MainStyles
            AddStyle("String",
                PredefinedStyles.BrownStyle,
                new Regex(
                    @"
                            # Character definitions:
                            '
                            (?> # disable backtracking
                              (?:
                                \\[^\r\n]|    # escaped meta char
                                [^'\r\n]      # any character except '
                              )*
                            )
                            '?
                            |
                            # Normal string & verbatim strings definitions:
                            (?<verbatimIdentifier>@)?         # this group matches if it is an verbatim string
                            ""
                            (?> # disable backtracking
                              (?:
                                # match and consume an escaped character including escaped double quote ("") char
                                (?(verbatimIdentifier)        # if it is a verbatim string ...
                                  """"|                         #   then: only match an escaped double quote ("") char
                                  \\.                         #   else: match an escaped sequence
                                )
                                | # OR
            
                                # match any char except double quote char ("")
                                [^""]
                              )*
                            )
                            ""
                        ",
                    RegexOptions.ExplicitCapture | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace |
                    RegexCompiledOption
                    )); //thanks to rittergig for this regex

            AddStyle("Comment1",
                PredefinedStyles.GreenStyle,
                new Regex(@"//.*$", RegexOptions.Multiline | RegexCompiledOption));

            AddStyle("Comment2",
                PredefinedStyles.GreenStyle,
                new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline | RegexCompiledOption));

            AddStyle("Comment3",
                PredefinedStyles.GreenStyle,
                new Regex(@"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption));

            AddStyle("Number",
                PredefinedStyles.MagentaStyle,
                new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b", RegexCompiledOption));

            AddStyle("Attribute",
                PredefinedStyles.GreenStyle,
                new Regex(@"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline | RegexCompiledOption));

            AddStyle("Class Name",
                PredefinedStyles.BoldStyle,
                new Regex(@"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b", RegexCompiledOption));

            AddStyle("Keyword",
                PredefinedStyles.BlueStyle,
                new Regex(@"\b(abstract|add|alias|as|ascending|async|await|base|bool|break|by|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|descending|do|double|dynamic|else|enum|equals|event|explicit|extern|false|finally|fixed|float|for|foreach|from|get|global|goto|group|if|implicit|in|int|interface|internal|into|is|join|let|lock|long|nameof|namespace|new|null|object|on|operator|orderby|out|override|params|partial|private|protected|public|readonly|ref|remove|return|sbyte|sealed|select|set|short|sizeof|stackalloc|static|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|using|value|var|virtual|void|volatile|when|where|while|yield)\b|#region\b|#endregion\b",
                    RegexCompiledOption));

            AddFoldingRule("{", "}");
            AddFoldingRule(@"#region\b", @"#endregion\b");
            AddFoldingRule(@"/\*", @"\*/");
        }

        public override void SyntaxHighlight(Range range)
        {
            //clear style of changed range
            range.ClearStyle(StyleSchema.Styles);
            //
            //string highlighting
            foreach (var styleInfo in StyleSchema)
                range.SetStyle(styleInfo.Style, styleInfo.Rule);

            //find document comments
            foreach (Range r in range.GetRanges(@"^\s*///.*$", RegexOptions.Multiline))
            {
                //remove C# highlighting from this fragment
                r.ClearStyle(StyleIndex.All);
                r.SetStyle(StyleSchema["Comment1"].Style);
                //tags
                foreach (Range rr in r.GetRanges(TagContentRegex))
                {
                    rr.ClearStyle(StyleIndex.All);
                    rr.SetStyle(TagContentStyle);
                }
                //prefix '///'
                foreach (Range rr in r.GetRanges(@"^\s*///", RegexOptions.Multiline))
                {
                    rr.ClearStyle(StyleIndex.All);
                    rr.SetStyle(TagContentStyle);
                }
            }

            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            foreach (var foldRule in FoldingSchema)
                range.SetFoldingMarkers(foldRule.startMarkerRegex, foldRule.endMarkerRegex);
        }
    }
}
