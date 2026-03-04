namespace SchoolManagement.Application.DTOs.TransCost
{
    public class GetTransCostDto
    {
        public int Id { get; set; }
        public string TransCostNm { get; set; } = null!;
        public string TranscostnmE { get; set; } = null!;
        public decimal? TransportCostValue { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? TransportCostValue2 { get; set; }
    }
}