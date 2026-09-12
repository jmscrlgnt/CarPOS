Imports System
Imports System.Data
Imports System.Data.SQLite
Imports CarDealershipPOS.Data
Imports CarDealershipPOS.Data.Repositories
Imports CarDealershipPOS.Models
Imports CarDealershipPOS.Security

Namespace CarDealershipPOS.Services
    Public NotInheritable Class AuthService
        Private ReadOnly _audit As New AuditService()
        Private ReadOnly _users As New UserRepository()

        Public Function HasAdministrator() As Boolean
            Return _users.CountActiveAdministrators() > 0
        End Function

        Public Function CreateInitialAdministrator(username As String, password As String) As String
            If HasAdministrator() Then Return "An administrator already exists."
            If String.IsNullOrWhiteSpace(username) Then Return "Username is required."
            If password Is Nothing OrElse password.Length < 8 Then Return "Password must be at least 8 characters."
            Dim hash As String = Nothing, salt As String = Nothing
            PasswordSecurity.HashPassword(password, hash, salt)
            Dim now = DateTime.UtcNow.ToString("o")
            Database.Execute("INSERT INTO Users(Username,PasswordHash,PasswordSalt,Role,IsActive,CreatedAtUtc,UpdatedAtUtc) VALUES(@u,@h,@s,'Administrator',1,@n,@n)",
                New SQLiteParameter("@u", username.Trim()), New SQLiteParameter("@h", hash), New SQLiteParameter("@s", salt), New SQLiteParameter("@n", now))
            _audit.Write("Initial administrator created", "User", Nothing, "Role=Administrator", username.Trim())
            Return Nothing
        End Function

        Public Function Login(username As String, password As String) As User
            Dim user=_users.FindByUsername(username)
            If user Is Nothing Then
                _audit.Write("Login failed","User",Nothing,"Unknown username",username)
                Return Nothing
            End If
            If Not user.IsActive OrElse Not PasswordSecurity.VerifyPassword(password,user.PasswordHash,user.PasswordSalt) Then
                _audit.Write("Login failed","User",user.Id.ToString(),"Invalid credentials",username)
                Return Nothing
            End If
            SessionContext.UserId=user.Id : SessionContext.Username=user.Username : SessionContext.Role=user.Role
            _audit.Write("Login successful","User",user.Id.ToString(),"Role=" & user.Role)
            user.PasswordHash=Nothing : user.PasswordSalt=Nothing
            Return user
        End Function

        Public Function CreateStaff(username As String, password As String, role As String) As String
            If Not SessionContext.IsAdministrator Then Return "Administrator access required."
            If String.IsNullOrWhiteSpace(username) Then Return "Username is required."
            If password Is Nothing OrElse password.Length < 8 Then Return "Password must be at least 8 characters."
            If role <> "Administrator" AndAlso role <> "Sales Staff" Then Return "Invalid role."
            If Database.Scalar(Of Long)("SELECT COUNT(*) FROM Users WHERE Username=@u", New SQLiteParameter("@u", username.Trim())) > 0 Then Return "Username already exists."
            Dim hash As String = Nothing, salt As String = Nothing
            PasswordSecurity.HashPassword(password, hash, salt)
            Dim now = DateTime.UtcNow.ToString("o")
            Database.Execute("INSERT INTO Users(Username,PasswordHash,PasswordSalt,Role,IsActive,CreatedAtUtc,UpdatedAtUtc) VALUES(@u,@h,@s,@r,1,@n,@n)", New SQLiteParameter("@u",username.Trim()),New SQLiteParameter("@h",hash),New SQLiteParameter("@s",salt),New SQLiteParameter("@r",role),New SQLiteParameter("@n",now))
            _audit.Write("User created", "User", Nothing, "Username=" & username.Trim() & ";Role=" & role)
            Return Nothing
        End Function

        Public Function ListUsers() As DataTable
            Return _users.ListUsers()
        End Function


        Public Sub SetUserActive(userId As Long, isActive As Boolean)
            If Not SessionContext.IsAdministrator Then Throw New UnauthorizedAccessException("Administrator access required.")
            If userId = SessionContext.UserId AndAlso Not isActive Then Throw New InvalidOperationException("You cannot deactivate your own account.")
            Database.Execute("UPDATE Users SET IsActive=@a,UpdatedAtUtc=@n WHERE Id=@id", New SQLiteParameter("@a", If(isActive,1,0)), New SQLiteParameter("@n", DateTime.UtcNow.ToString("o")), New SQLiteParameter("@id", userId))
            _audit.Write(If(isActive,"User activated","User deactivated"),"User",userId.ToString())
        End Sub

        Public Function ResetPassword(userId As Long, newPassword As String) As String
            If Not SessionContext.IsAdministrator Then Return "Administrator access required."
            If newPassword Is Nothing OrElse newPassword.Length < 8 Then Return "Password must be at least 8 characters."
            Dim hash As String = Nothing, salt As String = Nothing
            PasswordSecurity.HashPassword(newPassword, hash, salt)
            Database.Execute("UPDATE Users SET PasswordHash=@h,PasswordSalt=@s,UpdatedAtUtc=@n WHERE Id=@id",New SQLiteParameter("@h",hash),New SQLiteParameter("@s",salt),New SQLiteParameter("@n",DateTime.UtcNow.ToString("o")),New SQLiteParameter("@id",userId))
            _audit.Write("Password reset","User",userId.ToString())
            Return Nothing
        End Function

        Public Sub Logout()
            If SessionContext.UserId <> 0 Then _audit.Write("Logout", "User", SessionContext.UserId.ToString())
            SessionContext.Clear()
        End Sub
    End Class
End Namespace
