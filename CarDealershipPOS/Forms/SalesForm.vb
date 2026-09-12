Imports System
Imports System.Data
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class SalesForm
        Private _table As DataTable
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub SalesForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            UiTheme.StyleGrid(gridSales):dtFrom.Value=DateTime.Today.AddMonths(-1):dtTo.Value=DateTime.Today:RefreshGrid()
        End Sub
        Private Sub RefreshGrid()
            _table = New ReportService().Sales(dtFrom.Value, dtTo.Value, txtSearch.Text)
            gridSales.DataSource = _table
            ConfigureSalesGrid()
            lblEmptySales.Visible = _table.Rows.Count = 0
            If lblEmptySales.Visible Then lblEmptySales.BringToFront()
        End Sub

        Private Sub ConfigureSalesGrid()
            If gridSales.Columns.Contains("Id") Then gridSales.Columns("Id").Visible = False
            If gridSales.Columns.Contains("SaleNumber") Then gridSales.Columns("SaleNumber").HeaderText = "Sale Number"
            If gridSales.Columns.Contains("StockNumber") Then gridSales.Columns("StockNumber").HeaderText = "Stock Number"
            If gridSales.Columns.Contains("PaymentPlan") Then gridSales.Columns("PaymentPlan").HeaderText = "Payment Plan"
            For Each name As String In New String() {"Total", "Paid", "Balance"}
                If gridSales.Columns.Contains(name) Then gridSales.Columns(name).DefaultCellStyle.Format = "₱ #,##0.00"
            Next
        End Sub
        Private Function SelectedId() As Long
            If gridSales.CurrentRow Is Nothing Then Return 0
            Return CLng(gridSales.CurrentRow.Cells("Id").Value)
        End Function
        Private Sub btnApply_Click(sender As Object,e As EventArgs) Handles btnApply.Click
            RefreshGrid()
        End Sub
        Private Sub btnReceipt_Click(sender As Object,e As EventArgs) Handles btnReceipt.Click
            Dim id=SelectedId():If id=0 Then MessageBox.Show("Select a sale first."):Return
            Using f As New ReceiptForm(id):f.ShowDialog():End Using
        End Sub
        Private Sub btnExport_Click(sender As Object,e As EventArgs) Handles btnExport.Click
            If _table Is Nothing OrElse _table.Rows.Count=0 Then MessageBox.Show("There are no sales to export."):Return
            Using d As New SaveFileDialog() With {.Filter="CSV File|*.csv",.FileName="sales-" & DateTime.Now.ToString("yyyyMMdd") & ".csv"}
                If d.ShowDialog() = DialogResult.OK Then
                    Dim reportService As New ReportService()
                    reportService.ExportCsv(_table, d.FileName)
                    MessageBox.Show("CSV exported successfully.")
                End If
            End Using
        End Sub
    End Class
End Namespace
