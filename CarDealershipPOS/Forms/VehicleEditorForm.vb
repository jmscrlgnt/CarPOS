Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports CarDealershipPOS.Models
Imports CarDealershipPOS.Services
Imports CarDealershipPOS.Utilities

Namespace CarDealershipPOS
    Public Partial Class VehicleEditorForm
        Private _id As Long
        Private _existingImagePath As String
        Private _pendingImageSource As String
        Private _removeImage As Boolean

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(id As Long)
            InitializeComponent()
            _id = id
        End Sub

        Private Sub VehicleEditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cbCondition.SelectedIndex = 0
            numYear.Minimum = 1950
            numYear.Maximum = DateTime.Today.Year + 2
            numYear.Value = DateTime.Today.Year
            ShowImagePreview(Nothing)

            If _id = 0 Then Return

            Dim v As Vehicle = New InventoryService().GetById(_id)
            If v Is Nothing Then Return

            txtStock.Text = v.StockNumber
            txtVin.Text = v.Vin
            txtBrand.Text = v.Brand
            txtModel.Text = v.Model
            txtVariant.Text = v.TrimLevel
            numYear.Value = v.ModelYear
            txtColor.Text = v.Color
            cbCondition.SelectedItem = v.Condition
            numMileage.Value = Math.Min(numMileage.Maximum, v.MileageKm)
            numCost.Value = Math.Min(numCost.Maximum, v.CostPrice)
            numPrice.Value = Math.Min(numPrice.Maximum, v.SellingPrice)
            _existingImagePath = v.ImagePath
            txtImage.Text = If(v.ImagePath, String.Empty)
            txtNotes.Text = v.Notes
            ShowImagePreview(v.ImagePath)
        End Sub

        Private Sub btnChooseImage_Click(sender As Object, e As EventArgs) Handles btnChooseImage.Click
            Using dialog As New OpenFileDialog() With {
                .Filter = "Supported Images|*.jpg;*.jpeg;*.png;*.bmp;*.gif|JPEG Images|*.jpg;*.jpeg|PNG Images|*.png|Bitmap Images|*.bmp|GIF Images|*.gif",
                .Title = "Choose vehicle image"
            }
                If dialog.ShowDialog() <> DialogResult.OK Then Return
                If Not ShowImagePreview(dialog.FileName) Then
                    MessageBox.Show("The selected file could not be displayed as an image.", "Vehicle Image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                _pendingImageSource = dialog.FileName
                _removeImage = False
                txtImage.Text = dialog.FileName
            End Using
        End Sub

        Private Sub btnRemoveImage_Click(sender As Object, e As EventArgs) Handles btnRemoveImage.Click
            _pendingImageSource = Nothing
            _removeImage = True
            txtImage.Clear()
            ShowImagePreview(Nothing)
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Dim finalImagePath As String = _existingImagePath
            Dim copiedImagePath As String = Nothing

            Try
                If _removeImage Then finalImagePath = Nothing
                If Not String.IsNullOrWhiteSpace(_pendingImageSource) Then
                    copiedImagePath = VehicleImageStorage.CopyIntoLibrary(_pendingImageSource, txtStock.Text)
                    finalImagePath = copiedImagePath
                End If

                Dim vehicle As New Vehicle With {
                    .Id = _id,
                    .StockNumber = txtStock.Text,
                    .Vin = txtVin.Text,
                    .Brand = txtBrand.Text,
                    .Model = txtModel.Text,
                    .TrimLevel = txtVariant.Text,
                    .ModelYear = CInt(numYear.Value),
                    .Color = txtColor.Text,
                    .Condition = CStr(cbCondition.SelectedItem),
                    .MileageKm = CInt(numMileage.Value),
                    .CostPrice = numCost.Value,
                    .SellingPrice = numPrice.Value,
                    .ImagePath = finalImagePath,
                    .Notes = txtNotes.Text
                }

                Dim err As String = New InventoryService().Save(vehicle)
                If err IsNot Nothing Then
                    If copiedImagePath IsNot Nothing Then VehicleImageStorage.DeleteManagedImage(copiedImagePath)
                    MessageBox.Show(err, "Vehicle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                If Not String.IsNullOrWhiteSpace(_existingImagePath) AndAlso Not String.Equals(_existingImagePath, finalImagePath, StringComparison.OrdinalIgnoreCase) Then
                    VehicleImageStorage.DeleteManagedImage(_existingImagePath)
                End If

                _existingImagePath = finalImagePath
                DialogResult = DialogResult.OK
                Close()
            Catch ex As Exception
                If copiedImagePath IsNot Nothing Then VehicleImageStorage.DeleteManagedImage(copiedImagePath)
                MessageBox.Show(ex.Message, "Vehicle Image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Function ShowImagePreview(imagePath As String) As Boolean
            If picVehicle.Image IsNot Nothing Then
                Dim oldImage As Image = picVehicle.Image
                picVehicle.Image = Nothing
                oldImage.Dispose()
            End If

            Dim image As Image = VehicleImageStorage.LoadImageClone(imagePath)
            If image Is Nothing Then
                lblNoImage.Visible = True
                Return String.IsNullOrWhiteSpace(imagePath)
            End If

            picVehicle.Image = image
            lblNoImage.Visible = False
            Return True
        End Function

        Private Sub VehicleEditorForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
            If picVehicle.Image IsNot Nothing Then picVehicle.Image.Dispose()
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            DialogResult = DialogResult.Cancel
            Close()
        End Sub
    End Class
End Namespace
