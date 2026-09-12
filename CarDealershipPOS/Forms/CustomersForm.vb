Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class CustomersForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub CustomersForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            UiTheme.StyleGrid(gridCustomers):RefreshGrid()
        End Sub
        Private Sub RefreshGrid()
            gridCustomers.DataSource=New CustomerService().Search(txtSearch.Text,chkInactive.Checked)
        End Sub
        Private Function SelectedId() As Long
            If gridCustomers.CurrentRow Is Nothing Then Return 0
            Return CLng(gridCustomers.CurrentRow.Cells("Id").Value)
        End Function
        Private Sub btnSearch_Click(sender As Object,e As EventArgs) Handles btnSearch.Click
            RefreshGrid()
        End Sub
        Private Sub chkInactive_CheckedChanged(sender As Object,e As EventArgs) Handles chkInactive.CheckedChanged
            RefreshGrid()
        End Sub
        Private Sub btnAdd_Click(sender As Object,e As EventArgs) Handles btnAdd.Click
            Using f As New CustomerEditorForm()
                If f.ShowDialog()=DialogResult.OK Then RefreshGrid()
            End Using
        End Sub
        Private Sub btnEdit_Click(sender As Object,e As EventArgs) Handles btnEdit.Click
            Dim id=SelectedId():If id=0 Then MessageBox.Show("Select a customer first."):Return
            Using f As New CustomerEditorForm(id)
                If f.ShowDialog()=DialogResult.OK Then RefreshGrid()
            End Using
        End Sub
        Private Sub btnDeactivate_Click(sender As Object,e As EventArgs) Handles btnDeactivate.Click
            Dim id=SelectedId():If id=0 Then MessageBox.Show("Select a customer first."):Return
            If MessageBox.Show("Deactivate this customer? Existing sales history will be preserved.","Customers",MessageBoxButtons.YesNo)<>DialogResult.Yes Then Return
            Dim customerService As New CustomerService()
            customerService.Deactivate(id)
            RefreshGrid()
        End Sub
    End Class
End Namespace
