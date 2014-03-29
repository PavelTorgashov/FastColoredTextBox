using System;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class Sandbox : Form
    {
        public Sandbox()
        {
            InitializeComponent();

            var fctb = new MyFCTB() { Parent = this, Language = Language.Custom, Dock = DockStyle.Fill };
            fctb.VisibleRangeChanged += new EventHandler(fctb_VisibleChanged);

            OpenFileDialog ofd = new OpenFileDialog(){Filter = "Text|*.txt;*.cs"};
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                fctb.OpenFile(ofd.FileName);
        }

        private void fctb_VisibleChanged(object sender, EventArgs e)
        {
            var fctb = sender as FastColoredTextBox;
            //if you use built-in highlighter:
            fctb.SyntaxHighlighter.InitStyleSchema(Language.CSharp);
            fctb.SyntaxHighlighter.HighlightSyntax(Language.CSharp, fctb.VisibleRange);
            //if you use custom highlighting:
            //Highlight(fctrb.VisibleRange)
        }
    }

    public class MyFCTB: FastColoredTextBox
    {
        public char[] autoCompleteBracketsList = {'(', ')', '{', '}', '[', ']', '"', '"', '\'', '\''};

        public char[] AutoCompleteBracketsList 
        {
            get { return autoCompleteBracketsList; }
            set { autoCompleteBracketsList = value; }
        }

        public bool AutoCompleteBrackets { get; set; }

        public override bool ProcessKey(char c, Keys modifiers)
        {
            if (AutoCompleteBrackets)
            {
                if (!Selection.ColumnSelectionMode)
                    for (int i = 1; i < autoCompleteBracketsList.Length; i += 2)
                        if (c == autoCompleteBracketsList[i] && c == Selection.CharAfterStart)
                        {
                            Selection.GoRight();
                            return true;
                        }

                for (int i = 0; i < autoCompleteBracketsList.Length; i += 2)
                    if (c == autoCompleteBracketsList[i])
                        return InsertBrackets(autoCompleteBracketsList[i], autoCompleteBracketsList[i + 1]);
            }

            return base.ProcessKey(c, modifiers);
        }

        private bool InsertBrackets(char left, char right)
        {
            if(Selection.ColumnSelectionMode)
            {
                var range = Selection.Clone();
                range.Normalize();
                Selection.BeginUpdate();
                BeginAutoUndo();
                Selection = new Range(this, range.Start.iChar, range.Start.iLine, range.Start.iChar, range.End.iLine) {ColumnSelectionMode = true};
                base.ProcessKey(left, Keys.None);
                Selection = new Range(this, range.End.iChar + 1, range.Start.iLine, range.End.iChar + 1, range.End.iLine) { ColumnSelectionMode = true };
                base.ProcessKey(right, Keys.None);
                if(range.IsEmpty)
                    Selection = new Range(this, range.End.iChar + 1, range.Start.iLine, range.End.iChar + 1, range.End.iLine) { ColumnSelectionMode = true };
                EndAutoUndo();
                Selection.EndUpdate();
            }else
            if (Selection.IsEmpty)
            {
                InsertText(left  + "" + right);
                Selection.GoLeft();
            }
            else
                InsertText(left + SelectedText + right);

            return true;
        }
    }

}