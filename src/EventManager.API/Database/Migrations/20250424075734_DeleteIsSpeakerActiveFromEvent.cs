using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class DeleteIsSpeakerActiveFromEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSpeakerActive",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSpeakerActive",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }
    }
}
