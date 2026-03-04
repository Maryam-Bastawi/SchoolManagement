namespace SchoolManagement.Application.DTOs.Grades
{
    public class UpdateGradesDto
    {
        public int Id { get; set; }

        public string GradesNm { get; set; } = null!;
        public string GradesNm_E { get; set; } = null!;

        public int? StagesId { get; set; }
        public int? SchoolId { get; set; }
        public int? CostCenterId { get; set; }
        public int? TransCostId { get; set; }

        // Fees
        public decimal? Term1Fee { get; set; }
        public decimal? Term2Fee { get; set; }
        public decimal? RegistrationFee { get; set; }
        public decimal? BookFee { get; set; }
        public decimal? OtherFee { get; set; }
        public decimal? TransportFee { get; set; }

        // Promotion
        public int? NextStageId { get; set; }
        public int? NextGradeId { get; set; }
        public int? NextSchoolId { get; set; }
        public string? PromotionType { get; set; }

        public bool IsExit { get; set; }

        public int? studStatusId { get; set; }
    }
}