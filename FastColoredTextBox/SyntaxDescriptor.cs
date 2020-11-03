using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace FastColoredTextBoxNS
{
  public class SyntaxDescriptor : IDisposable
  {
    public readonly List<FoldingDesc> foldings = new List<FoldingDesc>();
    public readonly List<RuleDesc> rules = new List<RuleDesc>();
    public readonly List<Style> styles = new List<Style>();
    public BracketsHighlightStrategy bracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
    public char leftBracket = '(';
    public char leftBracket2 = '{';
    public char rightBracket = ')';
    public char rightBracket2 = '}';

    public void Dispose()
    {
      foreach (var style in styles)
        style.Dispose();
    }
  }

  public class RuleDesc
  {
    public RegexOptions options = RegexOptions.None;
    public string pattern;
    Regex regex;
    public Style style;

    public Regex Regex
    {
      get
      {
        if (regex == null)
        {
          regex = new Regex(pattern, SyntaxHighlighter.RegexCompiledOption | options);
        }

        return regex;
      }
    }
  }

  public class FoldingDesc
  {
    public string finishMarkerRegex;
    public RegexOptions options = RegexOptions.None;
    public string startMarkerRegex;
  }
}