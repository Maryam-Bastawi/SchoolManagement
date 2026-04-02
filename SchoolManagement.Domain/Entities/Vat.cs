using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Vat
    {
        public int Id { get; set; }
        public string? VATNM { get; set; }
        public string? VATNM_E { get; set; }
        public string? NOTES { get; set; }
        public decimal VAT_PERCENT { get; set; }
        public bool IS_DEFUALT { get; set; } = false;
    }
}
