namespace Tester
{
    partial class SyntaxHighlightingByXmlDescription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyntaxHighlightingByXmlDescription));
            this.label1 = new System.Windows.Forms.Label();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            FastColoredTextBoxNS.SyntaxHighlighter syntaxHighlighter1 = new FastColoredTextBoxNS.SyntaxHighlighter(fctb);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "This example uses XML file for description syntax highlighting.";
            // 
            // fastColoredTextBox1
            // 
            this.fctb.AutoScroll = true;
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(0, 176);
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DescriptionFile = "htmlDesc.xml";
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.IsChanged = true;
            this.fctb.LeftBracket = '(';
            this.fctb.Location = new System.Drawing.Point(0, 39);
            this.fctb.Name = "fastColoredTextBox1";
            this.fctb.RightBracket = ')';
            this.fctb.SelectedText = "";
            this.fctb.SelectionStart = 373;
            this.fctb.Size = new System.Drawing.Size(370, 275);
            this.fctb.SyntaxHighlighter = syntaxHighlighter1;
            this.fctb.TabIndex = 4;
            this.fctb.Text = @"<div class=""clip5x9 nav_arrows"">
      <img src=""http://i3.msdn.microsoft.com/Hash/0f73868cd340280cac28f7eeb3d2dd7d.png"" class=""cl_nav_arrow"" alt="""" />
</div>
    
<div class=""nav_div_currentroot"">
<a href=""http://msdn.microsoft.com/en-us/library/abeh092z(v=VS.90).aspx"" title=""System.Globalization Namespace"">System.Globalization Namespace</a></div>";
            this.fctb.WordWrap = true;
            // 
            // SyntaxHighlightingByXmlDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 314);
            this.Controls.Add(this.fctb);
            this.Controls.Add(this.label1);
            this.Name = "SyntaxHighlightingByXmlDescription";
            this.Text = "SyntaxHighlightingByXmlDescription";
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.Label label1;
    }
}