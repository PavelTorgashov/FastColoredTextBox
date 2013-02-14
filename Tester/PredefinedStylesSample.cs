using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class PredefinedStylesSample : Form
    {
        public PredefinedStylesSample()
        {
            InitializeComponent();

            GenerateText();
        }

        private void GenerateText()
        {
            Random rnd = new Random();

            fctb.BeginUpdate();
            fctb.Selection.BeginUpdate();

            for (int i = 0; i < 50000; i++)
            {
                switch (rnd.Next(4))
                {
                    case 0: fctb.AppendText("This is simple text "); break;
                    case 1: fctb.AppendText("Some link", new BlockDesc() { URL = "http://google.com?q=" + i }); break;
                    case 2: fctb.AppendText("TooltipedText ", new BlockDesc() { IsBold = true, ToolTip = "ToolTip " + i }); break;
                    case 3: fctb.NewLine(); break;
                }
            }

            fctb.Selection.EndUpdate();
            fctb.EndUpdate();
        }
    }

    internal class ReadOnlyFCTB : FastColoredTextBox
    {
        TextStyle linkStyle = new TextStyle(Brushes.Blue, null, FontStyle.Underline);
        TextStyle visitedLinkStyle = new TextStyle(Brushes.Brown, null, FontStyle.Underline);
        TextStyle boldStyle = new TextStyle(Brushes.Navy, null, FontStyle.Bold);
        List<BlockDesc> blockDescs = new List<BlockDesc>();

        Point lastMouseCoord;
        Place lastPlace;
        readonly Place emptyPlace = new Place(-1, -1);

        public ReadOnlyFCTB()
        {
            ReadOnly = true;
        }

        public void NewLine()
        {
            AppendText("\n");
        }

        public void AppendText(string text, BlockDesc desc)
        {
            var oldPlace = new Place(GetLineLength(LinesCount - 1), LinesCount - 1);

            if (desc.IsBold)
                AppendText(text, boldStyle);
            else
                if (!string.IsNullOrEmpty(desc.URL))
                    AppendText(text, linkStyle);
                else
                    AppendText(text);

            //if descriptor contains some additional data ...
            if (!string.IsNullOrEmpty(desc.URL) || !string.IsNullOrEmpty(desc.ToolTip))
            {
                //save descriptor in sorted list
                desc.Start = oldPlace;
                desc.End = new Place(GetLineLength(LinesCount - 1), LinesCount - 1);
                blockDescs.Add(desc);
            }
        }

        BlockDesc GetDesc(Place place)
        {
            var index = blockDescs.BinarySearch(new BlockDesc() { Start = place, End = place });
            if (index >= 0)
                return blockDescs[index];

            return null;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            lastMouseCoord = e.Location;
            Cursor = Cursors.IBeam;

            //get place under mouse
            lastPlace = PointToPlace(lastMouseCoord);

            //check distance
            var p = PlaceToPoint(lastPlace);
            if (Math.Abs(p.X - lastMouseCoord.X) > CharWidth * 2 || Math.Abs(p.Y - lastMouseCoord.Y) > CharHeight * 2)
                lastPlace = emptyPlace;

            //check link style
            if (lastPlace != emptyPlace)
            {
                var styles = GetStylesOfChar(lastPlace);
                if (styles.Contains(linkStyle) || styles.Contains(visitedLinkStyle))
                    Cursor = Cursors.Hand;
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var desc = GetDesc(lastPlace);
            if (desc != null && !string.IsNullOrEmpty(desc.URL))
            {
                var r = new Range(this, desc.Start, desc.End);
                r.ClearStyle(linkStyle);
                r.SetStyle(visitedLinkStyle);
                BeginInvoke(new MethodInvoker(() => Process.Start(desc.URL)));
            }

            base.OnMouseDown(e);
        }

        protected override void OnToolTip()
        {
            if (ToolTip == null)
                return;

            //get descriptor for place
            var desc = GetDesc(lastPlace);

            //show tooltip
            if (desc != null)
            {
                var toolTip = desc.ToolTip ?? desc.URL;
                ToolTip.SetToolTip(this, toolTip);
                ToolTip.Show(toolTip, this, new Point(lastMouseCoord.X, lastMouseCoord.Y + CharHeight));
            }
        }
    }

    public class BlockDesc : IComparable<BlockDesc>
    {
        public bool IsBold;
        public string ToolTip;
        public string URL;

        internal Place Start;
        internal Place End;

        public int CompareTo(BlockDesc other)
        {
            if (Start <= other.Start && End > other.End) return 0;
            if (Start <= other.Start) return -1;
            return 1;
        }
    }
}
