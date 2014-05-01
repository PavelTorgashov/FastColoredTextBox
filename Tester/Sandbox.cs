using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class Sandbox : Form
    {
        public Sandbox()
        {
            InitializeComponent();

            fastColoredTextBox1.TextSource = new TextSourceWithFilter(fastColoredTextBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filter = new Predicate<string>((s) => s.Contains(textBox1.Text));
            (fastColoredTextBox1.TextSource as TextSourceWithFilter).Filter(filter);
        }
    }

    public class TextSourceWithFilter : TextSource
    {
        //indices of filtered lines
        private List<int> filteredLines = new List<int>();

        public TextSourceWithFilter(FastColoredTextBox currentTB) : base(currentTB)
        {
            InsertLine(0, CreateLine());
        }

        public void Filter(Predicate<string> filter)
        {
            filteredLines.Clear();

            for(int i = 0 ;i<base.lines.Count;i++)
                if (filter(base.lines[i].Text))
                    filteredLines.Add(i);

            OnTextChanged(0, filteredLines.Count - 1);
        }

        public override Line this[int i]
        {
            get
            {
                if (i >= filteredLines.Count)
                    return null;
                return base.lines[filteredLines[i]];
            }
            set { throw new NotSupportedException(); }
        }

        public void ClearFilter()
        {
            Filter(null);
        }

        public override void InsertLine(int index, Line line)
        {
            if(index  >= filteredLines.Count)
            {
                filteredLines.Add(base.lines.Count);
                base.InsertLine(base.lines.Count, line);
            }else
            {
                var sourceIndex = filteredLines[index];
                filteredLines.Insert(index, sourceIndex);
                for (int i = index + 1; i < filteredLines.Count; i++)
                    filteredLines[i]++;

                base.InsertLine(sourceIndex, line);
            }
        }

        public override void RemoveLine(int index, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var sourceIndex = filteredLines[index];
                filteredLines.RemoveAt(index);
                RemoveSourceLine(sourceIndex - i);
            }

            for (int i = index; i < filteredLines.Count; i++)
                filteredLines[i] -= count;
        }

        void RemoveSourceLine(int index)
        {
            var removedLineIds = new List<int>();
            //
            if (IsNeedBuildRemovedLineIds)
                removedLineIds.Add(base.lines[index].UniqueId);
            //
            lines.RemoveRange(index, 1);

            OnLineRemoved(index, 1, removedLineIds);
        }

        public override int Count
        {
            get
            {
                return filteredLines.Count;
            }
        }
    }
}