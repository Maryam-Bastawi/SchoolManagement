using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StudentTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassroomsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Discounts_DiscounttypesId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Nations_NationsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassroomsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DiscounttypesId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_NationsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CREDIT_LIMIT",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassroomsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DiscounttypesId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DisplayCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EnrollmentDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ISNEWYEAR",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IdPlace",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SUSPIND_AC",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StopAutoPromotion",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsExit",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "PromotionType",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TransportFee",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "NewGradeId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "TaxStatus",
                table: "Students",
                newName: "WorkPhone");

            migrationBuilder.RenameColumn(
                name: "SuspendAccount",
                table: "Students",
                newName: "RegisterNextYear");

            migrationBuilder.RenameColumn(
                name: "SuspenDate",
                table: "Students",
                newName: "WithdrawDate");

            migrationBuilder.RenameColumn(
                name: "StudentSex",
                table: "Students",
                newName: "WorkDate");

            migrationBuilder.RenameColumn(
                name: "StudentIdNumber",
                table: "Students",
                newName: "StudentImagePath");

            migrationBuilder.RenameColumn(
                name: "StopSms",
                table: "Students",
                newName: "IsTaxable");

            migrationBuilder.RenameColumn(
                name: "Respons",
                table: "Students",
                newName: "ResponseName");

            migrationBuilder.RenameColumn(
                name: "PreviousSchool",
                table: "Students",
                newName: "RecordNumber");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Students",
                newName: "PassportNumber");

            migrationBuilder.RenameColumn(
                name: "Passport",
                table: "Students",
                newName: "Notes2");

            migrationBuilder.RenameColumn(
                name: "Note2",
                table: "Students",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Students",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "Mobile2",
                table: "Students",
                newName: "IssuePlace");

            migrationBuilder.RenameColumn(
                name: "Mobile1",
                table: "Students",
                newName: "HomePhone");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Students",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "IdIssueDate",
                table: "Students",
                newName: "IssueDate");

            migrationBuilder.RenameColumn(
                name: "IdEndDate",
                table: "Students",
                newName: "ExpiryDate");

            migrationBuilder.RenameColumn(
                name: "GraduateDate",
                table: "Students",
                newName: "ContractDate");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnglishName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DebtAmount",
                table: "Students",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsFileWithdrawn",
                table: "Students",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Discounttypeid",
                table: "Students",
                column: "Discounttypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NationalId",
                table: "Students",
                column: "NationalId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_NextGradeId",
                table: "Grades",
                column: "NextGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_NextSchoolId",
                table: "Grades",
                column: "NextSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_NextStageId",
                table: "Grades",
                column: "NextStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Grades_NextGradeId",
                table: "Grades",
                column: "NextGradeId",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Schools_NextSchoolId",
                table: "Grades",
                column: "NextSchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Stages_NextStageId",
                table: "Grades",
                column: "NextStageId",
                principalTable: "Stages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassroomId",
                table: "Students",
                column: "ClassroomId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Discounts_Discounttypeid",
                table: "Students",
                column: "Discounttypeid",
                principalTable: "Discounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Nations_NationalId",
                table: "Students",
                column: "NationalId",
                principalTable: "Nations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Grades_NextGradeId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Schools_NextSchoolId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Stages_NextStageId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassroomId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Discounts_Discounttypeid",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Nations_NationalId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassroomId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Discounttypeid",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_NationalId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Grades_NextGradeId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_NextSchoolId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_NextStageId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "DebtAmount",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsFileWithdrawn",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "WorkPhone",
                table: "Students",
                newName: "TaxStatus");

            migrationBuilder.RenameColumn(
                name: "WorkDate",
                table: "Students",
                newName: "StudentSex");

            migrationBuilder.RenameColumn(
                name: "WithdrawDate",
                table: "Students",
                newName: "SuspenDate");

            migrationBuilder.RenameColumn(
                name: "StudentImagePath",
                table: "Students",
                newName: "StudentIdNumber");

            migrationBuilder.RenameColumn(
                name: "ResponseName",
                table: "Students",
                newName: "Respons");

            migrationBuilder.RenameColumn(
                name: "RegisterNextYear",
                table: "Students",
                newName: "SuspendAccount");

            migrationBuilder.RenameColumn(
                name: "RecordNumber",
                table: "Students",
                newName: "PreviousSchool");

            migrationBuilder.RenameColumn(
                name: "PassportNumber",
                table: "Students",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Notes2",
                table: "Students",
                newName: "Passport");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Students",
                newName: "Note2");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Students",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "IssuePlace",
                table: "Students",
                newName: "Mobile2");

            migrationBuilder.RenameColumn(
                name: "IssueDate",
                table: "Students",
                newName: "IdIssueDate");

            migrationBuilder.RenameColumn(
                name: "IsTaxable",
                table: "Students",
                newName: "StopSms");

            migrationBuilder.RenameColumn(
                name: "HomePhone",
                table: "Students",
                newName: "Mobile1");

            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "Students",
                newName: "IdEndDate");

            migrationBuilder.RenameColumn(
                name: "ContractDate",
                table: "Students",
                newName: "GraduateDate");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Students",
                newName: "Location");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EnglishName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CREDIT_LIMIT",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassroomsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscounttypesId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayCode",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ISNEWYEAR",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IdPlace",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SUSPIND_AC",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StopAutoPromotion",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExit",
                table: "Grades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PromotionType",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TransportFee",
                table: "Grades",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewGradeId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomsId",
                table: "Students",
                column: "ClassroomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DiscounttypesId",
                table: "Students",
                column: "DiscounttypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NationsId",
                table: "Students",
                column: "NationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassroomsId",
                table: "Students",
                column: "ClassroomsId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Discounts_DiscounttypesId",
                table: "Students",
                column: "DiscounttypesId",
                principalTable: "Discounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Nations_NationsId",
                table: "Students",
                column: "NationsId",
                principalTable: "Nations",
                principalColumn: "Id");
        }
    }
}
