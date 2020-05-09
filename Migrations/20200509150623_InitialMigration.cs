using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_WebApp_Core.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DeptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 20, nullable: true),
                    DeptId = table.Column<int>(nullable: false),
                    departmentDeptId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_employees_Department_departmentDeptId",
                        column: x => x.departmentDeptId,
                        principalTable: "Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DeptId", "Name" },
                values: new object[] { 1, "HR" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmpId", "DeptId", "Email", "Name", "departmentDeptId" },
                values: new object[] { 1, 1, "JohnWick@gmail.com", "John Wick", null });

            migrationBuilder.CreateIndex(
                name: "IX_employees_departmentDeptId",
                table: "employees",
                column: "departmentDeptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
