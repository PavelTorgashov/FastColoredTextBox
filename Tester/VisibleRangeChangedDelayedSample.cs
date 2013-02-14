using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class VisibleRangeChangedDelayedSample : Form
    {
        //styles
        Style BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        Style RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        Style MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);

        public VisibleRangeChangedDelayedSample()
        {
            InitializeComponent();

            //generate 200,000 lines of HTML
            string html4line =
            @"<li id=""ctl00_TopNavBar_AQL"">
<a id=""ctl00_TopNavBar_ArticleQuestion"" class=""fly highlight"" href=""#_comments"">Ask a Question about this article</a></li>
<li class=""heading"">Quick Answers</li>
<li><a id=""ctl00_TopNavBar_QAAsk"" class=""fly"" href=""/Questions/ask.aspx"">Ask a Question</a></li>";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 50000; i++)
                sb.AppendLine(html4line);

            //assign to FastColoredTextBox
            fctb.Text = sb.ToString();
            fctb.IsChanged = false;
            fctb.ClearUndo();
            //set delay interval (10 ms)
            fctb.DelayedEventsInterval = 10;
        }

        private void fctb_VisibleRangeChangedDelayed(object sender, EventArgs e)
        {
            //highlight only visible area of text
            HTMLSyntaxHighlight(fctb.VisibleRange);
        }

        private void HTMLSyntaxHighlight(Range range)
        {
            //clear style of changed range
            range.ClearStyle(BlueStyle, MaroonStyle, RedStyle);
            //tag brackets highlighting
            range.SetStyle(BlueStyle, @"<|/>|</|>");
            //tag name
            range.SetStyle(MaroonStyle, @"<(?<range>[!\w]+)");
            //end of tag
            range.SetStyle(MaroonStyle, @"</(?<range>\w+)>");
            //attributes
            range.SetStyle(RedStyle, @"(?<range>\S+?)='[^']*'|(?<range>\S+)=""[^""]*""|(?<range>\S+)=\S+");
            //attribute values
            range.SetStyle(BlueStyle, @"\S+?=(?<range>'[^']*')|\S+=(?<range>""[^""]*"")|\S+=(?<range>\S+)");
        }
    }
}
