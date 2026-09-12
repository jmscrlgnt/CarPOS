Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnlBrand As Panel
    Friend WithEvents lblApp As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents chkShow As CheckBox
    Friend WithEvents lblError As Label
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.pnlBrand=New Panel()
        Me.lblApp=New Label()
        Me.lblDescription=New Label()
        Me.lblTitle=New Label()
        Me.lblSubtitle=New Label()
        Me.lblUsername=New Label()
        Me.lblPassword=New Label()
        Me.txtUsername=New TextBox()
        Me.txtPassword=New TextBox()
        Me.btnLogin=New Button()
        Me.chkShow=New CheckBox()
        Me.lblError=New Label()
        Me.pnlBrand.SuspendLayout()
        Me.SuspendLayout()
        Me.pnlBrand.BackColor=Drawing.Color.FromArgb(15,39,59)
        Me.pnlBrand.Dock=DockStyle.Left
        Me.pnlBrand.Width=420
        Me.lblApp.AutoSize=True
        Me.lblApp.Font=New Drawing.Font("Segoe UI",28.0!,Drawing.FontStyle.Bold)
        Me.lblApp.ForeColor=Drawing.Color.White
        Me.lblApp.Location=New Drawing.Point(48,170)
        Me.lblApp.Text="AUTODRIVE"
        Me.lblDescription.Font=New Drawing.Font("Segoe UI",11.0!)
        Me.lblDescription.ForeColor=Drawing.Color.FromArgb(200,220,235)
        Me.lblDescription.Location=New Drawing.Point(52,232)
        Me.lblDescription.Size=New Drawing.Size(310,120)
        Me.lblDescription.Text="Car Dealership POS & Inventory Management" & Environment.NewLine & Environment.NewLine & "Secure sales, stock, customer, quotation, and payment workflows."
        Me.pnlBrand.Controls.Add(Me.lblApp)
        Me.pnlBrand.Controls.Add(Me.lblDescription)
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",24.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(495,105)
        Me.lblTitle.Text="Welcome back"
        Me.lblSubtitle.AutoSize=True
        Me.lblSubtitle.ForeColor=Drawing.Color.DimGray
        Me.lblSubtitle.Location=New Drawing.Point(500,155)
        Me.lblSubtitle.Text="Sign in with your administrator or sales staff account."
        Me.lblUsername.AutoSize=True
        Me.lblUsername.Location=New Drawing.Point(500,220)
        Me.lblUsername.Text="Username"
        Me.txtUsername.Location=New Drawing.Point(503,245)
        Me.txtUsername.Size=New Drawing.Size(360,30)
        Me.lblPassword.AutoSize=True
        Me.lblPassword.Location=New Drawing.Point(500,295)
        Me.lblPassword.Text="Password"
        Me.txtPassword.Location=New Drawing.Point(503,320)
        Me.txtPassword.Size=New Drawing.Size(360,30)
        Me.txtPassword.UseSystemPasswordChar=True
        Me.chkShow.AutoSize=True
        Me.chkShow.Location=New Drawing.Point(503,363)
        Me.chkShow.Text="Show password"
        Me.lblError.AutoSize=True
        Me.lblError.ForeColor=Drawing.Color.Firebrick
        Me.lblError.Location=New Drawing.Point(500,400)
        Me.btnLogin.Location=New Drawing.Point(503,435)
        Me.btnLogin.Size=New Drawing.Size(360,45)
        Me.btnLogin.Text="Sign In"
        Me.btnLogin.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnLogin.ForeColor=Drawing.Color.White
        Me.btnLogin.FlatStyle=FlatStyle.Flat
        Me.AcceptButton=Me.btnLogin
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.ClientSize=New Drawing.Size(930,590)
        Me.Controls.Add(Me.pnlBrand)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblSubtitle)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.chkShow)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.btnLogin)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.MinimumSize=New Drawing.Size(900,570)
        Me.StartPosition=FormStartPosition.CenterScreen
        Me.Text="AutoDrive Dealership - Sign In"
        Me.pnlBrand.ResumeLayout(False)
        Me.pnlBrand.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
