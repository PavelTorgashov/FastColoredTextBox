Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB
    Public Class SimplestSyntaxHighlightingSample
        Inherits Form

        Private components As IContainer = Nothing

        Private fctb As FastColoredTextBox

        Private label1 As Label

        Private maroonStyle As TextStyle = New TextStyle(Brushes.Maroon, Nothing, FontStyle.Regular)

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.label1 = New Label()
            Me.fctb = New FastColoredTextBox()
            MyBase.SuspendLayout()
            Me.label1.Dock = DockStyle.Top
            Me.label1.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204)
            Me.label1.Location = New Point(0, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New Size(498, 45)
            Me.label1.TabIndex = 1
            Me.label1.Text = "This example shows how to make simplest syntax highlighting."
            Me.fctb.AutoScrollMinSize = New Size(25, 15)
            Me.fctb.BackBrush = Nothing
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.DescriptionFile = ""
            Me.fctb.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Consolas", 9.75F)
            Me.fctb.Location = New Point(0, 45)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New Padding(0)
            Me.fctb.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctb.Size = New Size(498, 216)
            Me.fctb.TabIndex = 0
            AddHandler Me.fctb.TextChanged, New EventHandler(Of TextChangedEventArgs)(AddressOf Me.fctb_TextChanged)
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(498, 261)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Controls.Add(Me.label1)
            MyBase.Name = "SimplestSyntaxHighlightingSample"
            Me.Text = "SimplestSyntaxHighlightingSample"
            MyBase.ResumeLayout(False)
        End Sub

        Public Sub New()
            Me.InitializeComponent()
            Me.fctb.Text = "<li>Article" & vbLf & "<a href=""#_comments"">Ask a Question about this article</a></li>" & vbLf & "<li class=""heading"">Quick Answers</li>" & vbLf & "<li><a href=""/Questions/ask.aspx"">Ask a Question</a></li>"
        End Sub

        Private Sub fctb_TextChanged(sender As Object, e As TextChangedEventArgs)
            e.ChangedRange.ClearStyle(New Style() {Me.maroonStyle})
            e.ChangedRange.SetStyle(Me.maroonStyle, "<[^>]+>")
        End Sub
    End Class
End Namespace
