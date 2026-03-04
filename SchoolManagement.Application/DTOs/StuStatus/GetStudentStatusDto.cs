using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.StuStatus
{
    public class GetStudentStatusDto
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
        public string StatusNameEn { get; set; } = null!;
    }
}
