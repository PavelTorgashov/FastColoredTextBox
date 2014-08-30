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
            fctb.Text = @"For example: ""This is a Text between the chr(34)"". 
 writing forward the for is blue
";

            fctb.SelectionStyle = new SelectionStyle(Brushes.Red, Brushes.White);

            fctb.KeyPressing += new KeyPressEventHandler(fctb_KeyPressing);
        }

        void fctb_KeyPressing(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //Enter Key
            {
                e.Handled = true;
                fctb.InsertText(Environment.NewLine);
                fctb.DoAutoIndentIfNeed();
            }
            else
            {
                e.Handled = true;
                /*
                if (fctb.GetStyleIndex(_lastDictatedStyle) >= 0)
                    fctb.Range.ClearStyle(_lastDictatedStyle);*/

                fctb.InsertText(e.KeyChar.ToString(), fctb.SyntaxHighlighter.BlueStyle, true);
            }
        }
    }
}