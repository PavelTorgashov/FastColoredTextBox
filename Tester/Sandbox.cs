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
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sett = new PrintDialogSettings();
            fastColoredTextBox1.Print(sett);
        }

        private Style s1 = new TextStyle(Brushes.Green, Brushes.LightGreen, FontStyle.Regular);
        private Style s2 = new TextStyle(Brushes.Red, Brushes.RosyBrown, FontStyle.Regular);

        private Style ms1 = new MarkerStyle(Brushes.Green);
        private Style ms2 = new MarkerStyle(new SolidBrush(Color.FromArgb(100, Color.Red)));

        private void fastColoredTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(StyleIndex.All);
            e.ChangedRange.SetStyle(s1, @"M\d+");
            e.ChangedRange.SetStyle(s2, @"M\d+");

            //e.ChangedRange.SetStyle(ms1, @"M\d+");
            e.ChangedRange.SetStyle(ms2, @"M\d+");
        }
    }
}