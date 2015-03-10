Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB
    Public Class SplitSample
        Inherits Form

        Private components As IContainer = Nothing

        Private fctbMaster As FastColoredTextBox

        Private fctbSlave As FastColoredTextBox

        Private label1 As Label

        Private label2 As Label

        Private splitter1 As Splitter

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(SplitSample))
            Me.label1 = New Label()
            Me.label2 = New Label()
            Me.splitter1 = New Splitter()
            Me.fctbMaster = New FastColoredTextBox()
            Me.fctbSlave = New FastColoredTextBox()
            MyBase.SuspendLayout()
            Me.label1.AutoSize = True
            Me.label1.Location = New Point(331, 59)
            Me.label1.Name = "label1"
            Me.label1.Size = New Size(35, 13)
            Me.label1.TabIndex = 2
            Me.label1.Text = "label1"
            Me.label2.Dock = DockStyle.Top
            Me.label2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204)
            Me.label2.Location = New Point(0, 0)
            Me.label2.Name = "label2"
            Me.label2.Size = New Size(610, 93)
            Me.label2.TabIndex = 3
            Me.label2.Text = "This example shows how to make split-screen mode." & vbCrLf &
"The form contains  two FCTB. One of them works as a master, the other - as a slave. Slave FCTB has property SourceTextBox referenced to the master FCTB." & vbCrLf &
"Note: Main properties (for example Language) and handlers(for example  TextChanged) for each control (master and slave) must be equal. "

            Me.splitter1.BorderStyle = BorderStyle.FixedSingle
            Me.splitter1.Dock = DockStyle.Bottom
            Me.splitter1.Location = New Point(0, 298)
            Me.splitter1.MinSize = 0
            Me.splitter1.Name = "splitter1"
            Me.splitter1.Size = New Size(610, 6)
            Me.splitter1.TabIndex = 4
            Me.splitter1.TabStop = False
            Me.fctbMaster.AutoScrollMinSize = New Size(284, 255)
            Me.fctbMaster.BackBrush = Nothing
            Me.fctbMaster.Cursor = Cursors.IBeam
            Me.fctbMaster.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctbMaster.Dock = DockStyle.Fill
            Me.fctbMaster.Font = New Font("Consolas", 9.75F)
            Me.fctbMaster.Language = Language.CSharp
            Me.fctbMaster.LeftBracket = "("
            Me.fctbMaster.Location = New Point(0, 93)
            Me.fctbMaster.Name = "fctbMaster"
            Me.fctbMaster.Paddings = New Padding(0)
            Me.fctbMaster.RightBracket = ")"
            Me.fctbMaster.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctbMaster.Size = New Size(610, 205)
            Me.fctbMaster.TabIndex = 0
            Me.fctbMaster.Text = "#region Char" & vbCrLf & "    /// <summary>" & vbCrLf & "    /// Char and style" & vbCrLf & "    /// </summary>" & vbCrLf & "    struct Char" & vbCrLf & "    {" & vbCrLf & "        public char c;" & vbCrLf & "        public StyleIndex style;" & vbCrLf & "" & vbCrLf & "        public Char(char c)" & vbCrLf & "        {" & vbCrLf & "            this.c = c;" & vbCrLf & "            style = StyleIndex.None;" & vbCrLf & "        }" & vbCrLf & "    }" & vbCrLf & "    #endregion"
            AddHandler Me.fctbMaster.Scroll, New ScrollEventHandler(AddressOf Me.fctbMaster_Scroll)
            Me.fctbSlave.AutoScrollMinSize = New Size(0, 255)
            Me.fctbSlave.BackBrush = Nothing
            Me.fctbSlave.Cursor = Cursors.IBeam
            Me.fctbSlave.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctbSlave.Dock = DockStyle.Bottom
            Me.fctbSlave.Font = New Font("Consolas", 9.75F)
            Me.fctbSlave.Language = Language.CSharp
            Me.fctbSlave.LeftBracket = "("
            Me.fctbSlave.Location = New Point(0, 304)
            Me.fctbSlave.Name = "fctbSlave"
            Me.fctbSlave.Paddings = New Padding(0)
            Me.fctbSlave.RightBracket = ")"
            Me.fctbSlave.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctbSlave.Size = New Size(610, 166)
            Me.fctbSlave.SourceTextBox = Me.fctbMaster
            Me.fctbSlave.TabIndex = 1
            Me.fctbSlave.Text = "#region Char" & vbCrLf & "    /// <summary>" & vbCrLf & "    /// Char and style" & vbCrLf & "    /// </summary>" & vbCrLf & "    struct Char" & vbCrLf & "    {" & vbCrLf & "        public char c;" & vbCrLf & "        public StyleIndex style;" & vbCrLf & "" & vbCrLf & "        public Char(char c)" & vbCrLf & "        {" & vbCrLf & "            this.c = c;" & vbCrLf & "            style = StyleIndex.None;" & vbCrLf & "        }" & vbCrLf & "    }" & vbCrLf & "    #endregion"
            Me.fctbSlave.WordWrap = True
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(610, 470)
            MyBase.Controls.Add(Me.fctbMaster)
            MyBase.Controls.Add(Me.splitter1)
            MyBase.Controls.Add(Me.label2)
            MyBase.Controls.Add(Me.label1)
            MyBase.Controls.Add(Me.fctbSlave)
            MyBase.Name = "SplitSample"
            Me.Text = "SplitSample"
            MyBase.ResumeLayout(False)
            MyBase.PerformLayout()
        End Sub

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub fctbMaster_Scroll(sender As Object, e As ScrollEventArgs)
            Me.fctbSlave.VerticalScroll.Value = Me.fctbMaster.VerticalScroll.Value
            Me.fctbSlave.Invalidate()
        End Sub
    End Class
End Namespace
