using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Areas
{
    public class CreateAreaDto
    {
        public string AreaNm { get; set; } = null!;
        public string AreaNm_E { get; set; } = null!;
        public string? Resp { get; set; }
    }
}