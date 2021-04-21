Public Class TokenList
    Inherits List(Of Token)

    Private Sub New(ByVal tokens As List(Of Token))
        For Each t As Token In tokens
            Add(t)
        Next
    End Sub

    Sub New(ByVal input As String)
        If ParserUtility.countCharacters(input, "(") <> ParserUtility.countCharacters(input, ")") Then
            Throw New Exception("Mismatched brackets")
        End If

        Dim splitString As String() = input.Replace("(", "( ").Replace(")", " )").Split(" ")
        Dim currentToken As TokenState

        Dim bracketAmount As Integer = 0

        For Each word As String In splitString
            If word.StartsWith("(") Then
                If bracketAmount = 0 Then
                    currentToken = TokenState.BRACKET_START
                End If
                bracketAmount += 1
            ElseIf word.EndsWith(")") Then
                If bracketAmount = 1 Then
                    currentToken = TokenState.BRACKET_END
                End If
                bracketAmount -= 1
            ElseIf inBracket() Then
                currentToken = TokenState.WITHIN_BRACKET
            ElseIf IsNumeric(word) Then
                currentToken = TokenState.NUMERIC
            ElseIf ParserUtility.isOperator(word) Then
                currentToken = TokenState.MATHEMATICAL_OPERATOR
            ElseIf word.ToLower() = "true" Or word.ToLower() = "false" Then
                currentToken = TokenState.BOOL
                word = If(word.ToLower() = "true", 1, 0)
            ElseIf word.ToLower() = "and" Or word.ToLower() = "or" Then
                currentToken = TokenState.ANDOR
            Else
                currentToken = TokenState.UNKNOWN_STATE
            End If
            Add(New Token(word.ToLower(), currentToken))
        Next
    End Sub

    Function ExpandTokens() As String
        Dim expanded As String = ""
        For Each t As Token In Me
            expanded += t.ToString() + " "
        Next
        Return expanded.Substring(0, expanded.Length - 1)
    End Function

    Private Function InBracket() As Boolean
        If Count = 0 Then
            Return False
        End If
        Return Last.state = TokenState.BRACKET_START Or Last.state = TokenState.WITHIN_BRACKET
    End Function

    Function CheckNextToEachOther(ByVal check As TokenState) As Boolean
        Dim index As Integer = -1
        Dim previousState As TokenState

        For Each t As Token In Me
            index += 1
            If index = 0 Then
                previousState = t.state
                Continue For
            End If

            If previousState = t.state And t.state = check Then
                Return True
            End If
            previousState = t.state
        Next
        Return False
    End Function

    Function GetResult() As Token
        For Each t As Token In Me
            If t.state = TokenState.UNKNOWN_STATE Then
                Throw New Exception("Unknown state")
            End If
        Next

        If CheckNextToEachOther(TokenState.NUMERIC) Then
            Throw New Exception("Two numbers next to each other.")
        End If

        If CheckNextToEachOther(TokenState.MATHEMATICAL_OPERATOR) Then
            Throw New Exception("Two operators next to each other.")
        End If

        Dim result = DoBrackets().ExpandTokens()

        If ParserUtility.isOperator(Item(0).ToString()) Then
            Throw New Exception("First item cannot be a operator")
        End If

        Dim changes = ParserUtility.FindChanges(result)
        ' Dim result = ExpandTokens()
        While changes.Count > 0
            For Each op As String In ParserUtility.operators
                If changes.Count = 0 Then
                    Continue For
                End If
                If op <> changes(0).op Then
                    Continue For
                End If

                result = result.Replace(changes(0).expression, changes(0).output)
                changes = ParserUtility.FindChanges(result)
            Next
        End While
        '' WRONG, I AM NOT RESPECTING BODMAS, INSTEAD, LOOP THROUGH OPERATORS IN THAT ORDER AND CHECK BEFORE AND AFTER INDEXES
        'For index As Integer = 0 To Count - 1
        '    If index = 0 And ParserUtility.isOperator(Item(index).ToString()) Then
        '        Throw New Exception("First item cannot be a operator")
        '    End If

        '    If Not ParserUtility.isOperator(Item(index).ToString()) Then
        '        Continue For
        '    End If
        '    Dim token1 = Item(index - 1)
        '    token1 = If(token1.state = TokenState.BOOL, New Token(If(token1.ToString() = "true", "1", "0"), TokenState.NUMERIC), token1)
        '    Dim token2 = Item(index + 1)
        '    token2 = If(token2.state = TokenState.BOOL, New Token(If(token2.ToString() = "true", "1", "0"), TokenState.NUMERIC), token2)

        '    Dim numeric1 = CDbl(token1.ToString())
        '    Dim currentOperator = Item(index).ToString()
        '    Dim numeric2 = CDbl(token2.ToString())

        '    Dim currentExpression As String = CStr(numeric1) + " " + currentOperator + " " + CStr(numeric2)
        '    Dim currentResult = ParserUtility.ReturnResult(numeric1, numeric2, currentOperator)
        '    Console.WriteLine(currentExpression + " ----- " + currentResult)

        '    result = New TokenList(result.ExpandTokens().Replace(currentExpression, currentResult))
        'Next

        Return (New Token(result.ToLower(), ParserUtility.GetStringTokenType(result)))
    End Function



    Function DoBrackets() As TokenList
        Dim brackets As List(Of String) = ParserUtility.GetBrackets(Me)
        Dim beforeWrite As String = ExpandTokens()

        Dim emptyList As New List(Of Token)

        For Each bracket As String In brackets
            beforeWrite = beforeWrite.Replace("( " + bracket + " )", New TokenList(bracket).GetResult().ToString())
        Next

        For Each t As Token In New TokenList(beforeWrite)
            emptyList.Add(t)
        Next

        Return New TokenList(emptyList)
    End Function

    Overrides Function ToString() As String
        Dim result As String = ""
        For Each i As Token In Me
            result += i.tokenString + " --- " + CStr(i.state) + Environment.NewLine
        Next
        'result = result.Substring(0, result.Length - 2)
        Return result
    End Function
End Class