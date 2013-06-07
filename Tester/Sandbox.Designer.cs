namespace Tester
{
    partial class Sandbox
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
            this.button1 = new System.Windows.Forms.Button();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fctb
            // 
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(0, 126);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 14;
            this.fctb.CharWidth = 8;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.IsReplaceMode = false;
            this.fctb.Location = new System.Drawing.Point(29, 31);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.Size = new System.Drawing.Size(413, 246);
            this.fctb.TabIndex = 0;
            this.fctb.Text = "This is questionnaire with input fields.\r\n\r\nYour Name: __________________________" +
    "_______\r\nYour Age: ___yo\r\nYour Height: ___cm\r\n\r\nYou can type into field, but oth" +
    "er text is readonly.\r\n";
            this.fctb.WordWrap = true;
            this.fctb.Zoom = 100;
            this.fctb.TextChanging += new System.EventHandler<FastColoredTextBoxNS.TextChangingEventArgs>(this.fctb_TextChanging);
            this.fctb.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctb_TextChangedDelayed);
            this.fctb.PaintLine += new System.EventHandler<FastColoredTextBoxNS.PaintLineEventArgs>(this.fctb_PaintLine);
            // 
            // Sandbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 314);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fctb);
            this.Name = "Sandbox";
            this.Text = "Sandbox";
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.Button button1;
    }
}