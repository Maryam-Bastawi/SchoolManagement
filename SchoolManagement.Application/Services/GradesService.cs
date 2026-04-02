using SchoolManagement.Application.DTOs.Grades;
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
    public class GradesService : IGradesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<Grades, int> GradesRepo => _unitOfWork.Repository<Grades, int>();

        // إضافة الـ Repositories الأخرى
        private IGenericRepository<Stages, int> StagesRepo => _unitOfWork.Repository<Stages, int>();
        private IGenericRepository<School, int> SchoolRepo => _unitOfWork.Repository<School, int>();
        private IGenericRepository<CostCenter, int> CostCenterRepo => _unitOfWork.Repository<CostCenter, int>();
        private IGenericRepository<TransCost, int> TransCostRepo => _unitOfWork.Repository<TransCost, int>();
        private IGenericRepository<StudentStatus, int> StudentStatusRepo => _unitOfWork.Repository<StudentStatus, int>();

        public GradesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetGradesDto>> GetAllAsync()
        {
            // جلب جميع الصفوف أولاً
            var grades = await GradesRepo.GetAllAsync();

            // جلب البيانات المرتبطة بشكل منفصل
            var stages = await StagesRepo.GetAllAsync();
            var schools = await SchoolRepo.GetAllAsync();
            var costCenters = await CostCenterRepo.GetAllAsync();
            var transCosts = await TransCostRepo.GetAllAsync();
            var studentStatuses = await StudentStatusRepo.GetAllAsync();
            var allGrades = await GradesRepo.GetAllAsync(); // للـ NextGrade

            return grades
                .OrderBy(x => x.GradesNm)
                .Select(x => new GetGradesDto
                {
                    Id = x.Id,
                    GradesNm = x.GradesNm,
                    GradesNm_E = x.GradesNm_E,
                    StagesId = x.StagesId,
                    StageName = stages.FirstOrDefault(s => s.Id == x.StagesId)?.StageNM,
                    SchoolId = x.SchoolId,
                    SchoolName = schools.FirstOrDefault(s => s.Id == x.SchoolId)?.SchoolNm,
                    CostCenterId = x.CostCenterId,
                    CostCenterName = costCenters.FirstOrDefault(c => c.Id == x.CostCenterId)?.CostNm,
                    TransCostId = x.TransCostId,
                    Term1Fee = x.Term1Fee,
                    Term2Fee = x.Term2Fee,
                    RegistrationFee = x.RegistrationFee,
                    BookFee = x.BookFee,
                    OtherFee = x.OtherFee,
                    NextStageId = x.NextStageId,
                    NextStageName = stages.FirstOrDefault(s => s.Id == x.NextStageId)?.StageNM,
                    NextGradeId = x.NextGradeId,
                    NextGradeName = allGrades.FirstOrDefault(g => g.Id == x.NextGradeId)?.GradesNm,
                    NextSchoolId = x.NextSchoolId,
                    NextSchoolName = schools.FirstOrDefault(s => s.Id == x.NextSchoolId)?.SchoolNm,
                    studStatusId = x.studStatusId,
                    StudentStatusName = studentStatuses.FirstOrDefault(ss => ss.Id == x.studStatusId)?.StatusName
                }).ToList();
        }

        public async Task<GetGradesDto?> GetByIdAsync(int id)
        {
            var entity = await GradesRepo.GetByIdAsync(id);
            if (entity == null) return null;

            // جلب البيانات المرتبطة
            var stages = await StagesRepo.GetAllAsync();
            var schools = await SchoolRepo.GetAllAsync();
            var costCenters = await CostCenterRepo.GetAllAsync();
            var studentStatuses = await StudentStatusRepo.GetAllAsync();
            var allGrades = await GradesRepo.GetAllAsync();

            return new GetGradesDto
            {
                Id = entity.Id,
                GradesNm = entity.GradesNm,
                GradesNm_E = entity.GradesNm_E,
                StagesId = entity.StagesId,
                StageName = stages.FirstOrDefault(s => s.Id == entity.StagesId)?.StageNM,
                SchoolId = entity.SchoolId,
                SchoolName = schools.FirstOrDefault(s => s.Id == entity.SchoolId)?.SchoolNm,
                CostCenterId = entity.CostCenterId,
                CostCenterName = costCenters.FirstOrDefault(c => c.Id == entity.CostCenterId)?.CostNm,
                TransCostId = entity.TransCostId,
                Term1Fee = entity.Term1Fee,
                Term2Fee = entity.Term2Fee,
                RegistrationFee = entity.RegistrationFee,
                BookFee = entity.BookFee,
                OtherFee = entity.OtherFee,
                NextStageId = entity.NextStageId,
                NextStageName = stages.FirstOrDefault(s => s.Id == entity.NextStageId)?.StageNM,
                NextGradeId = entity.NextGradeId,
                NextGradeName = allGrades.FirstOrDefault(g => g.Id == entity.NextGradeId)?.GradesNm,
                NextSchoolId = entity.NextSchoolId,
                NextSchoolName = schools.FirstOrDefault(s => s.Id == entity.NextSchoolId)?.SchoolNm,
                studStatusId = entity.studStatusId,
                StudentStatusName = studentStatuses.FirstOrDefault(ss => ss.Id == entity.studStatusId)?.StatusName
            };
        }

        public async Task<int> CreateAsync(CreateGradesDto dto)
        {
            // التحقق من صحة البيانات
            await ValidateGradeData(dto.GradesNm, dto.GradesNm_E, null);

            var entity = new Grades
            {
                GradesNm = dto.GradesNm.Trim(),
                GradesNm_E = dto.GradesNm_E.Trim(),
                StagesId = dto.StagesId,
                SchoolId = dto.SchoolId,
                CostCenterId = dto.CostCenterId,
                TransCostId = dto.TransCostId,
                Term1Fee = dto.Term1Fee,
                Term2Fee = dto.Term2Fee,
                RegistrationFee = dto.RegistrationFee,
                BookFee = dto.BookFee,
                OtherFee = dto.OtherFee,
                NextStageId = dto.NextStageId,
                NextGradeId = dto.NextGradeId,
                NextSchoolId = dto.NextSchoolId,
                studStatusId = dto.studStatusId
            };

            await GradesRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateGradesDto dto)
        {
            var entity = await GradesRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"الصف برقم {dto.Id} غير موجود");

            await ValidateGradeData(dto.GradesNm, dto.GradesNm_E, dto.Id);

            entity.GradesNm = dto.GradesNm.Trim();
            entity.GradesNm_E = dto.GradesNm_E.Trim();
            entity.StagesId = dto.StagesId;
            entity.SchoolId = dto.SchoolId;
            entity.CostCenterId = dto.CostCenterId;
            entity.TransCostId = dto.TransCostId;
            entity.Term1Fee = dto.Term1Fee;
            entity.Term2Fee = dto.Term2Fee;
            entity.RegistrationFee = dto.RegistrationFee;
            entity.BookFee = dto.BookFee;
            entity.OtherFee = dto.OtherFee;
            entity.NextStageId = dto.NextStageId;
            entity.NextGradeId = dto.NextGradeId;
            entity.NextSchoolId = dto.NextSchoolId;
            entity.studStatusId = dto.studStatusId;

            GradesRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GradesRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"الصف برقم {id} غير موجود");

            GradesRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await GradesRepo.GetByIdAsync(id);
            return entity != null;
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await GradesRepo.GetAllAsync();
            return !all.Any(x =>
                x.GradesNm != null &&
                x.GradesNm.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await GradesRepo.GetAllAsync();
            return !all.Any(x =>
                x.GradesNm_E != null &&
                x.GradesNm_E.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        private async Task ValidateGradeData(string arabicName, string englishName, int? excludeId)
        {
            if (string.IsNullOrWhiteSpace(arabicName))
                throw new ArgumentException("الاسم بالعربية مطلوب");

            if (string.IsNullOrWhiteSpace(englishName))
                throw new ArgumentException("الاسم بالإنجليزية مطلوب");

            if (!await IsNameUniqueAsync(arabicName, excludeId))
                throw new InvalidOperationException($"الاسم '{arabicName}' موجود بالفعل");

            if (!await IsEnglishNameUniqueAsync(englishName, excludeId))
                throw new InvalidOperationException($"الاسم الإنجليزي '{englishName}' موجود بالفعل");
        }
    }
}
