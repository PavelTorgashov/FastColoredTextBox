using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PowerfulSample().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MarkerToolSample().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CustomStyleSample().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            new VisibleRangeChangedDelayedSample().Show();
            Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new SimplestSyntaxHighlightingSample().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new JokeSample().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new SimplestCodeFoldingSample().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new AutocompleteSample().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new DynamicSyntaxHighlighting().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new SyntaxHighlightingByXmlDescription().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new IMEsample().Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new PowerfulCSharpEditor().Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new GifImageDrawingSample().Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new AutocompleteSample2().Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new AutoIndentSample().Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            new BookmarksSample().Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            new LoggerSample().Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            new TooltipSample().Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            new SplitSample().Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            new LazyLoadingSample().Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            new ConsoleSample().Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            new CustomFoldingSample().Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            new BilingualHighlighterSample().Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            new HyperlinkSample().Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            new CustomTextSourceSample().Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            new HintSample().Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            new ReadOnlyBlocksSample().Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            new PredefinedStylesSample().Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            new MacrosSample().Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            new OpenTypeFontSample().Show();
        }

        private void MainForm_DoubleClick(object sender, EventArgs e)
        {
            new Sandbox().ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            new RulerSample().Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            new AutocompleteSample3().Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            new AutocompleteSample4().Show(); 
        }

        private void button34_Click(object sender, EventArgs e)
        {
            new DocumentMapSample().Show();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            new DiffMergeSample().Show();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            new CustomScrollBarsSample().Show();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            new CustomWordWrapSample().Show();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            new AutoIndentCharsSample().Show();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            new CustomTextSourceSample2().Show();
        }
    }
}
