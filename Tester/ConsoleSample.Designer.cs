namespace Tester
{
    partial class ConsoleSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleSample));
            this.label2 = new System.Windows.Forms.Label();
            this.consoleTextBox1 = new Tester.ConsoleTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.consoleTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(737, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // consoleTextBox1
            // 
            this.consoleTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleTextBox1.AutoCompleteBracketsList = new char[] {
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
            this.consoleTextBox1.AutoScrollMinSize = new System.Drawing.Size(585, 15);
            this.consoleTextBox1.BackBrush = null;
            this.consoleTextBox1.BackColor = System.Drawing.Color.Black;
            this.consoleTextBox1.CaretColor = System.Drawing.Color.White;
            this.consoleTextBox1.CharHeight = 15;
            this.consoleTextBox1.CharWidth = 7;
            this.consoleTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.consoleTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.consoleTextBox1.FoldingIndicatorColor = System.Drawing.Color.Gold;
            this.consoleTextBox1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.consoleTextBox1.ForeColor = System.Drawing.Color.White;
            this.consoleTextBox1.IndentBackColor = System.Drawing.Color.Black;
            this.consoleTextBox1.IsReadLineMode = false;
            this.consoleTextBox1.IsReplaceMode = false;
            this.consoleTextBox1.LineNumberColor = System.Drawing.Color.Gold;
            this.consoleTextBox1.Location = new System.Drawing.Point(12, 41);
            this.consoleTextBox1.Name = "consoleTextBox1";
            this.consoleTextBox1.PaddingBackColor = System.Drawing.Color.Black;
            this.consoleTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.consoleTextBox1.PreferredLineWidth = 80;
            this.consoleTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.consoleTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("consoleTextBox1.ServiceColors")));
            this.consoleTextBox1.ServiceLinesColor = System.Drawing.Color.DimGray;
            this.consoleTextBox1.Size = new System.Drawing.Size(713, 342);
            this.consoleTextBox1.TabIndex = 0;
            this.consoleTextBox1.WordWrap = true;
            this.consoleTextBox1.WordWrapMode = FastColoredTextBoxNS.WordWrapMode.CharWrapPreferredWidth;
            this.consoleTextBox1.Zoom = 100;
            // 
            // ConsoleSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 395);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.consoleTextBox1);
            this.Name = "ConsoleSample";
            this.Text = "ConsoleSample";
            ((System.ComponentModel.ISupportInitialize)(this.consoleTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ConsoleTextBox consoleTextBox1;
        private System.Windows.Forms.Label label2;

    }
}