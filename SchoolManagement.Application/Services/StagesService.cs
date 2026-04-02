using SchoolManagement.Application.DTOs.Stages;
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
    public class StagesService : IStagesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<Stages, int> StagesRepo => _unitOfWork.Repository<Stages, int>();

        public StagesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetStagesDto>> GetAllAsync()
        {
            var stages = await StagesRepo.GetAllAsync();

            return stages
                .OrderBy(x => x.StageNM)
                .Select(x => new GetStagesDto
                {
                    Id = x.Id,
                    StageNM = x.StageNM,
                    StageNM_E = x.StageNM_E
                }).ToList();
        }

        public async Task<GetStagesDto?> GetByIdAsync(int id)
        {
            var entity = await StagesRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetStagesDto
            {
                Id = entity.Id,
                StageNM = entity.StageNM,
                StageNM_E = entity.StageNM_E
            };
        }

        public async Task<int> CreateAsync(CreateStagesDto dto)
        {
            var entity = new Stages
            {
                StageNM = dto.StageNM.Trim(),
                StageNM_E = dto.StageNM_E.Trim()
            };

            await StagesRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateStagesDto dto)
        {
            var entity = await StagesRepo.GetByIdAsync(dto.Id);

            if (entity == null)
                throw new KeyNotFoundException($"المرحلة برقم {dto.Id} غير موجودة");

            entity.StageNM = dto.StageNM.Trim();
            entity.StageNM_E = dto.StageNM_E.Trim();

            StagesRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await StagesRepo.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"المرحلة برقم {id} غير موجودة");

            StagesRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await StagesRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await StagesRepo.GetAllAsync();

            return !all.Any(x =>
                x.StageNM.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await StagesRepo.GetAllAsync();

            return !all.Any(x =>
                x.StageNM_E.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        // نفس IdGenerator المستخدم في AreaService
        public static class IdGenerator
        {
            public static async Task<int> GetNextIdAsync<T>(IGenericRepository<T, int> repository) where T : class
            {
                var allEntities = await repository.GetAllAsync();

                if (!allEntities.Any())
                    return 1;

                return allEntities.Max(e => (int)e.GetType().GetProperty("Id")!.GetValue(e)!) + 1;
            }
        }
    }
}
