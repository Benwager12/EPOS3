Public Class Deal

    Private Conditional As String
    Private Output As String

    Sub New(ByVal Conditional As String, ByVal Output As String)
        Me.Conditional = Conditional
        Me.Output = Output
    End Sub

    Function ExecuteOutput() As String
        Dim tempConditional As String = Conditional ' getting a temporary version of the conditional
        Dim matches As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(Conditional, "item\[([0-9]*)] (amt|test)") ' Look for any of this in regex, works for my conditional

        For Each match As System.Text.RegularExpressions.Match In matches ' Loop through matches
            Dim id As Integer = CDbl(match.Groups.Item(1).Value) ' The id of the item
            Dim replaceSection As String = System.Text.RegularExpressions.Regex.Matches(match.Value, "item\[([0-9]*)]").Item(0).Value ' The section I need to replace

            If match.Groups.Item(2).Value = "amt" Then
                tempConditional = tempConditional.Replace(replaceSection + " amt", 3) ' Replacing item index with 3 (placeholder until I get a lookup)
            End If
            Console.WriteLine(tempConditional) ' Should output 3 > 2 with my conditional test
        Next
        Return "price^-5" ' Temporary
    End Function

    '' For testing purposes, just giving a demonstration of the output for me
    Public Overrides Function ToString() As String
        Return Conditional + " => " + Output
    End Function
End Class
