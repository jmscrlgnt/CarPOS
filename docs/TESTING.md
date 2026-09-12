# Manual Testing Checklist

## Setup and security
- [ ] Fresh database shows first-run administrator setup.
- [ ] Password shorter than 8 characters is rejected.
- [ ] After admin creation, application shows Login on later launches.
- [ ] Wrong password is rejected and logged in Audit Log.
- [ ] Sales Staff cannot use administrator tools or inventory modification buttons.

## Inventory
- [ ] Demo seed adds multiple brands and both New/Used vehicles only when inventory is empty.
- [ ] Duplicate Stock Number is rejected.
- [ ] Duplicate non-empty VIN is rejected.
- [ ] Sold vehicle cannot be edited into available stock through the editor.
- [ ] Deactivate preserves the row for historical reporting.

## Customers
- [ ] Add/edit/search customer.
- [ ] Duplicate Customer Number is rejected.
- [ ] Deactivation preserves historical sales.

## Quotation
- [ ] Create a quote against an available vehicle.
- [ ] Quoted vehicle remains Available.
- [ ] Quote stores subtotal, discount, tax, and total.
- [ ] Convert quote to sale using the quote's stored pricing.
- [ ] Conversion fails safely if another completed sale already sold that vehicle.

## Full sale
- [ ] Select customer + vehicle.
- [ ] Total is calculated using Decimal and current tax setting.
- [ ] Insufficient full payment is rejected.
- [ ] Cash tendered above total displays change.
- [ ] Successful sale marks vehicle Sold.
- [ ] Receipt opens and sale appears in Sales History.

## Installment sale
- [ ] Down payment below total is accepted.
- [ ] Sale appears in Payments with correct balance.
- [ ] Later payment decreases balance.
- [ ] Overpayment is rejected.
- [ ] Fully paid sale disappears from Open Balances.

## Reporting
- [ ] Dashboard updates inventory/sales/receivables.
- [ ] Sales date/search filter works.
- [ ] CSV export creates a readable file.
- [ ] Receipt print dialog opens.

## Administration
- [ ] Administrator can create Sales Staff.
- [ ] Administrator can reset user password.
- [ ] Administrator cannot deactivate their own logged-in account.
- [ ] Dealership/tax settings persist after restart.
- [ ] Backup creates a `.db` copy.
- [ ] Restore creates a safety backup first; restart reloads restored data.
- [ ] Audit Log records login, inventory/customer changes, sales, payments, settings, and backup actions.

## Designer
For several forms (`MainForm`, `InventoryForm`, `PosForm`, `SettingsForm`, editor dialogs):
- [ ] Right-click `.vb` → View Designer opens without parser errors.
- [ ] Controls can be moved/resized and saved.
- [ ] Rebuild still succeeds after a harmless visual change.


## POS binding regression (v2.0.3)

1. Open Point of Sale with customers and inventory already present.
2. Confirm the screen opens without a `DataRowView` to `Long` `InvalidCastException`.
3. Confirm Customer and Vehicle start unselected and Save Quotation / Finalize Sale are disabled.
4. Select a customer, then a vehicle; totals should calculate and actions should enable.
5. Change vehicles several times; totals should update without exceptions.
6. Open a saved quotation with Convert to Sale; the quoted customer/vehicle should populate and the screen should remain stable.

## Vehicle images — Phase 1 (v2.1.0)

- [ ] Add a new vehicle, click **Choose Image**, and select a valid JPG/JPEG/PNG/BMP/GIF.
- [ ] Confirm the selected photo is visible before saving.
- [ ] Save the vehicle and select its Inventory row; the image and vehicle summary should appear in Vehicle Preview.
- [ ] Confirm a copy exists under `%LOCALAPPDATA%\CarDealershipPOS\VehicleImages\`.
- [ ] Move/delete the original source photo; restart the program and confirm the Inventory preview still works.
- [ ] Edit the vehicle and choose a replacement image; after save, the new image should appear.
- [ ] Use **Remove Image**, save, and confirm Inventory displays `No image available`.
- [ ] Confirm removing/replacing a managed image does not delete the original external source file.
- [ ] Select a demo vehicle with no image and confirm the no-image state is clear rather than showing an error/broken picture.
- [ ] Open `VehicleEditorForm.vb` and `InventoryForm.vb` in Visual Studio Designer and confirm both still load normally.


## SQLite native runtime — v2.1.1

- [ ] Restore NuGet packages before building.
- [ ] Build the solution in Debug and confirm it succeeds with x64 output.
- [ ] Confirm `bin\Debug\e_sqlite3.dll` exists beside `CarDealershipPOS.exe`.
- [ ] Launch the app and confirm first database access does not throw `SQLite.Interop.dll` or `e_sqlite3.dll` `DllNotFoundException`.
- [ ] Repeat with Release if producing a release build and confirm `bin\Release\e_sqlite3.dll` exists.

## x64 solution platform — v2.1.2

1. Open the solution and confirm the Visual Studio toolbar shows `x64`, not `Any CPU`.
2. Open Build > Configuration Manager and confirm the active solution platform is `x64`.
3. Rebuild the solution. SourceGear.sqlite3 must no longer report `This package does not support Any CPU builds`.
4. Confirm the application output folder contains `e_sqlite3.dll`.
## POS vehicle preview & UI polish — v2.2.0

- [ ] Assign a managed photo to at least one vehicle through Inventory → Edit.
- [ ] Open Point of Sale and confirm Customer/Vehicle still start safely without the old `DataRowView` exception.
- [ ] Select a vehicle with an image; confirm the POS vehicle card shows the photo, year/brand/model/trim, stock number, condition/color/mileage, and formatted price.
- [ ] Select a vehicle without an image; confirm `No image available` appears without an exception.
- [ ] Switch repeatedly between vehicles with/without images and confirm the preview updates without stale photos or locked-image errors.
- [ ] Convert a quotation to sale and confirm the quoted vehicle's preview loads automatically.
- [ ] In Inventory, confirm Price uses peso/currency formatting and the visible headers read `Stock Number`, `Trim`, and `Mileage (km)`.
- [ ] With no quotations, confirm the Quotations grid shows `No quotations yet.`
- [ ] With no matching sales filters, confirm Sales History shows `No sales match the current filters.`
- [ ] With no outstanding balances, confirm Payments shows `No outstanding installment balances.`
- [ ] Create records so each empty state disappears when rows are available.
- [ ] Open `PosForm.vb`, `QuotationsForm.vb`, `SalesForm.vb`, and `PaymentsForm.vb` in View Designer and confirm the Designer opens normally.

