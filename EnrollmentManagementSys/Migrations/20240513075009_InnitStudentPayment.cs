using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class InnitStudentPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPayments_Students_StudentRecordID",
                table: "StudentPayments");

            migrationBuilder.DropIndex(
                name: "IX_StudentPayments_StudentRecordID",
                table: "StudentPayments");

            migrationBuilder.DropColumn(
                name: "StudentRecordID",
                table: "StudentPayments");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPayments_RecordID",
                table: "StudentPayments",
                column: "RecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPayments_Students_RecordID",
                table: "StudentPayments",
                column: "RecordID",
                principalTable: "Students",
                principalColumn: "RecordID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPayments_Students_RecordID",
                table: "StudentPayments");

            migrationBuilder.DropIndex(
                name: "IX_StudentPayments_RecordID",
                table: "StudentPayments");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentRecordID",
                table: "StudentPayments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentPayments_StudentRecordID",
                table: "StudentPayments",
                column: "StudentRecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPayments_Students_StudentRecordID",
                table: "StudentPayments",
                column: "StudentRecordID",
                principalTable: "Students",
                principalColumn: "RecordID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
