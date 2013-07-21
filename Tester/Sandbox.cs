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

        private void button1_Click(object sender, EventArgs e)
        {
            var bmp = new Bitmap(fctb.Width, fctb.Height);
            fctb.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save("c:\\temp.png");
        }
    }
}
