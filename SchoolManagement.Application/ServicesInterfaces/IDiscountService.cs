using SchoolManagement.Application.DTOs.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IDiscountService
    {
        Task<int> CreateAsync(CreateDiscountDto dto);
        Task<List<GetDiscountDto>> GetAllAsync();
        Task<GetDiscountDto?> GetByIdAsync(int id);
        Task UpdateAsync(UpdateDiscountDto dto);
        Task DeleteAsync(int id);
    }
}
