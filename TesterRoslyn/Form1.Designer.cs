namespace TesterRoslyn
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.uxProject = new System.Windows.Forms.ListBox();
            this.uxMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.uxFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.uxEditor = new FastColoredTextBoxNS.FastColoredTextBox();
            this.uxFileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // uxProject
            // 
            this.uxProject.Dock = System.Windows.Forms.DockStyle.Left;
            this.uxProject.FormattingEnabled = true;
            this.uxProject.ItemHeight = 25;
            this.uxProject.Location = new System.Drawing.Point(0, 42);
            this.uxProject.Margin = new System.Windows.Forms.Padding(4);
            this.uxProject.Name = "uxProject";
            this.uxProject.Size = new System.Drawing.Size(213, 792);
            this.uxProject.TabIndex = 0;
            this.uxProject.SelectedIndexChanged += new System.EventHandler(this.uxProject_SelectedIndexChanged);
            // 
            // uxMenu
            // 
            this.uxMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.uxMenu.Location = new System.Drawing.Point(0, 0);
            this.uxMenu.Name = "uxMenu";
            this.uxMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.uxMenu.Size = new System.Drawing.Size(1287, 42);
            this.uxMenu.TabIndex = 2;
            this.uxMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxFileOpen,
            this.uxFileSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // uxFileOpen
            // 
            this.uxFileOpen.Name = "uxFileOpen";
            this.uxFileOpen.Size = new System.Drawing.Size(269, 38);
            this.uxFileOpen.Text = "&Open...";
            this.uxFileOpen.Click += new System.EventHandler(this.uxFileOpen_Click);
            // 
            // uxFileSave
            // 
            this.uxFileSave.Name = "uxFileSave";
            this.uxFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.uxFileSave.Size = new System.Drawing.Size(269, 38);
            this.uxFileSave.Text = "&Save";
            this.uxFileSave.Click += new System.EventHandler(this.uxFileSave_Click);
            // 
            // uxEditor
            // 
            this.uxEditor.AutoCompleteBracketsList = new char[] {
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
            this.uxEditor.AutoScrollMinSize = new System.Drawing.Size(43, 29);
            this.uxEditor.BackBrush = null;
            this.uxEditor.CharHeight = 29;
            this.uxEditor.CharWidth = 16;
            this.uxEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uxEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.uxEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxEditor.IsReplaceMode = false;
            this.uxEditor.Location = new System.Drawing.Point(213, 42);
            this.uxEditor.Margin = new System.Windows.Forms.Padding(4);
            this.uxEditor.Name = "uxEditor";
            this.uxEditor.Paddings = new System.Windows.Forms.Padding(0);
            this.uxEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.uxEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("uxEditor.ServiceColors")));
            this.uxEditor.Size = new System.Drawing.Size(1074, 792);
            this.uxEditor.TabIndex = 5;
            this.uxEditor.Zoom = 100;
            this.uxEditor.ToolTipNeeded += new System.EventHandler<FastColoredTextBoxNS.ToolTipNeededEventArgs>(this.uxEditor_ToolTipNeeded);
            this.uxEditor.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.uxEditor_TextChanged);
            this.uxEditor.VisibleRangeChanged += new System.EventHandler(this.uxEditor_VisibleRangeChanged);
            this.uxEditor.LineInserted += new System.EventHandler<FastColoredTextBoxNS.LineInsertedEventArgs>(this.uxEditor_LineInserted);
            this.uxEditor.LineRemoved += new System.EventHandler<FastColoredTextBoxNS.LineRemovedEventArgs>(this.uxEditor_LineRemoved);
            // 
            // uxFileOpenDialog
            // 
            this.uxFileOpenDialog.AddExtension = false;
            this.uxFileOpenDialog.DefaultExt = "csproj";
            this.uxFileOpenDialog.FileName = "openFileDialog1";
            this.uxFileOpenDialog.Filter = "Projects (*.csproj)|*.csproj|Solutions (*.sln)|*.sln";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1287, 834);
            this.Controls.Add(this.uxEditor);
            this.Controls.Add(this.uxProject);
            this.Controls.Add(this.uxMenu);
            this.MainMenuStrip = this.uxMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "TesterRoslyn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.uxMenu.ResumeLayout(false);
            this.uxMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox uxProject;
        private System.Windows.Forms.MenuStrip uxMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxFileOpen;
        private System.Windows.Forms.ToolStripMenuItem uxFileSave;
        private FastColoredTextBoxNS.FastColoredTextBox uxEditor;
        private System.Windows.Forms.OpenFileDialog uxFileOpenDialog;
    }
}

