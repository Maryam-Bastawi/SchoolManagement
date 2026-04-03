using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        Task<int> CreateAsync(CreateStudentDto dto, IFormFile? imageFile = null);
        Task UpdateAsync(CreateStudentDto dto);
        Task DeleteAsync(int id);
        Task<string?> SaveStudentImageAsync(IFormFile? imageFile);
        Task DeleteStudentImageAsync(string? imagePath);
        Task<List<SelectListItem>> GetStagesListAsync();
        Task<List<SelectListItem>> GetGradesListAsync();
        Task<List<SelectListItem>> GetClassroomsListAsync();
        Task<List<SelectListItem>> GetSchoolsListAsync();
        Task<List<SelectListItem>> GetNationsListAsync();
        Task<List<SelectListItem>> GetSectionsListAsync();
        Task<List<SelectListItem>> GetAreasListAsync();
        Task<List<SelectListItem>> GetStudentStatusesListAsync();
        Task<List<SelectListItem>> GetTransferTypesListAsync();
        Task<List<SelectListItem>> GetVehiclesListAsync();
        Task<List<SelectListItem>> GetDiscountsListAsync();
        Task<List<SelectListItem>> GetGendersListAsync();
    }
}
