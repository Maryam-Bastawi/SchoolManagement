namespace SchoolManagement.Application.DTOs.CostCenter
{
    public class CreateCostCenterDto
    {
        public string CostNm { get; set; } = null!;
        public string CostNme { get; set; } = null!;
        public string? Notes { get; set; }
    }
}