using SchoolManagement.Application.DTOs.CostCenter;
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
    public class CostCenterService : ICostCenterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<CostCenter, int> CostCenterRepo => _unitOfWork.Repository<CostCenter, int>();

        public CostCenterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetCostCenterDto>> GetAllAsync()
        {
            var centers = await CostCenterRepo.GetAllAsync();
            return centers
                .OrderBy(x => x.CostNm)
                .Select(x => new GetCostCenterDto
                {
                    Id = x.Id,
                    CostNm = x.CostNm,
                    CostNme = x.CostNme,
                    Notes = x.Notes
                }).ToList();
        }

        public async Task<GetCostCenterDto?> GetByIdAsync(int id)
        {
            var entity = await CostCenterRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetCostCenterDto
            {
                Id = entity.Id,
                CostNm = entity.CostNm,
                CostNme = entity.CostNme,
                Notes = entity.Notes
            };
        }

        public async Task<int> CreateAsync(CreateCostCenterDto dto)
        {
            var entity = new CostCenter
            {
                CostNm = dto.CostNm.Trim(),
                CostNme = dto.CostNme.Trim(),
                Notes = dto.Notes?.Trim()
            };

            await CostCenterRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateCostCenterDto dto)
        {
            var entity = await CostCenterRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"مركز التكلفة برقم {dto.Id} غير موجود");

            entity.CostNm = dto.CostNm.Trim();
            entity.CostNme = dto.CostNme.Trim();
            entity.Notes = dto.Notes?.Trim();

            CostCenterRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await CostCenterRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"مركز التكلفة برقم {id} غير موجود");

            CostCenterRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await CostCenterRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await CostCenterRepo.GetAllAsync();
            return !all.Any(x => x.CostNm.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await CostCenterRepo.GetAllAsync();
            return !all.Any(x => x.CostNme.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        // نفس IdGenerator زي AreaService
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
