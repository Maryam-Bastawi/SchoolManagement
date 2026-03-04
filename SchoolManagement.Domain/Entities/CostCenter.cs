using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class CostCenter
    {
        public int Id { get; set; }
        public string? CostNm { get; set; } 
        public string? CostNme { get; set; }  
        public string? Notes { get; set; }
    }
}
