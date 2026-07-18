using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NooshApp.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceIsSpicyWithSpiceLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSpicy",
                table: "MenuItems",
                newName: "SpiceLevel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpiceLevel",
                table: "MenuItems",
                newName: "IsSpicy");
        }
    }
}
