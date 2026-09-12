Imports System
Imports System.Data.SQLite
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports CarDealershipPOS.Data
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class ReceiptForm
        Private _saleId As Long
        Public Sub New()
            InitializeComponent()
        End Sub
        Public Sub New(saleId As Long)
            InitializeComponent():_saleId=saleId
        End Sub
        Private Sub ReceiptForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            If _saleId=0 Then Return
            txtReceipt.Text=BuildReceipt()
        End Sub
        Private Function BuildReceipt() As String
            Dim t=Database.Query("SELECT s.SaleNumber,s.CreatedAtUtc,s.Subtotal,s.Discount,s.TaxRate,s.TaxAmount,s.Total,s.PaymentPlan,c.CustomerNumber,c.FirstName || ' ' || c.LastName AS Customer,c.ContactNumber,v.StockNumber,v.Brand || ' ' || v.Model || ' ' || COALESCE(v.Variant,'') AS Vehicle,u.Username AS Staff,COALESCE((SELECT SUM(Amount) FROM Payments WHERE SaleId=s.Id),0) AS Paid FROM Sales s JOIN Customers c ON c.Id=s.CustomerId JOIN Users u ON u.Id=s.UserId JOIN SaleItems si ON si.SaleId=s.Id JOIN Vehicles v ON v.Id=si.VehicleId WHERE s.Id=@id",New SQLiteParameter("@id",_saleId))
            If t.Rows.Count=0 Then Return "Sale not found."
            Dim r=t.Rows(0):Dim settings As New SettingsService()
            Dim paid=CDec(r("Paid")):Dim total=CDec(r("Total"))
            Dim sb As New Text.StringBuilder()
            sb.AppendLine(settings.GetValue("DealershipName","AutoDrive Dealership")):sb.AppendLine(settings.GetValue("Address","")):sb.AppendLine(settings.GetValue("ContactNumber","")):sb.AppendLine(New String("-"c,52))
            sb.AppendLine("OFFICIAL SALES RECEIPT"):sb.AppendLine("Sale No.: " & CStr(r("SaleNumber"))):sb.AppendLine("Date: " & CStr(r("CreatedAtUtc"))):sb.AppendLine("Staff: " & CStr(r("Staff"))):sb.AppendLine(New String("-"c,52))
            sb.AppendLine("Customer: " & CStr(r("Customer")) & " (" & CStr(r("CustomerNumber")) & ")"):sb.AppendLine("Vehicle: " & CStr(r("Vehicle"))):sb.AppendLine("Stock No.: " & CStr(r("StockNumber"))):sb.AppendLine(New String("-"c,52))
            sb.AppendLine("Subtotal:       ₱ " & CDec(r("Subtotal")).ToString("N2")):sb.AppendLine("Discount:       ₱ " & CDec(r("Discount")).ToString("N2")):sb.AppendLine("Tax " & CDec(r("TaxRate")).ToString("0.##") & "%:          ₱ " & CDec(r("TaxAmount")).ToString("N2")):sb.AppendLine("TOTAL:          ₱ " & total.ToString("N2")):sb.AppendLine("Paid:           ₱ " & paid.ToString("N2")):sb.AppendLine("Balance:        ₱ " & Math.Max(0D,total-paid).ToString("N2")):sb.AppendLine("Payment Plan: " & CStr(r("PaymentPlan"))):sb.AppendLine(New String("-"c,52)):sb.AppendLine(settings.GetValue("ReceiptFooter","Thank you for choosing us."))
            Return sb.ToString()
        End Function
        Private Sub btnCopy_Click(sender As Object,e As EventArgs) Handles btnCopy.Click
            Clipboard.SetText(txtReceipt.Text):MessageBox.Show("Receipt copied to clipboard.")
        End Sub
        Private Sub btnPrint_Click(sender As Object,e As EventArgs) Handles btnPrint.Click
            Dim doc As New PrintDocument()
            AddHandler doc.PrintPage, Sub(s,args) args.Graphics.DrawString(txtReceipt.Text,New Drawing.Font("Consolas",10.0!),Drawing.Brushes.Black,40,40)
            Using dialog As New PrintDialog() With {.Document=doc}
                If dialog.ShowDialog()=DialogResult.OK Then doc.Print()
            End Using
        End Sub
    End Class
End Namespace
