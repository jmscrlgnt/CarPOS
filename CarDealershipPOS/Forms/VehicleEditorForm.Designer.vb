Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VehicleEditorForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblStock As Label
    Friend WithEvents lblVin As Label
    Friend WithEvents lblBrand As Label
    Friend WithEvents lblModel As Label
    Friend WithEvents lblVariant As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents lblColor As Label
    Friend WithEvents lblCondition As Label
    Friend WithEvents lblMileage As Label
    Friend WithEvents lblCost As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents lblImage As Label
    Friend WithEvents lblNotes As Label
    Friend WithEvents lblNoImage As Label
    Friend WithEvents txtStock As TextBox
    Friend WithEvents txtVin As TextBox
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents txtModel As TextBox
    Friend WithEvents txtVariant As TextBox
    Friend WithEvents txtColor As TextBox
    Friend WithEvents txtImage As TextBox
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents cbCondition As ComboBox
    Friend WithEvents numYear As NumericUpDown
    Friend WithEvents numMileage As NumericUpDown
    Friend WithEvents numCost As NumericUpDown
    Friend WithEvents numPrice As NumericUpDown
    Friend WithEvents picVehicle As PictureBox
    Friend WithEvents btnChooseImage As Button
    Friend WithEvents btnRemoveImage As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
        Me.lblTitle = New Label()
        Me.lblStock = New Label()
        Me.lblVin = New Label()
        Me.lblBrand = New Label()
        Me.lblModel = New Label()
        Me.lblVariant = New Label()
        Me.lblYear = New Label()
        Me.lblColor = New Label()
        Me.lblCondition = New Label()
        Me.lblMileage = New Label()
        Me.lblCost = New Label()
        Me.lblPrice = New Label()
        Me.lblImage = New Label()
        Me.lblNotes = New Label()
        Me.lblNoImage = New Label()
        Me.txtStock = New TextBox()
        Me.txtVin = New TextBox()
        Me.txtBrand = New TextBox()
        Me.txtModel = New TextBox()
        Me.txtVariant = New TextBox()
        Me.txtColor = New TextBox()
        Me.txtImage = New TextBox()
        Me.txtNotes = New TextBox()
        Me.cbCondition = New ComboBox()
        Me.numYear = New NumericUpDown()
        Me.numMileage = New NumericUpDown()
        Me.numCost = New NumericUpDown()
        Me.numPrice = New NumericUpDown()
        Me.picVehicle = New PictureBox()
        Me.btnChooseImage = New Button()
        Me.btnRemoveImage = New Button()
        Me.btnSave = New Button()
        Me.btnCancel = New Button()
        CType(Me.numYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMileage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVehicle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New Drawing.Font("Segoe UI", 20.0!, Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New Drawing.Point(30, 22)
        Me.lblTitle.Text = "Vehicle Details"
        Me.lblStock.AutoSize = True
        Me.lblStock.Location = New Drawing.Point(35, 85)
        Me.lblStock.Text = "Stock Number *"
        Me.lblVin.AutoSize = True
        Me.lblVin.Location = New Drawing.Point(415, 85)
        Me.lblVin.Text = "VIN"
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Location = New Drawing.Point(35, 155)
        Me.lblBrand.Text = "Brand *"
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New Drawing.Point(415, 155)
        Me.lblModel.Text = "Model *"
        Me.lblVariant.AutoSize = True
        Me.lblVariant.Location = New Drawing.Point(35, 225)
        Me.lblVariant.Text = "Variant"
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New Drawing.Point(415, 225)
        Me.lblYear.Text = "Model Year *"
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New Drawing.Point(35, 295)
        Me.lblColor.Text = "Color"
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Location = New Drawing.Point(415, 295)
        Me.lblCondition.Text = "Condition *"
        Me.lblMileage.AutoSize = True
        Me.lblMileage.Location = New Drawing.Point(35, 365)
        Me.lblMileage.Text = "Mileage (km)"
        Me.lblCost.AutoSize = True
        Me.lblCost.Location = New Drawing.Point(415, 365)
        Me.lblCost.Text = "Cost Price"
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New Drawing.Point(35, 435)
        Me.lblPrice.Text = "Selling Price *"
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New Drawing.Point(35, 505)
        Me.lblNotes.Text = "Notes"
        Me.lblImage.AutoSize = True
        Me.lblImage.Location = New Drawing.Point(790, 85)
        Me.lblImage.Text = "Vehicle Image"
        Me.txtStock.Location = New Drawing.Point(35, 110)
        Me.txtStock.Size = New Drawing.Size(330, 29)
        Me.txtVin.Location = New Drawing.Point(415, 110)
        Me.txtVin.Size = New Drawing.Size(330, 29)
        Me.txtBrand.Location = New Drawing.Point(35, 180)
        Me.txtBrand.Size = New Drawing.Size(330, 29)
        Me.txtModel.Location = New Drawing.Point(415, 180)
        Me.txtModel.Size = New Drawing.Size(330, 29)
        Me.txtVariant.Location = New Drawing.Point(35, 250)
        Me.txtVariant.Size = New Drawing.Size(330, 29)
        Me.numYear.Location = New Drawing.Point(415, 250)
        Me.numYear.Size = New Drawing.Size(330, 29)
        Me.txtColor.Location = New Drawing.Point(35, 320)
        Me.txtColor.Size = New Drawing.Size(330, 29)
        Me.cbCondition.Location = New Drawing.Point(415, 320)
        Me.cbCondition.Size = New Drawing.Size(330, 29)
        Me.cbCondition.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cbCondition.Items.AddRange(New Object() {"New", "Used"})
        Me.numMileage.Location = New Drawing.Point(35, 390)
        Me.numMileage.Size = New Drawing.Size(330, 29)
        Me.numMileage.Maximum = 1000000
        Me.numCost.Location = New Drawing.Point(415, 390)
        Me.numCost.Size = New Drawing.Size(330, 29)
        Me.numCost.Maximum = 100000000
        Me.numCost.DecimalPlaces = 2
        Me.numCost.ThousandsSeparator = True
        Me.numPrice.Location = New Drawing.Point(35, 460)
        Me.numPrice.Size = New Drawing.Size(330, 29)
        Me.numPrice.Maximum = 100000000
        Me.numPrice.DecimalPlaces = 2
        Me.numPrice.ThousandsSeparator = True
        Me.txtNotes.Location = New Drawing.Point(35, 530)
        Me.txtNotes.Size = New Drawing.Size(710, 75)
        Me.txtNotes.Multiline = True
        Me.txtImage.Location = New Drawing.Point(790, 385)
        Me.txtImage.Size = New Drawing.Size(285, 29)
        Me.txtImage.ReadOnly = True
        Me.txtImage.Visible = False
        Me.picVehicle.Location = New Drawing.Point(790, 110)
        Me.picVehicle.Size = New Drawing.Size(285, 210)
        Me.picVehicle.BorderStyle = BorderStyle.FixedSingle
        Me.picVehicle.BackColor = Drawing.Color.White
        Me.picVehicle.SizeMode = PictureBoxSizeMode.Zoom
        Me.lblNoImage.AutoSize = False
        Me.lblNoImage.Location = New Drawing.Point(810, 190)
        Me.lblNoImage.Size = New Drawing.Size(245, 50)
        Me.lblNoImage.Text = "No image selected"
        Me.lblNoImage.TextAlign = Drawing.ContentAlignment.MiddleCenter
        Me.lblNoImage.ForeColor = Drawing.Color.DimGray
        Me.btnChooseImage.Location = New Drawing.Point(790, 335)
        Me.btnChooseImage.Size = New Drawing.Size(135, 36)
        Me.btnChooseImage.Text = "Choose Image"
        Me.btnChooseImage.BackColor = Drawing.Color.FromArgb(39, 137, 216)
        Me.btnChooseImage.ForeColor = Drawing.Color.White
        Me.btnChooseImage.FlatStyle = FlatStyle.Flat
        Me.btnRemoveImage.Location = New Drawing.Point(940, 335)
        Me.btnRemoveImage.Size = New Drawing.Size(135, 36)
        Me.btnRemoveImage.Text = "Remove Image"
        Me.btnCancel.Location = New Drawing.Point(860, 630)
        Me.btnCancel.Size = New Drawing.Size(100, 38)
        Me.btnCancel.Text = "Cancel"
        Me.btnSave.Location = New Drawing.Point(970, 630)
        Me.btnSave.Size = New Drawing.Size(110, 38)
        Me.btnSave.Text = "Save Vehicle"
        Me.btnSave.BackColor = Drawing.Color.FromArgb(39, 137, 216)
        Me.btnSave.ForeColor = Drawing.Color.White
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Drawing.Size(1115, 700)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.lblVin)
        Me.Controls.Add(Me.lblBrand)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.lblVariant)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.lblCondition)
        Me.Controls.Add(Me.lblMileage)
        Me.Controls.Add(Me.lblCost)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.lblImage)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.txtVin)
        Me.Controls.Add(Me.txtBrand)
        Me.Controls.Add(Me.txtModel)
        Me.Controls.Add(Me.txtVariant)
        Me.Controls.Add(Me.numYear)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.cbCondition)
        Me.Controls.Add(Me.numMileage)
        Me.Controls.Add(Me.numCost)
        Me.Controls.Add(Me.numPrice)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtImage)
        Me.Controls.Add(Me.picVehicle)
        Me.Controls.Add(Me.lblNoImage)
        Me.Controls.Add(Me.btnChooseImage)
        Me.Controls.Add(Me.btnRemoveImage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New Drawing.Font("Segoe UI", 10.0!)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "Vehicle"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        CType(Me.numYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMileage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVehicle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
