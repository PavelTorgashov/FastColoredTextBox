using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

            var fctb = new MyFCTB(){Parent = this, Language = Language.CSharp, Dock = DockStyle.Fill};
        }
    }

    public class MyFCTB : FastColoredTextBox
    {
        private HashSet<int> foldedBlocks = new HashSet<int>();

        protected override void OnTextChanged(TextChangedEventArgs args)
        {
            //clear folding state for changed range of text
            var r = args.ChangedRange.Clone();
            r.Normalize();
            for (int iLine = r.Start.iLine; iLine <= r.End.iLine; iLine++)
                foldedBlocks.Remove(this[iLine].UniqueId);

            base.OnTextChanged(args);
        }

        public override void ExpandFoldedBlock(int iLine)
        {
            base.ExpandFoldedBlock(iLine);

            foldedBlocks.Remove(this[iLine].UniqueId);//remove folded state for this line
            AdjustFolding();
        }

        private void AdjustFolding()
        {
            //collapse folded blocks
            for(int iLine = 0; iLine<LinesCount;iLine++)
            if (LineInfos[iLine].VisibleState == VisibleState.Visible)
            if (foldedBlocks.Contains(this[iLine].UniqueId))
                CollapseFoldingBlock(iLine);
        }

        public override void CollapseFoldingBlock(int iLine)
        {
            base.CollapseFoldingBlock(iLine);

            foldedBlocks.Add(this[iLine].UniqueId);//add folded state for line
        }
    }
}