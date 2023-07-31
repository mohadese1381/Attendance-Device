using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceDevice.Migrations
{
    /// <inheritdoc />
    public partial class insertingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(table: "Person", columns: new string[] { "PersonId", "Name", "LastName", "NationalCode", "identityCode", "PictureURL" },
            //values: new object[] { 2, "mohadese", "akhondi", "123", "", ""});
            //migrationBuilder.AlterColumn<string>("PictureURL", "Person", nullable: true);
            // migrationBuilder.AlterColumn<string>("identityCode", "Person", nullable: true);
         
            /* migrationBuilder.InsertData(table:"Attendance",columns:new string[] { "AttendanceId", "PersonId", "Day", "EntryTime", "ExitTime" },values:new object[]
            {"1","1",DayOfWeek.Friday, new DateTime(2019,05,10,8,15,0),new DateTime(2019,05,10,19,15,0)});*/
            // migrationBuilder.InsertData(table: "Person", columns: new string[] { "PersonId", "Name", "LastName", "NationalCode", "identityCode", "PictureURL" },
            //values: new object[] { 4, "Maryam", "Akbari", "567",null,null});
            //------------------------------------------------------------------------------
            
            migrationBuilder.Sql($@"
            SET IDENTITY_INSERT [dbo].[Attendance] ON;

            INSERT INTO [dbo].[Attendance] ([AttendanceId], [PersonId], [Day], [EntryTime], [ExitTime])
                VALUES
                    ('1', '1', {(int)DayOfWeek.Friday}, '{new DateTime(2019,05,10,8,15,0)}', '{new DateTime(2019,05,10,19,15,0)}');
            SET IDENTITY_INSERT [dbo].[Attendance] OFF;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
