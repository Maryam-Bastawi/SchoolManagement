using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.Nation;
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
    public class NationService : INationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<Nation, int> NationRepo
            => _unitOfWork.Repository<Nation, int>();

        public NationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetNationDto>> GetAllAsync()
        {
            var nations = await NationRepo.GetAllAsync();

            return nations
                .OrderBy(x => x.NationNm)
                .Select(x => new GetNationDto
                {
                    Id = x.Id,
                    NationNm = x.NationNm,
                    NationNmE = x.NationNmE
                }).ToList();
        }

        public async Task<GetNationDto?> GetByIdAsync(int id)
        {
            var entity = await NationRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetNationDto
            {
                Id = entity.Id,
                NationNm = entity.NationNm,
                NationNmE = entity.NationNmE
            };
        }

        public async Task<int> CreateAsync(CreateNationDto dto)
        {
            var entity = new Nation
            {
                NationNm = dto.NationNm.Trim(),
                NationNmE = dto.NationNmE.Trim()
            };

            await NationRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            string displayCode = $"Nation-{entity.Id:D3}"; // للعرض فقط

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateNationDto dto)
        {
            var entity = await NationRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"الجنسية برقم {dto.Id} غير موجودة");

            entity.NationNm = dto.NationNm.Trim();
            entity.NationNmE = dto.NationNmE.Trim();

            NationRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await NationRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"الجنسية برقم {id} غير موجودة");

            NationRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
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
        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await NationRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = NationRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            var exists = await query.AnyAsync(x => x.NationNmE == name.Trim());

            return !await query.AnyAsync(x => x.NationNmE == name.Trim());
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = NationRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.NationNm == name.Trim());
        }


    }
}
