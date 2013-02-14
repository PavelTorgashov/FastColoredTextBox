<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.label8 = New System.Windows.Forms.Label()
        Me.button8 = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.button1 = New System.Windows.Forms.Button()
        Me.label16 = New System.Windows.Forms.Label()
        Me.button16 = New System.Windows.Forms.Button()
        Me.label15 = New System.Windows.Forms.Label()
        Me.button15 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(0, 41)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(208, 41)
        Me.label8.TabIndex = 19
        Me.label8.Text = "Autocomplete sample. This example shows simplest way to create autocomplete funct" & _
            "ionality."
        Me.label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'button8
        '
        Me.button8.Location = New System.Drawing.Point(214, 52)
        Me.button8.Name = "button8"
        Me.button8.Size = New System.Drawing.Size(75, 23)
        Me.button8.TabIndex = 18
        Me.button8.Text = "Show"
        Me.button8.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(0, 4)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(208, 34)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Powerful sample. It shows syntax highlighting and many features."
        Me.label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(214, 3)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 16
        Me.button1.Text = "Show"
        Me.button1.UseVisualStyleBackColor = True
        '
        'label16
        '
        Me.label16.Location = New System.Drawing.Point(0, 157)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(208, 23)
        Me.label16.TabIndex = 33
        Me.label16.Text = "Bookmarks sample"
        Me.label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'button16
        '
        Me.button16.Location = New System.Drawing.Point(214, 152)
        Me.button16.Name = "button16"
        Me.button16.Size = New System.Drawing.Size(75, 23)
        Me.button16.TabIndex = 32
        Me.button16.Text = "Show"
        Me.button16.UseVisualStyleBackColor = True
        '
        'label15
        '
        Me.label15.Location = New System.Drawing.Point(0, 206)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(208, 23)
        Me.label15.TabIndex = 35
        Me.label15.Text = "AutoIndent sample"
        Me.label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'button15
        '
        Me.button15.Location = New System.Drawing.Point(214, 201)
        Me.button15.Name = "button15"
        Me.button15.Size = New System.Drawing.Size(75, 23)
        Me.button15.TabIndex = 34
        Me.button15.Text = "Show"
        Me.button15.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 48)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Autocomplete sample 2." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This example demonstrates more flexible variant of Autoco" & _
            "mpleteMenu using."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(214, 102)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "Show"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 254)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.label15)
        Me.Controls.Add(Me.button15)
        Me.Controls.Add(Me.label16)
        Me.Controls.Add(Me.button16)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.button8)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.button1)
        Me.Name = "MainForm"
        Me.Text = "MenuForm"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents button8 As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents button16 As System.Windows.Forms.Button
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents button15 As System.Windows.Forms.Button
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Button2 As System.Windows.Forms.Button
End Class
