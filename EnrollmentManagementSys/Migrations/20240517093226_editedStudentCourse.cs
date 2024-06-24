using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class editedStudentCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "StudentSubjects");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentCourseID",
                table: "StudentSubjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StudentCourseID",
                table: "Fees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentCourseID",
                table: "StudentSubjects",
                column: "StudentCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_StudentCourseID",
                table: "Fees",
                column: "StudentCourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_StudentsCourses_StudentCourseID",
                table: "Fees",
                column: "StudentCourseID",
                principalTable: "StudentsCourses",
                principalColumn: "StudentCourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_StudentsCourses_StudentCourseID",
                table: "StudentSubjects",
                column: "StudentCourseID",
                principalTable: "StudentsCourses",
                principalColumn: "StudentCourseID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_StudentsCourses_StudentCourseID",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_StudentsCourses_StudentCourseID",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentCourseID",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Fees_StudentCourseID",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "StudentCourseID",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "StudentCourseID",
                table: "Fees");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "StudentSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
