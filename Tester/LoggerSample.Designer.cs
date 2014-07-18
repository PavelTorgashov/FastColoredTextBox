namespace Tester
{
    partial class LoggerSample
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
            this.label1 = new System.Windows.Forms.Label();
            this.btGotToEnd = new System.Windows.Forms.Button();
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "This example shows how to add text with predefined style.\r\nNote: It correctly wor" +
    "ks only for readonly mode.";
            // 
            // btGotToEnd
            // 
            this.btGotToEnd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btGotToEnd.Location = new System.Drawing.Point(0, 289);
            this.btGotToEnd.Name = "btGotToEnd";
            this.btGotToEnd.Size = new System.Drawing.Size(355, 23);
            this.btGotToEnd.TabIndex = 6;
            this.btGotToEnd.Text = "Go to end";
            this.btGotToEnd.UseVisualStyleBackColor = true;
            this.btGotToEnd.Click += new System.EventHandler(this.btGotToEnd_Click);
            // 
            // tm
            // 
            this.tm.Enabled = true;
            this.tm.Tick += new System.EventHandler(this.tm_Tick);
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
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 15;
            this.fctb.CharWidth = 7;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctb.IsReplaceMode = false;
            this.fctb.Location = new System.Drawing.Point(0, 40);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.ReadOnly = true;
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.Size = new System.Drawing.Size(355, 249);
            this.fctb.TabIndex = 5;
            this.fctb.Zoom = 100;
            // 
            // LoggerSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 312);
            this.Controls.Add(this.fctb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGotToEnd);
            this.Name = "LoggerSample";
            this.Text = "LoggerSample";
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.Button btGotToEnd;
        private System.Windows.Forms.Timer tm;
    }
}