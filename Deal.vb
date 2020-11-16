Public Class Deal

    Private Conditional As String
    Private Output As String

    Sub New(ByVal Conditional As String, ByVal Output As String)
        Me.Conditional = Conditional
        Me.Output = Output
    End Sub

    Public Function ReplaceConditional() As String
        Return Utility.ReplaceItemString(Conditional) ' Shows all
    End Function

    Public Function ReplaceOutput() As String
        Return Utility.ReplaceItemString(Output) ' Shows all
    End Function

    '' For testing purposes, just giving a demonstration of the output for me
    Public Overrides Function ToString() As String
        Return ReplaceConditional() + " => " + ReplaceOutput() ' + " (" + CStr(EvaluateConditional()) + ")"
    End Function

    Public Function EvaluateConditional() As Boolean
        Return ReplaceConditional().Replace(" ", "")
    End Function
End Class
