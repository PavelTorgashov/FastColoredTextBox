using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = new Range(fctb, 2);
            fctb.SelectedText = "new line value";
        }

        private ColorStyle colorStyle = new ColorStyle(Brushes.Black, Brushes.White, FontStyle.Regular);

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.SetStyle(colorStyle, @"Color\.\w+");
        }
    }

    class ColorStyle : TextStyle
    {
        public ColorStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle) : base(foreBrush, backgroundBrush, fontStyle)
        {
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            //get color name
            var parts = range.Text.Split('.');
            var colorName = parts[parts.Length - 1];
            var color = Color.FromName(colorName);
            (BackgroundBrush as SolidBrush).Color = color;
            base.Draw(gr, position, range);
        }
    }

    class MyFCTB : FastColoredTextBox
    {
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //to prevent drag&drop inside FCTB
            typeof(FastColoredTextBox).GetField("mouseIsDragDrop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, false);
            base.OnMouseMove(e);
        }
    }
}