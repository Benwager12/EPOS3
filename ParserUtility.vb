Public Class ParserUtility
    Public Shared operators As String() = {"min", "max", "**", "/", "mod", "*", "+", "-", ">", ">=", "<", "<=", "=", "!=", "and", "or"}

    Public Shared Function isOperator(ByVal word As String) As Boolean
        If operators.Contains(word) Then
            Return True
        End If
        Return False
    End Function

    Public Shared Function countCharacters(ByVal input As String, ByVal charmatch As Char) As Integer
        Dim result As Integer = 0
        For Each c As Char In input
            If c = charmatch Then
                result += 1
            End If
        Next
        Return result
    End Function

    Public Shared Function GetBrackets(ByVal tokens As TokenList) As List(Of String)
        Dim bracketStrings As List(Of String) = New List(Of String)

        For Each t As Token In tokens
            If t.state = TokenState.BRACKET_START Then
                bracketStrings.Add("")
            End If
            If t.state = TokenState.WITHIN_BRACKET Then
                Dim currentLast = bracketStrings.Last()
                bracketStrings.RemoveAt(bracketStrings.Count - 1)
                bracketStrings.Add(If(currentLast = "", "", currentLast + " ") + t.ToString())
            End If
        Next
        Return bracketStrings
    End Function

    Public Shared Function splitByWord(ByVal input As String, ByVal splitter As String) As String()
        Return System.Text.RegularExpressions.Regex.Split(input, splitter)
    End Function

    Public Shared Function ReturnResult(ByVal numeric1 As Double, ByVal numeric2 As Double, ByVal op As String) As String
        Select Case op
            Case "min"
                Return Math.Min(numeric1, numeric2)
            Case "max"
                Return Math.Max(numeric1, numeric2)
            Case "**"
                Return Math.Pow(numeric1, numeric2)
            Case "/"
                Return numeric1 / numeric2
            Case "mod"
                Return numeric1 Mod numeric2
            Case "*"
                Return numeric1 * numeric2
            Case "+"
                Return numeric1 + numeric2
            Case "-"
                Return numeric1 - numeric2
            Case ">"
                Return numeric1 > numeric2
            Case ">="
                Return numeric1 >= numeric2
            Case "<"
                Return numeric1 < numeric2
            Case "<="
                Return numeric1 <= numeric2
            Case "="
                Return numeric1 = numeric2
            Case "!="
                Return numeric1 <> numeric2
            Case "and"
                Return If(numeric1 + numeric2 = 2, "1", "0").ToLower()
            Case "or"
                Return If(numeric1 = 1 Or numeric2 = 1, "1", "0").ToLower()
        End Select
        Return "0"
    End Function

    Public Shared Function AllIndexesOf(ByVal look As String, ByVal find As Char) As List(Of Integer)
        Dim result = New List(Of Integer)
        Dim index = 0
        For Each i As Char In look
            If i = find Then
                result.Add(index)
            End If
            index += 1
        Next
        Return result
    End Function

    Public Shared Function AllWordIndexesOf(ByVal look As String, ByVal word As String) As List(Of Integer)
        Dim result = New List(Of Integer)
        Dim index = 0
        Dim split = look.Split(" ")
        For Each i As String In look.Split(" ")
            If i = word Then
                result.Add(index)
            End If
            index += 1
        Next
        Return result
    End Function

    Public Shared Function FindChanges(ByVal input As String) As List(Of ExpressionToOutput)
        Dim changes = New List(Of ExpressionToOutput)()
        Dim list = New TokenList(input)

        If input.Split(" ").Count = 1 Then
            Return changes
        End If

        For Each op As String In operators
            Dim allIndexes = AllIndexesOf(input, op)
            Dim allIndexesNoSpaces = AllIndexesOf(input.Replace(" ", ""), op)

            Dim tIndexes = New List(Of Integer)
            For i As Integer = 0 To allIndexes.Count - 1
                tIndexes.Add(allIndexes(i) - allIndexesNoSpaces(i))
            Next

            For Each ii As Integer In tIndexes

                Dim token1 = list(ii - 1)
                token1 = If(token1.state = TokenState.BOOL, New Token(If(token1.ToString().ToLower() = "true", "1", "0"), TokenState.NUMERIC), token1)
                Dim token2 = list(ii + 1)
                token2 = If(token2.state = TokenState.BOOL, New Token(If(token2.ToString().ToLower() = "true", "1", "0"), TokenState.NUMERIC), token2)

                Dim numeric1 = CDbl(token1.ToString())
                Dim currentOperator = list(ii).ToString()
                Dim numeric2 = CDbl(token2.ToString())

                Dim currentExpression As String = CStr(numeric1) + " " + currentOperator + " " + CStr(numeric2)
                Dim currentResult = ReturnResult(numeric1, numeric2, currentOperator)

                changes.Add(New ExpressionToOutput(currentExpression, currentResult, op))
            Next
        Next
        Return changes
    End Function

    Public Shared Function GetStringTokenType(ByVal input As String) As TokenState
        If IsNumeric(input) Then
            Return TokenState.NUMERIC
        ElseIf ParserUtility.isOperator(input) Then
            Return TokenState.MATHEMATICAL_OPERATOR
        ElseIf input.ToLower() = "true" Or input.ToLower() = "false" Then
            Return TokenState.BOOL
            input = If(input.ToLower() = "true", 1, 0)
        ElseIf input.ToLower() = "and" Or input.ToLower() = "or" Then
            Return TokenState.ANDOR
        Else
            Return TokenState.UNKNOWN_STATE
        End If
    End Function
End Class
