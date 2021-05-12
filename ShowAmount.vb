Imports System.Windows.Forms

Public Class ShowAmount

    ' Global price variable
    Private Price As String

    ' Initialize the form.
    Public Sub New(ByVal Price As String)
        Me.Price = Price
        InitializeComponent()
    End Sub

    ' Set the form amount when it is loaded
    Private Sub ShowAmount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAmount.Text = "The customer has ordered £" + Format(CDbl(Price), "0.00") + "."
    End Sub

    ' Close the form when I'm done with it
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
