using SchoolManagement.Application.DTOs.TransferType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
   
        public interface ITransferTypeService
        {
            Task<int> CreateAsync(CreateTransferTypeDto dto);
            Task UpdateAsync(UpdateTransferTypeDto dto);
            Task DeleteAsync(int id);
            Task<GetTransferTypeDto> GetByIdAsync(int id);
            Task<List<GetTransferTypeDto>> GetAllAsync();
        }
    
}
