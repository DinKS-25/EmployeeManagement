using Microsoft.EntityFrameworkCore.Migrations;

namespace InternWork.Migrations
{
    public partial class seededdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "Address", "FatherName", "Fresher", "MotherName", "Name", "Salary", "role" },
                values: new object[] { 12345, "befjkvhbfdjlvbajscnsdbv", "Suriyan", true, "jeyalakshmi", "dinesh", 12345.540000000001, 0 });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "EmpId", "password" },
                values: new object[] { 12345, "DineshKumar" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 12345);

            migrationBuilder.DeleteData(
                table: "Logins",
                keyColumn: "EmpId",
                keyValue: 12345);
        }
    }
}
