using SchoolManagement.Application.DTOs.Sections;
using SchoolManagement.Application.DTOs.StuStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface ISectionService
    {
        Task<List<GetSectionDto>> GetAllAsync();
        Task<GetSectionDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateSectionDto dto);
        Task UpdateAsync(UpdateSectionDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
