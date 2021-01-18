IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200921153228_f')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200921153228_f')
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
        CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200921153228_f')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200921153228_f', N'3.1.8');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200922090148_sales')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200922090148_sales')
BEGIN
    CREATE TABLE [Sales] (
        [SalesId] int NOT NULL IDENTITY,
        [CreatedBy] nvarchar(max) NULL,
        [Created] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        [LastModified] datetime2 NULL,
        [OrderGroup] nvarchar(max) NULL,
        [Total] decimal(18,2) NOT NULL,
        [CustomerId] int NULL,
        CONSTRAINT [PK_Sales] PRIMARY KEY ([SalesId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200922090148_sales')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200922090148_sales', N'3.1.8');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200922092151_keychange')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sales]') AND [c].[name] = N'OrderGroup');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Sales] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Sales] ALTER COLUMN [OrderGroup] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200922092151_keychange')
BEGIN
    CREATE UNIQUE INDEX [IX_Sales_OrderGroup] ON [Sales] ([OrderGroup]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200922092151_keychange')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200922092151_keychange', N'3.1.8');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201012075721_product category')
BEGIN
    ALTER TABLE [Sales] ADD [InvoiceNumber] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201012075721_product category')
BEGIN
    ALTER TABLE [Products] ADD [ProductCategoryId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201012075721_product category')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201012075721_product category')
BEGIN
    CREATE INDEX [IX_Products_ProductCategoryId] ON [Products] ([ProductCategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201012075721_product category')
BEGIN
    ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_ProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([ProductCategoryId]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201012075721_product category')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201012075721_product category', N'3.1.8');
END;

GO

