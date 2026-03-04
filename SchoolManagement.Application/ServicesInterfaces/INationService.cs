using SchoolManagement.Application.DTOs.Nation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface INationService
    {
        Task<List<GetNationDto>> GetAllAsync();
        Task<GetNationDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateNationDto dto);
        Task UpdateAsync(UpdateNationDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
