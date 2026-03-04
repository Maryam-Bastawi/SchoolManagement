using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DisplayCd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Depart",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsNewYear",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NextGrade",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "DisplayCode",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayCode",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "CreditLimit",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Depart",
                table: "Students",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewYear",
                table: "Students",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextGrade",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
