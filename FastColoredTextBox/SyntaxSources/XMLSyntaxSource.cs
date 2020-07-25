using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class XMLSyntaxSource : SyntaxHighlighter
    {
        Regex XMLFoldingRegex;
        public XMLSyntaxSource(FastColoredTextBox textbox) : base(textbox)
        {
            Init();
        }

        public override void Init()
        {
            Textbox.CommentPrefix = null;
            Textbox.LeftBracket = '<';
            Textbox.RightBracket = '>';
            Textbox.LeftBracket2 = '(';
            Textbox.RightBracket2 = ')';
            Textbox.AutoIndentCharsPatterns = @"";

            AddStyle("CData",
                PredefinedStyles.BlackStyle,
                new Regex(@"<!\s*\[CDATA\s*\[(?<text>(?>[^]]+|](?!]>))*)]]>", RegexCompiledOption | RegexOptions.IgnoreCase)); // http://stackoverflow.com/questions/21681861/i-need-a-regex-that-matches-cdata-elements-in-html
            AddStyle("Comment",
                PredefinedStyles.GreenStyle,
                new Regex(@"(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | RegexCompiledOption));
            AddStyle("Comment2",
                PredefinedStyles.GreenStyle,
                new Regex(@"(<!--.*?-->)|(.*-->)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption));
            AddStyle("Tag Bracket",
                PredefinedStyles.BlueStyle,
                new Regex(@"<\?|<|/>|</|>|\?>", RegexCompiledOption));
            AddStyle("Tag Name",
                PredefinedStyles.MaroonStyle,
                new Regex(@"<[?](?<range1>[x][m][l]{1})|<(?<range>[!\w:]+)", RegexCompiledOption));
            AddStyle("End of tag",
                PredefinedStyles.MaroonStyle,
                new Regex(@"</(?<range>[\w:]+)>", RegexCompiledOption));
            AddStyle("Attribute",
                PredefinedStyles.RedStyle,
                new Regex(@"(?<range>[\w\d\-\:]+)[ ]*=[ ]*'[^']*'|(?<range>[\w\d\-\:]+)[ ]*=[ ]*""[^""]*""|(?<range>[\w\d\-\:]+)[ ]*=[ ]*[\w\d\-\:]+", RegexCompiledOption));
            AddStyle("Attribute Value",
                PredefinedStyles.BlueStyle,
                new Regex(@"[\w\d\-]+?=(?<range>'[^']*')|[\w\d\-]+[ ]*=[ ]*(?<range>""[^""]*"")|[\w\d\-]+[ ]*=[ ]*(?<range>[\w\d\-]+)", RegexCompiledOption));
            AddStyle("Entity",
                PredefinedStyles.RedStyle,
                new Regex(@"\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});", RegexCompiledOption | RegexOptions.IgnoreCase));
            
            
            XMLFoldingRegex = new Regex(@"<(?<range>/?\w+)\s[^>]*?[^/]>|<(?<range>/?\w+)\s*>", RegexOptions.Singleline | RegexCompiledOption);
        }
        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            var tb = sender as FastColoredTextBox;
            tb.CalcAutoIndentShiftByCodeFolding(sender, args);
        }
        public override void SyntaxHighlight(Range range)
        {
            base.SyntaxHighlight(range);
            var stack = new Stack<XmlFoldingTag>();
            var id = 0;
            var fctb = range.tb;
            //extract opening and closing tags (exclude open-close tags: <TAG/>)
            foreach (var r in range.GetRanges(XMLFoldingRegex))
            {
                var tagName = r.Text;
                var iLine = r.Start.iLine;
                //if it is opening tag...
                if (tagName[0] != '/')
                {
                    // ...push into stack
                    var tag = new XmlFoldingTag { Name = tagName, id = id++, startLine = r.Start.iLine };
                    stack.Push(tag);
                    // if this line has no markers - set marker
                    if (string.IsNullOrEmpty(fctb[iLine].FoldingStartMarker))
                        fctb[iLine].FoldingStartMarker = tag.Marker;
                }
                else
                {
                    //if it is closing tag - pop from stack
                    if (stack.Count > 0)
                    {
                        var tag = stack.Pop();
                        //compare line number
                        if (iLine == tag.startLine)
                        {
                            //remove marker, because same line can not be folding
                            if (fctb[iLine].FoldingStartMarker == tag.Marker) //was it our marker?
                                fctb[iLine].FoldingStartMarker = null;
                        }
                        else
                        {
                            //set end folding marker
                            if (string.IsNullOrEmpty(fctb[iLine].FoldingEndMarker))
                                fctb[iLine].FoldingEndMarker = tag.Marker;
                        }
                    }
                }
            }
        }

        class XmlFoldingTag
        {
            public string Name;
            public int id;
            public int startLine;
            public string Marker { get { return Name + id; } }
        }
    }
}
