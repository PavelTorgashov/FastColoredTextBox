Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB

    Public Class MainForm
        Inherits Form

        Private components As IContainer = Nothing

        Private WithEvents button1 As Button

        Private WithEvents label1 As Label

        Private WithEvents label2 As Label

        Private WithEvents button2 As Button

        Private WithEvents label3 As Label

        Private WithEvents button3 As Button

        Private WithEvents label4 As Label

        Private WithEvents button4 As Button

        Private WithEvents label5 As Label

        Private WithEvents button5 As Button

        Private WithEvents label6 As Label

        Private WithEvents button6 As Button

        Private WithEvents label7 As Label

        Private WithEvents button7 As Button

        Private WithEvents label8 As Label

        Private WithEvents button8 As Button

        Private WithEvents label9 As Label

        Private WithEvents button9 As Button

        Private WithEvents label10 As Label

        Private WithEvents button10 As Button

        Private WithEvents label11 As Label

        Private WithEvents button11 As Button

        Private WithEvents label12 As Label

        Private WithEvents button12 As Button

        Private WithEvents label13 As Label

        Private WithEvents button13 As Button

        Private WithEvents label14 As Label

        Private WithEvents button14 As Button

        Private WithEvents label15 As Label

        Private WithEvents button15 As Button

        Private WithEvents button16 As Button
        Private WithEvents label16 As Label

        Private WithEvents label17 As Label

        Private WithEvents button17 As Button

        Private WithEvents label18 As Label

        Private WithEvents button18 As Button

        Private WithEvents label19 As Label

        Private WithEvents button19 As Button

        Private WithEvents label20 As Label

        Private WithEvents button20 As Button

        Private WithEvents label21 As Label

        Private WithEvents button21 As Button

        Private WithEvents label22 As Label

        Private WithEvents button22 As Button

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.button1 = New System.Windows.Forms.Button()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.button2 = New System.Windows.Forms.Button()
            Me.label3 = New System.Windows.Forms.Label()
            Me.button3 = New System.Windows.Forms.Button()
            Me.label4 = New System.Windows.Forms.Label()
            Me.button4 = New System.Windows.Forms.Button()
            Me.label5 = New System.Windows.Forms.Label()
            Me.button5 = New System.Windows.Forms.Button()
            Me.label6 = New System.Windows.Forms.Label()
            Me.button6 = New System.Windows.Forms.Button()
            Me.label7 = New System.Windows.Forms.Label()
            Me.button7 = New System.Windows.Forms.Button()
            Me.label8 = New System.Windows.Forms.Label()
            Me.button8 = New System.Windows.Forms.Button()
            Me.label9 = New System.Windows.Forms.Label()
            Me.button9 = New System.Windows.Forms.Button()
            Me.label10 = New System.Windows.Forms.Label()
            Me.button10 = New System.Windows.Forms.Button()
            Me.label11 = New System.Windows.Forms.Label()
            Me.button11 = New System.Windows.Forms.Button()
            Me.label12 = New System.Windows.Forms.Label()
            Me.button12 = New System.Windows.Forms.Button()
            Me.label13 = New System.Windows.Forms.Label()
            Me.button13 = New System.Windows.Forms.Button()
            Me.label14 = New System.Windows.Forms.Label()
            Me.button14 = New System.Windows.Forms.Button()
            Me.label15 = New System.Windows.Forms.Label()
            Me.button15 = New System.Windows.Forms.Button()
            Me.button16 = New System.Windows.Forms.Button()
            Me.label16 = New System.Windows.Forms.Label()
            Me.label17 = New System.Windows.Forms.Label()
            Me.button17 = New System.Windows.Forms.Button()
            Me.label18 = New System.Windows.Forms.Label()
            Me.button18 = New System.Windows.Forms.Button()
            Me.label19 = New System.Windows.Forms.Label()
            Me.button19 = New System.Windows.Forms.Button()
            Me.label20 = New System.Windows.Forms.Label()
            Me.button20 = New System.Windows.Forms.Button()
            Me.label21 = New System.Windows.Forms.Label()
            Me.button21 = New System.Windows.Forms.Button()
            Me.label22 = New System.Windows.Forms.Label()
            Me.button22 = New System.Windows.Forms.Button()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'button1
            '
            Me.button1.Location = New System.Drawing.Point(222, 3)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(75, 23)
            Me.button1.TabIndex = 0
            Me.button1.Text = "Show"
            Me.button1.UseVisualStyleBackColor = True
            '
            'label1
            '
            Me.label1.Location = New System.Drawing.Point(8, 4)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(208, 34)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Powerful sample. It shows syntax highlighting and many features."
            Me.label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'label2
            '
            Me.label2.Location = New System.Drawing.Point(8, 82)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(208, 30)
            Me.label2.TabIndex = 3
            Me.label2.Text = "Marker sample. It shows how to make marker tool."
            Me.label2.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button2
            '
            Me.button2.Location = New System.Drawing.Point(222, 82)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(75, 23)
            Me.button2.TabIndex = 2
            Me.button2.Text = "Show"
            Me.button2.UseVisualStyleBackColor = True
            '
            'label3
            '
            Me.label3.Location = New System.Drawing.Point(8, 122)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(208, 30)
            Me.label3.TabIndex = 5
            Me.label3.Text = "Custom style sample. This example shows how to create own custom style."
            Me.label3.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button3
            '
            Me.button3.Location = New System.Drawing.Point(222, 122)
            Me.button3.Name = "button3"
            Me.button3.Size = New System.Drawing.Size(75, 23)
            Me.button3.TabIndex = 4
            Me.button3.Text = "Show"
            Me.button3.UseVisualStyleBackColor = True
            '
            'label4
            '
            Me.label4.Location = New System.Drawing.Point(8, 159)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(208, 56)
            Me.label4.TabIndex = 7
            Me.label4.Text = "VisibleRangeChangedDelayed usage sample. This example shows how to highlight synt" & _
        "ax for extremally large text by VisibleRangeChangedDelayed event."
            Me.label4.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button4
            '
            Me.button4.Location = New System.Drawing.Point(222, 173)
            Me.button4.Name = "button4"
            Me.button4.Size = New System.Drawing.Size(75, 23)
            Me.button4.TabIndex = 6
            Me.button4.Text = "Show"
            Me.button4.UseVisualStyleBackColor = True
            '
            'label5
            '
            Me.label5.Location = New System.Drawing.Point(11, 35)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(205, 44)
            Me.label5.TabIndex = 9
            Me.label5.Text = "Simplest custom syntax highlighting sample. It shows how to make custom syntax hi" & _
        "ghlighting."
            Me.label5.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button5
            '
            Me.button5.Location = New System.Drawing.Point(222, 40)
            Me.button5.Name = "button5"
            Me.button5.Size = New System.Drawing.Size(75, 23)
            Me.button5.TabIndex = 8
            Me.button5.Text = "Show"
            Me.button5.UseVisualStyleBackColor = True
            '
            'label6
            '
            Me.label6.Location = New System.Drawing.Point(8, 429)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(208, 26)
            Me.label6.TabIndex = 11
            Me.label6.Text = "Joke sample :)"
            Me.label6.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button6
            '
            Me.button6.Location = New System.Drawing.Point(222, 424)
            Me.button6.Name = "button6"
            Me.button6.Size = New System.Drawing.Size(75, 23)
            Me.button6.TabIndex = 10
            Me.button6.Text = "Show"
            Me.button6.UseVisualStyleBackColor = True
            '
            'label7
            '
            Me.label7.Location = New System.Drawing.Point(315, 4)
            Me.label7.Name = "label7"
            Me.label7.Size = New System.Drawing.Size(208, 41)
            Me.label7.TabIndex = 13
            Me.label7.Text = "Simplest code folding sample. This example shows how to make simplest code foldin" & _
        "g."
            Me.label7.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button7
            '
            Me.button7.Location = New System.Drawing.Point(529, 4)
            Me.button7.Name = "button7"
            Me.button7.Size = New System.Drawing.Size(75, 23)
            Me.button7.TabIndex = 12
            Me.button7.Text = "Show"
            Me.button7.UseVisualStyleBackColor = True
            '
            'label8
            '
            Me.label8.Location = New System.Drawing.Point(315, 87)
            Me.label8.Name = "label8"
            Me.label8.Size = New System.Drawing.Size(208, 41)
            Me.label8.TabIndex = 15
            Me.label8.Text = "Autocomplete sample. This example shows simplest way to create autocomplete funct" & _
        "ionality."
            Me.label8.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button8
            '
            Me.button8.Location = New System.Drawing.Point(529, 98)
            Me.button8.Name = "button8"
            Me.button8.Size = New System.Drawing.Size(75, 23)
            Me.button8.TabIndex = 14
            Me.button8.Text = "Show"
            Me.button8.UseVisualStyleBackColor = True
            '
            'label9
            '
            Me.label9.Location = New System.Drawing.Point(315, 220)
            Me.label9.Name = "label9"
            Me.label9.Size = New System.Drawing.Size(208, 59)
            Me.label9.TabIndex = 17
            Me.label9.Text = "Dynamic syntax highlighting. This example finds the functions declared in the pro" & _
        "gram and dynamically highlights all of their entry into the code of LISP."
            Me.label9.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button9
            '
            Me.button9.Location = New System.Drawing.Point(529, 234)
            Me.button9.Name = "button9"
            Me.button9.Size = New System.Drawing.Size(75, 23)
            Me.button9.TabIndex = 16
            Me.button9.Text = "Show"
            Me.button9.UseVisualStyleBackColor = True
            '
            'label10
            '
            Me.label10.Location = New System.Drawing.Point(315, 285)
            Me.label10.Name = "label10"
            Me.label10.Size = New System.Drawing.Size(208, 45)
            Me.label10.TabIndex = 19
            Me.label10.Text = "Syntax highlighting by XML description file. This example shows how to use XML fi" & _
        "le for description of syntax highlighting."
            Me.label10.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button10
            '
            Me.button10.Location = New System.Drawing.Point(529, 292)
            Me.button10.Name = "button10"
            Me.button10.Size = New System.Drawing.Size(75, 23)
            Me.button10.TabIndex = 18
            Me.button10.Text = "Show"
            Me.button10.UseVisualStyleBackColor = True
            '
            'label11
            '
            Me.label11.Location = New System.Drawing.Point(315, 339)
            Me.label11.Name = "label11"
            Me.label11.Size = New System.Drawing.Size(208, 37)
            Me.label11.TabIndex = 21
            Me.label11.Text = "This example supports IME entering mode and rendering of wide characters."
            Me.label11.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button11
            '
            Me.button11.Location = New System.Drawing.Point(529, 339)
            Me.button11.Name = "button11"
            Me.button11.Size = New System.Drawing.Size(75, 23)
            Me.button11.TabIndex = 20
            Me.button11.Text = "Show"
            Me.button11.UseVisualStyleBackColor = True
            '
            'label12
            '
            Me.label12.Location = New System.Drawing.Point(8, 228)
            Me.label12.Name = "label12"
            Me.label12.Size = New System.Drawing.Size(208, 26)
            Me.label12.TabIndex = 23
            Me.label12.Text = "Powerfull C# source file editor"
            Me.label12.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button12
            '
            Me.button12.Location = New System.Drawing.Point(222, 223)
            Me.button12.Name = "button12"
            Me.button12.Size = New System.Drawing.Size(75, 23)
            Me.button12.TabIndex = 22
            Me.button12.Text = "Show"
            Me.button12.UseVisualStyleBackColor = True
            '
            'label13
            '
            Me.label13.Location = New System.Drawing.Point(8, 265)
            Me.label13.Name = "label13"
            Me.label13.Size = New System.Drawing.Size(208, 26)
            Me.label13.TabIndex = 25
            Me.label13.Text = "Example of image drawing"
            Me.label13.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button13
            '
            Me.button13.Location = New System.Drawing.Point(222, 265)
            Me.button13.Name = "button13"
            Me.button13.Size = New System.Drawing.Size(75, 23)
            Me.button13.TabIndex = 24
            Me.button13.Text = "Show"
            Me.button13.UseVisualStyleBackColor = True
            '
            'label14
            '
            Me.label14.Location = New System.Drawing.Point(315, 135)
            Me.label14.Name = "label14"
            Me.label14.Size = New System.Drawing.Size(208, 41)
            Me.label14.TabIndex = 27
            Me.label14.Text = "Autocomplete sample 2." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This example demonstrates more flexible variant of Autoco" & _
        "mpleteMenu using."
            Me.label14.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button14
            '
            Me.button14.Location = New System.Drawing.Point(529, 141)
            Me.button14.Name = "button14"
            Me.button14.Size = New System.Drawing.Size(75, 23)
            Me.button14.TabIndex = 26
            Me.button14.Text = "Show"
            Me.button14.UseVisualStyleBackColor = True
            '
            'label15
            '
            Me.label15.Location = New System.Drawing.Point(315, 387)
            Me.label15.Name = "label15"
            Me.label15.Size = New System.Drawing.Size(208, 23)
            Me.label15.TabIndex = 29
            Me.label15.Text = "AutoIndent sample"
            Me.label15.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button15
            '
            Me.button15.Location = New System.Drawing.Point(529, 382)
            Me.button15.Name = "button15"
            Me.button15.Size = New System.Drawing.Size(75, 23)
            Me.button15.TabIndex = 28
            Me.button15.Text = "Show"
            Me.button15.UseVisualStyleBackColor = True
            '
            'button16
            '
            Me.button16.Location = New System.Drawing.Point(529, 425)
            Me.button16.Name = "button16"
            Me.button16.Size = New System.Drawing.Size(75, 23)
            Me.button16.TabIndex = 30
            Me.button16.Text = "Show"
            Me.button16.UseVisualStyleBackColor = True
            '
            'label16
            '
            Me.label16.Location = New System.Drawing.Point(315, 430)
            Me.label16.Name = "label16"
            Me.label16.Size = New System.Drawing.Size(208, 23)
            Me.label16.TabIndex = 31
            Me.label16.Text = "Bookmarks sample"
            Me.label16.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'label17
            '
            Me.label17.Location = New System.Drawing.Point(8, 306)
            Me.label17.Name = "label17"
            Me.label17.Size = New System.Drawing.Size(208, 26)
            Me.label17.TabIndex = 33
            Me.label17.Text = "Logger sample. It shows how to add text with predefined style."
            Me.label17.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button17
            '
            Me.button17.Location = New System.Drawing.Point(222, 306)
            Me.button17.Name = "button17"
            Me.button17.Size = New System.Drawing.Size(75, 23)
            Me.button17.TabIndex = 32
            Me.button17.Text = "Show"
            Me.button17.UseVisualStyleBackColor = True
            '
            'label18
            '
            Me.label18.Location = New System.Drawing.Point(315, 185)
            Me.label18.Name = "label18"
            Me.label18.Size = New System.Drawing.Size(208, 26)
            Me.label18.TabIndex = 35
            Me.label18.Text = "Tooltip sample. It shows tooltips for words under mouse."
            Me.label18.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button18
            '
            Me.button18.Location = New System.Drawing.Point(529, 185)
            Me.button18.Name = "button18"
            Me.button18.Size = New System.Drawing.Size(75, 23)
            Me.button18.TabIndex = 34
            Me.button18.Text = "Show"
            Me.button18.UseVisualStyleBackColor = True
            '
            'label19
            '
            Me.label19.Location = New System.Drawing.Point(8, 345)
            Me.label19.Name = "label19"
            Me.label19.Size = New System.Drawing.Size(208, 26)
            Me.label19.TabIndex = 37
            Me.label19.Text = "Split sample. This example shows how to make split-screen mode."
            Me.label19.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button19
            '
            Me.button19.Location = New System.Drawing.Point(222, 345)
            Me.button19.Name = "button19"
            Me.button19.Size = New System.Drawing.Size(75, 23)
            Me.button19.TabIndex = 36
            Me.button19.Text = "Show"
            Me.button19.UseVisualStyleBackColor = True
            '
            'label20
            '
            Me.label20.Location = New System.Drawing.Point(8, 386)
            Me.label20.Name = "label20"
            Me.label20.Size = New System.Drawing.Size(208, 26)
            Me.label20.TabIndex = 39
            Me.label20.Text = "Lazy loading sample."
            Me.label20.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button20
            '
            Me.button20.Location = New System.Drawing.Point(222, 386)
            Me.button20.Name = "button20"
            Me.button20.Size = New System.Drawing.Size(75, 23)
            Me.button20.TabIndex = 38
            Me.button20.Text = "Show"
            Me.button20.UseVisualStyleBackColor = True
            '
            'label21
            '
            Me.label21.Location = New System.Drawing.Point(315, 471)
            Me.label21.Name = "label21"
            Me.label21.Size = New System.Drawing.Size(208, 23)
            Me.label21.TabIndex = 41
            Me.label21.Text = "Console sample"
            Me.label21.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button21
            '
            Me.button21.Location = New System.Drawing.Point(529, 466)
            Me.button21.Name = "button21"
            Me.button21.Size = New System.Drawing.Size(75, 23)
            Me.button21.TabIndex = 40
            Me.button21.Text = "Show"
            Me.button21.UseVisualStyleBackColor = True
            '
            'label22
            '
            Me.label22.Location = New System.Drawing.Point(315, 53)
            Me.label22.Name = "label22"
            Me.label22.Size = New System.Drawing.Size(208, 26)
            Me.label22.TabIndex = 43
            Me.label22.Text = "Custom code folding sample."
            Me.label22.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'button22
            '
            Me.button22.Location = New System.Drawing.Point(529, 48)
            Me.button22.Name = "button22"
            Me.button22.Size = New System.Drawing.Size(75, 23)
            Me.button22.TabIndex = 42
            Me.button22.Text = "Show"
            Me.button22.UseVisualStyleBackColor = True
            '
            'Label23
            '
            Me.Label23.Location = New System.Drawing.Point(12, 503)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(550, 35)
            Me.Label23.TabIndex = 44
            Me.Label23.Text = "Note: In this project some examples are deprecated and/or not implemented. Newer " & _
        "and full code samples see in project Tester (C#)."
            '
            'MainForm
            '
            Me.ClientSize = New System.Drawing.Size(608, 537)
            Me.Controls.Add(Me.Label23)
            Me.Controls.Add(Me.label22)
            Me.Controls.Add(Me.button22)
            Me.Controls.Add(Me.label21)
            Me.Controls.Add(Me.button21)
            Me.Controls.Add(Me.label20)
            Me.Controls.Add(Me.button20)
            Me.Controls.Add(Me.label19)
            Me.Controls.Add(Me.button19)
            Me.Controls.Add(Me.label18)
            Me.Controls.Add(Me.button18)
            Me.Controls.Add(Me.label17)
            Me.Controls.Add(Me.button17)
            Me.Controls.Add(Me.label16)
            Me.Controls.Add(Me.button16)
            Me.Controls.Add(Me.label15)
            Me.Controls.Add(Me.button15)
            Me.Controls.Add(Me.label14)
            Me.Controls.Add(Me.button14)
            Me.Controls.Add(Me.label13)
            Me.Controls.Add(Me.button13)
            Me.Controls.Add(Me.label12)
            Me.Controls.Add(Me.button12)
            Me.Controls.Add(Me.label11)
            Me.Controls.Add(Me.button11)
            Me.Controls.Add(Me.label10)
            Me.Controls.Add(Me.button10)
            Me.Controls.Add(Me.label9)
            Me.Controls.Add(Me.button9)
            Me.Controls.Add(Me.label8)
            Me.Controls.Add(Me.button8)
            Me.Controls.Add(Me.label7)
            Me.Controls.Add(Me.button7)
            Me.Controls.Add(Me.label6)
            Me.Controls.Add(Me.button6)
            Me.Controls.Add(Me.label5)
            Me.Controls.Add(Me.button5)
            Me.Controls.Add(Me.label4)
            Me.Controls.Add(Me.button4)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.button3)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.button1)
            Me.Name = "MainForm"
            Me.Text = "MainForm"
            Me.ResumeLayout(False)

        End Sub

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
            Dim x = New PowerfulSample
            x.Show()
        End Sub

        Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
            Dim x = New MarkerToolSample
            x.Show()
        End Sub

        Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click
            Dim x = New CustomStyleSample
            x.Show()
        End Sub

        Private Sub button4_Click(sender As Object, e As EventArgs) Handles button4.Click
            Me.Cursor = Cursors.WaitCursor
            Dim x = New VisibleRangeChangedDelayedSample
            x.Show()
            Me.Cursor = Cursors.[Default]
        End Sub

        Private Sub button5_Click(sender As Object, e As EventArgs) Handles button5.Click
            Dim x = New SimplestSyntaxHighlightingSample
            x.Show()
        End Sub

        Private Sub button6_Click(sender As Object, e As EventArgs) Handles button6.Click
            Dim x = New JokeSample
            x.Show()
        End Sub

        Private Sub button7_Click(sender As Object, e As EventArgs) Handles button7.Click
            Dim x = New SimplestCodeFoldingSample
            x.Show()
        End Sub

        Private Sub button8_Click(sender As Object, e As EventArgs) Handles button8.Click
            Dim x = New AutocompleteSample
            x.Show()
        End Sub

        Private Sub button9_Click(sender As Object, e As EventArgs) Handles button9.Click
            Dim x = New DynamicSyntaxHighlighting
            x.Show()
        End Sub

        Private Sub button10_Click(sender As Object, e As EventArgs) Handles button10.Click
            Dim x = New SyntaxHighlightingByXmlDescription
            x.Show()
        End Sub

        Private Sub button11_Click(sender As Object, e As EventArgs) Handles button11.Click
            Dim x = New IMEsample
            x.Show()
        End Sub

        Private Sub button12_Click(sender As Object, e As EventArgs) Handles button12.Click
            Dim x = New PowerfulCSharpEditor
            x.Show()
        End Sub

        Private Sub button13_Click(sender As Object, e As EventArgs) Handles button13.Click
            Dim x = New GifImageDrawingSample
            x.Show()
        End Sub

        Private Sub button14_Click(sender As Object, e As EventArgs) Handles button14.Click
            Dim x = New AutocompleteSample2
            x.Show()
        End Sub

        Private Sub button15_Click(sender As Object, e As EventArgs) Handles button15.Click
            Dim x = New AutoIndentSample
            x.Show()
        End Sub

        Private Sub button16_Click(sender As Object, e As EventArgs) Handles button16.Click
            Dim x = New BookmarksSample
            x.Show()
        End Sub

        Private Sub button17_Click(sender As Object, e As EventArgs) Handles button17.Click
            Dim x = New LoggerSample
            x.Show()
        End Sub

        Private Sub button18_Click(sender As Object, e As EventArgs) Handles button18.Click
            Dim x = New TooltipSample
            x.Show()
        End Sub

        Private Sub button19_Click(sender As Object, e As EventArgs) Handles button19.Click
            Dim x = New SplitSample
            x.Show()
        End Sub

        Private Sub button20_Click(sender As Object, e As EventArgs) Handles button20.Click
            Dim x = New LazyLoadingSample
            x.Show()
        End Sub

        Private Sub button21_Click(sender As Object, e As EventArgs) Handles button21.Click
            Dim x = New ConsoleSample
            x.Show()
        End Sub

        Private Sub button22_Click(sender As Object, e As EventArgs) Handles button22.Click
            Dim x = New CustomFoldingSample
            x.Show()
        End Sub
        Friend WithEvents Label23 As System.Windows.Forms.Label
    End Class
End Namespace
