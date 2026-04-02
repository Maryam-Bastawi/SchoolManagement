using SchoolManagement.Application.DTOs.Discount;
using SchoolManagement.Application.DTOs.Vat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IVatService
    {
        Task<int> CreateAsync(CreateVatDto dto);
        Task<List<GetVatDto>> GetAllAsync();
        Task<GetVatDto?> GetByIdAsync(int id);
        Task UpdateAsync(UpdateVatDto dto);
        Task DeleteAsync(int id);
    }
}
