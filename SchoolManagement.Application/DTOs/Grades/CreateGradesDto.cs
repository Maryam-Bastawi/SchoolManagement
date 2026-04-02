using SchoolManagement.Application.DTOs.CostCenter;
using SchoolManagement.Application.DTOs.Schoool;
using SchoolManagement.Application.DTOs.Stages;
using SchoolManagement.Application.DTOs.StuStatus;
using SchoolManagement.Application.DTOs.TransCost;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.DTOs.Grades
{
    public class CreateGradesDto
    {
        public string GradesNm { get; set; } = null!;
        public string GradesNm_E { get; set; } = null!;

        public int? StagesId { get; set; }

        public int? SchoolId { get; set; }
        public int? CostCenterId { get; set; }

        // Fees
        public decimal? Term1Fee { get; set; }
        public decimal? Term2Fee { get; set; }
        public decimal? RegistrationFee { get; set; }
        public decimal? BookFee { get; set; }
        public decimal? OtherFee { get; set; }
        public int? TransCostId { get; set; }

        // Promotion
        public int? NextStageId { get; set; }
        public int? NextGradeId { get; set; }
        public int? NextSchoolId { get; set; }


        public int? studStatusId { get; set; }
    }
}