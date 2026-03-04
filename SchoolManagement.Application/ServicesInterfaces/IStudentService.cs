using SchoolManagement.Application.DTOs.Student;
using SchoolManagement.Application.DTOs.TransferType;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IStudentService
    {
        Task<List<CreateStudentDto>> GetAllStudentsAsync();
        Task<CreateStudentDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateStudentDto dto);
        Task UpdateAsync(CreateStudentDto dto);
        Task DeleteAsync(int id);
    }
}
