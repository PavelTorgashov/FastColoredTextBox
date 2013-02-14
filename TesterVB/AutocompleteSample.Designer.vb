<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutocompleteSample
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutocompleteSample))
        Me.label1 = New System.Windows.Forms.Label()
        Me.fastColoredTextBox1 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label1.Location = New System.Drawing.Point(0, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(457, 50)
        Me.label1.TabIndex = 4
        Me.label1.Text = "This example shows how to create simplest autocomplete functionality." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Popup menu" & _
    " contains 500000 words."
        '
        'fastColoredTextBox1
        '
        Me.fastColoredTextBox1.AllowDrop = True
        Me.fastColoredTextBox1.AutoIndent = False
        Me.fastColoredTextBox1.AutoScrollMinSize = New System.Drawing.Size(0, 105)
        Me.fastColoredTextBox1.BackBrush = Nothing
        Me.fastColoredTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.fastColoredTextBox1.DelayedEventsInterval = 500
        Me.fastColoredTextBox1.DelayedTextChangedInterval = 500
        Me.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.fastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fastColoredTextBox1.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.fastColoredTextBox1.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.fastColoredTextBox1.Location = New System.Drawing.Point(0, 50)
        Me.fastColoredTextBox1.Name = "fastColoredTextBox1"
        Me.fastColoredTextBox1.Paddings = New System.Windows.Forms.Padding(0)
        Me.fastColoredTextBox1.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fastColoredTextBox1.ShowLineNumbers = False
        Me.fastColoredTextBox1.Size = New System.Drawing.Size(457, 276)
        Me.fastColoredTextBox1.TabIndex = 5
        Me.fastColoredTextBox1.Text = resources.GetString("fastColoredTextBox1.Text")
        Me.fastColoredTextBox1.WordWrap = True
        '
        'AutocompleteSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 326)
        Me.Controls.Add(Me.fastColoredTextBox1)
        Me.Controls.Add(Me.label1)
        Me.Name = "AutocompleteSample"
        Me.Text = "AutocompleteSample"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents fastColoredTextBox1 As FastColoredTextBoxNS.FastColoredTextBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
