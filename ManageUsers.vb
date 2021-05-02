Public Class ManageUsers

    Public isSuperuser As Boolean = False

    Private Sub ManageUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        GotoSignIn()
    End Sub

    Private Sub GotoSignIn()
        Hide()
        isSuperuser = False
        SignIn.Show()
    End Sub

    Private Sub ManageUsers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        GotoSignIn()
    End Sub
End Class