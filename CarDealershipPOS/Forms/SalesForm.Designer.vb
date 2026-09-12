Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnApply As Button
    Friend WithEvents btnReceipt As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents gridSales As DataGridView
    Friend WithEvents lblEmptySales As Label
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.lblFrom=New Label()
        Me.lblTo=New Label()
        Me.lblSearch=New Label()
        Me.dtFrom=New DateTimePicker()
        Me.dtTo=New DateTimePicker()
        Me.txtSearch=New TextBox()
        Me.btnApply=New Button()
        Me.btnReceipt=New Button()
        Me.btnExport=New Button()
        Me.gridSales=New DataGridView()
        Me.lblEmptySales=New Label()
        CType(Me.gridSales,System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",22.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(30,25)
        Me.lblTitle.Text="Sales History"
        Me.lblFrom.AutoSize=True
        Me.lblFrom.Location=New Drawing.Point(35,100)
        Me.lblFrom.Text="From"
        Me.dtFrom.Location=New Drawing.Point(35,125)
        Me.dtFrom.Size=New Drawing.Size(210,29)
        Me.lblTo.AutoSize=True
        Me.lblTo.Location=New Drawing.Point(260,100)
        Me.lblTo.Text="To"
        Me.dtTo.Location=New Drawing.Point(260,125)
        Me.dtTo.Size=New Drawing.Size(210,29)
        Me.lblSearch.AutoSize=True
        Me.lblSearch.Location=New Drawing.Point(485,100)
        Me.lblSearch.Text="Sale / customer / vehicle"
        Me.txtSearch.Location=New Drawing.Point(485,125)
        Me.txtSearch.Size=New Drawing.Size(300,29)
        Me.btnApply.Location=New Drawing.Point(800,123)
        Me.btnApply.Size=New Drawing.Size(90,33)
        Me.btnApply.Text="Apply"
        Me.btnApply.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnApply.ForeColor=Drawing.Color.White
        Me.btnReceipt.Location=New Drawing.Point(900,123)
        Me.btnReceipt.Size=New Drawing.Size(105,33)
        Me.btnReceipt.Text="Receipt"
        Me.btnExport.Location=New Drawing.Point(1015,123)
        Me.btnExport.Size=New Drawing.Size(115,33)
        Me.btnExport.Text="Export CSV"
        Me.gridSales.Location=New Drawing.Point(35,190)
        Me.gridSales.Size=New Drawing.Size(1095,520)
        Me.gridSales.Anchor=AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Me.lblEmptySales.AutoSize=False
        Me.lblEmptySales.Location=New Drawing.Point(340,415)
        Me.lblEmptySales.Size=New Drawing.Size(500,70)
        Me.lblEmptySales.Text="No sales match the current filters."
        Me.lblEmptySales.TextAlign=Drawing.ContentAlignment.MiddleCenter
        Me.lblEmptySales.ForeColor=Drawing.Color.DimGray
        Me.lblEmptySales.BackColor=Drawing.Color.White
        Me.lblEmptySales.Visible=False
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.BackColor=Drawing.Color.FromArgb(244,247,250)
        Me.ClientSize=New Drawing.Size(1175,760)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnReceipt)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.gridSales)
        Me.Controls.Add(Me.lblEmptySales)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.Text="Sales"
        CType(Me.gridSales,System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
