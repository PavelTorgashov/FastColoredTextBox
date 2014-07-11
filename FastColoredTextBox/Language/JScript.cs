using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS.Language2;

namespace FastColoredTextBoxNS.Language2
{
	public class JScript : ILanguage
	{
		private readonly Style StringStyle = LanguageStyles.Brown;
		private readonly Style CommentStyle = LanguageStyles.Green;
		private readonly Style NumberStyle = LanguageStyles.Magenta;
		private readonly Style KeywordStyle = LanguageStyles.Blue;

        protected Regex JScriptCommentRegex1,
                      JScriptCommentRegex2,
                      JScriptCommentRegex3;

        protected Regex JScriptKeywordRegex;
        protected Regex JScriptNumberRegex;
        protected Regex JScriptStringRegex;

		public JScript() {
			InitJScriptRegex();
		}

        protected void InitJScriptRegex()
        {
            JScriptStringRegex = new Regex(@"""""|''|"".*?[^\\]""|'.*?[^\\]'", Parsing.RegexCompiledOption);
            JScriptCommentRegex1 = new Regex(@"//.*$", RegexOptions.Multiline | Parsing.RegexCompiledOption);
            JScriptCommentRegex2 = new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline | Parsing.RegexCompiledOption);
            JScriptCommentRegex3 = new Regex(@"(/\*.*?\*/)|(.*\*/)",
                                             RegexOptions.Singleline | RegexOptions.RightToLeft | Parsing.RegexCompiledOption);
            JScriptNumberRegex = new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b",
                                           Parsing.RegexCompiledOption);
            JScriptKeywordRegex =
                new Regex(
                    @"\b(true|false|break|case|catch|const|continue|default|delete|do|else|export|for|function|if|in|instanceof|new|null|return|switch|this|throw|try|var|void|while|with|typeof)\b",
                    Parsing.RegexCompiledOption);
        }

		public void AutoIndentNeeded(FastColoredTextBox fctb, AutoIndentEventArgs args) {
			throw new NotImplementedException();
		}

		public void SyntaxHighlight(Range range) {
            range.tb.CommentPrefix = "//";
            range.tb.LeftBracket = '(';
            range.tb.RightBracket = ')';
            range.tb.LeftBracket2 = '{';
            range.tb.RightBracket2 = '}';
            range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
            //clear style of changed range
            range.ClearStyle(StringStyle, CommentStyle, NumberStyle, KeywordStyle);
            //
            if (JScriptStringRegex == null)
                InitJScriptRegex();
            //string highlighting
            range.SetStyle(StringStyle, JScriptStringRegex);
            //comment highlighting
            range.SetStyle(CommentStyle, JScriptCommentRegex1);
            range.SetStyle(CommentStyle, JScriptCommentRegex2);
            range.SetStyle(CommentStyle, JScriptCommentRegex3);
            //number highlighting
            range.SetStyle(NumberStyle, JScriptNumberRegex);
            //keyword highlighting
            range.SetStyle(KeywordStyle, JScriptKeywordRegex);
            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            range.SetFoldingMarkers("{", "}"); //allow to collapse brackets block
            range.SetFoldingMarkers(@"/\*", @"\*/"); //allow to collapse comment block
		}

	}
}
