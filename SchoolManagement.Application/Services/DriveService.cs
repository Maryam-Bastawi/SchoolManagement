using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.Drive;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class DriveService : IDriveService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IGenericRepository<Drive, int> DriveRepo =>
            _unitOfWork.Repository<Drive, int>();

        // Create
        public async Task<int> CreateAsync(CreateDriveDto dto)
        {
            var entity = new Drive
            {
                DrvNm = dto.DrvNm,
                DrvNmEn = dto.DrvNmEn,
                Mobil = dto.Mobil,
                LicEnd = dto.LicEnd
            };

            await DriveRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            string displayCode = $"drive-{entity.Id:D3}"; // للعرض فقط
            return entity.Id;
        }

        // Update
        public async Task UpdateAsync(UpdateDriveDto dto)
        {
            var entity = await DriveRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new Exception("Drive not found");

            entity.DrvNm = dto.DrvNm;
            entity.DrvNmEn = dto.DrvNmEn;
            entity.Mobil = dto.Mobil;
            entity.LicEnd = dto.LicEnd;

            DriveRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        // Delete
        public async Task DeleteAsync(int id)
        {
            var entity = await DriveRepo.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Drive not found");

            DriveRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        // Get by Id
        public async Task<GetDriveDto?> GetByIdAsync(int id)
        {
            var entity = await DriveRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetDriveDto
            {
                Id = entity.Id,
                DrvNm = entity.DrvNm,
                DrvNmEn = entity.DrvNmEn,
                Mobil = entity.Mobil,
                LicEnd = entity.LicEnd
            };
        }

        // Get all
        public async Task<List<GetDriveDto>> GetAllAsync()
        {
            var drives = await DriveRepo.GetAllAsync();
            return drives
                .OrderBy(d => d.DrvNm)
                .Select(d => new GetDriveDto
                {
                    Id = d.Id,
                    DrvNm = d.DrvNm,
                    DrvNmEn = d.DrvNmEn,
                    Mobil = d.Mobil,
                    LicEnd = d.LicEnd
                })
                .ToList();
        }



        // Check if Id exists
        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await DriveRepo.GetByIdAsync(id);
            return entity != null;
        }

        // Check if mobile is unique
        public async Task<bool> IsMobileUniqueAsync(string mobile, int? excludeId = null)
        {
            var query = DriveRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.Mobil == mobile.Trim());
        }

        // Check if name is unique
        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = DriveRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.DrvNm == name.Trim());
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
