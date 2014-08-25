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
        private Style strikeStyle = new StrikeoutStyle(255, Color.Black);

        public Sandbox()
        {
            InitializeComponent();

            var fctb = new FastColoredTextBox() { Dock = DockStyle.Fill, Parent = this, Language = Language.XML};
            fctb.Text = @"<bla bla> bla bla</bla>
<bla bla> bla bla</bla>
<bla bla> bla bla</bla>
";
            fctb.GetRange(new Place(0, 1), new Place(0, 2)).SetStyle(strikeStyle);
        }
    }

    public class StrikeoutStyle : Style
    {
        private Pen Pen { get; set; }

        public StrikeoutStyle(int alpha, Color color)
        {
            Pen = new Pen(Color.FromArgb(alpha, color));
        }

        public override void Draw(Graphics gr, Point pos, Range range)
        {
            var size = GetSizeOfRange(range);
            var start = new Point(pos.X, pos.Y + size.Height - 1);
            var end = new Point(pos.X + size.Width, pos.Y + size.Height - 1);
            gr.DrawLine(Pen, start, end);
        }

        public override void Dispose()
        {
            base.Dispose();

            if (Pen != null)
                Pen.Dispose();
        }
    }
}