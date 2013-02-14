Imports FastColoredTextBoxNS
Imports System
Imports System.Collections.Generic

Namespace TesterVB
    Public Class TbInfo
        Public bookmarksLineId As HashSet(Of Integer) = New HashSet(Of Integer)()

        Public bookmarks As List(Of Integer) = New List(Of Integer)()

        Public popupMenu As AutocompleteMenu
    End Class
End Namespace
