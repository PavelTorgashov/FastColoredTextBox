Imports FastColoredTextBoxNS
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Namespace TesterVB
    Friend Class JokeStyle
        Inherits TextStyle

        Public Sub New()
            MyBase.New(Nothing, Nothing, FontStyle.Regular)
        End Sub

        Public Overrides Sub Draw(gr As Graphics, position As Point, range As Range)
            For Each p As Place In CType(range, IEnumerable(Of Place))
                Dim time As Integer = CInt(DateTime.Now.TimeOfDay.TotalMilliseconds / 2.0)
                Dim angle As Integer = CInt(CLng(time) Mod 360L)
                Dim angle2 As Integer = CInt(CLng(time - (p.iChar - range.Start.iChar) * 20) Mod 360L) * 2
                Dim x As Integer = position.X + (p.iChar - range.Start.iChar) * range.tb.CharWidth
                Dim r As Range = range.tb.GetRange(p, New Place(p.iChar + 1, p.iLine))
                Dim point As Point = New Point(x, position.Y + CInt(5.0 + 5.0 * Math.Sin(3.1415926535897931 * CDec(angle2) / 180.0)))
                gr.ResetTransform()
                gr.TranslateTransform(CSng(point.X + range.tb.CharWidth / 2), CSng(point.Y + range.tb.CharHeight / 2))
                gr.RotateTransform(CSng(angle))
                gr.ScaleTransform(0.8F, 0.8F)
                gr.TranslateTransform(CSng(-CSng(range.tb.CharWidth) / 2), CSng(-CSng(range.tb.CharHeight) / 2))
                MyBase.Draw(gr, New Point(0, 0), r)
            Next
            gr.ResetTransform()
        End Sub
    End Class
End Namespace
