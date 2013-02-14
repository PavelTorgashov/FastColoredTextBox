Imports FastColoredTextBoxNS
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace TesterVB
    Public Class TooltipSample
        Inherits Form

        Private components As IContainer = Nothing

        Private label1 As Label

        Private WithEvents fctb As FastColoredTextBox

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TooltipSample))
            Me.label1 = New System.Windows.Forms.Label()
            Me.fctb = New FastColoredTextBoxNS.FastColoredTextBox()
            Me.SuspendLayout()
            '
            'label1
            '
            Me.label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label1.Location = New System.Drawing.Point(0, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(355, 30)
            Me.label1.TabIndex = 4
            Me.label1.Text = "This example shows tooltips for words under mouse."
            '
            'fctb
            '
            Me.fctb.AllowDrop = True
            Me.fctb.AutoScrollMinSize = New System.Drawing.Size(0, 255)
            Me.fctb.BackBrush = Nothing
            Me.fctb.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.fctb.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.fctb.Dock = System.Windows.Forms.DockStyle.Fill
            Me.fctb.Font = New System.Drawing.Font("Consolas", 9.75!)
            Me.fctb.IsReplaceMode = False
            Me.fctb.Language = FastColoredTextBoxNS.Language.CSharp
            Me.fctb.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
            Me.fctb.Location = New System.Drawing.Point(0, 30)
            Me.fctb.Name = "fctb"
            Me.fctb.Paddings = New System.Windows.Forms.Padding(0)
            Me.fctb.ReadOnly = True
            Me.fctb.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
            Me.fctb.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.fctb.Size = New System.Drawing.Size(355, 282)
            Me.fctb.TabIndex = 5
            Me.fctb.Text = resources.GetString("fctb.Text")
            Me.fctb.WordWrap = True
            '
            'TooltipSample
            '
            Me.ClientSize = New System.Drawing.Size(355, 312)
            Me.Controls.Add(Me.fctb)
            Me.Controls.Add(Me.label1)
            Me.Name = "TooltipSample"
            Me.Text = "TooltipSample"
            Me.ResumeLayout(False)

        End Sub

        Private Sub fctb_ToolTipNeeded(sender As System.Object, e As FastColoredTextBoxNS.ToolTipNeededEventArgs) Handles fctb.ToolTipNeeded
            If Not String.IsNullOrEmpty(e.HoveredWord) Then
                e.ToolTipTitle = e.HoveredWord
                e.ToolTipText = "This is tooltip for '" + e.HoveredWord & "'"
            End If

        End Sub
    End Class
End Namespace
