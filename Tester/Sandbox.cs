using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class Sandbox : Form
    {
        private FastColoredTextBox fctb;

        public Sandbox()
        {
            InitializeComponent();

            fctb = new FastColoredTextBox() { Dock = DockStyle.Fill, Parent = this, Language = Language.XML, HighlightingRangeType = HighlightingRangeType.AllTextRange, ShowFoldingLines = true};
        }
    }
}