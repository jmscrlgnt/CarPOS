Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class UserEditorForm
        Private _userId As Long
        Private _username As String
        Public Sub New()
            InitializeComponent()
        End Sub
        Public Sub New(userId As Long, username As String)
            InitializeComponent():_userId=userId:_username=username
        End Sub
        Private Sub UserEditorForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            cbRole.Items.Clear():cbRole.Items.AddRange(New Object(){"Sales Staff","Administrator"}):cbRole.SelectedIndex=0
            If _userId<>0 Then txtUsername.Text=_username:txtUsername.Enabled=False:cbRole.Enabled=False:lblTitle.Text="Reset User Password":btnSave.Text="Reset Password"
        End Sub
        Private Sub btnSave_Click(sender As Object,e As EventArgs) Handles btnSave.Click
            If txtPassword.Text<>txtConfirm.Text Then MessageBox.Show("Passwords do not match."):Return
            Dim auth As New AuthService():Dim err As String
            If _userId=0 Then err=auth.CreateStaff(txtUsername.Text,txtPassword.Text,CStr(cbRole.SelectedItem)) Else err=auth.ResetPassword(_userId,txtPassword.Text)
            If err IsNot Nothing Then MessageBox.Show(err,"User",MessageBoxButtons.OK,MessageBoxIcon.Warning):Return
            DialogResult=DialogResult.OK:Close()
        End Sub
        Private Sub btnCancel_Click(sender As Object,e As EventArgs) Handles btnCancel.Click
            DialogResult=DialogResult.Cancel:Close()
        End Sub
    End Class
End Namespace
