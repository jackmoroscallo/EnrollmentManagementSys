using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewClassSubjectSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentCourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_Instructors_StudentsCourses_StudentCourseID",
                        column: x => x.StudentCourseID,
                        principalTable: "StudentsCourses",
                        principalColumn: "StudentCourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectSchedules",
                columns: table => new
                {
                    SubjectScheduleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mon = table.Column<bool>(type: "bit", nullable: false),
                    Tue = table.Column<bool>(type: "bit", nullable: false),
                    Wed = table.Column<bool>(type: "bit", nullable: false),
                    Thu = table.Column<bool>(type: "bit", nullable: false),
                    Fri = table.Column<bool>(type: "bit", nullable: false),
                    Sat = table.Column<bool>(type: "bit", nullable: false),
                    Sun = table.Column<bool>(type: "bit", nullable: false),
                    RoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentCourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectLevel = table.Column<int>(type: "int", nullable: false),
                    SectionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchoolYearID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSchedules", x => x.SubjectScheduleID);
                    table.ForeignKey(
                        name: "FK_SubjectSchedules_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "InstructorID");
                    table.ForeignKey(
                        name: "FK_SubjectSchedules_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID");
                    table.ForeignKey(
                        name: "FK_SubjectSchedules_SchoolYears_SchoolYearID",
                        column: x => x.SchoolYearID,
                        principalTable: "SchoolYears",
                        principalColumn: "SchoolYearID");
                    table.ForeignKey(
                        name: "FK_SubjectSchedules_Sections_SectionID",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionID");
                    table.ForeignKey(
                        name: "FK_SubjectSchedules_Semesters_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semesters",
                        principalColumn: "SemesterID");
                    table.ForeignKey(
                        name: "FK_SubjectSchedules_StudentSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "StudentSubjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_SubjectSchedules_StudentsCourses_StudentCourseID",
                        column: x => x.StudentCourseID,
                        principalTable: "StudentsCourses",
                        principalColumn: "StudentCourseID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_StudentCourseID",
                table: "Instructors",
                column: "StudentCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSchedules_InstructorID",
                table: "SubjectSchedules",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSchedules_RoomID",
                table: "SubjectSchedules",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSchedules_SchoolYearID",
                table: "SubjectSchedules",
                column: "SchoolYearID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSchedules_SectionID",
                table: "SubjectSchedules",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSchedules_SemesterID",
                table: "SubjectSchedules",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSchedules_StudentCourseID",
                table: "SubjectSchedules",
                column: "StudentCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSchedules_SubjectId",
                table: "SubjectSchedules",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectSchedules");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
