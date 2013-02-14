Imports FastColoredTextBoxNS
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Namespace TesterVB

    Public Class LazyLoadingSample
        Inherits Form

        Private Const marging As Integer = 2000

        Private components As IContainer = Nothing

        Private fctb As FastColoredTextBox

        Private ofd As OpenFileDialog

        Private ms As MenuStrip

        Private fileToolStripMenuItem As ToolStripMenuItem

        Private miOpen As ToolStripMenuItem

        Private miSave As ToolStripMenuItem

        Private closeFileToolStripMenuItem As ToolStripMenuItem

        Private sfd As SaveFileDialog

        Private createTestFileToolStripMenuItem As ToolStripMenuItem

        Private label2 As Label

        Private editToolStripMenuItem As ToolStripMenuItem

        Private collapseAllFoldingBlocksToolStripMenuItem As ToolStripMenuItem

        Private expandAllCollapsedBlocksToolStripMenuItem As ToolStripMenuItem

        Private removeEmptyLinesToolStripMenuItem As ToolStripMenuItem

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(LazyLoadingSample))
            Me.ofd = New OpenFileDialog()
            Me.ms = New MenuStrip()
            Me.fileToolStripMenuItem = New ToolStripMenuItem()
            Me.miOpen = New ToolStripMenuItem()
            Me.miSave = New ToolStripMenuItem()
            Me.closeFileToolStripMenuItem = New ToolStripMenuItem()
            Me.editToolStripMenuItem = New ToolStripMenuItem()
            Me.collapseAllFoldingBlocksToolStripMenuItem = New ToolStripMenuItem()
            Me.expandAllCollapsedBlocksToolStripMenuItem = New ToolStripMenuItem()
            Me.removeEmptyLinesToolStripMenuItem = New ToolStripMenuItem()
            Me.createTestFileToolStripMenuItem = New ToolStripMenuItem()
            Me.sfd = New SaveFileDialog()
            Me.label2 = New Label()
            Me.fctb = New FastColoredTextBox()
            Me.ms.SuspendLayout()
            MyBase.SuspendLayout()
            Me.ofd.DefaultExt = "txt"
            Me.ofd.Filter = "Text file|*.txt|All files|*.*"
            Me.ms.Items.AddRange(New ToolStripItem() {Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.createTestFileToolStripMenuItem})
            Me.ms.Location = New Point(0, 0)
            Me.ms.Name = "ms"
            Me.ms.Size = New Size(647, 24)
            Me.ms.TabIndex = 1
            Me.ms.Text = "menuStrip1"
            Me.fileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.miOpen, Me.miSave, Me.closeFileToolStripMenuItem})
            Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
            Me.fileToolStripMenuItem.Size = New Size(37, 20)
            Me.fileToolStripMenuItem.Text = "File"
            Me.miOpen.Name = "miOpen"
            Me.miOpen.Size = New Size(166, 22)
            Me.miOpen.Text = "Bind to file ..."
            AddHandler Me.miOpen.Click, New EventHandler(AddressOf Me.miOpen_Click)
            Me.miSave.Name = "miSave"
            Me.miSave.Size = New Size(166, 22)
            Me.miSave.Text = "Save to file ..."
            AddHandler Me.miSave.Click, New EventHandler(AddressOf Me.miSave_Click)
            Me.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem"
            Me.closeFileToolStripMenuItem.Size = New Size(166, 22)
            Me.closeFileToolStripMenuItem.Text = "Close binding file"
            AddHandler Me.closeFileToolStripMenuItem.Click, New EventHandler(AddressOf Me.closeFileToolStripMenuItem_Click)
            Me.editToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.collapseAllFoldingBlocksToolStripMenuItem, Me.expandAllCollapsedBlocksToolStripMenuItem, Me.removeEmptyLinesToolStripMenuItem})
            Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
            Me.editToolStripMenuItem.Size = New Size(39, 20)
            Me.editToolStripMenuItem.Text = "Edit"
            Me.collapseAllFoldingBlocksToolStripMenuItem.Name = "collapseAllFoldingBlocksToolStripMenuItem"
            Me.collapseAllFoldingBlocksToolStripMenuItem.Size = New Size(217, 22)
            Me.collapseAllFoldingBlocksToolStripMenuItem.Text = "Collapse all folding blocks"
            AddHandler Me.collapseAllFoldingBlocksToolStripMenuItem.Click, New EventHandler(AddressOf Me.collapseAllFoldingBlocksToolStripMenuItem_Click)
            Me.expandAllCollapsedBlocksToolStripMenuItem.Name = "expandAllCollapsedBlocksToolStripMenuItem"
            Me.expandAllCollapsedBlocksToolStripMenuItem.Size = New Size(217, 22)
            Me.expandAllCollapsedBlocksToolStripMenuItem.Text = "Expand all collapsed blocks"
            AddHandler Me.expandAllCollapsedBlocksToolStripMenuItem.Click, New EventHandler(AddressOf Me.expandAllCollapsedBlocksToolStripMenuItem_Click)
            Me.removeEmptyLinesToolStripMenuItem.Name = "removeEmptyLinesToolStripMenuItem"
            Me.removeEmptyLinesToolStripMenuItem.Size = New Size(217, 22)
            Me.removeEmptyLinesToolStripMenuItem.Text = "Remove empty lines"
            AddHandler Me.removeEmptyLinesToolStripMenuItem.Click, New EventHandler(AddressOf Me.removeEmptyLinesToolStripMenuItem_Click)
            Me.createTestFileToolStripMenuItem.Name = "createTestFileToolStripMenuItem"
            Me.createTestFileToolStripMenuItem.Size = New Size(94, 20)
            Me.createTestFileToolStripMenuItem.Text = "Create test file"
            AddHandler Me.createTestFileToolStripMenuItem.Click, New EventHandler(AddressOf Me.createTestFileToolStripMenuItem_Click)
            Me.sfd.DefaultExt = "txt"
            Me.sfd.Filter = "Text file|*.txt|All files|*.*"
            Me.label2.Dock = DockStyle.Top
            Me.label2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204)
            Me.label2.Location = New Point(0, 24)
            Me.label2.Name = "label2"
            Me.label2.Size = New Size(647, 62)
            Me.label2.TabIndex = 3
            Me.label2.Text = resources.GetString("label2.Text")
            Me.fctb.AutoScrollMinSize = New Size(480, 45)
            Me.fctb.BackBrush = Nothing
            Me.fctb.Cursor = Cursors.IBeam
            Me.fctb.DelayedEventsInterval = 300
            Me.fctb.DisabledColor = Color.FromArgb(100, 180, 180, 180)
            Me.fctb.Dock = DockStyle.Fill
            Me.fctb.Font = New Font("Consolas", 9.75F)
            Me.fctb.Location = New Point(0, 86)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New Padding(0)
            Me.fctb.SelectionColor = Color.FromArgb(50, 0, 0, 255)
            Me.fctb.Size = New Size(647, 251)
            Me.fctb.TabIndex = 0
            Me.fctb.Text = "Press ""Create test file"", select target directory and press Save." & vbCrLf & "Will be created large file (approx. 50mb). " & vbCrLf & "Then bind file to the control in menu File/Bind to file."
            AddHandler Me.fctb.TextChangedDelayed, New EventHandler(Of TextChangedEventArgs)(AddressOf Me.fctb_TextChangedDelayed)
            AddHandler Me.fctb.VisibleRangeChangedDelayed, New EventHandler(AddressOf Me.fctb_VisibleRangeChangedDelayed)
            MyBase.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            MyBase.AutoScaleMode = AutoScaleMode.Font
            MyBase.ClientSize = New Size(647, 337)
            MyBase.Controls.Add(Me.fctb)
            MyBase.Controls.Add(Me.label2)
            MyBase.Controls.Add(Me.ms)
            MyBase.MainMenuStrip = Me.ms
            MyBase.Name = "LazyLoadingSample"
            Me.Text = "LazyLoadingSample"
            AddHandler MyBase.FormClosing, New FormClosingEventHandler(AddressOf Me.LazyLoadingSample_FormClosing)
            Me.ms.ResumeLayout(False)
            Me.ms.PerformLayout()
            MyBase.ResumeLayout(False)
            MyBase.PerformLayout()
        End Sub

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub miOpen_Click(sender As Object, e As EventArgs)
            If Me.ofd.ShowDialog() = DialogResult.OK Then
                Me.fctb.OpenBindingFile(Me.ofd.FileName, Encoding.UTF8)
                Me.fctb.IsChanged = False
                Me.fctb.ClearUndo()
                GC.Collect()
                GC.GetTotalMemory(True)
            End If
        End Sub

        Private Sub fctb_VisibleRangeChangedDelayed(sender As Object, e As EventArgs)
            Me.HighlightVisibleRange()
        End Sub

        Private Sub fctb_TextChangedDelayed(sender As Object, e As TextChangedEventArgs)
            Me.HighlightVisibleRange()
        End Sub

        Private Sub HighlightVisibleRange()
            Dim startLine As Integer = Math.Max(0, Me.fctb.VisibleRange.Start.iLine - 2000)
            Dim endLine As Integer = Math.Min(Me.fctb.LinesCount - 1, Me.fctb.VisibleRange.[End].iLine + 2000)
            Dim range As Range = New Range(Me.fctb, 0, startLine, 0, endLine)
            range.ClearFoldingMarkers()
            range.SetFoldingMarkers("N\d\d00", "N\d\d99")
            range.ClearStyle(StyleIndex.All)
            range.SetStyle(Me.fctb.SyntaxHighlighter.BlueStyle, "N\d+")
            range.SetStyle(Me.fctb.SyntaxHighlighter.RedStyle, "[+\-]?[\d\.]+\d+")
        End Sub

        Private Sub closeFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Me.fctb.CloseBindingFile()
        End Sub

        Private Sub LazyLoadingSample_FormClosing(sender As Object, e As FormClosingEventArgs)
            Me.fctb.CloseBindingFile()
        End Sub

        Private Sub miSave_Click(sender As Object, e As EventArgs)
            If Me.sfd.ShowDialog() = DialogResult.OK Then
                Me.fctb.SaveToFile(Me.sfd.FileName, Encoding.UTF8)
            End If
        End Sub

        Private Sub createTestFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Dim rnd As Random = New Random()
            If Me.sfd.ShowDialog() = DialogResult.OK Then
                Using sw As StreamWriter = New StreamWriter(Me.sfd.FileName, False, Encoding.[Default])
                    For i As Integer = 0 To 130 - 1
                        sw.WriteLine(vbCrLf & "--====" & i & "=====--" & vbCrLf)
                        For j As Integer = 0 To 10000 - 1
                            sw.WriteLine(String.Format("N{0:0000} X{1} Y{2} Z{3}", New Object() {j, rnd.[Next](), rnd.[Next](), rnd.[Next]()}))
                        Next
                    Next
                End Using
            End If
        End Sub

        Private Sub collapseAllFoldingBlocksToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Me.fctb.CollapseAllFoldingBlocks()
            Me.fctb.DoSelectionVisible()
        End Sub

        Private Sub expandAllCollapsedBlocksToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Me.fctb.ExpandAllFoldingBlocks()
            Me.fctb.DoSelectionVisible()
        End Sub

        Private Sub removeEmptyLinesToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Dim iLines As List(Of Integer) = Me.fctb.FindLines("^\s*$", RegexOptions.None)
            Me.fctb.RemoveLines(iLines)
        End Sub
    End Class
End Namespace
