using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Matrix.Agent.Postman.Database.Migrations.Sqlite
{
    public partial class Postman_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Application = table.Column<Guid>(nullable: false),
                    Body = table.Column<string>(maxLength: 4096, nullable: false),
                    From = table.Column<string>(maxLength: 256, nullable: false),
                    HTML = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Application = table.Column<Guid>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 256, nullable: false),
                    Blind = table.Column<bool>(nullable: false),
                    Copy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => new { x.EmailId, x.Address });
                    table.ForeignKey(
                        name: "FK_EmailAddress_Emails_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Emails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    PhoneMessageId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => new { x.PhoneMessageId, x.Number });
                    table.ForeignKey(
                        name: "FK_PhoneNumber_PhoneMessages_PhoneMessageId",
                        column: x => x.PhoneMessageId,
                        principalTable: "PhoneMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "PhoneMessages");
        }
    }
}
