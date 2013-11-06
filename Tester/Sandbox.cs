using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class Sandbox : Form
    {
        private FastColoredTextBox fctb;

        public Sandbox()
        {
            InitializeComponent();

            fctb = new FastColoredTextBox() { Parent = this, Dock = DockStyle.Fill };
            fctb.TextChangedDelayed += new EventHandler<TextChangedEventArgs>(fctb_TextChangedDelayed);
            fctb.Text = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
<!-- Edited by XMLSpy® -->
<CATALOG>
	<PLANT>
		<COMMON>Bloodroot</COMMON><AVAILABILITY>
			031599
		</AVAILABILITY>
	</PLANT>
	<PLANT><PRICE value=""11.34""></PRICE>
		<COMMON Name=""Bloodroot"" /><BLABLA/>
		<BOTANICAL Title=""Sanguinaria canadensis""
			Name="""" /><ZONE>4</ZONE>
		<LIGHT>Mostly Shady</LIGHT> <PRICE Value=""$2.44""/>
		<AVAILABILITY No=""3454"">
			031599
		</AVAILABILITY>
	</PLANT>
</CATALOG>
";
        }

        private static Regex regex = new Regex(@"<(?<range>/?\w+)\s[^>]*?[^/]>|<(?<range>/?\w+)\s*>", RegexOptions.Singleline);

        void fctb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            var fctb = sender as FastColoredTextBox;
            fctb.Range.ClearFoldingMarkers();
            //
            var stack = new Stack<Tag>();
            var id = 0;
            //extract opening and closing tags (exclude open-close tags: <TAG/>)
            foreach (var r in fctb.Range.GetRanges(regex))
            {
                var tagName = r.Text;
                var iLine = r.Start.iLine;
                //if it is opening tag...
                if (tagName[0] != '/')
                {
                    // ...push into stack
                    var tag = new Tag { Name = tagName, Id = id++, StartLine = r.Start.iLine };
                    stack.Push(tag);
                    // if this line has no markers - set marker
                    if (string.IsNullOrEmpty(fctb[iLine].FoldingStartMarker))
                        fctb[iLine].FoldingStartMarker = tag.Marker;
                }
                else
                {
                    //if it is closing tag - pop from stack
                    var tag = stack.Pop();
                    //compare line number
                    if (iLine == tag.StartLine)
                    {
                        //remove marker, because same line can not be folding
                        if (fctb[iLine].FoldingStartMarker == tag.Marker)//was it our marker?
                            fctb[iLine].FoldingStartMarker = null; 
                    }
                    else
                    {
                        //set end folding marker
                        if (string.IsNullOrEmpty(fctb[iLine].FoldingEndMarker))
                            fctb[iLine].FoldingEndMarker = tag.Marker;
                    }
                }
            }
        }

        class Tag
        {
            public string Name;
            public int Id;
            public int StartLine;
            public string Marker { get { return Name + Id; } }
        }
    }
}