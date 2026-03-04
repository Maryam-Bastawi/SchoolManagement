using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class TransCost
    {
        public int Id { get; set; }
        public string? TransCostNm { get; set; }
        public string? TranscostnmE { get; set; }
        public decimal? TransportCostValue { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? TransportCostValue2 { get; set; }
    }
}
