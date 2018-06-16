CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "UserGroups" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_UserGroups" PRIMARY KEY,
    "Application" BLOB NOT NULL,
    "Description" TEXT NOT NULL,
    "Name" TEXT NOT NULL
);

CREATE TABLE "UserRoles" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_UserRoles" PRIMARY KEY,
    "Application" BLOB NOT NULL,
    "Description" TEXT NOT NULL,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Users" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY,
    "Application" BLOB NOT NULL,
    "Email" TEXT NOT NULL,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    "Password" TEXT NOT NULL,
    "Phone" TEXT NULL,
    "Username" TEXT NOT NULL
);

CREATE TABLE "UserGroupMapping" (
    "UserId" BLOB NOT NULL,
    "GroupId" BLOB NOT NULL,
    CONSTRAINT "PK_UserGroupMapping" PRIMARY KEY ("UserId", "GroupId"),
    CONSTRAINT "FK_UserGroupMapping_UserGroups_GroupId" FOREIGN KEY ("GroupId") REFERENCES "UserGroups" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_UserGroupMapping_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
);

CREATE TABLE "UserRoleMapping" (
    "UserId" BLOB NOT NULL,
    "RoleId" BLOB NOT NULL,
    CONSTRAINT "PK_UserRoleMapping" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_UserRoleMapping_UserRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "UserRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_UserRoleMapping_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_UserGroupMapping_GroupId" ON "UserGroupMapping" ("GroupId");

CREATE INDEX "IX_UserRoleMapping_RoleId" ON "UserRoleMapping" ("RoleId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180604021802_Directory_Initial', '2.0.3-rtm-10026');

