namespace SchoolManagement.Application.DTOs.Drive
{
    public class CreateDriveDto
    {
        public string DrvNm { get; set; } = null!;
        public string DrvNmEn { get; set; } = null!;
        public string? Mobil { get; set; }
        public string? LicEnd { get; set; }
    }
}