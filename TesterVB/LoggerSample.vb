Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB
    Public Class LoggerSample
        Inherits Form

        Private components As IContainer = Nothing

        Private label1 As Label

        Private fctb As FastColoredTextBox

        Private btGotToEnd As Button

        Private tm As Timer

        Private infoStyle As TextStyle = New TextStyle(Brushes.Black, Nothing, FontStyle.Regular)

        Private warningStyle As TextStyle = New TextStyle(Brushes.BurlyWood, Nothing, FontStyle.Regular)

        Private errorStyle As TextStyle = New TextStyle(Brushes.Red, Nothing, FontStyle.Regular)

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.components = New Container()
            Me.label1 = New Label()
            Me.btGotToEnd = New Button()
            Me.tm = New Timer(Me.components)
            Me.fctb = New FastColoredTextBox()
            MyBase.SuspendLayout()
            Me.label1.Dock = DockStyle.Top
            Me.label1.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204)
            Me.label1.Location = New Point(0, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New Size(355, 40)
            Me.label1.TabIndex = 4
            Me.label1.Text = "This example shows how to add text with predefined style." & vbCrLf & "Note: It correctly works only for readonly mode."
            Me.btGotToEnd.Dock = DockStyle.Bottom
            Me.btGotToEnd.Location = New Point(0, 289)
            Me.btGotToEnd.Name = "btGotToEnd"
            Me.btGotToEnd.Size = New Size(355, 23)
            Me.btGotToEnd.TabIndex = 6
            Me.btGotToEnd.Text = "Go to end"
            Me.btGotToEnd.UseVisualStyleBackColor = True
            AddHandler Me.btGotToEnd.Click, New EventHandler(AddressOf Me.btGotToEnd_Click)
            Me.tm.Enabled = True
            AddHandler Me.tm.Tick, New EventHandler(AddressOf Me.tm_Tick)
            Me.fctb.AutoScrollMinSize = New Size(25, 15)
            Me.fctb.BackBrush = Nothing
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Consolas", 9.75F)
            Me.fctb.Location = New Point(0, 40)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New Padding(0)
            Me.fctb.[ReadOnly] = True
            Me.fctb.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctb.Size = New Size(355, 249)
            Me.fctb.TabIndex = 5
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(355, 312)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Controls.Add(Me.label1)
            MyBase.Controls.Add(Me.btGotToEnd)
            MyBase.Name = "LoggerSample"
            Me.Text = "LoggerSample"
            MyBase.ResumeLayout(False)
        End Sub

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub tm_Tick(sender As Object, e As EventArgs)
            Select Case DateTime.Now.Millisecond Mod 3
                Case 0
                    Me.Log(DateTime.Now + " Error" & vbCrLf, Me.errorStyle)
                Case 1
                    Me.Log(DateTime.Now + " Warning" & vbCrLf, Me.warningStyle)
                Case 2
                    Me.Log(DateTime.Now + " Info" & vbCrLf, Me.infoStyle)
            End Select
        End Sub

        Private Sub Log(text As String, style As Style)
            Me.fctb.BeginUpdate()
            Me.fctb.Selection.BeginUpdate()
            Dim userSelection As Range = Me.fctb.Selection.Clone()
            Me.fctb.Selection.Start = If(Me.fctb.LinesCount > 0, New Place(Me.fctb(Me.fctb.LinesCount - 1).Count, Me.fctb.LinesCount - 1), New Place(0, 0))
            Me.fctb.InsertText(text, style)
            If Not userSelection.IsEmpty OrElse userSelection.Start.iLine < Me.fctb.LinesCount - 2 Then
                Me.fctb.Selection.Start = userSelection.Start
                Me.fctb.Selection.[End] = userSelection.[End]
            Else
                Me.fctb.DoCaretVisible()
            End If
            Me.fctb.Selection.EndUpdate()
            Me.fctb.EndUpdate()
        End Sub

        Private Sub btGotToEnd_Click(sender As Object, e As EventArgs)
            Me.fctb.GoEnd()
        End Sub
    End Class
End Namespace
