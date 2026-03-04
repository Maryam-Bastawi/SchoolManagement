using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.Sections;
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
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork _unitOfWork;

        private IGenericRepository<Section, int> SectionRepo
            => _unitOfWork.Repository<Section, int>();

        public SectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetSectionDto>> GetAllAsync()
        {
            var sections = await SectionRepo.GetAllAsync();

            return sections
                .OrderBy(x => x.SectionName)
                .Select(x => new GetSectionDto
                {
                    Id = x.Id,
                    SectionName = x.SectionName,
                    SectionNameEn = x.SectionNameEn
                }).ToList();
        }

        public async Task<GetSectionDto?> GetByIdAsync(int id)
        {
            var entity = await SectionRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetSectionDto
            {
                Id = entity.Id,
                SectionName = entity.SectionName,
                SectionNameEn = entity.SectionNameEn
            };
        }

        public async Task<int> CreateAsync(CreateSectionDto dto)
        {
            var entity = new Section
            {
                Id = await IdGenerator.GetNextIdAsync(SectionRepo),

                SectionName = dto.SectionName.Trim(),
                SectionNameEn = dto.SectionNameEn.Trim()
            };

            await SectionRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            string displayCode = $"Section-{entity.Id:D3}"; // للعرض فقط

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateSectionDto dto)
        {
            var entity = await SectionRepo.GetByIdAsync(dto.Id);

            if (entity == null)
                throw new KeyNotFoundException($"القسم برقم {dto.Id} غير موجود");

            entity.SectionName = dto.SectionName.Trim();
            entity.SectionNameEn = dto.SectionNameEn.Trim();

            SectionRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await SectionRepo.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"القسم برقم {id} غير موجود");

            SectionRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await SectionRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = SectionRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.SectionName == name.Trim());
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = SectionRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.SectionNameEn == name.Trim());
        }
    }
    public static class IdGenerator
    {
        // T هو نوع الـ entity، TId هو نوع الـ Id (هنا int)
        public static async Task<int> GetNextIdAsync<T>(
            IGenericRepository<T, int> repository) where T : class
        {
            var allEntities = await repository.GetAllAsync();
            if (!allEntities.Any())
                return 1;

            // Max على الـ Id ويضيف 1
            return allEntities.Max(e => (int)e.GetType().GetProperty("Id")!.GetValue(e)!) + 1;
        }
    }
}
