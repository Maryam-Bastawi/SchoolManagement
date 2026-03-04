using SchoolManagement.Application.DTOs.Sections;
using SchoolManagement.Application.DTOs.TransCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface ITransCostService
    {
        Task<List<GetTransCostDto>> GetAllAsync();
        Task<GetTransCostDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateTransCostDto dto);
        Task UpdateAsync(UpdateTransCostDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
