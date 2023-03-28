using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektTaiib.DAL.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "DetailedInformation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id_event", "Category", "Date", "Description", "Event_name", "Location" },
                values: new object[,]
                {
                    { 1, "Wystawa", new DateTime(2024, 10, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), "Obrazy hehe", "Wystawa obrazów Beksińskiego", "Warsaw Art Gallery" },
                    { 2, "Pokaz", new DateTime(2024, 12, 31, 23, 45, 0, 0, DateTimeKind.Unspecified), null, "Pokaz sztucznych ogni", "Rynek Katowice" },
                    { 3, "Koncert", new DateTime(2023, 11, 21, 18, 30, 0, 0, DateTimeKind.Unspecified), null, "Maryla Rodowicz - wiecznie mloda tour", "Spodek, Katowice" }
                });

            migrationBuilder.InsertData(
                table: "Sponsors",
                columns: new[] { "Id_sponsor", "Sponsor_name" },
                values: new object[,]
                {
                    { 1, "Tarczyński" },
                    { 2, "Pocztex" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_user", "Email", "Moderator", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "jedrek.oskarowski@gmail.com", false, "Haslo123", "Oskiii" },
                    { 2, "kowalski@gmail.com", true, "Haslo123", "modKowal" }
                });

            migrationBuilder.InsertData(
                table: "DetailedInformation",
                columns: new[] { "Id_information", "Additional_information", "City", "Country", "Email", "House_number", "Id_user", "Local_number", "Name", "Payment", "Phone", "Street", "Surname", "Zip_code" },
                values: new object[,]
                {
                    { 1, null, "Katowice", "Poland", "jedrek.oskarowski@gmail.com", 24, 1, 7, "Jędrek", "Blik", "123123123", "Francuska", "Oskarowski", "40-000" },
                    { 2, null, "Katowice", "Poland", "kowalski@gmail.com", 2, 2, null, "Jan", "Blik", "321321321", "Warszawska", "Kowalski", "40-000" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id_ticket", "Id_event", "Premium", "Price", "Type", "UserId_user" },
                values: new object[,]
                {
                    { 1, 1, false, 200.0, "Normalny", null },
                    { 2, 2, true, 50.0, "Ulgowy", null },
                    { 3, 3, true, 50.0, "Normalny", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DetailedInformation_Users_Id_user",
                table: "DetailedInformation",
                column: "Id_user",
                principalTable: "Users",
                principalColumn: "Id_user",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailedInformation_Users_Id_user",
                table: "DetailedInformation");

            migrationBuilder.DeleteData(
                table: "DetailedInformation",
                keyColumn: "Id_information",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DetailedInformation",
                keyColumn: "Id_information",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sponsors",
                keyColumn: "Id_sponsor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sponsors",
                keyColumn: "Id_sponsor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id_ticket",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id_ticket",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id_ticket",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id_event",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id_event",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id_event",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_user",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_user",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Id_user",
                table: "DetailedInformation",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailedInformation_Id_user",
                table: "DetailedInformation",
                newName: "IX_DetailedInformation_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "DetailedInformation",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailedInformation_Users_UserId",
                table: "DetailedInformation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id_user",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
