using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Linq;

namespace Tester
{
    public partial class Sandbox : Form
    {
        public Sandbox()
        {
            InitializeComponent();

            var fctb = new MyFCTB() { Dock = DockStyle.Fill, Parent = this };
            fctb.Text = @"// snippetText like - {0:public} class {1:MyClass} { {2} }
// 0, 1 and 2 are tabstops. should I escape the opening and closing brackets of the class ?
";
        }
    }

    class MyFCTB: FastColoredTextBox
    {
        private MarkerStyle FieldStyle = new MarkerStyle(Brushes.Bisque);
        bool textHasFieldStyle = true;

        public MyFCTB()
        {
            TextChanged += new EventHandler<TextChangedEventArgs>(MyFCTB_TextChanged);
            AddStyle(FieldStyle);
        }

        private int updating = 0;

        void MyFCTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (updating > 0)
                return;

            updating++;

            var r = e.ChangedRange;

            again:
            foreach (var field in r.GetRanges(@"{\d+:\w+}|{\d+}"))
            {
                Selection = field;

                var parts = field.Text.Trim('{', '}').Split(':');
                var text = parts.Length == 2 ? parts[1] : " ";
                SelectedText = text;

                new Range(this, field.Start, Selection.Start).SetStyle(FieldStyle);

                textHasFieldStyle = true;

                goto again;
            }

            updating--;
        }

        public override bool ProcessKey(Keys keyData)
        {
            if(keyData == Keys.Tab)
            {
                if (textHasFieldStyle)
                    if (GoToNextField())
                        return true;
            }

            if(keyData == Keys.Escape)
            {
                    Range.ClearStyle(FieldStyle);
                    textHasFieldStyle = false;
            }

            return base.ProcessKey(keyData);
        }

        private bool GoToNextField()
        {
            Place? start = null;
            Place? end = null;
            var si = GetStyleIndexMask(new []{FieldStyle});

            foreach (var p in Range.GetPlacesCyclic(Selection.Start > Selection.End ? Selection.Start : Selection.End))
            if((this[p].style & si) != 0)
            {
                if (start == null)
                    start = p;
            }else
            if(start != null)
            {
                end = p;
                break;
            }

            if(start != null && end != null)
            {
                Selection.Start = (Place)start;
                Selection.End = (Place)end;
                DoSelectionVisible();
                return true;
            }

            textHasFieldStyle = false;
            return false;
        }
    }
}