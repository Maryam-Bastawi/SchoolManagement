using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RegistrationStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationStudents_Students_StudentId",
                table: "RegistrationStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationStudents_StudyYears_StudyYearId",
                table: "RegistrationStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationStudents_TransCosts_transCost_value_sem1Id",
                table: "RegistrationStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationStudents_TransCosts_transCost_value_sem2Id",
                table: "RegistrationStudents");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationStudents_transCost_value_sem1Id",
                table: "RegistrationStudents");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationStudents_transCost_value_sem2Id",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "FirstTerm",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "HijriDate",
                table: "RegistrationStudents");

            migrationBuilder.RenameColumn(
                name: "transCost_value_sem2Id",
                table: "RegistrationStudents",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "transCost_value_sem1Id",
                table: "RegistrationStudents",
                newName: "TransferTypeId");

            migrationBuilder.RenameColumn(
                name: "other",
                table: "RegistrationStudents",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "TotalPaid",
                table: "RegistrationStudents",
                newName: "SecondSemesterTransferFees");

            migrationBuilder.RenameColumn(
                name: "SecondTermStudyFees",
                table: "RegistrationStudents",
                newName: "SecondSemesterFees");

            migrationBuilder.RenameColumn(
                name: "SecondTerm",
                table: "RegistrationStudents",
                newName: "IsPaid");

            migrationBuilder.RenameColumn(
                name: "GregorianDate",
                table: "RegistrationStudents",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "FirstTermStudyFees",
                table: "RegistrationStudents",
                newName: "RegistrationFees");

            migrationBuilder.RenameColumn(
                name: "FirstTermRegistrationFees",
                table: "RegistrationStudents",
                newName: "OtherFees");

            migrationBuilder.RenameColumn(
                name: "FirstTermBooksFees",
                table: "RegistrationStudents",
                newName: "FirstSemesterTransferFees");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "RegistrationStudents",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<int>(
                name: "StudyYearId",
                table: "RegistrationStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "RegistrationStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountAfterDiscount",
                table: "RegistrationStudents",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BooksFees",
                table: "RegistrationStudents",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostCenterId",
                table: "RegistrationStudents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "RegistrationStudents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "RegistrationStudents",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountTypeId",
                table: "RegistrationStudents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountValue",
                table: "RegistrationStudents",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FirstSemesterFees",
                table: "RegistrationStudents",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationStudents_Students_StudentId",
                table: "RegistrationStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationStudents_StudyYears_StudyYearId",
                table: "RegistrationStudents",
                column: "StudyYearId",
                principalTable: "StudyYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationStudents_Students_StudentId",
                table: "RegistrationStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationStudents_StudyYears_StudyYearId",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "AmountAfterDiscount",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "BooksFees",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "DiscountTypeId",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "RegistrationStudents");

            migrationBuilder.DropColumn(
                name: "FirstSemesterFees",
                table: "RegistrationStudents");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "RegistrationStudents",
                newName: "transCost_value_sem2Id");

            migrationBuilder.RenameColumn(
                name: "TransferTypeId",
                table: "RegistrationStudents",
                newName: "transCost_value_sem1Id");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "RegistrationStudents",
                newName: "other");

            migrationBuilder.RenameColumn(
                name: "SecondSemesterTransferFees",
                table: "RegistrationStudents",
                newName: "TotalPaid");

            migrationBuilder.RenameColumn(
                name: "SecondSemesterFees",
                table: "RegistrationStudents",
                newName: "SecondTermStudyFees");

            migrationBuilder.RenameColumn(
                name: "RegistrationFees",
                table: "RegistrationStudents",
                newName: "FirstTermStudyFees");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "RegistrationStudents",
                newName: "GregorianDate");

            migrationBuilder.RenameColumn(
                name: "OtherFees",
                table: "RegistrationStudents",
                newName: "FirstTermRegistrationFees");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "RegistrationStudents",
                newName: "SecondTerm");

            migrationBuilder.RenameColumn(
                name: "FirstSemesterTransferFees",
                table: "RegistrationStudents",
                newName: "FirstTermBooksFees");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "RegistrationStudents",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<int>(
                name: "StudyYearId",
                table: "RegistrationStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "RegistrationStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "FirstTerm",
                table: "RegistrationStudents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HijriDate",
                table: "RegistrationStudents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationStudents_transCost_value_sem1Id",
                table: "RegistrationStudents",
                column: "transCost_value_sem1Id");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationStudents_transCost_value_sem2Id",
                table: "RegistrationStudents",
                column: "transCost_value_sem2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationStudents_Students_StudentId",
                table: "RegistrationStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationStudents_StudyYears_StudyYearId",
                table: "RegistrationStudents",
                column: "StudyYearId",
                principalTable: "StudyYears",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationStudents_TransCosts_transCost_value_sem1Id",
                table: "RegistrationStudents",
                column: "transCost_value_sem1Id",
                principalTable: "TransCosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationStudents_TransCosts_transCost_value_sem2Id",
                table: "RegistrationStudents",
                column: "transCost_value_sem2Id",
                principalTable: "TransCosts",
                principalColumn: "Id");
        }
    }
}
