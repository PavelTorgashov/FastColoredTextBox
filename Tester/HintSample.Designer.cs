namespace Tester
{
    partial class HintSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HintSample));
            this.btFind = new System.Windows.Forms.Button();
            this.cbInline = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbSimple = new System.Windows.Forms.CheckBox();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.cbDock = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(22, 22);
            this.btFind.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(161, 52);
            this.btFind.TabIndex = 2;
            this.btFind.Text = "Find and hint:";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbInline
            // 
            this.cbInline.AutoSize = true;
            this.cbInline.Checked = true;
            this.cbInline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInline.Location = new System.Drawing.Point(413, 35);
            this.cbInline.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbInline.Name = "cbInline";
            this.cbInline.Size = new System.Drawing.Size(74, 28);
            this.cbInline.TabIndex = 3;
            this.cbInline.Text = "Inline";
            this.cbInline.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbSimple);
            this.panel2.Controls.Add(this.tbFind);
            this.panel2.Controls.Add(this.cbDock);
            this.panel2.Controls.Add(this.btFind);
            this.panel2.Controls.Add(this.cbInline);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 89);
            this.panel2.TabIndex = 4;
            // 
            // cbSimple
            // 
            this.cbSimple.AutoSize = true;
            this.cbSimple.Checked = true;
            this.cbSimple.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSimple.Location = new System.Drawing.Point(636, 35);
            this.cbSimple.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbSimple.Name = "cbSimple";
            this.cbSimple.Size = new System.Drawing.Size(87, 28);
            this.cbSimple.TabIndex = 6;
            this.cbSimple.Text = "Simple";
            this.cbSimple.UseVisualStyleBackColor = true;
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(194, 31);
            this.tbFind.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(180, 29);
            this.tbFind.TabIndex = 5;
            this.tbFind.Text = "char";
            // 
            // cbDock
            // 
            this.cbDock.AutoSize = true;
            this.cbDock.Checked = true;
            this.cbDock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDock.Location = new System.Drawing.Point(530, 35);
            this.cbDock.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbDock.Name = "cbDock";
            this.cbDock.Size = new System.Drawing.Size(72, 28);
            this.cbDock.TabIndex = 4;
            this.cbDock.Text = "Dock";
            this.cbDock.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(900, 72);
            this.label2.TabIndex = 5;
            this.label2.Text = "The example shows usage of Hints. Press Find to add some hints. Press Esc to remo" +
    "ve all hints.";
            // 
            // fctb
            // 
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
            this.fctb.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(0, 290);
            this.fctb.BackBrush = null;
            this.fctb.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctb.CharHeight = 15;
            this.fctb.CharWidth = 7;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctb.IsReplaceMode = false;
            this.fctb.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctb.LeftBracket = '(';
            this.fctb.LeftBracket2 = '{';
            this.fctb.Location = new System.Drawing.Point(0, 161);
            this.fctb.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.fctb.Name = "fctb";
            this.fctb.PaddingBackColor = System.Drawing.Color.WhiteSmoke;
            this.fctb.Paddings = new System.Windows.Forms.Padding(10);
            this.fctb.RightBracket = ')';
            this.fctb.RightBracket2 = '}';
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb.ServiceColors")));
            this.fctb.Size = new System.Drawing.Size(900, 736);
            this.fctb.TabIndex = 0;
            this.fctb.Text = resources.GetString("fctb.Text");
            this.fctb.TextAreaBorder = FastColoredTextBoxNS.TextAreaBorderType.Shadow;
            this.fctb.TextAreaBorderColor = System.Drawing.Color.Gray;
            this.fctb.WordWrap = true;
            this.fctb.Zoom = 100;
            this.fctb.HintClick += new System.EventHandler<FastColoredTextBoxNS.HintClickEventArgs>(this.fctb_HintClick);
            // 
            // HintSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 897);
            this.Controls.Add(this.fctb);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "HintSample";
            this.Text = "HintSample";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.CheckBox cbInline;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbDock;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.CheckBox cbSimple;
        private System.Windows.Forms.Label label2;
    }
}