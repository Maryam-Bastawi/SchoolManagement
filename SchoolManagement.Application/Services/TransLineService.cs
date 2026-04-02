using SchoolManagement.Application.DTOs.TransLine;
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
    public class TransLineService : ITransLineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<TransLine, int> TransLineRepo => _unitOfWork.Repository<TransLine, int>();

        public TransLineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetTransLineDto>> GetAllAsync()
        {
            var lines = await TransLineRepo.GetAllAsync();
            return lines
                .OrderBy(x => x.TransLineName)
                .Select(x => new GetTransLineDto
                {
                    Id = x.Id,
                    TransLineName = x.TransLineName,
                    TransLineNameEn = x.TransLineNameEn,
                    Responsible = x.Responsible
                }).ToList();
        }

        public async Task<GetTransLineDto?> GetByIdAsync(int id)
        {
            var entity = await TransLineRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetTransLineDto
            {
                Id = entity.Id,
                TransLineName = entity.TransLineName,
                TransLineNameEn = entity.TransLineNameEn,
                Responsible = entity.Responsible
            };
        }

        public async Task<int> CreateAsync(CreateTransLineDto dto)
        {
            var entity = new TransLine
            {
                TransLineName = dto.TransLineName?.Trim(),
                TransLineNameEn = dto.TransLineNameEn?.Trim(),
                Responsible = dto.Responsible?.Trim()
            };

            await TransLineRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateTransLineDto dto)
        {
            var entity = await TransLineRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"خط النقل برقم {dto.Id} غير موجود");

            entity.TransLineName = dto.TransLineName?.Trim();
            entity.TransLineNameEn = dto.TransLineNameEn?.Trim();
            entity.Responsible = dto.Responsible?.Trim();

            TransLineRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await TransLineRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"خط النقل برقم {id} غير موجود");

            TransLineRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await TransLineRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await TransLineRepo.GetAllAsync();
            return !all.Any(x => x.TransLineName!.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await TransLineRepo.GetAllAsync();
            return !all.Any(x => x.TransLineNameEn!.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        // نفس IdGenerator زي باقي الـ Services
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
