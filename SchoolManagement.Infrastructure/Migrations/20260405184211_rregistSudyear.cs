using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rregistSudyear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyYearId",
                table: "RegistrationStudents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationStudents_StudyYearId",
                table: "RegistrationStudents",
                column: "StudyYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationStudents_StudyYears_StudyYearId",
                table: "RegistrationStudents",
                column: "StudyYearId",
                principalTable: "StudyYears",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationStudents_StudyYears_StudyYearId",
                table: "RegistrationStudents");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationStudents_StudyYearId",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "StudyYearId",
                table: "RegistrationStudents");
        }
    }
}
