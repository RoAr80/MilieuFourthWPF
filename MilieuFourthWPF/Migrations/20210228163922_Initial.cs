using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilieuFourthWPF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginCredentials",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Jwt = table.Column<string>(type: "TEXT", nullable: true),
                    RefreshToken = table.Column<string>(type: "TEXT", nullable: true),
                    LastEntry = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsLogout = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCredentials", x => x.Id);
                    table.UniqueConstraint("AK_LoginCredentials_Email", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginCredentials_LastEntry",
                table: "LoginCredentials",
                column: "LastEntry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginCredentials");
        }
    }
}
