namespace SchoolManagement.Application.DTOs.Vehicle
{
    public class CreateVehicleDto
    {
        public string CarName { get; set; } = null!;
        public string CarNameEn { get; set; } = null!;
        public bool InStock { get; set; }
        public string? PlateNum { get; set; }
        public string? Color { get; set; }
        public string? Model { get; set; }
        public string? Chasee { get; set; }
        public string? LicIssueDate { get; set; }
        public string? LicEndDate { get; set; }
        public int? DriveId { get; set; }
    }
}