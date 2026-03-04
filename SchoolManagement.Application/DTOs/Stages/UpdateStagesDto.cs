using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Stages
{
    public class UpdateStagesDto
    {
        public int Id { get; set; }
        public string StageNM { get; set; } = null!;
        public string StageNM_E { get; set; } = null!;
    }
}
