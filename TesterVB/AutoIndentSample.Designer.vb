<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoIndentSample
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
        Me.fastColoredTextBox1 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fastColoredTextBox1
        '
        Me.fastColoredTextBox1.AutoScrollMinSize = New System.Drawing.Size(347, 180)
        Me.fastColoredTextBox1.BackBrush = Nothing
        Me.fastColoredTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.fastColoredTextBox1.DelayedEventsInterval = 500
        Me.fastColoredTextBox1.DelayedTextChangedInterval = 500
        Me.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.fastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fastColoredTextBox1.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.fastColoredTextBox1.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.fastColoredTextBox1.Location = New System.Drawing.Point(0, 41)
        Me.fastColoredTextBox1.Name = "fastColoredTextBox1"
        Me.fastColoredTextBox1.Paddings = New System.Windows.Forms.Padding(0)
        Me.fastColoredTextBox1.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fastColoredTextBox1.Size = New System.Drawing.Size(423, 313)
        Me.fastColoredTextBox1.TabIndex = 5
        Me.fastColoredTextBox1.Text = "/// Please, type next text (without slashes):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/// begin" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/// i := 1;" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/// if j=0" & _
    " then" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/// begin" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/// i := 10;" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/// end" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/// else" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/// i := 20;" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/// end" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'label1
        '
        Me.label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label1.Location = New System.Drawing.Point(0, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(423, 41)
        Me.label1.TabIndex = 4
        Me.label1.Text = "This example demonstrates AutoIndent functionality." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Control automatically define" & _
    "s indentation for each new line."
        '
        'AutoIndentSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 354)
        Me.Controls.Add(Me.fastColoredTextBox1)
        Me.Controls.Add(Me.label1)
        Me.Name = "AutoIndentSample"
        Me.Text = "AutoIndentSample"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents fastColoredTextBox1 As FastColoredTextBoxNS.FastColoredTextBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
