Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports CarDealershipPOS.Services
Imports CarDealershipPOS.Utilities

Namespace CarDealershipPOS
    Public Partial Class PosForm
        Private _quotationId As Long
        Private _loadingSelections As Boolean

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(quotationId As Long)
            InitializeComponent()
            _quotationId = quotationId
        End Sub

        Private Sub PosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _loadingSelections = True
            Try
                cbPlan.Items.Clear()
                cbPlan.Items.AddRange(New Object() {"Full", "Installment"})
                cbPlan.SelectedIndex = 0

                cbMethod.Items.Clear()
                cbMethod.Items.AddRange(New Object() {"Cash", "Bank Transfer", "Card", "Financing"})
                cbMethod.SelectedIndex = 0

                numDiscount.Maximum = 100000000D
                numInitial.Maximum = 100000000D
                LoadSelections()
            Finally
                _loadingSelections = False
            End Try

            If _quotationId <> 0 Then
                LoadQuotation(_quotationId)
            Else
                Recalculate()
                UpdateActionState()
            End If
        End Sub

        Private Sub LoadSelections()
            Dim previousLoading = _loadingSelections
            _loadingSelections = True

            Try
                Dim customers = New CustomerService().Search("", False)
                cbCustomer.DataSource = Nothing
                cbCustomer.DisplayMember = "Customer"
                cbCustomer.ValueMember = "Id"
                cbCustomer.DataSource = customers
                cbCustomer.SelectedIndex = -1

                Dim vehicles = New InventoryService().AvailableForSelection()
                cbVehicle.DataSource = Nothing
                cbVehicle.DisplayMember = "Display"
                cbVehicle.ValueMember = "Id"
                cbVehicle.DataSource = vehicles
                cbVehicle.SelectedIndex = -1
            Finally
                _loadingSelections = previousLoading
            End Try

            If Not _loadingSelections Then
                UpdateActionState()
                Recalculate()
            End If
        End Sub

        Private Sub LoadQuotation(id As Long)
            Dim row = New QuotationService().GetCheckoutData(id)
            If row Is Nothing Then
                MessageBox.Show("Quotation not found.")
                Return
            End If

            If CStr(row("Status")) = "Converted" OrElse CStr(row("Status")) = "Cancelled" Then
                MessageBox.Show("This quotation can no longer be converted.")
                Return
            End If

            _loadingSelections = True
            Try
                cbCustomer.SelectedValue = CLng(row("CustomerId"))
                cbVehicle.SelectedValue = CLng(row("VehicleId"))
                numDiscount.Value = CDec(row("Discount"))
            Finally
                _loadingSelections = False
            End Try

            btnQuote.Enabled = False
            Recalculate()
            UpdateActionState()
        End Sub

        Private Shared Function SelectedBoundId(combo As ComboBox) As Long
            If combo Is Nothing Then Return 0

            Dim value = combo.SelectedValue
            If value Is Nothing OrElse value Is DBNull.Value Then Return 0

            ' During WinForms data binding SelectedValue can briefly be the row itself.
            ' That is not a valid bound ID and must never be cast directly to Long.
            If TypeOf value Is DataRowView Then Return 0

            Dim id As Long
            If Long.TryParse(Convert.ToString(value), id) Then Return id
            Return 0
        End Function

        Private Function SelectedCustomerId() As Long
            Return SelectedBoundId(cbCustomer)
        End Function

        Private Function SelectedVehicleId() As Long
            Return SelectedBoundId(cbVehicle)
        End Function

        Private Sub UpdateActionState()
            Dim hasValidSelection = SelectedCustomerId() > 0 AndAlso SelectedVehicleId() > 0
            btnQuote.Enabled = hasValidSelection AndAlso _quotationId = 0
            btnFinalize.Enabled = hasValidSelection
        End Sub

        Private Sub Recalculate()
            If _loadingSelections Then Return

            Dim vehicle = New InventoryService().GetById(SelectedVehicleId())
            If vehicle Is Nothing Then
                ClearVehiclePreview()
                lblSubtotal.Text = "₱ 0.00"
                lblDiscount.Text = "₱ 0.00"
                lblTax.Text = "₱ 0.00"
                lblTotal.Text = "₱ 0.00"
                lblChange.Text = "₱ 0.00"
                UpdateActionState()
                Return
            End If

            UpdateVehiclePreview(vehicle)
            Dim calc = New SalesService().CalculateTotal(vehicle.SellingPrice, numDiscount.Value)
            lblSubtotal.Text = "₱ " & calc.Subtotal.ToString("N2")
            lblDiscount.Text = "₱ " & calc.Discount.ToString("N2")
            lblTax.Text = "₱ " & calc.TaxAmount.ToString("N2") & " (" & calc.TaxRate.ToString("0.##") & "%)"
            lblTotal.Text = "₱ " & calc.Total.ToString("N2")

            numInitial.Maximum = Math.Max(100000000D, calc.Total * 2D)
            If CStr(cbPlan.SelectedItem) = "Full" AndAlso numInitial.Value < calc.Total Then
                numInitial.Value = calc.Total
            End If

            UpdateChange(calc.Total)
            UpdateActionState()
        End Sub

        Private Sub cbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomer.SelectedIndexChanged
            If _loadingSelections Then Return
            UpdateActionState()
        End Sub

        Private Sub cbVehicle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbVehicle.SelectedIndexChanged
            If _loadingSelections Then Return
            Recalculate()
            UpdateActionState()
        End Sub

        Private Sub numDiscount_ValueChanged(sender As Object, e As EventArgs) Handles numDiscount.ValueChanged
            If _loadingSelections Then Return
            Recalculate()
        End Sub

        Private Sub cbPlan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPlan.SelectedIndexChanged
            If _loadingSelections Then Return
            Recalculate()
            numInitial.Enabled = True
        End Sub

        Private Sub numInitial_ValueChanged(sender As Object, e As EventArgs) Handles numInitial.ValueChanged
            If _loadingSelections Then Return

            Dim vehicle = New InventoryService().GetById(SelectedVehicleId())
            If vehicle Is Nothing Then
                lblChange.Text = "₱ 0.00"
                Return
            End If

            Dim calc = New SalesService().CalculateTotal(vehicle.SellingPrice, numDiscount.Value)
            UpdateChange(calc.Total)
        End Sub

        Private Sub UpdateChange(total As Decimal)
            If CStr(cbPlan.SelectedItem) = "Full" Then
                lblChange.Text = "₱ " & Math.Max(0D, numInitial.Value - total).ToString("N2")
            Else
                lblChange.Text = "—"
            End If
        End Sub

        Private Sub UpdateVehiclePreview(vehicle As Models.Vehicle)
            DisposeVehiclePreviewImage()
            picPosVehicle.Image = VehicleImageStorage.LoadImageClone(vehicle.ImagePath)
            lblPosNoImage.Visible = picPosVehicle.Image Is Nothing
            lblPosVehicleName.Text = String.Format("{0} {1} {2} {3}", vehicle.ModelYear, vehicle.Brand, vehicle.Model, vehicle.TrimLevel).Trim()
            lblPosVehicleStock.Text = "Stock: " & vehicle.StockNumber
            lblPosVehicleDetails.Text = String.Format("{0} · {1} · {2:N0} km", vehicle.Condition, If(String.IsNullOrWhiteSpace(vehicle.Color), "No color", vehicle.Color), vehicle.MileageKm)
            lblPosVehiclePrice.Text = "₱ " & vehicle.SellingPrice.ToString("N2")
        End Sub

        Private Sub ClearVehiclePreview()
            DisposeVehiclePreviewImage()
            lblPosNoImage.Visible = True
            lblPosVehicleName.Text = "Select an available vehicle"
            lblPosVehicleStock.Text = "Stock: —"
            lblPosVehicleDetails.Text = "Condition · Color · Mileage"
            lblPosVehiclePrice.Text = "₱ 0.00"
        End Sub

        Private Sub DisposeVehiclePreviewImage()
            If picPosVehicle.Image Is Nothing Then Return
            Dim oldImage As Image = picPosVehicle.Image
            picPosVehicle.Image = Nothing
            oldImage.Dispose()
        End Sub

        Private Sub PosForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
            DisposeVehiclePreviewImage()
        End Sub

        Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
            Recalculate()
        End Sub

        Private Sub btnQuote_Click(sender As Object, e As EventArgs) Handles btnQuote.Click
            Dim customerId = SelectedCustomerId()
            Dim vehicleId = SelectedVehicleId()
            If customerId = 0 OrElse vehicleId = 0 Then
                MessageBox.Show("Select a customer and an available vehicle.")
                Return
            End If

            Try
                Dim id = New QuotationService().Create(customerId, vehicleId, numDiscount.Value, txtNotes.Text)
                MessageBox.Show("Quotation created successfully. Quote ID: " & id.ToString(), "Quotation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Quotation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub btnFinalize_Click(sender As Object, e As EventArgs) Handles btnFinalize.Click
            Dim customerId = SelectedCustomerId()
            Dim vehicleId = SelectedVehicleId()
            If customerId = 0 OrElse vehicleId = 0 Then
                MessageBox.Show("Select a customer and an available vehicle.")
                Return
            End If

            If MessageBox.Show("Finalize this sale? The vehicle will be marked Sold only after the transaction succeeds.", "Finalize Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

            Try
                Dim saleId = New SalesService().FinalizeSale(customerId, vehicleId, numDiscount.Value, CStr(cbPlan.SelectedItem), numInitial.Value, CStr(cbMethod.SelectedItem), _quotationId)
                MessageBox.Show("Sale completed successfully.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Using receipt As New ReceiptForm(saleId)
                    receipt.ShowDialog()
                End Using

                _quotationId = 0
                LoadSelections()
                numDiscount.Value = 0
                numInitial.Value = 0
                txtNotes.Clear()
                Recalculate()
                UpdateActionState()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Sale could not be completed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
