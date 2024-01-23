using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspBattleArena.Migrations
{
    /// <inheritdoc />
    public partial class Initial04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Bosses_OgranizationId",
                table: "Organizations");

            migrationBuilder.AlterColumn<int>(
                name: "OgranizationId",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BossId",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_BossId",
                table: "Organizations",
                column: "BossId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Bosses_BossId",
                table: "Organizations",
                column: "BossId",
                principalTable: "Bosses",
                principalColumn: "BossId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Bosses_BossId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_BossId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "BossId",
                table: "Organizations");

            migrationBuilder.AlterColumn<int>(
                name: "OgranizationId",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Bosses_OgranizationId",
                table: "Organizations",
                column: "OgranizationId",
                principalTable: "Bosses",
                principalColumn: "BossId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
