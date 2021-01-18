Public Class Deal

    Public Conditional As String
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
        Dim tString = New TokenList(ReplaceConditional()).GetResult().ToString()
        Return CBool(tString)
    End Function

    Public Function EvaluateOutput() As Double
        Dim changeNumber = New TokenList(ReplaceOutput()).GetResult() ' Makes a temporary variable just so it can execute the variable on the price.
        Return CDbl(changeNumber.ToString())
    End Function

    Public Sub CheckThenEvaluate()
        Dim changed = Utility.ProductsInstance.lblSubprice.Text
        If EvaluateConditional() Then ' Checks if the conditional is true
            changed += EvaluateOutput() ' If so, then execute the output
        End If

        Utility.ProductsInstance.lblFullPrice.Text = changed
    End Sub
End Class
