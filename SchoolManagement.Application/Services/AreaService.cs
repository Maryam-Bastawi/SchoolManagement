using SchoolManagement.Application.DTOs.Areas;
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
    public class AreaService : IAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<Area, int> AreaRepo => _unitOfWork.Repository<Area, int>();

        public AreaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAreaDto>> GetAllAsync()
        {
            var areas = await AreaRepo.GetAllAsync();
            return areas
                .OrderBy(x => x.AreaNm)
                .Select(x => new GetAreaDto
                {
                    Id = x.Id,
                    AreaNm = x.AreaNm,
                    AreaNm_E = x.AreaNm_E,
                    Resp = x.Resp
                }).ToList();
        }

        public async Task<GetAreaDto?> GetByIdAsync(int id)
        {
            var entity = await AreaRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetAreaDto
            {
                Id = entity.Id,
                AreaNm = entity.AreaNm,
                AreaNm_E = entity.AreaNm_E,
                Resp = entity.Resp
            };
        }

        public async Task<int> CreateAsync(CreateAreaDto dto)
        {
            var entity = new Area
            {
                AreaNm = dto.AreaNm.Trim(),
                AreaNm_E = dto.AreaNm_E.Trim(),
                Resp = dto.Resp.Trim()
            };

            await AreaRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateAreaDto dto)
        {
            var entity = await AreaRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"المنطقة برقم {dto.Id} غير موجود");

            entity.AreaNm = dto.AreaNm.Trim();
            entity.AreaNm_E = dto.AreaNm_E.Trim();
            entity.Resp = dto.Resp.Trim();

            AreaRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await AreaRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"المنطقة برقم {id} غير موجود");

            AreaRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await AreaRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await AreaRepo.GetAllAsync();
            return !all.Any(x => x.AreaNm.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await AreaRepo.GetAllAsync();
            return !all.Any(x => x.AreaNm_E.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        // نفس IdGenerator زي DiscountService
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
