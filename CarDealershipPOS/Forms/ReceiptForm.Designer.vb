Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceiptForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents txtReceipt As TextBox
    Friend WithEvents btnCopy As Button
    Friend WithEvents btnPrint As Button
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.txtReceipt=New TextBox()
        Me.btnCopy=New Button()
        Me.btnPrint=New Button()
        Me.SuspendLayout()
        Me.txtReceipt.Location=New Drawing.Point(20,20)
        Me.txtReceipt.Size=New Drawing.Size(620,560)
        Me.txtReceipt.Multiline=True
        Me.txtReceipt.ReadOnly=True
        Me.txtReceipt.ScrollBars=ScrollBars.Vertical
        Me.txtReceipt.Font=New Drawing.Font("Consolas",10.0!)
        Me.btnCopy.Location=New Drawing.Point(430,600)
        Me.btnCopy.Size=New Drawing.Size(100,38)
        Me.btnCopy.Text="Copy"
        Me.btnPrint.Location=New Drawing.Point(540,600)
        Me.btnPrint.Size=New Drawing.Size(100,38)
        Me.btnPrint.Text="Print"
        Me.btnPrint.BackColor=Drawing.Color.FromArgb(39,137,216)
        Me.btnPrint.ForeColor=Drawing.Color.White
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.ClientSize=New Drawing.Size(660,660)
        Me.Controls.Add(Me.txtReceipt)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnPrint)
        Me.StartPosition=FormStartPosition.CenterParent
        Me.Text="Sales Receipt"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
