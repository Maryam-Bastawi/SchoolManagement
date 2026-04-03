using SchoolManagement.Application.DTOs.Class;
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
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<Class, int> ClassRepo => _unitOfWork.Repository<Class, int>();
        private IGenericRepository<Grades, int> GradesRepo => _unitOfWork.Repository<Grades, int>();

        public ClassService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetClassDto>> GetAllAsync()
        {
            var classes = await ClassRepo.GetAllAsync();
            var grades = await GradesRepo.GetAllAsync();

            return classes
                .OrderBy(x => x.ClassNm)
                .Select(x => new GetClassDto
                {
                    Id = x.Id,
                    ClassNm = x.ClassNm,
                    ClassNmEn = x.ClassNmEn,
                    GradeId = x.GradesId,
                    GradeName = grades.FirstOrDefault(g => g.Id == x.GradesId)?.GradesNm
                }).ToList();
        }

        public async Task<GetClassDto?> GetByIdAsync(int id)
        {
            var entity = await ClassRepo.GetByIdAsync(id);
            if (entity == null) return null;

            var grades = await GradesRepo.GetAllAsync();

            return new GetClassDto
            {
                Id = entity.Id,
                ClassNm = entity.ClassNm,
                ClassNmEn = entity.ClassNmEn,
                GradeId = entity.GradesId,
                GradeName = grades.FirstOrDefault(g => g.Id == entity.GradesId)?.GradesNm
            };
        }

        public async Task<int> CreateAsync(CreateClassDto dto)
        {
            // التحقق من صحة البيانات
            await ValidateClassData(dto.ClassNm, dto.ClassNmEn, null);

            var entity = new Class
            {
                ClassNm = dto.ClassNm.Trim(),
                ClassNmEn = dto.ClassNmEn.Trim(),
                GradesId = dto.GradeId
            };

            await ClassRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateClassDto dto)
        {
            var entity = await ClassRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"الفصل برقم {dto.Id} غير موجود");

            await ValidateClassData(dto.ClassNm, dto.ClassNmEn, dto.Id);

            entity.ClassNm = dto.ClassNm.Trim();
            entity.ClassNmEn = dto.ClassNmEn.Trim();
            entity.GradesId = dto.GradeId;

            ClassRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await ClassRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"الفصل برقم {id} غير موجود");

            ClassRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await ClassRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await ClassRepo.GetAllAsync();
            return !all.Any(x =>
                x.ClassNm != null &&
                x.ClassNm.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await ClassRepo.GetAllAsync();
            return !all.Any(x =>
                x.ClassNmEn != null &&
                x.ClassNmEn.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        private async Task ValidateClassData(string arabicName, string englishName, int? excludeId)
        {
            if (string.IsNullOrWhiteSpace(arabicName))
                throw new ArgumentException("اسم الفصل بالعربية مطلوب");

            if (string.IsNullOrWhiteSpace(englishName))
                throw new ArgumentException("اسم الفصل بالإنجليزية مطلوب");

            if (!await IsNameUniqueAsync(arabicName, excludeId))
                throw new InvalidOperationException($"الاسم '{arabicName}' موجود بالفعل");

            if (!await IsEnglishNameUniqueAsync(englishName, excludeId))
                throw new InvalidOperationException($"الاسم الإنجليزي '{englishName}' موجود بالفعل");
        }
    }
}
