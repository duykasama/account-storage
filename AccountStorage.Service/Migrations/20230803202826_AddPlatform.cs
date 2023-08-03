using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountStorage.Service.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "PlatformId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PlatformId",
                table: "Accounts",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Platforms_PlatformId",
                table: "Accounts",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Platforms_PlatformId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PlatformId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
