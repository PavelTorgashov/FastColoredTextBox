using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class Sandbox : Form
    {
        private List<Style> styles = new List<Style>();

        public Sandbox()
        {
            InitializeComponent();

            var fctb = new FastColoredTextBox() { Parent = this, Dock = DockStyle.Fill };
            fctb.TextChanged += fctb_TextChanged;
            fctb.Text = @"; last modified 1 April 2001 by John Doe
[owner]
name=John Doe
organization=Acme Widgets Inc.
 
[database]
; use IP address in case network name resolution is not working
server=192.0.2.62     
port=143
file=""payroll.dat""
";
        }

        const string sectionRegex = @"^\[\w+\]$";

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();
            //
            foreach (var r in e.ChangedRange.GetRangesByLines(sectionRegex, RegexOptions.None))
            {
                if (r.Start.iLine > 0) r.tb[r.Start.iLine - 1].FoldingEndMarker = "section";
                r.tb[r.Start.iLine].FoldingStartMarker = "section";
            }
        }
    }
}