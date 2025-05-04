using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace relationshipTest.Migrations
{
    /// <inheritdoc />
    public partial class editCharTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks",
                column: "CharacterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks",
                column: "CharacterId");
        }
    }
}
