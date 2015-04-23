namespace Tester
{
    partial class LazyLoadingSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LazyLoadingSample));
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.ms = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllFoldingBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllCollapsedBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEmptyLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTestFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "txt";
            this.ofd.Filter = "Text file|*.txt|All files|*.*";
            // 
            // ms
            // 
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.createTestFileToolStripMenuItem});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(647, 24);
            this.ms.TabIndex = 1;
            this.ms.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpen,
            this.miSave,
            this.closeFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(166, 22);
            this.miOpen.Text = "Bind to file ...";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(166, 22);
            this.miSave.Text = "Save to file ...";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeFileToolStripMenuItem.Text = "Close binding file";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeFileToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapseAllFoldingBlocksToolStripMenuItem,
            this.expandAllCollapsedBlocksToolStripMenuItem,
            this.removeEmptyLinesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // collapseAllFoldingBlocksToolStripMenuItem
            // 
            this.collapseAllFoldingBlocksToolStripMenuItem.Name = "collapseAllFoldingBlocksToolStripMenuItem";
            this.collapseAllFoldingBlocksToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.collapseAllFoldingBlocksToolStripMenuItem.Text = "Collapse all folding blocks";
            this.collapseAllFoldingBlocksToolStripMenuItem.Click += new System.EventHandler(this.collapseAllFoldingBlocksToolStripMenuItem_Click);
            // 
            // expandAllCollapsedBlocksToolStripMenuItem
            // 
            this.expandAllCollapsedBlocksToolStripMenuItem.Name = "expandAllCollapsedBlocksToolStripMenuItem";
            this.expandAllCollapsedBlocksToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.expandAllCollapsedBlocksToolStripMenuItem.Text = "Expand all collapsed blocks";
            this.expandAllCollapsedBlocksToolStripMenuItem.Click += new System.EventHandler(this.expandAllCollapsedBlocksToolStripMenuItem_Click);
            // 
            // removeEmptyLinesToolStripMenuItem
            // 
            this.removeEmptyLinesToolStripMenuItem.Name = "removeEmptyLinesToolStripMenuItem";
            this.removeEmptyLinesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.removeEmptyLinesToolStripMenuItem.Text = "Remove empty lines";
            this.removeEmptyLinesToolStripMenuItem.Click += new System.EventHandler(this.removeEmptyLinesToolStripMenuItem_Click);
            // 
            // createTestFileToolStripMenuItem
            // 
            this.createTestFileToolStripMenuItem.Name = "createTestFileToolStripMenuItem";
            this.createTestFileToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.createTestFileToolStripMenuItem.Text = "Create test file";
            this.createTestFileToolStripMenuItem.Click += new System.EventHandler(this.createTestFileToolStripMenuItem_Click);
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "txt";
            this.sfd.Filter = "Text file|*.txt|All files|*.*";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(647, 62);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
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
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(480, 45);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 15;
            this.fctb.CharWidth = 7;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DelayedEventsInterval = 300;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctb.IsReplaceMode = false;
            this.fctb.Location = new System.Drawing.Point(0, 86);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb.ServiceColors")));
            this.fctb.Size = new System.Drawing.Size(647, 251);
            this.fctb.TabIndex = 0;
            this.fctb.Text = "Press \"Create test file\", select target directory and press Save.\r\nWill be create" +
    "d large file (approx. 50mb). \r\nThen bind file to the control in menu File/Bind t" +
    "o file.";
            this.fctb.Zoom = 100;
            this.fctb.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctb_TextChangedDelayed);
            this.fctb.VisibleRangeChangedDelayed += new System.EventHandler(this.fctb_VisibleRangeChangedDelayed);
            // 
            // LazyLoadingSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 337);
            this.Controls.Add(this.fctb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ms);
            this.MainMenuStrip = this.ms;
            this.Name = "LazyLoadingSample";
            this.Text = "LazyLoadingSample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LazyLoadingSample_FormClosing);
            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem closeFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.ToolStripMenuItem createTestFileToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseAllFoldingBlocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandAllCollapsedBlocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeEmptyLinesToolStripMenuItem;
    }
}