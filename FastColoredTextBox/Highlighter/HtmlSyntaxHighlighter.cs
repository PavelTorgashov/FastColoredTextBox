﻿using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace FastColoredTextBoxNS.Highlighter
{
    public class HtmlSyntaxHighlighter : SyntaxHighlighter
    {
        public HtmlSyntaxHighlighter()
        {
            InitStyleSchema();
            InitHTMLRegex();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void HighlightSyntax(Range range)
        {
            HtmlSyntaxHighlight(range);
        }

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            HTMLAutoIndentNeeded(sender, args);
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

        public override List<string> getStyleSchemaNames()
        {
            string[] namesArray = { "CommentStyle","TagBracketStyle","TagNameStyle","AttributeStyle","AttributeValueStyle","HtmlEntityStyle" };
            return new List<string>(namesArray);
        }

        public override bool setStyleSchema(string name, Style newStyle)
        {
            switch (name)
            {
                case "CommentStyle":
                    return (this.CommentStyle = newStyle) == newStyle;
                case "TagBracketStyle":
                    return (this.TagBracketStyle = newStyle) == newStyle;
                case "TagNameStyle":
                    return (this.TagNameStyle = newStyle) == newStyle;
                case "AttributeStyle":
                    return (this.AttributeStyle = newStyle) == newStyle;
                case "AttributeValueStyle":
                    return (this.AttributeValueStyle = newStyle) == newStyle;
                case "HtmlEntityStyle":
                    return (this.HtmlEntityStyle = newStyle) == newStyle;
            }
            return false;
        }

        private void InitStyleSchema()
        {
            CommentStyle = GreenStyle;
            TagBracketStyle = BlueStyle;
            TagNameStyle = MaroonStyle;
            AttributeStyle = RedStyle;
            AttributeValueStyle = BlueStyle;
            HtmlEntityStyle = RedStyle;
        }

        private void InitHTMLRegex()
        {
            HTMLCommentRegex1 = new Regex(@"(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | RegexCompiledOption);
            HTMLCommentRegex2 = new Regex(@"(<!--.*?-->)|(.*-->)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
            HTMLTagRegex = new Regex(@"<|/>|</|>", RegexCompiledOption);
            HTMLTagNameRegex = new Regex(@"<(?<range>[!\w:]+)", RegexCompiledOption);
            HTMLEndTagRegex = new Regex(@"</(?<range>[\w:]+)>", RegexCompiledOption);
            HTMLTagContentRegex = new Regex(@"<[^>]+>", RegexCompiledOption);
            HTMLAttrRegex = new Regex(@"(?<range>[\w\d\-]{1,20}?)='[^']*'|(?<range>[\w\d\-]{1,20})=""[^""]*""|(?<range>[\w\d\-]{1,20})=[\w\d\-]{1,20}", RegexCompiledOption);
            HTMLAttrValRegex = new Regex(@"[\w\d\-]{1,20}?=(?<range>'[^']*')|[\w\d\-]{1,20}=(?<range>""[^""]*"")|[\w\d\-]{1,20}=(?<range>[\w\d\-]{1,20})", RegexCompiledOption);
            HTMLEntityRegex = new Regex(@"\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});", RegexCompiledOption | RegexOptions.IgnoreCase);
        }

        private void HtmlSyntaxHighlight(Range range)
        {
            //clear style of changed range
            range.ClearStyle(CommentStyle, TagBracketStyle, TagNameStyle, AttributeStyle, AttributeValueStyle, HtmlEntityStyle);

            //comment highlighting
            range.SetStyle(CommentStyle, HTMLCommentRegex1);
            range.SetStyle(CommentStyle, HTMLCommentRegex2);
            //tag brackets highlighting
            range.SetStyle(TagBracketStyle, HTMLTagRegex);
            //tag name
            range.SetStyle(TagNameStyle, HTMLTagNameRegex);
            //end of tag
            range.SetStyle(TagNameStyle, HTMLEndTagRegex);
            //attributes
            range.SetStyle(AttributeStyle, HTMLAttrRegex);
            //attribute values
            range.SetStyle(AttributeValueStyle, HTMLAttrValRegex);
            //html entity
            range.SetStyle(HtmlEntityStyle, HTMLEntityRegex);

            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            range.SetFoldingMarkers("<head", "</head>", RegexOptions.IgnoreCase);
            range.SetFoldingMarkers("<body", "</body>", RegexOptions.IgnoreCase);
            range.SetFoldingMarkers("<table", "</table>", RegexOptions.IgnoreCase);
            range.SetFoldingMarkers("<form", "</form>", RegexOptions.IgnoreCase);
            range.SetFoldingMarkers("<div", "</div>", RegexOptions.IgnoreCase);
            range.SetFoldingMarkers("<script", "</script>", RegexOptions.IgnoreCase);
            range.SetFoldingMarkers("<tr", "</tr>", RegexOptions.IgnoreCase);
        }

        private void HTMLAutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            var tb = sender as FastColoredTextBox;
            tb.CalcAutoIndentShiftByCodeFolding(sender, args);
        }

        #region private members
        private Regex HTMLAttrRegex, HTMLAttrValRegex, HTMLCommentRegex1, HTMLCommentRegex2;
        private Regex HTMLEndTagRegex;
        private Regex HTMLEntityRegex, HTMLTagContentRegex;
        private Regex HTMLTagNameRegex;
        private Regex HTMLTagRegex;

        private Style CommentStyle { get; set; }
        private Style TagBracketStyle { get; set; }
        private Style TagNameStyle { get; set; }
        private Style AttributeStyle { get; set; }
        private Style AttributeValueStyle { get; set; }
        private Style HtmlEntityStyle { get; set; }
        #endregion
    }
}
