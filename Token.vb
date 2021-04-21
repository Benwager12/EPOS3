Public Class Token
    Public state As TokenState
    Public tokenString As String

    Sub New(ByVal tokenString As String, ByVal state As TokenState)
        Me.tokenString = tokenString
        Me.state = state
    End Sub

    Overrides Function ToString() As String
        Return tokenString
    End Function
End Class