using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceDevice.Migrations
{
    /// <inheritdoc />
    public partial class addChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Exit",
                table: "Attendance",
                newName: "ExitTime");

            migrationBuilder.RenameColumn(
                name: "Entry",
                table: "Attendance",
                newName: "EntryTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Exit",
                table: "Attendance",
                newName: "ExitTime");

            migrationBuilder.RenameColumn(
                name: "Entry",
                table: "Attendance",
                newName: "EntryTime");
        }
    }
}
