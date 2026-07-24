using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NooshApp.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    DesiredPosition = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CoverLetter = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CvFilePath = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    CvOriginalFileName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    KeywordScore = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
