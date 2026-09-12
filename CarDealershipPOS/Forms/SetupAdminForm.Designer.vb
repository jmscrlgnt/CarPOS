Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SetupAdminForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblHint As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblConfirm As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirm As TextBox
    Friend WithEvents btnCreate As Button
    Friend WithEvents lblError As Label
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.lblHint=New Label()
        Me.lblUsername=New Label()
        Me.lblPassword=New Label()
        Me.lblConfirm=New Label()
        Me.txtUsername=New TextBox()
        Me.txtPassword=New TextBox()
        Me.txtConfirm=New TextBox()
        Me.btnCreate=New Button()
        Me.lblError=New Label()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",22.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(46,38)
        Me.lblTitle.Text="First-run administrator setup"
        Me.lblHint.AutoSize=True
        Me.lblHint.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.lblHint.ForeColor=Drawing.Color.DimGray
        Me.lblHint.Location=New Drawing.Point(50,85)
        Me.lblHint.Text="Create the first administrator. There is no default administrator password."
        Me.lblUsername.AutoSize=True
        Me.lblUsername.Location=New Drawing.Point(50,135)
        Me.lblUsername.Text="Administrator username"
        Me.txtUsername.Location=New Drawing.Point(53,158)
        Me.txtUsername.Size=New Drawing.Size(430,29)
        Me.lblPassword.AutoSize=True
        Me.lblPassword.Location=New Drawing.Point(50,204)
        Me.lblPassword.Text="Password (minimum 8 characters)"
        Me.txtPassword.Location=New Drawing.Point(53,227)
        Me.txtPassword.Size=New Drawing.Size(430,29)
        Me.txtPassword.UseSystemPasswordChar=True
        Me.lblConfirm.AutoSize=True
        Me.lblConfirm.Location=New Drawing.Point(50,273)
        Me.lblConfirm.Text="Confirm password"
        Me.txtConfirm.Location=New Drawing.Point(53,296)
        Me.txtConfirm.Size=New Drawing.Size(430,29)
        Me.txtConfirm.UseSystemPasswordChar=True
        Me.lblError.AutoSize=True
        Me.lblError.ForeColor=Drawing.Color.Firebrick
        Me.lblError.Location=New Drawing.Point(50,340)
        Me.lblError.Text=""
        Me.btnCreate.Location=New Drawing.Point(53,378)
        Me.btnCreate.Size=New Drawing.Size(430,44)
        Me.btnCreate.Text="Create Administrator"
        Me.btnCreate.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnCreate.ForeColor=Drawing.Color.White
        Me.btnCreate.FlatStyle=FlatStyle.Flat
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.ClientSize=New Drawing.Size(540,470)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblHint)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblConfirm)
        Me.Controls.Add(Me.txtConfirm)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.btnCreate)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.StartPosition=FormStartPosition.CenterScreen
        Me.Text="Car Dealership POS - Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
