Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserEditorForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblConfirm As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents cbRole As ComboBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirm As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.lblUsername=New Label()
        Me.lblRole=New Label()
        Me.lblPassword=New Label()
        Me.lblConfirm=New Label()
        Me.txtUsername=New TextBox()
        Me.cbRole=New ComboBox()
        Me.txtPassword=New TextBox()
        Me.txtConfirm=New TextBox()
        Me.btnSave=New Button()
        Me.btnCancel=New Button()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",20.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(30,24)
        Me.lblTitle.Text="Create User"
        Me.lblUsername.AutoSize=True
        Me.lblUsername.Location=New Drawing.Point(35,90)
        Me.lblUsername.Text="Username"
        Me.txtUsername.Location=New Drawing.Point(35,115)
        Me.txtUsername.Size=New Drawing.Size(360,29)
        Me.lblRole.AutoSize=True
        Me.lblRole.Location=New Drawing.Point(35,165)
        Me.lblRole.Text="Role"
        Me.cbRole.Location=New Drawing.Point(35,190)
        Me.cbRole.Size=New Drawing.Size(360,30)
        Me.cbRole.DropDownStyle=ComboBoxStyle.DropDownList
        Me.lblPassword.AutoSize=True
        Me.lblPassword.Location=New Drawing.Point(35,240)
        Me.lblPassword.Text="Password (minimum 8 characters)"
        Me.txtPassword.Location=New Drawing.Point(35,265)
        Me.txtPassword.Size=New Drawing.Size(360,29)
        Me.txtPassword.UseSystemPasswordChar=True
        Me.lblConfirm.AutoSize=True
        Me.lblConfirm.Location=New Drawing.Point(35,315)
        Me.lblConfirm.Text="Confirm Password"
        Me.txtConfirm.Location=New Drawing.Point(35,340)
        Me.txtConfirm.Size=New Drawing.Size(360,29)
        Me.txtConfirm.UseSystemPasswordChar=True
        Me.btnCancel.Location=New Drawing.Point(175,400)
        Me.btnCancel.Size=New Drawing.Size(100,38)
        Me.btnCancel.Text="Cancel"
        Me.btnSave.Location=New Drawing.Point(285,400)
        Me.btnSave.Size=New Drawing.Size(110,38)
        Me.btnSave.Text="Save"
        Me.btnSave.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnSave.ForeColor=Drawing.Color.White
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.ClientSize=New Drawing.Size(435,480)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblRole)
        Me.Controls.Add(Me.cbRole)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblConfirm)
        Me.Controls.Add(Me.txtConfirm)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.StartPosition=FormStartPosition.CenterParent
        Me.FormBorderStyle=FormBorderStyle.FixedDialog
        Me.MaximizeBox=False
        Me.Text="User"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
