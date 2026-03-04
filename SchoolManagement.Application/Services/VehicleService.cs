using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.Vehicle;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.Interface;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IGenericRepository<Vehicle, int> VehicleRepo =>
            _unitOfWork.Repository<Vehicle, int>();

        private IGenericRepository<Drive, int> DriveRepo =>
            _unitOfWork.Repository<Drive, int>();

        public async Task<int> CreateAsync(CreateVehicleDto dto)
        {
            var allVehicle = await VehicleRepo.GetAllAsync();

            int nextNumber = 1;

            if (allVehicle.Any())
            {
                nextNumber = allVehicle.Max(s => s.Id) + 1;
            }
            var entity = new Vehicle
            {
                CarName = dto.CarName,
                CarNameEn = dto.CarNameEn,
                InStock = dto.InStock,
                PlateNum = dto.PlateNum,
                Color = dto.Color,
                Model = dto.Model,
                Chasee = dto.Chasee,
                LicIssueDate = dto.LicIssueDate,
                LicEndDate = dto.LicEndDate,
                DriveId = dto.DriveId
            };

            await VehicleRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            string displayCode = $"Vehicle-{entity.Id:D3}";

            // هنا nextNumber يبقى Id أو نرجع Id
            return entity.Id;
        }

        public async Task UpdateAsync(UpdateVehicleDto dto)
        {
            var entity = await VehicleRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new Exception("Vehicle not found");

            entity.CarName = dto.CarName;
            entity.CarNameEn = dto.CarNameEn;
            entity.InStock = dto.InStock;
            entity.PlateNum = dto.PlateNum;
            entity.Color = dto.Color;
            entity.Model = dto.Model;
            entity.Chasee = dto.Chasee;
            entity.LicIssueDate = dto.LicIssueDate;
            entity.LicEndDate = dto.LicEndDate;
            entity.DriveId = dto.DriveId;

            VehicleRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await VehicleRepo.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Vehicle not found");

            VehicleRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetVehicleDto> GetByIdAsync(int id)
        {
            var entity = await VehicleRepo.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Vehicle not found");

            return new GetVehicleDto
            {
                Id = entity.Id,
                CarName = entity.CarName,
                CarNameEn = entity.CarNameEn,
                InStock = entity.InStock,
                PlateNum = entity.PlateNum,
                Color = entity.Color,
                Model = entity.Model,
                Chasee = entity.Chasee,
                LicIssueDate = entity.LicIssueDate,
                LicEndDate = entity.LicEndDate,
                DriveId = entity.DriveId
            };
        }

        public async Task<List<GetVehicleDto>> GetAllAsync()
        {
            var entities = await VehicleRepo.GetAllAsync();
            return entities.Select(x => new GetVehicleDto
            {
                Id = x.Id,
                CarName = x.CarName,
                CarNameEn = x.CarNameEn,
                InStock = x.InStock,
                PlateNum = x.PlateNum,
                Color = x.Color,
                Model = x.Model,
                Chasee = x.Chasee,
                LicIssueDate = x.LicIssueDate,
                LicEndDate = x.LicEndDate,
                DriveId = x.DriveId
            }).ToList();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await VehicleRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsPlateNumberUniqueAsync(string plateNum, int? excludeId = null)
        {
            var query = VehicleRepo.Query();
            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.PlateNum == plateNum);
        }

        public async Task<bool> IsChaseeUniqueAsync(string chasee, int? excludeId = null)
        {
            var query = VehicleRepo.Query();
            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.Chasee == chasee);
        }

        public async Task<List<Drive>> GetAvailableDriversAsync()
        {
            var allDrives = await DriveRepo.GetAllAsync();
            var vehicles = await VehicleRepo.GetAllAsync();

            var usedDriverIds = vehicles
                .Where(v => v.DriveId.HasValue)
                .Select(v => v.DriveId!.Value)
                .ToHashSet();

            return allDrives.Where(d => !usedDriverIds.Contains(d.Id)).ToList();
        }
    }
}