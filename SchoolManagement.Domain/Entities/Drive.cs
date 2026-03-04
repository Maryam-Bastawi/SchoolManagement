using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Drive
    {
        public int Id { get; set; }
        public string? DrvNm { get; set; }
        public string? DrvNmEn { get; set; }
        public string? Mobil { get; set; }
        public string? LicEnd { get; set; }
    }
}
