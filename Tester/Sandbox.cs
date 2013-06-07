using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

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
            //fctb.Range.SetStyle(new ReadOnlyStyle(), "[^_]*");
            fctb.Text = "line1\n    line3\r\nline4";
            var s = fctb.Text;
            s = s.Replace("\r", "");//remove \r
            s = s.Replace(new string(' ', fctb.TabLength), "\t");//simple replacing spaces on tabs
        }

        static string[] keywords = new string[]{"Class", "Int", "Float"};
        static Regex keywordRegex = new Regex("\\b(" + string.Join("|", keywords) + ")\\b", RegexOptions.IgnoreCase);

        private void fctb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            var text = e.ChangedRange.Text;

            if (keywordRegex.IsMatch(text))
            {
                foreach (var keyword in keywords)
                    text = Regex.Replace(text, "\\b" + keyword + "\\b", keyword, RegexOptions.IgnoreCase);

                var oldSelection = fctb.Selection.Clone();

                fctb.BeginAutoUndo();
                fctb.TextSource.Manager.ExecuteCommand(new SelectCommand(fctb.TextSource));
                fctb.Selection = e.ChangedRange;
                fctb.InsertText(text);
                fctb.TextSource.Manager.ExecuteCommand(new SelectCommand(fctb.TextSource));
                fctb.EndAutoUndo();

                fctb.Selection = oldSelection;
            }
        }

        private void fctb_PaintLine(object sender, PaintLineEventArgs e)
        {
            var isChanged = fctb[e.LineIndex].IsChanged;
            if(isChanged)
                using(var brush = new SolidBrush(Color.FromArgb(100, Color.Red)))
                e.Graphics.FillRectangle(brush, e.LineRect.Left - 12, e.LineRect.Top, 5, e.LineRect.Height);
        }

        List<int> readonlyLines = new List<int>(new int[]{ 1, 3, 4 });

        private void fctb_TextChanging(object sender, TextChangingEventArgs e)
        {
            if (fctb.Selection.IsEmpty)
            {
                if (readonlyLines.Contains(fctb.Selection.Start.iLine))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            foreach (var place in fctb.Selection)
                if (readonlyLines.Contains(place.iLine))
                {
                    e.Cancel = true;
                    return;
                }
        }
    }
}
