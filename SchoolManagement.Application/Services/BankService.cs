using SchoolManagement.Application.DTOs.Bank;
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
    public class BankService : IBankService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<Bank, int> BankRepo => _unitOfWork.Repository<Bank, int>();

        public BankService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetBankDto>> GetAllAsync()
        {
            var banks = await BankRepo.GetAllAsync();
            return banks
                .OrderBy(x => x.BankName)
                .Select(x => new GetBankDto
                {
                    Id = x.Id,
                    BankName = x.BankName,
                    BankNameEn = x.BankNameEn,
                    Responsible = x.Responsible
                }).ToList();
        }

        public async Task<GetBankDto?> GetByIdAsync(int id)
        {
            var entity = await BankRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetBankDto
            {
                Id = entity.Id,
                BankName = entity.BankName,
                BankNameEn = entity.BankNameEn,
                Responsible = entity.Responsible
            };
        }

        public async Task<int> CreateAsync(CreateBankDto dto)
        {
            var entity = new Bank
            {
                Id = await IdGenerator.GetNextIdAsync(BankRepo),
                BankName = dto.BankName.Trim(),
                BankNameEn = dto.BankNameEn.Trim(),
                Responsible = dto.Responsible?.Trim()
            };

            await BankRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateBankDto dto)
        {
            var entity = await BankRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"البنك برقم {dto.Id} غير موجود");

            entity.BankName = dto.BankName.Trim();
            entity.BankNameEn = dto.BankNameEn.Trim();
            entity.Responsible = dto.Responsible?.Trim();

            BankRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await BankRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"البنك برقم {id} غير موجود");

            BankRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await BankRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await BankRepo.GetAllAsync();
            return !all.Any(x => x.BankName.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await BankRepo.GetAllAsync();
            return !all.Any(x => x.BankNameEn.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)
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
