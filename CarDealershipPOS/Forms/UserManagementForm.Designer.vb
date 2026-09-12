Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserManagementForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents btnToggle As Button
    Friend WithEvents gridUsers As DataGridView
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.btnAdd=New Button()
        Me.btnReset=New Button()
        Me.btnToggle=New Button()
        Me.gridUsers=New DataGridView()
        CType(Me.gridUsers,System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",20.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(25,22)
        Me.lblTitle.Text="User Management"
        Me.btnAdd.Location=New Drawing.Point(575,35)
        Me.btnAdd.Size=New Drawing.Size(120,35)
        Me.btnAdd.Text="Add User"
        Me.btnAdd.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnAdd.ForeColor=Drawing.Color.White
        Me.btnReset.Location=New Drawing.Point(705,35)
        Me.btnReset.Size=New Drawing.Size(140,35)
        Me.btnReset.Text="Reset Password"
        Me.btnToggle.Location=New Drawing.Point(855,35)
        Me.btnToggle.Size=New Drawing.Size(130,35)
        Me.btnToggle.Text="Activate / Disable"
        Me.gridUsers.Location=New Drawing.Point(30,95)
        Me.gridUsers.Size=New Drawing.Size(955,455)
        Me.gridUsers.Anchor=AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.ClientSize=New Drawing.Size(1020,590)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnToggle)
        Me.Controls.Add(Me.gridUsers)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.StartPosition=FormStartPosition.CenterParent
        Me.Text="Users"
        CType(Me.gridUsers,System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
