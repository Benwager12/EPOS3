Imports System.Windows.Forms

Public Class ShowAmount

    Private Price As String

    Public Sub New(ByVal Price As String)
        Me.Price = Price
        InitializeComponent()
    End Sub

    Private Sub ShowAmount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAmount.Text = "The customer has ordered £" + Format(CDbl(Price), "0.00") + "."
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
