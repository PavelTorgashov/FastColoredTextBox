Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB
    Public Class SyntaxHighlightingByXmlDescription
        Inherits Form

        Private components As IContainer = Nothing

        Private fctb As FastColoredTextBox

        Private label1 As Label

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(SyntaxHighlightingByXmlDescription))
            Me.label1 = New Label()
            Me.fctb = New FastColoredTextBox()
            Dim syntaxHighlighter As SyntaxHighlighter = New SyntaxHighlighter(fctb)
            MyBase.SuspendLayout()
            Me.label1.Dock = DockStyle.Top
            Me.label1.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204)
            Me.label1.Location = New Point(0, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New Size(370, 39)
            Me.label1.TabIndex = 3
            Me.label1.Text = "This example uses XML file for description syntax highlighting."
            Me.fctb.AutoScroll = True
            Me.fctb.AutoScrollMinSize = New Size(0, 176)
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.DescriptionFile = "htmlDesc.xml"
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.IsChanged = True
            Me.fctb.LeftBracket = "("
            Me.fctb.Location = New Point(0, 39)
            Me.fctb.Name = "fastColoredTextBox1"
            Me.fctb.RightBracket = ")"
            Me.fctb.SelectedText = ""
            Me.fctb.SelectionStart = 373
            Me.fctb.Size = New Size(370, 275)
            Me.fctb.SyntaxHighlighter = syntaxHighlighter
            Me.fctb.TabIndex = 4
            Me.fctb.Text = ""
            Me.fctb.WordWrap = True
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(370, 314)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Controls.Add(Me.label1)
            MyBase.Name = "SyntaxHighlightingByXmlDescription"
            Me.Text = "SyntaxHighlightingByXmlDescription"
            MyBase.ResumeLayout(False)
        End Sub

        Public Sub New()
            Me.InitializeComponent()
            Me.fctb.Text = "<div class=""clip5x9 nav_arrows"">" & vbCrLf & "      <img src=""http://i3.msdn.microsoft.com/Hash/0f73868cd340280cac28f7eeb3d2dd7d.png"" class=""cl_nav_arrow"" alt="""" />" & vbCrLf & "</div>" & vbCrLf & "    " & vbCrLf & "<div class=""nav_div_currentroot"">" & vbCrLf & "<a href=""http://msdn.microsoft.com/en-us/library/abeh092z(v=VS.90).aspx"" title=""System.Globalization Namespace"">System.Globalization Namespace</a></div>"
        End Sub
    End Class
End Namespace
