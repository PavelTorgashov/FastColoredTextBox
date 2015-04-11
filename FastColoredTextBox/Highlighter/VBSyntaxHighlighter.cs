using System;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Highlighter
{
    class VBSyntaxHighlighter : SyntaxHighlighter
    {
        public VBSyntaxHighlighter()
        {
            InitStyleSchema();
        }

        public override void HighlightSyntax(Range range)
        {
            VBSyntaxHighlight(range);
        }

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            VBAutoIntentNeeded(sender, args);
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void setTextBoxParameter(FastColoredTextBox tb)
        {
            tb.CommentPrefix = "'";
            tb.LeftBracket = '(';
            tb.RightBracket = ')';
            tb.LeftBracket2 = '\x0';
            tb.RightBracket2 = '\x0';

            tb.AutoIndentCharsPatterns = @"^\s*[\w\.\(\)]+\s*(?<range>=)\s*(?<range>.+)";
        }

        private void InitStyleSchema()
        {
            StringStyle = BrownStyle;
            CommentStyle = GreenStyle;
            NumberStyle = MagentaStyle;
            ClassNameStyle = BoldStyle;
            KeywordStyle = BlueStyle;
        }

        private void InitVBRegex()
        {
            VBStringRegex = new Regex(@"""""|"".*?[^\\]""", RegexCompiledOption);
            VBCommentRegex = new Regex(@"'.*$", RegexOptions.Multiline | RegexCompiledOption);
            VBNumberRegex = new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?\b", RegexCompiledOption);
            VBClassNameRegex = new Regex(@"\b(Class|Structure|Enum|Interface)[ ]+(?<range>\w+?)\b", RegexOptions.IgnoreCase | RegexCompiledOption);
            VBKeywordRegex = new Regex(@"\b(AddHandler|AddressOf|Alias|And|AndAlso|As|Boolean|ByRef|Byte|ByVal|Call|Case|Catch|CBool|CByte|CChar|CDate|CDbl|CDec|Char|CInt|Class|CLng|CObj|Const|Continue|CSByte|CShort|CSng|CStr|CType|CUInt|CULng|CUShort|Date|Decimal|Declare|Default|Delegate|Dim|DirectCast|Do|Double|Each|Else|ElseIf|End|EndIf|Enum|Erase|Error|Event|Exit|False|Finally|For|Friend|Function|Get|GetType|GetXMLNamespace|Global|GoSub|GoTo|Handles|If|Implements|Imports|In|Inherits|Integer|Interface|Is|IsNot|Let|Lib|Like|Long|Loop|Me|Mod|Module|MustInherit|MustOverride|MyBase|MyClass|Namespace|Narrowing|New|Next|Not|Nothing|NotInheritable|NotOverridable|Object|Of|On|Operator|Option|Optional|Or|OrElse|Overloads|Overridable|Overrides|ParamArray|Partial|Private|Property|Protected|Public|RaiseEvent|ReadOnly|ReDim|REM|RemoveHandler|Resume|Return|SByte|Select|Set|Shadows|Shared|Short|Single|Static|Step|Stop|String|Structure|Sub|SyncLock|Then|Throw|To|True|Try|TryCast|TypeOf|UInteger|ULong|UShort|Using|Variant|Wend|When|While|Widening|With|WithEvents|WriteOnly|Xor|Region)\b|(#Const|#Else|#ElseIf|#End|#If|#Region)\b", RegexOptions.IgnoreCase | RegexCompiledOption);
        }

        private void VBSyntaxHighlight(Range range)
        {
            if (VBStringRegex == null)
                InitVBRegex();

            //clear style of changed range
            range.ClearStyle(StringStyle, CommentStyle, NumberStyle, ClassNameStyle, KeywordStyle);
            //string highlighting
            range.SetStyle(StringStyle, VBStringRegex);
            //comment highlighting
            range.SetStyle(CommentStyle, VBCommentRegex);
            //number highlighting
            range.SetStyle(NumberStyle, VBNumberRegex);
            //class name highlighting
            range.SetStyle(ClassNameStyle, VBClassNameRegex);
            //keyword highlighting
            range.SetStyle(KeywordStyle, VBKeywordRegex);

            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            range.SetFoldingMarkers(@"#Region\b", @"#End\s+Region\b", RegexOptions.IgnoreCase);
            range.SetFoldingMarkers(@"\b(Class|Property|Enum|Structure|Interface)[ \t]+\S+", @"\bEnd (Class|Property|Enum|Structure|Interface)\b", RegexOptions.IgnoreCase);
            range.SetFoldingMarkers(@"^\s*(?<range>While)[ \t]+\S+", @"^\s*(?<range>End While)\b", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            range.SetFoldingMarkers(@"\b(Sub|Function)[ \t]+[^\s']+", @"\bEnd (Sub|Function)\b", RegexOptions.IgnoreCase);
            //this declared separately because Sub and Function can be unclosed
            range.SetFoldingMarkers(@"(\r|\n|^)[ \t]*(?<range>Get|Set)[ \t]*(\r|\n|$)", @"\bEnd (Get|Set)\b", RegexOptions.IgnoreCase);
            range.SetFoldingMarkers(@"^\s*(?<range>For|For\s+Each)\b", @"^\s*(?<range>Next)\b", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            range.SetFoldingMarkers(@"^\s*(?<range>Do)\b", @"^\s*(?<range>Loop)\b", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }

        private void VBAutoIntentNeeded(object sender, AutoIndentEventArgs args)
        {
            //end of block
            if (Regex.IsMatch(args.LineText, @"^\s*(End|EndIf|Next|Loop)\b", RegexOptions.IgnoreCase))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //start of declaration
            if (Regex.IsMatch(args.LineText,
                              @"\b(Class|Property|Enum|Structure|Sub|Function|Namespace|Interface|Get)\b|(Set\s*\()",
                              RegexOptions.IgnoreCase))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            // then ...
            if (Regex.IsMatch(args.LineText, @"\b(Then)\s*\S+", RegexOptions.IgnoreCase))
                return;
            //start of operator block
            if (Regex.IsMatch(args.LineText, @"^\s*(If|While|For|Do|Try|With|Using|Select)\b", RegexOptions.IgnoreCase))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }

            //Statements else, elseif, case etc
            if (Regex.IsMatch(args.LineText, @"^\s*(Else|ElseIf|Case|Catch|Finally)\b", RegexOptions.IgnoreCase))
            {
                args.Shift = -args.TabLength;
                return;
            }

            //Char _
            if (args.PrevLineText.TrimEnd().EndsWith("_"))
            {
                args.Shift = args.TabLength;
                return;
            }
        }

        #region private members
        private Regex VBClassNameRegex;
        private Regex VBCommentRegex;
        private Regex VBKeywordRegex;
        private Regex VBNumberRegex;
        private Regex VBStringRegex;

        private Style StringStyle { get; set; }
        private Style CommentStyle { get; set; }
        private Style NumberStyle { get; set; }
        private Style ClassNameStyle { get; set; }
        private Style KeywordStyle { get; set; }
        #endregion
    }
}
