using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS.SyntaxSources;

namespace FastColoredTextBoxNS
{
    public abstract class SyntaxHighlighter : IDisposable
    {
        public static SyntaxHighlighter CreateSyntaxHighlighter(FastColoredTextBox textbox, Language language)
        {
            switch (language)
            {
                case Language.AVRASM: return new AvrasmSyntaxSource(textbox);
                case Language.JS: return new JScriptSyntaxSource(textbox);
                case Language.JSON: return new JSONSyntaxSource(textbox);
                case Language.Lua: return new LuaSyntaxSources(textbox);
                case Language.SQL: return new SQLSyntaxSource(textbox);
                case Language.VB: return new VBSyntaxSource(textbox);
                case Language.XML: return new XMLSyntaxSource(textbox);
                case Language.CSharp: return new CSharpSyntaxSource(textbox);
                case Language.HTML: return new HTMLSyntaxSource(textbox);
                case Language.PHP: return new PHPSyntaxSource(textbox);
                case Language.FromXMLfile: return new FromXMLfileSyntaxSource(textbox);
                case Language.Custom:
                default: return new CustomSyntaxSource(textbox);
            }
        }

        public static class PredefinedStyles
        {
            public static readonly Style BlueBoldStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
            public static readonly Style BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
            public static readonly Style BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
            public static readonly Style BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
            public static readonly Style GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
            public static readonly Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
            public static readonly Style MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
            public static readonly Style MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
            public static readonly Style RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
            public static readonly Style BlackStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
            public static readonly Style DarkGreenBoldStyle = new TextStyle(Brushes.DarkGreen, null, FontStyle.Bold);
        }

        public StyleDescriptionList StyleSchema = new StyleDescriptionList();
        protected List<FoldingDescription> FoldingSchema = new List<FoldingDescription>();
        protected FastColoredTextBox Textbox;

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

        protected SyntaxHighlighter(FastColoredTextBox textbox)
        {
            Textbox = textbox;
        }

        public void AddStyle(string styleName, Style style, Regex rule)
        {
            StyleSchema.Add(styleName, style, rule);
        }
        public void RemoveStyle (string styleName)
        {
            StyleSchema.Remove(styleName);
        }
        public void AddFoldingRule(string startMarkerRule, string endMarkerRule, RegexOptions options = RegexOptions.None)
        {
            FoldingDescription desc = new FoldingDescription();
            desc.startMarkerRegex = startMarkerRule;
            desc.endMarkerRegex = endMarkerRule;
            desc.options = options;
            FoldingSchema.Add(desc);
        }
        public virtual void SyntaxHighlight(Range range)
        {
            //clear style of changed range
            range.ClearStyle(StyleSchema.Styles);
            //
            //string highlighting
            foreach (var styleInfo in StyleSchema)
                range.SetStyle(styleInfo.Style, styleInfo.Rule);
            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            foreach (var foldRule in FoldingSchema)
                range.SetFoldingMarkers(foldRule.startMarkerRegex, foldRule.endMarkerRegex, foldRule.options);
        }
        public virtual void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {

        }
        public abstract void Init();
        public virtual void Dispose()
        {
            if (StyleSchema != null) StyleSchema.Dispose();
        }
    }


    /// <summary>
    /// Style and associated Regex Combinations
    /// </summary>
    public class StyleDescriptionList : ICollection<StyleDescription>, IDisposable
    {
        private List<string> names = new List<string>();
        private List<Style> styles = new List<Style>();
        private List<Regex> regexs = new List<Regex>();

        public bool IsReadOnly { get { return false; } }
        public int Count { get { return names.Count; } }

        public void Add(string name, Style style, Regex regex)
        {
            if (!names.Contains(name))
            {
                names.Add(name);
                styles.Add(style);
                regexs.Add(regex);
            }
            else
                throw new ArgumentException("List contained style with name " + name);
        }
        public void Add(StyleDescription style)
        {
            Add(style.Name, style.Style, style.Rule);
        }
        public bool Remove(string name)
        {
            if (names.Contains(name))
            {
                int index = names.IndexOf(name);
                names.RemoveAt(index);
                styles.RemoveAt(index);
                regexs.RemoveAt(index);
                return true;
            }
            else
                return false;
        }

        public bool Remove(StyleDescription style)
        {
            return Remove(style.Name);
        }

        public void Clear()
        {
            names.Clear();
            styles.Clear();
            regexs.Clear();
        }
        public bool Contains (StyleDescription style)
        {
            return names.Contains(style.Name);
        }
        public bool Contains(string styleName)
        {
            return names.Contains(styleName);
        }
        public void CopyTo(StyleDescription[] styles, int index)
        {
            for (int i = 0; i < names.Count; ++i)
                styles[index + i] = this[i];
        }
        public StyleDescription this[int i]
        {
            get
            {
                return new StyleDescription(names[i], styles[i], regexs[i]);
            }
            
        }
        public StyleDescription this[string name]
        {
            get
            {
                int i = names.IndexOf(name);
                if (i >= 0 && i < names.Count)
                    return this[i];
                else
                    throw new ArgumentOutOfRangeException("StyleDescriptionList not contained style with name \"" + name + "\"");
            }
        }
        public void ChangeStyle(string styleName, Style newStyle)
        {
            int index = names.IndexOf(styleName);
            ChangeStyle(index, newStyle);
        }
        public void ChangeStyle(int index, Style newStyle)
        {
            styles[index] = newStyle;
        }
        public Style[] Styles
        {
            get
            {
                return styles.ToArray();
            }
        }
        public IEnumerator<StyleDescription> GetEnumerator()
        {
            for (int i = 0; i < names.Count; ++i)
                yield return this[i];
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            if (styles.Count != 0)
            {
                foreach (var st in Styles) st.Dispose();
            }
        }
    }

    /// <summary>
    /// Contained Name, Style information and Regex of Style;
    /// </summary>
    public struct StyleDescription
    {
        public readonly string Name;
        public readonly Style Style;
        public readonly Regex Rule;
        public StyleDescription(string name, Style style, Regex regex)
        {
            Name = name;
            Style = style;
            Rule = regex;
        }
    }

    public struct FoldingDescription
    {
        public string startMarkerRegex;
        public string endMarkerRegex;
        public RegexOptions options;
    }

    /// <summary>
    /// Language
    /// </summary>
    public enum Language
    {
        Custom,
        FromXMLfile,
        CSharp,
        VB,
        HTML,
        XML,
        SQL,
        PHP,
        JS,
        Lua,
        JSON,
        AVRASM
    }
}
