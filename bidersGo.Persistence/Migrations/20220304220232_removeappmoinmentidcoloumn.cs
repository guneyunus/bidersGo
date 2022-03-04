using Microsoft.EntityFrameworkCore.Migrations;

namespace bidersGo.Persistence.Migrations
{
    public partial class removeappmoinmentidcoloumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "workingForOneHours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "workingForOneHours",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
