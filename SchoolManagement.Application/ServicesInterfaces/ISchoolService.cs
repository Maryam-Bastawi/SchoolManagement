using SchoolManagement.Application.DTOs.Schoool;
using SchoolManagement.Application.DTOs.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface ISchoolService
    {
        Task<List<GetSchoolDto>> GetAllAsync();
        Task<GetSchoolDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateSchoolDto dto);
        Task UpdateAsync(UpdateSchoolDto dto);
        Task DeleteAsync(int id);
    }
}
