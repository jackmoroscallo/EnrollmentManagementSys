using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewClassesEnrollmentAndEnrollmentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnrollmentsStatuses",
                columns: table => new
                {
                    EnrollmentStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollmentStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentsStatuses", x => x.EnrollmentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentCourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearLevelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolYearID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TermID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrollmentStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollments_EnrollmentsStatuses_EnrollmentStatusID",
                        column: x => x.EnrollmentStatusID,
                        principalTable: "EnrollmentsStatuses",
                        principalColumn: "EnrollmentStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_SchoolYears_SchoolYearID",
                        column: x => x.SchoolYearID,
                        principalTable: "SchoolYears",
                        principalColumn: "SchoolYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_StudentsCourses_StudentCourseID",
                        column: x => x.StudentCourseID,
                        principalTable: "StudentsCourses",
                        principalColumn: "StudentCourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Terms_TermID",
                        column: x => x.TermID,
                        principalTable: "Terms",
                        principalColumn: "TermID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_YearLevels_YearLevelID",
                        column: x => x.YearLevelID,
                        principalTable: "YearLevels",
                        principalColumn: "YearLevelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentStatusID",
                table: "Enrollments",
                column: "EnrollmentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SchoolYearID",
                table: "Enrollments",
                column: "SchoolYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentCourseID",
                table: "Enrollments",
                column: "StudentCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_TermID",
                table: "Enrollments",
                column: "TermID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_YearLevelID",
                table: "Enrollments",
                column: "YearLevelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "EnrollmentsStatuses");
        }
    }
}
