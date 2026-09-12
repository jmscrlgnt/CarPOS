Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class QuotationsForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub QuotationsForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            UiTheme.StyleGrid(gridQuotes):RefreshGrid()
        End Sub
        Private Sub RefreshGrid()
            Dim table = New QuotationService().ListQuotations()
            gridQuotes.DataSource = table
            ConfigureQuotationGrid()
            lblEmptyQuotes.Visible = table.Rows.Count = 0
            If lblEmptyQuotes.Visible Then lblEmptyQuotes.BringToFront()
        End Sub

        Private Sub ConfigureQuotationGrid()
            If gridQuotes.Columns.Contains("Id") Then gridQuotes.Columns("Id").Visible = False
            If gridQuotes.Columns.Contains("QuoteNumber") Then gridQuotes.Columns("QuoteNumber").HeaderText = "Quote Number"
            If gridQuotes.Columns.Contains("Total") Then gridQuotes.Columns("Total").DefaultCellStyle.Format = "₱ #,##0.00"
            If gridQuotes.Columns.Contains("Created") Then gridQuotes.Columns("Created").HeaderText = "Created"
        End Sub
        Private Function SelectedId() As Long
            If gridQuotes.CurrentRow Is Nothing Then Return 0
            Return CLng(gridQuotes.CurrentRow.Cells("Id").Value)
        End Function
        Private Sub btnRefresh_Click(sender As Object,e As EventArgs) Handles btnRefresh.Click
            RefreshGrid()
        End Sub
        Private Sub btnNew_Click(sender As Object,e As EventArgs) Handles btnNew.Click
            Using f As New PosForm()
                f.Text="Create Quotation / Sale"
                f.ShowDialog()
            End Using
            RefreshGrid()
        End Sub
        Private Sub btnConvert_Click(sender As Object,e As EventArgs) Handles btnConvert.Click
            Dim id=SelectedId():If id=0 Then MessageBox.Show("Select a quotation first."):Return
            Using f As New PosForm(id)
                f.Text="Convert Quotation to Sale"
                f.ShowDialog()
            End Using
            RefreshGrid()
        End Sub
    End Class
End Namespace
