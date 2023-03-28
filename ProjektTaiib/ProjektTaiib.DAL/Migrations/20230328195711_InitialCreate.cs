using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektTaiib.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id_event = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id_event);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id_sponsor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sponsor_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id_sponsor);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moderator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_user);
                });

            migrationBuilder.CreateTable(
                name: "EventSponsor",
                columns: table => new
                {
                    EventsId_event = table.Column<int>(type: "int", nullable: false),
                    SponsorsId_sponsor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSponsor", x => new { x.EventsId_event, x.SponsorsId_sponsor });
                    table.ForeignKey(
                        name: "FK_EventSponsor_Events_EventsId_event",
                        column: x => x.EventsId_event,
                        principalTable: "Events",
                        principalColumn: "Id_event",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSponsor_Sponsors_SponsorsId_sponsor",
                        column: x => x.SponsorsId_sponsor,
                        principalTable: "Sponsors",
                        principalColumn: "Id_sponsor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailedInformation",
                columns: table => new
                {
                    Id_information = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Payment = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Zip_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    House_number = table.Column<int>(type: "int", nullable: false),
                    Local_number = table.Column<int>(type: "int", nullable: true),
                    Additional_information = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedInformation", x => x.Id_information);
                    table.ForeignKey(
                        name: "FK_DetailedInformation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id_ticket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_event = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Premium = table.Column<bool>(type: "bit", nullable: true),
                    UserId_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id_ticket);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_Id_event",
                        column: x => x.Id_event,
                        principalTable: "Events",
                        principalColumn: "Id_event",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId_user",
                        column: x => x.UserId_user,
                        principalTable: "Users",
                        principalColumn: "Id_user");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailedInformation_UserId",
                table: "DetailedInformation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSponsor_SponsorsId_sponsor",
                table: "EventSponsor",
                column: "SponsorsId_sponsor");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Id_event",
                table: "Tickets",
                column: "Id_event");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId_user",
                table: "Tickets",
                column: "UserId_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailedInformation");

            migrationBuilder.DropTable(
                name: "EventSponsor");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
