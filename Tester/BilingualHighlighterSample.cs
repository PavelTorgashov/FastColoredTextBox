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
using FastColoredTextBoxNS.Models.Syntaxes;

namespace Tester
{
    public partial class BilingualHighlighterSample : Form
    {
        public BilingualHighlighterSample()
        {
            InitializeComponent();
        }

        private void tb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            throw new Exception("Uncomment this section");
            //var tb = (FastColoredTextBox) sender;

            //tb.SyntaxHighlighter.HighlightSyntax(new HtmlSyntax(), tb.Range);

            //tb.Range.ClearFoldingMarkers();

            ////find PHP fragments
            //foreach(var r in tb.GetRanges(@"<\?php.*?\?>", RegexOptions.Singleline))
            //{
            //    r.ClearStyle(StyleIndex.All);

            //    tb.SyntaxHighlighter.HighlightSyntax(new PHPSyntax(), r);
            //}
        }
    }
}
