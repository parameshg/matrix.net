IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [UserGroups] (
    [Id] uniqueidentifier NOT NULL,
    [Application] uniqueidentifier NOT NULL,
    [Description] nvarchar(1024) NOT NULL,
    [Name] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_UserGroups] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [UserRoles] (
    [Id] uniqueidentifier NOT NULL,
    [Application] uniqueidentifier NOT NULL,
    [Description] nvarchar(1024) NOT NULL,
    [Name] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [Application] uniqueidentifier NOT NULL,
    [Email] nvarchar(256) NOT NULL,
    [FirstName] nvarchar(128) NOT NULL,
    [LastName] nvarchar(128) NOT NULL,
    [Password] nvarchar(1024) NOT NULL,
    [Phone] nvarchar(16) NULL,
    [Username] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [UserGroupMapping] (
    [UserId] uniqueidentifier NOT NULL,
    [GroupId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserGroupMapping] PRIMARY KEY ([UserId], [GroupId]),
    CONSTRAINT [FK_UserGroupMapping_UserGroups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [UserGroups] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserGroupMapping_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserRoleMapping] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserRoleMapping] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRoleMapping_UserRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [UserRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoleMapping_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_UserGroupMapping_GroupId] ON [UserGroupMapping] ([GroupId]);

GO

CREATE INDEX [IX_UserRoleMapping_RoleId] ON [UserRoleMapping] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180604021656_Directory_Initial', N'2.0.3-rtm-10026');

GO

