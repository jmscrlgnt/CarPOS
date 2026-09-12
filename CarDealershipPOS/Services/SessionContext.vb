Namespace CarDealershipPOS.Services
    Public NotInheritable Class SessionContext
        Private Sub New()
        End Sub
        Public Shared Property UserId As Long
        Public Shared Property Username As String
        Public Shared Property Role As String
        Public Shared ReadOnly Property IsAdministrator As Boolean
            Get
                Return String.Equals(Role, "Administrator", StringComparison.OrdinalIgnoreCase)
            End Get
        End Property
        Public Shared Sub Clear()
            UserId = 0 : Username = Nothing : Role = Nothing
        End Sub
    End Class
End Namespace
