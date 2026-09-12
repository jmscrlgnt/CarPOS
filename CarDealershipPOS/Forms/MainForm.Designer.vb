Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnInventory As Button
    Friend WithEvents btnCustomers As Button
    Friend WithEvents btnPos As Button
    Friend WithEvents btnQuotes As Button
    Friend WithEvents btnSales As Button
    Friend WithEvents btnPayments As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents lblUser As Label
    Friend WithEvents lblBrand As Label
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.pnlSidebar=New Panel()
        Me.pnlContent=New Panel()
        Me.lblUser=New Label()
        Me.lblBrand=New Label()
        Me.btnDashboard=New Button()
        Me.btnInventory=New Button()
        Me.btnCustomers=New Button()
        Me.btnPos=New Button()
        Me.btnQuotes=New Button()
        Me.btnSales=New Button()
        Me.btnPayments=New Button()
        Me.btnSettings=New Button()
        Me.btnLogout=New Button()
        Me.pnlSidebar.SuspendLayout()
        Me.SuspendLayout()
        Me.pnlSidebar.Dock=DockStyle.Left
        Me.pnlSidebar.Width=225
        Me.pnlSidebar.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.lblBrand.Location=New Drawing.Point(20,28)
        Me.lblBrand.Size=New Drawing.Size(185,70)
        Me.lblBrand.ForeColor=Drawing.Color.White
        Me.lblBrand.Font=New Drawing.Font("Segoe UI",15.0!,Drawing.FontStyle.Bold)
        Me.lblBrand.Text="AUTODRIVE"
        Me.btnDashboard.Location=New Drawing.Point(12,115)
        Me.btnDashboard.Size=New Drawing.Size(201,44)
        Me.btnDashboard.Text="Dashboard"
        Me.btnInventory.Location=New Drawing.Point(12,167)
        Me.btnInventory.Size=New Drawing.Size(201,44)
        Me.btnInventory.Text="Inventory"
        Me.btnCustomers.Location=New Drawing.Point(12,219)
        Me.btnCustomers.Size=New Drawing.Size(201,44)
        Me.btnCustomers.Text="Customers"
        Me.btnPos.Location=New Drawing.Point(12,271)
        Me.btnPos.Size=New Drawing.Size(201,44)
        Me.btnPos.Text="Point of Sale"
        Me.btnQuotes.Location=New Drawing.Point(12,323)
        Me.btnQuotes.Size=New Drawing.Size(201,44)
        Me.btnQuotes.Text="Quotations"
        Me.btnSales.Location=New Drawing.Point(12,375)
        Me.btnSales.Size=New Drawing.Size(201,44)
        Me.btnSales.Text="Sales History"
        Me.btnPayments.Location=New Drawing.Point(12,427)
        Me.btnPayments.Size=New Drawing.Size(201,44)
        Me.btnPayments.Text="Payments"
        Me.btnSettings.Location=New Drawing.Point(12,479)
        Me.btnSettings.Size=New Drawing.Size(201,44)
        Me.btnSettings.Text="Settings"
        Me.btnDashboard.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.btnInventory.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.btnCustomers.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.btnPos.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.btnQuotes.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.btnSales.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.btnPayments.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.btnSettings.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.btnDashboard.ForeColor=Drawing.Color.White
        Me.btnInventory.ForeColor=Drawing.Color.White
        Me.btnCustomers.ForeColor=Drawing.Color.White
        Me.btnPos.ForeColor=Drawing.Color.White
        Me.btnQuotes.ForeColor=Drawing.Color.White
        Me.btnSales.ForeColor=Drawing.Color.White
        Me.btnPayments.ForeColor=Drawing.Color.White
        Me.btnSettings.ForeColor=Drawing.Color.White
        Me.btnDashboard.FlatStyle=FlatStyle.Flat
        Me.btnInventory.FlatStyle=FlatStyle.Flat
        Me.btnCustomers.FlatStyle=FlatStyle.Flat
        Me.btnPos.FlatStyle=FlatStyle.Flat
        Me.btnQuotes.FlatStyle=FlatStyle.Flat
        Me.btnSales.FlatStyle=FlatStyle.Flat
        Me.btnPayments.FlatStyle=FlatStyle.Flat
        Me.btnSettings.FlatStyle=FlatStyle.Flat
        Me.btnDashboard.FlatAppearance.BorderSize=0
        Me.btnInventory.FlatAppearance.BorderSize=0
        Me.btnCustomers.FlatAppearance.BorderSize=0
        Me.btnPos.FlatAppearance.BorderSize=0
        Me.btnQuotes.FlatAppearance.BorderSize=0
        Me.btnSales.FlatAppearance.BorderSize=0
        Me.btnPayments.FlatAppearance.BorderSize=0
        Me.btnSettings.FlatAppearance.BorderSize=0
        Me.btnDashboard.TextAlign=ContentAlignment.MiddleLeft
        Me.btnInventory.TextAlign=ContentAlignment.MiddleLeft
        Me.btnCustomers.TextAlign=ContentAlignment.MiddleLeft
        Me.btnPos.TextAlign=ContentAlignment.MiddleLeft
        Me.btnQuotes.TextAlign=ContentAlignment.MiddleLeft
        Me.btnSales.TextAlign=ContentAlignment.MiddleLeft
        Me.btnPayments.TextAlign=ContentAlignment.MiddleLeft
        Me.btnSettings.TextAlign=ContentAlignment.MiddleLeft
        Me.btnDashboard.Padding=New Padding(14,0,0,0)
        Me.btnInventory.Padding=New Padding(14,0,0,0)
        Me.btnCustomers.Padding=New Padding(14,0,0,0)
        Me.btnPos.Padding=New Padding(14,0,0,0)
        Me.btnQuotes.Padding=New Padding(14,0,0,0)
        Me.btnSales.Padding=New Padding(14,0,0,0)
        Me.btnPayments.Padding=New Padding(14,0,0,0)
        Me.btnSettings.Padding=New Padding(14,0,0,0)
        Me.lblUser.Anchor=AnchorStyles.Left Or AnchorStyles.Bottom
        Me.lblUser.Location=New Drawing.Point(20,650)
        Me.lblUser.Size=New Drawing.Size(185,55)
        Me.lblUser.ForeColor=Drawing.Color.White
        Me.lblUser.Font=New Drawing.Font("Segoe UI",9.5!,Drawing.FontStyle.Bold)
        Me.btnLogout.Anchor=AnchorStyles.Left Or AnchorStyles.Bottom
        Me.btnLogout.Location=New Drawing.Point(15,710)
        Me.btnLogout.Size=New Drawing.Size(195,42)
        Me.btnLogout.Text="Logout"
        Me.btnLogout.ForeColor=Drawing.Color.White
        Me.btnLogout.BackColor=Drawing.Color.FromArgb(33,63,86)
        Me.btnLogout.FlatStyle=FlatStyle.Flat
        Me.btnLogout.FlatAppearance.BorderSize=0
        Me.pnlSidebar.Controls.Add(Me.lblBrand)
        Me.pnlSidebar.Controls.Add(Me.btnDashboard)
        Me.pnlSidebar.Controls.Add(Me.btnInventory)
        Me.pnlSidebar.Controls.Add(Me.btnCustomers)
        Me.pnlSidebar.Controls.Add(Me.btnPos)
        Me.pnlSidebar.Controls.Add(Me.btnQuotes)
        Me.pnlSidebar.Controls.Add(Me.btnSales)
        Me.pnlSidebar.Controls.Add(Me.btnPayments)
        Me.pnlSidebar.Controls.Add(Me.btnSettings)
        Me.pnlSidebar.Controls.Add(Me.lblUser)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlContent.Dock=DockStyle.Fill
        Me.pnlContent.BackColor=Drawing.Color.FromArgb(244,247,250)
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.ClientSize=New Drawing.Size(1400,800)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.MinimumSize=New Drawing.Size(1200,720)
        Me.StartPosition=FormStartPosition.CenterScreen
        Me.Text="AutoDrive - Car Dealership POS"
        Me.pnlSidebar.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
End Class
End Namespace
