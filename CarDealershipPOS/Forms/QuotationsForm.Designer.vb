Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QuotationsForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents btnConvert As Button
    Friend WithEvents gridQuotes As DataGridView
    Friend WithEvents lblEmptyQuotes As Label
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.btnRefresh=New Button()
        Me.btnNew=New Button()
        Me.btnConvert=New Button()
        Me.gridQuotes=New DataGridView()
        Me.lblEmptyQuotes=New Label()
        CType(Me.gridQuotes,System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",22.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(30,25)
        Me.lblTitle.Text="Quotations"
        Me.btnRefresh.Location=New Drawing.Point(730,45)
        Me.btnRefresh.Size=New Drawing.Size(95,35)
        Me.btnRefresh.Text="Refresh"
        Me.btnNew.Location=New Drawing.Point(835,45)
        Me.btnNew.Size=New Drawing.Size(120,35)
        Me.btnNew.Text="New Quote"
        Me.btnNew.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnNew.ForeColor=Drawing.Color.White
        Me.btnConvert.Location=New Drawing.Point(965,45)
        Me.btnConvert.Size=New Drawing.Size(165,35)
        Me.btnConvert.Text="Convert to Sale"
        Me.btnConvert.BackColor=Drawing.Color.FromArgb(40,137,75)
        Me.btnConvert.ForeColor=Drawing.Color.White
        Me.gridQuotes.Location=New Drawing.Point(35,115)
        Me.gridQuotes.Size=New Drawing.Size(1095,595)
        Me.gridQuotes.Anchor=AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Me.lblEmptyQuotes.AutoSize=False
        Me.lblEmptyQuotes.Location=New Drawing.Point(350,360)
        Me.lblEmptyQuotes.Size=New Drawing.Size(460,70)
        Me.lblEmptyQuotes.Text="No quotations yet."
        Me.lblEmptyQuotes.TextAlign=Drawing.ContentAlignment.MiddleCenter
        Me.lblEmptyQuotes.ForeColor=Drawing.Color.DimGray
        Me.lblEmptyQuotes.BackColor=Drawing.Color.White
        Me.lblEmptyQuotes.Visible=False
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.BackColor=Drawing.Color.FromArgb(244,247,250)
        Me.ClientSize=New Drawing.Size(1175,760)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.gridQuotes)
        Me.Controls.Add(Me.lblEmptyQuotes)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.Text="Quotations"
        CType(Me.gridQuotes,System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
