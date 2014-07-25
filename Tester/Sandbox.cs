using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Linq;

namespace Tester
{
    public partial class Sandbox : Form
    {
        public Sandbox()
        {
            InitializeComponent();

            var fctb = new FastColoredTextBox() { Dock = DockStyle.Fill, Parent = this, Language = Language.CSharp, BackColor = Color.Black, ForeColor = Color.White, WordWrap = true };
            fctb.SelectionStyle = new SelectionStyle(Brushes.Silver, Brushes.Black);
            fctb.Text = @" snippetText like - {0:public} class {1:MyClass} { {2} }
 0, 1 and 2 are tabstops. should I escape the opening and closing brackets of the class ?
";
        }
    }
}