using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Commends",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Commends_AppUserId",
                table: "Commends",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commends_AspNetUsers_AppUserId",
                table: "Commends",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commends_AspNetUsers_AppUserId",
                table: "Commends");

            migrationBuilder.DropIndex(
                name: "IX_Commends_AppUserId",
                table: "Commends");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Commends");
        }
    }
}
