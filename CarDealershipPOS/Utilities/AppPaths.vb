Imports System
Imports System.IO

Namespace CarDealershipPOS.Utilities
    Public NotInheritable Class AppPaths
        Private Sub New()
        End Sub

        Public Shared ReadOnly Property Root As String
            Get
                Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CarDealershipPOS")
            End Get
        End Property

        Public Shared ReadOnly Property DataDirectory As String
            Get
                Return Path.Combine(Root, "Data")
            End Get
        End Property

        Public Shared ReadOnly Property DatabasePath As String
            Get
                Return Path.Combine(DataDirectory, "dealership.db")
            End Get
        End Property

        Public Shared ReadOnly Property BackupDirectory As String
            Get
                Return Path.Combine(Root, "Backups")
            End Get
        End Property

        Public Shared ReadOnly Property VehicleImageDirectory As String
            Get
                Return Path.Combine(Root, "VehicleImages")
            End Get
        End Property

        Public Shared Sub EnsureDirectories()
            Directory.CreateDirectory(DataDirectory)
            Directory.CreateDirectory(BackupDirectory)
            Directory.CreateDirectory(VehicleImageDirectory)
        End Sub
    End Class
End Namespace
