Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Namespace TesterVB
    Public Class CustomStyleSample
        Inherits Form

        Private ellipseStyle As EllipseStyle = New EllipseStyle()

        Private components As IContainer = Nothing

        Private label1 As Label

        Private WithEvents fctb As FastColoredTextBox

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub fctb_TextChanged(sender As Object, e As TextChangedEventArgs) Handles fctb.TextChanged
            e.ChangedRange.ClearStyle(New Style() {Me.ellipseStyle})
            e.ChangedRange.SetStyle(Me.ellipseStyle, "\bBabylon\b", RegexOptions.IgnoreCase)
        End Sub

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomStyleSample))
            Me.label1 = New System.Windows.Forms.Label()
            Me.fctb = New FastColoredTextBoxNS.FastColoredTextBox()
            CType(Me.fctb, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'label1
            '
            Me.label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label1.Location = New System.Drawing.Point(0, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(600, 39)
            Me.label1.TabIndex = 1
            Me.label1.Text = "This example shows how to create own custom style."
            '
            'fctb
            '
            Me.fctb.AllowDrop = True
            Me.fctb.AutoIndent = False
            Me.fctb.AutoScrollMinSize = New System.Drawing.Size(575, 145)
            Me.fctb.BackBrush = Nothing
            Me.fctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.fctb.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.fctb.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.fctb.Dock = System.Windows.Forms.DockStyle.Fill
            Me.fctb.Font = New System.Drawing.Font("Consolas", 9.75!)
            Me.fctb.IsReplaceMode = False
            Me.fctb.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
            Me.fctb.LeftPadding = 3
            Me.fctb.Location = New System.Drawing.Point(0, 39)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New System.Windows.Forms.Padding(5)
            Me.fctb.PreferredLineWidth = 80
            Me.fctb.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
            Me.fctb.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.fctb.ShowLineNumbers = False
            Me.fctb.Size = New System.Drawing.Size(600, 266)
            Me.fctb.TabIndex = 2
            Me.fctb.Text = resources.GetString("fctb.Text")
            Me.fctb.WordWrap = True
            Me.fctb.WordWrapMode = FastColoredTextBoxNS.WordWrapMode.WordWrapPreferredWidth
            '
            'CustomStyleSample
            '
            Me.ClientSize = New System.Drawing.Size(600, 305)
            Me.Controls.Add(Me.fctb)
            Me.Controls.Add(Me.label1)
            Me.Name = "CustomStyleSample"
            Me.Text = "Custom style sample"
            CType(Me.fctb, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
