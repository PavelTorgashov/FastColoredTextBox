Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB
    Public Class IMEsample
        Inherits Form

        Private components As IContainer = Nothing

        Private fctb As FastColoredTextBox

        Private label1 As Label

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(IMEsample))
            Me.label1 = New Label()
            Me.fctb = New FastColoredTextBox()
            MyBase.SuspendLayout()
            Me.label1.Dock = DockStyle.Top
            Me.label1.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204)
            Me.label1.Location = New Point(0, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New Size(417, 85)
            Me.label1.TabIndex = 3
            Me.label1.Text = "This example supports IME entering mode. Simply set ImeMode property to On." & vbCrLf &
"Note: For a normal display wide characters (for Arabic or CJK languages) ​​may require a larger font size." & vbCrLf &
"Note: Enabled IME mode can decrease performance of control."
            Me.fctb.AutoIndent = False
            Me.fctb.AutoScrollMinSize = New Size(0, 264)
            Me.fctb.BorderStyle = BorderStyle.FixedSingle
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204)
            Me.fctb.ImeMode = ImeMode.[On]
            Me.fctb.LeftBracket = "("
            Me.fctb.Location = New Point(0, 85)
            Me.fctb.Name = "fctb"
            Me.fctb.RightBracket = ")"
            Me.fctb.ShowLineNumbers = False
            Me.fctb.Size = New Size(417, 217)
            Me.fctb.TabIndex = 2
            Me.fctb.Text = "The Tao Te Ching or Dao De Jing (道德經), whose authorship has been attributed to Laozi is a Chinese classic text." & vbCrLf & "宗教化《道德經》" & vbCrLf & "常會被歸屬為道教學說。"
            Me.fctb.WordWrap = True
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(417, 302)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Controls.Add(Me.label1)
            MyBase.Name = "IMEsample"
            Me.Text = "IMEsample"
            MyBase.ResumeLayout(False)
        End Sub
    End Class
End Namespace
