namespace SchoolManagement.Application.DTOs.CostCenter
{
    public class GetCostCenterDto
    {
        public int Id { get; set; }
        public string CostNm { get; set; } = null!;
        public string CostNme { get; set; } = null!;
        public string? Notes { get; set; }
    }
}