using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class Sandbox : Form
    {
        private List<Style> styles = new List<Style>();

        public Sandbox()
        {
            InitializeComponent();

            var rnd = new Random();
            for (int i = 0; i < 32; i++)
                styles.Add(new TextStyle(new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255))), null, FontStyle.Regular));

            var fctb = new FastColoredTextBox() { Parent = this, Dock = DockStyle.Fill };
            fctb.TextChanged += fctb_TextChanged;
            fctb.Text = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 19 20 21 22 23 24 25 26 27 28 29 30 31";
        }

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(StyleIndex.All);

            for (int i = 0; i < styles.Count; i++)
                e.ChangedRange.SetStyle(styles[i], @"\b" + i + @"\b");
        }
    }
}