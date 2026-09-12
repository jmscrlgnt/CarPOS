Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AuditLogForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents gridAudit As DataGridView
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.btnRefresh=New Button()
        Me.gridAudit=New DataGridView()
        CType(Me.gridAudit,System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",20.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(25,22)
        Me.lblTitle.Text="Audit Activity"
        Me.btnRefresh.Location=New Drawing.Point(890,35)
        Me.btnRefresh.Size=New Drawing.Size(95,35)
        Me.btnRefresh.Text="Refresh"
        Me.gridAudit.Location=New Drawing.Point(30,95)
        Me.gridAudit.Size=New Drawing.Size(955,455)
        Me.gridAudit.Anchor=AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.ClientSize=New Drawing.Size(1020,590)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.gridAudit)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.StartPosition=FormStartPosition.CenterParent
        Me.Text="Audit Log"
        CType(Me.gridAudit,System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
