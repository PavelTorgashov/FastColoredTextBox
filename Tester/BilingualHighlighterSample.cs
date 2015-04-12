using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using FastColoredTextBoxNS.Highlighter;

namespace Tester
{
    public partial class BilingualHighlighterSample : Form
    {
        private SyntaxHighlighter m_HtmlHighlighter;
        private SyntaxHighlighter m_PhpHighlighter;
        public BilingualHighlighterSample()
        {
            InitializeComponent();
            this.m_HtmlHighlighter = new HtmlSyntaxHighlighter();
            this.m_PhpHighlighter = new PHPSyntaxHighlighter();
        }

        private void tb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            var tb = (FastColoredTextBox) sender;
            
            //highlight html
            tb.SyntaxHighlighter = this.m_HtmlHighlighter;
            tb.SyntaxHighlighter.HighlightSyntax(tb.Range);
            //find PHP fragments
            foreach(var r in tb.GetRanges(@"<\?php.*?\?>", RegexOptions.Singleline))
            {
                //remove HTML highlighting from this fragment
                r.ClearStyle(StyleIndex.All);
                //do PHP highlighting
                tb.SyntaxHighlighter = this.m_PhpHighlighter;
                tb.SyntaxHighlighter.HighlightSyntax(r);
            }
        }
    }
}
