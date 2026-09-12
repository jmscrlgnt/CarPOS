Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class LoginForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
            lblError.Text=""
            If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrEmpty(txtPassword.Text) Then lblError.Text="Enter your username and password." : Return
            Dim user=New AuthService().Login(txtUsername.Text,txtPassword.Text)
            If user Is Nothing Then lblError.Text="Invalid username or password." : Return
            txtPassword.Clear()
            Hide()
            Using main As New MainForm()
                main.ShowDialog()
            End Using
            Show()
            txtUsername.Clear()
            txtUsername.Focus()
        End Sub
        Private Sub chkShow_CheckedChanged(sender As Object,e As EventArgs) Handles chkShow.CheckedChanged
            txtPassword.UseSystemPasswordChar=Not chkShow.Checked
        End Sub
    End Class
End Namespace
