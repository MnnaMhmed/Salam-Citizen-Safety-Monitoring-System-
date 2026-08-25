IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NOT NULL,
    [NationalId] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [BloodType] nvarchar(max) NOT NULL,
    [AccountType] nvarchar(max) NOT NULL,
    [IsDeaf] bit NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [NumOfReports] int NOT NULL,
    [NumOfDevices] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Devices] (
    [Id] int NOT NULL IDENTITY,
    [DeviceName] nvarchar(max) NOT NULL,
    [SerialNumber] nvarchar(max) NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Devices] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Devices_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reports] (
    [Id] int NOT NULL IDENTITY,
    [Type] nvarchar(max) NOT NULL,
    [Location] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [IsResolved] bit NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Reports] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reports_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Devices_UserId] ON [Devices] ([UserId]);
GO

CREATE INDEX [IX_Reports_UserId] ON [Reports] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260708110733_SalamMigr', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Plans] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Price] int NOT NULL,
    [DurationInDays] int NOT NULL,
    CONSTRAINT [PK_Plans] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Subscribtions] (
    [id] int NOT NULL IDENTITY,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [UserId] int NOT NULL,
    [PlanId] int NOT NULL,
    CONSTRAINT [PK_Subscribtions] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Subscribtions_Plans_PlanId] FOREIGN KEY ([PlanId]) REFERENCES [Plans] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Subscribtions_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Subscribtions_PlanId] ON [Subscribtions] ([PlanId]);
GO

CREATE INDEX [IX_Subscribtions_UserId] ON [Subscribtions] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260816154958_menna2', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Notifications] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [IsRead] bit NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Notifications] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Notifications_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Notifications_UserId] ON [Notifications] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260816170240_menna3', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [EmergencyContacts] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Relation] nvarchar(max) NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_EmergencyContacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmergencyContacts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_EmergencyContacts_UserId] ON [EmergencyContacts] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260816193134_menna4', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [EmergencyNumbers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EmergencyNumbers] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260824162434_AddEmergencyNumbers', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Rating] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Rate] int NOT NULL,
    [Comment] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Rating] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rating_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Supports] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Subject] nvarchar(max) NOT NULL,
    [Message] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Supports] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Supports_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Rating_UserId] ON [Rating] ([UserId]);
GO

CREATE INDEX [IX_Supports_UserId] ON [Supports] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260824165536_AddProfile', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Plans].[DurationInDays]', N'Duration', N'COLUMN';
GO

CREATE TABLE [Payments] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [SubscriptionId] int NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [PaymentMethod] nvarchar(max) NOT NULL,
    [TransactionId] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payments_Subscribtions_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [Subscribtions] ([id]),
    CONSTRAINT [FK_Payments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
);
GO

CREATE INDEX [IX_Payments_SubscriptionId] ON [Payments] ([SubscriptionId]);
GO

CREATE INDEX [IX_Payments_UserId] ON [Payments] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260825145921_AddPayment', N'8.0.0');
GO

COMMIT;
GO

