# AutoDrive Car Dealership POS — Setup & Usage Instructions

## Requirements

Before running the project, install:

1. **Visual Studio 2019 or 2022**
2. **.NET desktop development** workload
3. **.NET Framework 4.8 Developer Pack**
4. NuGet package restore enabled

The project uses:

```text
VB.NET
Windows Forms
.NET Framework 4.8
SQLite
System.Data.SQLite
SourceGear.sqlite3
```

The project is configured for:

```text
x64
```

Do not switch the solution to `Any CPU`, because the SQLite native runtime requires a concrete platform target.

---

## How to Run the Program

1. Clone or download this repository.

2. Place the project in a short local folder, for example:

```text
C:\CarPOS
```

3. Open:

```text
CarDealershipPOS.sln
```

> Open the `.sln` file instead of opening only the `.vbproj` file.

4. In Visual Studio, restore NuGet packages if necessary:

```text
Build > Restore NuGet Packages
```

5. Confirm that the Visual Studio toolbar shows:

```text
Debug | x64
```

6. Run:

```text
Build > Clean Solution
```

7. Then:

```text
Build > Rebuild Solution
```

8. Confirm that Visual Studio reports:

```text
0 errors
```

9. Press **F5** or click **Start**.

---

## First-Time Setup

On first launch, the system creates the required local application folders and SQLite database.

The database is stored outside the source-code folder.

If the system has no Administrator account yet, follow the first-run account setup screen to create one.

Do not use hardcoded production credentials.

---

## Main System Modules

The application includes:

```text
Dashboard
Vehicle Inventory
Customers
Point of Sale
Quotations
Sales History
Installment Payments
Settings
User Management
Audit Log
Backup / Restore
```

---

## Vehicle Inventory

Use **Inventory** to manage dealership vehicles.

Vehicle information includes:

```text
Stock Number
Brand
Model
Trim
Year
Color
Condition
Mileage
VIN
Cost Price
Selling Price
Status
Vehicle Image
```

Vehicles may be marked as:

```text
Available
Sold
Inactive
```

The system supports both:

```text
New Vehicles
Used Vehicles
```

---

## Vehicle Images

Vehicle images are stored in the application's managed image folder:

```text
%LOCALAPPDATA%\CarDealershipPOS\VehicleImages\
```

When an image is selected through the Vehicle Editor, the application copies the image into its own managed folder.

The database stores the managed image filename/path instead of relying permanently on the original Desktop/Downloads location.

Supported formats include:

```text
.jpg
.jpeg
.png
.bmp
.gif
```

If no image is assigned, the application displays:

```text
No image available
```

Vehicle images are shown in:

```text
Inventory Preview
Point of Sale Vehicle Preview
```

---

## Customer Management

Use **Customers** to:

- Add customers
- Edit customer information
- Search customers
- Activate or deactivate customer records

Customer records may include:

```text
Customer Number
Full Name
Email
Contact Number
Address
Status
```

---

## Point of Sale

Use **Point of Sale** to create quotations and complete vehicle sales.

Typical workflow:

1. Select a customer.
2. Select an available vehicle.
3. Review the vehicle information and image.
4. Enter any discount.
5. Choose the payment plan.
6. Enter the initial payment or down payment.
7. Choose the payment method.
8. Click **Calculate**.
9. Review the Sale Summary.
10. Choose either:

```text
Save Quotation
```

or:

```text
Finalize Sale
```

---

## Quotations

Saving a quotation does **not** immediately mark the vehicle as sold.

A quotation may later be converted into a sale.

Workflow:

```text
Quotation
   ↓
Review
   ↓
Convert to Sale
   ↓
Finalize Sale
```

The selected vehicle only becomes sold after the sale is successfully finalized.

---

## Payment Plans

The system supports:

```text
Full Payment
Installment
```

For installment sales, the system tracks:

```text
Total Amount
Amount Paid
Outstanding Balance
Payment Method
Reference / OR Number
```

Additional installment payments can be recorded through:

```text
Payments
```

---

## Sales History

Use **Sales History** to view completed transactions.

You can search/filter by:

```text
Sale Number
Customer
Vehicle
Date Range
```

Available actions include:

```text
View Receipt
Export CSV
```

---

## Dashboard

The Dashboard displays dealership statistics such as:

```text
Available Inventory
New Vehicles
Used Vehicles
Sales Today
Sales This Month
Outstanding Receivables
Recent Sales
```

---

## Settings

Administrators can use **Settings** to configure:

```text
Dealership Name
Contact Number
Dealership Address
Tax Rate
Receipt Footer
```

Administrator tools include:

```text
User Management
Audit Log
Backup Database
Restore Database
```

---

## Database Location

The live SQLite database is stored at:

```text
%LOCALAPPDATA%\CarDealershipPOS\Data\dealership.db
```

This means the database is separate from the GitHub/source-code folder.

Replacing, recloning, or moving the source project does not automatically delete your dealership data.

---

## Vehicle Image Location

Vehicle images are stored at:

```text
%LOCALAPPDATA%\CarDealershipPOS\VehicleImages\
```

---

## Database Backups

Backups are stored under:

```text
%LOCALAPPDATA%\CarDealershipPOS\Backups\
```

Always create a backup before testing restore operations or manually modifying the database.

---

## Reset the Program for Testing

To return the system to a fresh local state:

1. Close AutoDrive.
2. Press:

```text
Win + R
```

3. Open:

```text
%LOCALAPPDATA%\CarDealershipPOS
```

4. Back up anything you want to keep.
5. Delete the `CarDealershipPOS` folder.
6. Start the application again.

> Only do this for development/testing. This removes the local database and managed vehicle images.

---

## Editing the UI With Visual Studio Designer

The WinForms forms use the standard Visual Studio Designer structure.

Example:

```text
InventoryForm.vb
InventoryForm.Designer.vb
InventoryForm.resx
```

Use:

```text
InventoryForm.vb
```

for event handlers, service calls, validation, and form behavior.

Use:

```text
InventoryForm.Designer.vb
```

for Designer-managed controls and layout.

Use:

```text
InventoryForm.resx
```

for Windows Forms resources.

To open the Designer:

1. Open **Solution Explorer**.
2. Right-click the main `.vb` form file.
3. Select **View Designer**.

Whenever possible, edit the interface using:

```text
View Designer + Properties
```

instead of manually editing `.Designer.vb`.

---

## SQLite Runtime Requirement

The project uses:

```text
System.Data.SQLite
SourceGear.sqlite3
```

The application must be built as:

```text
x64
```

The build output should include:

```text
CarDealershipPOS.exe
System.Data.SQLite.dll
e_sqlite3.dll
```

If `e_sqlite3.dll` is missing, restore NuGet packages and rebuild the solution.

---

## Troubleshooting

### SourceGear Error: Any CPU Not Supported

If Visual Studio shows:

```text
This package does not support Any CPU builds
```

change the solution platform to:

```text
x64
```

The expected configuration is:

```text
Debug | x64
Release | x64
```

---

### SQLite Native DLL Error

If you receive an error involving:

```text
SQLite.Interop.dll
```

make sure you are using the current project dependencies and not an older `System.Data.SQLite.Core` setup.

The current runtime uses:

```text
System.Data.SQLite
SourceGear.sqlite3
e_sqlite3.dll
```

Restore packages and rebuild.

---

### Vehicle Image Is Blank

Edit the vehicle and choose an image.

Vehicle images are not automatically bundled with every inventory record.

Use:

```text
Inventory > Select Vehicle > Edit > Choose Image
```

Then save the vehicle.

---

### Existing Data Is Missing

Check:

```text
%LOCALAPPDATA%\CarDealershipPOS\Data\dealership.db
```

Remember that the source-code folder and runtime database are separate.

---

### Windows Path Too Long

If Windows reports a path/extraction error, move the project to a shorter location such as:

```text
C:\CarPOS
```

Then reopen the solution.

---

## Recommended Test Flow

After rebuilding the project, test:

1. Login
2. Dashboard
3. Inventory
4. Add/Edit Vehicle
5. Vehicle Image Selection
6. Customer Creation
7. Point of Sale
8. Save Quotation
9. Convert Quotation to Sale
10. Finalize Sale
11. Sales History
12. Installment Payment
13. Settings
14. Backup / Restore

Confirm there are no runtime errors before publishing or deploying the program.
