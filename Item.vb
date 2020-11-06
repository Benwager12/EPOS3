Public Class Item

    ' Finding out whether the chosen item in the list is a Page or an Item.
    Public Enum ItemType
        Page
        Item
    End Enum

    ' The above type for a specific item.
    Public Type As ItemType
    ' The path to the page or the name of the item.
    Public PathOrName As String

    ' The constructor function, assigns the type, very basic.
    Sub New(ByVal Type As ItemType, ByVal PathOrName As String)
        Me.Type = Type
        Me.PathOrName = PathOrName
    End Sub

    ' To string function, only used for debugging.
    Public Overrides Function ToString() As String
        Return PathOrName
    End Function

End Class
