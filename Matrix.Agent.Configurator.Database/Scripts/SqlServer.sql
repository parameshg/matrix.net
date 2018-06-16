IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Configuration] (
    [Id] uniqueidentifier NOT NULL,
    [Application] uniqueidentifier NOT NULL,
    [Key] nvarchar(256) NOT NULL,
    [Value] nvarchar(1024) NOT NULL,
    CONSTRAINT [PK_Configuration] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180604015051_Configurator_Initial', N'2.0.3-rtm-10026');

GO

