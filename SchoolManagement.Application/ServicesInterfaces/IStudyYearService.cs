using SchoolManagement.Application.DTOs.StudyYear;
using SchoolManagement.Application.DTOs.TransLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IStudyYearService
    {
        Task<List<GetStudyYearDto>> GetAllAsync();
        Task<GetStudyYearDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateStudyYearDto dto);
        Task UpdateAsync(UpdateStudyYearDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
