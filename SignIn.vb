Imports System.IO

Public Class SignIn

    Private Sub SignIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Make the products directory if it doesn't exist and then send a message to the console.
        If Not Directory.Exists("Products") Then
            Directory.CreateDirectory("Products")
            Console.WriteLine("Created products folder.")
        End If

        ' Make a index page if it doesn't exist and send a message to the console.
        If Not File.Exists("Products/index.page") Then
            File.Create("Products/index.page").Close()
            Console.WriteLine("Created index page.")
        End If

        ' Make an empty products file if it doesn't exist and send a message to the console.
        If Not File.Exists("Products/products.prod") Then
            File.Create("Products/products.prod").Close()
            Console.WriteLine("Created products file.")
        End If

        ' Load all the products out of the products file (important to do after products file is created)
        Utility.LoadProducts()

        If Not File.Exists("Products/deals.deal") Then
            File.Create("Products/deals.deal").Close()
            Console.WriteLine("Created deals file.")
        End If

        ' Load all of the deals within the program.
        Utility.LoadDeals()

        For Each d As Deal In Utility.GetDeals()
            d.EvaluateConditional()
        Next

        Try
            ' Load the databases
            Utility.LoadDatabases()
        Catch ex As InvalidOperationException
            MsgBox("Access Database Engine 12.0 not installed!", MsgBoxStyle.Critical, "Error!")
            Application.Exit()
        Catch ex2 As Data.OleDb.OleDbException
            MsgBox("Cannot find the database!", MsgBoxStyle.Critical, "Error!")
            Application.Exit()
        End Try

    End Sub

    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        ' Check user credentials
        Dim usrs As Database = Utility.GetUserTbl()
        Dim getUserSql As String = "SELECT Users.Username, Users.Password, Users.UserType FROM Users WHERE (((Users.Username)=""" + txtUsername.Text + """) AND ((Users.Password)=""" + txtPassword.Text + """));"
        Dim user As DataTable = usrs.getSQL(getUserSql)

        If user.Rows.Count = 0 Then
            MsgBox("No user")
            Return
        End If

        txtUsername.Text = ""
        txtPassword.Text = ""

        ' Check user type
        Dim userType As Integer = user.Rows(0).Item(2)
        If userType < 1 Or userType > 3 Then
            MsgBox("Invalid user type")
            Return
        End If

        Hide()

        ' If normal user open Products,
        If userType = 3 Then
            If Utility.ProductsInstance Is Nothing Then
                Utility.ProductsInstance = Products
            End If
            Products.Show()
            Return
        Else
            ' If not, open manage users,
            ' Let the super user condition be dependent on whether the user type is 1
            ManageUsers.isSuperuser = userType = 1
            ManageUsers.Show()
            Return
        End If
    End Sub
End Class