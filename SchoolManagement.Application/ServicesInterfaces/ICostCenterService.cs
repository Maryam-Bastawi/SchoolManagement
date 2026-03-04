using SchoolManagement.Application.DTOs.Areas;
using SchoolManagement.Application.DTOs.CostCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface ICostCenterService
    {
        Task<List<GetCostCenterDto>> GetAllAsync();
        Task<GetCostCenterDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateCostCenterDto dto);
        Task UpdateAsync(UpdateCostCenterDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
