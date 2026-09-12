Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblContact As Label
    Friend WithEvents lblTax As Label
    Friend WithEvents lblFooter As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtFooter As TextBox
    Friend WithEvents numTax As NumericUpDown
    Friend WithEvents btnSave As Button
    Friend WithEvents grpAdmin As GroupBox
    Friend WithEvents btnUsers As Button
    Friend WithEvents btnAudit As Button
    Friend WithEvents btnBackup As Button
    Friend WithEvents btnRestore As Button
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.lblRole=New Label()
        Me.lblName=New Label()
        Me.lblAddress=New Label()
        Me.lblContact=New Label()
        Me.lblTax=New Label()
        Me.lblFooter=New Label()
        Me.txtName=New TextBox()
        Me.txtAddress=New TextBox()
        Me.txtContact=New TextBox()
        Me.txtFooter=New TextBox()
        Me.numTax=New NumericUpDown()
        Me.btnSave=New Button()
        Me.grpAdmin=New GroupBox()
        Me.btnUsers=New Button()
        Me.btnAudit=New Button()
        Me.btnBackup=New Button()
        Me.btnRestore=New Button()
        CType(Me.numTax,System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",22.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(30,25)
        Me.lblTitle.Text="Settings"
        Me.lblRole.AutoSize=True
        Me.lblRole.ForeColor=Drawing.Color.DimGray
        Me.lblRole.Location=New Drawing.Point(35,72)
        Me.lblName.AutoSize=True
        Me.lblName.Location=New Drawing.Point(35,120)
        Me.lblName.Text="Dealership / system name"
        Me.txtName.Location=New Drawing.Point(35,145)
        Me.txtName.Size=New Drawing.Size(440,29)
        Me.lblContact.AutoSize=True
        Me.lblContact.Location=New Drawing.Point(500,120)
        Me.lblContact.Text="Contact Number"
        Me.txtContact.Location=New Drawing.Point(500,145)
        Me.txtContact.Size=New Drawing.Size(260,29)
        Me.lblTax.AutoSize=True
        Me.lblTax.Location=New Drawing.Point(785,120)
        Me.lblTax.Text="Tax Rate (%)"
        Me.numTax.Location=New Drawing.Point(785,145)
        Me.numTax.Size=New Drawing.Size(170,29)
        Me.numTax.DecimalPlaces=2
        Me.numTax.Maximum=100
        Me.lblAddress.AutoSize=True
        Me.lblAddress.Location=New Drawing.Point(35,205)
        Me.lblAddress.Text="Dealership Address"
        Me.txtAddress.Location=New Drawing.Point(35,230)
        Me.txtAddress.Size=New Drawing.Size(725,65)
        Me.txtAddress.Multiline=True
        Me.lblFooter.AutoSize=True
        Me.lblFooter.Location=New Drawing.Point(35,320)
        Me.lblFooter.Text="Receipt Footer"
        Me.txtFooter.Location=New Drawing.Point(35,345)
        Me.txtFooter.Size=New Drawing.Size(725,65)
        Me.txtFooter.Multiline=True
        Me.btnSave.Location=New Drawing.Point(785,345)
        Me.btnSave.Size=New Drawing.Size(170,42)
        Me.btnSave.Text="Save Settings"
        Me.btnSave.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnSave.ForeColor=Drawing.Color.White
        Me.grpAdmin.Location=New Drawing.Point(35,450)
        Me.grpAdmin.Size=New Drawing.Size(920,145)
        Me.grpAdmin.Text="Administrator Tools"
        Me.btnUsers.Location=New Drawing.Point(25,50)
        Me.btnUsers.Size=New Drawing.Size(165,40)
        Me.btnUsers.Text="User Management"
        Me.btnAudit.Location=New Drawing.Point(205,50)
        Me.btnAudit.Size=New Drawing.Size(140,40)
        Me.btnAudit.Text="Audit Log"
        Me.btnBackup.Location=New Drawing.Point(360,50)
        Me.btnBackup.Size=New Drawing.Size(165,40)
        Me.btnBackup.Text="Backup Database"
        Me.btnRestore.Location=New Drawing.Point(540,50)
        Me.btnRestore.Size=New Drawing.Size(165,40)
        Me.btnRestore.Text="Restore Database"
        Me.grpAdmin.Controls.Add(Me.btnUsers)
        Me.grpAdmin.Controls.Add(Me.btnAudit)
        Me.grpAdmin.Controls.Add(Me.btnBackup)
        Me.grpAdmin.Controls.Add(Me.btnRestore)
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.BackColor=Drawing.Color.FromArgb(244,247,250)
        Me.ClientSize=New Drawing.Size(1175,760)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblRole)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblContact)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.lblTax)
        Me.Controls.Add(Me.numTax)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.lblFooter)
        Me.Controls.Add(Me.txtFooter)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpAdmin)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.Text="Settings"
        CType(Me.numTax,System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
