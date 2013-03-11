using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class LazyLoadingSample : Form
    {
        public LazyLoadingSample()
        {
            InitializeComponent();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fctb.OpenBindingFile(ofd.FileName, Encoding.UTF8);
                fctb.IsChanged = false;
                fctb.ClearUndo();
                GC.Collect();
                GC.GetTotalMemory(true);
            }
        }

        private void fctb_VisibleRangeChangedDelayed(object sender, EventArgs e)
        {
            HighlightVisibleRange();
        }

        private void fctb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            HighlightVisibleRange();
        }

        const int margin = 2000;

        private void HighlightVisibleRange()
        {
            //expand visible range (+- margin)
            var startLine = Math.Max(0, fctb.VisibleRange.Start.iLine - margin);
            var endLine = Math.Min(fctb.LinesCount - 1, fctb.VisibleRange.End.iLine + margin);
            var range = new Range(fctb, 0, startLine, 0, endLine);
            //clear folding markers
            range.ClearFoldingMarkers();
            //set markers for folding
            range.SetFoldingMarkers(@"N\d\d00", @"N\d\d99");
            //
            range.ClearStyle(StyleIndex.All);
            range.SetStyle(fctb.SyntaxHighlighter.BlueStyle, @"N\d+");
            range.SetStyle(fctb.SyntaxHighlighter.RedStyle, @"[+\-]?[\d\.]+\d+");
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.CloseBindingFile();
        }

        private void LazyLoadingSample_FormClosing(object sender, FormClosingEventArgs e)
        {
            fctb.CloseBindingFile();
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                fctb.SaveToFile(sfd.FileName, Encoding.UTF8);
            }
        }

        private void createTestFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            using(StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Default))
            {
                //create large test file
                for (int j = 0; j < 5*130; j++)
                {
                    sw.WriteLine("\r\n--====" + j + "=====--\r\n");
                    for (int i = 0; i < 10000; i++)
                        sw.WriteLine(string.Format("N{0:0000} X{1} Y{2} Z{3}", i, rnd.Next(), rnd.Next(), rnd.Next()));
                }
            }
        }

        private void collapseAllFoldingBlocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.CollapseAllFoldingBlocks();
            fctb.DoSelectionVisible();
        }

        private void expandAllCollapsedBlocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.ExpandAllFoldingBlocks();
            fctb.DoSelectionVisible();
        }

        private void removeEmptyLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iLines = fctb.FindLines(@"^\s*$", RegexOptions.None);
            fctb.RemoveLines(iLines);
        }

        private void removeAllSpacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSpaces();
        }

        
         public void RemoveSpaces()
         {
             lock (this.fctb)
             {
                 try
                 {
                     // pattern to search for
                     String pattern = @"\s";

                     fctb.BeginUpdate();

                     // range to search in
                     Range range = rangeSelected();

                     // collect all ranges that match for the pattern " "
                     var ranges = new List<Range>();
                     foreach (var r in range.GetRangesByLines(pattern, RegexOptions.None | RegexOptions.Compiled))
                     {
                         ranges.Add(r);
                     }

                     // remove all collected ranges
                     if (ranges.Count > 0)
                     {
                         fctb.TextSource.Manager.ExecuteCommand(new ReplaceTextCommand(fctb.TextSource, ranges, String.Empty));
                         // clear selection
                         fctb.Selection = new Range(this.fctb);
                     }
                     // update screen
                     fctb.Invalidate();
                 }
                 catch (Exception exp)
                 {
                     //ShowException(exp);
                 }
                 finally
                 {
                     // unlock
                     fctb.EndUpdate();
                 }
             }
         }


         /// <summary>
         /// Calculates the range of the whole document if no selection exists. Else return range containing the selection.
         /// </summary>
         /// <returns>returns either the range ALL or SELECTION if it exists</returns>
         private Range rangeSelected()
         {
             var t = fctb;
             var r = new Range(t);

             lock (this.fctb)
             {
                 t.Selection.BeginUpdate();

                 if ((t.Selection.Start.iLine == t.Selection.End.iLine) &&
                      (t.Selection.Start.iChar == t.Selection.End.iChar))
                 {
                     // No selection - set range over all
                     r.Start = new Place(0, 0);

                     var lastLine = t.LinesCount - 1;
                     r.End = new Place(t.GetLineLength(lastLine), lastLine);
                 }
                 else
                 {
                     // Use available selection
                     r.Start = t.Selection.Start;
                     r.End = t.Selection.End;
                 }

                 // unlock
                 t.Selection.EndUpdate();
             }
             return r;
         }
    }
}
