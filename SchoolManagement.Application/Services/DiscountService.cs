using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.Discount;
using SchoolManagement.Application.DTOs.Drive;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<Discount, int> DiscountRepo => _unitOfWork.Repository<Discount, int>();

        public DiscountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetDiscountDto>> GetAllAsync()
        {
            var discounts = await DiscountRepo.GetAllAsync();
            return discounts
                .OrderBy(x => x.DescountNm)
                .Select(x => new GetDiscountDto
                {
                    Id = x.Id,
                    DescountNm = x.DescountNm,
                    DescountNm_E = x.DescountNm_E,
                    DiscVal = x.DiscVal,
                    DiscPer = x.DiscPer,
                    DiscVal2 = x.DiscVal2
                }).ToList();
        }

        public async Task<GetDiscountDto?> GetByIdAsync(int id)
        {
            var entity = await DiscountRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetDiscountDto
            {
                Id = entity.Id,
                DescountNm = entity.DescountNm,
                DescountNm_E = entity.DescountNm_E,
                DiscVal = entity.DiscVal,
                DiscPer = entity.DiscPer,
                DiscVal2 = entity.DiscVal2
            };
        }

        public async Task<int> CreateAsync(CreateDiscountDto dto)
        {
            var entity = new Discount
            {
                DescountNm = dto.DescountNm.Trim(),
                DescountNm_E = dto.DescountNm_E.Trim(),
                DiscVal = dto.DiscVal,
                DiscPer = dto.DiscPer,
                DiscVal2 = dto.DiscVal2
            };

            await DiscountRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            string displayCode = $"Discount-{entity.Id:D3}"; // للعرض فقط

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateDiscountDto dto)
        {
            var entity = await DiscountRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"الخصم برقم {dto.Id} غير موجود");

            entity.DescountNm = dto.DescountNm.Trim();
            entity.DescountNm_E = dto.DescountNm_E.Trim();
            entity.DiscVal = dto.DiscVal;
            entity.DiscPer = dto.DiscPer;
            entity.DiscVal2 = dto.DiscVal2;

            DiscountRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await DiscountRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"الخصم برقم {id} غير موجود");

            DiscountRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await DiscountRepo.GetByIdAsync(id);
            return entity != null;
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
