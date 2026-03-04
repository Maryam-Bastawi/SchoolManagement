using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.StuStatus;
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
    public class StudentStatusService : IStudentStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        private IGenericRepository<StudentStatus, int> StudentStatusRepo
            => _unitOfWork.Repository<StudentStatus, int>();

        public StudentStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetStudentStatusDto>> GetAllAsync()
        {
            var statuses = await StudentStatusRepo.GetAllAsync();

            return statuses
                .OrderBy(x => x.StatusName)
                .Select(x => new GetStudentStatusDto
                {
                    Id = x.Id,
                    StatusName = x.StatusName,
                    StatusNameEn = x.StatusNameEn
                }).ToList();
        }

        public async Task<GetStudentStatusDto?> GetByIdAsync(int id)
        {
            var entity = await StudentStatusRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetStudentStatusDto
            {
                Id = entity.Id,
                StatusName = entity.StatusName,
                StatusNameEn = entity.StatusNameEn
            };
        }

        public async Task<int> CreateAsync(CreateStudentStatusDto dto)
        {
            var entity = new StudentStatus
            {
                Id = await IdGenerator
                         .GetNextIdAsync(StudentStatusRepo),

                StatusName = dto.StatusName.Trim(),
                StatusNameEn = dto.StatusNameEn.Trim()
            };

            await StudentStatusRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            string displayCode = $"StudentStatus-{entity.Id:D3}"; // للعرض فقط

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateStudentStatusDto dto)
        {
            var entity = await StudentStatusRepo.GetByIdAsync(dto.Id);

            if (entity == null)
                throw new KeyNotFoundException($"حالة الطالب برقم {dto.Id} غير موجودة");

            entity.StatusName = dto.StatusName.Trim();
            entity.StatusNameEn = dto.StatusNameEn.Trim();

            StudentStatusRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await StudentStatusRepo.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"حالة الطالب برقم {id} غير موجودة");

            StudentStatusRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await StudentStatusRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = StudentStatusRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.StatusName == name.Trim());
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = StudentStatusRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.StatusNameEn == name.Trim());
        }
    }
}
