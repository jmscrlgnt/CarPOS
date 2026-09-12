Namespace CarDealershipPOS
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents lblCondition As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cbCondition As ComboBox
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDeactivate As Button
    Friend WithEvents btnSeed As Button
    Friend WithEvents gridVehicles As DataGridView
    Friend WithEvents grpPreview As GroupBox
    Friend WithEvents picVehiclePreview As PictureBox
    Friend WithEvents lblNoImage As Label
    Friend WithEvents lblPreviewName As Label
    Friend WithEvents lblPreviewStock As Label
    Friend WithEvents lblPreviewDetails As Label
    Friend WithEvents lblPreviewPrice As Label
    Friend WithEvents lblPreviewStatus As Label

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
        Me.lblTitle = New Label()
        Me.lblSearch = New Label()
        Me.lblCondition = New Label()
        Me.lblStatus = New Label()
        Me.txtSearch = New TextBox()
        Me.cbCondition = New ComboBox()
        Me.cbStatus = New ComboBox()
        Me.btnSearch = New Button()
        Me.btnAdd = New Button()
        Me.btnEdit = New Button()
        Me.btnDeactivate = New Button()
        Me.btnSeed = New Button()
        Me.gridVehicles = New DataGridView()
        Me.grpPreview = New GroupBox()
        Me.picVehiclePreview = New PictureBox()
        Me.lblNoImage = New Label()
        Me.lblPreviewName = New Label()
        Me.lblPreviewStock = New Label()
        Me.lblPreviewDetails = New Label()
        Me.lblPreviewPrice = New Label()
        Me.lblPreviewStatus = New Label()
        CType(Me.gridVehicles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVehiclePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPreview.SuspendLayout()
        Me.SuspendLayout()
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New Drawing.Font("Segoe UI", 22.0!, Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New Drawing.Point(30, 25)
        Me.lblTitle.Text = "Vehicle Inventory"
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New Drawing.Point(35, 105)
        Me.lblSearch.Text = "Search"
        Me.txtSearch.Location = New Drawing.Point(35, 130)
        Me.txtSearch.Size = New Drawing.Size(330, 30)
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Location = New Drawing.Point(380, 105)
        Me.lblCondition.Text = "Condition"
        Me.cbCondition.Location = New Drawing.Point(380, 130)
        Me.cbCondition.Size = New Drawing.Size(145, 30)
        Me.cbCondition.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cbCondition.Items.AddRange(New Object() {"All", "New", "Used"})
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New Drawing.Point(540, 105)
        Me.lblStatus.Text = "Status"
        Me.cbStatus.Location = New Drawing.Point(540, 130)
        Me.cbStatus.Size = New Drawing.Size(145, 30)
        Me.cbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cbStatus.Items.AddRange(New Object() {"All", "Available", "Reserved", "Sold", "Inactive"})
        Me.btnSearch.Location = New Drawing.Point(700, 128)
        Me.btnSearch.Size = New Drawing.Size(95, 34)
        Me.btnSearch.Text = "Search"
        Me.btnSearch.BackColor = Drawing.Color.FromArgb(39, 137, 216)
        Me.btnSearch.ForeColor = Drawing.Color.White
        Me.btnSearch.FlatStyle = FlatStyle.Flat
        Me.btnAdd.Location = New Drawing.Point(820, 128)
        Me.btnAdd.Size = New Drawing.Size(105, 34)
        Me.btnAdd.Text = "Add Vehicle"
        Me.btnEdit.Location = New Drawing.Point(935, 128)
        Me.btnEdit.Size = New Drawing.Size(80, 34)
        Me.btnEdit.Text = "Edit"
        Me.btnDeactivate.Location = New Drawing.Point(1025, 128)
        Me.btnDeactivate.Size = New Drawing.Size(105, 34)
        Me.btnDeactivate.Text = "Deactivate"
        Me.btnDeactivate.BackColor = Drawing.Color.Firebrick
        Me.btnDeactivate.ForeColor = Drawing.Color.White
        Me.btnSeed.Location = New Drawing.Point(35, 180)
        Me.btnSeed.Size = New Drawing.Size(160, 34)
        Me.btnSeed.Text = "Load Demo Inventory"
        Me.gridVehicles.Location = New Drawing.Point(35, 230)
        Me.gridVehicles.Size = New Drawing.Size(735, 480)
        Me.gridVehicles.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Me.gridVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.gridVehicles.MultiSelect = False
        Me.grpPreview.Location = New Drawing.Point(790, 230)
        Me.grpPreview.Size = New Drawing.Size(340, 480)
        Me.grpPreview.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        Me.grpPreview.Text = "Vehicle Preview"
        Me.picVehiclePreview.Location = New Drawing.Point(20, 35)
        Me.picVehiclePreview.Size = New Drawing.Size(300, 205)
        Me.picVehiclePreview.BorderStyle = BorderStyle.FixedSingle
        Me.picVehiclePreview.BackColor = Drawing.Color.White
        Me.picVehiclePreview.SizeMode = PictureBoxSizeMode.Zoom
        Me.lblNoImage.AutoSize = False
        Me.lblNoImage.Location = New Drawing.Point(60, 105)
        Me.lblNoImage.Size = New Drawing.Size(220, 60)
        Me.lblNoImage.Text = "No image available"
        Me.lblNoImage.TextAlign = Drawing.ContentAlignment.MiddleCenter
        Me.lblNoImage.ForeColor = Drawing.Color.DimGray
        Me.lblPreviewName.AutoSize = False
        Me.lblPreviewName.Location = New Drawing.Point(20, 260)
        Me.lblPreviewName.Size = New Drawing.Size(300, 48)
        Me.lblPreviewName.Font = New Drawing.Font("Segoe UI", 13.0!, Drawing.FontStyle.Bold)
        Me.lblPreviewName.Text = "Select a vehicle"
        Me.lblPreviewStock.AutoSize = False
        Me.lblPreviewStock.Location = New Drawing.Point(20, 315)
        Me.lblPreviewStock.Size = New Drawing.Size(300, 26)
        Me.lblPreviewStock.Text = "Stock: —"
        Me.lblPreviewDetails.AutoSize = False
        Me.lblPreviewDetails.Location = New Drawing.Point(20, 350)
        Me.lblPreviewDetails.Size = New Drawing.Size(300, 48)
        Me.lblPreviewDetails.Text = "Condition · Color · Mileage"
        Me.lblPreviewPrice.AutoSize = False
        Me.lblPreviewPrice.Location = New Drawing.Point(20, 405)
        Me.lblPreviewPrice.Size = New Drawing.Size(190, 34)
        Me.lblPreviewPrice.Font = New Drawing.Font("Segoe UI", 14.0!, Drawing.FontStyle.Bold)
        Me.lblPreviewPrice.ForeColor = Drawing.Color.FromArgb(16, 73, 115)
        Me.lblPreviewPrice.Text = "₱ 0.00"
        Me.lblPreviewStatus.AutoSize = False
        Me.lblPreviewStatus.Location = New Drawing.Point(220, 405)
        Me.lblPreviewStatus.Size = New Drawing.Size(100, 34)
        Me.lblPreviewStatus.Font = New Drawing.Font("Segoe UI", 10.0!, Drawing.FontStyle.Bold)
        Me.lblPreviewStatus.TextAlign = Drawing.ContentAlignment.MiddleRight
        Me.lblPreviewStatus.Text = "—"
        Me.grpPreview.Controls.Add(Me.picVehiclePreview)
        Me.grpPreview.Controls.Add(Me.lblNoImage)
        Me.grpPreview.Controls.Add(Me.lblPreviewName)
        Me.grpPreview.Controls.Add(Me.lblPreviewStock)
        Me.grpPreview.Controls.Add(Me.lblPreviewDetails)
        Me.grpPreview.Controls.Add(Me.lblPreviewPrice)
        Me.grpPreview.Controls.Add(Me.lblPreviewStatus)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Drawing.Color.FromArgb(244, 247, 250)
        Me.ClientSize = New Drawing.Size(1175, 760)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblCondition)
        Me.Controls.Add(Me.cbCondition)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cbStatus)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDeactivate)
        Me.Controls.Add(Me.btnSeed)
        Me.Controls.Add(Me.gridVehicles)
        Me.Controls.Add(Me.grpPreview)
        Me.Font = New Drawing.Font("Segoe UI", 10.0!)
        Me.Text = "Inventory"
        CType(Me.gridVehicles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVehiclePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPreview.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
End Namespace
