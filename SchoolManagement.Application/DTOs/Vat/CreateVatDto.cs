using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Vat
{
    public class CreateVatDto
    {
        public string? VATNM { get; set; }

        public string? VATNM_E { get; set; }

        public string? NOTES { get; set; }

        public decimal VAT_PERCENT { get; set; }

        public bool IS_DEFUALT { get; set; }
    }
}
