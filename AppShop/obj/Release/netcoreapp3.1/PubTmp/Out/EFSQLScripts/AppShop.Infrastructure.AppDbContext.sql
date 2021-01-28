IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210121083134_Initial')
BEGIN
    CREATE TABLE [Customers] (
        [CustomerId] int NOT NULL IDENTITY,
        [CreatedBy] nvarchar(max) NULL,
        [Created] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        [LastModified] datetime2 NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210121083134_Initial')
BEGIN
    CREATE TABLE [Orders] (
        [OrderId] int NOT NULL IDENTITY,
        [CreatedBy] nvarchar(max) NULL,
        [Created] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        [LastModified] datetime2 NULL,
        [OrderGroup] nvarchar(max) NULL,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210121083134_Initial')
BEGIN
    CREATE TABLE [ProductCategory] (
        [ProductCategoryId] int NOT NULL IDENTITY,
        [CreatedBy] nvarchar(max) NULL,
        [Created] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        [LastModified] datetime2 NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([ProductCategoryId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210121083134_Initial')
BEGIN
    CREATE TABLE [Sales] (
        [SalesId] int NOT NULL IDENTITY,
        [CreatedBy] nvarchar(max) NULL,
        [Created] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        [LastModified] datetime2 NULL,
        [OrderGroup] nvarchar(450) NOT NULL,
        [Total] decimal(18,2) NOT NULL,
        [InvoiceNumber] nvarchar(max) NULL,
        [CustomerId] int NULL,
        CONSTRAINT [PK_Sales] PRIMARY KEY ([SalesId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210121083134_Initial')
BEGIN
    CREATE TABLE [Products] (
        [ProductId] int NOT NULL IDENTITY,
        [CreatedBy] nvarchar(max) NULL,
        [Created] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        [LastModified] datetime2 NULL,
        [Name] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [Description] nvarchar(max) NULL,
        [ProductCategoryId] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
        CONSTRAINT [FK_Products_ProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([ProductCategoryId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210121083134_Initial')
BEGIN
    CREATE INDEX [IX_Products_ProductCategoryId] ON [Products] ([ProductCategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210121083134_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_Sales_OrderGroup] ON [Sales] ([OrderGroup]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210121083134_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210121083134_Initial', N'3.1.8');
END;

GO

