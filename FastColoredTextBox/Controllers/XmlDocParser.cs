using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace FastColoredTextBoxNS.Controllers
{
    public class XmlDocParser : IXmlDocParser
    {
        public string FilePath { get; private set; }
        public Dictionary<string, SyntaxDescriptor> DescByXMLfileNames { get; private set; }



        public XmlDocParser(string filePath)
        {
            FilePath = filePath;

            DescByXMLfileNames = new Dictionary<string, SyntaxDescriptor>();
        }



        public SyntaxDescriptor ConvertXmlDocumet(XmlDocument xmlDocument)
        {
            var desc = new SyntaxDescriptor();
            var brackets = xmlDocument.SelectSingleNode("doc/brackets");

            if (brackets != null)
            {
                if (brackets.Attributes["left"] == null || brackets.Attributes["right"] == null ||
                    brackets.Attributes["left"].Value == "" || brackets.Attributes["right"].Value == "")
                {
                    desc.LeftBracket = '\x0';
                    desc.RightBracket = '\x0';
                }
                else
                {
                    desc.LeftBracket = brackets.Attributes["left"].Value[0];
                    desc.RightBracket = brackets.Attributes["right"].Value[0];
                }

                if (brackets.Attributes["left2"] == null || brackets.Attributes["right2"] == null ||
                    brackets.Attributes["left2"].Value == "" || brackets.Attributes["right2"].Value == "")
                {
                    desc.LeftBracket2 = '\x0';
                    desc.RightBracket = '\x0';
                }
                else
                {
                    desc.LeftBracket2 = brackets.Attributes["left2"].Value[0];
                    desc.RightBracket = brackets.Attributes["right2"].Value[0];
                }

                if (brackets.Attributes["strategy"] == null || brackets.Attributes["strategy"].Value == "")
                    desc.bracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
                else
                    desc.bracketsHighlightStrategy = (BracketsHighlightStrategy)Enum.Parse(typeof(BracketsHighlightStrategy), brackets.Attributes["strategy"].Value);
            }

            var styleByName = new Dictionary<string, Style>();

            foreach (XmlNode style in xmlDocument.SelectNodes("doc/style"))
            {
                Style s = ParseStyle(style);
                styleByName[style.Attributes["name"].Value] = s;
                desc.styles.Add(s);
            }
            foreach (XmlNode rule in xmlDocument.SelectNodes("doc/rule"))
                desc.rules.Add(ParseRule(rule, styleByName));
            foreach (XmlNode folding in xmlDocument.SelectNodes("doc/folding"))
                desc.foldings.Add(ParseFolding(folding));

            return desc;
        }

        public XmlDocument LoadSyntaxFile()
        {
            return LoadSyntaxFile(FilePath);
        }

        public XmlDocument LoadSyntaxFile(string file)
        {
            SyntaxDescriptor desc = null;
            var doc = new XmlDocument();

            if (!DescByXMLfileNames.TryGetValue(file, out desc))
            {
                if (!File.Exists(file))
                    file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(file));

                doc.LoadXml(File.ReadAllText(file));

                AddXmlDescription(file, doc);
            }

            return doc;
        }

        public Color ParseColor(string colorName)
        {
            if (colorName.StartsWith("#"))
            {
                if (colorName.Length <= 7)
                    return Color.FromArgb(255,
                                          Color.FromArgb(Int32.Parse(colorName.Substring(1), NumberStyles.AllowHexSpecifier)));
                else
                    return Color.FromArgb(Int32.Parse(colorName.Substring(1), NumberStyles.AllowHexSpecifier));
            }
            else
                return Color.FromName(colorName);
        }

        public FoldingDesc ParseFolding(XmlNode foldingNode)
        {
            var folding = new FoldingDesc
            {
                startMarkerRegex = foldingNode.Attributes["start"].Value,
                finishMarkerRegex = foldingNode.Attributes["finish"].Value
            };

            var optionsA = foldingNode.Attributes["options"];

            if (optionsA != null)
                folding.options = (RegexOptions)Enum.Parse(typeof(RegexOptions), optionsA.Value);

            return folding;
        }

        public RuleDesc ParseRule(XmlNode ruleNode, Dictionary<string, Style> styles)
        {
            var rule = new RuleDesc
            {
                pattern = ruleNode.InnerText
            };

            var   styleA = ruleNode.Attributes["style"];
            var optionsA = ruleNode.Attributes["options"];

            if (styleA == null)
                throw new Exception("Rule must contain style name.");

            if (!styles.ContainsKey(styleA.Value))
                throw new Exception("Style '" + styleA.Value + "' is not found.");

            rule.style = styles[styleA.Value];

            if (optionsA != null)
                rule.options = (RegexOptions)Enum.Parse(typeof(RegexOptions), optionsA.Value);

            return rule;
        }

        public Style ParseStyle(XmlNode styleNode)
        {
            var typeA      = styleNode.Attributes["type"];
            var colorA     = styleNode.Attributes["color"];
            var backColorA = styleNode.Attributes["backColor"];
            var fontStyleA = styleNode.Attributes["fontStyle"];
            var nameA      = styleNode.Attributes["name"];

            SolidBrush foreBrush = null;

            if (colorA != null)
                foreBrush = new SolidBrush(ParseColor(colorA.Value));

            SolidBrush backBrush = null;

            if (backColorA != null)
                backBrush = new SolidBrush(ParseColor(backColorA.Value));

            var fontStyle = FontStyle.Regular;

            if (fontStyleA != null)
                fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), fontStyleA.Value);

            return new TextStyle(foreBrush, backBrush, fontStyle);
        }

        /// <summary>
        /// Uses the given <paramref name="doc"/> to parse a XML description and adds it as syntax descriptor. 
        /// The syntax descriptor is used for highlighting when 
        /// <list type="bullet">
        ///     <item>Language property of FCTB is set to <see cref="Language.Custom"/></item>
        ///     <item>DescriptionFile property of FCTB has the same value as the method parameter <paramref name="descriptionFileName"/></item>
        /// </list>
        /// </summary>
        /// <param name="descriptionFileName">Name of the description file</param>
        /// <param name="doc">XmlDocument to parse</param>
        public void AddXmlDescription(string descriptionFileName, XmlDocument doc)
        {
            var syntaxDescriptor = ConvertXmlDocumet(doc);

            DescByXMLfileNames[descriptionFileName] = syntaxDescriptor;
        }
    }
}
