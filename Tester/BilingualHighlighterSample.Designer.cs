namespace Tester
{
    partial class BilingualHighlighterSample
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
            this.tb = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tb)).BeginInit();
            this.SuspendLayout();
            // 
            // tb
            // 
            this.tb.AllowDrop = true;
            this.tb.AutoScrollMinSize = new System.Drawing.Size(347, 154);
            this.tb.BackBrush = null;
            this.tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb.IsReplaceMode = false;
            this.tb.Location = new System.Drawing.Point(0, 0);
            this.tb.Name = "tb";
            this.tb.Paddings = new System.Windows.Forms.Padding(0);
            this.tb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tb.Size = new System.Drawing.Size(355, 321);
            this.tb.TabIndex = 0;
            this.tb.Text = "<html>\r\n <head></head>\r\n <body>\r\n <ul> \r\n  <?php for($i=1;$i<=5;$i++){ ?>\r\n  <li>" +
    "Menu Item <?php echo $i; ?></li> \r\n  <?php } ?>\r\n </ul> \r\n</body>\r\n</html>\r\n";
            this.tb.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.tb_TextChangedDelayed);
            // 
            // BilingualHighlighterSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 321);
            this.Controls.Add(this.tb);
            this.Name = "BilingualHighlighterSample";
            this.Text = "BilingualHighlighterSample";
            ((System.ComponentModel.ISupportInitialize)(this.tb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox tb;
    }
}