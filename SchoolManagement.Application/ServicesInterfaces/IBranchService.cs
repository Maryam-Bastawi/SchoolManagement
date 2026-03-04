using SchoolManagement.Application.DTOs.Bank;
using SchoolManagement.Application.DTOs.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IBranchService
    {
        Task<List<GetBranchDto>> GetAllAsync();
        Task<GetBranchDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateBranchDto dto);
        Task UpdateAsync(UpdateBranchDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
