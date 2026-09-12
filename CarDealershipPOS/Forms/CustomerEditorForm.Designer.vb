Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomerEditorForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblNumber As Label
    Friend WithEvents lblFirst As Label
    Friend WithEvents lblLast As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblContact As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtNumber As TextBox
    Friend WithEvents txtFirst As TextBox
    Friend WithEvents txtLast As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.lblNumber=New Label()
        Me.lblFirst=New Label()
        Me.lblLast=New Label()
        Me.lblEmail=New Label()
        Me.lblContact=New Label()
        Me.lblAddress=New Label()
        Me.txtNumber=New TextBox()
        Me.txtFirst=New TextBox()
        Me.txtLast=New TextBox()
        Me.txtEmail=New TextBox()
        Me.txtContact=New TextBox()
        Me.txtAddress=New TextBox()
        Me.btnSave=New Button()
        Me.btnCancel=New Button()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",20.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(30,24)
        Me.lblTitle.Text="Customer Details"
        Me.lblNumber.AutoSize=True
        Me.lblNumber.Location=New Drawing.Point(35,90)
        Me.lblNumber.Text="Customer Number"
        Me.txtNumber.Location=New Drawing.Point(35,115)
        Me.txtNumber.Size=New Drawing.Size(300,29)
        Me.lblFirst.AutoSize=True
        Me.lblFirst.Location=New Drawing.Point(365,90)
        Me.lblFirst.Text="First Name *"
        Me.txtFirst.Location=New Drawing.Point(365,115)
        Me.txtFirst.Size=New Drawing.Size(300,29)
        Me.lblLast.AutoSize=True
        Me.lblLast.Location=New Drawing.Point(35,170)
        Me.lblLast.Text="Last Name *"
        Me.txtLast.Location=New Drawing.Point(35,195)
        Me.txtLast.Size=New Drawing.Size(300,29)
        Me.lblEmail.AutoSize=True
        Me.lblEmail.Location=New Drawing.Point(365,170)
        Me.lblEmail.Text="Email"
        Me.txtEmail.Location=New Drawing.Point(365,195)
        Me.txtEmail.Size=New Drawing.Size(300,29)
        Me.lblContact.AutoSize=True
        Me.lblContact.Location=New Drawing.Point(35,250)
        Me.lblContact.Text="Contact Number"
        Me.txtContact.Location=New Drawing.Point(35,275)
        Me.txtContact.Size=New Drawing.Size(300,29)
        Me.lblAddress.AutoSize=True
        Me.lblAddress.Location=New Drawing.Point(35,330)
        Me.lblAddress.Text="Address"
        Me.txtAddress.Location=New Drawing.Point(35,355)
        Me.txtAddress.Size=New Drawing.Size(630,85)
        Me.txtAddress.Multiline=True
        Me.btnCancel.Location=New Drawing.Point(445,470)
        Me.btnCancel.Size=New Drawing.Size(100,40)
        Me.btnCancel.Text="Cancel"
        Me.btnSave.Location=New Drawing.Point(555,470)
        Me.btnSave.Size=New Drawing.Size(110,40)
        Me.btnSave.Text="Save"
        Me.btnSave.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnSave.ForeColor=Drawing.Color.White
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.ClientSize=New Drawing.Size(710,550)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblNumber)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.lblFirst)
        Me.Controls.Add(Me.txtFirst)
        Me.Controls.Add(Me.lblLast)
        Me.Controls.Add(Me.txtLast)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblContact)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.StartPosition=FormStartPosition.CenterParent
        Me.FormBorderStyle=FormBorderStyle.FixedDialog
        Me.MaximizeBox=False
        Me.Text="Customer"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
