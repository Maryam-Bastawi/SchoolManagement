using SchoolManagement.Application.DTOs.Drive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IDriveService
    {
        Task<List<GetDriveDto>> GetAllAsync();
        Task<GetDriveDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateDriveDto dto);
        Task UpdateAsync(UpdateDriveDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsMobileUniqueAsync(string mobile, int? excludeId = null);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
    }
}
