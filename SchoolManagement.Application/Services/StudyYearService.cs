using Microsoft.AspNetCore.Server.IISIntegration;
using SchoolManagement.Application.DTOs.StudyYear;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class StudyYearService : IStudyYearService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<StudyYear, int> StudyYearRepo => _unitOfWork.Repository<StudyYear, int>();

        public StudyYearService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetStudyYearDto>> GetAllAsync()
        {
            var years = await StudyYearRepo.GetAllAsync();
            return years
                .OrderBy(x => x.StudyYearsNm)
                .Select(x => new GetStudyYearDto
                {
                    Id = x.Id,
                    StudyYearsNm = x.StudyYearsNm,
                    StudyYearsNm_E = x.StudyYearsNm_E,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate,
                    IsClosed = x.IsClosed,
                    IsNewYear = x.IsNewYear,
                    IsDefault = x.IsDefault
                }).ToList();
        }

        public async Task<GetStudyYearDto?> GetByIdAsync(int id)
        {
            var entity = await StudyYearRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetStudyYearDto
            {
                Id = entity.Id,
                StudyYearsNm = entity.StudyYearsNm,
                StudyYearsNm_E = entity.StudyYearsNm_E,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                IsClosed = entity.IsClosed,
                IsNewYear = entity.IsNewYear,
                IsDefault = entity.IsDefault
            };
        }

        public async Task<int> CreateAsync(CreateStudyYearDto dto)
        {
            var entity = new StudyYear
            {

                StudyYearsNm = dto.StudyYearsNm?.Trim(),
                StudyYearsNm_E = dto.StudyYearsNm_E?.Trim(),
                FromDate = dto.FromDate,
                ToDate = dto.ToDate,
                IsClosed = dto.IsClosed,
                IsNewYear = dto.IsNewYear,
                IsDefault = dto.IsDefault

            };

            await StudyYearRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateStudyYearDto dto)
        {
            var entity = await StudyYearRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"السنة الدراسية برقم {dto.Id} غير موجود");

            entity.StudyYearsNm = dto.StudyYearsNm?.Trim();
            entity.StudyYearsNm_E = dto.StudyYearsNm_E?.Trim();
            entity.FromDate = dto.FromDate;
            entity.ToDate = dto.ToDate;
            entity.IsClosed = dto.IsClosed;
            entity.IsNewYear = dto.IsNewYear;
            entity.IsDefault = dto.IsDefault;

            StudyYearRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await StudyYearRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"السنة الدراسية برقم {id} غير موجود");

            StudyYearRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await StudyYearRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await StudyYearRepo.GetAllAsync();
            return !all.Any(x => x.StudyYearsNm!.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await StudyYearRepo.GetAllAsync();
            return !all.Any(x => x.StudyYearsNm_E!.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public static class IdGenerator
        {
            public static async Task<int> GetNextIdAsync<T>(
                IGenericRepository<T, int> repository) where T : class
            {
                var allEntities = await repository.GetAllAsync();
                if (!allEntities.Any())
                    return 1;

                return allEntities.Max(e => (int)e.GetType().GetProperty("Id")!.GetValue(e)!) + 1;
            }
        }
    }
}
