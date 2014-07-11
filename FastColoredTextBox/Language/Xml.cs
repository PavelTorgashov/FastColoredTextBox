using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS.Language2;

namespace FastColoredTextBoxNS.Language2
{
	public class Xml : ILanguage
	{
        protected Regex XMLAttrRegex,
                      XMLAttrValRegex,
                      XMLCommentRegex1,
                      XMLCommentRegex2;

        protected Regex XMLEndTagRegex;

        protected Regex XMLEntityRegex,
                      XMLTagContentRegex;

        protected Regex XMLTagNameRegex;
        protected Regex XMLTagRegex;
        protected Regex XMLCDataRegex;

		private readonly Style CommentStyle = LanguageStyles.Green;
		private readonly Style XmlTagBracketStyle = LanguageStyles.Blue;
		private readonly Style XmlTagNameStyle = LanguageStyles.Maroon;
		private readonly Style XmlAttributeStyle = LanguageStyles.Red;
		private readonly Style XmlAttributeValueStyle = LanguageStyles.Blue;
		private readonly Style XmlEntityStyle = LanguageStyles.Red;
		private readonly Style XmlCDataStyle = LanguageStyles.Black;


		public Xml() {
			InitXMLRegex();
		}
		        protected void InitXMLRegex()
        {
            XMLCommentRegex1 = new Regex(@"(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | Parsing.RegexCompiledOption);
            XMLCommentRegex2 = new Regex(@"(<!--.*?-->)|(.*-->)",
                                          RegexOptions.Singleline | RegexOptions.RightToLeft | Parsing.RegexCompiledOption);
            XMLTagRegex = new Regex(@"<\?|<|/>|</|>|\?>", Parsing.RegexCompiledOption);
            XMLTagNameRegex = new Regex(@"<[?](?<range1>[x][m][l]{1})|<(?<range>[!\w:]+)", Parsing.RegexCompiledOption);
            XMLEndTagRegex = new Regex(@"</(?<range>[\w:]+)>", Parsing.RegexCompiledOption);
            XMLTagContentRegex = new Regex(@"<[^>]+>", Parsing.RegexCompiledOption);
            XMLAttrRegex =
                new Regex(
                    @"(?<range>[\w\d\-\:]+)[ ]*=[ ]*'[^']*'|(?<range>[\w\d\-\:]+)[ ]*=[ ]*""[^""]*""|(?<range>[\w\d\-\:]+)[ ]*=[ ]*[\w\d\-\:]+",
                    Parsing.RegexCompiledOption);
            XMLAttrValRegex =
                new Regex(
                    @"[\w\d\-]+?=(?<range>'[^']*')|[\w\d\-]+[ ]*=[ ]*(?<range>""[^""]*"")|[\w\d\-]+[ ]*=[ ]*(?<range>[\w\d\-]+)",
                    Parsing.RegexCompiledOption);
            XMLEntityRegex = new Regex(@"\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});",
                                        Parsing.RegexCompiledOption | RegexOptions.IgnoreCase);
            XMLCDataRegex = new Regex(@"<!\s*\[CDATA\s*\[(?<text>(?>[^]]+|](?!]>))*)]]>", Parsing.RegexCompiledOption | RegexOptions.IgnoreCase); // http://stackoverflow.com/questions/21681861/i-need-a-regex-that-matches-cdata-elements-in-html
        }
		public void AutoIndentNeeded(FastColoredTextBox fctb, AutoIndentEventArgs args) {
            fctb.CalcAutoIndentShiftByCodeFolding(fctb, args);
		}

		public void SyntaxHighlight(Range range) {
            range.tb.CommentPrefix = null;
            range.tb.LeftBracket = '<';
            range.tb.RightBracket = '>';
            range.tb.LeftBracket2 = '(';
            range.tb.RightBracket2 = ')';

            //clear style of changed range
            range.ClearStyle(CommentStyle, XmlTagBracketStyle, XmlTagNameStyle, XmlAttributeStyle, XmlAttributeValueStyle,
                             XmlEntityStyle, XmlCDataStyle);

            //
            if (XMLTagRegex == null)
            {
                InitXMLRegex();
            }

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
            //
		}

	}
}
