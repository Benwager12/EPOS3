Public Class Database

    ' Provider and File, necessary for any connection
    Private dbProvider As String = "Provider=Microsoft.ACE.OLEDB.12.0;"
    Private dbFile As String = "Data Source=Database.accdb"

    ' Specific connection, I've heard that you can specify the connection string in the constructor.
    Private connection As OleDb.OleDbConnection = New OleDb.OleDbConnection(dbProvider + dbFile)

    ' Data adapter is used to fill the data set.
    Private dataadapter As OleDb.OleDbDataAdapter

    ' Filled data table, mostly used for querying.
    Dim table As DataTable

    ' I like using this because it helps in developing in and grabbing the table easily.
    Private tableName As String

    ' Initialize the variables, tell me if I'm developing that I initialized the table and query the access database
    ' for the full table.
    Sub New(ByVal tableName As String)
        Me.tableName = tableName
        Console.WriteLine("Initialized table with name """ + tableName + """")
        getEntireTable()
    End Sub

    ' Using a new data adapter with an SQL string to open a connection and fill a quick dataset and using the
    ' data adapter to fill a temporary table, and then the data table into the table in full view.
    Function getSQL(ByVal sql As String) As DataTable
        connection.Open()
        dataadapter = New OleDb.OleDbDataAdapter(sql, connection)
        connection.Close()

        Dim dataset As DataSet = New DataSet()
        dataadapter.Fill(dataset, tableName)
        table = dataset.Tables(tableName)
        Return table
    End Function

    ' Just using the previous table with some basic SQL to get the entirety of the table.
    Function getEntireTable()
        Return getSQL("SELECT * FROM " + tableName)
    End Function
End Class
