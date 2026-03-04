using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.TransLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface ITransLineService
    {
        Task<List<GetTransLineDto>> GetAllAsync();
        Task<GetTransLineDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateTransLineDto dto);
        Task UpdateAsync(UpdateTransLineDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
