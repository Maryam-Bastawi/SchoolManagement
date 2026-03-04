using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.StuStatus
{
    public class CreateStudentStatusDto
    {
        public string StatusName { get; set; } = null!;
        public string StatusNameEn { get; set; } = null!;
    }
}