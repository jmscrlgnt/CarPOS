Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Models
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class CustomerEditorForm
        Private _id As Long
        Public Sub New()
            InitializeComponent()
        End Sub
        Public Sub New(id As Long)
            InitializeComponent():_id=id
        End Sub
        Private Sub CustomerEditorForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            If _id=0 Then
                txtNumber.Text="CUS-" & DateTime.Now.ToString("yyyyMMddHHmmss")
                Return
            End If
            Dim c=New CustomerService().GetById(_id):If c Is Nothing Then Return
            txtNumber.Text=c.CustomerNumber:txtFirst.Text=c.FirstName:txtLast.Text=c.LastName:txtEmail.Text=c.Email:txtContact.Text=c.ContactNumber:txtAddress.Text=c.Address
        End Sub
        Private Sub btnSave_Click(sender As Object,e As EventArgs) Handles btnSave.Click
            Dim c As New Customer With {.Id=_id,.CustomerNumber=txtNumber.Text,.FirstName=txtFirst.Text,.LastName=txtLast.Text,.Email=txtEmail.Text,.ContactNumber=txtContact.Text,.Address=txtAddress.Text}
            Dim err=New CustomerService().Save(c)
            If err IsNot Nothing Then MessageBox.Show(err,"Customer",MessageBoxButtons.OK,MessageBoxIcon.Warning):Return
            DialogResult=DialogResult.OK:Close()
        End Sub
        Private Sub btnCancel_Click(sender As Object,e As EventArgs) Handles btnCancel.Click
            DialogResult=DialogResult.Cancel:Close()
        End Sub
    End Class
End Namespace
