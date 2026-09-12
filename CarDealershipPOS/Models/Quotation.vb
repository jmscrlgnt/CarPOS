Namespace CarDealershipPOS.Models
    Public NotInheritable Class Quotation
        Public Property Id As Long
        Public Property QuoteNumber As String
        Public Property CustomerId As Long
        Public Property VehicleId As Long
        Public Property Subtotal As Decimal
        Public Property Discount As Decimal
        Public Property TaxRate As Decimal
        Public Property TaxAmount As Decimal
        Public Property Total As Decimal
        Public Property Status As String
    End Class
End Namespace
