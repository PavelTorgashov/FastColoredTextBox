using System;
using System.Collections.Generic;
using System.Text;

namespace FastColoredTextBoxNS.Highlighter
{
    class HtmlSyntaxHighlighter : SyntaxHighlighter
    {
        public HtmlSyntaxHighlighter()
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
            throw new NotImplementedException();
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

        #region private members
        private Style CommentStyle { get; set; }
        private Style TagBracketStyle { get; set; }
        private Style TagNameStyle { get; set; }
        private Style AttributeStyle { get; set; }
        private Style AttributeValueStyle { get; set; }
        private Style HtmlEntityStyle { get; set; }
        #endregion
    }
}
