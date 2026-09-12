Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PosForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblCustomer As Label
    Friend WithEvents lblVehicle As Label
    Friend WithEvents lblDiscountCaption As Label
    Friend WithEvents lblPlan As Label
    Friend WithEvents lblInitial As Label
    Friend WithEvents lblMethod As Label
    Friend WithEvents lblNotes As Label
    Friend WithEvents cbCustomer As ComboBox
    Friend WithEvents cbVehicle As ComboBox
    Friend WithEvents cbPlan As ComboBox
    Friend WithEvents cbMethod As ComboBox
    Friend WithEvents numDiscount As NumericUpDown
    Friend WithEvents numInitial As NumericUpDown
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents btnCalculate As Button
    Friend WithEvents btnQuote As Button
    Friend WithEvents btnFinalize As Button
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblDiscount As Label
    Friend WithEvents lblTax As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents grpSummary As GroupBox
    Friend WithEvents lblSummaryPrice As Label
    Friend WithEvents lblSummaryDiscount As Label
    Friend WithEvents lblSummaryTax As Label
    Friend WithEvents lblSummaryTotal As Label
    Friend WithEvents lblSummaryChange As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents grpVehiclePreview As GroupBox
    Friend WithEvents picPosVehicle As PictureBox
    Friend WithEvents lblPosNoImage As Label
    Friend WithEvents lblPosVehicleName As Label
    Friend WithEvents lblPosVehicleStock As Label
    Friend WithEvents lblPosVehicleDetails As Label
    Friend WithEvents lblPosVehiclePrice As Label
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.lblTitle=New Label()
        Me.lblCustomer=New Label()
        Me.lblVehicle=New Label()
        Me.lblDiscountCaption=New Label()
        Me.lblPlan=New Label()
        Me.lblInitial=New Label()
        Me.lblMethod=New Label()
        Me.lblNotes=New Label()
        Me.cbCustomer=New ComboBox()
        Me.cbVehicle=New ComboBox()
        Me.cbPlan=New ComboBox()
        Me.cbMethod=New ComboBox()
        Me.numDiscount=New NumericUpDown()
        Me.numInitial=New NumericUpDown()
        Me.txtNotes=New TextBox()
        Me.btnCalculate=New Button()
        Me.btnQuote=New Button()
        Me.btnFinalize=New Button()
        Me.lblSubtotal=New Label()
        Me.lblDiscount=New Label()
        Me.lblTax=New Label()
        Me.lblTotal=New Label()
        Me.grpSummary=New GroupBox()
        Me.lblSummaryPrice=New Label()
        Me.lblSummaryDiscount=New Label()
        Me.lblSummaryTax=New Label()
        Me.lblSummaryTotal=New Label()
        Me.lblSummaryChange=New Label()
        Me.lblChange=New Label()
        Me.grpVehiclePreview=New GroupBox()
        Me.picPosVehicle=New PictureBox()
        Me.lblPosNoImage=New Label()
        Me.lblPosVehicleName=New Label()
        Me.lblPosVehicleStock=New Label()
        Me.lblPosVehicleDetails=New Label()
        Me.lblPosVehiclePrice=New Label()
        CType(Me.numDiscount,System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numInitial,System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPosVehicle,System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVehiclePreview.SuspendLayout()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize=True
        Me.lblTitle.Font=New Drawing.Font("Segoe UI",22.0!,Drawing.FontStyle.Bold)
        Me.lblTitle.Location=New Drawing.Point(30,25)
        Me.lblTitle.Text="Point of Sale"
        Me.lblCustomer.AutoSize=True
        Me.lblCustomer.Location=New Drawing.Point(35,100)
        Me.lblCustomer.Text="Customer *"
        Me.cbCustomer.Location=New Drawing.Point(35,126)
        Me.cbCustomer.Size=New Drawing.Size(495,30)
        Me.cbCustomer.DropDownStyle=ComboBoxStyle.DropDownList
        Me.lblVehicle.AutoSize=True
        Me.lblVehicle.Location=New Drawing.Point(565,100)
        Me.lblVehicle.Text="Available Vehicle *"
        Me.cbVehicle.Location=New Drawing.Point(565,126)
        Me.cbVehicle.Size=New Drawing.Size(565,30)
        Me.cbVehicle.DropDownStyle=ComboBoxStyle.DropDownList
        Me.grpVehiclePreview.Location=New Drawing.Point(35,175)
        Me.grpVehiclePreview.Size=New Drawing.Size(1095,160)
        Me.grpVehiclePreview.Text="Selected Vehicle"
        Me.picPosVehicle.Location=New Drawing.Point(18,28)
        Me.picPosVehicle.Size=New Drawing.Size(190,115)
        Me.picPosVehicle.BorderStyle=BorderStyle.FixedSingle
        Me.picPosVehicle.BackColor=Drawing.Color.White
        Me.picPosVehicle.SizeMode=PictureBoxSizeMode.Zoom
        Me.lblPosNoImage.AutoSize=False
        Me.lblPosNoImage.Location=New Drawing.Point(38,55)
        Me.lblPosNoImage.Size=New Drawing.Size(150,55)
        Me.lblPosNoImage.Text="No image available"
        Me.lblPosNoImage.TextAlign=Drawing.ContentAlignment.MiddleCenter
        Me.lblPosNoImage.ForeColor=Drawing.Color.DimGray
        Me.lblPosVehicleName.AutoSize=False
        Me.lblPosVehicleName.Location=New Drawing.Point(230,30)
        Me.lblPosVehicleName.Size=New Drawing.Size(520,32)
        Me.lblPosVehicleName.Font=New Drawing.Font("Segoe UI",13.0!,Drawing.FontStyle.Bold)
        Me.lblPosVehicleName.Text="Select an available vehicle"
        Me.lblPosVehicleStock.AutoSize=False
        Me.lblPosVehicleStock.Location=New Drawing.Point(230,67)
        Me.lblPosVehicleStock.Size=New Drawing.Size(420,25)
        Me.lblPosVehicleStock.Text="Stock: —"
        Me.lblPosVehicleDetails.AutoSize=False
        Me.lblPosVehicleDetails.Location=New Drawing.Point(230,99)
        Me.lblPosVehicleDetails.Size=New Drawing.Size(520,28)
        Me.lblPosVehicleDetails.ForeColor=Drawing.Color.DimGray
        Me.lblPosVehicleDetails.Text="Condition · Color · Mileage"
        Me.lblPosVehiclePrice.AutoSize=False
        Me.lblPosVehiclePrice.Location=New Drawing.Point(780,48)
        Me.lblPosVehiclePrice.Size=New Drawing.Size(285,55)
        Me.lblPosVehiclePrice.Font=New Drawing.Font("Segoe UI",18.0!,Drawing.FontStyle.Bold)
        Me.lblPosVehiclePrice.ForeColor=Drawing.Color.FromArgb(16,73,115)
        Me.lblPosVehiclePrice.TextAlign=Drawing.ContentAlignment.MiddleRight
        Me.lblPosVehiclePrice.Text="₱ 0.00"
        Me.grpVehiclePreview.Controls.Add(Me.picPosVehicle)
        Me.grpVehiclePreview.Controls.Add(Me.lblPosNoImage)
        Me.grpVehiclePreview.Controls.Add(Me.lblPosVehicleName)
        Me.grpVehiclePreview.Controls.Add(Me.lblPosVehicleStock)
        Me.grpVehiclePreview.Controls.Add(Me.lblPosVehicleDetails)
        Me.grpVehiclePreview.Controls.Add(Me.lblPosVehiclePrice)
        Me.lblDiscountCaption.AutoSize=True
        Me.lblDiscountCaption.Location=New Drawing.Point(35,355)
        Me.lblDiscountCaption.Text="Discount"
        Me.numDiscount.Location=New Drawing.Point(35,380)
        Me.numDiscount.Size=New Drawing.Size(220,29)
        Me.numDiscount.DecimalPlaces=2
        Me.numDiscount.ThousandsSeparator=True
        Me.lblPlan.AutoSize=True
        Me.lblPlan.Location=New Drawing.Point(285,355)
        Me.lblPlan.Text="Payment Plan"
        Me.cbPlan.Location=New Drawing.Point(285,380)
        Me.cbPlan.Size=New Drawing.Size(200,30)
        Me.cbPlan.DropDownStyle=ComboBoxStyle.DropDownList
        Me.lblInitial.AutoSize=True
        Me.lblInitial.Location=New Drawing.Point(515,355)
        Me.lblInitial.Text="Initial Payment / Down Payment"
        Me.numInitial.Location=New Drawing.Point(515,380)
        Me.numInitial.Size=New Drawing.Size(240,29)
        Me.numInitial.DecimalPlaces=2
        Me.numInitial.ThousandsSeparator=True
        Me.lblMethod.AutoSize=True
        Me.lblMethod.Location=New Drawing.Point(785,355)
        Me.lblMethod.Text="Payment Method"
        Me.cbMethod.Location=New Drawing.Point(785,380)
        Me.cbMethod.Size=New Drawing.Size(240,30)
        Me.cbMethod.DropDownStyle=ComboBoxStyle.DropDownList
        Me.btnCalculate.Location=New Drawing.Point(1040,378)
        Me.btnCalculate.Size=New Drawing.Size(90,34)
        Me.btnCalculate.Text="Calculate"
        Me.lblNotes.AutoSize=True
        Me.lblNotes.Location=New Drawing.Point(35,435)
        Me.lblNotes.Text="Notes"
        Me.txtNotes.Location=New Drawing.Point(35,460)
        Me.txtNotes.Size=New Drawing.Size(650,115)
        Me.txtNotes.Multiline=True
        Me.grpSummary.Location=New Drawing.Point(720,435)
        Me.grpSummary.Size=New Drawing.Size(410,215)
        Me.grpSummary.Text="Sale Summary"
        Me.lblSummaryPrice.AutoSize=True
        Me.lblSummaryPrice.Location=New Drawing.Point(25,35)
        Me.lblSummaryPrice.Text="Vehicle Price"
        Me.lblSubtotal.AutoSize=True
        Me.lblSubtotal.Location=New Drawing.Point(230,35)
        Me.lblSubtotal.Font=New Drawing.Font("Segoe UI",10.0!,Drawing.FontStyle.Bold)
        Me.lblSubtotal.Text="₱ 0.00"
        Me.lblSummaryDiscount.AutoSize=True
        Me.lblSummaryDiscount.Location=New Drawing.Point(25,68)
        Me.lblSummaryDiscount.Text="Discount"
        Me.lblDiscount.AutoSize=True
        Me.lblDiscount.Location=New Drawing.Point(230,68)
        Me.lblDiscount.Text="₱ 0.00"
        Me.lblSummaryTax.AutoSize=True
        Me.lblSummaryTax.Location=New Drawing.Point(25,101)
        Me.lblSummaryTax.Text="Tax"
        Me.lblTax.AutoSize=True
        Me.lblTax.Location=New Drawing.Point(230,101)
        Me.lblTax.Text="₱ 0.00"
        Me.lblSummaryTotal.AutoSize=True
        Me.lblSummaryTotal.Location=New Drawing.Point(25,139)
        Me.lblSummaryTotal.Text="TOTAL"
        Me.lblSummaryTotal.Font=New Drawing.Font("Segoe UI",12.0!,Drawing.FontStyle.Bold)
        Me.lblTotal.AutoSize=True
        Me.lblTotal.Location=New Drawing.Point(205,134)
        Me.lblTotal.Font=New Drawing.Font("Segoe UI",16.0!,Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor=Drawing.Color.FromArgb(20,110,70)
        Me.lblTotal.Text="₱ 0.00"
        Me.lblSummaryChange.AutoSize=True
        Me.lblSummaryChange.Location=New Drawing.Point(25,177)
        Me.lblSummaryChange.Text="Change"
        Me.lblChange.AutoSize=True
        Me.lblChange.Location=New Drawing.Point(230,177)
        Me.lblChange.Font=New Drawing.Font("Segoe UI",10.0!,Drawing.FontStyle.Bold)
        Me.lblChange.Text="₱ 0.00"
        Me.grpSummary.Controls.Add(Me.lblSummaryPrice)
        Me.grpSummary.Controls.Add(Me.lblSubtotal)
        Me.grpSummary.Controls.Add(Me.lblSummaryDiscount)
        Me.grpSummary.Controls.Add(Me.lblDiscount)
        Me.grpSummary.Controls.Add(Me.lblSummaryTax)
        Me.grpSummary.Controls.Add(Me.lblTax)
        Me.grpSummary.Controls.Add(Me.lblSummaryTotal)
        Me.grpSummary.Controls.Add(Me.lblTotal)
        Me.grpSummary.Controls.Add(Me.lblSummaryChange)
        Me.grpSummary.Controls.Add(Me.lblChange)
        Me.btnQuote.Location=New Drawing.Point(720,670)
        Me.btnQuote.Size=New Drawing.Size(155,44)
        Me.btnQuote.Text="Save Quotation"
        Me.btnFinalize.Location=New Drawing.Point(890,670)
        Me.btnFinalize.Size=New Drawing.Size(240,44)
        Me.btnFinalize.Text="Finalize Sale"
        Me.btnFinalize.BackColor=Drawing.Color.FromArgb(40,137,75)
        Me.btnFinalize.ForeColor=Drawing.Color.White
        Me.AutoScaleMode=AutoScaleMode.Font
        Me.BackColor=Drawing.Color.FromArgb(244,247,250)
        Me.ClientSize=New Drawing.Size(1175,760)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.cbCustomer)
        Me.Controls.Add(Me.lblVehicle)
        Me.Controls.Add(Me.cbVehicle)
        Me.Controls.Add(Me.grpVehiclePreview)
        Me.Controls.Add(Me.lblDiscountCaption)
        Me.Controls.Add(Me.numDiscount)
        Me.Controls.Add(Me.lblPlan)
        Me.Controls.Add(Me.cbPlan)
        Me.Controls.Add(Me.lblInitial)
        Me.Controls.Add(Me.numInitial)
        Me.Controls.Add(Me.lblMethod)
        Me.Controls.Add(Me.cbMethod)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.grpSummary)
        Me.Controls.Add(Me.btnQuote)
        Me.Controls.Add(Me.btnFinalize)
        Me.Font=New Drawing.Font("Segoe UI",10.0!)
        Me.Text="Point of Sale"
        CType(Me.numDiscount,System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numInitial,System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPosVehicle,System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVehiclePreview.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
