Namespace CarDealershipPOS.Models
    Public NotInheritable Class Customer
        Public Property Id As Long
        Public Property CustomerNumber As String
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Email As String
        Public Property ContactNumber As String
        Public Property Address As String
        Public Property IsActive As Boolean
        Public ReadOnly Property DisplayName As String
            Get
                Return (FirstName & " " & LastName).Trim()
            End Get
        End Property
    End Class
End Namespace
