using System;
using System.Windows.Forms;

namespace FastColoredTextBoxNS
{
    public partial class GoToForm : Form
    {
        public int SelectedLineNumber { get; set; }
        public int TotalLineCount { get; set; }

        public GoToForm()
        {
            InitializeComponent();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.label.Text = String.Format("Line number (1 - {0}):", this.TotalLineCount);
            this.textBox.DataBindings.Add("Text", this, "SelectedLineNumber", true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
