using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Language2
{
	public class Html : ILanguage {

		private readonly Style CommentStyle = LanguageStyles.Green;
		private readonly Style TagBracketStyle = LanguageStyles.Green;
		private readonly Style TagNameStyle = LanguageStyles.Green;
		private readonly Style AttributeStyle = LanguageStyles.Green;
		private readonly Style AttributeValueStyle = LanguageStyles.Green;
		private readonly Style HtmlEntityStyle = LanguageStyles.Green;

        protected Regex HTMLAttrRegex,
                      HTMLAttrValRegex,
                      HTMLCommentRegex1,
                      HTMLCommentRegex2;

        protected Regex HTMLEndTagRegex;

        protected Regex HTMLEntityRegex,
                      HTMLTagContentRegex;

        protected Regex HTMLTagNameRegex;
        protected Regex HTMLTagRegex;


		public Html() {
			InitRegex();
		}
        protected void InitRegex()
        {
            HTMLCommentRegex1 = new Regex(@"(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | Parsing.RegexCompiledOption);
            HTMLCommentRegex2 = new Regex(@"(<!--.*?-->)|(.*-->)",
                                          RegexOptions.Singleline | RegexOptions.RightToLeft | Parsing.RegexCompiledOption);
            HTMLTagRegex = new Regex(@"<|/>|</|>", Parsing.RegexCompiledOption);
            HTMLTagNameRegex = new Regex(@"<(?<range>[!\w:]+)", Parsing.RegexCompiledOption);
            HTMLEndTagRegex = new Regex(@"</(?<range>[\w:]+)>", Parsing.RegexCompiledOption);
            HTMLTagContentRegex = new Regex(@"<[^>]+>", Parsing.RegexCompiledOption);
            HTMLAttrRegex =
                new Regex(
                    @"(?<range>[\w\d\-]{1,20}?)='[^']*'|(?<range>[\w\d\-]{1,20})=""[^""]*""|(?<range>[\w\d\-]{1,20})=[\w\d\-]{1,20}",
                    Parsing.RegexCompiledOption);
            HTMLAttrValRegex =
                new Regex(
                    @"[\w\d\-]{1,20}?=(?<range>'[^']*')|[\w\d\-]{1,20}=(?<range>""[^""]*"")|[\w\d\-]{1,20}=(?<range>[\w\d\-]{1,20})",
                    Parsing.RegexCompiledOption);
            HTMLEntityRegex = new Regex(@"\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});",
                                        Parsing.RegexCompiledOption | RegexOptions.IgnoreCase);
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
			range.ClearStyle(CommentStyle, TagBracketStyle, TagNameStyle, AttributeStyle, AttributeValueStyle,
												HtmlEntityStyle);
			//
			if (HTMLTagRegex == null)
					InitRegex();
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

	}
}
