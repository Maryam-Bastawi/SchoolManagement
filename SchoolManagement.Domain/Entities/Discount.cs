using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string? DescountNm { get; set; }
        public string? DescountNm_E { get; set; }
        public decimal? DiscVal { get; set; }
        public decimal? DiscPer { get; set; }
        public bool DiscVal2 { get; set; }
    }
}
