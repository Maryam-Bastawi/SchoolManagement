using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rregistSud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrationStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HijriDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GregorianDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstTerm = table.Column<bool>(type: "bit", nullable: false),
                    SecondTerm = table.Column<bool>(type: "bit", nullable: false),
                    FirstTermStudyFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SecondTermStudyFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    transCost_value_sem1Id = table.Column<int>(type: "int", nullable: true),
                    transCost_value_sem2Id = table.Column<int>(type: "int", nullable: true),
                    FirstTermRegistrationFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FirstTermBooksFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    other = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationStudents_TransCosts_transCost_value_sem1Id",
                        column: x => x.transCost_value_sem1Id,
                        principalTable: "TransCosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationStudents_TransCosts_transCost_value_sem2Id",
                        column: x => x.transCost_value_sem2Id,
                        principalTable: "TransCosts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationStudents_StudentId",
                table: "RegistrationStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationStudents_transCost_value_sem1Id",
                table: "RegistrationStudents",
                column: "transCost_value_sem1Id");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationStudents_transCost_value_sem2Id",
                table: "RegistrationStudents",
                column: "transCost_value_sem2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationStudents");
        }
    }
}
