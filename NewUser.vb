Public Class NewUser

    Private isSuperuser As Boolean = False

    Public Sub New(Optional ByVal isSuperuser As Boolean = False)
        Me.isSuperuser = isSuperuser
        InitializeComponent()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If username.Length = 0 Then
            MsgBox("Username length cannot be 0.")
            Return
        End If

        If password.Length = 0 Then
            MsgBox("Password length cannot be 0.")
            Return
        End If

        MakeNewUser(username, password, cmbUserType.Text)
    End Sub

    Private Sub MakeNewUser(ByVal Username As String, ByVal Password As String, ByVal RoleName As String)
        Dim userTypes As Database = Utility.GetUserTypesTbl()
        Dim sql As String = "SELECT ID FROM UserTypes WHERE Type=""" + RoleName + """;"
        Dim ID As Integer = userTypes.getSQL(sql).Rows(0).Item(0)

        Dim sql2 As String = "INSERT INTO Users (Username, UserType, [Password]) SELECT """ + Username + """, " + CStr(ID) + ", """ + Password + """;"
        Dim users As Database = Utility.GetUserTbl()
        users.getSQL(sql2)

        MsgBox("User """ + Username + """ was created with a " + RoleName + " role.")

        ManageUsers.RefreshUsers()
    End Sub

    Private Sub chkShowPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.PasswordChar = If(chkShowPassword.Checked, "", "*")
    End Sub

    Private Sub NewUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim userTypes As Database = Utility.GetUserTypesTbl()
        Dim sql As String = "SELECT Type FROM UserTypes"

        Dim types As DataTable = userTypes.getSQL(sql)

        For Each role As DataRow In types.Rows
            If role.Item(0) = types.Rows(0).Item(0) Then
                Continue For
            End If

            If role.Item(0) = types.Rows(1).Item(0) And Not isSuperuser Then
                Continue For
            End If
            cmbUserType.Items.Add(role.Item(0))
        Next

        cmbUserType.SelectedIndex = 0
    End Sub
End Class
