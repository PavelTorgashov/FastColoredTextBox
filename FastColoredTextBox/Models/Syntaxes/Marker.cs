using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class Marker
    {
        public string       StartMarker { get; private set; }
        public string       EndMarker   { get; private set; }
        public RegexOptions RegexOption { get; private set; }



        public Marker(string startMarker, string endMarker)
            : this (startMarker, endMarker, SyntaxHighlighter.RegexCompiledOption)
        { }

        public Marker(string startMarker, string endMarker, RegexOptions regexOptions)
        {
            StartMarker = startMarker;
            EndMarker   = endMarker;
            RegexOption = regexOptions;
        }
    }
}