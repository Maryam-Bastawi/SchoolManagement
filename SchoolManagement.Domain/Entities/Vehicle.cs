using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? CarName { get; set; }
        public string? CarNameEn { get; set; }
        public bool InStock { get; set; }
        public string? PlateNum { get; set; }
        public string? Color { get; set; }
        public string? Model { get; set; }
        public string? Chasee { get; set; }
        public string? LicIssueDate { get; set; }
        public string? LicEndDate { get; set; }
        public Drive? Drive { get; set; }
        public int? DriveId { get; set; }

    }
}
