using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string? BRNNM { get; set; }
        public string? BRNNM_E { get; set; }
        public string? RESP { get; set; }
    }
}
