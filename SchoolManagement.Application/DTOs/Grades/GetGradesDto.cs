namespace SchoolManagement.Application.DTOs.Grades
{
    public class GetGradesDto
    {
        public int Id { get; set; }
        public string? GradesNm { get; set; }
        public string? GradesNm_E { get; set; }
        public int? StagesId { get; set; }
        public string? StageName { get; set; } // للعرض
        public int? SchoolId { get; set; }
        public string? SchoolName { get; set; } // للعرض
        public int? CostCenterId { get; set; }
        public string? CostCenterName { get; set; } // للعرض
        public int? TransCostId { get; set; }
        public decimal? Term1Fee { get; set; }
        public decimal? Term2Fee { get; set; }
        public decimal? RegistrationFee { get; set; }
        public decimal? BookFee { get; set; }
        public decimal? OtherFee { get; set; }
        public int? NextStageId { get; set; }
        public string? NextStageName { get; set; } // للعرض
        public int? NextGradeId { get; set; }
        public string? NextGradeName { get; set; } // للعرض
        public int? NextSchoolId { get; set; }
        public string? NextSchoolName { get; set; } // للعرض
        public int? studStatusId { get; set; }
        public string? StudentStatusName { get; set; } // للعرض
    }
}