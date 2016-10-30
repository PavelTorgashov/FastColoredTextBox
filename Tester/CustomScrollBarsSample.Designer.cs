namespace Tester
{
    partial class CustomScrollBarsSample
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomScrollBarsSample));
            this.label2 = new System.Windows.Forms.Label();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.hMyScrollBar = new Tester.MyScrollBar();
            this.vMyScrollBar = new Tester.MyScrollBar();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(461, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "Here we create custom outside scrollbars for FCTB.";
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.Location = new System.Drawing.Point(359, 62);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 181);
            this.vScrollBar.TabIndex = 8;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.Location = new System.Drawing.Point(41, 330);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(227, 17);
            this.hScrollBar.TabIndex = 9;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // hMyScrollBar
            // 
            this.hMyScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hMyScrollBar.BackColor = System.Drawing.Color.Gold;
            this.hMyScrollBar.BorderColor = System.Drawing.Color.Gray;
            this.hMyScrollBar.Location = new System.Drawing.Point(41, 280);
            this.hMyScrollBar.Maximum = 100;
            this.hMyScrollBar.Name = "hMyScrollBar";
            this.hMyScrollBar.Orientation = System.Windows.Forms.ScrollOrientation.HorizontalScroll;
            this.hMyScrollBar.Size = new System.Drawing.Size(227, 14);
            this.hMyScrollBar.TabIndex = 7;
            this.hMyScrollBar.Text = "myScrollBar2";
            this.hMyScrollBar.ThumbColor = System.Drawing.Color.Red;
            this.hMyScrollBar.ThumbSize = 10;
            this.hMyScrollBar.Value = 0;
            this.hMyScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // vMyScrollBar
            // 
            this.vMyScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vMyScrollBar.BackColor = System.Drawing.Color.Gold;
            this.vMyScrollBar.BorderColor = System.Drawing.Color.Gray;
            this.vMyScrollBar.Location = new System.Drawing.Point(314, 62);
            this.vMyScrollBar.Maximum = 100;
            this.vMyScrollBar.Name = "vMyScrollBar";
            this.vMyScrollBar.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.vMyScrollBar.Size = new System.Drawing.Size(14, 179);
            this.vMyScrollBar.TabIndex = 6;
            this.vMyScrollBar.Text = "myScrollBar1";
            this.vMyScrollBar.ThumbColor = System.Drawing.Color.Red;
            this.vMyScrollBar.ThumbSize = 10;
            this.vMyScrollBar.Value = 0;
            this.vMyScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // fctb
            // 
            this.fctb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctb.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(284, 315);
            this.fctb.BackBrush = null;
            this.fctb.BackColor = System.Drawing.Color.Gold;
            this.fctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fctb.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctb.CharHeight = 15;
            this.fctb.CharWidth = 7;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctb.IndentBackColor = System.Drawing.Color.Orange;
            this.fctb.IsReplaceMode = false;
            this.fctb.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctb.LeftBracket = '(';
            this.fctb.LeftBracket2 = '{';
            this.fctb.Location = new System.Drawing.Point(41, 62);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.RightBracket = ')';
            this.fctb.RightBracket2 = '}';
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb.ServiceColors")));
            this.fctb.ServiceLinesColor = System.Drawing.Color.DarkGray;
            this.fctb.ShowScrollBars = false;
            this.fctb.Size = new System.Drawing.Size(227, 179);
            this.fctb.TabIndex = 3;
            this.fctb.Text = resources.GetString("fctb.Text");
            this.fctb.Zoom = 100;
            this.fctb.ScrollbarsUpdated += new System.EventHandler(this.fctb_ScrollbarsUpdated);
            // 
            // CustomScrollBarsSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 403);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hMyScrollBar);
            this.Controls.Add(this.vMyScrollBar);
            this.Controls.Add(this.fctb);
            this.Controls.Add(this.label2);
            this.Name = "CustomScrollBarsSample";
            this.Text = "CustomScrollBarsSample";
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private MyScrollBar vMyScrollBar;
        private MyScrollBar hMyScrollBar;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;

    }
}