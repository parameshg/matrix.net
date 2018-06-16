CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Configuration" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_Configuration" PRIMARY KEY,
    "Application" BLOB NOT NULL,
    "Key" TEXT NOT NULL,
    "Value" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180604015214_Configurator_Initial', '2.0.3-rtm-10026');

