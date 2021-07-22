using Microsoft.EntityFrameworkCore.Migrations;

namespace career.DAL.Migrations
{
    public partial class Ref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users");

            
            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "VacancyTypes",
                keyColumn: "VacancyTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VacancyTypes",
                keyColumn: "VacancyTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departmants",
                keyColumn: "DepartmantId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departmants",
                keyColumn: "DepartmantId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departmants",
                keyColumn: "DepartmantId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departmants",
                keyColumn: "DepartmantId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departmants",
                keyColumn: "DepartmantId",
                keyValue: 14);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
