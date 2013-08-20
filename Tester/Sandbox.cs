using System;
using System.Collections.Generic;
using System.Drawing;
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

        private void fctb_AutoIndentNeeded(object sender, AutoIndentEventArgs e)
        {
            if (Regex.IsMatch(e.PrevLineText, @"^\s*For\(.*\)"))
            {
                e.Shift = e.Shift + e.TabLength;
                e.ShiftNextLines = e.ShiftNextLines + e.TabLength;
                return;
            }
            if (Regex.IsMatch(e.PrevLineText, @"^\s*If\(.*\)"))
            {
                e.Shift = e.Shift + e.TabLength;
                e.ShiftNextLines = e.ShiftNextLines + e.TabLength;
                return;
            }
            if (Regex.IsMatch(e.LineText, @"###"))
            {
                e.Shift = e.Shift - e.TabLength;
                e.ShiftNextLines = e.ShiftNextLines - e.TabLength;
                return;
            }
            if (Regex.IsMatch(e.LineText, @"\$\$\$"))
            {
                e.Shift = e.Shift - e.TabLength;
                e.ShiftNextLines = e.ShiftNextLines - e.TabLength;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fctb.Visible = false;
            var bmp = new Bitmap(fctb.Width,fctb.Height);
            fctb.DrawToBitmap(bmp, new Rectangle(0, 0, fctb.Width, fctb.Height));
            bmp.Save("c:\\temp.png");
        }
    }
}
