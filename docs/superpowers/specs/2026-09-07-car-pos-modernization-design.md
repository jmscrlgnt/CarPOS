# Car Dealership POS & Inventory Management System — Modernization Design

## Purpose
Modernize the uploaded VB.NET WinForms car POS into a configurable, persistent dealership POS and inventory application while preserving the familiar desktop workflow and Visual Studio Designer editability.

## Platform
- VB.NET
- Windows Forms
- .NET Framework 4.8
- SQLite via System.Data.SQLite 2.x + SourceGear.sqlite3
- Visual Studio Designer-compatible `.vb + .Designer.vb + .resx` forms

## Architecture
Forms are presentation only. Business rules live in services, persistence lives in repositories, and runtime state lives in a session context. SQLite is the source of truth for users, customers, vehicles, quotations, sales, payments, settings, and audit records.

## Main modules
1. First-run administrator setup and Administrator/Sales Staff authentication with PBKDF2 password hashes.
2. Multi-brand inventory with New/Used condition, stock number, VIN, mileage, pricing, status, and optional image path.
3. Customer management and reusable customer profiles.
4. Quotation workflow that does not consume stock until converted to a sale.
5. POS checkout with Decimal calculations, configurable tax, discount, cash/full and installment terms.
6. Installment payment ledger with outstanding balance calculated from recorded payments.
7. Persistent sales history, receipt preview/printing, filters, and CSV export.
8. Dashboard with inventory, sales, receivables, and recent activity metrics.
9. Administration with staff management, settings, audit log, database backup/restore, and demo-data seeding.

## Rules
- No hardcoded default admin password.
- Vehicle status changes to Sold only inside a successful finalized-sale transaction.
- Quotations never mark vehicles Sold.
- Monetary fields use Decimal.
- Tax is stored as a configurable decimal percentage in Settings.
- Installment balance is derived from sale total minus successful payments.
- Inactive vehicles/customers/users remain in history instead of being destructively deleted.
- Original uploaded project remains untouched.
