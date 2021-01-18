Imports System.IO
Imports EPOS3.Products

Public Class Utility

    Public Shared ProductsInstance As Products

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

    Public Shared Function ReplaceItemString(ByVal input As String) As String
        Dim matches As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(input, "item\[([0-9]*)] (amt|test)") ' Look for any of this in regex, works for my conditional

        For Each match As System.Text.RegularExpressions.Match In matches ' Loop through matches
            Dim id As Integer = CDbl(match.Groups.Item(1).Value) ' The id of the item
            Dim replaceSection As String = System.Text.RegularExpressions.Regex.Matches(match.Value, "item\[([0-9]*)]").Item(0).Value ' The section I need to replace

            If match.Groups.Item(2).Value = "amt" Then
                input = input.Replace(replaceSection + " amt", FindAmountID(id)) ' Replacing item index with 3 (placeholder until I get a lookup)
            End If
        Next

        input = input.Replace("price", ProductsInstance.lblFullPrice.Text)
        Return input
    End Function

    Public Shared Function FindAmountID(ByVal ID As Integer) As Integer
        Dim amount = 0
        For Each Item As DataGridViewRow In ProductsInstance.dataBasket.Rows
            Dim cellID = Item.Cells(0).Value
            amount -= CInt(CInt(cellID) = ID) ' Some cool shorthand
        Next
        Return amount
    End Function

    
End Class
