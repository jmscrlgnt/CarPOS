Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports CarDealershipPOS.Models
Imports CarDealershipPOS.Services
Imports CarDealershipPOS.Utilities

Namespace CarDealershipPOS
    Public Partial Class InventoryForm
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            UiTheme.StyleGrid(gridVehicles)
            gridVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            gridVehicles.MultiSelect = False
            btnAdd.Enabled = SessionContext.IsAdministrator
            btnEdit.Enabled = SessionContext.IsAdministrator
            btnDeactivate.Enabled = SessionContext.IsAdministrator
            btnSeed.Visible = SessionContext.IsAdministrator
            cbCondition.SelectedIndex = 0
            cbStatus.SelectedIndex = 1
            RefreshGrid()
        End Sub

        Private Sub RefreshGrid()
            gridVehicles.DataSource = New InventoryService().Search(txtSearch.Text, CStr(cbCondition.SelectedItem), CStr(cbStatus.SelectedItem))
            ConfigureInventoryGrid()
            gridVehicles.ClearSelection()
            ClearPreview()
        End Sub

        Private Sub ConfigureInventoryGrid()
            If gridVehicles.Columns.Contains("Id") Then gridVehicles.Columns("Id").Visible = False
            If gridVehicles.Columns.Contains("StockNumber") Then gridVehicles.Columns("StockNumber").HeaderText = "Stock Number"
            If gridVehicles.Columns.Contains("Variant") Then gridVehicles.Columns("Variant").HeaderText = "Trim"
            If gridVehicles.Columns.Contains("Mileage") Then
                gridVehicles.Columns("Mileage").HeaderText = "Mileage (km)"
                gridVehicles.Columns("Mileage").DefaultCellStyle.Format = "N0"
            End If
            If gridVehicles.Columns.Contains("Price") Then
                gridVehicles.Columns("Price").HeaderText = "Price"
                gridVehicles.Columns("Price").DefaultCellStyle.Format = "₱ #,##0.00"
            End If
        End Sub

        Private Function SelectedId() As Long
            If gridVehicles.SelectedRows.Count = 0 Then Return 0
            Dim value As Object = gridVehicles.SelectedRows(0).Cells("Id").Value
            If value Is Nothing OrElse value Is DBNull.Value Then Return 0
            Return Convert.ToInt64(value)
        End Function

        Private Sub gridVehicles_SelectionChanged(sender As Object, e As EventArgs) Handles gridVehicles.SelectionChanged
            UpdatePreview()
        End Sub

        Private Sub UpdatePreview()
            Dim id As Long = SelectedId()
            If id = 0 Then
                ClearPreview()
                Return
            End If

            Dim vehicle As Vehicle = New InventoryService().GetById(id)
            If vehicle Is Nothing Then
                ClearPreview()
                Return
            End If

            DisposePreviewImage()
            picVehiclePreview.Image = VehicleImageStorage.LoadImageClone(vehicle.ImagePath)
            lblNoImage.Visible = picVehiclePreview.Image Is Nothing
            lblPreviewName.Text = String.Format("{0} {1} {2}", vehicle.ModelYear, vehicle.Brand, vehicle.Model)
            lblPreviewStock.Text = "Stock: " & vehicle.StockNumber
            lblPreviewDetails.Text = String.Format("{0} · {1} · {2:N0} km", vehicle.Condition, If(String.IsNullOrWhiteSpace(vehicle.Color), "No color", vehicle.Color), vehicle.MileageKm)
            lblPreviewPrice.Text = "₱ " & vehicle.SellingPrice.ToString("N2")
            lblPreviewStatus.Text = vehicle.Status
            lblPreviewStatus.ForeColor = If(vehicle.Status = "Available", Drawing.Color.ForestGreen, If(vehicle.Status = "Sold", Drawing.Color.Firebrick, Drawing.Color.DarkOrange))
        End Sub

        Private Sub ClearPreview()
            DisposePreviewImage()
            lblNoImage.Visible = True
            lblPreviewName.Text = "Select a vehicle"
            lblPreviewStock.Text = "Stock: —"
            lblPreviewDetails.Text = "Condition · Color · Mileage"
            lblPreviewPrice.Text = "₱ 0.00"
            lblPreviewStatus.Text = "—"
            lblPreviewStatus.ForeColor = Drawing.Color.DimGray
        End Sub

        Private Sub DisposePreviewImage()
            If picVehiclePreview.Image Is Nothing Then Return
            Dim oldImage As Image = picVehiclePreview.Image
            picVehiclePreview.Image = Nothing
            oldImage.Dispose()
        End Sub

        Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            RefreshGrid()
        End Sub

        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Using form As New VehicleEditorForm()
                If form.ShowDialog() = DialogResult.OK Then RefreshGrid()
            End Using
        End Sub

        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            Dim id As Long = SelectedId()
            If id = 0 Then
                MessageBox.Show("Select a vehicle first.")
                Return
            End If
            Using form As New VehicleEditorForm(id)
                If form.ShowDialog() = DialogResult.OK Then RefreshGrid()
            End Using
        End Sub

        Private Sub btnDeactivate_Click(sender As Object, e As EventArgs) Handles btnDeactivate.Click
            Dim id As Long = SelectedId()
            If id = 0 Then
                MessageBox.Show("Select a vehicle first.")
                Return
            End If
            If MessageBox.Show("Mark the selected vehicle inactive?", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
            Dim err As String = New InventoryService().SetInactive(id)
            If err IsNot Nothing Then MessageBox.Show(err, "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RefreshGrid()
        End Sub

        Private Sub btnSeed_Click(sender As Object, e As EventArgs) Handles btnSeed.Click
            Dim inventoryService As New InventoryService()
            inventoryService.SeedDemoInventory()
            RefreshGrid()
            MessageBox.Show("Demo inventory is available. Existing inventory was not overwritten.")
        End Sub

        Private Sub InventoryForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
            DisposePreviewImage()
        End Sub
    End Class
End Namespace
