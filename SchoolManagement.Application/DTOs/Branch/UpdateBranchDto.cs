using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Branch
{
    public class UpdateBranchDto
    {
        public int Id { get; set; }
        public string? BRNNM { get; set; }
        public string? BRNNM_E { get; set; }
        public string? RESP { get; set; }
    }
}
