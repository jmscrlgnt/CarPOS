# v2.2.0 - POS vehicle preview and UI polish

- Added a Designer-based selected-vehicle card to Point of Sale with managed photo, model/year/trim, stock number, condition/color/mileage, and formatted selling price.
- Reused Phase 1 `VehicleImageStorage`; no new database migration is required.
- Added safe POS image disposal and clear no-image/cleared-selection states.
- Formatted Inventory price and mileage columns and replaced raw field labels with user-facing headers.
- Added purposeful empty states to Quotations, Sales History, and Installment Payments.
- Polished Sales/Payments headers and currency formatting.
- Improved common DataGridView header, row-height, padding, alternating-row, and selection styling.
- Added `verify_ui_phase2.py` regression coverage while preserving the existing x64 SQLite, POS binding, and vehicle-image checks.

# v2.1.2 - x64 solution/platform fix

- Changed solution configurations from Any CPU to x64.
- Changed project default platform and Debug/Release property groups to x64.
- Added a regression test that rejects Any CPU solution/project mappings.
- Preserves the v2.1.1 System.Data.SQLite 2.x + SourceGear native runtime migration.

# v2.1.1 - SQLite runtime dependency fix

- Replaced deprecated `System.Data.SQLite.Core` 1.0.119 with `System.Data.SQLite` 2.0.4.
- Added `SourceGear.sqlite3` 3.53.4 to supply the native `e_sqlite3.dll` required by System.Data.SQLite 2.x.
- Pinned Debug and Release to x64 and disabled Prefer32Bit for deterministic native loading.
- Added an MSBuild post-build target that copies the x64 `e_sqlite3.dll` beside the application executable and fails the build with a clear message if the native DLL is unavailable.
- Added regression coverage preventing the old `SQLite.Interop.dll` package model from returning.

# v2.0.3 - POS runtime binding safety

- Fixed `InvalidCastException` when Point of Sale ComboBoxes briefly exposed a `DataRowView` as `SelectedValue` during data binding.
- Set `DisplayMember`/`ValueMember` before assigning ComboBox `DataSource`.
- Added an initialization guard so selection-change events do not recalculate while controls are half-bound.
- Added safe bound-ID conversion and disabled quotation/finalize actions until both a real customer and available vehicle are selected.
- Added regression coverage for the POS binding sequence and selection safety.

# v2.0.2 - VB.NET syntax compatibility

- Fixed standalone `New Type().Method()` calls that compile in C# style but are invalid VB.NET statements.
- Renamed the VB model property `Variant` to `TrimLevel` because `Variant` is a Visual Basic keyword.
- Kept the SQLite column name `Variant`, so no database migration is required.
- Added regression checks for these compile-risk patterns.

# Changelog

## v2.0.0 — Modernized Car Dealership POS

- Rebuilt persistence around SQLite.
- Added first-run administrator setup, Administrator/Sales Staff roles, PBKDF2 password hashing, sessions, and audit logging.
- Replaced hardcoded Toyota inventory with configurable multi-brand New/Used vehicle inventory.
- Added persistent customer management.
- Added quotation creation and quotation-to-sale conversion without consuming inventory before a successful sale.
- Added atomic checkout with configurable tax, discounts, full/cash and installment payment plans.
- Added installment payment ledger and outstanding balance tracking.
- Added persistent sales history, receipt preview/printing, and CSV export.
- Added dashboard inventory/sales/receivable metrics.
- Added dealership settings, user management, and database backup/restore.
- Preserved Visual Studio WinForms Designer compatibility using `.vb + .Designer.vb + .resx` form trios.
- Removed dependency on plaintext `My.Settings` credentials, hardcoded `Admin123`, in-memory transaction history, and form-to-form control mutation as the source of truth.

## v2.0.1 - Build Configuration Fix
- Fixed legacy .NET Framework VB.NET MSBuild platform normalization (`x64` vs `x64`).
- Added explicit Debug/Release `OutputPath` blocks for `x64`.
- Added regression coverage so Visual Studio does not lose the output path again.

## v2.1.0 - Vehicle Images Phase 1

- Added managed vehicle-image storage under `%LOCALAPPDATA%\CarDealershipPOS\VehicleImages`.
- Added safe copy, resolution, cloned-image loading, filename sanitization, and managed-image cleanup helpers.
- Upgraded Add/Edit Vehicle with image preview, Choose Image, and Remove Image controls.
- Added an Inventory vehicle preview panel with photo, stock/model details, price, condition/mileage, and status.
- Existing `Vehicles.ImagePath` persistence is reused, so no destructive database migration is required from v2.0.x.
- Added regression coverage for the complete Phase 1 vehicle-image structure.
