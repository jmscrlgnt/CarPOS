# Old Project → v2 Mapping

| Old area | v2 replacement |
|---|---|
| `My.Settings.Username/Password` | SQLite `Users` + PBKDF2 |
| hardcoded `Admin/Admin123` | first-run Administrator |
| `FormNewCars` hardcoded price variables | `Vehicles` inventory table |
| Used-car `ListView` removal | vehicle `Status='Sold'` after committed sale |
| `TransactionSummary.ListView` | persistent `Sales`, `SaleItems`, `Payments` |
| one `UserBal` | per-sale payment ledger |
| hardcoded 10% tax | `Settings.TaxRate` |
| string/Double money | `Decimal` in VB + NUMERIC in SQLite |
| forms writing into other forms' controls | IDs/models through services/constructors |
| temporary customer fields | reusable `Customers` table |
| no quotation stage | persistent Quotation → Sale workflow |
