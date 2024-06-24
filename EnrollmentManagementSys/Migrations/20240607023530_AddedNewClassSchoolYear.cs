using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewClassSchoolYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolYear",
                table: "StudentPayments");

            migrationBuilder.DropColumn(
                name: "SchoolYear",
                table: "OfferedSubjects");

            migrationBuilder.DropColumn(
                name: "SchoolYear",
                table: "Fees");

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolYearID",
                table: "StudentPayments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolYearID",
                table: "OfferedSubjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolYearID",
                table: "Fees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    SchoolYearID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolYearName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.SchoolYearID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPayments_SchoolYearID",
                table: "StudentPayments",
                column: "SchoolYearID");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedSubjects_SchoolYearID",
                table: "OfferedSubjects",
                column: "SchoolYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_SchoolYearID",
                table: "Fees",
                column: "SchoolYearID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_SchoolYears_SchoolYearID",
                table: "Fees",
                column: "SchoolYearID",
                principalTable: "SchoolYears",
                principalColumn: "SchoolYearID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferedSubjects_SchoolYears_SchoolYearID",
                table: "OfferedSubjects",
                column: "SchoolYearID",
                principalTable: "SchoolYears",
                principalColumn: "SchoolYearID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPayments_SchoolYears_SchoolYearID",
                table: "StudentPayments",
                column: "SchoolYearID",
                principalTable: "SchoolYears",
                principalColumn: "SchoolYearID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_SchoolYears_SchoolYearID",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferedSubjects_SchoolYears_SchoolYearID",
                table: "OfferedSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPayments_SchoolYears_SchoolYearID",
                table: "StudentPayments");

            migrationBuilder.DropTable(
                name: "SchoolYears");

            migrationBuilder.DropIndex(
                name: "IX_StudentPayments_SchoolYearID",
                table: "StudentPayments");

            migrationBuilder.DropIndex(
                name: "IX_OfferedSubjects_SchoolYearID",
                table: "OfferedSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Fees_SchoolYearID",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "SchoolYearID",
                table: "StudentPayments");

            migrationBuilder.DropColumn(
                name: "SchoolYearID",
                table: "OfferedSubjects");

            migrationBuilder.DropColumn(
                name: "SchoolYearID",
                table: "Fees");

            migrationBuilder.AddColumn<string>(
                name: "SchoolYear",
                table: "StudentPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolYear",
                table: "OfferedSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolYear",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
