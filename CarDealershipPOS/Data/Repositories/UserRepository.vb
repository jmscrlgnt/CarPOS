Imports System.Data
Imports System.Data.SQLite
Imports CarDealershipPOS.Models

Namespace CarDealershipPOS.Data.Repositories
    Public NotInheritable Class UserRepository
        Public Function CountActiveAdministrators() As Long
            Return Database.Scalar(Of Long)("SELECT COUNT(*) FROM Users WHERE Role='Administrator' AND IsActive=1")
        End Function
        Public Function FindByUsername(username As String) As User
            Dim table=Database.Query("SELECT Id,Username,PasswordHash,PasswordSalt,Role,IsActive FROM Users WHERE Username=@u LIMIT 1",New SQLiteParameter("@u",username.Trim()))
            If table.Rows.Count=0 Then Return Nothing
            Dim row=table.Rows(0)
            Return New User With {.Id=CLng(row("Id")),.Username=CStr(row("Username")),.PasswordHash=CStr(row("PasswordHash")),.PasswordSalt=CStr(row("PasswordSalt")),.Role=CStr(row("Role")),.IsActive=CBool(row("IsActive"))}
        End Function
        Public Function ListUsers() As DataTable
            Return Database.Query("SELECT Id,Username,Role,CASE WHEN IsActive=1 THEN 'Active' ELSE 'Inactive' END AS Status,CreatedAtUtc FROM Users ORDER BY Username")
        End Function
    End Class
End Namespace
