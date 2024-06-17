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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [BirthDate] datetime2 NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[mstStatus] (
        [ID] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [IsActive] bit NOT NULL,
        [LogBy] nvarchar(max) NOT NULL,
        [LogDate] datetime2 NOT NULL,
        [LogInc] int NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_mstStatus] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[mstToken] (
        [ID] nvarchar(450) NOT NULL,
        [UserID] nvarchar(max) NOT NULL,
        [TokenType] nvarchar(max) NOT NULL,
        [TokenValue] nvarchar(max) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        [ValidFrom] datetime2 NOT NULL,
        [ValidTo] datetime2 NOT NULL,
        CONSTRAINT [PK_mstToken] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[mstBloodType] (
        [ID] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [StatusID] int NOT NULL,
        [LogBy] nvarchar(max) NOT NULL,
        [LogDate] datetime2 NOT NULL,
        [LogInc] int NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_mstBloodType] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_mstBloodType_mstStatus_StatusID] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[mstStatus] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[mstGender] (
        [ID] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [StatusID] int NOT NULL,
        [LogBy] nvarchar(max) NOT NULL,
        [LogDate] datetime2 NOT NULL,
        [LogInc] int NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_mstGender] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_mstGender_mstStatus_StatusID] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[mstStatus] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[mstMaritalStatus] (
        [ID] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [StatusID] int NOT NULL,
        [LogBy] nvarchar(max) NOT NULL,
        [LogDate] datetime2 NOT NULL,
        [LogInc] int NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_mstMaritalStatus] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_mstMaritalStatus_mstStatus_StatusID] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[mstStatus] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[mstNationality] (
        [ID] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [StatusID] int NOT NULL,
        [LogBy] nvarchar(max) NOT NULL,
        [LogDate] datetime2 NOT NULL,
        [LogInc] int NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_mstNationality] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_mstNationality_mstStatus_StatusID] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[mstStatus] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[mstReligion] (
        [ID] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [StatusID] int NOT NULL,
        [LogBy] nvarchar(max) NOT NULL,
        [LogDate] datetime2 NOT NULL,
        [LogInc] int NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_mstReligion] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_mstReligion_mstStatus_StatusID] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[mstStatus] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[mstDriver] (
        [ID] nvarchar(450) NOT NULL,
        [IdentityCardNumber] nvarchar(max) NOT NULL,
        [DrivingLicenseNumber] nvarchar(max) NOT NULL,
        [FullName] nvarchar(max) NOT NULL,
        [PlaceOfBirth] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [GenderID] int NOT NULL,
        [BloodTypeID] int NOT NULL,
        [AddressOfIdentityCard] nvarchar(max) NOT NULL,
        [AddressOfDrivingLicense] nvarchar(max) NOT NULL,
        [ReligionID] int NOT NULL,
        [MaritalStatusID] int NOT NULL,
        [NationalityID] int NOT NULL,
        [OccupationsIDOfIdentityCard] int NOT NULL,
        [OccupationsOthersOfIdentityCard] nvarchar(max) NOT NULL,
        [OccupationsIDOfDrivingLicense] int NOT NULL,
        [OccupationsOthersOfDrivingLicense] nvarchar(max) NOT NULL,
        [ValidThruOfIdentityCard] datetime2 NOT NULL,
        [ValidThruOfDrivingLicense] datetime2 NOT NULL,
        [DrivingLicenseTypeID] int NOT NULL,
        [Height] int NOT NULL,
        [StatusID] int NOT NULL,
        [CreatedFromComLocID] int NOT NULL,
        [LastUpdatedFromComLocID] int NOT NULL,
        [ReferencesID] nvarchar(max) NOT NULL,
        [InternalRemarks] nvarchar(max) NOT NULL,
        [LogBy] nvarchar(max) NOT NULL,
        [LogDate] datetime2 NOT NULL,
        [LogInc] int NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_mstDriver] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_mstDriver_mstBloodType_BloodTypeID] FOREIGN KEY ([BloodTypeID]) REFERENCES [dbo].[mstBloodType] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_mstDriver_mstGender_GenderID] FOREIGN KEY ([GenderID]) REFERENCES [dbo].[mstGender] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_mstDriver_mstMaritalStatus_MaritalStatusID] FOREIGN KEY ([MaritalStatusID]) REFERENCES [dbo].[mstMaritalStatus] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_mstDriver_mstNationality_NationalityID] FOREIGN KEY ([NationalityID]) REFERENCES [dbo].[mstNationality] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_mstDriver_mstReligion_ReligionID] FOREIGN KEY ([ReligionID]) REFERENCES [dbo].[mstReligion] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_mstDriver_mstStatus_StatusID] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[mstStatus] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[dbo].[AspNetRoles]'))
        SET IDENTITY_INSERT [dbo].[AspNetRoles] ON;
    EXEC(N'INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''d23b8f4f-2afc-4ba1-848d-d0dc9e94f3a6'', NULL, N''Admin'', N''ADMIN''),
    (N''f09e8844-6e7c-4965-9175-e58c4c836280'', NULL, N''User'', N''USER'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[dbo].[AspNetRoles]'))
        SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [dbo].[AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstBloodType_StatusID] ON [dbo].[mstBloodType] ([StatusID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstDriver_BloodTypeID] ON [dbo].[mstDriver] ([BloodTypeID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstDriver_GenderID] ON [dbo].[mstDriver] ([GenderID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstDriver_MaritalStatusID] ON [dbo].[mstDriver] ([MaritalStatusID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstDriver_NationalityID] ON [dbo].[mstDriver] ([NationalityID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstDriver_ReligionID] ON [dbo].[mstDriver] ([ReligionID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstDriver_StatusID] ON [dbo].[mstDriver] ([StatusID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstGender_StatusID] ON [dbo].[mstGender] ([StatusID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstMaritalStatus_StatusID] ON [dbo].[mstMaritalStatus] ([StatusID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstNationality_StatusID] ON [dbo].[mstNationality] ([StatusID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_mstReligion_StatusID] ON [dbo].[mstReligion] ([StatusID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240617092409_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240617092409_InitialCreate', N'8.0.6');
END;
GO

COMMIT;
GO

