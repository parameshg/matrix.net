CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Logs" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_Logs" PRIMARY KEY,
    "Application" BLOB NOT NULL,
    "Event" INTEGER NOT NULL,
    "Level" INTEGER NOT NULL,
    "Message" TEXT NOT NULL,
    "Source" TEXT NOT NULL,
    "Timestamp" TEXT NOT NULL
);

CREATE TABLE "LogProperty" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_LogProperty" PRIMARY KEY,
    "Key" TEXT NOT NULL,
    "LogEntryId" BLOB NULL,
    "Value" TEXT NOT NULL,
    CONSTRAINT "FK_LogProperty_Logs_LogEntryId" FOREIGN KEY ("LogEntryId") REFERENCES "Logs" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "LogTag" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_LogTag" PRIMARY KEY,
    "LogEntryId" BLOB NULL,
    "Value" TEXT NOT NULL,
    CONSTRAINT "FK_LogTag_Logs_LogEntryId" FOREIGN KEY ("LogEntryId") REFERENCES "Logs" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_LogProperty_LogEntryId" ON "LogProperty" ("LogEntryId");

CREATE INDEX "IX_LogTag_LogEntryId" ON "LogTag" ("LogEntryId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180604020448_Journal_Initial', '2.0.3-rtm-10026');

