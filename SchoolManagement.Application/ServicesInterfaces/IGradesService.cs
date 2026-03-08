using SchoolManagement.Application.DTOs.Grades;
using SchoolManagement.Application.DTOs.Stages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
    public interface IGradesService
    {

            Task<List<GetGradesDto>> GetAllAsync();
            Task<GetGradesDto> GetByIdAsync(int id);
            Task<int> CreateAsync(CreateGradesDto dto);
            Task UpdateAsync(UpdateGradesDto dto);
            Task DeleteAsync(int id);
            Task<bool> ExistsAsync(int id);
            Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
            Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null);
        }
    }

