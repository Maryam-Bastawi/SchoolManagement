namespace SchoolManagement.Application.DTOs.TransferType
{
    public class GetTransferTypeDto
    {
        public int Id { get; set; }
        public string Route { get; set; } = null!;
        public string RouteEng { get; set; } = null!;
        public decimal? Exmount1 { get; set; }
        public decimal? Exmount2 { get; set; }
    }
}