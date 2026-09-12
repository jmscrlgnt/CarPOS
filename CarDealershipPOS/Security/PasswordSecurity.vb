Imports System
Imports System.Security.Cryptography

Namespace CarDealershipPOS.Security
    Public NotInheritable Class PasswordSecurity
        Private Const SaltSize As Integer = 16
        Private Const HashSize As Integer = 32
        Private Const Iterations As Integer = 120000

        Private Sub New()
        End Sub

        Public Shared Sub HashPassword(password As String, ByRef hash As String, ByRef salt As String)
            If String.IsNullOrWhiteSpace(password) Then Throw New ArgumentException("Password is required.")
            Dim saltBytes(SaltSize - 1) As Byte
            Using rng = RandomNumberGenerator.Create()
                rng.GetBytes(saltBytes)
            End Using
            Using derive As New Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256)
                salt = Convert.ToBase64String(saltBytes)
                hash = Convert.ToBase64String(derive.GetBytes(HashSize))
            End Using
        End Sub

        Public Shared Function VerifyPassword(password As String, expectedHash As String, salt As String) As Boolean
            If String.IsNullOrEmpty(expectedHash) OrElse String.IsNullOrEmpty(salt) Then Return False
            Dim saltBytes = Convert.FromBase64String(salt)
            Dim expected = Convert.FromBase64String(expectedHash)
            Using derive As New Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256)
                Dim actual = derive.GetBytes(expected.Length)
                Dim diff As Integer = 0
                For i = 0 To expected.Length - 1
                    diff = diff Or (expected(i) Xor actual(i))
                Next
                Return diff = 0
            End Using
        End Function
    End Class
End Namespace
