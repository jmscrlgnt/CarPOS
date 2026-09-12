Imports System
Imports System.Data
Imports System.Data.SQLite
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports CarDealershipPOS.Utilities

Namespace CarDealershipPOS.Data
    Public NotInheritable Class Database
        Private Sub New()
        End Sub

        Public Shared Sub Initialize()
            AppPaths.EnsureDirectories()
            Dim isNew As Boolean = Not File.Exists(AppPaths.DatabasePath)
            Using connection = OpenConnection()
                Dim schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "schema.sql")
                Dim sql As String
                If File.Exists(schemaPath) Then
                    sql = File.ReadAllText(schemaPath)
                Else
                    Using stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CarDealershipPOS.Data.schema.sql")
                        If stream Is Nothing Then Throw New FileNotFoundException("Embedded database schema was not found.")
                        Using reader As New StreamReader(stream)
                            sql = reader.ReadToEnd()
                        End Using
                    End Using
                End If
                Using command As New SQLiteCommand(sql, connection)
                    command.ExecuteNonQuery()
                End Using
            End Using
            EnsureDefaultSettings()
        End Sub

        Public Shared Function OpenConnection() As SQLiteConnection
            AppPaths.EnsureDirectories()
            Dim connection As New SQLiteConnection("Data Source=" & AppPaths.DatabasePath & ";Version=3;Foreign Keys=True;")
            connection.Open()
            Return connection
        End Function

        Public Shared Function Query(sql As String, ParamArray parameters() As SQLiteParameter) As DataTable
            Using connection = OpenConnection(), command As New SQLiteCommand(sql, connection)
                If parameters IsNot Nothing Then
                    For Each parameter As SQLiteParameter In parameters
                        command.Parameters.Add(parameter)
                    Next
                End If
                Using adapter As New SQLiteDataAdapter(command)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    Return table
                End Using
            End Using
        End Function

        Public Shared Function Scalar(Of T)(sql As String, ParamArray parameters() As SQLiteParameter) As T
            Using connection = OpenConnection(), command As New SQLiteCommand(sql, connection)
                If parameters IsNot Nothing Then
                    For Each parameter As SQLiteParameter In parameters
                        command.Parameters.Add(parameter)
                    Next
                End If
                Dim value = command.ExecuteScalar()
                If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing
                Return CType(Convert.ChangeType(value, GetType(T), CultureInfo.InvariantCulture), T)
            End Using
        End Function

        Public Shared Function Execute(sql As String, ParamArray parameters() As SQLiteParameter) As Integer
            Using connection = OpenConnection(), command As New SQLiteCommand(sql, connection)
                If parameters IsNot Nothing Then
                    For Each parameter As SQLiteParameter In parameters
                        command.Parameters.Add(parameter)
                    Next
                End If
                Return command.ExecuteNonQuery()
            End Using
        End Function

        Private Shared Sub EnsureDefaultSettings()
            Execute("INSERT OR IGNORE INTO Settings(Key,Value) VALUES('DealershipName','AutoDrive Dealership')")
            Execute("INSERT OR IGNORE INTO Settings(Key,Value) VALUES('TaxRate','12.00')")
            Execute("INSERT OR IGNORE INTO Settings(Key,Value) VALUES('Address','')")
            Execute("INSERT OR IGNORE INTO Settings(Key,Value) VALUES('ContactNumber','')")
            Execute("INSERT OR IGNORE INTO Settings(Key,Value) VALUES('ReceiptFooter','Thank you for choosing us.')")
        End Sub
    End Class
End Namespace
