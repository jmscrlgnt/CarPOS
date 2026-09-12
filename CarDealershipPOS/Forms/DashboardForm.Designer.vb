Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DashboardForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents pnlAvailable As Panel
    Friend WithEvents pnlNew As Panel
    Friend WithEvents pnlUsed As Panel
    Friend WithEvents pnlToday As Panel
    Friend WithEvents pnlMonth As Panel
    Friend WithEvents pnlReceivables As Panel
    Friend WithEvents lblAvailableCaption As Label
    Friend WithEvents lblNewCaption As Label
    Friend WithEvents lblUsedCaption As Label
    Friend WithEvents lblTodayCaption As Label
    Friend WithEvents lblMonthCaption As Label
    Friend WithEvents lblReceivablesCaption As Label
    Friend WithEvents lblAvailable As Label
    Friend WithEvents lblNew As Label
    Friend WithEvents lblUsed As Label
    Friend WithEvents lblToday As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents lblReceivables As Label
    Friend WithEvents lblRecentTitle As Label
    Friend WithEvents gridRecent As DataGridView
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.lblDate=New Label()
        Me.pnlAvailable=New Panel()
        Me.pnlNew=New Panel()
        Me.pnlUsed=New Panel()
        Me.pnlToday=New Panel()
        Me.pnlMonth=New Panel()
        Me.pnlReceivables=New Panel()
        Me.lblAvailableCaption=New Label()
        Me.lblNewCaption=New Label()
        Me.lblUsedCaption=New Label()
        Me.lblTodayCaption=New Label()
        Me.lblMonthCaption=New Label()
        Me.lblReceivablesCaption=New Label()
        Me.lblAvailable=New Label()
        Me.lblNew=New Label()
        Me.lblUsed=New Label()
        Me.lblToday=New Label()
        Me.lblMonth=New Label()
        Me.lblReceivables=New Label()
        Me.lblRecentTitle=New Label()
        Me.gridRecent=New DataGridView()
        CType(Me.gridRecent,System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAvailable.SuspendLayout()
        Me.pnlNew.SuspendLayout()
        Me.pnlUsed.SuspendLayout()
        Me.pnlToday.SuspendLayout()
        Me.pnlMonth.SuspendLayout()
        Me.pnlReceivables.SuspendLayout()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",22.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(30,25)
        Me.lblTitle.Text="Dashboard"
        Me.lblDate.AutoSize=True
        Me.lblDate.Location=New Drawing.Point(34,70)
        Me.lblDate.ForeColor=Drawing.Color.DimGray
        Me.pnlAvailable.BackColor=Drawing.Color.White
        Me.pnlAvailable.BorderStyle=BorderStyle.FixedSingle
        Me.pnlAvailable.Location=New Drawing.Point(35,110)
        Me.pnlAvailable.Size=New Drawing.Size(340,105)
        Me.lblAvailableCaption.AutoSize=True
        Me.lblAvailableCaption.Location=New Drawing.Point(18,14)
        Me.lblAvailableCaption.Text="Available Inventory"
        Me.lblAvailableCaption.ForeColor=Drawing.Color.DimGray
        Me.lblAvailableCaption.Font=New Drawing.Font("Segoe UI",9.5!,Drawing.FontStyle.Bold)
        Me.lblAvailable.AutoSize=True
        Me.lblAvailable.Location=New Drawing.Point(18,47)
        Me.lblAvailable.Font=New Drawing.Font("Segoe UI",21.0!,Drawing.FontStyle.Bold)
        Me.lblAvailable.ForeColor=Drawing.Color.FromArgb(25,70,105)
        Me.lblAvailable.Text="0"
        Me.pnlAvailable.Controls.Add(Me.lblAvailableCaption)
        Me.pnlAvailable.Controls.Add(Me.lblAvailable)
        Me.pnlNew.BackColor=Drawing.Color.White
        Me.pnlNew.BorderStyle=BorderStyle.FixedSingle
        Me.pnlNew.Location=New Drawing.Point(400,110)
        Me.pnlNew.Size=New Drawing.Size(340,105)
        Me.lblNewCaption.AutoSize=True
        Me.lblNewCaption.Location=New Drawing.Point(18,14)
        Me.lblNewCaption.Text="New Vehicles"
        Me.lblNewCaption.ForeColor=Drawing.Color.DimGray
        Me.lblNewCaption.Font=New Drawing.Font("Segoe UI",9.5!,Drawing.FontStyle.Bold)
        Me.lblNew.AutoSize=True
        Me.lblNew.Location=New Drawing.Point(18,47)
        Me.lblNew.Font=New Drawing.Font("Segoe UI",21.0!,Drawing.FontStyle.Bold)
        Me.lblNew.ForeColor=Drawing.Color.FromArgb(25,70,105)
        Me.lblNew.Text="0"
        Me.pnlNew.Controls.Add(Me.lblNewCaption)
        Me.pnlNew.Controls.Add(Me.lblNew)
        Me.pnlUsed.BackColor=Drawing.Color.White
        Me.pnlUsed.BorderStyle=BorderStyle.FixedSingle
        Me.pnlUsed.Location=New Drawing.Point(765,110)
        Me.pnlUsed.Size=New Drawing.Size(340,105)
        Me.lblUsedCaption.AutoSize=True
        Me.lblUsedCaption.Location=New Drawing.Point(18,14)
        Me.lblUsedCaption.Text="Used Vehicles"
        Me.lblUsedCaption.ForeColor=Drawing.Color.DimGray
        Me.lblUsedCaption.Font=New Drawing.Font("Segoe UI",9.5!,Drawing.FontStyle.Bold)
        Me.lblUsed.AutoSize=True
        Me.lblUsed.Location=New Drawing.Point(18,47)
        Me.lblUsed.Font=New Drawing.Font("Segoe UI",21.0!,Drawing.FontStyle.Bold)
        Me.lblUsed.ForeColor=Drawing.Color.FromArgb(25,70,105)
        Me.lblUsed.Text="0"
        Me.pnlUsed.Controls.Add(Me.lblUsedCaption)
        Me.pnlUsed.Controls.Add(Me.lblUsed)
        Me.pnlToday.BackColor=Drawing.Color.White
        Me.pnlToday.BorderStyle=BorderStyle.FixedSingle
        Me.pnlToday.Location=New Drawing.Point(35,235)
        Me.pnlToday.Size=New Drawing.Size(340,105)
        Me.lblTodayCaption.AutoSize=True
        Me.lblTodayCaption.Location=New Drawing.Point(18,14)
        Me.lblTodayCaption.Text="Sales Today"
        Me.lblTodayCaption.ForeColor=Drawing.Color.DimGray
        Me.lblTodayCaption.Font=New Drawing.Font("Segoe UI",9.5!,Drawing.FontStyle.Bold)
        Me.lblToday.AutoSize=True
        Me.lblToday.Location=New Drawing.Point(18,47)
        Me.lblToday.Font=New Drawing.Font("Segoe UI",21.0!,Drawing.FontStyle.Bold)
        Me.lblToday.ForeColor=Drawing.Color.FromArgb(25,70,105)
        Me.lblToday.Text="0"
        Me.pnlToday.Controls.Add(Me.lblTodayCaption)
        Me.pnlToday.Controls.Add(Me.lblToday)
        Me.pnlMonth.BackColor=Drawing.Color.White
        Me.pnlMonth.BorderStyle=BorderStyle.FixedSingle
        Me.pnlMonth.Location=New Drawing.Point(400,235)
        Me.pnlMonth.Size=New Drawing.Size(340,105)
        Me.lblMonthCaption.AutoSize=True
        Me.lblMonthCaption.Location=New Drawing.Point(18,14)
        Me.lblMonthCaption.Text="Sales This Month"
        Me.lblMonthCaption.ForeColor=Drawing.Color.DimGray
        Me.lblMonthCaption.Font=New Drawing.Font("Segoe UI",9.5!,Drawing.FontStyle.Bold)
        Me.lblMonth.AutoSize=True
        Me.lblMonth.Location=New Drawing.Point(18,47)
        Me.lblMonth.Font=New Drawing.Font("Segoe UI",18.0!,Drawing.FontStyle.Bold)
        Me.lblMonth.ForeColor=Drawing.Color.FromArgb(25,70,105)
        Me.lblMonth.Text="₱ 0.00"
        Me.pnlMonth.Controls.Add(Me.lblMonthCaption)
        Me.pnlMonth.Controls.Add(Me.lblMonth)
        Me.pnlReceivables.BackColor=Drawing.Color.White
        Me.pnlReceivables.BorderStyle=BorderStyle.FixedSingle
        Me.pnlReceivables.Location=New Drawing.Point(765,235)
        Me.pnlReceivables.Size=New Drawing.Size(340,105)
        Me.lblReceivablesCaption.AutoSize=True
        Me.lblReceivablesCaption.Location=New Drawing.Point(18,14)
        Me.lblReceivablesCaption.Text="Outstanding Receivables"
        Me.lblReceivablesCaption.ForeColor=Drawing.Color.DimGray
        Me.lblReceivablesCaption.Font=New Drawing.Font("Segoe UI",9.5!,Drawing.FontStyle.Bold)
        Me.lblReceivables.AutoSize=True
        Me.lblReceivables.Location=New Drawing.Point(18,47)
        Me.lblReceivables.Font=New Drawing.Font("Segoe UI",18.0!,Drawing.FontStyle.Bold)
        Me.lblReceivables.ForeColor=Drawing.Color.FromArgb(25,70,105)
        Me.lblReceivables.Text="₱ 0.00"
        Me.pnlReceivables.Controls.Add(Me.lblReceivablesCaption)
        Me.pnlReceivables.Controls.Add(Me.lblReceivables)
        Me.lblRecentTitle.AutoSize=True
        Me.lblRecentTitle.Font=New Drawing.Font("Segoe UI",13.0!,Drawing.FontStyle.Bold)
        Me.lblRecentTitle.Location=New Drawing.Point(35,380)
        Me.lblRecentTitle.Text="Recent sales"
        Me.gridRecent.Location=New Drawing.Point(35,420)
        Me.gridRecent.Size=New Drawing.Size(1070,285)
        Me.gridRecent.Anchor=AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.BackColor=Drawing.Color.FromArgb(244,247,250)
        Me.ClientSize=New Drawing.Size(1175,760)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.pnlAvailable)
        Me.Controls.Add(Me.pnlNew)
        Me.Controls.Add(Me.pnlUsed)
        Me.Controls.Add(Me.pnlToday)
        Me.Controls.Add(Me.pnlMonth)
        Me.Controls.Add(Me.pnlReceivables)
        Me.Controls.Add(Me.lblRecentTitle)
        Me.Controls.Add(Me.gridRecent)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.Text="Dashboard"
        CType(Me.gridRecent,System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAvailable.ResumeLayout(False)
        Me.pnlAvailable.PerformLayout()
        Me.pnlNew.ResumeLayout(False)
        Me.pnlNew.PerformLayout()
        Me.pnlUsed.ResumeLayout(False)
        Me.pnlUsed.PerformLayout()
        Me.pnlToday.ResumeLayout(False)
        Me.pnlToday.PerformLayout()
        Me.pnlMonth.ResumeLayout(False)
        Me.pnlMonth.PerformLayout()
        Me.pnlReceivables.ResumeLayout(False)
        Me.pnlReceivables.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
