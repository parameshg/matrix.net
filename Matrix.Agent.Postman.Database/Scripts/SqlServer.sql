IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Emails] (
    [Id] uniqueidentifier NOT NULL,
    [Application] uniqueidentifier NOT NULL,
    [Body] nvarchar(max) NOT NULL,
    [From] nvarchar(256) NOT NULL,
    [HTML] bit NOT NULL,
    [Status] int NOT NULL,
    [Subject] nvarchar(1024) NOT NULL,
    CONSTRAINT [PK_Emails] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PhoneMessages] (
    [Id] uniqueidentifier NOT NULL,
    [Application] uniqueidentifier NOT NULL,
    [From] nvarchar(max) NULL,
    [Message] nvarchar(max) NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_PhoneMessages] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [EmailAddress] (
    [EmailId] uniqueidentifier NOT NULL,
    [Address] nvarchar(256) NOT NULL,
    [Blind] bit NOT NULL,
    [Copy] bit NOT NULL,
    CONSTRAINT [PK_EmailAddress] PRIMARY KEY ([EmailId], [Address]),
    CONSTRAINT [FK_EmailAddress_Emails_EmailId] FOREIGN KEY ([EmailId]) REFERENCES [Emails] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [PhoneNumber] (
    [PhoneMessageId] uniqueidentifier NOT NULL,
    [Number] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_PhoneNumber] PRIMARY KEY ([PhoneMessageId], [Number]),
    CONSTRAINT [FK_PhoneNumber_PhoneMessages_PhoneMessageId] FOREIGN KEY ([PhoneMessageId]) REFERENCES [PhoneMessages] ([Id]) ON DELETE CASCADE
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180604022311_Postman_Initial', N'2.0.3-rtm-10026');

GO

