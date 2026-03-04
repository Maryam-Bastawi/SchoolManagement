using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class StudyYear
    {
        public int Id { get; set; }
        public string? StudyYearsNm { get; set; }
        public string? StudyYearsNm_E { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsClosed { get; set; }
        public bool IsNewYear { get; set; }
        public bool IsDefault { get; set; }
    }
}
