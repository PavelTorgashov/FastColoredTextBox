<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookmarksSample
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BookmarksSample))
        Me.fctb = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btAddBookmark = New System.Windows.Forms.ToolStripButton()
        Me.btRemoveBookmark = New System.Windows.Forms.ToolStripButton()
        Me.btGo = New System.Windows.Forms.ToolStripDropDownButton()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fctb
        '
        Me.fctb.AutoScrollMinSize = New System.Drawing.Size(1218, 1245)
        Me.fctb.BackBrush = Nothing
        Me.fctb.CommentPrefix = "'"
        Me.fctb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.fctb.DelayedEventsInterval = 500
        Me.fctb.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.fctb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fctb.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.fctb.Language = FastColoredTextBoxNS.Language.VB
        Me.fctb.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.fctb.LeftPadding = 17
        Me.fctb.Location = New System.Drawing.Point(0, 25)
        Me.fctb.Name = "fctb"
        Me.fctb.Paddings = New System.Windows.Forms.Padding(0)
        Me.fctb.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.fctb.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fctb.Size = New System.Drawing.Size(477, 307)
        Me.fctb.TabIndex = 2
        Me.fctb.Text = resources.GetString("fctb.Text")
        '
        'toolStrip1
        '
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btAddBookmark, Me.btRemoveBookmark, Me.btGo})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.ShowItemToolTips = False
        Me.toolStrip1.Size = New System.Drawing.Size(477, 25)
        Me.toolStrip1.TabIndex = 3
        Me.toolStrip1.Text = "toolStrip1"
        '
        'btAddBookmark
        '
        Me.btAddBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btAddBookmark.Image = CType(resources.GetObject("btAddBookmark.Image"), System.Drawing.Image)
        Me.btAddBookmark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btAddBookmark.Name = "btAddBookmark"
        Me.btAddBookmark.Size = New System.Drawing.Size(90, 22)
        Me.btAddBookmark.Text = "Add bookmark"
        '
        'btRemoveBookmark
        '
        Me.btRemoveBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btRemoveBookmark.Image = CType(resources.GetObject("btRemoveBookmark.Image"), System.Drawing.Image)
        Me.btRemoveBookmark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btRemoveBookmark.Name = "btRemoveBookmark"
        Me.btRemoveBookmark.Size = New System.Drawing.Size(111, 22)
        Me.btRemoveBookmark.Text = "Remove bookmark"
        '
        'btGo
        '
        Me.btGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btGo.Image = CType(resources.GetObject("btGo.Image"), System.Drawing.Image)
        Me.btGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGo.Name = "btGo"
        Me.btGo.Size = New System.Drawing.Size(61, 22)
        Me.btGo.Text = "Go to ..."
        '
        'BookmarksSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 332)
        Me.Controls.Add(Me.fctb)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "BookmarksSample"
        Me.Text = "BookmarksSample"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents fctb As FastColoredTextBoxNS.FastColoredTextBox
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents btAddBookmark As System.Windows.Forms.ToolStripButton
    Private WithEvents btRemoveBookmark As System.Windows.Forms.ToolStripButton
    Private WithEvents btGo As System.Windows.Forms.ToolStripDropDownButton
End Class
