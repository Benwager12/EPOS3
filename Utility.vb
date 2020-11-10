Imports System.IO

Public Class Utility

    '' Products array
    Private Shared Products() As String
    Private Shared Deals As List(Of Deal)

    '' Only called on startup, may put a refresh product button. Reads all lines from Products file and puts them into an array.
    Public Shared Sub LoadProducts()
        Products = File.ReadAllLines("Products/products.prod")
    End Sub


    '' Only called on startup, loads all the deals from files.
    Public Shared Sub LoadDeals()
        Deals = New List(Of Deal)
        Dim dealFile = File.ReadAllLines("Products/deals.deal")
        For Each line In dealFile
            If line.ToLower().StartsWith("if ") Then
                line = line.Remove(0, 3)
            End If

            If Not line.ToLower().Contains(" then ") Then
                Continue For
            End If

            Dim split() As String = System.Text.RegularExpressions.Regex.Split(line.ToLower, " then ")
            Dim deal As Deal = New Deal(split(0), split(1))
            Deals.Add(deal)
        Next
    End Sub

    '' Reads from the Products file, and makes a new Item type.
    Public Shared Function LookupProduct(ByVal index As Integer) As Item
        Return New Item(EPOS3.Item.ItemType.Item, Products(index - 1))
    End Function

    '' Returns the deals, mostly used for iteration through them.
    Public Shared Function GetDeals() As List(Of Deal)
        Return Deals
    End Function
End Class
