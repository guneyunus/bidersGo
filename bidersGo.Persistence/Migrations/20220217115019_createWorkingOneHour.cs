using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bidersGo.Persistence.Migrations
{
    public partial class createWorkingOneHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "WorkingHoursOfWeeks");

            migrationBuilder.DropColumn(
                name: "WorkingStart",
                table: "WorkingHoursOfWeeks");

            migrationBuilder.DropColumn(
                name: "WorkingStop",
                table: "WorkingHoursOfWeeks");

            migrationBuilder.CreateTable(
                name: "workingForOneHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    weekID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkingHourTotalTime = table.Column<double>(type: "float", nullable: false),
                    WorkingStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkingStop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workingForOneHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workingForOneHours_WorkingHoursOfWeeks_weekID",
                        column: x => x.weekID,
                        principalTable: "WorkingHoursOfWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_workingForOneHours_weekID",
                table: "workingForOneHours",
                column: "weekID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workingForOneHours");

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingHours",
                table: "WorkingHoursOfWeeks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingStart",
                table: "WorkingHoursOfWeeks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingStop",
                table: "WorkingHoursOfWeeks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
