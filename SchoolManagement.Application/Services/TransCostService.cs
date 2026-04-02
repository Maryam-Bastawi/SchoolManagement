using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.TransCost;
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
    public class TransCostService : ITransCostService
    {
        private readonly IUnitOfWork _unitOfWork;

        private IGenericRepository<TransCost, int> TransCostRepo
            => _unitOfWork.Repository<TransCost, int>();

        public TransCostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetTransCostDto>> GetAllAsync()
        {
            var list = await TransCostRepo.GetAllAsync();

            return list
                .OrderBy(x => x.TransCostNm)
                .Select(x => new GetTransCostDto
                {
                    Id = x.Id,
                    TransCostNm = x.TransCostNm,
                    TranscostnmE = x.TranscostnmE,
                    TransportCostValue = x.TransportCostValue,
                    DiscountPercentage = x.DiscountPercentage,
                    TransportCostValue2 = x.TransportCostValue2
                }).ToList();
        }

        public async Task<GetTransCostDto?> GetByIdAsync(int id)
        {
            var entity = await TransCostRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetTransCostDto
            {
                Id = entity.Id,
                TransCostNm = entity.TransCostNm,
                TranscostnmE = entity.TranscostnmE,
                TransportCostValue = entity.TransportCostValue,
                DiscountPercentage = entity.DiscountPercentage,
                TransportCostValue2 = entity.TransportCostValue2
            };
        }

        public async Task<int> CreateAsync(CreateTransCostDto dto)
        {
            var entity = new TransCost
            {


                TransCostNm = dto.TransCostNm.Trim(),
                TranscostnmE = dto.TranscostnmE.Trim(),
                TransportCostValue = dto.TransportCostValue,
                DiscountPercentage = dto.DiscountPercentage,
                TransportCostValue2 = dto.TransportCostValue2
            };

            await TransCostRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            string displayCode = $"TransCost-{entity.Id:D3}"; // للعرض فقط

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateTransCostDto dto)
        {
            var entity = await TransCostRepo.GetByIdAsync(dto.Id);

            if (entity == null)
                throw new KeyNotFoundException($"تكلفة النقل برقم {dto.Id} غير موجودة");

            entity.TransCostNm = dto.TransCostNm.Trim();
            entity.TranscostnmE = dto.TranscostnmE.Trim();
            entity.TransportCostValue = dto.TransportCostValue;
            entity.DiscountPercentage = dto.DiscountPercentage;
            entity.TransportCostValue2 = dto.TransportCostValue2;

            TransCostRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await TransCostRepo.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"تكلفة النقل برقم {id} غير موجودة");

            TransCostRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await TransCostRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = TransCostRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.TransCostNm == name.Trim());
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = TransCostRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.TranscostnmE == name.Trim());
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
}
