Imports System
Imports System.Data
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class DashboardForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub DashboardForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            UiTheme.StyleGrid(gridRecent)
            RefreshDashboard()
        End Sub
        Private Sub RefreshDashboard()
            Dim report As New ReportService()
            Dim metrics=report.DashboardMetrics()
            Dim values As New Dictionary(Of String,String)(StringComparer.OrdinalIgnoreCase)
            For Each row As DataRow In metrics.Rows : values(CStr(row("Metric")))=CStr(row("Value")) : Next
            lblAvailable.Text=values("Available Inventory")
            lblNew.Text=values("New Vehicles")
            lblUsed.Text=values("Used Vehicles")
            lblToday.Text=values("Sales Today")
            lblMonth.Text="₱ " & values("Sales This Month")
            lblReceivables.Text="₱ " & values("Receivables")
            gridRecent.DataSource=report.RecentSales()
            lblDate.Text=DateTime.Now.ToString("dddd, MMMM d, yyyy")
        End Sub
    End Class
End Namespace
