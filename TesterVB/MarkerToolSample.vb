Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace TesterVB
    Public Class MarkerToolSample
        Inherits Form

        Private components As IContainer = Nothing

        Private fctb As FastColoredTextBox

        Private cmMark As ContextMenuStrip

        Private markAsYellowToolStripMenuItem As ToolStripMenuItem

        Private markAsRedToolStripMenuItem As ToolStripMenuItem

        Private markAsGreenToolStripMenuItem As ToolStripMenuItem

        Private toolStripMenuItem1 As ToolStripSeparator

        Private clearMarkedToolStripMenuItem As ToolStripMenuItem

        Private markLineBackgroundToolStripMenuItem As ToolStripMenuItem

        Private toolStripMenuItem2 As ToolStripSeparator

        Private shortCutStyle As ShortcutStyle = New ShortcutStyle(Pens.Maroon)

        Private YellowStyle As MarkerStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(180, Color.Yellow)))

        Private RedStyle As MarkerStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(180, Color.Red)))

        Private GreenStyle As MarkerStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(180, Color.Green)))

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.components = New Container()
            Me.cmMark = New ContextMenuStrip(Me.components)
            Me.markAsYellowToolStripMenuItem = New ToolStripMenuItem()
            Me.markAsRedToolStripMenuItem = New ToolStripMenuItem()
            Me.markAsGreenToolStripMenuItem = New ToolStripMenuItem()
            Me.toolStripMenuItem1 = New ToolStripSeparator()
            Me.markLineBackgroundToolStripMenuItem = New ToolStripMenuItem()
            Me.toolStripMenuItem2 = New ToolStripSeparator()
            Me.clearMarkedToolStripMenuItem = New ToolStripMenuItem()
            Me.fctb = New FastColoredTextBox()
            Me.cmMark.SuspendLayout()
            MyBase.SuspendLayout()
            Me.cmMark.Items.AddRange(New ToolStripItem() {Me.markAsYellowToolStripMenuItem, Me.markAsRedToolStripMenuItem, Me.markAsGreenToolStripMenuItem, Me.toolStripMenuItem1, Me.markLineBackgroundToolStripMenuItem, Me.toolStripMenuItem2, Me.clearMarkedToolStripMenuItem})
            Me.cmMark.Name = "contextMenuStrip1"
            Me.cmMark.Size = New Size(191, 126)
            Me.markAsYellowToolStripMenuItem.Name = "markAsYellowToolStripMenuItem"
            Me.markAsYellowToolStripMenuItem.Size = New Size(190, 22)
            Me.markAsYellowToolStripMenuItem.Tag = "yellow"
            Me.markAsYellowToolStripMenuItem.Text = "Mark as Yellow"
            AddHandler Me.markAsYellowToolStripMenuItem.Click, New EventHandler(AddressOf Me.markAsYellowToolStripMenuItem_Click)
            Me.markAsRedToolStripMenuItem.Name = "markAsRedToolStripMenuItem"
            Me.markAsRedToolStripMenuItem.Size = New Size(190, 22)
            Me.markAsRedToolStripMenuItem.Tag = "red"
            Me.markAsRedToolStripMenuItem.Text = "Mark as Red"
            AddHandler Me.markAsRedToolStripMenuItem.Click, New EventHandler(AddressOf Me.markAsYellowToolStripMenuItem_Click)
            Me.markAsGreenToolStripMenuItem.Name = "markAsGreenToolStripMenuItem"
            Me.markAsGreenToolStripMenuItem.Size = New Size(190, 22)
            Me.markAsGreenToolStripMenuItem.Tag = "green"
            Me.markAsGreenToolStripMenuItem.Text = "Mark as Green"
            AddHandler Me.markAsGreenToolStripMenuItem.Click, New EventHandler(AddressOf Me.markAsYellowToolStripMenuItem_Click)
            Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
            Me.toolStripMenuItem1.Size = New Size(187, 6)
            Me.markLineBackgroundToolStripMenuItem.Name = "markLineBackgroundToolStripMenuItem"
            Me.markLineBackgroundToolStripMenuItem.Size = New Size(190, 22)
            Me.markLineBackgroundToolStripMenuItem.Tag = "lineBackground"
            Me.markLineBackgroundToolStripMenuItem.Text = "Mark line background"
            AddHandler Me.markLineBackgroundToolStripMenuItem.Click, New EventHandler(AddressOf Me.markAsYellowToolStripMenuItem_Click)
            Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
            Me.toolStripMenuItem2.Size = New Size(187, 6)
            Me.clearMarkedToolStripMenuItem.Name = "clearMarkedToolStripMenuItem"
            Me.clearMarkedToolStripMenuItem.Size = New Size(190, 22)
            Me.clearMarkedToolStripMenuItem.Text = "Clear marked"
            AddHandler Me.clearMarkedToolStripMenuItem.Click, New EventHandler(AddressOf Me.clearMarkedToolStripMenuItem_Click)
            Me.fctb.AutoIndent = False
            Me.fctb.AutoScrollMinSize = New Size(0, 15)
            Me.fctb.BackBrush = Nothing
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.DelayedEventsInterval = 500
            Me.fctb.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Consolas", 9.75F)
            Me.fctb.IndentBackColor = Color.FromArgb(50, 255, 255, 255)
            Me.fctb.LeftBracket = "("
            Me.fctb.LeftPadding = 15
            Me.fctb.Location = New Point(0, 0)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New Padding(0)
            Me.fctb.RightBracket = ")"
            Me.fctb.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctb.Size = New Size(447, 262)
            Me.fctb.TabIndex = 0
            Me.fctb.WordWrap = True
            AddHandler Me.fctb.SelectionChangedDelayed, New EventHandler(AddressOf Me.fctb_SelectionChangedDelayed)
            AddHandler Me.fctb.VisualMarkerClick, New EventHandler(Of VisualMarkerEventArgs)(AddressOf Me.fctb_VisualMarkerClick)
            AddHandler Me.fctb.PaintLine, New EventHandler(Of PaintLineEventArgs)(AddressOf Me.fctb_PaintLine)
            AddHandler Me.fctb.Resize, New EventHandler(AddressOf Me.fctb_Resize)
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(447, 262)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Name = "MarkerToolSample"
            Me.Text = "MarkerTool Sample"
            Me.cmMark.ResumeLayout(False)
            MyBase.ResumeLayout(False)
        End Sub

        Public Sub New()
            Me.InitializeComponent()
            Me.fctb.Text = "This example shows how to create Marker Tool and usage of ShortcutStyle class." & vbLf & "Also VisualMarkerClick event handling is present." & vbLf & "Also it shows how to set priority of styles." & vbLf & vbLf & "Select any text, please."
            Me.fctb.AddStyle(Me.YellowStyle)
            Me.fctb.AddStyle(Me.RedStyle)
            Me.fctb.AddStyle(Me.GreenStyle)
            Me.fctb.AddStyle(Me.shortCutStyle)
            Me.fctb_Resize(Me.fctb, Nothing)
        End Sub

        Private Sub fctb_SelectionChangedDelayed(sender As Object, e As EventArgs)
            Dim selection As Range = Me.fctb.Selection
            Me.fctb.VisibleRange.ClearStyle(New Style() {Me.shortCutStyle})
            If Not selection.IsEmpty Then
                Dim r As Range = selection.Clone()
                r.Normalize()
                r.Start = r.[End]
                r.GoLeft(True)
                r.SetStyle(Me.shortCutStyle)
            End If
        End Sub

        Private Sub fctb_VisualMarkerClick(sender As Object, e As VisualMarkerEventArgs)
            If e.Style Is Me.shortCutStyle Then
                Me.cmMark.Show(Me.fctb.PointToScreen(e.Location))
            End If
        End Sub

        Private Sub markAsYellowToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Me.TrimSelection()
            Dim text As String = CStr(TryCast(sender, ToolStripMenuItem).Tag)
            If text IsNot Nothing Then
                If Not text = "yellow" Then
                    If Not text = "red" Then
                        If Not text = "green" Then
                            If text = "lineBackground" Then
                                Me.fctb(Me.fctb.Selection.Start.iLine).BackgroundBrush = Brushes.Pink
                            End If
                        Else
                            Me.fctb.Selection.SetStyle(Me.GreenStyle)
                        End If
                    Else
                        Me.fctb.Selection.SetStyle(Me.RedStyle)
                    End If
                Else
                    Me.fctb.Selection.SetStyle(Me.YellowStyle)
                End If
            End If
            Me.fctb.Selection.ClearStyle(New Style() {Me.shortCutStyle})
        End Sub

        Private Sub TrimSelection()
            Dim sel As Range = Me.fctb.Selection
            sel.Normalize()
            While Char.IsWhiteSpace(sel.CharAfterStart) AndAlso sel.Start < sel.[End]
                sel.GoRight(True)
            End While
            sel.Inverse()
            While Char.IsWhiteSpace(sel.CharBeforeStart) AndAlso sel.Start > sel.[End]
                sel.GoLeft(True)
            End While
        End Sub

        Private Sub clearMarkedToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Me.fctb.Selection.ClearStyle(New Style() {Me.YellowStyle, Me.RedStyle, Me.GreenStyle})
            Me.fctb(Me.fctb.Selection.Start.iLine).BackgroundBrush = Nothing
        End Sub

        Private Sub fctb_PaintLine(sender As Object, e As PaintLineEventArgs)
            If e.LineIndex = Me.fctb.Selection.Start.iLine Then
                e.Graphics.FillEllipse(New LinearGradientBrush(New Rectangle(0, e.LineRect.Top, 15, 15), Color.LightPink, Color.Red, 45.0F), 0, e.LineRect.Top, 15, 15)
            End If
        End Sub

        Private Sub fctb_Resize(sender As Object, e As EventArgs)
            Me.fctb.BackBrush = New LinearGradientBrush(Me.fctb.ClientRectangle, Color.White, Color.Silver, LinearGradientMode.Vertical)
        End Sub
    End Class
End Namespace
