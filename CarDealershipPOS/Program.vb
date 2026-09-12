Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Data
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Friend Module Program
        <STAThread>
        Public Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Database.Initialize()

            Dim auth As New AuthService()
            If Not auth.HasAdministrator() Then
                Using setup As New SetupAdminForm()
                    If setup.ShowDialog() <> DialogResult.OK Then Return
                End Using
            End If

            Application.Run(New LoginForm())
        End Sub
    End Module
End Namespace
