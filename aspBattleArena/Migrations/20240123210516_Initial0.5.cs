using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspBattleArena.Migrations
{
    /// <inheritdoc />
    public partial class Initial05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Bases",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Bases");
        }
    }
}
