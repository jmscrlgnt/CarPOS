from pathlib import Path

root = Path(__file__).resolve().parents[1]
forms = root / 'CarDealershipPOS' / 'Forms'

pos = (forms / 'PosForm.vb').read_text(encoding='utf-8')
posd = (forms / 'PosForm.Designer.vb').read_text(encoding='utf-8')
inv = (forms / 'InventoryForm.vb').read_text(encoding='utf-8')
quotes = (forms / 'QuotationsForm.vb').read_text(encoding='utf-8')
quotesd = (forms / 'QuotationsForm.Designer.vb').read_text(encoding='utf-8')
sales = (forms / 'SalesForm.vb').read_text(encoding='utf-8')
salesd = (forms / 'SalesForm.Designer.vb').read_text(encoding='utf-8')
pay = (forms / 'PaymentsForm.vb').read_text(encoding='utf-8')
payd = (forms / 'PaymentsForm.Designer.vb').read_text(encoding='utf-8')

checks = {
    'POS preview group exists': 'Friend WithEvents grpVehiclePreview As GroupBox' in posd,
    'POS picture box exists': 'Friend WithEvents picPosVehicle As PictureBox' in posd,
    'POS no-image label exists': 'Friend WithEvents lblPosNoImage As Label' in posd,
    'POS preview updated from vehicle selection': 'UpdateVehiclePreview(vehicle)' in pos and 'cbVehicle_SelectedIndexChanged' in pos and 'Recalculate()' in pos,
    'POS preview loads managed vehicle image': 'VehicleImageStorage.LoadImageClone(vehicle.ImagePath)' in pos,
    'POS preview image disposed': 'DisposeVehiclePreviewImage()' in pos,
    'Inventory formats price as currency': 'DefaultCellStyle.Format = "₱ #,##0.00"' in inv,
    'Inventory user-facing headers': 'HeaderText = "Stock Number"' in inv and 'HeaderText = "Mileage (km)"' in inv,
    'Quotations empty state exists': 'Friend WithEvents lblEmptyQuotes As Label' in quotesd and 'No quotations yet.' in quotesd and 'lblEmptyQuotes.Visible = table.Rows.Count = 0' in quotes,
    'Sales empty state exists': 'Friend WithEvents lblEmptySales As Label' in salesd and 'No sales match the current filters.' in salesd and 'lblEmptySales.Visible = _table.Rows.Count = 0' in sales,
    'Payments empty state exists': 'Friend WithEvents lblEmptyBalances As Label' in payd and 'No outstanding installment balances.' in payd and 'lblEmptyBalances.Visible = table.Rows.Count = 0' in pay,
    'Sales headers are polished': 'HeaderText = "Sale Number"' in sales,
    'Payment headers are polished': 'HeaderText = "Sale Number"' in pay,
}

failed = [name for name, ok in checks.items() if not ok]
for name, ok in checks.items():
    print(('PASS' if ok else 'FAIL') + ': ' + name)
if failed:
    raise SystemExit(1)
print('UI PHASE 2 CHECKS PASS')
