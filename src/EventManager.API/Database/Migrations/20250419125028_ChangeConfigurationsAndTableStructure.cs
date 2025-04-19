using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConfigurationsAndTableStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agenda",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agenda",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
