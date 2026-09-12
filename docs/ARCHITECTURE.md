# Architecture Guide

## Layers

### Forms
Collect input, show grids/dialogs, and call services. Forms do not own database state.

### Services
Business rules:
- `AuthService` — first admin, login, roles, user reset/activation.
- `InventoryService` — vehicle validation, lifecycle, demo seed.
- `CustomerService` — reusable customer records.
- `QuotationService` — quote math and quote persistence without selling stock.
- `SalesService` — transactional final sale and stock transition.
- `PaymentService` — installment ledger and outstanding balance.
- `ReportService` — dashboard, sales filtering, CSV export.
- `SettingsService` — dealership identity and tax.
- `AuditService` — security/business audit records.
- `BackupService` — SQLite backup and restore.

### Repositories / Data
`Data/Repositories` contains reusable read/persistence queries for core entities. `Database.vb` owns connection creation and common query helpers. `schema.sql` defines durable data structure.

### Models
Plain VB.NET domain objects. Money is `Decimal`, never `Double`.

## Critical sale invariant

A vehicle is not marked Sold when it is viewed, selected, quoted, or placed in checkout. `SalesService.FinalizeSale` opens one SQLite transaction, validates that the vehicle is still Available, inserts the sale/item/payment, then updates the vehicle to Sold before committing. Any exception rolls the whole operation back.

## Quotation invariant

Quotations store the quoted unit price, discount, tax rate, tax amount and total. Converting an existing quotation preserves those quoted values rather than silently recalculating using a later tax setting.

## Installment invariant

There is no global balance setting. Balance is:

`Sale.Total - SUM(Payments.Amount)`

Each later payment is a separate row with staff, method, optional reference, and timestamp.

## Roles

- **Administrator:** full inventory maintenance, dealership settings, user management, audit, backup/restore, sales/customer/POS access.
- **Sales Staff:** dashboard, customers, quotes, POS, sales, installment payments, inventory viewing. Administrative controls are disabled.

## Adding features

When adding a feature, keep this direction:

`Designer Form → Service → Repository/Database → SQLite`

Do not pass values by directly changing controls on another form. Pass IDs or model values through constructors/service methods.

## Vehicle image storage

Vehicle images are file assets rather than SQLite BLOBs. `VehicleImageStorage` copies administrator-selected images into `AppPaths.VehicleImageDirectory` (`%LOCALAPPDATA%\CarDealershipPOS\VehicleImages`) and stores the managed filename in `Vehicles.ImagePath`. `ResolvePath` also accepts rooted paths for backward compatibility, while `DeleteManagedImage` refuses to delete files outside the managed image directory. UI forms load cloned `System.Drawing.Image` instances to avoid locking the image file on disk.
