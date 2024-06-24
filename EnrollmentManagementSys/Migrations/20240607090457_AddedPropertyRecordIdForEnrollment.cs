using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertyRecordIdForEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecordID",
                table: "Enrollments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_RecordID",
                table: "Enrollments",
                column: "RecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_RecordID",
                table: "Enrollments",
                column: "RecordID",
                principalTable: "Students",
                principalColumn: "RecordID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_RecordID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_RecordID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "RecordID",
                table: "Enrollments");
        }
    }
}
