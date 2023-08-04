using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountStorage.Service.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountAndPlatform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Platforms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Platforms");
        }
    }
}
