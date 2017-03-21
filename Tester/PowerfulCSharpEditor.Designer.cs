namespace Tester
{
    partial class PowerfulCSharpEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerfulCSharpEditor));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lbWordUnderMouse = new System.Windows.Forms.ToolStripStatusLabel();
            this.btZoom = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.btInvisibleChars = new System.Windows.Forms.ToolStripButton();
            this.btHighlightCurrentLine = new System.Windows.Forms.ToolStripButton();
            this.btShowFoldingLines = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.undoStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.backStripButton = new System.Windows.Forms.ToolStripButton();
            this.forwardStripButton = new System.Windows.Forms.ToolStripButton();
            this.tbFind = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.bookmarkPlusButton = new System.Windows.Forms.ToolStripButton();
            this.bookmarkMinusButton = new System.Windows.Forms.ToolStripButton();
            this.gotoButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFiles = new FarsiLibrary.Win.FATabStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.sfdMain = new System.Windows.Forms.SaveFileDialog();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.cmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.autoIndentSelectedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncommentSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneLinesAndCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmUpdateInterface = new System.Windows.Forms.Timer(this.components);
            this.dgvObjectExplorer = new System.Windows.Forms.DataGridView();
            this.clImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ilAutocomplete = new System.Windows.Forms.ImageList(this.components);
            this.msMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsFiles)).BeginInit();
            this.cmMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(769, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as ...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbWordUnderMouse,
            this.btZoom});
            this.ssMain.Location = new System.Drawing.Point(0, 307);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(769, 22);
            this.ssMain.TabIndex = 2;
            this.ssMain.Text = "statusStrip1";
            // 
            // lbWordUnderMouse
            // 
            this.lbWordUnderMouse.AutoSize = false;
            this.lbWordUnderMouse.ForeColor = System.Drawing.Color.Gray;
            this.lbWordUnderMouse.Name = "lbWordUnderMouse";
            this.lbWordUnderMouse.Size = new System.Drawing.Size(699, 17);
            this.lbWordUnderMouse.Spring = true;
            this.lbWordUnderMouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btZoom
            // 
            this.btZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11,
            this.toolStripMenuItem10,
            this.toolStripMenuItem9,
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
            this.toolStripMenuItem6});
            this.btZoom.Image = ((System.Drawing.Image)(resources.GetObject("btZoom.Image")));
            this.btZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btZoom.Name = "btZoom";
            this.btZoom.Size = new System.Drawing.Size(55, 20);
            this.btZoom.Text = "Zoom";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem11.Tag = "300";
            this.toolStripMenuItem11.Text = "300%";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem10.Tag = "200";
            this.toolStripMenuItem10.Text = "200%";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem9.Tag = "150";
            this.toolStripMenuItem9.Text = "150%";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem8.Tag = "100";
            this.toolStripMenuItem8.Text = "100%";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem7.Tag = "50";
            this.toolStripMenuItem7.Text = "50%";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem6.Tag = "25";
            this.toolStripMenuItem6.Text = "25%";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.Zoom_click);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator3,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.btInvisibleChars,
            this.btHighlightCurrentLine,
            this.btShowFoldingLines,
            this.toolStripSeparator4,
            this.undoStripButton,
            this.redoStripButton,
            this.toolStripSeparator5,
            this.backStripButton,
            this.forwardStripButton,
            this.tbFind,
            this.toolStripLabel1,
            this.toolStripSeparator6,
            this.bookmarkPlusButton,
            this.bookmarkMinusButton,
            this.gotoButton});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(769, 25);
            this.tsMain.TabIndex = 3;
            this.tsMain.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // btInvisibleChars
            // 
            this.btInvisibleChars.CheckOnClick = true;
            this.btInvisibleChars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btInvisibleChars.Image = ((System.Drawing.Image)(resources.GetObject("btInvisibleChars.Image")));
            this.btInvisibleChars.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btInvisibleChars.Name = "btInvisibleChars";
            this.btInvisibleChars.Size = new System.Drawing.Size(23, 22);
            this.btInvisibleChars.Text = "¶";
            this.btInvisibleChars.ToolTipText = "Show invisible chars";
            this.btInvisibleChars.Click += new System.EventHandler(this.btInvisibleChars_Click);
            // 
            // btHighlightCurrentLine
            // 
            this.btHighlightCurrentLine.CheckOnClick = true;
            this.btHighlightCurrentLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btHighlightCurrentLine.Image = global::Tester.Properties.Resources.edit_padding_top;
            this.btHighlightCurrentLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btHighlightCurrentLine.Name = "btHighlightCurrentLine";
            this.btHighlightCurrentLine.Size = new System.Drawing.Size(23, 22);
            this.btHighlightCurrentLine.Text = "Highlight current line";
            this.btHighlightCurrentLine.ToolTipText = "Highlight current line";
            this.btHighlightCurrentLine.Click += new System.EventHandler(this.btHighlightCurrentLine_Click);
            // 
            // btShowFoldingLines
            // 
            this.btShowFoldingLines.Checked = true;
            this.btShowFoldingLines.CheckOnClick = true;
            this.btShowFoldingLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btShowFoldingLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btShowFoldingLines.Image = ((System.Drawing.Image)(resources.GetObject("btShowFoldingLines.Image")));
            this.btShowFoldingLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btShowFoldingLines.Name = "btShowFoldingLines";
            this.btShowFoldingLines.Size = new System.Drawing.Size(23, 22);
            this.btShowFoldingLines.Text = "Show folding lines";
            this.btShowFoldingLines.Click += new System.EventHandler(this.btShowFoldingLines_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // undoStripButton
            // 
            this.undoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoStripButton.Image = global::Tester.Properties.Resources.undo_16x16;
            this.undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoStripButton.Name = "undoStripButton";
            this.undoStripButton.Size = new System.Drawing.Size(23, 22);
            this.undoStripButton.Text = "Undo (Ctrl+Z)";
            this.undoStripButton.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoStripButton
            // 
            this.redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoStripButton.Image = global::Tester.Properties.Resources.redo_16x16;
            this.redoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoStripButton.Name = "redoStripButton";
            this.redoStripButton.Size = new System.Drawing.Size(23, 22);
            this.redoStripButton.Text = "Redo (Ctrl+R)";
            this.redoStripButton.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // backStripButton
            // 
            this.backStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backStripButton.Image = global::Tester.Properties.Resources.backward0_16x16;
            this.backStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backStripButton.Name = "backStripButton";
            this.backStripButton.Size = new System.Drawing.Size(23, 22);
            this.backStripButton.Text = "Navigate Backward (Ctrl+ -)";
            this.backStripButton.Click += new System.EventHandler(this.backStripButton_Click);
            // 
            // forwardStripButton
            // 
            this.forwardStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardStripButton.Image = global::Tester.Properties.Resources.forward_16x16;
            this.forwardStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardStripButton.Name = "forwardStripButton";
            this.forwardStripButton.Size = new System.Drawing.Size(23, 22);
            this.forwardStripButton.Text = "Navigate Forward (Ctrl+Shift+ -)";
            this.forwardStripButton.Click += new System.EventHandler(this.forwardStripButton_Click);
            // 
            // tbFind
            // 
            this.tbFind.AcceptsReturn = true;
            this.tbFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(100, 25);
            this.tbFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFind_KeyPress);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "Find: ";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // bookmarkPlusButton
            // 
            this.bookmarkPlusButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bookmarkPlusButton.Image = global::Tester.Properties.Resources.layer__plus;
            this.bookmarkPlusButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bookmarkPlusButton.Name = "bookmarkPlusButton";
            this.bookmarkPlusButton.Size = new System.Drawing.Size(23, 22);
            this.bookmarkPlusButton.Text = "Add bookmark (Ctrl-B)";
            this.bookmarkPlusButton.Click += new System.EventHandler(this.bookmarkPlusButton_Click);
            // 
            // bookmarkMinusButton
            // 
            this.bookmarkMinusButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bookmarkMinusButton.Image = global::Tester.Properties.Resources.layer__minus;
            this.bookmarkMinusButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bookmarkMinusButton.Name = "bookmarkMinusButton";
            this.bookmarkMinusButton.Size = new System.Drawing.Size(23, 22);
            this.bookmarkMinusButton.Text = "Remove bookmark (Ctrl-Shift-B)";
            this.bookmarkMinusButton.Click += new System.EventHandler(this.bookmarkMinusButton_Click);
            // 
            // gotoButton
            // 
            this.gotoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gotoButton.Image = ((System.Drawing.Image)(resources.GetObject("gotoButton.Image")));
            this.gotoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gotoButton.Name = "gotoButton";
            this.gotoButton.Size = new System.Drawing.Size(55, 22);
            this.gotoButton.Text = "Goto...";
            this.gotoButton.DropDownOpening += new System.EventHandler(this.gotoButton_DropDownOpening);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsFiles
            // 
            this.tsFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsFiles.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsFiles.Location = new System.Drawing.Point(175, 49);
            this.tsFiles.Name = "tsFiles";
            this.tsFiles.Size = new System.Drawing.Size(594, 258);
            this.tsFiles.TabIndex = 0;
            this.tsFiles.Text = "faTabStrip1";
            this.tsFiles.TabStripItemClosing += new FarsiLibrary.Win.TabStripItemClosingHandler(this.tsFiles_TabStripItemClosing);
            this.tsFiles.TabStripItemSelectionChanged += new FarsiLibrary.Win.TabStripItemChangedHandler(this.tsFiles_TabStripItemSelectionChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(172, 49);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 258);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // sfdMain
            // 
            this.sfdMain.DefaultExt = "cs";
            this.sfdMain.Filter = "C# file(*.cs)|*.cs";
            // 
            // ofdMain
            // 
            this.ofdMain.DefaultExt = "cs";
            this.ofdMain.Filter = "C# file(*.cs)|*.cs";
            // 
            // cmMain
            // 
            this.cmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem3,
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.toolStripMenuItem4,
            this.autoIndentSelectedTextToolStripMenuItem,
            this.commentSelectedToolStripMenuItem,
            this.uncommentSelectedToolStripMenuItem,
            this.cloneLinesToolStripMenuItem,
            this.cloneLinesAndCommentToolStripMenuItem});
            this.cmMain.Name = "cmMain";
            this.cmMain.Size = new System.Drawing.Size(219, 308);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(215, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::Tester.Properties.Resources.undo_16x16;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = global::Tester.Properties.Resources.redo_16x16;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(215, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(215, 6);
            // 
            // autoIndentSelectedTextToolStripMenuItem
            // 
            this.autoIndentSelectedTextToolStripMenuItem.Name = "autoIndentSelectedTextToolStripMenuItem";
            this.autoIndentSelectedTextToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.autoIndentSelectedTextToolStripMenuItem.Text = "AutoIndent selected text";
            this.autoIndentSelectedTextToolStripMenuItem.Click += new System.EventHandler(this.autoIndentSelectedTextToolStripMenuItem_Click);
            // 
            // commentSelectedToolStripMenuItem
            // 
            this.commentSelectedToolStripMenuItem.Name = "commentSelectedToolStripMenuItem";
            this.commentSelectedToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.commentSelectedToolStripMenuItem.Text = "Comment selected";
            this.commentSelectedToolStripMenuItem.Click += new System.EventHandler(this.commentSelectedToolStripMenuItem_Click);
            // 
            // uncommentSelectedToolStripMenuItem
            // 
            this.uncommentSelectedToolStripMenuItem.Name = "uncommentSelectedToolStripMenuItem";
            this.uncommentSelectedToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.uncommentSelectedToolStripMenuItem.Text = "Uncomment selected";
            this.uncommentSelectedToolStripMenuItem.Click += new System.EventHandler(this.uncommentSelectedToolStripMenuItem_Click);
            // 
            // cloneLinesToolStripMenuItem
            // 
            this.cloneLinesToolStripMenuItem.Name = "cloneLinesToolStripMenuItem";
            this.cloneLinesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.cloneLinesToolStripMenuItem.Text = "Clone line(s)";
            this.cloneLinesToolStripMenuItem.Click += new System.EventHandler(this.cloneLinesToolStripMenuItem_Click);
            // 
            // cloneLinesAndCommentToolStripMenuItem
            // 
            this.cloneLinesAndCommentToolStripMenuItem.Name = "cloneLinesAndCommentToolStripMenuItem";
            this.cloneLinesAndCommentToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.cloneLinesAndCommentToolStripMenuItem.Text = "Clone line(s) and comment";
            this.cloneLinesAndCommentToolStripMenuItem.Click += new System.EventHandler(this.cloneLinesAndCommentToolStripMenuItem_Click);
            // 
            // tmUpdateInterface
            // 
            this.tmUpdateInterface.Enabled = true;
            this.tmUpdateInterface.Interval = 400;
            this.tmUpdateInterface.Tick += new System.EventHandler(this.tmUpdateInterface_Tick);
            // 
            // dgvObjectExplorer
            // 
            this.dgvObjectExplorer.AllowUserToAddRows = false;
            this.dgvObjectExplorer.AllowUserToDeleteRows = false;
            this.dgvObjectExplorer.AllowUserToResizeColumns = false;
            this.dgvObjectExplorer.AllowUserToResizeRows = false;
            this.dgvObjectExplorer.BackgroundColor = System.Drawing.Color.White;
            this.dgvObjectExplorer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvObjectExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjectExplorer.ColumnHeadersVisible = false;
            this.dgvObjectExplorer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clImage,
            this.clName});
            this.dgvObjectExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvObjectExplorer.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvObjectExplorer.GridColor = System.Drawing.Color.White;
            this.dgvObjectExplorer.Location = new System.Drawing.Point(0, 49);
            this.dgvObjectExplorer.MultiSelect = false;
            this.dgvObjectExplorer.Name = "dgvObjectExplorer";
            this.dgvObjectExplorer.ReadOnly = true;
            this.dgvObjectExplorer.RowHeadersVisible = false;
            this.dgvObjectExplorer.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvObjectExplorer.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvObjectExplorer.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Green;
            this.dgvObjectExplorer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvObjectExplorer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObjectExplorer.Size = new System.Drawing.Size(172, 258);
            this.dgvObjectExplorer.TabIndex = 6;
            this.dgvObjectExplorer.VirtualMode = true;
            this.dgvObjectExplorer.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvObjectExplorer_CellMouseDoubleClick);
            this.dgvObjectExplorer.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvObjectExplorer_CellValueNeeded);
            // 
            // clImage
            // 
            this.clImage.HeaderText = "Column2";
            this.clImage.MinimumWidth = 32;
            this.clImage.Name = "clImage";
            this.clImage.ReadOnly = true;
            this.clImage.Width = 32;
            // 
            // clName
            // 
            this.clName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clName.HeaderText = "Column1";
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            // 
            // ilAutocomplete
            // 
            this.ilAutocomplete.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilAutocomplete.ImageStream")));
            this.ilAutocomplete.TransparentColor = System.Drawing.Color.Transparent;
            this.ilAutocomplete.Images.SetKeyName(0, "script_16x16.png");
            this.ilAutocomplete.Images.SetKeyName(1, "app_16x16.png");
            this.ilAutocomplete.Images.SetKeyName(2, "1302166543_virtualbox.png");
            // 
            // PowerfulCSharpEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 329);
            this.Controls.Add(this.tsFiles);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dgvObjectExplorer);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.Controls.Add(this.ssMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "PowerfulCSharpEditor";
            this.Text = "PowerfulCSharpEditor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PowerfulCSharpEditor_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsFiles)).EndInit();
            this.cmMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectExplorer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private FarsiLibrary.Win.FATabStrip tsFiles;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SaveFileDialog sfdMain;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.ContextMenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Timer tmUpdateInterface;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton undoStripButton;
        private System.Windows.Forms.ToolStripButton redoStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox tbFind;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvObjectExplorer;
        private System.Windows.Forms.ToolStripButton backStripButton;
        private System.Windows.Forms.ToolStripButton forwardStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.DataGridViewImageColumn clImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.ToolStripStatusLabel lbWordUnderMouse;
        private System.Windows.Forms.ImageList ilAutocomplete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem autoIndentSelectedTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btInvisibleChars;
        private System.Windows.Forms.ToolStripButton btHighlightCurrentLine;
        private System.Windows.Forms.ToolStripMenuItem commentSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncommentSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneLinesAndCommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton bookmarkPlusButton;
        private System.Windows.Forms.ToolStripButton bookmarkMinusButton;
        private System.Windows.Forms.ToolStripDropDownButton gotoButton;
        private System.Windows.Forms.ToolStripButton btShowFoldingLines;
        private System.Windows.Forms.ToolStripSplitButton btZoom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    }
}