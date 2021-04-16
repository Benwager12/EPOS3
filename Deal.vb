Public Class Deal

    ' Values
    Public Conditional As String
    Private Output As String

    ' Constructor for function and applying values.
    Sub New(ByVal Conditional As String, ByVal Output As String)
        Me.Conditional = Conditional
        Me.Output = Output
    End Sub

    ' A string which is the conditional of the deal replacing the item[number] price/amt with the relevant value.
    Public Function ReplaceConditional() As String
        Return Utility.ReplaceItemString(Conditional) ' Shows all
    End Function

    ' A string which is the output of the deal replacing the item[number] price/amt with the relevant value.
    Public Function ReplaceOutput() As String
        Return Utility.ReplaceItemString(Output) ' Shows all
    End Function

    ' For testing purposes, just giving a demonstration of the output for me
    Public Overrides Function ToString() As String
        Return ReplaceConditional() + " => " + ReplaceOutput() ' + " (" + CStr(EvaluateConditional()) + ")"
    End Function

    ' Gets the conditional and converts every string to a value, and then gets the boolean result from it.
    Public Function EvaluateConditional() As Boolean
        Dim tString = New TokenList(ReplaceConditional()).GetResult().ToString() ' Makes a temporary variable just so it can execute the variable on the price.
        Return CBool(tString)
    End Function

    ' Gets the output and converts every string to a value, then finds a double from it.
    Public Function EvaluateOutput() As Double
        Dim changeNumber = New TokenList(ReplaceOutput()).GetResult() ' Makes a temporary variable just so it can execute the variable on the price.
        Return CDbl(changeNumber.ToString())
    End Function
End Class
