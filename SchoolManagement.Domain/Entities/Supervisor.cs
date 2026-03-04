using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Supervisor
    {
        public int Id { get; set; } 
        public string? SupervisorNAME_E { get; set; }
        public string? SupervisorNAME { get; set; }
        public string? SupervisorMobile { get; set; }
    }
}
