using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DID);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    SubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Period = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.SubID);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Did = table.Column<int>(type: "int", nullable: false),
                    DepartmentDID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_students_Department_DepartmentDID",
                        column: x => x.DepartmentDID,
                        principalTable: "Department",
                        principalColumn: "DID");
                });

            migrationBuilder.CreateTable(
                name: "departmentSubject",
                columns: table => new
                {
                    DeptSubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DID = table.Column<int>(type: "int", nullable: false),
                    SubID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmentSubject", x => x.DeptSubID);
                    table.ForeignKey(
                        name: "FK_departmentSubject_Department_DID",
                        column: x => x.DID,
                        principalTable: "Department",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_departmentSubject_subjects_SubID",
                        column: x => x.SubID,
                        principalTable: "subjects",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentSubject",
                columns: table => new
                {
                    StudSubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudID = table.Column<int>(type: "int", nullable: false),
                    SubID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSubject", x => x.StudSubID);
                    table.ForeignKey(
                        name: "FK_studentSubject_students_StudID",
                        column: x => x.StudID,
                        principalTable: "students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentSubject_subjects_SubID",
                        column: x => x.SubID,
                        principalTable: "subjects",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departmentSubject_DID",
                table: "departmentSubject",
                column: "DID");

            migrationBuilder.CreateIndex(
                name: "IX_departmentSubject_SubID",
                table: "departmentSubject",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_students_DepartmentDID",
                table: "students",
                column: "DepartmentDID");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubject_StudID",
                table: "studentSubject",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubject_SubID",
                table: "studentSubject",
                column: "SubID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departmentSubject");

            migrationBuilder.DropTable(
                name: "studentSubject");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
