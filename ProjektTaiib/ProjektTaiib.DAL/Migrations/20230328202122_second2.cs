using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektTaiib.DAL.Migrations
{
    /// <inheritdoc />
    public partial class second2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailedInformation_Users_Id_user",
                table: "DetailedInformation");

            migrationBuilder.RenameColumn(
                name: "Id_user",
                table: "DetailedInformation",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailedInformation_Id_user",
                table: "DetailedInformation",
                newName: "IX_DetailedInformation_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailedInformation_Users_UserId",
                table: "DetailedInformation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id_user",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailedInformation_Users_UserId",
                table: "DetailedInformation");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DetailedInformation",
                newName: "Id_user");

            migrationBuilder.RenameIndex(
                name: "IX_DetailedInformation_UserId",
                table: "DetailedInformation",
                newName: "IX_DetailedInformation_Id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailedInformation_Users_Id_user",
                table: "DetailedInformation",
                column: "Id_user",
                principalTable: "Users",
                principalColumn: "Id_user",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
