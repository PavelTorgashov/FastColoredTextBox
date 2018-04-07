using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace FastColoredTextBoxNS.Controllers
{
    interface IXmlDocParser
    {
        string FilePath { get; }

        Dictionary<string, SyntaxDescriptor> DescByXMLfileNames { get; }



        XmlDocument LoadSyntaxFile(string file);

        SyntaxDescriptor ConvertXmlDocumet(XmlDocument xmlDocument);

        FoldingDesc ParseFolding(XmlNode foldingNode);

        RuleDesc ParseRule(XmlNode ruleNode, Dictionary<string, Style> styles);

        Style ParseStyle(XmlNode styleNode);

        Color ParseColor(string colorName);

        void AddXmlDescription(string descriptionFileName, XmlDocument doc);
    }
}
