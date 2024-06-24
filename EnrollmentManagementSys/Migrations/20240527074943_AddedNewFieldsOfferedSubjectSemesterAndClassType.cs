using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewFieldsOfferedSubjectSemesterAndClassType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassTypes",
                columns: table => new
                {
                    ClassTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTypes", x => x.ClassTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    SemesterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.SemesterID);
                });

            migrationBuilder.CreateTable(
                name: "OfferedSubjects",
                columns: table => new
                {
                    OfferedSubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOffered = table.Column<DateOnly>(type: "date", nullable: false),
                    SubjectRate = table.Column<float>(type: "real", nullable: false),
                    SchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SemesterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentCourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferedSubjects", x => x.OfferedSubjectID);
                    table.ForeignKey(
                        name: "FK_OfferedSubjects_ClassTypes_ClassTypeID",
                        column: x => x.ClassTypeID,
                        principalTable: "ClassTypes",
                        principalColumn: "ClassTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferedSubjects_Semesters_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semesters",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferedSubjects_StudentSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "StudentSubjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferedSubjects_StudentsCourses_StudentCourseID",
                        column: x => x.StudentCourseID,
                        principalTable: "StudentsCourses",
                        principalColumn: "StudentCourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferedSubjects_ClassTypeID",
                table: "OfferedSubjects",
                column: "ClassTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedSubjects_SemesterID",
                table: "OfferedSubjects",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedSubjects_StudentCourseID",
                table: "OfferedSubjects",
                column: "StudentCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedSubjects_SubjectId",
                table: "OfferedSubjects",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferedSubjects");

            migrationBuilder.DropTable(
                name: "ClassTypes");

            migrationBuilder.DropTable(
                name: "Semesters");
        }
    }
}
