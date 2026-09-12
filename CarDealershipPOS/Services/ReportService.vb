Imports System
Imports System.Data
Imports System.Data.SQLite
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports CarDealershipPOS.Data

Namespace CarDealershipPOS.Services
    Public NotInheritable Class ReportService
        Public Function DashboardMetrics() As DataTable
            Dim t As New DataTable()
            t.Columns.Add("Metric") : t.Columns.Add("Value")
            t.Rows.Add("Available Inventory",Database.Scalar(Of Long)("SELECT COUNT(*) FROM Vehicles WHERE Status='Available'"))
            t.Rows.Add("New Vehicles",Database.Scalar(Of Long)("SELECT COUNT(*) FROM Vehicles WHERE Status='Available' AND Condition='New'"))
            t.Rows.Add("Used Vehicles",Database.Scalar(Of Long)("SELECT COUNT(*) FROM Vehicles WHERE Status='Available' AND Condition='Used'"))
            t.Rows.Add("Sales Today",Database.Scalar(Of Long)("SELECT COUNT(*) FROM Sales WHERE Status='Completed' AND date(CreatedAtUtc)=date('now')"))
            t.Rows.Add("Sales This Month",Database.Scalar(Of Decimal)("SELECT COALESCE(SUM(Total),0) FROM Sales WHERE Status='Completed' AND strftime('%Y-%m',CreatedAtUtc)=strftime('%Y-%m','now')").ToString("N2"))
            t.Rows.Add("Receivables",Database.Scalar(Of Decimal)("SELECT COALESCE(SUM(Balance),0) FROM (SELECT s.Total-COALESCE(SUM(p.Amount),0) Balance FROM Sales s LEFT JOIN Payments p ON p.SaleId=s.Id WHERE s.Status='Completed' GROUP BY s.Id)").ToString("N2"))
            Return t
        End Function
        Public Function RecentSales(Optional limit As Integer=12) As DataTable
            Return Database.Query("SELECT s.Id,s.SaleNumber,c.FirstName || ' ' || c.LastName AS Customer,v.Brand || ' ' || v.Model AS Vehicle,s.Total,s.PaymentPlan,s.CreatedAtUtc AS Date FROM Sales s JOIN Customers c ON c.Id=s.CustomerId JOIN SaleItems si ON si.SaleId=s.Id JOIN Vehicles v ON v.Id=si.VehicleId ORDER BY s.Id DESC LIMIT @l",New SQLiteParameter("@l",limit))
        End Function
        Public Function Sales(fromDate As DateTime, toDate As DateTime, query As String) As DataTable
            Dim sql="SELECT s.Id,s.SaleNumber,c.FirstName || ' ' || c.LastName AS Customer,v.StockNumber,v.Brand || ' ' || v.Model AS Vehicle,s.Total,COALESCE(SUM(p.Amount),0) AS Paid,(s.Total-COALESCE(SUM(p.Amount),0)) AS Balance,s.PaymentPlan,u.Username AS Staff,s.CreatedAtUtc AS Date FROM Sales s JOIN Customers c ON c.Id=s.CustomerId JOIN Users u ON u.Id=s.UserId JOIN SaleItems si ON si.SaleId=s.Id JOIN Vehicles v ON v.Id=si.VehicleId LEFT JOIN Payments p ON p.SaleId=s.Id WHERE datetime(s.CreatedAtUtc)>=datetime(@f) AND datetime(s.CreatedAtUtc)<datetime(@t)"
            Dim ps As New List(Of SQLiteParameter) From {New SQLiteParameter("@f",fromDate.Date.ToUniversalTime().ToString("o")),New SQLiteParameter("@t",toDate.Date.AddDays(1).ToUniversalTime().ToString("o"))}
            If Not String.IsNullOrWhiteSpace(query) Then sql &= " AND (s.SaleNumber LIKE @q OR c.FirstName LIKE @q OR c.LastName LIKE @q OR v.StockNumber LIKE @q OR v.Brand LIKE @q OR v.Model LIKE @q)" : ps.Add(New SQLiteParameter("@q","%" & query.Trim() & "%"))
            sql &= " GROUP BY s.Id ORDER BY s.Id DESC"
            Return Database.Query(sql,ps.ToArray())
        End Function
        Public Sub ExportCsv(table As DataTable, path As String)
            Dim sb As New StringBuilder()
            sb.AppendLine(String.Join(",",table.Columns.Cast(Of DataColumn)().Select(Function(c) Csv(c.ColumnName))))
            For Each row As DataRow In table.Rows
                sb.AppendLine(String.Join(",",table.Columns.Cast(Of DataColumn)().Select(Function(c) Csv(If(row(c) Is DBNull.Value,"",Convert.ToString(row(c),CultureInfo.InvariantCulture))))))
            Next
            File.WriteAllText(path,sb.ToString(),Encoding.UTF8)
        End Sub
        Private Shared Function Csv(value As String) As String
            Dim quote As String = ChrW(34)
            Return quote & value.Replace(quote, quote & quote) & quote
        End Function
    End Class
End Namespace
