<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutocompleteSample2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutocompleteSample2))
        Me.fctb = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'fctb
        '
        Me.fctb.AutoScrollMinSize = New System.Drawing.Size(466, 330)
        Me.fctb.BackBrush = Nothing
        Me.fctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fctb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.fctb.DelayedEventsInterval = 500
        Me.fctb.DelayedTextChangedInterval = 500
        Me.fctb.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.fctb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fctb.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.fctb.Language = FastColoredTextBoxNS.Language.CSharp
        Me.fctb.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.fctb.Location = New System.Drawing.Point(0, 85)
        Me.fctb.Name = "fctb"
        Me.fctb.Paddings = New System.Windows.Forms.Padding(0)
        Me.fctb.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.fctb.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fctb.Size = New System.Drawing.Size(500, 280)
        Me.fctb.TabIndex = 7
        Me.fctb.Text = resources.GetString("fctb.Text")
        '
        'label1
        '
        Me.label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label1.Location = New System.Drawing.Point(0, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(500, 85)
        Me.label1.TabIndex = 6
        Me.label1.Text = resources.GetString("label1.Text")
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "script_16x16.png")
        Me.imageList1.Images.SetKeyName(1, "app_16x16.png")
        Me.imageList1.Images.SetKeyName(2, "1302166543_virtualbox.png")
        '
        'AutocompleteSample2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 365)
        Me.Controls.Add(Me.fctb)
        Me.Controls.Add(Me.label1)
        Me.Name = "AutocompleteSample2"
        Me.Text = "AutocompleteSample2"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents fctb As FastColoredTextBoxNS.FastColoredTextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
End Class
