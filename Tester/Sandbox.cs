using System;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class Sandbox : Form
    {
        private FastColoredTextBox fctb;

        public Sandbox()
        {
            InitializeComponent();

            fctb = new FastColoredTextBox() { Dock = DockStyle.Fill, Parent = this};
            var menu = new AutocompleteMenu(fctb);
            var item = new MethodAutocompleteItem("ToString");
            menu.Items.SetAutocompleteItems(new AutocompleteItem[]{item});
        }
    }
}