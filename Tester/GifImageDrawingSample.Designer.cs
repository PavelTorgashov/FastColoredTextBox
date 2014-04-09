namespace Tester
{
    partial class GifImageDrawingSample
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
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // fctb
            // 
            this.fctb.AutoCompleteBrackets = false;
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
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(0, 198);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 22;
            this.fctb.CharWidth = 10;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fctb.IsReplaceMode = false;
            this.fctb.Location = new System.Drawing.Point(0, 0);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ShowLineNumbers = false;
            this.fctb.Size = new System.Drawing.Size(314, 262);
            this.fctb.TabIndex = 1;
            this.fctb.Text = "This example draws smile image instead of text smile\r\n: + D  = :D\r\n: + @ = :@\r\n8 " +
    "+ ) = 8)\r\n: + bb = :bb\r\n: + ) = :)\r\n: + ( = :(\r\n";
            this.fctb.WordWrap = true;
            this.fctb.Zoom = 100;
            this.fctb.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctb_TextChanged);
            // 
            // GifImageDrawingSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 262);
            this.Controls.Add(this.fctb);
            this.Name = "GifImageDrawingSample";
            this.Text = "GifImageDrawingSample";
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctb;
    }
}