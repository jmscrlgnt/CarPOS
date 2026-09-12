Namespace CarDealershipPOS.Models
    Public NotInheritable Class Payment
        Public Property Id As Long
        Public Property SaleId As Long
        Public Property Amount As Decimal
        Public Property Method As String
        Public Property ReferenceNumber As String
        Public Property PaidAtUtc As DateTime
    End Class
End Namespace
