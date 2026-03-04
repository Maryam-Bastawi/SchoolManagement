using SchoolManagement.Application.DTOs.Areas;
using SchoolManagement.Application.DTOs.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IBankService
    {
        Task<List<GetBankDto>> GetAllAsync();
        Task<GetBankDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateBankDto dto);
        Task UpdateAsync(UpdateBankDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
