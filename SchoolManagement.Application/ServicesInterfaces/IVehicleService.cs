using SchoolManagement.Application.DTOs.Vehicle;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IVehicleService
    {
        Task<List<GetVehicleDto>> GetAllAsync();
        Task<GetVehicleDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateVehicleDto dto);
        Task UpdateAsync(UpdateVehicleDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsPlateNumberUniqueAsync(string plateNum, int? excludeId = null);
        Task<bool> IsChaseeUniqueAsync(string chasee, int? excludeId = null);
        Task<List<Drive>> GetAvailableDriversAsync();
    }
}
