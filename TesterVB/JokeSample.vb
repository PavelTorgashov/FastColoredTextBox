Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB

    Public Class JokeSample
        Inherits Form

        Private components As IContainer = Nothing

        Private timer1 As Timer

        Private fctb As FastColoredTextBox

        Public Sub New()
            Me.InitializeComponent()
            Me.fctb.DefaultStyle = New JokeStyle()
        End Sub

        Private Sub timer1_Tick(sender As Object, e As EventArgs)
            Me.fctb.Invalidate()
        End Sub

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.components = New Container()
            Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(JokeSample))
            Me.timer1 = New Timer(Me.components)
            Me.fctb = New FastColoredTextBox()
            MyBase.SuspendLayout()
            Me.timer1.Enabled = True
            Me.timer1.Interval = 10
            AddHandler Me.timer1.Tick, New EventHandler(AddressOf Me.timer1_Tick)
            Me.fctb.AutoIndent = False
            Me.fctb.AutoScrollMinSize = New Size(0, 621)
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Courier New", 18.0F, FontStyle.Regular, GraphicsUnit.Point, 204)
            Me.fctb.LeftBracket = "("
            Me.fctb.Location = New Point(0, 0)
            Me.fctb.Name = "fctb"
            Me.fctb.RightBracket = ")"
            Me.fctb.ShowLineNumbers = False
            Me.fctb.Size = New Size(438, 287)
            Me.fctb.TabIndex = 0
            Me.fctb.Text = resources.GetString("fctb.Text")
            Me.fctb.WordWrap = True
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(438, 287)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Name = "JokeSample"
            Me.Text = "JokeSample"
            MyBase.ResumeLayout(False)
        End Sub
    End Class
End Namespace
