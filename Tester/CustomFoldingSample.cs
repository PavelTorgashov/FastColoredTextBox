using System;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace Tester
{
    public partial class CustomFoldingSample : Form
    {
        public CustomFoldingSample()
        {
            InitializeComponent();
            fctb.OnTextChangedDelayed(fctb.Range);
        }

        private void fctb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            //delete all markers
            fctb.Range.ClearFoldingMarkers();

            var currentIndent = 0;
            var lastNonEmptyLine = 0;

            for (int i = 0; i < fctb.LinesCount; i++)
            {
                var line = fctb[i];
                var spacesCount = line.StartSpacesCount;
                if (spacesCount == line.Count) //empty line
                    continue;

                if (currentIndent < spacesCount)
                    //append start folding marker
                    fctb[lastNonEmptyLine].FoldingStartMarker = "m" + currentIndent;
                else
                if (currentIndent > spacesCount)
                    //append end folding marker
                    fctb[lastNonEmptyLine].FoldingEndMarker = "m" + spacesCount;

                currentIndent = spacesCount;
                lastNonEmptyLine = i;
            }
        }

        private void fctb_AutoIndentNeeded(object sender, AutoIndentEventArgs e)
        {
            //we assign this handler to disable AutoIndent by folding
        }
    }
}
