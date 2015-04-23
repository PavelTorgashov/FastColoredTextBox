namespace Tester
{
    partial class MarkerToolSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkerToolSample));
            this.cmMark = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markAsYellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsRedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.markLineBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearMarkedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.cmMark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // cmMark
            // 
            this.cmMark.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markAsYellowToolStripMenuItem,
            this.markAsRedToolStripMenuItem,
            this.markAsGreenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.markLineBackgroundToolStripMenuItem,
            this.toolStripMenuItem2,
            this.clearMarkedToolStripMenuItem});
            this.cmMark.Name = "contextMenuStrip1";
            this.cmMark.Size = new System.Drawing.Size(191, 126);
            // 
            // markAsYellowToolStripMenuItem
            // 
            this.markAsYellowToolStripMenuItem.Name = "markAsYellowToolStripMenuItem";
            this.markAsYellowToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.markAsYellowToolStripMenuItem.Tag = "yellow";
            this.markAsYellowToolStripMenuItem.Text = "Mark as Yellow";
            this.markAsYellowToolStripMenuItem.Click += new System.EventHandler(this.markAsYellowToolStripMenuItem_Click);
            // 
            // markAsRedToolStripMenuItem
            // 
            this.markAsRedToolStripMenuItem.Name = "markAsRedToolStripMenuItem";
            this.markAsRedToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.markAsRedToolStripMenuItem.Tag = "red";
            this.markAsRedToolStripMenuItem.Text = "Mark as Red";
            this.markAsRedToolStripMenuItem.Click += new System.EventHandler(this.markAsYellowToolStripMenuItem_Click);
            // 
            // markAsGreenToolStripMenuItem
            // 
            this.markAsGreenToolStripMenuItem.Name = "markAsGreenToolStripMenuItem";
            this.markAsGreenToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.markAsGreenToolStripMenuItem.Tag = "green";
            this.markAsGreenToolStripMenuItem.Text = "Mark as Green";
            this.markAsGreenToolStripMenuItem.Click += new System.EventHandler(this.markAsYellowToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // markLineBackgroundToolStripMenuItem
            // 
            this.markLineBackgroundToolStripMenuItem.Name = "markLineBackgroundToolStripMenuItem";
            this.markLineBackgroundToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.markLineBackgroundToolStripMenuItem.Tag = "lineBackground";
            this.markLineBackgroundToolStripMenuItem.Text = "Mark line background";
            this.markLineBackgroundToolStripMenuItem.Click += new System.EventHandler(this.markAsYellowToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 6);
            // 
            // clearMarkedToolStripMenuItem
            // 
            this.clearMarkedToolStripMenuItem.Name = "clearMarkedToolStripMenuItem";
            this.clearMarkedToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.clearMarkedToolStripMenuItem.Text = "Clear marked";
            this.clearMarkedToolStripMenuItem.Click += new System.EventHandler(this.clearMarkedToolStripMenuItem_Click);
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
            this.fctb.AutoIndent = false;
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(0, 105);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 15;
            this.fctb.CharWidth = 7;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DelayedEventsInterval = 500;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctb.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fctb.IsReplaceMode = false;
            this.fctb.LeftBracket = '(';
            this.fctb.LeftPadding = 15;
            this.fctb.Location = new System.Drawing.Point(0, 0);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.RightBracket = ')';
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb.ServiceColors")));
            this.fctb.Size = new System.Drawing.Size(447, 262);
            this.fctb.TabIndex = 0;
            this.fctb.Text = resources.GetString("fctb.Text");
            this.fctb.WordWrap = true;
            this.fctb.Zoom = 100;
            this.fctb.SelectionChangedDelayed += new System.EventHandler(this.fctb_SelectionChangedDelayed);
            this.fctb.VisualMarkerClick += new System.EventHandler<FastColoredTextBoxNS.VisualMarkerEventArgs>(this.fctb_VisualMarkerClick);
            this.fctb.PaintLine += new System.EventHandler<FastColoredTextBoxNS.PaintLineEventArgs>(this.fctb_PaintLine);
            this.fctb.Resize += new System.EventHandler(this.fctb_Resize);
            // 
            // MarkerToolSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 262);
            this.Controls.Add(this.fctb);
            this.Name = "MarkerToolSample";
            this.Text = "MarkerTool Sample";
            this.cmMark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.ContextMenuStrip cmMark;
        private System.Windows.Forms.ToolStripMenuItem markAsYellowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markAsRedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markAsGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearMarkedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markLineBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}