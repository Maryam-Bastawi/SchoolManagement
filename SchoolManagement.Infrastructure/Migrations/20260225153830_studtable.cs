using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class studtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
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
                name: "CreditLimit",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Depart",
                table: "Students",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discounttypeid",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscounttypesId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradesId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GraduateDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IdEndDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IdIssueDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsGraduate",
                table: "Students",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewYear",
                table: "Students",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile1",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile2",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextGrade",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note2",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousSchool",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Respons",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StagesId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StopAutoPromotion",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StopSms",
                table: "Students",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentIdNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentSex",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentStatusId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SuspenDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SuspendAccount",
                table: "Students",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxStatus",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransferTypeId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaNm_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsible = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BRNNM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BRNNM_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RESP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostNme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescountNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescountNm_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscVal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscPer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscVal2 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrvNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrvNmEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicEnd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationNmE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolNmEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageNM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StageNM_E = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyYearsNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyYearsNm_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    IsNewYear = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransCostNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranscostnmE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportCostValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransportCostValue2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exmount1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Exmount2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransLineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransLineNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsible = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    PlateNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chasee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drives",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradesNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradesNm_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StagesId = table.Column<int>(type: "int", nullable: true),
                    SchoolId = table.Column<int>(type: "int", nullable: true),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    Term1Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Term2Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RegistrationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BookFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransportFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransCostId = table.Column<int>(type: "int", nullable: true),
                    NextStageId = table.Column<int>(type: "int", nullable: true),
                    NextGradeId = table.Column<int>(type: "int", nullable: true),
                    NextSchoolId = table.Column<int>(type: "int", nullable: true),
                    PromotionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExit = table.Column<bool>(type: "bit", nullable: false),
                    studentStatusId = table.Column<int>(type: "int", nullable: true),
                    studStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_CostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Grades_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Grades_Stages_StagesId",
                        column: x => x.StagesId,
                        principalTable: "Stages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Grades_StudentStatuses_studentStatusId",
                        column: x => x.studentStatusId,
                        principalTable: "StudentStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Grades_TransCosts_TransCostId",
                        column: x => x.TransCostId,
                        principalTable: "TransCosts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassNmEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: true),
                    NewGradeId = table.Column<int>(type: "int", nullable: true),
                    GradesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Grades_GradesId",
                        column: x => x.GradesId,
                        principalTable: "Grades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AreaId",
                table: "Students",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomsId",
                table: "Students",
                column: "ClassroomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DiscounttypesId",
                table: "Students",
                column: "DiscounttypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradesId",
                table: "Students",
                column: "GradesId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NationsId",
                table: "Students",
                column: "NationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SectionId",
                table: "Students",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StagesId",
                table: "Students",
                column: "StagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentStatusId",
                table: "Students",
                column: "StudentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TransferTypeId",
                table: "Students",
                column: "TransferTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_VehicleId",
                table: "Students",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GradesId",
                table: "Classes",
                column: "GradesId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CostCenterId",
                table: "Grades",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SchoolId",
                table: "Grades",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StagesId",
                table: "Grades",
                column: "StagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_studentStatusId",
                table: "Grades",
                column: "studentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TransCostId",
                table: "Grades",
                column: "TransCostId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriveId",
                table: "Vehicles",
                column: "DriveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Areas_AreaId",
                table: "Students",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");

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
                name: "FK_Students_Grades_GradesId",
                table: "Students",
                column: "GradesId",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Nations_NationsId",
                table: "Students",
                column: "NationsId",
                principalTable: "Nations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Sections_SectionId",
                table: "Students",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Stages_StagesId",
                table: "Students",
                column: "StagesId",
                principalTable: "Stages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentStatuses_StudentStatusId",
                table: "Students",
                column: "StudentStatusId",
                principalTable: "StudentStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_TransferTypes_TransferTypeId",
                table: "Students",
                column: "TransferTypeId",
                principalTable: "TransferTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Vehicles_VehicleId",
                table: "Students",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Areas_AreaId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassroomsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Discounts_DiscounttypesId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grades_GradesId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Nations_NationsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Sections_SectionId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Stages_StagesId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentStatuses_StudentStatusId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_TransferTypes_TransferTypeId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Vehicles_VehicleId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Nations");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "StudyYears");

            migrationBuilder.DropTable(
                name: "TransferTypes");

            migrationBuilder.DropTable(
                name: "TransLines");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "CostCenters");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "StudentStatuses");

            migrationBuilder.DropTable(
                name: "TransCosts");

            migrationBuilder.DropIndex(
                name: "IX_Students_AreaId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassroomsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DiscounttypesId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GradesId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_NationsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SectionId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StagesId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentStatusId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TransferTypeId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_VehicleId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassroomsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Depart",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Discounttypeid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DiscounttypesId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EnrollmentDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradesId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GraduateDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IdEndDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IdIssueDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IdPlace",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsGraduate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsNewYear",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Mobile1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Mobile2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NextGrade",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Note2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PreviousSchool",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Respons",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StagesId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StopAutoPromotion",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StopSms",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentIdNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentSex",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentStatusId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SuspenDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SuspendAccount",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TaxStatus",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TransferTypeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
