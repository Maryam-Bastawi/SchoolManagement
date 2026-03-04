using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Sections
{
    public class GetSectionDto
    {
        public int Id { get; set; }
        public string SectionName { get; set; } = null!;
        public string SectionNameEn { get; set; } = null!;
    }
}