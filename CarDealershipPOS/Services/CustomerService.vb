Imports System
Imports System.Data
Imports System.Data.SQLite
Imports CarDealershipPOS.Data
Imports CarDealershipPOS.Data.Repositories
Imports CarDealershipPOS.Models

Namespace CarDealershipPOS.Services
    Public NotInheritable Class CustomerService
        Private ReadOnly _audit As New AuditService()
        Private ReadOnly _repo As New CustomerRepository()
        Public Function Search(query As String, includeInactive As Boolean) As DataTable
            Return _repo.Search(query,includeInactive)
        End Function
        Public Function GetById(id As Long) As Customer
            Return _repo.GetById(id)
        End Function
        Public Function Save(c As Customer) As String
            If c Is Nothing Then Return "Customer is required."
            If String.IsNullOrWhiteSpace(c.FirstName) OrElse String.IsNullOrWhiteSpace(c.LastName) Then Return "First and last name are required."
            If String.IsNullOrWhiteSpace(c.CustomerNumber) Then c.CustomerNumber="CUS-" & DateTime.Now.ToString("yyyyMMddHHmmss")
            If Database.Scalar(Of Long)("SELECT COUNT(*) FROM Customers WHERE CustomerNumber=@n AND Id<>@id",New SQLiteParameter("@n",c.CustomerNumber.Trim()),New SQLiteParameter("@id",c.Id))>0 Then Return "Customer number already exists."
            If Not String.IsNullOrWhiteSpace(c.ContactNumber) AndAlso c.ContactNumber.Trim().Length < 7 Then Return "Contact number is too short."
            Dim now=DateTime.UtcNow.ToString("o")
            If c.Id=0 Then
                Database.Execute("INSERT INTO Customers(CustomerNumber,FirstName,LastName,Email,ContactNumber,Address,IsActive,CreatedAtUtc,UpdatedAtUtc) VALUES(@n,@f,@l,@e,@c,@a,1,@now,@now)",New SQLiteParameter("@n",c.CustomerNumber.Trim()),New SQLiteParameter("@f",c.FirstName.Trim()),New SQLiteParameter("@l",c.LastName.Trim()),New SQLiteParameter("@e",Db(c.Email)),New SQLiteParameter("@c",Db(c.ContactNumber)),New SQLiteParameter("@a",Db(c.Address)),New SQLiteParameter("@now",now))
                _audit.Write("Customer created","Customer",Nothing,c.CustomerNumber)
            Else
                Database.Execute("UPDATE Customers SET CustomerNumber=@n,FirstName=@f,LastName=@l,Email=@e,ContactNumber=@c,Address=@a,UpdatedAtUtc=@now WHERE Id=@id",New SQLiteParameter("@n",c.CustomerNumber.Trim()),New SQLiteParameter("@f",c.FirstName.Trim()),New SQLiteParameter("@l",c.LastName.Trim()),New SQLiteParameter("@e",Db(c.Email)),New SQLiteParameter("@c",Db(c.ContactNumber)),New SQLiteParameter("@a",Db(c.Address)),New SQLiteParameter("@now",now),New SQLiteParameter("@id",c.Id))
                _audit.Write("Customer updated","Customer",c.Id.ToString(),c.CustomerNumber)
            End If
            Return Nothing
        End Function
        Public Sub Deactivate(id As Long)
            Database.Execute("UPDATE Customers SET IsActive=0,UpdatedAtUtc=@n WHERE Id=@id",New SQLiteParameter("@n",DateTime.UtcNow.ToString("o")),New SQLiteParameter("@id",id))
            _audit.Write("Customer deactivated","Customer",id.ToString())
        End Sub
        Private Shared Function Db(value As String) As Object
            Return If(String.IsNullOrWhiteSpace(value),CType(DBNull.Value,Object),value.Trim())
        End Function
    End Class
End Namespace
