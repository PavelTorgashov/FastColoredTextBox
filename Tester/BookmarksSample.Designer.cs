namespace Tester
{
    partial class BookmarksSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookmarksSample));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btAddBookmark = new System.Windows.Forms.ToolStripButton();
            this.btRemoveBookmark = new System.Windows.Forms.ToolStripButton();
            this.btGo = new System.Windows.Forms.ToolStripDropDownButton();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAddBookmark,
            this.btRemoveBookmark,
            this.btGo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 38);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(487, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btAddBookmark
            // 
            this.btAddBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btAddBookmark.Image = ((System.Drawing.Image)(resources.GetObject("btAddBookmark.Image")));
            this.btAddBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAddBookmark.Name = "btAddBookmark";
            this.btAddBookmark.Size = new System.Drawing.Size(90, 22);
            this.btAddBookmark.Text = "Add bookmark";
            this.btAddBookmark.Click += new System.EventHandler(this.btAddBookmark_Click);
            // 
            // btRemoveBookmark
            // 
            this.btRemoveBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btRemoveBookmark.Image = ((System.Drawing.Image)(resources.GetObject("btRemoveBookmark.Image")));
            this.btRemoveBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btRemoveBookmark.Name = "btRemoveBookmark";
            this.btRemoveBookmark.Size = new System.Drawing.Size(111, 22);
            this.btRemoveBookmark.Text = "Remove bookmark";
            this.btRemoveBookmark.Click += new System.EventHandler(this.btRemoveBookmark_Click);
            // 
            // btGo
            // 
            this.btGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btGo.Image = ((System.Drawing.Image)(resources.GetObject("btGo.Image")));
            this.btGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(61, 22);
            this.btGo.Text = "Go to ...";
            this.btGo.DropDownOpening += new System.EventHandler(this.btGo_DropDownOpening);
            // 
            // fctb
            // 
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(0, 4065);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 15;
            this.fctb.CharWidth = 7;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DelayedEventsInterval = 500;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fctb.IsReplaceMode = false;
            this.fctb.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctb.LeftBracket = '(';
            this.fctb.LeftPadding = 17;
            this.fctb.Location = new System.Drawing.Point(0, 63);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.RightBracket = ')';
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.Size = new System.Drawing.Size(487, 235);
            this.fctb.TabIndex = 0;
            this.fctb.Text = resources.GetString("fctb.Text");
            this.fctb.WordWrap = true;
            this.fctb.Zoom = 100;
            this.fctb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fctb_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(487, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "This example shows bookmarks. You can use menu or hot keys: Ctrl-B, Ctrl-Shift-B," +
    " Ctrl-N";
            // 
            // BookmarksSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 298);
            this.Controls.Add(this.fctb);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Name = "BookmarksSample";
            this.Text = "Bookmarks Sample";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btAddBookmark;
        private System.Windows.Forms.ToolStripButton btRemoveBookmark;
        private System.Windows.Forms.ToolStripDropDownButton btGo;
        private System.Windows.Forms.Label label2;
    }
}