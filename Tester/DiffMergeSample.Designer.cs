namespace Tester
{
    partial class DiffMergeSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiffMergeSample));
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSecondFile = new System.Windows.Forms.TextBox();
            this.btSecond = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstFile = new System.Windows.Forms.TextBox();
            this.btFirst = new System.Windows.Forms.Button();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.btCompare = new System.Windows.Forms.Button();
            this.fctb1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.fctb2 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.fctb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctb2)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 415);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Deleted lines";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BackColor = System.Drawing.Color.Pink;
            this.label7.Location = new System.Drawing.Point(118, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = " ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Inserted lines";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BackColor = System.Drawing.Color.PaleGreen;
            this.label4.Location = new System.Drawing.Point(12, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Second file";
            // 
            // tbSecondFile
            // 
            this.tbSecondFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSecondFile.Location = new System.Drawing.Point(79, 37);
            this.tbSecondFile.Name = "tbSecondFile";
            this.tbSecondFile.Size = new System.Drawing.Size(497, 20);
            this.tbSecondFile.TabIndex = 19;
            // 
            // btSecond
            // 
            this.btSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSecond.Location = new System.Drawing.Point(582, 34);
            this.btSecond.Name = "btSecond";
            this.btSecond.Size = new System.Drawing.Size(30, 23);
            this.btSecond.TabIndex = 18;
            this.btSecond.Text = "...";
            this.btSecond.UseVisualStyleBackColor = true;
            this.btSecond.Click += new System.EventHandler(this.btSecond_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "First file";
            // 
            // tbFirstFile
            // 
            this.tbFirstFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFirstFile.Location = new System.Drawing.Point(79, 11);
            this.tbFirstFile.Name = "tbFirstFile";
            this.tbFirstFile.Size = new System.Drawing.Size(497, 20);
            this.tbFirstFile.TabIndex = 16;
            // 
            // btFirst
            // 
            this.btFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFirst.Location = new System.Drawing.Point(582, 8);
            this.btFirst.Name = "btFirst";
            this.btFirst.Size = new System.Drawing.Size(30, 23);
            this.btFirst.TabIndex = 15;
            this.btFirst.Text = "...";
            this.btFirst.UseVisualStyleBackColor = true;
            this.btFirst.Click += new System.EventHandler(this.btFirst_Click);
            // 
            // btCompare
            // 
            this.btCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCompare.Location = new System.Drawing.Point(537, 63);
            this.btCompare.Name = "btCompare";
            this.btCompare.Size = new System.Drawing.Size(75, 23);
            this.btCompare.TabIndex = 25;
            this.btCompare.Text = "Compare";
            this.btCompare.UseVisualStyleBackColor = true;
            this.btCompare.Click += new System.EventHandler(this.btCompare_Click);
            // 
            // fctb1
            // 
            this.fctb1.AutoCompleteBracketsList = new char[] {
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
            this.fctb1.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.fctb1.BackBrush = null;
            this.fctb1.CharHeight = 14;
            this.fctb1.CharWidth = 8;
            this.fctb1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb1.IsReplaceMode = false;
            this.fctb1.Location = new System.Drawing.Point(0, 0);
            this.fctb1.Name = "fctb1";
            this.fctb1.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb1.ReadOnly = true;
            this.fctb1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb1.ServiceColors")));
            this.fctb1.Size = new System.Drawing.Size(342, 311);
            this.fctb1.TabIndex = 26;
            this.fctb1.Text = "fastColoredTextBox1";
            this.fctb1.Zoom = 100;
            this.fctb1.SelectionChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            this.fctb1.VisibleRangeChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            // 
            // fctb2
            // 
            this.fctb2.AutoCompleteBracketsList = new char[] {
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
            this.fctb2.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.fctb2.BackBrush = null;
            this.fctb2.CharHeight = 14;
            this.fctb2.CharWidth = 8;
            this.fctb2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb2.IsReplaceMode = false;
            this.fctb2.Location = new System.Drawing.Point(0, 0);
            this.fctb2.Name = "fctb2";
            this.fctb2.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb2.ReadOnly = true;
            this.fctb2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb2.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb2.ServiceColors")));
            this.fctb2.Size = new System.Drawing.Size(352, 311);
            this.fctb2.TabIndex = 27;
            this.fctb2.Text = "fastColoredTextBox2";
            this.fctb2.Zoom = 100;
            this.fctb2.SelectionChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            this.fctb2.VisibleRangeChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 92);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fctb1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fctb2);
            this.splitContainer1.Size = new System.Drawing.Size(698, 311);
            this.splitContainer1.SplitterDistance = 342;
            this.splitContainer1.TabIndex = 28;
            // 
            // DiffMergeSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 437);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btCompare);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSecondFile);
            this.Controls.Add(this.btSecond);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFirstFile);
            this.Controls.Add(this.btFirst);
            this.Name = "DiffMergeSample";
            this.Text = "DiffMergeSample";
            ((System.ComponentModel.ISupportInitialize)(this.fctb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctb2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSecondFile;
        private System.Windows.Forms.Button btSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFirstFile;
        private System.Windows.Forms.Button btFirst;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Button btCompare;
        private FastColoredTextBoxNS.FastColoredTextBox fctb1;
        private FastColoredTextBoxNS.FastColoredTextBox fctb2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}