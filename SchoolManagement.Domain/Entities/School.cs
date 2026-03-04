using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string? SchoolNm { get; set; }
        public string? SchoolNmEn { get; set; }
    }
}
