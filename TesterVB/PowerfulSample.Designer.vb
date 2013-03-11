<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PowerfulSample
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.findToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.replaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miLanguage = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCSharp = New System.Windows.Forms.ToolStripMenuItem()
        Me.miVB = New System.Windows.Forms.ToolStripMenuItem()
        Me.hTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.sQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pHPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.hTMLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.FastColoredTextBox1 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.menuStrip1.SuspendLayout()
        CType(Me.FastColoredTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.editToolStripMenuItem, Me.miLanguage, Me.exportToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(362, 24)
        Me.menuStrip1.TabIndex = 5
        Me.menuStrip1.Text = "menuStrip1"
        '
        'editToolStripMenuItem
        '
        Me.editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.findToolStripMenuItem, Me.replaceToolStripMenuItem})
        Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
        Me.editToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.editToolStripMenuItem.Text = "&Edit"
        '
        'findToolStripMenuItem
        '
        Me.findToolStripMenuItem.Name = "findToolStripMenuItem"
        Me.findToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.findToolStripMenuItem.Text = "&Find"
        '
        'replaceToolStripMenuItem
        '
        Me.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem"
        Me.replaceToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.replaceToolStripMenuItem.Text = "&Replace"
        '
        'miLanguage
        '
        Me.miLanguage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miCSharp, Me.miVB, Me.hTMLToolStripMenuItem, Me.sQLToolStripMenuItem, Me.pHPToolStripMenuItem})
        Me.miLanguage.Name = "miLanguage"
        Me.miLanguage.Size = New System.Drawing.Size(71, 20)
        Me.miLanguage.Text = "Language"
        '
        'miCSharp
        '
        Me.miCSharp.Name = "miCSharp"
        Me.miCSharp.Size = New System.Drawing.Size(112, 22)
        Me.miCSharp.Text = "CSharp"
        '
        'miVB
        '
        Me.miVB.Name = "miVB"
        Me.miVB.Size = New System.Drawing.Size(112, 22)
        Me.miVB.Text = "VB"
        '
        'hTMLToolStripMenuItem
        '
        Me.hTMLToolStripMenuItem.Name = "hTMLToolStripMenuItem"
        Me.hTMLToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.hTMLToolStripMenuItem.Text = "HTML"
        '
        'sQLToolStripMenuItem
        '
        Me.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem"
        Me.sQLToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.sQLToolStripMenuItem.Text = "SQL"
        '
        'pHPToolStripMenuItem
        '
        Me.pHPToolStripMenuItem.Name = "pHPToolStripMenuItem"
        Me.pHPToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.pHPToolStripMenuItem.Text = "PHP"
        '
        'exportToolStripMenuItem
        '
        Me.exportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.hTMLToolStripMenuItem1})
        Me.exportToolStripMenuItem.Name = "exportToolStripMenuItem"
        Me.exportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.exportToolStripMenuItem.Text = "Export"
        '
        'hTMLToolStripMenuItem1
        '
        Me.hTMLToolStripMenuItem1.Name = "hTMLToolStripMenuItem1"
        Me.hTMLToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.hTMLToolStripMenuItem1.Text = "HTML"
        '
        'FontDialog1
        '
        Me.FontDialog1.Color = System.Drawing.SystemColors.ControlText
        '
        'FastColoredTextBox1
        '
        Me.FastColoredTextBox1.AutoScrollMinSize = New System.Drawing.Size(158, 15)
        Me.FastColoredTextBox1.BackBrush = Nothing
        Me.FastColoredTextBox1.CharHeight = 15
        Me.FastColoredTextBox1.CharWidth = 7
        Me.FastColoredTextBox1.CommentPrefix = "'"
        Me.FastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.FastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FastColoredTextBox1.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.FastColoredTextBox1.IsReplaceMode = False
        Me.FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB
        Me.FastColoredTextBox1.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.FastColoredTextBox1.Location = New System.Drawing.Point(0, 24)
        Me.FastColoredTextBox1.Name = "FastColoredTextBox1"
        Me.FastColoredTextBox1.Paddings = New System.Windows.Forms.Padding(0)
        Me.FastColoredTextBox1.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.FastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FastColoredTextBox1.Size = New System.Drawing.Size(362, 302)
        Me.FastColoredTextBox1.TabIndex = 0
        Me.FastColoredTextBox1.Text = "FastColoredTextBox1"
        '
        'PowerfulSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 326)
        Me.Controls.Add(Me.FastColoredTextBox1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "PowerfulSample"
        Me.Text = "FastColoredTextBox sample"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.FastColoredTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FastColoredTextBox1 As FastColoredTextBoxNS.FastColoredTextBox
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents findToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents replaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents miLanguage As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents miCSharp As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents miVB As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents hTMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents sQLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents pHPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents hTMLToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog

End Class
