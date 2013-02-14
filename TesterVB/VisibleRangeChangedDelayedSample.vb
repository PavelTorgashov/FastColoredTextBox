Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace TesterVB
    Public Class VisibleRangeChangedDelayedSample
        Inherits Form

        Private components As IContainer = Nothing

        Private label1 As Label

        Private fctb As FastColoredTextBox

        Private BlueStyle As Style = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)

        Private RedStyle As Style = New TextStyle(Brushes.Red, Nothing, FontStyle.Regular)

        Private MaroonStyle As Style = New TextStyle(Brushes.Maroon, Nothing, FontStyle.Regular)

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
            Me.label1.Size = New Size(371, 48)
            Me.label1.TabIndex = 0
            Me.label1.Text = "This example shows how to highlight syntax for extremally large text by VisibleRangeChangedDelayed event"
            Me.fctb.AutoScrollMinSize = New Size(25, 15)
            Me.fctb.BackBrush = Nothing
            Me.fctb.BorderStyle = BorderStyle.FixedSingle
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.DelayedEventsInterval = 1000
            Me.fctb.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Consolas", 9.75F)
            Me.fctb.Location = New Point(0, 48)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New Padding(0)
            Me.fctb.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctb.Size = New Size(371, 235)
            Me.fctb.TabIndex = 1
            AddHandler Me.fctb.VisibleRangeChangedDelayed, New EventHandler(AddressOf Me.fctb_VisibleRangeChangedDelayed)
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(371, 283)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Controls.Add(Me.label1)
            MyBase.Name = "VisibleRangeChangedDelayedSample"
            Me.Text = "VisibleRangeChangedDelayed sample"
            MyBase.ResumeLayout(False)
        End Sub

        Public Sub New()
            Me.InitializeComponent()
            Dim html4line As String = "<li id=""ctl00_TopNavBar_AQL"">" & vbCrLf & "<a id=""ctl00_TopNavBar_ArticleQuestion"" class=""fly highlight"" href=""#_comments"">Ask a Question about this article</a></li>" & vbCrLf & "<li class=""heading"">Quick Answers</li>" & vbCrLf & "<li><a id=""ctl00_TopNavBar_QAAsk"" class=""fly"" href=""/Questions/ask.aspx"">Ask a Question</a></li>"
            Dim sb As StringBuilder = New StringBuilder()
            For i As Integer = 0 To 50000 - 1
                sb.AppendLine(html4line)
            Next
            Me.fctb.Text = sb.ToString()
            Me.fctb.IsChanged = False
            Me.fctb.ClearUndo()
            Me.fctb.DelayedEventsInterval = 10
        End Sub

        Private Sub fctb_VisibleRangeChangedDelayed(sender As Object, e As EventArgs)
            Me.HTMLSyntaxHighlight(Me.fctb.VisibleRange)
        End Sub

        Private Sub HTMLSyntaxHighlight(range As Range)
            range.ClearStyle(New Style() {Me.BlueStyle, Me.MaroonStyle, Me.RedStyle})
            range.SetStyle(Me.BlueStyle, "<|/>|</|>")
            range.SetStyle(Me.MaroonStyle, "<(?<range>[!\w]+)")
            range.SetStyle(Me.MaroonStyle, "</(?<range>\w+)>")
            range.SetStyle(Me.RedStyle, "(?<range>\S+?)='[^']*'|(?<range>\S+)=""[^""]*""|(?<range>\S+)=\S+")
            range.SetStyle(Me.BlueStyle, "\S+?=(?<range>'[^']*')|\S+=(?<range>""[^""]*"")|\S+=(?<range>\S+)")
        End Sub
    End Class
End Namespace
