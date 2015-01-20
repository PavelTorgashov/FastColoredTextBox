using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Drawing;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tester
{
    public partial class AutoIndentSample : Form
    {
        public AutoIndentSample()
        {
            InitializeComponent();
            cbAutoIndentType.SelectedIndex = 0;
        }

        private void cbAutoIndentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAutoIndentType.SelectedIndex == 0)//built-in C# AutoIndent
            {
                fctb.Language = Language.CSharp;
                fctb.AutoIndentNeeded -= new EventHandler<AutoIndentEventArgs>(fctb_AutoIndentNeeded);
                fctb.Text = @"/// Please, type next text (without slashes):
/// int Foo()
/// {
/// int i=10;
/// label:
/// while(i!=j){
/// i--;
/// j++;
/// }
/// if(i==0)
/// return i;
/// else
/// return j;
/// }

";
                fctb.GoEnd();
                fctb.Focus();
            }

            if(cbAutoIndentType.SelectedIndex == 1)//custom AutoIndent
            {
                fctb.Language = Language.Custom;
                fctb.AutoIndentNeeded += new EventHandler<AutoIndentEventArgs>(fctb_AutoIndentNeeded);
                fctb.Text = @"/// Please, type next text (without slashes):
/// begin
/// i := 1;
/// if j=0 then
/// begin
/// i := 10;
/// end
/// else
/// i := 20;
/// end

";
                fctb.GoEnd();
                fctb.Focus();
            }
        }

        void fctb_AutoIndentNeeded(object sender, AutoIndentEventArgs e)
        {
            // if current line is "begin" then next
            // line shift to right
            if (e.LineText.Trim() == "begin")
            {
                e.ShiftNextLines = e.TabLength;
                return;
            }
            // if current line is "end" then current
            // and next line shift to left
            if (e.LineText.Trim() == "end")
            {
                e.Shift = -e.TabLength;
                e.ShiftNextLines = -e.TabLength;
                return;
            }
            // if previous line contains "then" or "else", 
            // and current line does not contain "begin"
            // then shift current line to right
            if (Regex.IsMatch(e.PrevLineText, @"\b(then|else)\b") &&
                !Regex.IsMatch(e.LineText, @"\bbegin\b"))
            {
                e.Shift = e.TabLength;
                return;
            }
        }
    }
}
