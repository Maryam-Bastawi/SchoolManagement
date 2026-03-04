using SchoolManagement.Application.DTOs.Areas;
using SchoolManagement.Application.DTOs.TransCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IAreaService
    {
        Task<List<GetAreaDto>> GetAllAsync();
        Task<GetAreaDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateAreaDto dto);
        Task UpdateAsync(UpdateAreaDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
    }
}
