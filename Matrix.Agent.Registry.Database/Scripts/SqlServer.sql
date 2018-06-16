IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Applications] (
    [Id] uniqueidentifier NOT NULL,
    [Description] nvarchar(1024) NULL,
    [Name] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_Applications] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180604003829_Registry_Initial', N'2.0.3-rtm-10026');

GO

