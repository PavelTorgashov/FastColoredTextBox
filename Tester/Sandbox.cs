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
        TextStyle style1 = new TextStyle(Brushes.Red, null, System.Drawing.FontStyle.Regular);
        TextStyle style2 = new TextStyle(Brushes.Green, null, System.Drawing.FontStyle.Regular);

        public Sandbox()
        {
            InitializeComponent();

            var fctb = new FastColoredTextBox(){Dock = DockStyle.Fill, Parent = this};
            fctb.TextChangedDelayed += new EventHandler<TextChangedEventArgs>(fctb_TextChangedDelayed);
            fctb.Text = "[TestApp] This is line one";
        }

        void fctb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(StyleIndex.All);
            e.ChangedRange.SetStyle(style2, @"\[\w+\]");
            e.ChangedRange.SetStyle(style1, @".*");
        }
    }
}