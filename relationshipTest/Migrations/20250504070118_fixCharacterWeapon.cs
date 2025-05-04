using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace relationshipTest.Migrations
{
    /// <inheritdoc />
    public partial class fixCharacterWeapon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Backpacks_BackPackId",
                table: "Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Weapons_WeaponId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_WeaponId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "BackPackId",
                table: "Weapons",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_BackPackId",
                table: "Weapons",
                newName: "IX_Weapons_CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Weapons",
                newName: "BackPackId");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                newName: "IX_Weapons_BackPackId");

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Weapons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponId",
                table: "Weapons",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Backpacks_BackPackId",
                table: "Weapons",
                column: "BackPackId",
                principalTable: "Backpacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Weapons_WeaponId",
                table: "Weapons",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id");
        }
    }
}
