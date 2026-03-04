using SchoolManagement.Application.DTOs.Branch;
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
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<Branch, int> BranchRepo => _unitOfWork.Repository<Branch, int>();

        public BranchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetBranchDto>> GetAllAsync()
        {
            var branches = await BranchRepo.GetAllAsync();
            return branches
                .OrderBy(x => x.BRNNM)
                .Select(x => new GetBranchDto
                {
                    Id = x.Id,
                    BRNNM = x.BRNNM,
                    BRNNM_E = x.BRNNM_E,
                    RESP = x.RESP
                }).ToList();
        }

        public async Task<GetBranchDto?> GetByIdAsync(int id)
        {
            var entity = await BranchRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetBranchDto
            {
                Id = entity.Id,
                BRNNM = entity.BRNNM,
                BRNNM_E = entity.BRNNM_E,
                RESP = entity.RESP
            };
        }

        public async Task<int> CreateAsync(CreateBranchDto dto)
        {
            var entity = new Branch
            {
                Id = await IdGenerator.GetNextIdAsync(BranchRepo),
                BRNNM = dto.BRNNM.Trim(),
                BRNNM_E = dto.BRNNM_E.Trim(),
                RESP = dto.RESP?.Trim()
            };

            await BranchRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateBranchDto dto)
        {
            var entity = await BranchRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"الفرع برقم {dto.Id} غير موجود");

            entity.BRNNM = dto.BRNNM.Trim();
            entity.BRNNM_E = dto.BRNNM_E.Trim();
            entity.RESP = dto.RESP?.Trim();

            BranchRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await BranchRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"الفرع برقم {id} غير موجود");

            BranchRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await BranchRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await BranchRepo.GetAllAsync();
            return !all.Any(x => x.BRNNM.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await BranchRepo.GetAllAsync();
            return !all.Any(x => x.BRNNM_E.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        // نفس IdGenerator زي CostCenterService
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
