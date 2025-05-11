using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacation_Manager.Shared.DB.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assistents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VacationBalance = table.Column<int>(type: "int", nullable: false),
                    DaysOff = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    AssistentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationCalendars_Assistents_AssistentId",
                        column: x => x.AssistentId,
                        principalTable: "Assistents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VacationCalendarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationPeriods_VacationCalendars_VacationCalendarId",
                        column: x => x.VacationCalendarId,
                        principalTable: "VacationCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationCalendars_AssistentId",
                table: "VacationCalendars",
                column: "AssistentId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationPeriods_VacationCalendarId",
                table: "VacationPeriods",
                column: "VacationCalendarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationPeriods");

            migrationBuilder.DropTable(
                name: "VacationCalendars");

            migrationBuilder.DropTable(
                name: "Assistents");
        }
    }
}
