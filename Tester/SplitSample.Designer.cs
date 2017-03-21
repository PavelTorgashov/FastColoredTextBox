namespace Tester
{
    partial class SplitSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplitSample));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.fctbMaster = new FastColoredTextBoxNS.FastColoredTextBox();
            this.fctbSlave = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fctbMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctbSlave)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(610, 93);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 298);
            this.splitter1.MinSize = 0;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(610, 6);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // fctbMaster
            // 
            this.fctbMaster.AutoCompleteBracketsList = new char[] {
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
            this.fctbMaster.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctbMaster.AutoScrollMinSize = new System.Drawing.Size(284, 255);
            this.fctbMaster.BackBrush = null;
            this.fctbMaster.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctbMaster.CharHeight = 15;
            this.fctbMaster.CharWidth = 7;
            this.fctbMaster.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbMaster.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbMaster.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctbMaster.IsReplaceMode = false;
            this.fctbMaster.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctbMaster.LeftBracket = '(';
            this.fctbMaster.LeftBracket2 = '{';
            this.fctbMaster.Location = new System.Drawing.Point(0, 93);
            this.fctbMaster.Name = "fctbMaster";
            this.fctbMaster.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbMaster.RightBracket = ')';
            this.fctbMaster.RightBracket2 = '}';
            this.fctbMaster.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbMaster.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbMaster.ServiceColors")));
            this.fctbMaster.ShowCaretWhenInactive = true;
            this.fctbMaster.Size = new System.Drawing.Size(610, 205);
            this.fctbMaster.TabIndex = 0;
            this.fctbMaster.Text = resources.GetString("fctbMaster.Text");
            this.fctbMaster.Zoom = 100;
            // 
            // fctbSlave
            // 
            this.fctbSlave.AutoCompleteBracketsList = new char[] {
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
            this.fctbSlave.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctbSlave.AutoScrollMinSize = new System.Drawing.Size(0, 255);
            this.fctbSlave.BackBrush = null;
            this.fctbSlave.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctbSlave.CharHeight = 15;
            this.fctbSlave.CharWidth = 7;
            this.fctbSlave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbSlave.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbSlave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fctbSlave.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctbSlave.IsReplaceMode = false;
            this.fctbSlave.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctbSlave.LeftBracket = '(';
            this.fctbSlave.LeftBracket2 = '{';
            this.fctbSlave.Location = new System.Drawing.Point(0, 304);
            this.fctbSlave.Name = "fctbSlave";
            this.fctbSlave.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbSlave.RightBracket = ')';
            this.fctbSlave.RightBracket2 = '}';
            this.fctbSlave.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbSlave.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbSlave.ServiceColors")));
            this.fctbSlave.ShowCaretWhenInactive = true;
            this.fctbSlave.Size = new System.Drawing.Size(610, 166);
            this.fctbSlave.SourceTextBox = this.fctbMaster;
            this.fctbSlave.TabIndex = 1;
            this.fctbSlave.Text = resources.GetString("fctbSlave.Text");
            this.fctbSlave.WordWrap = true;
            this.fctbSlave.Zoom = 100;
            // 
            // SplitSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 470);
            this.Controls.Add(this.fctbMaster);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fctbSlave);
            this.Name = "SplitSample";
            this.Text = "SplitSample";
            ((System.ComponentModel.ISupportInitialize)(this.fctbMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctbSlave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctbMaster;
        private FastColoredTextBoxNS.FastColoredTextBox fctbSlave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
    }
}