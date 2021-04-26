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

        For Each d As Deal In Utility.GetDeals()
            d.EvaluateConditional()
        Next

        ' Load the databases
        Utility.LoadDatabases()
    End Sub

    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        ' Hide window
        Dim usrs As Database = Utility.GetUserTbl()
        Dim user As DataTable = usrs.getSQL("SELECT * FROM Users WHERE Username='" + txtUsername.Text + "' AND Password='" + txtPassword.Text + "';")
        If user.Rows.Count = 0 Then
            MsgBox("No user")
        End If

        Console.WriteLine(user.Columns(2))
        a = user.Columns(2)
        Console.WriteLine()
        ' Check user type
        ' If normal user open Products,
        ' If not, open manage users,
        ' If it's a superuser, then open manage users with a boolean property
    End Sub
End Class