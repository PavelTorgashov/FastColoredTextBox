Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB
    Public Class CustomFoldingSample
        Inherits Form

        Private components As IContainer = Nothing

        Private label1 As Label

        Private fctb As FastColoredTextBox

        Public Sub New()
            Me.InitializeComponent()
            Me.fctb.Text = vbCrLf & "class Evaluator:" & vbCrLf & "    def __init__(self):" & vbCrLf & "        self.myNameSpace = {} " & vbCrLf & "        self.runpython(""from math import *"")" & vbCrLf & vbCrLf & "    def doEnter(self, *args):" & vbCrLf & "        result = self.calc.runpython(self.current)" & vbCrLf & "        if result:" & vbCrLf & "            self.display.insert(END, '\n')" & vbCrLf & "            self.display.insert(END, '%s\n' % result, 'ans')" & vbCrLf & "        self.current = """"" & vbCrLf & vbCrLf & "    def runpython(self, code):" & vbCrLf & "        try:" & vbCrLf & "            return 'eval(code, self.myNameSpace, self.myNameSpace)'" & vbCrLf & "        except SyntaxError:" & vbCrLf & "            return 'Error'" & vbCrLf & vbCrLf & "Calculator().mainloop()"
            Me.fctb.OnTextChangedDelayed(Me.fctb.Range)
        End Sub

        Private Sub fctb_TextChangedDelayed(sender As Object, e As TextChangedEventArgs)
            Me.fctb.Range.ClearFoldingMarkers()
            Dim currentIndent As Integer = 0
            Dim lastNonEmptyLine As Integer = 0
            For i As Integer = 0 To Me.fctb.LinesCount - 1
                Dim line As Line = Me.fctb(i)
                Dim spacesCount As Integer = line.StartSpacesCount
                If spacesCount <> line.Count Then
                    If currentIndent < spacesCount Then
                        Me.fctb(lastNonEmptyLine).FoldingStartMarker = "m" + currentIndent.ToString()
                    Else
                        If currentIndent > spacesCount Then
                            Me.fctb(lastNonEmptyLine).FoldingEndMarker = "m" + spacesCount.ToString()
                        End If
                    End If
                    currentIndent = spacesCount
                    lastNonEmptyLine = i
                End If
            Next
        End Sub

        Private Sub fctb_AutoIndentNeeded(sender As Object, e As AutoIndentEventArgs)
        End Sub

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
            Me.label1.Size = New Size(467, 45)
            Me.label1.TabIndex = 2
            Me.label1.Text = "This example shows how to make custom code folding." & vbCrLf & "Example creates folding for Python."
            Me.fctb.AutoScrollMinSize = New Size(25, 15)
            Me.fctb.BackBrush = Nothing
            Me.fctb.BorderStyle = BorderStyle.FixedSingle
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Consolas", 9.75F)
            Me.fctb.Location = New Point(0, 45)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New Padding(0)
            Me.fctb.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctb.ServiceLinesColor = Color.Gray
            Me.fctb.ShowFoldingLines = True
            Me.fctb.Size = New Size(467, 358)
            Me.fctb.TabIndex = 3
            AddHandler Me.fctb.TextChangedDelayed, New EventHandler(Of TextChangedEventArgs)(AddressOf Me.fctb_TextChangedDelayed)
            AddHandler Me.fctb.AutoIndentNeeded, New EventHandler(Of AutoIndentEventArgs)(AddressOf Me.fctb_AutoIndentNeeded)
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(467, 403)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Controls.Add(Me.label1)
            MyBase.Name = "CustomFoldingSample"
            Me.Text = "CustomCodeFolding Sample"
            MyBase.ResumeLayout(False)
        End Sub
    End Class
End Namespace
