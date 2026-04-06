using SchoolManagement.Application.DTOs.RegistrationStudent;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IRegistrationStudentService
    {
        Task<RegistrationIndexVM> GetRegistrationIndexDataAsync(int? studyYearId = null);
        Task<RegistrationCreateVM> GetStudentForRegistrationAsync(int studentId, int studyYearId);
        Task<bool> CreateRegistrationAsync(RegistrationCreateVM model, int userId);
        Task<bool> IsStudentAlreadyRegisteredAsync(int studentId, int studyYearId);
        Task<List<RegistrationStudent>> GetStudentRegistrationsAsync(int studentId);
        Task<RegistrationStudent> GetRegistrationByIdAsync(int id);
        Task<bool> UpdateRegistrationAsync(RegistrationCreateVM model);
        Task<bool> DeleteRegistrationAsync(int id);
        Task<List<RegistrationStudent>> GetRegistrationsByStudyYearAsync(int studyYearId);
        Task<List<RegistrationStudent>> GetAllRegistrationsAsync();
    }
}
