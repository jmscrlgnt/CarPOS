Imports System.Data.SQLite
Imports CarDealershipPOS.Data

Namespace CarDealershipPOS.Services
    Public NotInheritable Class SettingsService
        Public Function GetValue(key As String, Optional fallback As String = "") As String
            Dim value = Database.Scalar(Of String)("SELECT Value FROM Settings WHERE Key=@k", New SQLiteParameter("@k", key))
            Return If(value, fallback)
        End Function
        Public Sub SetValue(key As String, value As String)
            Database.Execute("INSERT INTO Settings(Key,Value) VALUES(@k,@v) ON CONFLICT(Key) DO UPDATE SET Value=excluded.Value", New SQLiteParameter("@k",key), New SQLiteParameter("@v",value))
            Dim auditService As New AuditService()
            auditService.Write("Setting updated", "Setting", key, "Value=" & value)
        End Sub
        Public Function GetTaxRate() As Decimal
            Dim parsed As Decimal
            If Decimal.TryParse(GetValue("TaxRate","12.00"), Globalization.NumberStyles.Number, Globalization.CultureInfo.InvariantCulture, parsed) Then Return parsed
            Return 12D
        End Function
    End Class
End Namespace
