Namespace CarDealershipPOS.Models
    Public NotInheritable Class Vehicle
        Public Property Id As Long
        Public Property StockNumber As String
        Public Property Vin As String
        Public Property Brand As String
        Public Property Model As String
        Public Property TrimLevel As String
        Public Property ModelYear As Integer
        Public Property Color As String
        Public Property Condition As String
        Public Property MileageKm As Integer
        Public Property CostPrice As Decimal
        Public Property SellingPrice As Decimal
        Public Property Status As String
        Public Property ImagePath As String
        Public Property Notes As String
        Public ReadOnly Property DisplayName As String
            Get
                Return String.Format("{0} {1} {2} ({3})", ModelYear, Brand, Model, StockNumber)
            End Get
        End Property
    End Class
End Namespace
