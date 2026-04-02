using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Bank
{
    public class UpdateBankDto
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string BankNameEn { get; set; }
        public string? Responsible { get; set; }
    }
}
