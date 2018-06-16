CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Applications" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_Applications" PRIMARY KEY,
    "Description" TEXT NULL,
    "Name" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180604004002_Registry_Initial', '2.0.3-rtm-10026');

