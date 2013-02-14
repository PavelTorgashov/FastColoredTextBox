Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Namespace TesterVB
    Public Class DynamicSyntaxHighlighting
        Inherits Form

        Private components As IContainer = Nothing

        Private fctb As FastColoredTextBox

        Private label1 As Label

        Private KeywordsStyle As Style = New TextStyle(Brushes.Green, Nothing, FontStyle.Regular)

        Private FunctionNameStyle As Style = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)

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
            Me.label1.Size = New Size(406, 77)
            Me.label1.TabIndex = 3
            Me.label1.Text = "This example finds the functions declared in the program and dynamically highlights all of their entry into the code of LISP." & vbCrLf & "Change function name 'fibonacci' and 'fibonacci' it will not highlighted."
            Me.fctb.AutoScrollMinSize = New Size(352, 75)
            Me.fctb.BackBrush = Nothing
            Me.fctb.BorderStyle = BorderStyle.FixedSingle
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.DelayedTextChangedInterval = 400
            Me.fctb.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Consolas", 9.75F)
            Me.fctb.LeftBracket = "("
            Me.fctb.Location = New Point(0, 77)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New Padding(0)
            Me.fctb.RightBracket = ")"
            Me.fctb.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctb.ShowLineNumbers = False
            Me.fctb.Size = New Size(406, 204)
            Me.fctb.TabIndex = 4
            Me.fctb.Text = vbCrLf & "(defun fibonacci(n)" & vbCrLf & "    (if (or (= n 0) (= n 1))" & vbCrLf & "     1" & vbCrLf & "     (+ (fibonacci (- n 1)) (fibonacci (- n 2)))))"
            AddHandler Me.fctb.TextChangedDelayed, New EventHandler(Of TextChangedEventArgs)(AddressOf Me.fctb_TextChangedDelayed)
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(406, 281)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Controls.Add(Me.label1)
            MyBase.Name = "DynamicSyntaxHighlighting"
            Me.Text = "DynamicSyntaxHighlighting"
            MyBase.ResumeLayout(False)
        End Sub

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Protected Overrides Sub OnLoad(e As EventArgs)
            MyBase.OnLoad(e)
            Me.fctb.OnTextChanged()
        End Sub

        Private Sub fctb_TextChangedDelayed(sender As Object, e As TextChangedEventArgs)
            Me.fctb.Range.ClearStyle(New Style() {Me.KeywordsStyle, Me.FunctionNameStyle})
            Me.fctb.Range.SetStyle(Me.KeywordsStyle, "\b(and|eval|else|if|lambda|or|set|defun)\b", RegexOptions.IgnoreCase)
            For Each found As Range In Me.fctb.GetRanges("\b(defun|DEFUN)\s+(?<range>\w+)\b")
                Me.fctb.Range.SetStyle(Me.FunctionNameStyle, "\b" + found.Text + "\b")
            Next
        End Sub
    End Class
End Namespace
