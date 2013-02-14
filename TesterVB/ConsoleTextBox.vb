Imports FastColoredTextBoxNS
Imports System
Imports System.Linq
Imports System.Threading
Imports System.Windows.Forms

Namespace TesterVB
    Public Class ConsoleTextBox
        Inherits FastColoredTextBox

        Private _isReadLineMode As Boolean

        Private isUpdating As Boolean

        Private Property StartReadPlace() As Place

        Public Property IsReadLineMode() As Boolean
            Get
                Return Me._isReadLineMode
            End Get
            Set(value As Boolean)
                Me._isReadLineMode = value
            End Set
        End Property

        Public Sub WriteLine(text As String)
            Me.IsReadLineMode = False
            Me.isUpdating = True
            Try
                MyBase.AppendText(text)
                MyBase.GoEnd()
            Finally
                Me.isUpdating = False
                MyBase.ClearUndo()
            End Try
        End Sub

        Public Function ReadLine() As String
            MyBase.GoEnd()
            Me.StartReadPlace = MyBase.Range.[End]
            Me.IsReadLineMode = True
            Try
                While Me.IsReadLineMode
                    Application.DoEvents()
                    Thread.Sleep(5)
                End While
            Finally
                Me.IsReadLineMode = False
                MyBase.ClearUndo()
            End Try
            Return New Range(Me, Me.StartReadPlace, MyBase.Range.[End]).Text.TrimEnd(New Char() {vbCr, vbLf})
        End Function

        Public Overrides Sub OnTextChanging(ByRef text As String)
            If Not Me.IsReadLineMode AndAlso Not Me.isUpdating Then
                text = ""
            Else
                If Me.IsReadLineMode Then
                    If MyBase.Selection.Start < Me.StartReadPlace OrElse MyBase.Selection.[End] < Me.StartReadPlace Then
                        MyBase.GoEnd()
                    End If

                    If MyBase.Selection.Start = Me.StartReadPlace Or MyBase.Selection.[End] = Me.StartReadPlace Then
                        If text = vbBack Then
                            text = ""
                            Return
                        End If
                    End If

                    If text IsNot Nothing AndAlso text.Contains(vbLf) Then
                        text = text.Substring(0, text.IndexOf(vbLf) + 1)
                        Me.IsReadLineMode = False
                    End If
                End If
                MyBase.OnTextChanging(text)
                End If
        End Sub
    End Class
End Namespace
