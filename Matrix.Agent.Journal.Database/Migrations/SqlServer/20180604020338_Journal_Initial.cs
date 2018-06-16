using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Matrix.Agent.Journal.Database.Migrations.SqlServer
{
    public partial class Journal_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Application = table.Column<Guid>(nullable: false),
                    Event = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Message = table.Column<string>(maxLength: 4096, nullable: false),
                    Source = table.Column<string>(maxLength: 256, nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(maxLength: 256, nullable: false),
                    LogEntryId = table.Column<Guid>(nullable: true),
                    Value = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogProperty_Logs_LogEntryId",
                        column: x => x.LogEntryId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogEntryId = table.Column<Guid>(nullable: true),
                    Value = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogTag_Logs_LogEntryId",
                        column: x => x.LogEntryId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogProperty_LogEntryId",
                table: "LogProperty",
                column: "LogEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_LogTag_LogEntryId",
                table: "LogTag",
                column: "LogEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogProperty");

            migrationBuilder.DropTable(
                name: "LogTag");

            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
