using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Highlighter
{
    class XMLSyntaxHighlighter : SyntaxHighlighter
    {
        public XMLSyntaxHighlighter()
        {
            InitStyleSchema();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void HighlightSyntax(Range range)
        {
            throw new NotImplementedException();
        }

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            XMLAutoIndentNeeded(sender, args);
        }

        public override void setTextBoxParameter(FastColoredTextBox tb)
        {
            tb.CommentPrefix = null;
            tb.LeftBracket = '<';
            tb.RightBracket = '>';
            tb.LeftBracket2 = '(';
            tb.RightBracket2 = ')';
            tb.AutoIndentCharsPatterns = @"";
        }

        private void InitStyleSchema()
        {
            CommentStyle = GreenStyle;
            XmlTagBracketStyle = BlueStyle;
            XmlTagNameStyle = MaroonStyle;
            XmlAttributeStyle = RedStyle;
            XmlAttributeValueStyle = BlueStyle;
            XmlEntityStyle = RedStyle;
            XmlCDataStyle = BlackStyle;
        }

        private void InitXMLRegex()
        {
            XMLCommentRegex1 = new Regex(@"(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | RegexCompiledOption);
            XMLCommentRegex2 = new Regex(@"(<!--.*?-->)|(.*-->)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
            XMLTagRegex = new Regex(@"<\?|<|/>|</|>|\?>", RegexCompiledOption);
            XMLTagNameRegex = new Regex(@"<[?](?<range1>[x][m][l]{1})|<(?<range>[!\w:]+)", RegexCompiledOption);
            XMLEndTagRegex = new Regex(@"</(?<range>[\w:]+)>", RegexCompiledOption);
            XMLTagContentRegex = new Regex(@"<[^>]+>", RegexCompiledOption);
            XMLAttrRegex = new Regex(@"(?<range>[\w\d\-\:]+)[ ]*=[ ]*'[^']*'|(?<range>[\w\d\-\:]+)[ ]*=[ ]*""[^""]*""|(?<range>[\w\d\-\:]+)[ ]*=[ ]*[\w\d\-\:]+", RegexCompiledOption);
            XMLAttrValRegex = new Regex(@"[\w\d\-]+?=(?<range>'[^']*')|[\w\d\-]+[ ]*=[ ]*(?<range>""[^""]*"")|[\w\d\-]+[ ]*=[ ]*(?<range>[\w\d\-]+)", RegexCompiledOption);
            XMLEntityRegex = new Regex(@"\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});", RegexCompiledOption | RegexOptions.IgnoreCase);
            XMLCDataRegex = new Regex(@"<!\s*\[CDATA\s*\[(?<text>(?>[^]]+|](?!]>))*)]]>", RegexCompiledOption | RegexOptions.IgnoreCase); // http://stackoverflow.com/questions/21681861/i-need-a-regex-that-matches-cdata-elements-in-html
            XMLFoldingRegex = new Regex(@"<(?<range>/?\w+)\s[^>]*?[^/]>|<(?<range>/?\w+)\s*>", RegexOptions.Singleline | RegexCompiledOption);
        }

        private void XMLSyntaxHighlight(Range range)
        {
            if (XMLTagRegex == null)
                InitXMLRegex();

            //clear style of changed range
            range.ClearStyle(CommentStyle, XmlTagBracketStyle, XmlTagNameStyle, XmlAttributeStyle, XmlAttributeValueStyle, XmlEntityStyle, XmlCDataStyle);
            //xml CData
            range.SetStyle(XmlCDataStyle, XMLCDataRegex);
            //comment highlighting
            range.SetStyle(CommentStyle, XMLCommentRegex1);
            range.SetStyle(CommentStyle, XMLCommentRegex2);
            //tag brackets highlighting
            range.SetStyle(XmlTagBracketStyle, XMLTagRegex);
            //tag name
            range.SetStyle(XmlTagNameStyle, XMLTagNameRegex);
            //end of tag
            range.SetStyle(XmlTagNameStyle, XMLEndTagRegex);
            //attributes
            range.SetStyle(XmlAttributeStyle, XMLAttrRegex);
            //attribute values
            range.SetStyle(XmlAttributeValueStyle, XMLAttrValRegex);
            //xml entity
            range.SetStyle(XmlEntityStyle, XMLEntityRegex);
            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            XmlFolding(range);
        }

        private void XMLAutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            var tb = sender as FastColoredTextBox;
            tb.CalcAutoIndentShiftByCodeFolding(sender, args);
        }

        private void XmlFolding(Range range)
        {
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

        #region private members
        private Regex XMLAttrRegex, XMLAttrValRegex, XMLCommentRegex1, XMLCommentRegex2;
        private Regex XMLEndTagRegex;
        private Regex XMLEntityRegex, XMLTagContentRegex;
        private Regex XMLTagNameRegex;
        private Regex XMLTagRegex;
        private Regex XMLCDataRegex;
        private Regex XMLFoldingRegex;

        private Style CommentStyle { get; set; }
        private Style XmlTagBracketStyle { get; set; }
        private Style XmlTagNameStyle { get; set; }
        private Style XmlAttributeStyle { get; set; }
        private Style XmlAttributeValueStyle { get; set; }
        private Style XmlEntityStyle { get; set; }
        private Style XmlCDataStyle { get; set; }
        #endregion

        private class XmlFoldingTag
        {
            public string Name;
            public int id;
            public int startLine;
            public string Marker { get { return Name + id; } }
        }
    }
}
