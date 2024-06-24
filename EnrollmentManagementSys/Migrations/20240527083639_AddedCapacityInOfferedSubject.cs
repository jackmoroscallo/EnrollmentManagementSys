using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class AddedCapacityInOfferedSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "OfferedSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "OfferedSubjects");
        }
    }
}
