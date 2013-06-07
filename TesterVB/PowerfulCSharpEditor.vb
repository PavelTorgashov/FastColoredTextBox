Imports FarsiLibrary.Win
Imports FastColoredTextBoxNS
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms

'-----------------------------------------------------------------------------------------------------
' Note: this sample is deprecated. See project Tester for newest code samples.
' For example: Bookmarks now is built-in feature. But this sample implements bookmarks manually.
'-----------------------------------------------------------------------------------------------------

Namespace TesterVB
    Partial Public Class PowerfulCSharpEditor
        Inherits Form

        Private Enum ExplorerItemType
            [Class]
            Method
            [Property]
            [Event]
        End Enum

        Private Class ExplorerItem
            Public type As PowerfulCSharpEditor.ExplorerItemType

            Public title As String

            Public position As Integer
        End Class

        Private Class ExplorerItemComparer
            Implements IComparer(Of PowerfulCSharpEditor.ExplorerItem)

            Public Function Compare(x As PowerfulCSharpEditor.ExplorerItem, y As PowerfulCSharpEditor.ExplorerItem) As Integer Implements IComparer(Of PowerfulCSharpEditor.ExplorerItem).Compare
                Return x.title.CompareTo(y.title)
            End Function
        End Class

        Private Class DeclarationSnippet
            Inherits SnippetAutocompleteItem

            Public Sub New(snippet As String)
                MyBase.New(snippet)
            End Sub

            Public Overrides Function Compare(fragmentText As String) As CompareResult
                Dim pattern As String = Regex.Escape(fragmentText)
                Dim result As CompareResult
                If Regex.IsMatch(Me.Text, "\b" + pattern, RegexOptions.IgnoreCase) Then
                    result = CompareResult.Visible
                Else
                    result = CompareResult.Hidden
                End If
                Return result
            End Function
        End Class

        Private Class InsertSpaceSnippet
            Inherits AutocompleteItem

            Private pattern As String

            Public Overrides Property ToolTipTitle() As String
                Get
                    Return Me.Text
                End Get
                Set(value As String)

                End Set
            End Property

            Public Sub New(pattern As String)
                MyBase.New("")
                Me.pattern = pattern
            End Sub

            Public Sub New()
                Me.New("^(\d+)([a-zA-Z_]+)(\d*)$")
            End Sub

            Public Overrides Function Compare(fragmentText As String) As CompareResult
                Dim result As CompareResult
                If Regex.IsMatch(fragmentText, Me.pattern) Then
                    Me.Text = Me.InsertSpaces(fragmentText)
                    If Me.Text <> fragmentText Then
                        result = CompareResult.Visible
                        Return result
                    End If
                End If
                result = CompareResult.Hidden
                Return result
            End Function

            Public Function InsertSpaces(fragment As String) As String
                Dim i As Match = Regex.Match(fragment, Me.pattern)
                Dim result As String
                If i Is Nothing Then
                    result = fragment
                Else
                    If i.Groups(1).Value = "" AndAlso i.Groups(3).Value = "" Then
                        result = fragment
                    Else
                        result = String.Concat(New String() {i.Groups(1).Value, " ", i.Groups(2).Value, " ", i.Groups(3).Value}).Trim()
                    End If
                End If
                Return result
            End Function
        End Class

        Private Class InsertEnterSnippet
            Inherits AutocompleteItem

            Private enterPlace As Place = Place.Empty

            Public Overrides Property ToolTipTitle() As String
                Get
                    Return "Insert line break after '}'"
                End Get
                Set(value As String)

                End Set
            End Property

            Public Sub New()
                MyBase.New("[Line break]")
            End Sub

            Public Overrides Function Compare(fragmentText As String) As CompareResult
                Dim r As Range = MyBase.Parent.Fragment.Clone()
                Dim result As CompareResult
                While r.Start.iChar > 0
                    If r.CharBeforeStart = "}" Then
                        Me.enterPlace = r.Start
                        result = CompareResult.Visible
                        Return result
                    End If
                    r.GoLeftThroughFolded()
                End While
                result = CompareResult.Hidden
                Return result
            End Function

            Public Overrides Function GetTextForReplace() As String
                Dim r As Range = MyBase.Parent.Fragment
                Dim [end] As Place = r.[End]
                r.Start = Me.enterPlace
                r.[End] = r.[End]
                Return Environment.NewLine + r.Text
            End Function

            Public Overrides Sub OnSelected(popupMenu As AutocompleteMenu, e As SelectedEventArgs)
                MyBase.OnSelected(popupMenu, e)
                If MyBase.Parent.Fragment.tb.AutoIndent Then
                    MyBase.Parent.Fragment.tb.DoAutoIndent()
                End If
            End Sub
        End Class

        Public Class BookmarkInfo
            Public iBookmark As Integer
            Public tb As FastColoredTextBox
        End Class

        Private components As IContainer = Nothing

        Private WithEvents msMain As MenuStrip

        Private WithEvents fileToolStripMenuItem As ToolStripMenuItem

        Private WithEvents openToolStripMenuItem As ToolStripMenuItem

        Private WithEvents saveToolStripMenuItem As ToolStripMenuItem

        Private WithEvents saveAsToolStripMenuItem As ToolStripMenuItem

        Private WithEvents toolStripMenuItem1 As ToolStripSeparator

        Private WithEvents quitToolStripMenuItem As ToolStripMenuItem

        Private WithEvents ssMain As StatusStrip

        Private WithEvents tsMain As ToolStrip

        Private WithEvents tsFiles As FATabStrip

        Private WithEvents newToolStripMenuItem As ToolStripMenuItem

        Private WithEvents splitter1 As Splitter

        Private WithEvents sfdMain As SaveFileDialog

        Private WithEvents ofdMain As OpenFileDialog

        Private WithEvents cmMain As ContextMenuStrip

        Private WithEvents cutToolStripMenuItem As ToolStripMenuItem

        Private WithEvents copyToolStripMenuItem As ToolStripMenuItem

        Private WithEvents pasteToolStripMenuItem As ToolStripMenuItem

        Private WithEvents selectAllToolStripMenuItem As ToolStripMenuItem

        Private WithEvents toolStripMenuItem2 As ToolStripSeparator

        Private WithEvents undoToolStripMenuItem As ToolStripMenuItem

        Private WithEvents redoToolStripMenuItem As ToolStripMenuItem

        Private WithEvents tmUpdateInterface As System.Windows.Forms.Timer

        Private WithEvents newToolStripButton As ToolStripButton

        Private WithEvents openToolStripButton As ToolStripButton

        Private WithEvents saveToolStripButton As ToolStripButton

        Private WithEvents printToolStripButton As ToolStripButton

        Private WithEvents toolStripSeparator As ToolStripSeparator

        Private WithEvents cutToolStripButton As ToolStripButton

        Private WithEvents copyToolStripButton As ToolStripButton

        Private WithEvents pasteToolStripButton As ToolStripButton

        Private WithEvents toolStripSeparator1 As ToolStripSeparator

        Private WithEvents undoStripButton As ToolStripButton

        Private WithEvents redoStripButton As ToolStripButton

        Private WithEvents toolStripSeparator2 As ToolStripSeparator

        Private WithEvents tbFind As ToolStripTextBox

        Private WithEvents toolStripLabel1 As ToolStripLabel

        Private WithEvents toolStripMenuItem3 As ToolStripSeparator

        Private WithEvents findToolStripMenuItem As ToolStripMenuItem

        Private WithEvents replaceToolStripMenuItem As ToolStripMenuItem

        Private WithEvents dgvObjectExplorer As DataGridView

        Private WithEvents backStripButton As ToolStripButton

        Private WithEvents forwardStripButton As ToolStripButton

        Private WithEvents toolStripSeparator3 As ToolStripSeparator

        Private WithEvents toolStripSeparator4 As ToolStripSeparator

        Private WithEvents toolStripSeparator5 As ToolStripSeparator

        Private WithEvents clImage As DataGridViewImageColumn

        Private WithEvents clName As DataGridViewTextBoxColumn

        Private WithEvents lbWordUnderMouse As ToolStripStatusLabel

        Private WithEvents ilAutocomplete As ImageList

        Private WithEvents toolStripMenuItem4 As ToolStripSeparator

        Private WithEvents autoIndentSelectedTextToolStripMenuItem As ToolStripMenuItem

        Private WithEvents btInvisibleChars As ToolStripButton

        Private WithEvents btHighlightCurrentLine As ToolStripButton

        Private WithEvents commentSelectedToolStripMenuItem As ToolStripMenuItem

        Private WithEvents uncommentSelectedToolStripMenuItem As ToolStripMenuItem

        Private WithEvents cloneLinesToolStripMenuItem As ToolStripMenuItem

        Private WithEvents cloneLinesAndCommentToolStripMenuItem As ToolStripMenuItem

        Private WithEvents toolStripSeparator6 As ToolStripSeparator

        Private WithEvents bookmarkPlusButton As ToolStripButton

        Private WithEvents bookmarkMinusButton As ToolStripButton

        Private WithEvents gotoButton As ToolStripDropDownButton

        Private WithEvents btShowFoldingLines As ToolStripButton

        Private keywords As String() = New String() {"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "descending", "dynamic", "from", "get", "global", "group", "into", "join", "let", "orderby", "partial", "remove", "select", "set", "value", "var", "where", "yield"}

        Private methods As String() = New String() {"Equals()", "GetHashCode()", "GetType()", "ToString()"}

        Private snippets As String() = New String() {"if(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}", "if(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}" & vbLf & "else" & vbLf & "{" & vbLf & ";" & vbLf & "}", "for(^;;)" & vbLf & "{" & vbLf & ";" & vbLf & "}", "while(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}", "do" & vbLf & "{" & vbLf & "^;" & vbLf & "}while();", "switch(^)" & vbLf & "{" & vbLf & "case : break;" & vbLf & "}"}

        Private declarationSnippets As String() = New String() {"public class ^" & vbLf & "{" & vbLf & "}", "private class ^" & vbLf & "{" & vbLf & "}", "internal class ^" & vbLf & "{" & vbLf & "}", "public struct ^" & vbLf & "{" & vbLf & ";" & vbLf & "}", "private struct ^" & vbLf & "{" & vbLf & ";" & vbLf & "}", "internal struct ^" & vbLf & "{" & vbLf & ";" & vbLf & "}", "public void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "private void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "internal void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "protected void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "public ^{ get; set; }", "private ^{ get; set; }", "internal ^{ get; set; }", "protected ^{ get; set; }"}

        Private invisibleCharsStyle As Style = New InvisibleCharsRenderer(Pens.Gray)

        Private currentLineColor As Color = Color.FromArgb(100, 210, 210, 255)

        Private changedLineColor As Color = Color.FromArgb(255, 230, 230, 255)

        Private explorerList As List(Of PowerfulCSharpEditor.ExplorerItem) = New List(Of PowerfulCSharpEditor.ExplorerItem)()

        Private tbFindChanged As Boolean = False

        Private lastNavigatedDateTime As DateTime = DateTime.Now

        Private Property CurrentTB() As FastColoredTextBox
            Get
                Dim result As FastColoredTextBox
                If Me.tsFiles.SelectedItem Is Nothing Then
                    result = Nothing
                Else
                    result = TryCast(Me.tsFiles.SelectedItem.Controls(0), FastColoredTextBox)
                End If
                Return result
            End Get
            Set(value As FastColoredTextBox)
                Me.tsFiles.SelectedItem = TryCast(value.Parent, FATabStripItem)
                value.Focus()
            End Set
        End Property

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PowerfulCSharpEditor))
            Me.msMain = New System.Windows.Forms.MenuStrip()
            Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.saveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
            Me.quitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ssMain = New System.Windows.Forms.StatusStrip()
            Me.lbWordUnderMouse = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tsMain = New System.Windows.Forms.ToolStrip()
            Me.newToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.openToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.saveToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.printToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.cutToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.copyToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.pasteToolStripButton = New System.Windows.Forms.ToolStripButton()
            Me.btInvisibleChars = New System.Windows.Forms.ToolStripButton()
            Me.btHighlightCurrentLine = New System.Windows.Forms.ToolStripButton()
            Me.btShowFoldingLines = New System.Windows.Forms.ToolStripButton()
            Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.undoStripButton = New System.Windows.Forms.ToolStripButton()
            Me.redoStripButton = New System.Windows.Forms.ToolStripButton()
            Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
            Me.backStripButton = New System.Windows.Forms.ToolStripButton()
            Me.forwardStripButton = New System.Windows.Forms.ToolStripButton()
            Me.tbFind = New System.Windows.Forms.ToolStripTextBox()
            Me.toolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
            Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
            Me.bookmarkPlusButton = New System.Windows.Forms.ToolStripButton()
            Me.bookmarkMinusButton = New System.Windows.Forms.ToolStripButton()
            Me.gotoButton = New System.Windows.Forms.ToolStripDropDownButton()
            Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
            Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsFiles = New FarsiLibrary.Win.FATabStrip()
            Me.splitter1 = New System.Windows.Forms.Splitter()
            Me.sfdMain = New System.Windows.Forms.SaveFileDialog()
            Me.ofdMain = New System.Windows.Forms.OpenFileDialog()
            Me.cmMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.cutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.pasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
            Me.undoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.redoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
            Me.findToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.replaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
            Me.autoIndentSelectedTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.commentSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.uncommentSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.cloneLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.cloneLinesAndCommentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.tmUpdateInterface = New System.Windows.Forms.Timer(Me.components)
            Me.dgvObjectExplorer = New System.Windows.Forms.DataGridView()
            Me.clImage = New System.Windows.Forms.DataGridViewImageColumn()
            Me.clName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ilAutocomplete = New System.Windows.Forms.ImageList(Me.components)
            Me.msMain.SuspendLayout()
            Me.ssMain.SuspendLayout()
            Me.tsMain.SuspendLayout()
            CType(Me.tsFiles, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cmMain.SuspendLayout()
            CType(Me.dgvObjectExplorer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'msMain
            '
            Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
            Me.msMain.Location = New System.Drawing.Point(0, 0)
            Me.msMain.Name = "msMain"
            Me.msMain.Size = New System.Drawing.Size(728, 24)
            Me.msMain.TabIndex = 0
            Me.msMain.Text = "menuStrip1"
            '
            'fileToolStripMenuItem
            '
            Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripMenuItem1, Me.quitToolStripMenuItem})
            Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
            Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
            Me.fileToolStripMenuItem.Text = "File"
            '
            'newToolStripMenuItem
            '
            Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
            Me.newToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
            Me.newToolStripMenuItem.Text = "New"
            '
            'openToolStripMenuItem
            '
            Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
            Me.openToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
            Me.openToolStripMenuItem.Text = "Open"
            '
            'saveToolStripMenuItem
            '
            Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
            Me.saveToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
            Me.saveToolStripMenuItem.Text = "Save"
            '
            'saveAsToolStripMenuItem
            '
            Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
            Me.saveAsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
            Me.saveAsToolStripMenuItem.Text = "Save as ..."
            '
            'toolStripMenuItem1
            '
            Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
            Me.toolStripMenuItem1.Size = New System.Drawing.Size(121, 6)
            '
            'quitToolStripMenuItem
            '
            Me.quitToolStripMenuItem.Name = "quitToolStripMenuItem"
            Me.quitToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
            Me.quitToolStripMenuItem.Text = "Quit"
            '
            'ssMain
            '
            Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbWordUnderMouse})
            Me.ssMain.Location = New System.Drawing.Point(0, 374)
            Me.ssMain.Name = "ssMain"
            Me.ssMain.Size = New System.Drawing.Size(728, 22)
            Me.ssMain.TabIndex = 2
            Me.ssMain.Text = "statusStrip1"
            '
            'lbWordUnderMouse
            '
            Me.lbWordUnderMouse.AutoSize = False
            Me.lbWordUnderMouse.ForeColor = System.Drawing.Color.Gray
            Me.lbWordUnderMouse.Name = "lbWordUnderMouse"
            Me.lbWordUnderMouse.Size = New System.Drawing.Size(200, 17)
            Me.lbWordUnderMouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tsMain
            '
            Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripButton, Me.openToolStripButton, Me.saveToolStripButton, Me.printToolStripButton, Me.toolStripSeparator3, Me.cutToolStripButton, Me.copyToolStripButton, Me.pasteToolStripButton, Me.btInvisibleChars, Me.btHighlightCurrentLine, Me.btShowFoldingLines, Me.toolStripSeparator4, Me.undoStripButton, Me.redoStripButton, Me.toolStripSeparator5, Me.backStripButton, Me.forwardStripButton, Me.tbFind, Me.toolStripLabel1, Me.toolStripSeparator6, Me.bookmarkPlusButton, Me.bookmarkMinusButton, Me.gotoButton})
            Me.tsMain.Location = New System.Drawing.Point(0, 24)
            Me.tsMain.Name = "tsMain"
            Me.tsMain.Size = New System.Drawing.Size(728, 25)
            Me.tsMain.TabIndex = 3
            Me.tsMain.Text = "toolStrip1"
            '
            'newToolStripButton
            '
            Me.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.newToolStripButton.Image = CType(resources.GetObject("newToolStripButton.Image"), System.Drawing.Image)
            Me.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.newToolStripButton.Name = "newToolStripButton"
            Me.newToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.newToolStripButton.Text = "&New"
            '
            'openToolStripButton
            '
            Me.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.openToolStripButton.Image = CType(resources.GetObject("openToolStripButton.Image"), System.Drawing.Image)
            Me.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.openToolStripButton.Name = "openToolStripButton"
            Me.openToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.openToolStripButton.Text = "&Open"
            '
            'saveToolStripButton
            '
            Me.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.saveToolStripButton.Image = CType(resources.GetObject("saveToolStripButton.Image"), System.Drawing.Image)
            Me.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.saveToolStripButton.Name = "saveToolStripButton"
            Me.saveToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.saveToolStripButton.Text = "&Save"
            '
            'printToolStripButton
            '
            Me.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.printToolStripButton.Image = CType(resources.GetObject("printToolStripButton.Image"), System.Drawing.Image)
            Me.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.printToolStripButton.Name = "printToolStripButton"
            Me.printToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.printToolStripButton.Text = "&Print"
            '
            'toolStripSeparator3
            '
            Me.toolStripSeparator3.Name = "toolStripSeparator3"
            Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
            '
            'cutToolStripButton
            '
            Me.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.cutToolStripButton.Image = CType(resources.GetObject("cutToolStripButton.Image"), System.Drawing.Image)
            Me.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.cutToolStripButton.Name = "cutToolStripButton"
            Me.cutToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.cutToolStripButton.Text = "C&ut"
            '
            'copyToolStripButton
            '
            Me.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.copyToolStripButton.Image = CType(resources.GetObject("copyToolStripButton.Image"), System.Drawing.Image)
            Me.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.copyToolStripButton.Name = "copyToolStripButton"
            Me.copyToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.copyToolStripButton.Text = "&Copy"
            '
            'pasteToolStripButton
            '
            Me.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.pasteToolStripButton.Image = CType(resources.GetObject("pasteToolStripButton.Image"), System.Drawing.Image)
            Me.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.pasteToolStripButton.Name = "pasteToolStripButton"
            Me.pasteToolStripButton.Size = New System.Drawing.Size(23, 22)
            Me.pasteToolStripButton.Text = "&Paste"
            '
            'btInvisibleChars
            '
            Me.btInvisibleChars.CheckOnClick = True
            Me.btInvisibleChars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btInvisibleChars.Image = CType(resources.GetObject("btInvisibleChars.Image"), System.Drawing.Image)
            Me.btInvisibleChars.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btInvisibleChars.Name = "btInvisibleChars"
            Me.btInvisibleChars.Size = New System.Drawing.Size(23, 22)
            Me.btInvisibleChars.Text = "¶"
            Me.btInvisibleChars.ToolTipText = "Show invisible chars"
            '
            'btHighlightCurrentLine
            '
            Me.btHighlightCurrentLine.CheckOnClick = True
            Me.btHighlightCurrentLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btHighlightCurrentLine.Image = Global.TesterVB.My.Resources.Resources.edit_padding_top
            Me.btHighlightCurrentLine.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btHighlightCurrentLine.Name = "btHighlightCurrentLine"
            Me.btHighlightCurrentLine.Size = New System.Drawing.Size(23, 22)
            Me.btHighlightCurrentLine.Text = "Highlight current line"
            Me.btHighlightCurrentLine.ToolTipText = "Highlight current line"
            '
            'btShowFoldingLines
            '
            Me.btShowFoldingLines.Checked = True
            Me.btShowFoldingLines.CheckOnClick = True
            Me.btShowFoldingLines.CheckState = System.Windows.Forms.CheckState.Checked
            Me.btShowFoldingLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btShowFoldingLines.Image = CType(resources.GetObject("btShowFoldingLines.Image"), System.Drawing.Image)
            Me.btShowFoldingLines.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btShowFoldingLines.Name = "btShowFoldingLines"
            Me.btShowFoldingLines.Size = New System.Drawing.Size(23, 22)
            Me.btShowFoldingLines.Text = "Show folding lines"
            '
            'toolStripSeparator4
            '
            Me.toolStripSeparator4.Name = "toolStripSeparator4"
            Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
            '
            'undoStripButton
            '
            Me.undoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.undoStripButton.Image = Global.TesterVB.My.Resources.Resources.undo_16x16
            Me.undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.undoStripButton.Name = "undoStripButton"
            Me.undoStripButton.Size = New System.Drawing.Size(23, 22)
            Me.undoStripButton.Text = "Undo (Ctrl+Z)"
            '
            'redoStripButton
            '
            Me.redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.redoStripButton.Image = Global.TesterVB.My.Resources.Resources.redo_16x16
            Me.redoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.redoStripButton.Name = "redoStripButton"
            Me.redoStripButton.Size = New System.Drawing.Size(23, 22)
            Me.redoStripButton.Text = "Redo (Ctrl+R)"
            '
            'toolStripSeparator5
            '
            Me.toolStripSeparator5.Name = "toolStripSeparator5"
            Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 25)
            '
            'backStripButton
            '
            Me.backStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.backStripButton.Image = Global.TesterVB.My.Resources.Resources.backward0_16x16
            Me.backStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.backStripButton.Name = "backStripButton"
            Me.backStripButton.Size = New System.Drawing.Size(23, 22)
            Me.backStripButton.Text = "Navigate Backward (Ctrl+ -)"
            '
            'forwardStripButton
            '
            Me.forwardStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.forwardStripButton.Image = Global.TesterVB.My.Resources.Resources.forward_16x16
            Me.forwardStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.forwardStripButton.Name = "forwardStripButton"
            Me.forwardStripButton.Size = New System.Drawing.Size(23, 22)
            Me.forwardStripButton.Text = "Navigate Forward (Ctrl+Shift+ -)"
            '
            'tbFind
            '
            Me.tbFind.AcceptsReturn = True
            Me.tbFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.tbFind.Name = "tbFind"
            Me.tbFind.Size = New System.Drawing.Size(100, 25)
            '
            'toolStripLabel1
            '
            Me.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.toolStripLabel1.Name = "toolStripLabel1"
            Me.toolStripLabel1.Size = New System.Drawing.Size(36, 22)
            Me.toolStripLabel1.Text = "Find: "
            '
            'toolStripSeparator6
            '
            Me.toolStripSeparator6.Name = "toolStripSeparator6"
            Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 25)
            '
            'bookmarkPlusButton
            '
            Me.bookmarkPlusButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.bookmarkPlusButton.Image = Global.TesterVB.My.Resources.Resources.layer__plus
            Me.bookmarkPlusButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.bookmarkPlusButton.Name = "bookmarkPlusButton"
            Me.bookmarkPlusButton.Size = New System.Drawing.Size(23, 22)
            Me.bookmarkPlusButton.Text = "Add bookmark"
            '
            'bookmarkMinusButton
            '
            Me.bookmarkMinusButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.bookmarkMinusButton.Image = Global.TesterVB.My.Resources.Resources.layer__minus
            Me.bookmarkMinusButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.bookmarkMinusButton.Name = "bookmarkMinusButton"
            Me.bookmarkMinusButton.Size = New System.Drawing.Size(23, 22)
            Me.bookmarkMinusButton.Text = "Remove bookmark"
            '
            'gotoButton
            '
            Me.gotoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.gotoButton.Image = CType(resources.GetObject("gotoButton.Image"), System.Drawing.Image)
            Me.gotoButton.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.gotoButton.Name = "gotoButton"
            Me.gotoButton.Size = New System.Drawing.Size(55, 22)
            Me.gotoButton.Text = "Goto..."
            '
            'toolStripSeparator
            '
            Me.toolStripSeparator.Name = "toolStripSeparator"
            Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripSeparator1
            '
            Me.toolStripSeparator1.Name = "toolStripSeparator1"
            Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripSeparator2
            '
            Me.toolStripSeparator2.Name = "toolStripSeparator2"
            Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'tsFiles
            '
            Me.tsFiles.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tsFiles.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.tsFiles.Location = New System.Drawing.Point(172, 49)
            Me.tsFiles.Name = "tsFiles"
            Me.tsFiles.Size = New System.Drawing.Size(556, 325)
            Me.tsFiles.TabIndex = 0
            Me.tsFiles.Text = "faTabStrip1"
            '
            'splitter1
            '
            Me.splitter1.Location = New System.Drawing.Point(172, 49)
            Me.splitter1.Name = "splitter1"
            Me.splitter1.Size = New System.Drawing.Size(3, 325)
            Me.splitter1.TabIndex = 5
            Me.splitter1.TabStop = False
            '
            'sfdMain
            '
            Me.sfdMain.DefaultExt = "cs"
            Me.sfdMain.Filter = "C# file(*.cs)|*.cs"
            '
            'ofdMain
            '
            Me.ofdMain.DefaultExt = "cs"
            Me.ofdMain.Filter = "C# file(*.cs)|*.cs"
            '
            'cmMain
            '
            Me.cmMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cutToolStripMenuItem, Me.copyToolStripMenuItem, Me.pasteToolStripMenuItem, Me.selectAllToolStripMenuItem, Me.toolStripMenuItem2, Me.undoToolStripMenuItem, Me.redoToolStripMenuItem, Me.toolStripMenuItem3, Me.findToolStripMenuItem, Me.replaceToolStripMenuItem, Me.toolStripMenuItem4, Me.autoIndentSelectedTextToolStripMenuItem, Me.commentSelectedToolStripMenuItem, Me.uncommentSelectedToolStripMenuItem, Me.cloneLinesToolStripMenuItem, Me.cloneLinesAndCommentToolStripMenuItem})
            Me.cmMain.Name = "cmMain"
            Me.cmMain.Size = New System.Drawing.Size(219, 308)
            '
            'cutToolStripMenuItem
            '
            Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
            Me.cutToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.cutToolStripMenuItem.Text = "Cut"
            '
            'copyToolStripMenuItem
            '
            Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
            Me.copyToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.copyToolStripMenuItem.Text = "Copy"
            '
            'pasteToolStripMenuItem
            '
            Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
            Me.pasteToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.pasteToolStripMenuItem.Text = "Paste"
            '
            'selectAllToolStripMenuItem
            '
            Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
            Me.selectAllToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.selectAllToolStripMenuItem.Text = "Select all"
            '
            'toolStripMenuItem2
            '
            Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
            Me.toolStripMenuItem2.Size = New System.Drawing.Size(215, 6)
            '
            'undoToolStripMenuItem
            '
            Me.undoToolStripMenuItem.Image = Global.TesterVB.My.Resources.Resources.undo_16x16
            Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
            Me.undoToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.undoToolStripMenuItem.Text = "Undo"
            '
            'redoToolStripMenuItem
            '
            Me.redoToolStripMenuItem.Image = Global.TesterVB.My.Resources.Resources.redo_16x16
            Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
            Me.redoToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.redoToolStripMenuItem.Text = "Redo"
            '
            'toolStripMenuItem3
            '
            Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
            Me.toolStripMenuItem3.Size = New System.Drawing.Size(215, 6)
            '
            'findToolStripMenuItem
            '
            Me.findToolStripMenuItem.Name = "findToolStripMenuItem"
            Me.findToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.findToolStripMenuItem.Text = "Find"
            '
            'replaceToolStripMenuItem
            '
            Me.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem"
            Me.replaceToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.replaceToolStripMenuItem.Text = "Replace"
            '
            'toolStripMenuItem4
            '
            Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
            Me.toolStripMenuItem4.Size = New System.Drawing.Size(215, 6)
            '
            'autoIndentSelectedTextToolStripMenuItem
            '
            Me.autoIndentSelectedTextToolStripMenuItem.Name = "autoIndentSelectedTextToolStripMenuItem"
            Me.autoIndentSelectedTextToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.autoIndentSelectedTextToolStripMenuItem.Text = "AutoIndent selected text"
            '
            'commentSelectedToolStripMenuItem
            '
            Me.commentSelectedToolStripMenuItem.Name = "commentSelectedToolStripMenuItem"
            Me.commentSelectedToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.commentSelectedToolStripMenuItem.Text = "Comment selected"
            '
            'uncommentSelectedToolStripMenuItem
            '
            Me.uncommentSelectedToolStripMenuItem.Name = "uncommentSelectedToolStripMenuItem"
            Me.uncommentSelectedToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.uncommentSelectedToolStripMenuItem.Text = "Uncomment selected"
            '
            'cloneLinesToolStripMenuItem
            '
            Me.cloneLinesToolStripMenuItem.Name = "cloneLinesToolStripMenuItem"
            Me.cloneLinesToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.cloneLinesToolStripMenuItem.Text = "Clone line(s)"
            '
            'cloneLinesAndCommentToolStripMenuItem
            '
            Me.cloneLinesAndCommentToolStripMenuItem.Name = "cloneLinesAndCommentToolStripMenuItem"
            Me.cloneLinesAndCommentToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
            Me.cloneLinesAndCommentToolStripMenuItem.Text = "Clone line(s) and comment"
            '
            'tmUpdateInterface
            '
            Me.tmUpdateInterface.Enabled = True
            Me.tmUpdateInterface.Interval = 400
            '
            'dgvObjectExplorer
            '
            Me.dgvObjectExplorer.AllowUserToAddRows = False
            Me.dgvObjectExplorer.AllowUserToDeleteRows = False
            Me.dgvObjectExplorer.AllowUserToResizeColumns = False
            Me.dgvObjectExplorer.AllowUserToResizeRows = False
            Me.dgvObjectExplorer.BackgroundColor = System.Drawing.Color.White
            Me.dgvObjectExplorer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.dgvObjectExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvObjectExplorer.ColumnHeadersVisible = False
            Me.dgvObjectExplorer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clImage, Me.clName})
            Me.dgvObjectExplorer.Cursor = System.Windows.Forms.Cursors.Hand
            Me.dgvObjectExplorer.Dock = System.Windows.Forms.DockStyle.Left
            Me.dgvObjectExplorer.GridColor = System.Drawing.Color.White
            Me.dgvObjectExplorer.Location = New System.Drawing.Point(0, 49)
            Me.dgvObjectExplorer.MultiSelect = False
            Me.dgvObjectExplorer.Name = "dgvObjectExplorer"
            Me.dgvObjectExplorer.ReadOnly = True
            Me.dgvObjectExplorer.RowHeadersVisible = False
            Me.dgvObjectExplorer.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
            Me.dgvObjectExplorer.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
            Me.dgvObjectExplorer.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Green
            Me.dgvObjectExplorer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dgvObjectExplorer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvObjectExplorer.Size = New System.Drawing.Size(172, 325)
            Me.dgvObjectExplorer.TabIndex = 6
            Me.dgvObjectExplorer.VirtualMode = True
            '
            'clImage
            '
            Me.clImage.HeaderText = "Column2"
            Me.clImage.MinimumWidth = 32
            Me.clImage.Name = "clImage"
            Me.clImage.ReadOnly = True
            Me.clImage.Width = 32
            '
            'clName
            '
            Me.clName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.clName.HeaderText = "Column1"
            Me.clName.Name = "clName"
            Me.clName.ReadOnly = True
            '
            'ilAutocomplete
            '
            Me.ilAutocomplete.ImageStream = CType(resources.GetObject("ilAutocomplete.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ilAutocomplete.TransparentColor = System.Drawing.Color.Transparent
            Me.ilAutocomplete.Images.SetKeyName(0, "script_16x16.png")
            Me.ilAutocomplete.Images.SetKeyName(1, "app_16x16.png")
            Me.ilAutocomplete.Images.SetKeyName(2, "1302166543_virtualbox.png")
            '
            'PowerfulCSharpEditor
            '
            Me.ClientSize = New System.Drawing.Size(728, 396)
            Me.Controls.Add(Me.splitter1)
            Me.Controls.Add(Me.tsFiles)
            Me.Controls.Add(Me.dgvObjectExplorer)
            Me.Controls.Add(Me.tsMain)
            Me.Controls.Add(Me.msMain)
            Me.Controls.Add(Me.ssMain)
            Me.MainMenuStrip = Me.msMain
            Me.Name = "PowerfulCSharpEditor"
            Me.Text = "PowerfulCSharpEditor"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.msMain.ResumeLayout(False)
            Me.msMain.PerformLayout()
            Me.ssMain.ResumeLayout(False)
            Me.ssMain.PerformLayout()
            Me.tsMain.ResumeLayout(False)
            Me.tsMain.PerformLayout()
            CType(Me.tsFiles, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cmMain.ResumeLayout(False)
            CType(Me.dgvObjectExplorer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Public Sub New()
            Me.InitializeComponent()
            Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(PowerfulCSharpEditor))
            Me.copyToolStripMenuItem.Image = CType(resources.GetObject("copyToolStripButton.Image"), Image)
            Me.cutToolStripMenuItem.Image = CType(resources.GetObject("cutToolStripButton.Image"), Image)
            Me.pasteToolStripMenuItem.Image = CType(resources.GetObject("pasteToolStripButton.Image"), Image)
        End Sub

        Private Sub newToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles newToolStripButton.Click
            Me.CreateTab(Nothing)
        End Sub

        Private Sub CreateTab(fileName As String)
            Try
                Dim tb As FastColoredTextBox = New FastColoredTextBox()
                tb.Font = New Font("Consolas", 9.75F)
                tb.ContextMenuStrip = Me.cmMain
                tb.Dock = DockStyle.Fill
                tb.BorderStyle = BorderStyle.Fixed3D
                tb.LeftPadding = 17
                tb.Language = Language.CSharp
                tb.AddStyle(New MarkerStyle(New SolidBrush(Color.FromArgb(50, Color.Gray))))
                Dim tab As FATabStripItem = New FATabStripItem(If(fileName IsNot Nothing, Path.GetFileName(fileName), "[new]"), tb)
                tab.Tag = fileName
                If fileName <> Nothing Then
                    tb.Text = File.ReadAllText(fileName)
                End If
                tb.ClearUndo()
                tb.Tag = New TbInfo()
                tb.IsChanged = False
                Me.tsFiles.AddTab(tab)
                Me.tsFiles.SelectedItem = tab
                tb.Focus()
                tb.DelayedTextChangedInterval = 1000
                tb.DelayedEventsInterval = 1000
                AddHandler tb.TextChangedDelayed, New EventHandler(Of TextChangedEventArgs)(AddressOf Me.tb_TextChangedDelayed)
                AddHandler tb.SelectionChangedDelayed, New EventHandler(AddressOf Me.tb_SelectionChangedDelayed)
                AddHandler tb.KeyDown, New KeyEventHandler(AddressOf Me.tb_KeyDown)
                AddHandler tb.MouseMove, New MouseEventHandler(AddressOf Me.tb_MouseMove)
                AddHandler tb.LineRemoved, New EventHandler(Of LineRemovedEventArgs)(AddressOf Me.tb_LineRemoved)
                AddHandler tb.PaintLine, New EventHandler(Of PaintLineEventArgs)(AddressOf Me.tb_PaintLine)
                tb.ChangedLineColor = Me.changedLineColor
                If Me.btHighlightCurrentLine.Checked Then
                    tb.CurrentLineColor = Me.currentLineColor
                End If
                tb.ShowFoldingLines = Me.btShowFoldingLines.Checked
                tb.HighlightingRangeType = HighlightingRangeType.VisibleRange
                Dim popupMenu As AutocompleteMenu = New AutocompleteMenu(tb)
                popupMenu.Items.ImageList = Me.ilAutocomplete
                AddHandler popupMenu.Opening, New EventHandler(Of CancelEventArgs)(AddressOf Me.popupMenu_Opening)
                Me.BuildAutocompleteMenu(popupMenu)
                TryCast(tb.Tag, TbInfo).popupMenu = popupMenu
            Catch ex As Exception
                If MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand) = DialogResult.Retry Then
                    Me.CreateTab(fileName)
                End If
            End Try
        End Sub

        Private Sub popupMenu_Opening(sender As Object, e As CancelEventArgs)
            Dim iGreenStyle As Integer = Me.CurrentTB.GetStyleIndex(Me.CurrentTB.SyntaxHighlighter.GreenStyle)
            If iGreenStyle >= 0 AndAlso Me.CurrentTB.Selection.Start.iChar > 0 Then
                Dim c As FastColoredTextBoxNS.Char = Me.CurrentTB(Me.CurrentTB.Selection.Start.iLine)(Me.CurrentTB.Selection.Start.iChar - 1)
                Dim greenStyleIndex As StyleIndex = Range.ToStyleIndex(iGreenStyle)
                If CUShort(c.style And greenStyleIndex) <> 0 Then
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub tb_PaintLine(sender As Object, e As PaintLineEventArgs)
            Dim info As TbInfo = TryCast(TryCast(sender, FastColoredTextBox).Tag, TbInfo)
            If info.bookmarksLineId.Contains(TryCast(sender, FastColoredTextBox)(e.LineIndex).UniqueId) Then
                e.Graphics.FillEllipse(New LinearGradientBrush(New Rectangle(0, e.LineRect.Top, 15, 15), Color.White, Color.PowderBlue, 45.0F), 0, e.LineRect.Top, 15, 15)
                e.Graphics.DrawEllipse(Pens.PowderBlue, 0, e.LineRect.Top, 15, 15)
            End If
        End Sub

        Private Sub tb_LineRemoved(sender As Object, e As LineRemovedEventArgs)
            Dim info As TbInfo = TryCast(TryCast(sender, FastColoredTextBox).Tag, TbInfo)
            For Each id As Integer In e.RemovedLineUniqueIds
                If info.bookmarksLineId.Contains(id) Then
                    info.bookmarksLineId.Remove(id)
                    info.bookmarks.Remove(id)
                End If
            Next
        End Sub

        Private Sub BuildAutocompleteMenu(popupMenu As AutocompleteMenu)
            Dim items As List(Of AutocompleteItem) = New List(Of AutocompleteItem)()
            Dim array As String() = Me.snippets
            For i As Integer = 0 To array.Length - 1
                Dim item As String = array(i)
                items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 1})
            Next
            array = Me.declarationSnippets
            For i As Integer = 0 To array.Length - 1
                Dim item As String = array(i)
                items.Add(New PowerfulCSharpEditor.DeclarationSnippet(item) With {.ImageIndex = 0})
            Next
            array = Me.methods
            For i As Integer = 0 To array.Length - 1
                Dim item As String = array(i)
                items.Add(New MethodAutocompleteItem(item) With {.ImageIndex = 2})
            Next
            array = Me.keywords
            For i As Integer = 0 To array.Length - 1
                Dim item As String = array(i)
                items.Add(New AutocompleteItem(item))
            Next
            items.Add(New PowerfulCSharpEditor.InsertSpaceSnippet())
            items.Add(New PowerfulCSharpEditor.InsertSpaceSnippet("^(\w+)([=<>!:]+)(\w+)$"))
            items.Add(New PowerfulCSharpEditor.InsertEnterSnippet())
            popupMenu.Items.SetAutocompleteItems(items)
            popupMenu.SearchPattern = "[\w\.:=!<>]"
        End Sub

        Private Sub tb_MouseMove(sender As Object, e As MouseEventArgs)
            Dim tb As FastColoredTextBox = TryCast(sender, FastColoredTextBox)
            Dim place As Place = tb.PointToPlace(e.Location)
            Dim r As Range = New Range(tb, place, place)
            Dim text As String = r.GetFragment("[a-zA-Z]").Text
            Me.lbWordUnderMouse.Text = text
        End Sub

        Private Sub tb_KeyDown(sender As Object, e As KeyEventArgs)
            If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.OemMinus Then
                Me.NavigateBackward()
                e.Handled = True
            End If
            If e.Modifiers = Keys.Shift Or Keys.Control AndAlso e.KeyCode = Keys.OemMinus Then
                Me.NavigateForward()
                e.Handled = True
            End If
            If e.KeyData = CType(131147, Keys) Then
                TryCast(Me.CurrentTB.Tag, TbInfo).popupMenu.Show(True)
                e.Handled = True
            End If
        End Sub

        Private Sub tb_SelectionChangedDelayed(sender As Object, e As EventArgs)
            Dim tb As FastColoredTextBox = TryCast(sender, FastColoredTextBox)
            If tb.Selection.IsEmpty AndAlso tb.Selection.Start.iLine < tb.LinesCount Then
                If Me.lastNavigatedDateTime <> tb(tb.Selection.Start.iLine).LastVisit Then
                    tb(tb.Selection.Start.iLine).LastVisit = DateTime.Now
                    Me.lastNavigatedDateTime = tb(tb.Selection.Start.iLine).LastVisit
                End If
            End If
            tb.VisibleRange.ClearStyle(New Style() {tb.Styles(0)})
            If tb.Selection.IsEmpty Then
                Dim fragment As Range = tb.Selection.GetFragment("\w")
                Dim text As String = fragment.Text
                If text.Length <> 0 Then
                    Dim ranges As Range() = tb.VisibleRange.GetRanges("\b" + text + "\b").ToArray()
                    If ranges.Length > 1 Then
                        Dim array As Range() = ranges
                        For i As Integer = 0 To array.Length - 1
                            Dim r As Range = array(i)
                            r.SetStyle(tb.Styles(0))
                        Next
                    End If
                End If
            End If
        End Sub

        Private Sub tb_TextChangedDelayed(sender As Object, e As TextChangedEventArgs)
            Dim tb As FastColoredTextBox = TryCast(sender, FastColoredTextBox)
            Dim text As String = TryCast(sender, FastColoredTextBox).Text
            ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                             Me.ReBuildObjectExplorer(text)
                                         End Sub)
            Me.HighlightInvisibleChars(e.ChangedRange)
        End Sub

        Private Sub HighlightInvisibleChars(range As Range)
            range.ClearStyle(New Style() {Me.invisibleCharsStyle})
            If Me.btInvisibleChars.Checked Then
                range.SetStyle(Me.invisibleCharsStyle, ".$|.\r\n|\s")
            End If
        End Sub

        Private Sub ReBuildObjectExplorer(text As String)
            Try
                Dim list As List(Of PowerfulCSharpEditor.ExplorerItem) = New List(Of PowerfulCSharpEditor.ExplorerItem)()
                Dim lastClassIndex As Integer = -1
                Dim regex As Regex = New Regex("^(?<range>[\w\s]+\b(class|struct|enum|interface)\s+[\w<>,\s]+)|^\s*(public|private|internal|protected)[^\n]+(\n?\s*{|;)?", RegexOptions.Multiline)
                For Each r As Match In regex.Matches(text)
                    Try
                        Dim s As String = r.Value
                        Dim i As Integer = s.IndexOfAny(New Char() {"=", "{", ";"})
                        If i >= 0 Then
                            s = s.Substring(0, i)
                        End If
                        s = s.Trim()
                        Dim item As PowerfulCSharpEditor.ExplorerItem = New PowerfulCSharpEditor.ExplorerItem() With {.title = s, .position = r.Index}
                        If regex.IsMatch(item.title, "\b(class|struct|enum|interface)\b") Then
                            item.title = item.title.Substring(item.title.LastIndexOf(" ")).Trim()
                            item.type = PowerfulCSharpEditor.ExplorerItemType.[Class]
                            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New PowerfulCSharpEditor.ExplorerItemComparer())
                            lastClassIndex = list.Count
                        Else
                            If item.title.Contains(" event ") Then
                                Dim ii As Integer = item.title.LastIndexOf(" ")
                                item.title = item.title.Substring(ii).Trim()
                                item.type = PowerfulCSharpEditor.ExplorerItemType.[Event]
                            Else
                                If item.title.Contains("(") Then
                                    Dim parts As String() = item.title.Split(New Char() {"("})
                                    item.title = parts(0).Substring(parts(0).LastIndexOf(" ")).Trim() + "(" + parts(1)
                                    item.type = PowerfulCSharpEditor.ExplorerItemType.Method
                                Else
                                    If item.title.EndsWith("]") Then
                                        Dim parts As String() = item.title.Split(New Char() {"["})
                                        If parts.Length < 2 Then
                                            Continue For
                                        End If
                                        item.title = parts(0).Substring(parts(0).LastIndexOf(" ")).Trim() + "[" + parts(1)
                                        item.type = PowerfulCSharpEditor.ExplorerItemType.Method
                                    Else
                                        Dim ii As Integer = item.title.LastIndexOf(" ")
                                        item.title = item.title.Substring(ii).Trim()
                                        item.type = PowerfulCSharpEditor.ExplorerItemType.[Property]
                                    End If
                                End If
                            End If
                        End If
                        list.Add(item)
                    Catch ex_2BF As Exception
                        Console.WriteLine(ex_2BF)
                    End Try
                Next
                list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New PowerfulCSharpEditor.ExplorerItemComparer())
                MyBase.BeginInvoke(Sub()
                                       Me.explorerList = list
                                       Me.dgvObjectExplorer.RowCount = Me.explorerList.Count
                                       Me.dgvObjectExplorer.Invalidate()
                                   End Sub)
            Catch ex_332 As Exception
                Console.WriteLine(ex_332)
            End Try
        End Sub

        Private Sub tsFiles_TabStripItemClosing(e As TabStripItemClosingEventArgs) Handles tsFiles.TabStripItemClosing
            If TryCast(e.Item.Controls(0), FastColoredTextBox).IsChanged Then
                Dim dialogResult As DialogResult = MessageBox.Show("Do you want save " + e.Item.Title + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)
                If dialogResult <> dialogResult.Cancel Then
                    If dialogResult = dialogResult.Yes Then
                        If Not Me.Save(e.Item) Then
                            e.Cancel = True
                        End If
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Function Save(tab As FATabStripItem) As Boolean
            Dim tb As FastColoredTextBox = TryCast(tab.Controls(0), FastColoredTextBox)
            Dim result As Boolean
            If tab.Tag Is Nothing Then
                If Me.sfdMain.ShowDialog() <> DialogResult.OK Then
                    result = False
                    Return result
                End If
                tab.Title = Path.GetFileName(Me.sfdMain.FileName)
                tab.Tag = Me.sfdMain.FileName
            End If
            Try
                File.WriteAllText(TryCast(tab.Tag, String), tb.Text)
                tb.IsChanged = False
            Catch ex As Exception
                If MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand) = DialogResult.Retry Then
                    result = Me.Save(tab)
                    Return result
                End If
                result = False
                Return result
            End Try
            tb.Invalidate()
            result = True
            Return result
        End Function

        Private Sub saveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles saveToolStripButton.Click
            If Me.tsFiles.SelectedItem IsNot Nothing Then
                Me.Save(Me.tsFiles.SelectedItem)
            End If
        End Sub

        Private Sub saveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles saveAsToolStripMenuItem.Click
            If Me.tsFiles.SelectedItem IsNot Nothing Then
                Dim oldFile As String = TryCast(Me.tsFiles.SelectedItem.Tag, String)
                Me.tsFiles.SelectedItem.Tag = Nothing
                If Not Me.Save(Me.tsFiles.SelectedItem) AndAlso oldFile <> Nothing Then
                    Me.tsFiles.SelectedItem.Tag = oldFile
                    Me.tsFiles.SelectedItem.Title = Path.GetFileName(oldFile)
                End If
            End If
        End Sub

        Private Sub quitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles quitToolStripMenuItem.Click
            MyBase.Close()
        End Sub

        Private Sub openToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles openToolStripButton.Click
            If Me.ofdMain.ShowDialog() = DialogResult.OK Then
                Me.CreateTab(Me.ofdMain.FileName)
            End If
        End Sub

        Private Sub cutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cutToolStripButton.Click
            Me.CurrentTB.Cut()
        End Sub

        Private Sub copyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles copyToolStripButton.Click
            Me.CurrentTB.Copy()
        End Sub

        Private Sub pasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles pasteToolStripButton.Click
            Me.CurrentTB.Paste()
        End Sub

        Private Sub selectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles selectAllToolStripMenuItem.Click
            Me.CurrentTB.Selection.SelectAll()
        End Sub

        Private Sub undoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles undoStripButton.Click
            If Me.CurrentTB.UndoEnabled Then
                Me.CurrentTB.Undo()
            End If
        End Sub

        Private Sub redoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles redoStripButton.Click
            If Me.CurrentTB.RedoEnabled Then
                Me.CurrentTB.Redo()
            End If
        End Sub

        Private Sub tmUpdateInterface_Tick(sender As Object, e As EventArgs) Handles tmUpdateInterface.Tick
            Try
                If Me.CurrentTB IsNot Nothing AndAlso Me.tsFiles.Items.Count > 0 Then
                    Dim tb As FastColoredTextBox = Me.CurrentTB
                    Me.undoStripButton.Enabled = Me.undoToolStripMenuItem.Enabled = tb.UndoEnabled
                    Me.redoStripButton.Enabled = Me.redoToolStripMenuItem.Enabled = tb.RedoEnabled
                    Me.saveToolStripButton.Enabled = Me.saveToolStripMenuItem.Enabled = tb.IsChanged
                    Me.saveAsToolStripMenuItem.Enabled = True
                    Me.pasteToolStripButton.Enabled = Me.pasteToolStripMenuItem.Enabled = True
                    Me.cutToolStripButton.Enabled = Me.cutToolStripMenuItem.Enabled = Me.copyToolStripButton.Enabled = Me.copyToolStripMenuItem.Enabled = Not tb.Selection.IsEmpty
                    Me.printToolStripButton.Enabled = True
                Else
                    Me.saveToolStripButton.Enabled = Me.saveToolStripMenuItem.Enabled = False
                    Me.saveAsToolStripMenuItem.Enabled = False
                    Me.cutToolStripButton.Enabled = Me.cutToolStripMenuItem.Enabled = Me.copyToolStripButton.Enabled = Me.copyToolStripMenuItem.Enabled = False
                    Me.pasteToolStripButton.Enabled = Me.pasteToolStripMenuItem.Enabled = False
                    Me.printToolStripButton.Enabled = False
                    Me.undoStripButton.Enabled = Me.undoToolStripMenuItem.Enabled = False
                    Me.redoStripButton.Enabled = Me.redoToolStripMenuItem.Enabled = False
                    Me.dgvObjectExplorer.RowCount = 0
                End If
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Sub printToolStripButton_Click(sender As Object, e As EventArgs) Handles printToolStripButton.Click
            If Me.CurrentTB IsNot Nothing Then
                Dim settings As PrintDialogSettings = New PrintDialogSettings()
                settings.Title = Me.tsFiles.SelectedItem.Title
                settings.Header = "&b&w&b"
                settings.Footer = "&b&p"
                Me.CurrentTB.Print(settings)
            End If
        End Sub

        Private Sub tbFind_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbFind.KeyPress
            If e.KeyChar = vbCr AndAlso Me.CurrentTB IsNot Nothing Then
                Dim r As Range = If(Me.tbFindChanged, Me.CurrentTB.Range.Clone(), Me.CurrentTB.Selection.Clone())
                Me.tbFindChanged = False
                r.[End] = New Place(Me.CurrentTB(Me.CurrentTB.LinesCount - 1).Count, Me.CurrentTB.LinesCount - 1)
                Dim pattern As String = Regex.Escape(Me.tbFind.Text)
                Using enumerator As IEnumerator(Of Range) = r.GetRanges(pattern).GetEnumerator()
                    If enumerator.MoveNext() Then
                        Dim found As Range = enumerator.Current
                        found.Inverse()
                        Me.CurrentTB.Selection = found
                        Me.CurrentTB.DoSelectionVisible()
                        Return
                    End If
                End Using
                MessageBox.Show("Not found.")
            Else
                Me.tbFindChanged = True
            End If
        End Sub

        Private Sub findToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles findToolStripMenuItem.Click
            Me.CurrentTB.ShowFindDialog()
        End Sub

        Private Sub replaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles replaceToolStripMenuItem.Click
            Me.CurrentTB.ShowReplaceDialog()
        End Sub

        Private Sub PowerfulCSharpEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            Dim list As List(Of FATabStripItem) = New List(Of FATabStripItem)()
            For Each tab As FATabStripItem In Me.tsFiles.Items
                list.Add(tab)
            Next
            For Each tab As FATabStripItem In list
                Dim args As TabStripItemClosingEventArgs = New TabStripItemClosingEventArgs(tab)
                Me.tsFiles_TabStripItemClosing(args)
                If args.Cancel Then
                    e.Cancel = True
                    Exit For
                End If
                Me.tsFiles.RemoveTab(tab)
            Next
        End Sub

        Private Sub dgvObjectExplorer_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvObjectExplorer.CellMouseClick
            If Me.CurrentTB IsNot Nothing Then
                Dim item As PowerfulCSharpEditor.ExplorerItem = Me.explorerList(e.RowIndex)
                Me.CurrentTB.GoEnd()
                Me.CurrentTB.SelectionStart = item.position
                Me.CurrentTB.DoSelectionVisible()
                Me.CurrentTB.Focus()
            End If
        End Sub

        Private Sub dgvObjectExplorer_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgvObjectExplorer.CellValueNeeded
            Try
                Dim item As PowerfulCSharpEditor.ExplorerItem = Me.explorerList(e.RowIndex)
                If e.ColumnIndex = 1 Then
                    e.Value = item.title
                Else
                    Select Case item.type
                        Case PowerfulCSharpEditor.ExplorerItemType.[Class]
                            e.Value = My.Resources.class_libraries
                        Case PowerfulCSharpEditor.ExplorerItemType.Method
                            e.Value = My.Resources.box
                        Case PowerfulCSharpEditor.ExplorerItemType.[Property]
                            e.Value = My.Resources._property
                        Case PowerfulCSharpEditor.ExplorerItemType.[Event]
                            e.Value = My.Resources.lightning
                    End Select
                End If
            Catch ex_8D As Exception
            End Try
        End Sub

        Private Sub tsFiles_TabStripItemSelectionChanged(e As TabStripItemChangedEventArgs) Handles tsFiles.TabStripItemSelectionChanged
            If Me.CurrentTB IsNot Nothing Then
                Me.CurrentTB.Focus()
                Dim text As String = Me.CurrentTB.Text
                ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                                 Me.ReBuildObjectExplorer(text)
                                             End Sub)
            End If
        End Sub

        Private Sub backStripButton_Click(sender As Object, e As EventArgs) Handles backStripButton.Click
            Me.NavigateBackward()
        End Sub

        Private Sub forwardStripButton_Click(sender As Object, e As EventArgs) Handles forwardStripButton.Click
            Me.NavigateForward()
        End Sub

        Private Function NavigateBackward() As Boolean
            Dim max As DateTime = Nothing
            Dim iLine As Integer = -1
            Dim tb As FastColoredTextBox = Nothing
            For iTab As Integer = 0 To Me.tsFiles.Items.Count - 1
                Dim t As FastColoredTextBox = TryCast(Me.tsFiles.Items(iTab).Controls(0), FastColoredTextBox)
                For i As Integer = 0 To t.LinesCount - 1
                    If t(i).LastVisit < Me.lastNavigatedDateTime AndAlso t(i).LastVisit > max Then
                        max = t(i).LastVisit
                        iLine = i
                        tb = t
                    End If
                Next
            Next
            Dim result As Boolean
            If iLine >= 0 Then
                Me.tsFiles.SelectedItem = TryCast(tb.Parent, FATabStripItem)
                tb.Navigate(iLine)
                Me.lastNavigatedDateTime = tb(iLine).LastVisit
                Console.WriteLine("Backward: " + Me.lastNavigatedDateTime)
                tb.Focus()
                tb.Invalidate()
                result = True
            Else
                result = False
            End If
            Return result
        End Function

        Private Function NavigateForward() As Boolean
            Dim min As DateTime = DateTime.Now
            Dim iLine As Integer = -1
            Dim tb As FastColoredTextBox = Nothing
            For iTab As Integer = 0 To Me.tsFiles.Items.Count - 1
                Dim t As FastColoredTextBox = TryCast(Me.tsFiles.Items(iTab).Controls(0), FastColoredTextBox)
                For i As Integer = 0 To t.LinesCount - 1
                    If t(i).LastVisit > Me.lastNavigatedDateTime AndAlso t(i).LastVisit < min Then
                        min = t(i).LastVisit
                        iLine = i
                        tb = t
                    End If
                Next
            Next
            Dim result As Boolean
            If iLine >= 0 Then
                Me.tsFiles.SelectedItem = TryCast(tb.Parent, FATabStripItem)
                tb.Navigate(iLine)
                Me.lastNavigatedDateTime = tb(iLine).LastVisit
                Console.WriteLine("Forward: " + Me.lastNavigatedDateTime)
                tb.Focus()
                tb.Invalidate()
                result = True
            Else
                result = False
            End If
            Return result
        End Function

        Private Sub autoIndentSelectedTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles autoIndentSelectedTextToolStripMenuItem.Click
            Me.CurrentTB.DoAutoIndent()
        End Sub

        Private Sub btInvisibleChars_Click(sender As Object, e As EventArgs) Handles btInvisibleChars.Click
            For Each tab As FATabStripItem In Me.tsFiles.Items
                Me.HighlightInvisibleChars(TryCast(tab.Controls(0), FastColoredTextBox).Range)
            Next
            If Me.CurrentTB IsNot Nothing Then
                Me.CurrentTB.Invalidate()
            End If
        End Sub

        Private Sub btHighlightCurrentLine_Click(sender As Object, e As EventArgs) Handles btHighlightCurrentLine.Click
            For Each tab As FATabStripItem In Me.tsFiles.Items
                If Me.btHighlightCurrentLine.Checked Then
                    TryCast(tab.Controls(0), FastColoredTextBox).CurrentLineColor = Me.currentLineColor
                Else
                    TryCast(tab.Controls(0), FastColoredTextBox).CurrentLineColor = Color.Transparent
                End If
            Next
            If Me.CurrentTB IsNot Nothing Then
                Me.CurrentTB.Invalidate()
            End If
        End Sub

        Private Sub commentSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles commentSelectedToolStripMenuItem.Click
            Me.CurrentTB.InsertLinePrefix("//")
        End Sub

        Private Sub uncommentSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles uncommentSelectedToolStripMenuItem.Click
            Me.CurrentTB.RemoveLinePrefix("//")
        End Sub

        Private Sub cloneLinesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cloneLinesToolStripMenuItem.Click
            Me.CurrentTB.Selection.Expand()
            Dim text As String = Environment.NewLine + Me.CurrentTB.Selection.Text
            Me.CurrentTB.Selection.Start = Me.CurrentTB.Selection.[End]
            Me.CurrentTB.InsertText(text)
        End Sub

        Private Sub cloneLinesAndCommentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cloneLinesAndCommentToolStripMenuItem.Click
            Me.CurrentTB.BeginAutoUndo()
            Me.CurrentTB.Selection.Expand()
            Dim text As String = Environment.NewLine + Me.CurrentTB.Selection.Text
            Me.CurrentTB.InsertLinePrefix("//")
            Me.CurrentTB.Selection.Start = Me.CurrentTB.Selection.[End]
            Me.CurrentTB.InsertText(text)
            Me.CurrentTB.EndAutoUndo()
        End Sub

        Private Sub bookmarkPlusButton_Click(sender As Object, e As EventArgs) Handles bookmarkPlusButton.Click
            If Me.CurrentTB IsNot Nothing Then
                Dim info As TbInfo = TryCast(Me.CurrentTB.Tag, TbInfo)
                Dim id As Integer = Me.CurrentTB(Me.CurrentTB.Selection.Start.iLine).UniqueId
                If Not info.bookmarksLineId.Contains(id) Then
                    info.bookmarks.Add(id)
                    info.bookmarksLineId.Add(id)
                    Me.CurrentTB.Invalidate()
                End If
            End If
        End Sub

        Private Sub bookmarkMinusButton_Click(sender As Object, e As EventArgs) Handles bookmarkMinusButton.Click
            If Me.CurrentTB IsNot Nothing Then
                Dim info As TbInfo = TryCast(Me.CurrentTB.Tag, TbInfo)
                Dim id As Integer = Me.CurrentTB(Me.CurrentTB.Selection.Start.iLine).UniqueId
                If info.bookmarksLineId.Contains(id) Then
                    info.bookmarks.Remove(id)
                    info.bookmarksLineId.Remove(id)
                    Me.CurrentTB.Invalidate()
                End If
            End If
        End Sub

        Private Sub gotoButton_DropDownOpening(sender As Object, e As EventArgs) Handles gotoButton.DropDownOpening
            Me.gotoButton.DropDownItems.Clear()
            For Each tab As Control In Me.tsFiles.Items
                Dim tb As FastColoredTextBox = TryCast(tab.Controls(0), FastColoredTextBox)
                Dim info As TbInfo = TryCast(tb.Tag, TbInfo)
                For i As Integer = 0 To info.bookmarks.Count - 1
                    Dim item As ToolStripItem = Me.gotoButton.DropDownItems.Add(String.Concat(New Object() {"Bookmark ", Me.gotoButton.DropDownItems.Count, " [", Path.GetFileNameWithoutExtension(TryCast(tab.Tag, String)), "]"}))
                    item.Tag = New PowerfulCSharpEditor.BookmarkInfo() With {.tb = tb, .iBookmark = i}
                    AddHandler item.Click, Sub(o As Object, a As EventArgs)
                                               Me.[GoTo](CType(TryCast(o, ToolStripItem).Tag, PowerfulCSharpEditor.BookmarkInfo))
                                           End Sub
                Next
            Next
        End Sub

        Private Sub [GoTo](bookmark As PowerfulCSharpEditor.BookmarkInfo)
            Dim info As TbInfo = TryCast(bookmark.tb.Tag, TbInfo)
            Try
                Me.CurrentTB = bookmark.tb
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
            If bookmark.iBookmark >= 0 AndAlso bookmark.iBookmark < info.bookmarks.Count Then
                Dim id As Integer = info.bookmarks(bookmark.iBookmark)
                For i As Integer = 0 To Me.CurrentTB.LinesCount - 1
                    If Me.CurrentTB(i).UniqueId = id Then
                        Me.CurrentTB.Selection.Start = New Place(0, i)
                        Me.CurrentTB.DoSelectionVisible()
                        Me.CurrentTB.Invalidate()
                        Exit For
                    End If
                Next
            End If
        End Sub

        Private Sub btShowFoldingLines_Click(sender As Object, e As EventArgs) Handles btShowFoldingLines.Click
            For Each tab As FATabStripItem In Me.tsFiles.Items
                TryCast(tab.Controls(0), FastColoredTextBox).ShowFoldingLines = Me.btShowFoldingLines.Checked
            Next
            If Me.CurrentTB IsNot Nothing Then
                Me.CurrentTB.Invalidate()
            End If
        End Sub
    End Class
End Namespace
