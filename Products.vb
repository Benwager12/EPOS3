Imports System.IO

Public Class Products
    ' The number of buttons visible to the user.
    Private productsVisible As Integer = 0

    ' Get an instance of the database table named "Login".
    Private Login As Database = New Database("Login")

    ' An instance of the page so I can make the page change quickly without having to back reference.
    Private CurrentPage As Page

    Private Sub Products_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Utility.ProductsInstance = Me

        ' Make the products directory if it doesn't exist and then send a message to the console.
        If Not Directory.Exists("Products") Then
            Directory.CreateDirectory("Products")
            Console.WriteLine("Created products folder.")
        End If

        ' Make a index page if it doesn't exist and send a message to the console.
        If Not File.Exists("Products/index.page") Then
            File.Create("Products/index.page")
            Console.WriteLine("Created index page.")
        End If

        ' Make an empty products file if it doesn't exist and send a message to the console.
        If Not File.Exists("Products/products.prod") Then
            File.Create("Products/products.prod")
            Console.WriteLine("Created products file.")
        End If

        ' Load all the products out of the products file (important to do after products file is created)
        Utility.LoadProducts()

        If Not File.Exists("Products/deals.deal") Then
            File.Create("Products/deals.deal")
            Console.WriteLine("Created deals file.")
        End If

        ' Load all of the deals within the program.
        Utility.LoadDeals()

        ' Make an instance of the index and load it.
        LoadPage(New Page("index.page^Index"))

        For Each d As Deal In Utility.GetDeals()
            d.EvaluateConditional()
        Next
    End Sub

    Private Sub btnProd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProd1.TextChanged, btnProd2.TextChanged, btnProd3.TextChanged, btnProd4.TextChanged, btnProd5.TextChanged, btnProd6.TextChanged, btnProd7.TextChanged, btnProd8.TextChanged, btnProd9.TextChanged
        Dim button As Button = CType(sender, Button)
        button.Visible = (Not button.Text = "")
        productsVisible += If(button.Text = "", -1, 1)
        lblNoProducts.Visible = (productsVisible = 0)
    End Sub

    ' If a page is specified, then the current page is set and then we move onto main code.
    Private Sub LoadPage(ByVal Page As Page)
        CurrentPage = Page
        LoadPage()
    End Sub

    ' Cycles through each button and uses some math to figure which products are on that page. If there are no products
    ' in this page at all, it will simply print the line "You have no products on your page." and Return, otherwise, it'll
    ' set the text of the page number. It will then go on to enabling the first, previous, next and last button.
    Private Sub LoadPage()
        For Index As Integer = 1 To 9
            Dim button As Button = CType(Controls("btnProd" + CStr(Index)), Button)
            If CurrentPage.Items.Count < (CurrentPage.PageNumber * 9) + Index Then
                button.Text = ""
                button.Tag = button.Tag.ToString().Substring(0, 1)
                Continue For
            End If

            Dim item As Item = CurrentPage.Items((CurrentPage.PageNumber * 9) + Index - 1)

            If item.Type = EPOS3.Item.ItemType.Item Then
                button.Text = item.PathOrName.Split("^")(1)
            Else
                If item.ToString().Split("^").Length > 2 Then
                    button.Text = item.PathOrName.Split("^")(2)
                Else
                    button.Text = item.ToString().Split("^")(1).Substring(0, item.PathOrName.Length - 5)
                End If
            End If

            If item.Type = EPOS3.Item.ItemType.Item Then
                button.Tag = button.Tag.ToString.Substring(0, 1) + "^" + "item" + "^" + item.PathOrName.Split("^")(0)
            Else
                button.Tag = button.Tag.ToString.Substring(0, 1) + "^" + item.ToString()
            End If

            button.Font = New Font("Microsoft Sans Serif", 14)

            Dim buttonText As SizeF = CreateGraphics().MeasureString(button.Text, button.Font)
            Dim newButtonSize As Double = 14 - (buttonText.Width / 325)
            button.Font = New Font("Microsoft Sans Serif", newButtonSize)
        Next

        If CurrentPage.Items.Count = 0 Then
            Console.WriteLine("You have no products on your page.")
            Return
        End If
        txtPageNumber.Text = CStr(CurrentPage.PageNumber + 1) + "/" + CStr(Math.Ceiling(CurrentPage.Items.Count / 9))

        btnFirst.Enabled = Not (CurrentPage.PageNumber = 0)
        btnPrev.Enabled = Not (CurrentPage.PageNumber = 0)

        btnNext.Enabled = Not ((Math.Ceiling(CurrentPage.Items.Count / 9) - 1) = CurrentPage.PageNumber)
        btnLast.Enabled = Not ((Math.Ceiling(CurrentPage.Items.Count / 9) - 1) = CurrentPage.PageNumber)
    End Sub

    ' First buttonm, set page number to 0.
    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        CurrentPage.PageNumber = 0
        LoadPage()
    End Sub

    ' Previous button, decreases page number by 1.
    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        CurrentPage.PageNumber -= 1
        LoadPage()
    End Sub

    ' Next button, increases page number by 1.
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        CurrentPage.PageNumber += 1
        LoadPage()
    End Sub

    ' Last button, set the page number to the amount of pages that exist (-1 for coding purposes).
    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        CurrentPage.PageNumber = Math.Ceiling(CurrentPage.Items.Count / 9) - 1
        LoadPage()
    End Sub

    ' If the button is a item then it adds it to the basket, if it's a page, it goes to it.
    Private Sub btnProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProd1.Click, btnProd2.Click, btnProd3.Click, btnProd4.Click, btnProd5.Click, btnProd6.Click, btnProd7.Click, btnProd8.Click, btnProd9.Click
        Dim buttonTagParts() As String = CType(sender, Button).Tag.ToString.Split("^")

        Select Case buttonTagParts(1)
            Case "item"
                AddItemToBasket(CInt(buttonTagParts(2)))
            Case "page"
                LoadPage(New Page(buttonTagParts(2)))
        End Select

    End Sub

    '' Add item to basket and update the price
    Private Sub AddItemToBasket(ByVal index As Integer)
        Dim info() As String = Utility.LookupProduct(index).PathOrName.Split("^")
        Dim name As String = info(If(info.Length > 2, 2, 0))
        dataBasket.Rows.Add(New Object() {index, name, "£" + CStr(String.Format("{0:0.00}", CDbl(info(1))))})

        lblSubprice.Text = String.Format("{0:0.00}", CDbl(lblSubprice.Text) + CDbl(info(1)))
    End Sub

    Private Sub btnIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIndex.Click
        LoadPage(New Page("index.page"))
    End Sub

    '' When a cell is double clicked, remove the row and detract the price.
    Private Sub dataBasket_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataBasket.CellDoubleClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
            Return
        End If

        Dim selectedRow = dataBasket.Rows(e.RowIndex)
        'Console.WriteLine("Removed """ + selectedRow.Cells(1).Value + """.")
        dataBasket.Rows.RemoveAt(e.RowIndex)
        lblSubprice.Text = String.Format("{0:0.00}", CDbl(lblSubprice.Text) - CDbl(selectedRow.Cells(2).Value.Remove(0, 1)))
    End Sub

    Private Sub lblSubprice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSubprice.TextChanged
        If Utility.GetDeals() Is Nothing Then
            Return
        End If

        Utility.CheckThenEvaluateDeals()

        txtSubprice.Text = "£" + lblSubprice.Text
        lblFullPrice.Text = CStr(CDbl(lblSubprice.Text) + CDbl(lblDealPrice.Text))
        txtFullPrice.Text = String.Format("{0:0.00}", CDbl(lblFullPrice.Text))
    End Sub

    Private Sub lblDealPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDealPrice.TextChanged
        lblFullPrice.Text = CStr(CDbl(lblSubprice.Text) + CDbl(lblDealPrice.Text))
        txtFullPrice.Text = "£" + String.Format("{0:0.00}", lblFullPrice.Text)
    End Sub

    Private Sub btnClearBasket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearBasket.Click
        dataBasket.Rows.Clear()
        lblSubprice.Text = "0.00"
    End Sub
End Class
