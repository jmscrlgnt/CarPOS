PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE COLLATE NOCASE,
    PasswordHash TEXT NOT NULL,
    PasswordSalt TEXT NOT NULL,
    Role TEXT NOT NULL CHECK(Role IN ('Administrator','Sales Staff')),
    IsActive INTEGER NOT NULL DEFAULT 1,
    CreatedAtUtc TEXT NOT NULL,
    UpdatedAtUtc TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Customers (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CustomerNumber TEXT NOT NULL UNIQUE,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    Email TEXT,
    ContactNumber TEXT,
    Address TEXT,
    IsActive INTEGER NOT NULL DEFAULT 1,
    CreatedAtUtc TEXT NOT NULL,
    UpdatedAtUtc TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Vehicles (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StockNumber TEXT NOT NULL UNIQUE,
    Vin TEXT UNIQUE,
    Brand TEXT NOT NULL,
    Model TEXT NOT NULL,
    Variant TEXT,
    ModelYear INTEGER NOT NULL,
    Color TEXT,
    Condition TEXT NOT NULL CHECK(Condition IN ('New','Used')),
    MileageKm INTEGER NOT NULL DEFAULT 0,
    CostPrice NUMERIC NOT NULL DEFAULT 0,
    SellingPrice NUMERIC NOT NULL,
    Status TEXT NOT NULL DEFAULT 'Available' CHECK(Status IN ('Available','Reserved','Sold','Inactive')),
    ImagePath TEXT,
    Notes TEXT,
    CreatedAtUtc TEXT NOT NULL,
    UpdatedAtUtc TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Quotations (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    QuoteNumber TEXT NOT NULL UNIQUE,
    CustomerId INTEGER NOT NULL REFERENCES Customers(Id),
    UserId INTEGER NOT NULL REFERENCES Users(Id),
    Status TEXT NOT NULL DEFAULT 'Draft' CHECK(Status IN ('Draft','Approved','Converted','Cancelled')),
    Subtotal NUMERIC NOT NULL,
    Discount NUMERIC NOT NULL DEFAULT 0,
    TaxRate NUMERIC NOT NULL DEFAULT 0,
    TaxAmount NUMERIC NOT NULL DEFAULT 0,
    Total NUMERIC NOT NULL,
    Notes TEXT,
    CreatedAtUtc TEXT NOT NULL,
    ExpiresAtUtc TEXT,
    ConvertedSaleId INTEGER
);

CREATE TABLE IF NOT EXISTS QuotationItems (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    QuotationId INTEGER NOT NULL REFERENCES Quotations(Id) ON DELETE CASCADE,
    VehicleId INTEGER NOT NULL REFERENCES Vehicles(Id),
    UnitPrice NUMERIC NOT NULL
);

CREATE TABLE IF NOT EXISTS Sales (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    SaleNumber TEXT NOT NULL UNIQUE,
    CustomerId INTEGER NOT NULL REFERENCES Customers(Id),
    UserId INTEGER NOT NULL REFERENCES Users(Id),
    QuotationId INTEGER REFERENCES Quotations(Id),
    Subtotal NUMERIC NOT NULL,
    Discount NUMERIC NOT NULL DEFAULT 0,
    TaxRate NUMERIC NOT NULL DEFAULT 0,
    TaxAmount NUMERIC NOT NULL DEFAULT 0,
    Total NUMERIC NOT NULL,
    PaymentPlan TEXT NOT NULL CHECK(PaymentPlan IN ('Full','Installment')),
    Status TEXT NOT NULL DEFAULT 'Completed' CHECK(Status IN ('Completed','Cancelled')),
    CreatedAtUtc TEXT NOT NULL,
    Notes TEXT
);

CREATE TABLE IF NOT EXISTS SaleItems (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    SaleId INTEGER NOT NULL REFERENCES Sales(Id) ON DELETE CASCADE,
    VehicleId INTEGER NOT NULL REFERENCES Vehicles(Id),
    UnitPrice NUMERIC NOT NULL
);

CREATE TABLE IF NOT EXISTS Payments (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    SaleId INTEGER NOT NULL REFERENCES Sales(Id) ON DELETE CASCADE,
    UserId INTEGER NOT NULL REFERENCES Users(Id),
    Amount NUMERIC NOT NULL CHECK(Amount > 0),
    Method TEXT NOT NULL,
    ReferenceNumber TEXT,
    Notes TEXT,
    PaidAtUtc TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Settings (
    Key TEXT PRIMARY KEY,
    Value TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS AuditLogs (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER,
    Username TEXT,
    Action TEXT NOT NULL,
    EntityType TEXT,
    EntityId TEXT,
    Details TEXT,
    CreatedAtUtc TEXT NOT NULL
);

CREATE INDEX IF NOT EXISTS IX_Vehicles_Status ON Vehicles(Status);
CREATE INDEX IF NOT EXISTS IX_Vehicles_BrandModel ON Vehicles(Brand, Model);
CREATE INDEX IF NOT EXISTS IX_Sales_CreatedAt ON Sales(CreatedAtUtc);
CREATE INDEX IF NOT EXISTS IX_Payments_SaleId ON Payments(SaleId);
CREATE INDEX IF NOT EXISTS IX_AuditLogs_CreatedAt ON AuditLogs(CreatedAtUtc);
