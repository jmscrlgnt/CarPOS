Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomersForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents chkInactive As CheckBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDeactivate As Button
    Friend WithEvents gridCustomers As DataGridView
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.lblSearch=New Label()
        Me.txtSearch=New TextBox()
        Me.chkInactive=New CheckBox()
        Me.btnSearch=New Button()
        Me.btnAdd=New Button()
        Me.btnEdit=New Button()
        Me.btnDeactivate=New Button()
        Me.gridCustomers=New DataGridView()
        CType(Me.gridCustomers,System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",22.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(30,25)
        Me.lblTitle.Text="Customers"
        Me.lblSearch.AutoSize=True
        Me.lblSearch.Location=New Drawing.Point(35,105)
        Me.lblSearch.Text="Search customer"
        Me.txtSearch.Location=New Drawing.Point(35,130)
        Me.txtSearch.Size=New Drawing.Size(355,30)
        Me.btnSearch.Location=New Drawing.Point(400,128)
        Me.btnSearch.Size=New Drawing.Size(90,34)
        Me.btnSearch.Text="Search"
        Me.chkInactive.AutoSize=True
        Me.chkInactive.Location=New Drawing.Point(505,134)
        Me.chkInactive.Text="Show inactive"
        Me.btnAdd.Location=New Drawing.Point(810,128)
        Me.btnAdd.Size=New Drawing.Size(105,34)
        Me.btnAdd.Text="Add Customer"
        Me.btnAdd.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnAdd.ForeColor=Drawing.Color.White
        Me.btnEdit.Location=New Drawing.Point(925,128)
        Me.btnEdit.Size=New Drawing.Size(80,34)
        Me.btnEdit.Text="Edit"
        Me.btnDeactivate.Location=New Drawing.Point(1015,128)
        Me.btnDeactivate.Size=New Drawing.Size(115,34)
        Me.btnDeactivate.Text="Deactivate"
        Me.btnDeactivate.BackColor=Drawing.Color.Firebrick
        Me.btnDeactivate.ForeColor=Drawing.Color.White
        Me.gridCustomers.Location=New Drawing.Point(35,190)
        Me.gridCustomers.Size=New Drawing.Size(1095,520)
        Me.gridCustomers.Anchor=AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.BackColor=Drawing.Color.FromArgb(244,247,250)
        Me.ClientSize=New Drawing.Size(1175,760)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.chkInactive)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDeactivate)
        Me.Controls.Add(Me.gridCustomers)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.Text="Customers"
        CType(Me.gridCustomers,System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
