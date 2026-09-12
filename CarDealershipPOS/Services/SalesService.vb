Imports System
Imports System.Data.SQLite
Imports CarDealershipPOS.Data
Imports CarDealershipPOS.Models

Namespace CarDealershipPOS.Services
    Public NotInheritable Class SalesService
        Private ReadOnly _audit As New AuditService()
        Private ReadOnly _quotation As New QuotationService()
        Public Function CalculateTotal(vehiclePrice As Decimal, discount As Decimal) As Models.Quotation
            Return _quotation.Calculate(vehiclePrice,discount)
        End Function
        Public Function FinalizeSale(customerId As Long, vehicleId As Long, discount As Decimal, paymentPlan As String, initialPayment As Decimal, paymentMethod As String, Optional quotationId As Long=0) As Long
            If paymentPlan<>"Full" AndAlso paymentPlan<>"Installment" Then Throw New ArgumentException("Invalid payment plan.")
            Using cn=Database.OpenConnection(), tx=cn.BeginTransaction()
                Dim price As Decimal
                Dim status As String
                Using checkCmd As New SQLiteCommand("SELECT SellingPrice,Status FROM Vehicles WHERE Id=@id",cn,tx)
                    checkCmd.Parameters.AddWithValue("@id",vehicleId)
                    Using reader=checkCmd.ExecuteReader()
                        If Not reader.Read() Then Throw New InvalidOperationException("Vehicle not found.")
                        price=Convert.ToDecimal(reader.GetValue(0),Globalization.CultureInfo.InvariantCulture): status=reader.GetString(1)
                    End Using
                End Using
                If status<>"Available" Then Throw New InvalidOperationException("Vehicle is no longer available.")
                If Database.Scalar(Of Long)("SELECT COUNT(*) FROM Customers WHERE Id=@id AND IsActive=1",New SQLiteParameter("@id",customerId))=0 Then Throw New InvalidOperationException("Customer is not active or does not exist.")
                Dim calc As Quotation
                If quotationId<>0 Then
                    Using quoteCmd As New SQLiteCommand("SELECT q.CustomerId,qi.VehicleId,qi.UnitPrice,q.Discount,q.TaxRate,q.TaxAmount,q.Total,q.Status FROM Quotations q JOIN QuotationItems qi ON qi.QuotationId=q.Id WHERE q.Id=@id",cn,tx)
                        quoteCmd.Parameters.AddWithValue("@id",quotationId)
                        Using quoteReader=quoteCmd.ExecuteReader()
                            If Not quoteReader.Read() Then Throw New InvalidOperationException("Quotation not found.")
                            If quoteReader.GetInt64(0)<>customerId OrElse quoteReader.GetInt64(1)<>vehicleId Then Throw New InvalidOperationException("Quotation customer or vehicle does not match the checkout selection.")
                            Dim quoteStatus=quoteReader.GetString(7)
                            If quoteStatus<>"Draft" AndAlso quoteStatus<>"Approved" Then Throw New InvalidOperationException("Quotation can no longer be converted.")
                            price=Convert.ToDecimal(quoteReader.GetValue(2),Globalization.CultureInfo.InvariantCulture)
                            calc=New Quotation With {.Subtotal=price,.Discount=Convert.ToDecimal(quoteReader.GetValue(3),Globalization.CultureInfo.InvariantCulture),.TaxRate=Convert.ToDecimal(quoteReader.GetValue(4),Globalization.CultureInfo.InvariantCulture),.TaxAmount=Convert.ToDecimal(quoteReader.GetValue(5),Globalization.CultureInfo.InvariantCulture),.Total=Convert.ToDecimal(quoteReader.GetValue(6),Globalization.CultureInfo.InvariantCulture),.Status=quoteStatus}
                        End Using
                    End Using
                Else
                    calc=_quotation.Calculate(price,discount)
                End If
                If paymentPlan="Full" AndAlso initialPayment<calc.Total Then Throw New InvalidOperationException("Full payment is insufficient.")
                If paymentPlan="Installment" AndAlso (initialPayment<0D OrElse initialPayment>calc.Total) Then Throw New InvalidOperationException("Payment amount is invalid.")
                If initialPayment<0D Then Throw New InvalidOperationException("Payment amount is invalid.")
                Dim saleNumber="S-" & DateTime.Now.ToString("yyyyMMddHHmmssfff")
                Dim saleId As Long
                Using cmd As New SQLiteCommand("INSERT INTO Sales(SaleNumber,CustomerId,UserId,QuotationId,Subtotal,Discount,TaxRate,TaxAmount,Total,PaymentPlan,Status,CreatedAtUtc) VALUES(@n,@c,@u,@q,@s,@d,@r,@ta,@t,@p,'Completed',@now); SELECT last_insert_rowid();",cn,tx)
                    cmd.Parameters.AddWithValue("@n",saleNumber):cmd.Parameters.AddWithValue("@c",customerId):cmd.Parameters.AddWithValue("@u",SessionContext.UserId):cmd.Parameters.AddWithValue("@q",If(quotationId=0,CType(DBNull.Value,Object),quotationId)):cmd.Parameters.AddWithValue("@s",calc.Subtotal):cmd.Parameters.AddWithValue("@d",calc.Discount):cmd.Parameters.AddWithValue("@r",calc.TaxRate):cmd.Parameters.AddWithValue("@ta",calc.TaxAmount):cmd.Parameters.AddWithValue("@t",calc.Total):cmd.Parameters.AddWithValue("@p",paymentPlan):cmd.Parameters.AddWithValue("@now",DateTime.UtcNow.ToString("o"))
                    saleId=CLng(cmd.ExecuteScalar())
                End Using
                Using cmd As New SQLiteCommand("INSERT INTO SaleItems(SaleId,VehicleId,UnitPrice) VALUES(@s,@v,@p)",cn,tx)
                    cmd.Parameters.AddWithValue("@s",saleId):cmd.Parameters.AddWithValue("@v",vehicleId):cmd.Parameters.AddWithValue("@p",price):cmd.ExecuteNonQuery()
                End Using
                If initialPayment>0D Then
                    Using cmd As New SQLiteCommand("INSERT INTO Payments(SaleId,UserId,Amount,Method,PaidAtUtc) VALUES(@s,@u,@a,@m,@now)",cn,tx)
                        cmd.Parameters.AddWithValue("@s",saleId):cmd.Parameters.AddWithValue("@u",SessionContext.UserId):cmd.Parameters.AddWithValue("@a",If(paymentPlan="Full",calc.Total,initialPayment)):cmd.Parameters.AddWithValue("@m",paymentMethod):cmd.Parameters.AddWithValue("@now",DateTime.UtcNow.ToString("o")):cmd.ExecuteNonQuery()
                    End Using
                End If
                Using cmd As New SQLiteCommand("UPDATE Vehicles SET Status='Sold',UpdatedAtUtc=@now WHERE Id=@v AND Status='Available'",cn,tx)
                    cmd.Parameters.AddWithValue("@now",DateTime.UtcNow.ToString("o")):cmd.Parameters.AddWithValue("@v",vehicleId)
                    If cmd.ExecuteNonQuery()<>1 Then Throw New InvalidOperationException("Vehicle availability changed during checkout.")
                End Using
                If quotationId<>0 Then
                    Using cmd As New SQLiteCommand("UPDATE Quotations SET Status='Converted',ConvertedSaleId=@s WHERE Id=@q",cn,tx)
                        cmd.Parameters.AddWithValue("@s",saleId):cmd.Parameters.AddWithValue("@q",quotationId):cmd.ExecuteNonQuery()
                    End Using
                End If
                tx.Commit()
                _audit.Write("Sale finalized","Sale",saleId.ToString(),saleNumber)
                Return saleId
            End Using
        End Function
    End Class
End Namespace
