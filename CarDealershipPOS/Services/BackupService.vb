Imports System
Imports System.IO
Imports CarDealershipPOS.Utilities

Namespace CarDealershipPOS.Services
    Public NotInheritable Class BackupService
        Public Function CreateBackup(Optional destination As String=Nothing) As String
            AppPaths.EnsureDirectories()
            If String.IsNullOrWhiteSpace(destination) Then destination=Path.Combine(AppPaths.BackupDirectory,"dealership-" & DateTime.Now.ToString("yyyyMMdd-HHmmss") & ".db")
            File.Copy(AppPaths.DatabasePath,destination,True)
            Dim auditService As New AuditService()
            auditService.Write("Database backup created", "Database", Nothing, destination)
            Return destination
        End Function
        Public Sub Restore(source As String)
            If Not SessionContext.IsAdministrator Then Throw New UnauthorizedAccessException("Administrator access required.")
            If Not File.Exists(source) Then Throw New FileNotFoundException("Backup file not found.",source)
            CreateBackup()
            File.Copy(source,AppPaths.DatabasePath,True)
            Dim auditService As New AuditService()
            auditService.Write("Database restored", "Database", Nothing, source)
        End Sub
    End Class
End Namespace
