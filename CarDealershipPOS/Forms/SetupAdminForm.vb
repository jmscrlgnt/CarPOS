Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class SetupAdminForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
            lblError.Text = ""
            If txtPassword.Text <> txtConfirm.Text Then lblError.Text="Passwords do not match." : Return
            Dim err=New AuthService().CreateInitialAdministrator(txtUsername.Text,txtPassword.Text)
            If err IsNot Nothing Then lblError.Text=err : Return
            MessageBox.Show("Administrator created. You can now sign in.","Setup",MessageBoxButtons.OK,MessageBoxIcon.Information)
            DialogResult=DialogResult.OK
            Close()
        End Sub
    End Class
End Namespace
