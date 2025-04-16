using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEventConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Topics_SpeakerId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TopicId",
                table: "Events",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Topics_TopicId",
                table: "Events",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Topics_TopicId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_TopicId",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Topics_SpeakerId",
                table: "Events",
                column: "SpeakerId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
