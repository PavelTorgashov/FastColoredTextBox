using System;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class Sandbox : Form
    {
        private FastColoredTextBox fctb;
        TextStyle brownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
        TextStyle blueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);

        public Sandbox()
        {
            InitializeComponent();

            fctb = new FastColoredTextBox() { Dock = DockStyle.Fill, Parent = this, Language = Language.XML };
            fctb.TextChanged += new EventHandler<TextChangedEventArgs>(fctb_TextChanged);
            fctb.Text = @"For example: ""This is a Text between the chr(34)"". 
 writing forward the for is blue
";
        }

        void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            //clear previous highlighting
            e.ChangedRange.ClearStyle(brownStyle, blueStyle);
            //
            e.ChangedRange.SetStyle(blueStyle, @"\bfor\b");
            e.ChangedRange.SetStyle(brownStyle, @"""[^""]*""");
        }
    }
}