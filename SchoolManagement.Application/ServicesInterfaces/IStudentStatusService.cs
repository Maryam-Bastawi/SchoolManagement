using SchoolManagement.Application.DTOs.Nation;
using SchoolManagement.Application.DTOs.StuStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IStudentStatusService
    {
        Task<List<GetStudentStatusDto>> GetAllAsync();
        Task<GetStudentStatusDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateStudentStatusDto dto);
        Task UpdateAsync(UpdateStudentStatusDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
