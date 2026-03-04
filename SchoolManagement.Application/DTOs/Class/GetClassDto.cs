namespace SchoolManagement.Application.DTOs.Class
{
    public class GetClassDto
    {
        public int Id { get; set; }

        public string ClassNm { get; set; } = null!;
        public string ClassNmEn { get; set; } = null!;

        public int? GradeId { get; set; }
        public string? GradeName { get; set; }

        public int? NewGradeId { get; set; }
    }
}