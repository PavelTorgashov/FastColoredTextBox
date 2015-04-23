using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class ReadOnlyBlocksSample : Form
    {
        public ReadOnlyBlocksSample()
        {
            InitializeComponent();

            //set all <tag> as readonly
            //we need to do it only once, because in future the user will not to be able to change these blocks
            fctb.Range.SetStyle(new ReadOnlyStyle(), @"</?\w+[^>]*>");
        }

        private void fctb_KeyPressing(object sender, KeyPressEventArgs e)
        {
            if (fctb.Selection.IsEmpty && fctb.Selection.ReadOnly && fctb.Selection.CharBeforeStart == '>' && fctb.Selection.CharAfterStart == '<')
            if (e.KeyChar != '\b')
            {
                //Hey, user completely removed whole tag body and now he cannot insert any text here
                //so, we help him...
                fctb.InsertText(e.KeyChar.ToString());
                e.Handled = true;
            }
        }
    }
}
