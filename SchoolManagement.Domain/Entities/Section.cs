using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string? SectionName { get; set; }
        public string? SectionNameEn { get; set; }
    }
}
