using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Language2
{
	public interface ILanguage {
		void AutoIndentNeeded(FastColoredTextBox fctb, AutoIndentEventArgs args);
		void SyntaxHighlight(Range range);
	}

	//public class LanguageStyle {

	//	public Style Comment { get; set; }
	//	public Style String { get; set; }
	//	public Style Number { get; set; }
	//	public Style Class { get; set; }
	//	public Style Keyword { get; set; }
	//	public Style Keyword2 { get; set; }
	//	public Style Keyword3 { get; set; }
	//	public Style Attribute { get; set; }
	//	public Style TagBracket { get; set; }
	//	public Style TagName { get; set; }
	//	public Style HtmlEntity { get; set; }
	//	public Style Function { get; set; }
	//	public Style Variable { get; set; }
	//	public Style Statement { get; set; }
	//	public Style Types { get; set; }

	//}

	public static class LanguageStyles {
		public static Style BlueBold = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
		public static Style Blue = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
		public static Style Bold = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
		public static Style Brown = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
		public static Style Gray = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
		public static Style Green = new TextStyle(Brushes.Green, null, FontStyle.Italic);
		public static Style Magenta = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
		public static Style Maroon = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
		public static Style Red = new TextStyle(Brushes.Red, null, FontStyle.Regular);
		public static Style Black = new TextStyle(Brushes.Black, null, FontStyle.Regular);
	}

	public class Parsing {

		protected static readonly Platform platformType = PlatformType.GetOperationSystemPlatform();
        public static RegexOptions RegexCompiledOption
        {
            get
            {
                if (platformType == Platform.X86)
                    return RegexOptions.Compiled;
                else
                    return RegexOptions.None;
            }
        }

	}
}
