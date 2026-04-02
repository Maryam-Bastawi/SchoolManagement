namespace SchoolManagement.Application.DTOs.Class
{
    public class CreateClassDto
    {
        public string ClassNm { get; set; } = null!;
        public string ClassNmEn { get; set; } = null!;
        public int? GradeId { get; set; }
        public string? GradeName { get; set; }

    }
}