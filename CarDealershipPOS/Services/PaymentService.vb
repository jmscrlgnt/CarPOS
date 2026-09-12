Imports System
Imports System.Data
Imports System.Data.SQLite
Imports CarDealershipPOS.Data

Namespace CarDealershipPOS.Services
    Public NotInheritable Class PaymentService
        Private ReadOnly _audit As New AuditService()
        Public Function ListOpenBalances() As DataTable
            Return Database.Query("SELECT s.Id AS SaleId,s.SaleNumber,c.FirstName || ' ' || c.LastName AS Customer,v.Brand || ' ' || v.Model AS Vehicle,s.Total,COALESCE(SUM(p.Amount),0) AS Paid,(s.Total-COALESCE(SUM(p.Amount),0)) AS Balance FROM Sales s JOIN Customers c ON c.Id=s.CustomerId JOIN SaleItems si ON si.SaleId=s.Id JOIN Vehicles v ON v.Id=si.VehicleId LEFT JOIN Payments p ON p.SaleId=s.Id WHERE s.Status='Completed' GROUP BY s.Id HAVING Balance>0.009 ORDER BY s.Id DESC")
        End Function
        Public Function GetBalance(saleId As Long) As Decimal
            Return Database.Scalar(Of Decimal)("SELECT s.Total-COALESCE((SELECT SUM(Amount) FROM Payments WHERE SaleId=s.Id),0) FROM Sales s WHERE s.Id=@id",New SQLiteParameter("@id",saleId))
        End Function
        Public Function RecordPayment(saleId As Long, amount As Decimal, method As String, reference As String) As String
            If amount<=0D Then Return "Payment must be greater than zero."
            Dim balance=GetBalance(saleId)
            If balance<=0D Then Return "This sale is already fully paid."
            If amount>balance Then Return "Payment exceeds the outstanding balance."
            Database.Execute("INSERT INTO Payments(SaleId,UserId,Amount,Method,ReferenceNumber,PaidAtUtc) VALUES(@s,@u,@a,@m,@r,@n)",New SQLiteParameter("@s",saleId),New SQLiteParameter("@u",SessionContext.UserId),New SQLiteParameter("@a",amount),New SQLiteParameter("@m",method),New SQLiteParameter("@r",reference),New SQLiteParameter("@n",DateTime.UtcNow.ToString("o")))
            _audit.Write("Installment payment recorded","Sale",saleId.ToString(),"Amount=" & amount.ToString("0.00"))
            Return Nothing
        End Function
        Public Function GetPaymentHistory(saleId As Long) As DataTable
            Return Database.Query("SELECT PaidAtUtc AS Date,Amount,Method,ReferenceNumber FROM Payments WHERE SaleId=@id ORDER BY Id DESC",New SQLiteParameter("@id",saleId))
        End Function
    End Class
End Namespace
