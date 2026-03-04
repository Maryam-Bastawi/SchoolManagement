namespace SchoolManagement.Application.DTOs.Discount
{
    public class GetDiscountDto
    {
        public int Id { get; set; }
        public string DescountNm { get; set; } = null!;
        public string DescountNm_E { get; set; } = null!;
        public decimal? DiscVal { get; set; }
        public decimal? DiscPer { get; set; }
        public bool DiscVal2 { get; set; }
    }
}