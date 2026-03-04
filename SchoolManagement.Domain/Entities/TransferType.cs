using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class TransferType
    {
        public int Id { get; set; }
        public string? Route { get; set; }
        public string? RouteEng { get; set; }
        public decimal? Exmount1 { get; set; }
        public decimal? Exmount2 { get; set; }
    }
}
