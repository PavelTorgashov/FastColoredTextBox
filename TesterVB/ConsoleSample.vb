Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB
    Public Class ConsoleSample
        Inherits Form

        Private _stop As Boolean

        Private components As IContainer = Nothing

        Private consoleTextBox1 As ConsoleTextBox

        Private label2 As Label

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Protected Overrides Sub OnShown(e As EventArgs)
            MyBase.OnShown(e)
            _stop = False
            Dim text As String
            Do
                Me.consoleTextBox1.WriteLine("Enter some line: ")
                text = Me.consoleTextBox1.ReadLine()
            Loop While text <> "" AndAlso Not _stop
            Me.consoleTextBox1.WriteLine("End of enetering.")
        End Sub

        Protected Overrides Sub OnClosing(e As CancelEventArgs)
            Me.[Stop]()
            MyBase.OnClosing(e)
        End Sub

        Private Sub [Stop]()
            _stop = True
            Me.consoleTextBox1.IsReadLineMode = False
        End Sub

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsoleSample))
            Me.label2 = New System.Windows.Forms.Label()
            Me.consoleTextBox1 = New TesterVB.ConsoleTextBox()
            Me.SuspendLayout()
            '
            'label2
            '
            Me.label2.Dock = System.Windows.Forms.DockStyle.Top
            Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label2.Location = New System.Drawing.Point(0, 0)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(737, 38)
            Me.label2.TabIndex = 2
            Me.label2.Text = resources.GetString("label2.Text")
            '
            'consoleTextBox1
            '
            Me.consoleTextBox1.AllowDrop = True
            Me.consoleTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.consoleTextBox1.AutoScrollMinSize = New System.Drawing.Size(585, 15)
            Me.consoleTextBox1.BackBrush = Nothing
            Me.consoleTextBox1.BackColor = System.Drawing.Color.Black
            Me.consoleTextBox1.CaretColor = System.Drawing.Color.White
            Me.consoleTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.consoleTextBox1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.consoleTextBox1.FoldingIndicatorColor = System.Drawing.Color.Gold
            Me.consoleTextBox1.Font = New System.Drawing.Font("Consolas", 9.75!)
            Me.consoleTextBox1.ForeColor = System.Drawing.Color.White
            Me.consoleTextBox1.IndentBackColor = System.Drawing.Color.Black
            Me.consoleTextBox1.IsReadLineMode = False
            Me.consoleTextBox1.LineNumberColor = System.Drawing.Color.Gold
            Me.consoleTextBox1.Location = New System.Drawing.Point(12, 41)
            Me.consoleTextBox1.Name = "consoleTextBox1"
            Me.consoleTextBox1.PaddingBackColor = System.Drawing.Color.Black
            Me.consoleTextBox1.Paddings = New System.Windows.Forms.Padding(0)
            Me.consoleTextBox1.PreferredLineWidth = 80
            Me.consoleTextBox1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.consoleTextBox1.ServiceLinesColor = System.Drawing.Color.DimGray
            Me.consoleTextBox1.Size = New System.Drawing.Size(713, 342)
            Me.consoleTextBox1.TabIndex = 0
            Me.consoleTextBox1.WordWrap = True
            Me.consoleTextBox1.WordWrapMode = FastColoredTextBoxNS.WordWrapMode.CharWrapPreferredWidth
            '
            'ConsoleSample
            '
            Me.ClientSize = New System.Drawing.Size(737, 395)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.consoleTextBox1)
            Me.Name = "ConsoleSample"
            Me.Text = "ConsoleSample"
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
