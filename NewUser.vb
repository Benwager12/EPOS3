Public Class NewUser

    Private isSuperuser As Boolean = False

    ' Initializing NewUser with whether they're a superuser
    Public Sub New(Optional ByVal isSuperuser As Boolean = False)
        Me.isSuperuser = isSuperuser
        InitializeComponent()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        ' Trimming any before or after whitespace
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Checking for length on username
        If username.Length = 0 Then
            MsgBox("Username length cannot be 0.")
            Return
        End If

        ' Checking for length on password
        If password.Length = 0 Then
            MsgBox("Password length cannot be 0.")
            Return
        End If

        ' Make a new user and then close the program
        MakeNewUser(username, password, cmbUserType.Text)
        Close()
    End Sub

    Private Sub MakeNewUser(ByVal Username As String, ByVal Password As String, ByVal RoleName As String)
        ' Get the ID of the RoleName
        Dim userTypes As Database = Utility.GetUserTypesTbl()
        Dim sql As String = "SELECT ID FROM UserTypes WHERE Type=""" + RoleName + """;"
        Dim ID As Integer = userTypes.getSQL(sql).Rows(0).Item(0)

        ' Insert the new user
        Dim sql2 As String = "INSERT INTO Users (Username, UserType, [Password]) SELECT """ + Username + """, " + CStr(ID) + ", """ + Password + """;"
        Dim users As Database = Utility.GetUserTbl()
        users.getSQL(sql2)

        ' Inform the user that a user was created
        MsgBox("User """ + Username + """ was created with a " + RoleName + " role.")

        ' Refresh the users when a new one is added
        ManageUsers.RefreshUsers()
    End Sub

    ' Either show or unshow a password
    Private Sub chkShowPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.PasswordChar = If(chkShowPassword.Checked, "", "*")
    End Sub

    Private Sub NewUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Get user types table
        Dim userTypes As Database = Utility.GetUserTypesTbl()
        ' Select all types
        Dim sql As String = "SELECT Type FROM UserTypes"

        Dim types As DataTable = userTypes.getSQL(sql)

        ' Add all user roles that are allowed for that staff member
        For Each role As DataRow In types.Rows
            If role.Item(0) = types.Rows(0).Item(0) Then
                Continue For
            End If

            If role.Item(0) = types.Rows(1).Item(0) And Not isSuperuser Then
                Continue For
            End If
            cmbUserType.Items.Add(role.Item(0))
        Next

        ' Select the 0th index
        cmbUserType.SelectedIndex = 0
    End Sub
End Class
