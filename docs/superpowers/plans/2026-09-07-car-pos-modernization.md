# Car Dealership POS Modernization Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Produce a portfolio-ready VB.NET WinForms dealership POS with SQLite persistence, configurable multi-brand inventory, quotations, sales, installment payments, reporting, and administration.

**Architecture:** Designer forms call focused services. Services enforce business rules and use SQLite repositories/database helpers. SessionContext carries the authenticated user only; AppPaths owns runtime file locations.

**Tech Stack:** VB.NET, WinForms, .NET Framework 4.8, System.Data.SQLite 2.x + SourceGear.sqlite3, XML/RESX Designer resources.

**Spec:** `docs/superpowers/specs/2026-09-07-car-pos-modernization-design.md`

## Global Constraints
- Preserve the original upload unchanged.
- Keep all user-facing forms Designer-editable.
- Use Decimal for money and rates.
- Do not hardcode administrator credentials.
- Finalize inventory sale state atomically with sale creation.
- Runtime database lives under `%LOCALAPPDATA%\CarDealershipPOS\Data`.

---

### Task 1: Project shell, SQLite schema, and authentication
**Files:** create solution/project, `Data/Database.vb`, `Models/User.vb`, `Security/PasswordSecurity.vb`, `Services/AuthService.vb`, setup/login forms.
- [ ] Add SQLite package reference and runtime AppPaths.
- [ ] Create schema for Users, Customers, Vehicles, Quotations, QuotationItems, Sales, SaleItems, Payments, Settings, AuditLogs.
- [ ] Add first-run administrator and login flow with PBKDF2.
- [ ] Add regression checks for no hardcoded Admin123/plaintext passwords.

### Task 2: Inventory
**Files:** `Models/Vehicle.vb`, `Data/VehicleRepository.vb`, `Services/InventoryService.vb`, inventory list/editor forms.
- [ ] Implement search/filter and New/Used/Available/Sold statuses.
- [ ] Implement add/edit/deactivate without destructive deletes.
- [ ] Add demo Toyota seed data through service, not form constants.

### Task 3: Customers
**Files:** customer model/repository/service and list/editor forms.
- [ ] Implement searchable reusable customer profiles.
- [ ] Validate names/contact/email and active state.

### Task 4: Quotations
**Files:** quotation models/repository/service and quotation form.
- [ ] Create Draft quotations against an available vehicle and customer.
- [ ] Compute Decimal subtotal/discount/tax/total.
- [ ] Keep vehicle available until conversion.

### Task 5: Checkout and sales
**Files:** sale/payment models/repositories, `SalesService.vb`, POS form, receipt form.
- [ ] Finalize sale in one transaction.
- [ ] Validate vehicle availability before commit.
- [ ] Mark vehicle Sold only after sale insert succeeds.
- [ ] Support full payment and installment down payment.

### Task 6: Installment payment ledger
**Files:** `PaymentService.vb`, payments form.
- [ ] List open installment accounts.
- [ ] Record later payments.
- [ ] Derive outstanding balance from ledger.
- [ ] Prevent overpayment.

### Task 7: Dashboard and reporting
**Files:** dashboard, sales history/report service.
- [ ] Show inventory counts, today/month sales, receivables, recent sales.
- [ ] Filter sales by dates/customer/status/staff.
- [ ] Export visible sales to CSV.

### Task 8: Administration and delivery
**Files:** users/settings/audit/backup forms/services, README, testing guide.
- [ ] Manage staff accounts and resets/deactivation.
- [ ] Configure dealership identity and tax percentage.
- [ ] Add audit log and SQLite backup/restore.
- [ ] Run structural, schema, resource, path-length, secret, and ZIP integrity checks.
