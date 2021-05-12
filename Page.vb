Imports System.IO

Public Class Page

    ' All the items on each page file.
    Public Items As List(Of Item) = New List(Of Item)
    ' The page number that we are currently on.
    Public PageNumber As Integer = 0

    ' The constructor for the Page, checks for errors and adds everything to the Items class.
    Sub New(ByVal path As String)
        If Not File.Exists("Products/" + path.Split("^")(0)) Then
            Console.WriteLine("Page does not exist.")
            Return
        End If
        Dim lines() = File.ReadAllLines("Products/" + path.Split("^")(0))

        For Each Item As String In lines
            Dim Parts = Item.Split("^")
            If Not (Parts(0).ToLower() = "item" Or Parts(0).ToLower() = "page") Then
                Console.WriteLine("Line in path doesn't start with item or page.")
                Return
            End If

            If Parts.Length < 2 Or Parts(1).Length = 0 Then
                Continue For
            End If

            Dim type As EPOS3.Item.ItemType = If(Parts(0).ToLower() = "item", EPOS3.Item.ItemType.Item, EPOS3.Item.ItemType.Page)
            Dim pathorname = If(type = EPOS3.Item.ItemType.Item, Parts(1) + "^" + Utility.LookupProduct(Parts(1)).PathOrName, Item.Split("^")(0) + "^" + Item.Split("^")(1))

            If type = EPOS3.Item.ItemType.Page And Parts.Length > 2 Then
                pathorname += "^" + Parts(2)
            End If

            If type = EPOS3.Item.ItemType.Item Then
                Dim product = Utility.LookupProduct(Item.Split("^")(1))
                If product.PathOrName.Split("^").Length > 2 Then
                    pathorname += "^" + product.PathOrName.Split("^")(2)
                End If
            End If

            Items.Add(New Item(type, pathorname))
        Next
    End Sub

    ' To String method, only used for debugging.
    Public Overrides Function ToString() As String
        Dim final = ""
        For Each Item As Item In Items
            final += Item.ToString + Environment.NewLine
        Next
        final = final.Substring(0, final.Length - (Environment.NewLine.Length))
        Return final
    End Function
End Class
