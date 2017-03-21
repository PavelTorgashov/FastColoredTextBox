namespace Tester
{
    partial class Sandbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sandbox));
            this.button1 = new System.Windows.Forms.Button();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.myFCTB1 = new Tester.MyFCTB();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myFCTB1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 14;
            this.fctb.CharWidth = 8;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.IsReplaceMode = false;
            this.fctb.Location = new System.Drawing.Point(147, 36);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb.ServiceColors")));
            this.fctb.Size = new System.Drawing.Size(408, 209);
            this.fctb.TabIndex = 1;
            this.fctb.Text = "fastColoredTextBox1";
            this.fctb.Zoom = 100;
            // 
            // myFCTB1
            // 
            this.myFCTB1.AutoCompleteBracketsList = new char[] {
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
            this.myFCTB1.AutoScrollMinSize = new System.Drawing.Size(83, 14);
            this.myFCTB1.BackBrush = null;
            this.myFCTB1.CharHeight = 14;
            this.myFCTB1.CharWidth = 8;
            this.myFCTB1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.myFCTB1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.myFCTB1.IsReplaceMode = false;
            this.myFCTB1.Location = new System.Drawing.Point(78, 89);
            this.myFCTB1.Name = "myFCTB1";
            this.myFCTB1.Paddings = new System.Windows.Forms.Padding(0);
            this.myFCTB1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.myFCTB1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("myFCTB1.ServiceColors")));
            this.myFCTB1.Size = new System.Drawing.Size(442, 213);
            this.myFCTB1.TabIndex = 2;
            this.myFCTB1.Text = "myFCTB1";
            this.myFCTB1.Zoom = 100;
            // 
            // Sandbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 314);
            this.Controls.Add(this.myFCTB1);
            this.Controls.Add(this.fctb);
            this.Controls.Add(this.button1);
            this.Name = "Sandbox";
            this.Text = "Sandbox";
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myFCTB1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private MyFCTB myFCTB1;







    }
}