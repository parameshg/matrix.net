CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Emails" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_Emails" PRIMARY KEY,
    "Application" BLOB NOT NULL,
    "Body" TEXT NOT NULL,
    "From" TEXT NOT NULL,
    "HTML" INTEGER NOT NULL,
    "Status" INTEGER NOT NULL,
    "Subject" TEXT NOT NULL
);

CREATE TABLE "PhoneMessages" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_PhoneMessages" PRIMARY KEY,
    "Application" BLOB NOT NULL,
    "From" TEXT NULL,
    "Message" TEXT NULL,
    "Status" INTEGER NOT NULL
);

CREATE TABLE "EmailAddress" (
    "EmailId" BLOB NOT NULL,
    "Address" TEXT NOT NULL,
    "Blind" INTEGER NOT NULL,
    "Copy" INTEGER NOT NULL,
    CONSTRAINT "PK_EmailAddress" PRIMARY KEY ("EmailId", "Address"),
    CONSTRAINT "FK_EmailAddress_Emails_EmailId" FOREIGN KEY ("EmailId") REFERENCES "Emails" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PhoneNumber" (
    "PhoneMessageId" BLOB NOT NULL,
    "Number" TEXT NOT NULL,
    CONSTRAINT "PK_PhoneNumber" PRIMARY KEY ("PhoneMessageId", "Number"),
    CONSTRAINT "FK_PhoneNumber_PhoneMessages_PhoneMessageId" FOREIGN KEY ("PhoneMessageId") REFERENCES "PhoneMessages" ("Id") ON DELETE CASCADE
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180604022402_Postman_Initial', '2.0.3-rtm-10026');

