Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PaymentsForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSelected As Label
    Friend WithEvents lblAmount As Label
    Friend WithEvents lblMethod As Label
    Friend WithEvents lblReference As Label
    Friend WithEvents gridBalances As DataGridView
    Friend WithEvents gridHistory As DataGridView
    Friend WithEvents numAmount As NumericUpDown
    Friend WithEvents cbMethod As ComboBox
    Friend WithEvents txtReference As TextBox
    Friend WithEvents btnPay As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblEmptyBalances As Label
    Friend WithEvents lblEmptyHistory As Label
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.lblSelected=New Label()
        Me.lblAmount=New Label()
        Me.lblMethod=New Label()
        Me.lblReference=New Label()
        Me.gridBalances=New DataGridView()
        Me.gridHistory=New DataGridView()
        Me.numAmount=New NumericUpDown()
        Me.cbMethod=New ComboBox()
        Me.txtReference=New TextBox()
        Me.btnPay=New Button()
        Me.btnRefresh=New Button()
        Me.lblEmptyBalances=New Label()
        Me.lblEmptyHistory=New Label()
        CType(Me.gridBalances,System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridHistory,System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAmount,System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",22.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(30,25)
        Me.lblTitle.Text="Installment Payments"
        Me.btnRefresh.Location=New Drawing.Point(1020,45)
        Me.btnRefresh.Size=New Drawing.Size(110,35)
        Me.btnRefresh.Text="Refresh"
        Me.gridBalances.Location=New Drawing.Point(35,105)
        Me.gridBalances.Size=New Drawing.Size(1095,250)
        Me.lblEmptyBalances.AutoSize=False
        Me.lblEmptyBalances.Location=New Drawing.Point(360,195)
        Me.lblEmptyBalances.Size=New Drawing.Size(450,60)
        Me.lblEmptyBalances.Text="No outstanding installment balances."
        Me.lblEmptyBalances.TextAlign=Drawing.ContentAlignment.MiddleCenter
        Me.lblEmptyBalances.ForeColor=Drawing.Color.DimGray
        Me.lblEmptyBalances.BackColor=Drawing.Color.White
        Me.lblEmptyBalances.Visible=False
        Me.lblSelected.Location=New Drawing.Point(35,375)
        Me.lblSelected.Size=New Drawing.Size(1095,25)
        Me.lblSelected.Text="Select an installment sale to record a payment."
        Me.lblAmount.AutoSize=True
        Me.lblAmount.Location=New Drawing.Point(35,420)
        Me.lblAmount.Text="Payment Amount"
        Me.numAmount.Location=New Drawing.Point(35,445)
        Me.numAmount.Size=New Drawing.Size(220,29)
        Me.lblMethod.AutoSize=True
        Me.lblMethod.Location=New Drawing.Point(275,420)
        Me.lblMethod.Text="Method"
        Me.cbMethod.Location=New Drawing.Point(275,445)
        Me.cbMethod.Size=New Drawing.Size(200,30)
        Me.cbMethod.DropDownStyle=ComboBoxStyle.DropDownList
        Me.lblReference.AutoSize=True
        Me.lblReference.Location=New Drawing.Point(495,420)
        Me.lblReference.Text="Reference / OR Number"
        Me.txtReference.Location=New Drawing.Point(495,445)
        Me.txtReference.Size=New Drawing.Size(260,29)
        Me.btnPay.Location=New Drawing.Point(775,443)
        Me.btnPay.Size=New Drawing.Size(160,35)
        Me.btnPay.Text="Record Payment"
        Me.btnPay.BackColor=Drawing.Color.FromArgb(40,137,75)
        Me.btnPay.ForeColor=Drawing.Color.White
        Me.gridHistory.Location=New Drawing.Point(35,510)
        Me.gridHistory.Size=New Drawing.Size(1095,200)
        Me.gridHistory.Anchor=AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Me.lblEmptyHistory.AutoSize=False
        Me.lblEmptyHistory.Location=New Drawing.Point(360,600)
        Me.lblEmptyHistory.Size=New Drawing.Size(450,60)
        Me.lblEmptyHistory.Text="No payments recorded for this sale yet."
        Me.lblEmptyHistory.TextAlign=Drawing.ContentAlignment.MiddleCenter
        Me.lblEmptyHistory.ForeColor=Drawing.Color.DimGray
        Me.lblEmptyHistory.BackColor=Drawing.Color.White
        Me.lblEmptyHistory.Visible=False
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.BackColor=Drawing.Color.FromArgb(244,247,250)
        Me.ClientSize=New Drawing.Size(1175,760)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.gridBalances)
        Me.Controls.Add(Me.lblEmptyBalances)
        Me.Controls.Add(Me.lblSelected)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.numAmount)
        Me.Controls.Add(Me.lblMethod)
        Me.Controls.Add(Me.cbMethod)
        Me.Controls.Add(Me.lblReference)
        Me.Controls.Add(Me.txtReference)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.gridHistory)
        Me.Controls.Add(Me.lblEmptyHistory)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.Text="Payments"
        CType(Me.gridBalances,System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridHistory,System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAmount,System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
