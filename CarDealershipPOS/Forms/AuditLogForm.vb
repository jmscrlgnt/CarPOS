Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class AuditLogForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub AuditLogForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            UiTheme.StyleGrid(gridAudit):RefreshGrid()
        End Sub
        Private Sub RefreshGrid()
            gridAudit.DataSource=New AuditService().ListRecent(500)
        End Sub
        Private Sub btnRefresh_Click(sender As Object,e As EventArgs) Handles btnRefresh.Click
            RefreshGrid()
        End Sub
    End Class
End Namespace
