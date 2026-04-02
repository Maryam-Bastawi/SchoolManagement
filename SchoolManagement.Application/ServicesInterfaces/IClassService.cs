using SchoolManagement.Application.DTOs.Areas;
using SchoolManagement.Application.DTOs.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IClassService
    {
        Task<List<GetClassDto>> GetAllAsync();
        Task<GetClassDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateClassDto dto);
        Task UpdateAsync(UpdateClassDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);

    }
}
