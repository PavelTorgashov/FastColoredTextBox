namespace Tester
{
    partial class CustomWordWrapSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomWordWrapSample));
            this.label1 = new System.Windows.Forms.Label();
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
            this.label1.Size = new System.Drawing.Size(468, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Here we make custom wordwrap.\r\nAny fragment starts with &, &&, |, || will be draw" +
    "n from new line.";
            this.label1.UseMnemonic = false;
            // 
            // fctb
            // 
            this.fctb.AutoIndent = false;
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(1271, 300);
            this.fctb.BackBrush = null;
            this.fctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fctb.CharHeight = 15;
            this.fctb.CharWidth = 7;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctb.IsReplaceMode = false;
            this.fctb.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctb.LeftBracket = '(';
            this.fctb.Location = new System.Drawing.Point(0, 42);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.RightBracket = ')';
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ServiceLinesColor = System.Drawing.Color.Gray;
            this.fctb.ShowFoldingLines = true;
            this.fctb.Size = new System.Drawing.Size(468, 358);
            this.fctb.TabIndex = 3;
            this.fctb.Text = resources.GetString("fctb.Text");
            this.fctb.WordWrap = true;
            this.fctb.WordWrapMode = FastColoredTextBoxNS.WordWrapMode.Custom;
            this.fctb.Zoom = 100;
            this.fctb.WordWrapNeeded += new System.EventHandler<FastColoredTextBoxNS.WordWrapNeededEventArgs>(this.fctb_WordWrapNeeded);
            // 
            // CustomWordWrapSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 400);
            this.Controls.Add(this.fctb);
            this.Controls.Add(this.label1);
            this.Name = "CustomWordWrapSample";
            this.Text = "CustomWordWrapSample";
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FastColoredTextBoxNS.FastColoredTextBox fctb;
    }
}