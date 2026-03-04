namespace SchoolManagement.Application.DTOs.Nation
{
    public class UpdateNationDto
    {
        public int Id { get; set; }
        public string NationNm { get; set; } = null!;
        public string NationNmE { get; set; } = null!;
    }
}