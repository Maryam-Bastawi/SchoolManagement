using SchoolManagement.Application.DTOs.Schoool;
using SchoolManagement.Application.DTOs.Vehicle;
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
    public class SchoolService : ISchoolService
    {

            private readonly IUnitOfWork _unitOfWork;

            public SchoolService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            private IGenericRepository<School, int> SchoolRepo =>
                _unitOfWork.Repository<School, int>();

        public async Task<int> CreateAsync(CreateSchoolDto dto)
        {
            var entity = new School
            {
                SchoolNm = dto.SchoolNm,
                SchoolNmEn = dto.SchoolNmEn
            };

            await SchoolRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            string displayCode = $"school-{entity.Id:D3}"; // للعرض فقط
            return entity.Id;
        }
        public async Task UpdateAsync(UpdateSchoolDto dto)
            {
                var entity = await SchoolRepo.GetByIdAsync(dto.Id);
                if (entity == null)
                    throw new Exception("School not found");

                  entity.Id = dto.Id;
                  entity.SchoolNm = dto.SchoolNm;
                  entity.SchoolNmEn = dto.SchoolNmEn;


                SchoolRepo.Update(entity);
                await _unitOfWork.CompleteAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var entity = await SchoolRepo.GetByIdAsync(id);
                if (entity == null)
                    throw new Exception("School not found");

                SchoolRepo.Delete(entity);
                await _unitOfWork.CompleteAsync();
            }

            public async Task<GetSchoolDto?> GetByIdAsync(int id)
            {
                var entity = await SchoolRepo.GetByIdAsync(id);
                if (entity == null) return null;

                return new GetSchoolDto
                {
                    Id = entity.Id,
                    SchoolNm = entity.SchoolNm,
                    SchoolNmEn = entity.SchoolNmEn,

                };
            }

            public async Task<List<GetSchoolDto>> GetAllAsync()
            {
                var schools = await SchoolRepo.GetAllAsync();
                return schools.Select(s => new GetSchoolDto
                {
                    Id = s.Id,
                    SchoolNm = s.SchoolNm,
                    SchoolNmEn = s.SchoolNmEn,

                }).ToList();
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

