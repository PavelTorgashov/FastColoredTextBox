using System;
using System.Collections.Generic;
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
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = @"1234567890
1234567890
1234567890
1234567890

1234567890
1234567890

1234567890
1234567890

1234567890
1234567890

";
            fastColoredTextBox1.WordWrap = true;
        }
    }
}