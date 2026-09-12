Imports System
Imports System.Data
Imports System.Data.SQLite
Imports CarDealershipPOS.Data
Imports CarDealershipPOS.Models

Namespace CarDealershipPOS.Services
    Public NotInheritable Class QuotationService
        Private ReadOnly _settings As New SettingsService()
        Private ReadOnly _audit As New AuditService()
        Public Function Calculate(vehiclePrice As Decimal, discount As Decimal) As Quotation
            If discount<0D Then discount=0D
            If discount>vehiclePrice Then discount=vehiclePrice
            Dim taxable=vehiclePrice-discount
            Dim rate=_settings.GetTaxRate()
            Dim tax=Decimal.Round(taxable*(rate/100D),2,MidpointRounding.AwayFromZero)
            Return New Quotation With {.Subtotal=vehiclePrice,.Discount=discount,.TaxRate=rate,.TaxAmount=tax,.Total=taxable+tax,.Status="Draft"}
        End Function
        Public Function Create(customerId As Long, vehicleId As Long, discount As Decimal, notes As String) As Long
            If Database.Scalar(Of Long)("SELECT COUNT(*) FROM Customers WHERE Id=@id AND IsActive=1",New SQLiteParameter("@id",customerId))=0 Then Throw New InvalidOperationException("Customer is not active or does not exist.")
            Dim v=New InventoryService().GetById(vehicleId)
            If v Is Nothing OrElse v.Status<>"Available" Then Throw New InvalidOperationException("Vehicle is not available for quotation.")
            Dim q=Calculate(v.SellingPrice,discount)
            Dim number="Q-" & DateTime.Now.ToString("yyyyMMddHHmmssfff")
            Using cn=Database.OpenConnection(), tx=cn.BeginTransaction()
                Using cmd As New SQLiteCommand("INSERT INTO Quotations(QuoteNumber,CustomerId,UserId,Status,Subtotal,Discount,TaxRate,TaxAmount,Total,Notes,CreatedAtUtc,ExpiresAtUtc) VALUES(@n,@c,@u,'Draft',@s,@d,@r,@ta,@t,@notes,@now,@exp); SELECT last_insert_rowid();",cn,tx)
                    cmd.Parameters.AddWithValue("@n",number):cmd.Parameters.AddWithValue("@c",customerId):cmd.Parameters.AddWithValue("@u",SessionContext.UserId):cmd.Parameters.AddWithValue("@s",q.Subtotal):cmd.Parameters.AddWithValue("@d",q.Discount):cmd.Parameters.AddWithValue("@r",q.TaxRate):cmd.Parameters.AddWithValue("@ta",q.TaxAmount):cmd.Parameters.AddWithValue("@t",q.Total):cmd.Parameters.AddWithValue("@notes",notes):cmd.Parameters.AddWithValue("@now",DateTime.UtcNow.ToString("o")):cmd.Parameters.AddWithValue("@exp",DateTime.UtcNow.AddDays(7).ToString("o"))
                    Dim id=CLng(cmd.ExecuteScalar())
                    Using itemCmd As New SQLiteCommand("INSERT INTO QuotationItems(QuotationId,VehicleId,UnitPrice) VALUES(@q,@v,@p)",cn,tx)
                        itemCmd.Parameters.AddWithValue("@q",id):itemCmd.Parameters.AddWithValue("@v",vehicleId):itemCmd.Parameters.AddWithValue("@p",v.SellingPrice):itemCmd.ExecuteNonQuery()
                    End Using
                    tx.Commit()
                    _audit.Write("Quotation created","Quotation",id.ToString(),number)
                    Return id
                End Using
            End Using
        End Function

        Public Function GetCheckoutData(quotationId As Long) As DataRow
            Dim t=Database.Query("SELECT q.Id,q.CustomerId,qi.VehicleId,q.Discount,q.Total,q.Status,c.FirstName || ' ' || c.LastName AS Customer,v.Brand || ' ' || v.Model AS Vehicle FROM Quotations q JOIN QuotationItems qi ON qi.QuotationId=q.Id JOIN Customers c ON c.Id=q.CustomerId JOIN Vehicles v ON v.Id=qi.VehicleId WHERE q.Id=@id",New SQLiteParameter("@id",quotationId))
            If t.Rows.Count=0 Then Return Nothing
            Return t.Rows(0)
        End Function

        Public Function ListQuotations() As DataTable
            Return Database.Query("SELECT q.Id,q.QuoteNumber,c.FirstName || ' ' || c.LastName AS Customer,v.Brand || ' ' || v.Model AS Vehicle,q.Total,q.Status,q.CreatedAtUtc AS Created FROM Quotations q JOIN Customers c ON c.Id=q.CustomerId JOIN QuotationItems qi ON qi.QuotationId=q.Id JOIN Vehicles v ON v.Id=qi.VehicleId ORDER BY q.Id DESC")
        End Function
    End Class
End Namespace
