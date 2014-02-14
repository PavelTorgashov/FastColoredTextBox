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
        public Sandbox()
        {
            InitializeComponent();

            var fctb = new FastColoredTextBox(){Parent = this, Language = Language.CSharp, Dock = DockStyle.Fill};
        }
    }

}