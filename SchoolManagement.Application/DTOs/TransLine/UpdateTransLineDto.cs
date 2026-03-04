using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.TransLine
{
    public class UpdateTransLineDto
    {
        public int Id { get; set; }
        public string? TransLineName { get; set; }
        public string? TransLineNameEn { get; set; }
        public string? Responsible { get; set; }
    }
}
