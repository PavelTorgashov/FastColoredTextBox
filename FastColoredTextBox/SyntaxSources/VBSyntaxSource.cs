using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class VBSyntaxSource : SyntaxHighlighter
    {
        public VBSyntaxSource(FastColoredTextBox textbox) : base(textbox)
        {
            Init();
        }
        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
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
        public override void Init()
        {
            Textbox.CommentPrefix = "'";
            Textbox.LeftBracket = '(';
            Textbox.RightBracket = ')';
            Textbox.LeftBracket2 = '\x0';
            Textbox.RightBracket2 = '\x0';

            Textbox.AutoIndentCharsPatterns
                = @"
^\s*[\w\.\(\)]+\s*(?<range>=)\s*(?<range>.+)
";
            AddStyle("String",
                PredefinedStyles.BrownStyle,
                new Regex(@"""""|"".*?[^\\]""", RegexCompiledOption));
            AddStyle("Comment",
                PredefinedStyles.GreenStyle,
                new Regex(@"'.*$", RegexOptions.Multiline | RegexCompiledOption));
            AddStyle("Number",
                PredefinedStyles.MagentaStyle,
                new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?\b", RegexCompiledOption));
            AddStyle("Class Name",
                PredefinedStyles.BoldStyle,
                new Regex(@"\b(Class|Structure|Enum|Interface)[ ]+(?<range>\w+?)\b", RegexOptions.IgnoreCase | RegexCompiledOption));
            AddStyle("Keyword",
                PredefinedStyles.BlueStyle,
                 new Regex(@"\b(AddHandler|AddressOf|Alias|And|AndAlso|As|Boolean|ByRef|Byte|ByVal|Call|Case|Catch|CBool|CByte|CChar|CDate|CDbl|CDec|Char|CInt|Class|CLng|CObj|Const|Continue|CSByte|CShort|CSng|CStr|CType|CUInt|CULng|CUShort|Date|Decimal|Declare|Default|Delegate|Dim|DirectCast|Do|Double|Each|Else|ElseIf|End|EndIf|Enum|Erase|Error|Event|Exit|False|Finally|For|Friend|Function|Get|GetType|GetXMLNamespace|Global|GoSub|GoTo|Handles|If|Implements|Imports|In|Inherits|Integer|Interface|Is|IsNot|Let|Lib|Like|Long|Loop|Me|Mod|Module|MustInherit|MustOverride|MyBase|MyClass|Namespace|Narrowing|New|Next|Not|Nothing|NotInheritable|NotOverridable|Object|Of|On|Operator|Option|Optional|Or|OrElse|Overloads|Overridable|Overrides|ParamArray|Partial|Private|Property|Protected|Public|RaiseEvent|ReadOnly|ReDim|REM|RemoveHandler|Resume|Return|SByte|Select|Set|Shadows|Shared|Short|Single|Static|Step|Stop|String|Structure|Sub|SyncLock|Then|Throw|To|True|Try|TryCast|TypeOf|UInteger|ULong|UShort|Using|Variant|Wend|When|While|Widening|With|WithEvents|WriteOnly|Xor|Region)\b|(#Const|#Else|#ElseIf|#End|#If|#Region)\b", RegexOptions.IgnoreCase | RegexCompiledOption));
            
            AddFoldingRule(@"#Region\b", @"#End\s+Region\b", RegexOptions.IgnoreCase);
            AddFoldingRule(@"\b(Class|Property|Enum|Structure|Interface)[ \t]+\S+", 
                @"\bEnd (Class|Property|Enum|Structure|Interface)\b", RegexOptions.IgnoreCase);
            AddFoldingRule(@"^\s*(?<range>While)[ \t]+\S+", @"^\s*(?<range>End While)\b",
                                    RegexOptions.Multiline | RegexOptions.IgnoreCase);
            AddFoldingRule(@"\b(Sub|Function)[ \t]+[^\s']+", @"\bEnd (Sub|Function)\b", RegexOptions.IgnoreCase);
            AddFoldingRule(@"(\r|\n|^)[ \t]*(?<range>Get|Set)[ \t]*(\r|\n|$)", @"\bEnd (Get|Set)\b",
                                    RegexOptions.IgnoreCase);
            AddFoldingRule(@"^\s*(?<range>For|For\s+Each)\b", @"^\s*(?<range>Next)\b",
                                    RegexOptions.Multiline | RegexOptions.IgnoreCase);
            AddFoldingRule(@"^\s*(?<range>Do)\b", @"^\s*(?<range>Loop)\b",
                                    RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }

    }
}
