Imports System.IO

Public Class Utility

    ' Products array
    Private Shared Products() As String

    ' Only called on startup, may put a refresh product button. Reads all lines from Products file and puts them into an array.
    Public Shared Sub LoadProducts()
        Products = File.ReadAllLines("Products/products.prod")
    End Sub

    ' Reads from the Products file, and makes a new Item type.
    Public Shared Function LookupProduct(ByVal index As Integer) As Item
        Return New Item(EPOS3.Item.ItemType.Item, Products(index - 1))
    End Function
End Class
