using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.Supervisor;
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
    public class SupervisorService : ISupervisorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupervisorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IGenericRepository<Supervisor, int> SupervisorRepo =>
            _unitOfWork.Repository<Supervisor, int>();


        // =========================
        // Create
        // =========================
        public async Task<int> CreateAsync(CreateSupervisorDto dto)
        {
            var entity = new Supervisor
            {
                SupervisorNAME = dto.SupervisorNAME,
                SupervisorNAME_E = dto.SupervisorNAME_E,
                SupervisorMobile = dto.SupervisorMobile
            };

            await SupervisorRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }


        // =========================
        // Update
        // =========================
        public async Task UpdateAsync(UpdateSupervisorDto dto)
        {
            var entity = await SupervisorRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new Exception("Supervisor not found");

            entity.SupervisorNAME = dto.SupervisorNAME;
            entity.SupervisorNAME_E = dto.SupervisorNAME_E;
            entity.SupervisorMobile = dto.SupervisorMobile;

            SupervisorRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }


        // =========================
        // Delete
        // =========================
        public async Task DeleteAsync(int id)
        {
            var entity = await SupervisorRepo.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Supervisor not found");

            SupervisorRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }


        // =========================
        // Get By Id
        // =========================
        public async Task<GetSupervisorDto?> GetByIdAsync(int id)
        {
            var entity = await SupervisorRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetSupervisorDto
            {
                Id = entity.Id,
                SupervisorNAME = entity.SupervisorNAME,
                SupervisorNAME_E = entity.SupervisorNAME_E,
                SupervisorMobile = entity.SupervisorMobile
            };
        }


        // =========================
        // Get All
        // =========================
        public async Task<List<GetSupervisorDto>> GetAllAsync()
        {
            var supervisors = await SupervisorRepo.GetAllAsync();

            return supervisors
                .OrderBy(s => s.SupervisorNAME)
                .Select(s => new GetSupervisorDto
                {
                    Id = s.Id,
                    SupervisorNAME = s.SupervisorNAME,
                    SupervisorNAME_E = s.SupervisorNAME_E,
                    SupervisorMobile = s.SupervisorMobile
                })
                .ToList();
        }


        // =========================
        // Exists
        // =========================
        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await SupervisorRepo.GetByIdAsync(id);
            return entity != null;
        }


        // =========================
        // Check Mobile Unique
        // =========================
        public async Task<bool> IsMobileUniqueAsync(string mobile, int? excludeId = null)
        {
            var query = SupervisorRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.SupervisorMobile == mobile.Trim());
        }


        // =========================
        // Check Name Unique
        // =========================
        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = SupervisorRepo.Query();

            if (excludeId.HasValue)
                query = query.Where(x => x.Id != excludeId.Value);

            return !await query.AnyAsync(x => x.SupervisorNAME == name.Trim());
        }


        // =========================
        // Id Generator (زي Drive بالظبط)
        // =========================
        public static class IdGenerator
        {
            public static async Task<int> GetNextIdAsync<T>(
                IGenericRepository<T, int> repository) where T : class
            {
                var allEntities = await repository.GetAllAsync();
                if (!allEntities.Any())
                    return 1;

                return allEntities
                    .Max(e => (int)e.GetType().GetProperty("Id")!
                    .GetValue(e)!) + 1;
            }
        }
    }
}
