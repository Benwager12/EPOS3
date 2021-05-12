Imports System.IO
Imports EPOS3.Products

Public Class Utility

    Public Shared ProductsInstance As Products

    ' Products array
    Private Shared Products() As String
    Private Shared Deals As List(Of Deal)

    ' Get an instance of the database table named "Users".
    Private Shared Users As Database
    ' Get an instance of the database table named "UserTypes"
    Private Shared UserTypes As Database

    ' Only called on startup, may put a refresh product button. Reads all lines from Products file and puts them into an array.
    Public Shared Sub LoadProducts()
        Products = File.ReadAllLines("Products/products.prod")
    End Sub

    ' Initialize the databases
    Public Shared Sub LoadDatabases()
        Users = New Database("Users")
        UserTypes = New Database("UserTypes")
    End Sub

    ' Get a copy of "User" table.
    Public Shared Function GetUserTbl() As Database
        Return Users
    End Function

    ' Get a copy of "UserTypes" table.
    Public Shared Function GetUserTypesTbl() As Database
        Return UserTypes
    End Function

    ' Check if deal conditional is true, if it is, then take it away from the price.
    Public Shared Sub CheckThenEvaluateDeals()
        ProductsInstance.lblDealPrice.Text = 0
        For Each d As Deal In Deals
            If d.EvaluateConditional Then
                ProductsInstance.lblDealPrice.Text += d.EvaluateOutput()
            End If
            Console.WriteLine(d.ToString())
        Next
        ProductsInstance.txtDealPrice.Text = "£" + String.Format("{0:0.00}", Math.Abs(CDbl(ProductsInstance.lblDealPrice.Text)))

        With ProductsInstance.txtDealPrice
            If ProductsInstance.lblDealPrice.Text < 0 Then
                .ForeColor = Color.Green
            ElseIf ProductsInstance.lblDealPrice.Text = 0 Then
                .ForeColor = Color.Black
            Else
                .ForeColor = Color.Red
            End If
        End With
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
            Console.WriteLine(deal.ToString())
        Next
    End Sub

    ' Reads from the Products file, and makes a new Item type.
    Public Shared Function LookupProduct(ByVal index As Integer) As Item
        Return New Item(EPOS3.Item.ItemType.Item, Products(index - 1))
    End Function

    ' Returns the deals, mostly used for iteration through them.
    Public Shared Function GetDeals() As List(Of Deal)
        Return Deals
    End Function

    ' Used for when I'm changing the things in deals
    Public Shared Function ReplaceItemString(ByVal input As String) As String
        Dim matches As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(input, "item\[([0-9]*)] (amt|price)") ' Look for any of this in regex, works for my conditional

        For Each match As System.Text.RegularExpressions.Match In matches ' Loop through matches
            Dim id As Integer = CDbl(match.Groups.Item(1).Value) ' The id of the item
            Dim replaceSection As String = System.Text.RegularExpressions.Regex.Matches(match.Value, "item\[([0-9]*)]").Item(0).Value ' The section I need to replace

            If match.Groups.Item(2).Value = "amt" Then
                input = input.Replace(replaceSection + " amt", FindAmountID(id)) ' Replacing item index with 3 (placeholder until I get a lookup)
            ElseIf match.Groups.Item(2).Value = "price" Then
                input = input.Replace(replaceSection + " price", FindPriceID(id))
            End If
        Next

        Try
            input = input.Replace("price", ProductsInstance.lblSubprice.Text)
        Catch ex As Exception
            Console.WriteLine("Deal applied on startup")
        End Try

        Return input
    End Function

    Public Shared Function FindAmountID(ByVal ID As Integer) As Integer
        Dim amount = 0
        If ProductsInstance Is Nothing Then
            Return 0
        End If
        For Each Item As DataGridViewRow In ProductsInstance.dataBasket.Rows
            Dim cellID = Item.Cells(0).Value
            amount -= CInt(CInt(cellID) = ID) ' Finds the amount of given item per amount in basket,
            ' As when rereading this, I could figure out what it meant for 10 minutes, I'll explain, It compares a the cellID with ID which returns a boolean of either true of false,
            ' when true is casted to an integer it gives the result of -1 in VB, so then if I minus minus 1, then it will give me plus 1, as false is 0, it doesn't affect the total
            ' at all, so then I can count very easily using a shorthand operator.
        Next
        Return amount
    End Function

    ' From the ID find the price.
    Public Shared Function FindPriceID(ByVal ID As Integer) As Double
        Return Products(ID - 1).Split("^")(1) ' Looks through all the products, takes away one from the index because arrays start at 0, separate the carets and get the price, which is in the 2nd (or 1st) slot.
    End Function
End Class
