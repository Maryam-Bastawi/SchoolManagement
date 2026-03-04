using SchoolManagement.Application.DTOs.Drive;
using SchoolManagement.Application.DTOs.Supervisor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface ISupervisorService
    {
        Task<List<GetSupervisorDto>> GetAllAsync();
        Task<GetSupervisorDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateSupervisorDto dto);
        Task UpdateAsync(UpdateSupervisorDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsMobileUniqueAsync(string mobile, int? excludeId = null);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
    }
}
