Imports System
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class PaymentsForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub PaymentsForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            UiTheme.StyleGrid(gridBalances):UiTheme.StyleGrid(gridHistory)
            cbMethod.Items.Clear():cbMethod.Items.AddRange(New Object(){"Cash","Bank Transfer","Card","Financing"}):cbMethod.SelectedIndex=0
            numAmount.Maximum=100000000D:numAmount.DecimalPlaces=2:numAmount.ThousandsSeparator=True
            RefreshBalances()
        End Sub
        Private Sub RefreshBalances()
            Dim table = New PaymentService().ListOpenBalances()
            gridBalances.DataSource = table
            ConfigureBalanceGrid()
            lblEmptyBalances.Visible = table.Rows.Count = 0
            If lblEmptyBalances.Visible Then lblEmptyBalances.BringToFront()
            gridHistory.DataSource = Nothing
            lblEmptyHistory.Visible = False
            lblSelected.Text = "Select an installment sale to record a payment."
            btnPay.Enabled = table.Rows.Count > 0
        End Sub

        Private Sub ConfigureBalanceGrid()
            If gridBalances.Columns.Contains("SaleId") Then gridBalances.Columns("SaleId").Visible = False
            If gridBalances.Columns.Contains("SaleNumber") Then gridBalances.Columns("SaleNumber").HeaderText = "Sale Number"
            For Each name As String In New String() {"Total", "Paid", "Balance"}
                If gridBalances.Columns.Contains(name) Then gridBalances.Columns(name).DefaultCellStyle.Format = "₱ #,##0.00"
            Next
        End Sub

        Private Sub ConfigureHistoryGrid()
            If gridHistory.Columns.Contains("Amount") Then gridHistory.Columns("Amount").DefaultCellStyle.Format = "₱ #,##0.00"
            If gridHistory.Columns.Contains("ReferenceNumber") Then gridHistory.Columns("ReferenceNumber").HeaderText = "Reference / OR Number"
        End Sub
        Private Function SelectedSaleId() As Long
            If gridBalances.CurrentRow Is Nothing Then Return 0
            Return CLng(gridBalances.CurrentRow.Cells("SaleId").Value)
        End Function
        Private Sub gridBalances_SelectionChanged(sender As Object,e As EventArgs) Handles gridBalances.SelectionChanged
            Dim id=SelectedSaleId():If id=0 Then Return
            lblSelected.Text = "Selected: " & CStr(gridBalances.CurrentRow.Cells("SaleNumber").Value) & " · Balance ₱ " & CDec(gridBalances.CurrentRow.Cells("Balance").Value).ToString("N2")
            Dim history = New PaymentService().GetPaymentHistory(id)
            gridHistory.DataSource = history
            ConfigureHistoryGrid()
            lblEmptyHistory.Visible = history.Rows.Count = 0
            If lblEmptyHistory.Visible Then lblEmptyHistory.BringToFront()
            btnPay.Enabled = True
        End Sub
        Private Sub btnPay_Click(sender As Object,e As EventArgs) Handles btnPay.Click
            Dim id=SelectedSaleId():If id=0 Then MessageBox.Show("Select an open installment account first."):Return
            Dim err=New PaymentService().RecordPayment(id,numAmount.Value,CStr(cbMethod.SelectedItem),txtReference.Text)
            If err IsNot Nothing Then MessageBox.Show(err,"Payment",MessageBoxButtons.OK,MessageBoxIcon.Warning):Return
            MessageBox.Show("Payment recorded successfully.","Payment",MessageBoxButtons.OK,MessageBoxIcon.Information)
            numAmount.Value=0:txtReference.Clear():RefreshBalances()
        End Sub
        Private Sub btnRefresh_Click(sender As Object,e As EventArgs) Handles btnRefresh.Click
            RefreshBalances()
        End Sub
    End Class
End Namespace
