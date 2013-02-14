using System;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class HintSample : Form
    {
        public HintSample()
        {
            InitializeComponent();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fctb.Hints.Clear();
            foreach (var r in fctb.GetRanges(tbFind.Text))
            {
                Hint hint;
                if(cbSimple.Checked)
                    hint = new Hint(r, "This is hint " + fctb.Hints.Count, cbInline.Checked, cbDock.Checked);
                else
                    hint = new Hint(r, new CustomHint(), cbInline.Checked, cbDock.Checked);

                fctb.Hints.Add(hint);
            }
        }

        private void fctb_HintClick(object sender, HintClickEventArgs e)
        {
            MessageBox.Show("You click on the hint");
        }
    }
}
