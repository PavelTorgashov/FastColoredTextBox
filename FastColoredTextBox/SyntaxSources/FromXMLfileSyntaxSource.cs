using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace FastColoredTextBoxNS.SyntaxSources
{
    class FromXMLfileSyntaxSource : SyntaxHighlighter
    {
        protected string XMLfile;
        public FromXMLfileSyntaxSource(FastColoredTextBox textbox) : base(textbox)
        {
            XMLfile = textbox.DescriptionFile;
            LoadStyleSchema();
        }
        public override void Init()
        {
            LoadStyleSchema();
        }
        public void LoadStyleSchema()
        {
            var doc = new XmlDocument();
            if (!File.Exists(XMLfile))
                XMLfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(XMLfile));

            doc.LoadXml(File.ReadAllText(XMLfile));

            //Load Brakets
            XmlNode brackets = doc.SelectSingleNode("doc/brackets");
            if (brackets != null)
            {
                if (brackets.Attributes["left"] == null || brackets.Attributes["right"] == null ||
                    brackets.Attributes["left"].Value == "" || brackets.Attributes["right"].Value == "")
                {
                    Textbox.LeftBracket = '\x0';
                    Textbox.RightBracket = '\x0';
                }
                else
                {
                    Textbox.LeftBracket = brackets.Attributes["left"].Value[0];
                    Textbox.RightBracket = brackets.Attributes["right"].Value[0];
                }

                if (brackets.Attributes["left2"] == null || brackets.Attributes["right2"] == null ||
                    brackets.Attributes["left2"].Value == "" || brackets.Attributes["right2"].Value == "")
                {
                    Textbox.LeftBracket2 = '\x0';
                    Textbox.RightBracket2 = '\x0';
                }
                else
                {
                    Textbox.LeftBracket2 = brackets.Attributes["left2"].Value[0];
                    Textbox.RightBracket2 = brackets.Attributes["right2"].Value[0];
                }

                if (brackets.Attributes["strategy"] == null || brackets.Attributes["strategy"].Value == "")
                    Textbox.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
                else
                    Textbox.BracketsHighlightStrategy = (BracketsHighlightStrategy)Enum.Parse(typeof(BracketsHighlightStrategy), brackets.Attributes["strategy"].Value);
            }

            //Load MainStyles
            foreach (XmlNode rule in doc.SelectNodes("doc/rule"))
            {
                string name = rule.Attributes["style"].Value;
                Style st = null;
                foreach (XmlNode style in doc.SelectNodes("doc/style"))
                {
                    if (style.Attributes["name"].Value == name)
                    {
                        st = ParseStyle(style);
                        break;
                    }
                }
                if (!StyleSchema.Contains(name))
                {
                    StyleSchema.Add(name, st, ParseRule(rule));
                }
            }

            //Load FoldingRules
            foreach (XmlNode frule in doc.SelectNodes("doc/folding"))
            {
                FoldingSchema.Add(ParseFolding(frule));
            }

        }
        protected FoldingDescription ParseFolding(XmlNode foldingNode)
        {
            FoldingDescription folding = new FoldingDescription();
            folding.startMarkerRegex = foldingNode.Attributes["start"].Value;
            folding.endMarkerRegex = foldingNode.Attributes["finish"].Value;
            XmlAttribute optionsA = foldingNode.Attributes["options"];
            if (optionsA != null)
                folding.options = RegexCompiledOption|(RegexOptions)Enum.Parse(typeof(RegexOptions), optionsA.Value);

            return folding;
        }
        protected Regex ParseRule (XmlNode ruleNode)
        {
            string pattern = ruleNode.InnerText;
            XmlAttribute optionsA = ruleNode.Attributes["options"];
            RegexOptions options = RegexCompiledOption;
            if (optionsA != null)
                options = options|(RegexOptions)Enum.Parse(typeof(RegexOptions), optionsA.Value);
            return new Regex(pattern, options);
        }
        protected Style ParseStyle(XmlNode styleNode)
        {
            XmlAttribute typeA = styleNode.Attributes["type"];
            XmlAttribute colorA = styleNode.Attributes["color"];
            XmlAttribute backColorA = styleNode.Attributes["backColor"];
            XmlAttribute fontStyleA = styleNode.Attributes["fontStyle"];
            XmlAttribute nameA = styleNode.Attributes["name"];
            //colors
            SolidBrush foreBrush = null;
            if (colorA != null)
                foreBrush = new SolidBrush(ParseColor(colorA.Value));
            SolidBrush backBrush = null;
            if (backColorA != null)
                backBrush = new SolidBrush(ParseColor(backColorA.Value));
            //fontStyle
            FontStyle fontStyle = FontStyle.Regular;
            if (fontStyleA != null)
                fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), fontStyleA.Value);

            return new TextStyle(foreBrush, backBrush, fontStyle);
        }
        protected Color ParseColor(string s)
        {
            if (s.StartsWith("#"))
            {
                if (s.Length <= 7)
                    return Color.FromArgb(255,
                                          Color.FromArgb(Int32.Parse(s.Substring(1), NumberStyles.AllowHexSpecifier)));
                else
                    return Color.FromArgb(Int32.Parse(s.Substring(1), NumberStyles.AllowHexSpecifier));
            }
            else
                return Color.FromName(s);
        }
    }
}
