Public Class ManageUsers

    ' Declaring the superuser variable
    Public isSuperuser As Boolean = False

    ' Refresh the users when the page loads
    Private Sub ManageUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshUsers()
    End Sub

    ' Go back to sign in
    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        GotoSignIn()
    End Sub

    ' Hide, set isSuperuser to false and show sign in
    Private Sub GotoSignIn()
        Hide()
        isSuperuser = False
        SignIn.Show()
    End Sub

    ' When the form is closed, go to the sign in page
    Private Sub ManageUsers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        GotoSignIn()
    End Sub

    ' Add a user by opening the NewUser form as a dialog
    Private Sub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click
        Dim userPage As NewUser = New NewUser(isSuperuser)
        userPage.ShowDialog()
    End Sub

    ' Clear the users and then refresh it
    Public Sub RefreshUsers()
        ' Clear the users
        dataUsers.Rows.Clear()

        Dim users As Database = Utility.GetUserTbl()
        Dim types As Database = Utility.GetUserTypesTbl()

        ' Add each user to the table
        For Each user As DataRow In users.getEntireTable().Rows
            Dim id = user.Item(0)
            Dim username = user.Item(1)
            Dim usertype_id = user.Item(2)
            Dim password = user.Item(3)

            ' Add the user to the table with the correct UserType name
            Dim usertype_name = types.getSQL("SELECT Type FROM UserTypes WHERE ID=" + CStr(usertype_id)).Rows(0).Item(0)
            dataUsers.Rows.Add(New Object() {id, username, usertype_name, password})
        Next

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        RefreshUsers()
    End Sub

    ' Remove a user
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        ' When no rows are selected
        If dataUsers.SelectedCells.Count = 0 Then
            MsgBox("You have not selected any rows.")
            Return
        End If

        ' When more than 1 row is selected
        If dataUsers.SelectedCells.Count > 1 Then
            MsgBox("You can only select one row at a time to delete.")
            Return
        End If

        Dim row_index = dataUsers.SelectedCells.Item(0).RowIndex
        Dim person_id = dataUsers.Rows(row_index).Cells(0).Value
        Dim person_role = dataUsers.Rows(row_index).Cells(2).Value

        ' Checking the different roles and if they can delete
        If person_role = "Superuser" Then
            MsgBox("You cannot remove a superuser.")
            Return
        End If

        If person_role = "Admin" And Not isSuperuser Then
            MsgBox("You need to be a superuser to remove admins.")
            Return
        End If

        ' Making the SQL to find
        Dim selectionSQL As String = "SELECT * FROM Users WHERE ID=" + CStr(person_id) + ";"
        Dim users As Database = Utility.GetUserTbl()

        ' Refresh the table if user doesn't exist
        If users.getSQL(selectionSQL).Rows.Count = 0 Then
            MsgBox("No users have that ID, refreshing.")
            RefreshUsers()
        End If

        ' Making the SQL to delete
        Dim sql As String = "Delete * FROM Users Where ID=" + CStr(person_id) + ";"

        ' Delete from database
        users.getSQL(sql)

        ' Checking if it was truly deleted
        If users.getSQL(selectionSQL).Rows.Count = 0 Then
            MsgBox("User deleted!")
            RefreshUsers()
        End If
    End Sub
End Class