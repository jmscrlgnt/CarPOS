Namespace CarDealershipPOS.Models
    Public NotInheritable Class Sale
        Public Property Id As Long
        Public Property SaleNumber As String
        Public Property CustomerId As Long
        Public Property VehicleId As Long
        Public Property Total As Decimal
        Public Property PaymentPlan As String
        Public Property CreatedAtUtc As DateTime
    End Class
End Namespace
