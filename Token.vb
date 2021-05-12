Public Class Token
    Public state As TokenState
    Public tokenString As String

    ' Initialization of token
    Sub New(ByVal tokenString As String, ByVal state As TokenState)
        Me.tokenString = tokenString
        Me.state = state
    End Sub

    ' Return the token's to string version
    Overrides Function ToString() As String
        Return tokenString
    End Function
End Class