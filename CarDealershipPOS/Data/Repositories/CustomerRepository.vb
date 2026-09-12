Imports System.Data
Imports System.Data.SQLite
Imports CarDealershipPOS.Models

Namespace CarDealershipPOS.Data.Repositories
    Public NotInheritable Class CustomerRepository
        Public Function Search(query As String, includeInactive As Boolean) As DataTable
            Dim sql="SELECT Id,CustomerNumber,FirstName || ' ' || LastName AS Customer,Email,ContactNumber,Address,CASE WHEN IsActive=1 THEN 'Active' ELSE 'Inactive' END AS Status FROM Customers WHERE 1=1"
            Dim ps As New List(Of SQLiteParameter)()
            If Not includeInactive Then sql &= " AND IsActive=1"
            If Not String.IsNullOrWhiteSpace(query) Then sql &= " AND (CustomerNumber LIKE @q OR FirstName LIKE @q OR LastName LIKE @q OR Email LIKE @q OR ContactNumber LIKE @q)" : ps.Add(New SQLiteParameter("@q","%" & query.Trim() & "%"))
            sql &= " ORDER BY LastName,FirstName"
            Return Database.Query(sql,ps.ToArray())
        End Function
        Public Function GetById(id As Long) As Customer
            Dim t=Database.Query("SELECT * FROM Customers WHERE Id=@id",New SQLiteParameter("@id",id))
            If t.Rows.Count=0 Then Return Nothing
            Dim r=t.Rows(0)
            Return New Customer With {.Id=CLng(r("Id")),.CustomerNumber=CStr(r("CustomerNumber")),.FirstName=CStr(r("FirstName")),.LastName=CStr(r("LastName")),.Email=If(r("Email") Is DBNull.Value,"",CStr(r("Email"))),.ContactNumber=If(r("ContactNumber") Is DBNull.Value,"",CStr(r("ContactNumber"))),.Address=If(r("Address") Is DBNull.Value,"",CStr(r("Address"))),.IsActive=CBool(r("IsActive"))}
        End Function
    End Class
End Namespace
