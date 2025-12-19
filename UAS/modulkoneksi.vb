Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Module modulkoneksi

    Private ReadOnly connectionString As String =
        "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\praty\source\repos\UAS\UAS\Database1.mdf;Integrated Security=True"

    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

End Module
