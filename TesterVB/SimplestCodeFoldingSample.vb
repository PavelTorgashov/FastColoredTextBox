Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB
    Public Class SimplestCodeFoldingSample
        Inherits Form

        Private components As IContainer = Nothing

        Private label1 As Label

        Private fctb As FastColoredTextBox

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
            Me.label1.Size = New Size(361, 45)
            Me.label1.TabIndex = 2
            Me.label1.Text = "This example shows how to make simplest code folding."
            Me.fctb.AutoScrollMinSize = New Size(12, 15)
            Me.fctb.BackBrush = Nothing
            Me.fctb.BorderStyle = BorderStyle.FixedSingle
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Consolas", 9.75F)
            Me.fctb.LeftPadding = 15
            Me.fctb.Location = New Point(0, 45)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New Padding(0)
            Me.fctb.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctb.ServiceLinesColor = Color.Gray
            Me.fctb.ShowLineNumbers = False
            Me.fctb.Size = New Size(361, 295)
            Me.fctb.TabIndex = 3
            AddHandler Me.fctb.TextChanged, New EventHandler(Of TextChangedEventArgs)(AddressOf Me.fctb_TextChanged)
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(361, 340)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Controls.Add(Me.label1)
            MyBase.Name = "SimplestCodeFoldingSample"
            Me.Text = "SimplestCodeFolding Sample"
            MyBase.ResumeLayout(False)
        End Sub

        Public Sub New()
            Me.InitializeComponent()
            Me.fctb.Text = vbCrLf & "    /// <summary>" & vbCrLf & "    /// Char and style" & vbCrLf & "    /// </summary>" & vbCrLf & "    struct Char" & vbCrLf & "    {" & vbCrLf & "        public char c;" & vbCrLf & "        public StyleIndex style;" & vbCrLf & vbCrLf & "        public Char(char c)" & vbCrLf & "        {" & vbCrLf & "            this.c = c;" & vbCrLf & "            style = StyleIndex.None;" & vbCrLf & "        }" & vbCrLf & "    }"
        End Sub

        Private Sub fctb_TextChanged(sender As Object, e As TextChangedEventArgs)
            e.ChangedRange.ClearFoldingMarkers()
            e.ChangedRange.SetFoldingMarkers("{", "}")
        End Sub
    End Class
End Namespace
