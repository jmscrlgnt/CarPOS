Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class UserManagementForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub UserManagementForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            UiTheme.StyleGrid(gridUsers):RefreshGrid()
        End Sub
        Private Sub RefreshGrid()
            gridUsers.DataSource=New AuthService().ListUsers()
        End Sub
        Private Function SelectedId() As Long
            If gridUsers.CurrentRow Is Nothing Then Return 0
            Return CLng(gridUsers.CurrentRow.Cells("Id").Value)
        End Function
        Private Sub btnAdd_Click(sender As Object,e As EventArgs) Handles btnAdd.Click
            Using f As New UserEditorForm()
                If f.ShowDialog()=DialogResult.OK Then RefreshGrid()
            End Using
        End Sub
        Private Sub btnReset_Click(sender As Object,e As EventArgs) Handles btnReset.Click
            Dim id=SelectedId():If id=0 Then MessageBox.Show("Select a user first."):Return
            Dim username=CStr(gridUsers.CurrentRow.Cells("Username").Value)
            Using f As New UserEditorForm(id,username)
                If f.ShowDialog()=DialogResult.OK Then RefreshGrid()
            End Using
        End Sub
        Private Sub btnToggle_Click(sender As Object,e As EventArgs) Handles btnToggle.Click
            Dim id=SelectedId():If id=0 Then MessageBox.Show("Select a user first."):Return
            Dim current=CStr(gridUsers.CurrentRow.Cells("Status").Value)
            Try
                Dim authService As New AuthService()
                authService.SetUserActive(id, current <> "Active")
                RefreshGrid()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
