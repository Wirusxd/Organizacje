using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspBattleArena.Migrations
{
    /// <inheritdoc />
    public partial class Initial06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameOfBoss",
                table: "Organizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfBoss",
                table: "Organizations");
        }
    }
}
