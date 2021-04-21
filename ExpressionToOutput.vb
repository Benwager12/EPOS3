Public Class ExpressionToOutput
    Public expression As String
    Public output As String
    Public op As String

    Sub New(ByVal expression As String, ByVal output As String, ByVal op As String)
        Me.expression = expression
        Me.output = output
        Me.op = op
    End Sub
End Class