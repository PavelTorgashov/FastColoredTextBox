using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class CustomTextSourceSample2 : Form
    {
        public CustomTextSourceSample2()
        {
            InitializeComponent();
        }

        private string CreateBigString()
        {
            var sb = new StringBuilder();
            var counter = 1;

            for (int i = 0; i < 25000; i++)
            {
                sb.AppendLine(counter++ + " aaaaccccc");
                sb.AppendLine(counter++ + " bbbbbbcc");
                sb.AppendLine(counter++ + " cccaaaa");
                sb.AppendLine(counter++ + " dddddaaaa");
            }

            return sb.ToString();
        }

        private void CustomTextSourceSample_Shown(object sender, EventArgs e)
        {
            //create our custom TextSource
            var ts = new TextSourceWithLineFiltering(fctb);
            //assign TextSource to the component
            fctb.TextSource = ts;
            //assign text to fctb
            fctb.Text = CreateBigString();
            fctb.ClearUndo();
        }

        private void tbLineFilter_TextChanged(object sender, EventArgs e)
        {
            (fctb.TextSource as TextSourceWithLineFiltering).LineFilterRegex = Regex.Escape(tbLineFilter.Text);
        }
    }

    public class TextSourceWithLineFiltering : TextSource
    {
        List<int> toSourceIndex = new List<int>();
        private string _lineFilterRegex;

        public string LineFilterRegex
        {
            get { return _lineFilterRegex; }
            set { _lineFilterRegex = value; UpdateFilter(); }
        }

        private void UpdateFilter()
        {
            toSourceIndex.Clear();

            var count = base.lines.Count;
            var regex = new Regex(LineFilterRegex);
            for (int i = 0; i < count; i++)
            {
                if (regex.IsMatch(lines[i].Text))
                    toSourceIndex.Add(i);
            }

            CurrentTB.NeedRecalc(true);
            CurrentTB.Invalidate();
        }

        public TextSourceWithLineFiltering(FastColoredTextBox tb) : base(tb)
        {
        }

        public override int Count
        {
            get{ return toSourceIndex.Count;}
        }

        public override Line this[int i]
        {
            get{ return base[toSourceIndex[i]]; }
            set{ base[toSourceIndex[i]] = value; }
        }

        public override void InsertLine(int index, Line line)
        {
            if (index >= toSourceIndex.Count)
            {
                var c = lines.Count;
                while (index >= toSourceIndex.Count)
                    toSourceIndex.Add(c++);
            }
            else
            {
                var srcIndex = toSourceIndex[index];
                toSourceIndex.Insert(index, srcIndex);
                for (int i = index + 1; i < toSourceIndex.Count; i++)
                    toSourceIndex[i]++;
            }

            index = toSourceIndex[index];
            base.InsertLine(index, line);
        }

        public override void RemoveLine(int index, int count)
        {
            for (int ii = index + count - 1; ii >= index; ii--)
            {
                var srcIndex = toSourceIndex[ii];
                base.RemoveLine(srcIndex, 1);

                toSourceIndex.RemoveAt(ii);

                for (int i = index; i < toSourceIndex.Count; i++)
                    toSourceIndex[i]--;
            }
        }

        public override int GetLineLength(int i)
        {
            return base.GetLineLength(toSourceIndex[i]);
        }

        public override bool LineHasFoldingStartMarker(int iLine)
        {
            return base.LineHasFoldingStartMarker(toSourceIndex[iLine]);
        }

        public override bool LineHasFoldingEndMarker(int iLine)
        {
            return base.LineHasFoldingEndMarker(toSourceIndex[iLine]);
        }
    }
}
