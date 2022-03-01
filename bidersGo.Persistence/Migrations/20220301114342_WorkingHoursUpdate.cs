using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bidersGo.Persistence.Migrations
{
    public partial class WorkingHoursUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingHourTotalTime",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "WorkingStart",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "WorkingStop",
                table: "workingForOneHours");

            migrationBuilder.AddColumn<bool>(
                name: "AllDay",
                table: "workingForOneHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "workingForOneHours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "workingForOneHours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "workingForOneHours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecurrenceException",
                table: "workingForOneHours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecurrenceRule",
                table: "workingForOneHours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartDate",
                table: "workingForOneHours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "workingForOneHours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDisabled",
                table: "workingForOneHours",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllDay",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "RecurrenceException",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "RecurrenceRule",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "workingForOneHours");

            migrationBuilder.DropColumn(
                name: "isDisabled",
                table: "workingForOneHours");

            migrationBuilder.AddColumn<double>(
                name: "WorkingHourTotalTime",
                table: "workingForOneHours",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingStart",
                table: "workingForOneHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingStop",
                table: "workingForOneHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
