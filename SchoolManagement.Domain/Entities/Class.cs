using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string? ClassNm { get; set; }
        public string? ClassNmEn { get; set; }
        public int? GradeId { get; set; }
        public int? NewGradeId { get; set; }
        public Grades? Grades { get; set; }

    }
}
