using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class AvrasmSyntaxSource : SyntaxHighlighter
    {
        public AvrasmSyntaxSource(FastColoredTextBox textbox) : base(textbox)
        {
            Init();
        }
        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            //block macro
            if (Regex.IsMatch(args.LineText, @"^\.macro\s.*\.endm$"))
                return;
            //start of block macro
            if (Regex.IsMatch(args.LineText, @"\.macro\b"))
            {
                args.AbsoluteIndentation = 0;
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //end of block macro
            if (Regex.IsMatch(args.LineText, @"\.endm(?:acro)?\b"))
            {
                args.AbsoluteIndentation = 0;
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //Method start
            if (Regex.IsMatch(args.LineText, @"^\s*[A-Z]\w+:"))
            {
                args.AbsoluteIndentation = 0;
                args.ShiftNextLines = 2 * args.TabLength;
                return;
            }
            //Method end
            if (Regex.IsMatch(args.LineText, @"^\s*reti?"))
            {
                args.AbsoluteIndentation = 0;
                args.ShiftNextLines = 2 * args.TabLength;
                return;
            }
            if (Regex.IsMatch(args.LineText, @"^\s*[a-z]\w+:"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = args.TabLength;
                return;
            }
        }
        public override void Init()
        {
            //Brackets
            Textbox.CommentPrefix = ";";
            Textbox.LeftBracket = '\0';
            Textbox.RightBracket = '\0';
            Textbox.LeftBracket2 = '\0';
            Textbox.RightBracket2 = '\0';
            Textbox.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            Textbox.AutoIndentCharsPatterns = @"";

            //MainStyles
            AddStyle("String",
                PredefinedStyles.BrownStyle,
                new Regex(@"'(?<=[^\\])(.|\\[0nrabftv\\'""]|\\x[A-Fa-f0-9]{ 2}|\\[0-3][0-7]{2})'(?=[^\\])|" +
                @"""(?<=[^\\]).*?""(?=[^\\])", RegexOptions.Singleline | RegexCompiledOption));
            AddStyle("Comment", 
                PredefinedStyles.GreenStyle,
                new Regex(@"(\;.*)|(\/\/.*)$", RegexOptions.Multiline | RegexCompiledOption));
            AddStyle("Comment2", 
                StyleSchema["Comment1"].Style,
                new Regex(@"(\/\*.*?\*\/)|(\/\*.*)", RegexOptions.Singleline | RegexCompiledOption));
            AddStyle("Number",
                PredefinedStyles.GreenStyle,
                new Regex(@"((?<=\W)\\\d{3}\b)|((?<=\W)[\\0]x[A-Fa-f0-9]{2}\b)|(\b\d+\b)", RegexCompiledOption));
            AddStyle("PreProcessor Directive",
                PredefinedStyles.DarkGreenBoldStyle,
                new Regex(@"#(define|undef|ifn?def|(end)?if|el(if|se)|error|warning|message|include|pragma)?", RegexCompiledOption));
            AddStyle("Assembler Directive",
                PredefinedStyles.DarkGreenBoldStyle,     
                new Regex(@"\.(byte|cseg(size)?|db|def|dseg|dw|endm(acro)?|equ|eseg|exit|include|list(mac)?|macro|nolist|org|set|el(se|if)" +
                @"|endif|error|ifn?(def)?|message|dd|dq|undef|warning|(no)?overlap)\b", RegexOptions.IgnoreCase | RegexCompiledOption));
            AddStyle("Instruction",
                PredefinedStyles.MaroonStyle,
                new Regex(@"\b(?:ad[dc]|adiw|subi?|sbci?|andi?|ori?|eor|com|neg|[cs]br|inc|dec|tst|sbiw|f?mul(?:s|su)?|(?:r|i|ei)?jmp|" +
                @"(?:r|i|ei)?call|reti?|cp(?:se|c|i)?|sbr[cs]|sbi[cs]|brb[cs]|br(?:eq|ne|cs|cc|sh|lo|mi|pl|ge|lt|hs|hc|ts|tc|vs|vc|ie|id)|movw?|ld[is]?|la[cts]|" +
                @"xch|st[s]?|e?lpm|e?spm|in|out|push|pop|ls[rl]|ro[lr]|asr|swap|bset|bclr|[cs]bi|bst|bld|se[chinrstvz]|cl[chinrstvz]|nop|sleep|wdr|break)\b",
                RegexOptions.IgnoreCase | RegexCompiledOption));
            AddStyle("Define Name",
                PredefinedStyles.RedStyle,
                new Regex(@"(?:(?<=\.(?:def|set|equ)\s)|(?<=#define\s))\w+\b", RegexOptions.IgnoreCase | RegexCompiledOption));
            AddStyle("Method Name",
                new TextStyle(Brushes.Gray, null, FontStyle.Bold),
                new Regex(@"^[A-Z]\w*(?=:)", RegexOptions.Multiline | RegexCompiledOption));
            AddStyle("Label Name",
                PredefinedStyles.GrayStyle,
                new Regex(@"\t[a-z]\w*(?=:)", RegexCompiledOption));
            AddStyle("Macros Name",
                PredefinedStyles.BlueStyle,
                new Regex(@"(?<=\.macro\s)(?=\s*)\w+", RegexOptions.IgnoreCase | RegexCompiledOption));

            AddFoldingRule(@"\.[Mm][Aa][Cc][Rr][Oo]\b", @"\.[Ee][Nn][Dd][Mm]\b");
            AddFoldingRule(@"\.[Mm][Aa][Cc][Rr][Oo]\b", @"\.[Ee][Nn][Dd][Mm][Aa][Cc][Rr][Oo]\b");
            AddFoldingRule(@"[A-Z]\w*:", @"reti?\b");
            AddFoldingRule(@"/\*", @"\*/");

        }
    }
}
