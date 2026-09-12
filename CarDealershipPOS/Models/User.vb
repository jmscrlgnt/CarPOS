Namespace CarDealershipPOS.Models
    Public NotInheritable Class User
        Public Property Id As Long
        Public Property Username As String
        Public Property PasswordHash As String
        Public Property PasswordSalt As String
        Public Property Role As String
        Public Property IsActive As Boolean
    End Class
End Namespace
