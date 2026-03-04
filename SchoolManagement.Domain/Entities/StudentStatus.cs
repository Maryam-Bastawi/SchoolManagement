using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class StudentStatus
    {
        public int Id { get; set; }
        public string? StatusName { get; set; }
        public string? StatusNameEn { get; set; }
    }
}
