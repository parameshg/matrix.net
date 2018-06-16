IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Logs] (
    [Id] uniqueidentifier NOT NULL,
    [Application] uniqueidentifier NOT NULL,
    [Event] int NOT NULL,
    [Level] int NOT NULL,
    [Message] nvarchar(max) NOT NULL,
    [Source] nvarchar(256) NOT NULL,
    [Timestamp] datetime2 NOT NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [LogProperty] (
    [Id] uniqueidentifier NOT NULL,
    [Key] nvarchar(256) NOT NULL,
    [LogEntryId] uniqueidentifier NULL,
    [Value] nvarchar(1024) NOT NULL,
    CONSTRAINT [PK_LogProperty] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LogProperty_Logs_LogEntryId] FOREIGN KEY ([LogEntryId]) REFERENCES [Logs] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [LogTag] (
    [Id] uniqueidentifier NOT NULL,
    [LogEntryId] uniqueidentifier NULL,
    [Value] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_LogTag] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LogTag_Logs_LogEntryId] FOREIGN KEY ([LogEntryId]) REFERENCES [Logs] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_LogProperty_LogEntryId] ON [LogProperty] ([LogEntryId]);

GO

CREATE INDEX [IX_LogTag_LogEntryId] ON [LogTag] ([LogEntryId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180604020338_Journal_Initial', N'2.0.3-rtm-10026');

GO

