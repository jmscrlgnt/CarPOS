Imports System
Imports System.Data.SQLite
Imports CarDealershipPOS.Data

Namespace CarDealershipPOS.Services
    Public NotInheritable Class AuditService
        Public Sub Write(action As String, Optional entityType As String = Nothing, Optional entityId As String = Nothing, Optional details As String = Nothing, Optional usernameOverride As String = Nothing)
            Database.Execute("INSERT INTO AuditLogs(UserId,Username,Action,EntityType,EntityId,Details,CreatedAtUtc) VALUES(@uid,@u,@a,@et,@ei,@d,@now)",
                New SQLiteParameter("@uid", If(SessionContext.UserId = 0, CType(DBNull.Value, Object), SessionContext.UserId)),
                New SQLiteParameter("@u", If(usernameOverride, SessionContext.Username)),
                New SQLiteParameter("@a", action), New SQLiteParameter("@et", entityType), New SQLiteParameter("@ei", entityId), New SQLiteParameter("@d", details),
                New SQLiteParameter("@now", DateTime.UtcNow.ToString("o")))
        End Sub

        Public Function ListRecent(Optional limit As Integer = 250) As System.Data.DataTable
            Return Database.Query("SELECT CreatedAtUtc AS Time,COALESCE(Username,'System') AS [User],Action,EntityType AS Entity,Details FROM AuditLogs ORDER BY Id DESC LIMIT @l", New SQLiteParameter("@l", limit))
        End Function
    End Class
End Namespace
