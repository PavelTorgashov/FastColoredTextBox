using FastColoredTextBoxNS.Controllers;
using FastColoredTextBoxNS.Models.Syntaxes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS
{
    public partial class SyntaxHighlighter : IDisposable
    {
        protected static readonly Platform platformType = PlatformType.GetOperationSystemPlatform();

        protected readonly Dictionary<string, SyntaxDescriptor> descByXMLfileNames =
            new Dictionary<string, SyntaxDescriptor>();

        protected readonly List<Style> resilientStyles = new List<Style>(5);

        protected FastColoredTextBox currentTb;

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

        public SyntaxHighlighter(FastColoredTextBox currentTb) {
            this.currentTb = currentTb;
        }

        #region IDisposable Members

        public void Dispose()
        {
            foreach (SyntaxDescriptor desc in descByXMLfileNames.Values)
                desc.Dispose();
        }

        #endregion

        /// <summary>
        /// Highlights syntax for given language
        /// </summary>
        public virtual void HighlightSyntax(ILanguage language, Range range)
        {
            range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
            range.tb.AutoIndentCharsPatterns   = language.AutoIndentCharsPatterns;
            
            range.ClearStyle(language.GetStyles());

            foreach (var rule in language.Rules)
                range.SetStyle(rule.Style, rule.Regex);
            
            range.ClearFoldingMarkers();

            foreach (var marker in language.FoldingMarkers)
                range.SetFoldingMarkers(marker.StartMarker, marker.EndMarker, marker.RegexOption);
        }

        /// <summary>
        /// Highlights syntax for given XML description file
        /// </summary>
        public virtual void HighlightSyntax(string xmlDdescriptionFile, Range range)
        {
            var customxmlParser  = new XmlDocParser(xmlDdescriptionFile);
            var xmlDoc           = customxmlParser.LoadSyntaxFile();
            var syntaxDescriptor = customxmlParser.ConvertXmlDocumet(xmlDoc);

            HighlightSyntax(syntaxDescriptor, range);
        }
        
        public void HighlightSyntax(SyntaxDescriptor desc, Range range)
        {
            range.tb.ClearStylesBuffer();
            
            int l = desc.styles.Count;
            for (int i = 0; i < resilientStyles.Count; i++)
                range.tb.Styles[l + i] = resilientStyles[i];

            char[] oldBrackets = RememberBrackets(range.tb);

            range.tb.Language.LeftBracket = desc.LeftBracket;
            range.tb.Language.RightBracket = desc.RightBracket;
            range.tb.Language.LeftBracket2 = desc.LeftBracket2;
            range.tb.Language.RightBracket2 = desc.RightBracket2;

            range.ClearStyle(desc.styles.ToArray());

            foreach (RuleDesc rule in desc.rules)
                range.SetStyle(rule.style, rule.Regex);

            range.ClearFoldingMarkers();

            foreach (FoldingDesc folding in desc.foldings)
                range.SetFoldingMarkers(folding.startMarkerRegex, folding.finishMarkerRegex, folding.options);

            RestoreBrackets(range.tb, oldBrackets);
        }

        public virtual void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            var tb = (sender as FastColoredTextBox);
            
            tb.Language.AutoIndentNeeded(args);
        }

        /// <summary>
        /// Adds the given <paramref name="style"/> as resilient style. A resilient style is additionally available when highlighting is 
        /// based on a syntax descriptor that has been derived from a XML description file. In the run of the highlighting routine 
        /// the styles used by the FCTB are always dropped and replaced with the (initial) ones from the syntax descriptor. Resilient styles are 
        /// added afterwards and can be used anyway. 
        /// </summary>
        /// <param name="style">Style to add</param>
        public virtual void AddResilientStyle(Style style)
        {
            if (resilientStyles.Contains(style)) return;
            currentTb.CheckStylesBufferSize(); // Prevent buffer overflow
            resilientStyles.Add(style);
        }

        protected void RestoreBrackets(FastColoredTextBox tb, char[] oldBrackets)
        {
            tb.Language.LeftBracket   = oldBrackets[0];
            tb.Language.RightBracket  = oldBrackets[1];
            tb.Language.LeftBracket2  = oldBrackets[2];
            tb.Language.RightBracket2 = oldBrackets[3];
        }

        protected char[] RememberBrackets(FastColoredTextBox tb)
        {
            return new[]
            {
                tb.Language.LeftBracket,
                tb.Language.RightBracket,
                tb.Language.LeftBracket2,
                tb.Language.RightBracket2
            };
        }

        public void InitStyleSchema(Language lang)
        {
            //switch (lang)
            //{
            //    case Language.CSharp:
            //        StringStyle = BrownStyle;
            //        CommentStyle = GreenStyle;
            //        NumberStyle = MagentaStyle;
            //        AttributeStyle = GreenStyle;
            //        ClassNameStyle = BoldStyle;
            //        KeywordStyle = BlueStyle;
            //        CommentTagStyle = GrayStyle;
            //        break;
            //    case Language.VB:
            //        StringStyle = BrownStyle;
            //        CommentStyle = GreenStyle;
            //        NumberStyle = MagentaStyle;
            //        ClassNameStyle = BoldStyle;
            //        KeywordStyle = BlueStyle;
            //        break;
            //    case Language.HTML:
            //        CommentStyle = GreenStyle;
            //        TagBracketStyle = BlueStyle;
            //        TagNameStyle = MaroonStyle;
            //        AttributeStyle = RedStyle;
            //        AttributeValueStyle = BlueStyle;
            //        HtmlEntityStyle = RedStyle;
            //        break;
            //    case Language.XML:
            //        CommentStyle = GreenStyle;
            //        XmlTagBracketStyle = BlueStyle;
            //        XmlTagNameStyle = MaroonStyle;
            //        XmlAttributeStyle = RedStyle;
            //        XmlAttributeValueStyle = BlueStyle;
            //        XmlEntityStyle = RedStyle;
            //        XmlCDataStyle = BlackStyle;
            //        break;
            //    case Language.JS:
            //        StringStyle = BrownStyle;
            //        CommentStyle = GreenStyle;
            //        NumberStyle = MagentaStyle;
            //        KeywordStyle = BlueStyle;
            //        break;
            //    case Language.PHP:
            //        StringStyle = RedStyle;
            //        CommentStyle = GreenStyle;
            //        NumberStyle = RedStyle;
            //        VariableStyle = MaroonStyle;
            //        KeywordStyle = MagentaStyle;
            //        KeywordStyle2 = BlueStyle;
            //        KeywordStyle3 = GrayStyle;
            //        break;
            //    case Language.SQL:
            //        StringStyle = RedStyle;
            //        CommentStyle = GreenStyle;
            //        NumberStyle = MagentaStyle;
            //        KeywordStyle = BlueBoldStyle;
            //        StatementsStyle = BlueBoldStyle;
            //        FunctionsStyle = MaroonStyle;
            //        VariableStyle = MaroonStyle;
            //        TypesStyle = BrownStyle;
            //        break;
            //}
        }
    }

    /// <summary>
    /// Language
    /// </summary>
    public enum Language
    {
        Custom,
        CSharp,
        VB,
        HTML,
        XML,
        SQL,
        PHP,
        JS,
        Lua
    }
}