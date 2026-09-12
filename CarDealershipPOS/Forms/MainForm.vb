Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class MainForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub MainForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            lblUser.Text=SessionContext.Username & Environment.NewLine & SessionContext.Role
            Dim name=New SettingsService().GetValue("DealershipName","AutoDrive Dealership")
            lblBrand.Text=name.ToUpperInvariant()
            ShowChild(New DashboardForm(),btnDashboard)
        End Sub
        Private Sub ShowChild(form As Form, activeButton As Button)
            For Each b As Button In New Button(){btnDashboard,btnInventory,btnCustomers,btnPos,btnQuotes,btnSales,btnPayments,btnSettings}
                b.BackColor=UiTheme.Navy
            Next
            activeButton.BackColor=Drawing.Color.FromArgb(29,79,112)
            While pnlContent.Controls.Count>0
                pnlContent.Controls(0).Dispose()
            End While
            form.TopLevel=False:form.FormBorderStyle=FormBorderStyle.None:form.Dock=DockStyle.Fill
            pnlContent.Controls.Add(form):form.Show()
        End Sub
        Private Sub btnDashboard_Click(sender As Object,e As EventArgs) Handles btnDashboard.Click
            ShowChild(New DashboardForm(),btnDashboard)
        End Sub
        Private Sub btnInventory_Click(sender As Object,e As EventArgs) Handles btnInventory.Click
            ShowChild(New InventoryForm(),btnInventory)
        End Sub
        Private Sub btnCustomers_Click(sender As Object,e As EventArgs) Handles btnCustomers.Click
            ShowChild(New CustomersForm(),btnCustomers)
        End Sub
        Private Sub btnPos_Click(sender As Object,e As EventArgs) Handles btnPos.Click
            ShowChild(New PosForm(),btnPos)
        End Sub
        Private Sub btnQuotes_Click(sender As Object,e As EventArgs) Handles btnQuotes.Click
            ShowChild(New QuotationsForm(),btnQuotes)
        End Sub
        Private Sub btnSales_Click(sender As Object,e As EventArgs) Handles btnSales.Click
            ShowChild(New SalesForm(),btnSales)
        End Sub
        Private Sub btnPayments_Click(sender As Object,e As EventArgs) Handles btnPayments.Click
            ShowChild(New PaymentsForm(),btnPayments)
        End Sub
        Private Sub btnSettings_Click(sender As Object,e As EventArgs) Handles btnSettings.Click
            ShowChild(New SettingsForm(),btnSettings)
        End Sub
        Private Sub btnLogout_Click(sender As Object,e As EventArgs) Handles btnLogout.Click
            If MessageBox.Show("Log out of the dealership system?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question)=DialogResult.Yes Then
                Dim authService As New AuthService()
                authService.Logout()
                Close()
            End If
        End Sub
    End Class
End Namespace
