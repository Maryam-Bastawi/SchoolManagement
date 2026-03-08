using SchoolManagement.Application.DTOs.Areas;
using SchoolManagement.Application.DTOs.Stages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IStagesService
    {
        Task<List<GetStagesDto>> GetAllAsync();
        Task<GetStagesDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateStagesDto dto);
        Task UpdateAsync(UpdateStagesDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
