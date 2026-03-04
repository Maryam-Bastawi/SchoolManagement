using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SchoolManagement.Domain.Entities
{
    public class Stages
    {
        public int Id { get; set; }
        public string? StageNM { get; set; }
        public string? StageNM_E { get; set; }

    }
}
