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

        public GradesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetGradesDto>> GetAllAsync()
        {
            var grades = await GradesRepo.GetAllAsync();

            return grades
                .OrderBy(x => x.GradesNm)
                .Select(x => new GetGradesDto
                {
                    Id = x.Id,
                    GradesNm = x.GradesNm,
                    GradesNm_E = x.GradesNm_E,

                    StagesId = x.StagesId,

                    SchoolId = x.SchoolId,

                    CostCenterId = x.CostCenterId,

                    TransCostId = x.TransCostId,

                    Term1Fee = x.Term1Fee,
                    Term2Fee = x.Term2Fee,
                    RegistrationFee = x.RegistrationFee,
                    BookFee = x.BookFee,
                    OtherFee = x.OtherFee,
                    TransportFee = x.TransportFee,

                    NextStageId = x.NextStageId,
                    NextGradeId = x.NextGradeId,
                    NextSchoolId = x.NextSchoolId,
                    PromotionType = x.PromotionType,

                    IsExit = x.IsExit,

                    studStatusId = x.studStatusId,
                }).ToList();
        }

        public async Task<GetGradesDto?> GetByIdAsync(int id)
        {
            var entity = await GradesRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetGradesDto
            {
                Id = entity.Id,
                GradesNm = entity.GradesNm,
                GradesNm_E = entity.GradesNm_E,

                StagesId = entity.StagesId,

                SchoolId = entity.SchoolId,

                CostCenterId = entity.CostCenterId,

                TransCostId = entity.TransCostId,

                Term1Fee = entity.Term1Fee,
                Term2Fee = entity.Term2Fee,
                RegistrationFee = entity.RegistrationFee,
                BookFee = entity.BookFee,
                OtherFee = entity.OtherFee,
                TransportFee = entity.TransportFee,

                NextStageId = entity.NextStageId,
                NextGradeId = entity.NextGradeId,
                NextSchoolId = entity.NextSchoolId,
                PromotionType = entity.PromotionType,

                IsExit = entity.IsExit,

                studStatusId = entity.studStatusId,
            };
        }

        public async Task<int> CreateAsync(CreateGradesDto dto)
        {
            var entity = new Grades
            {
                Id = await IdGenerator.GetNextIdAsync(GradesRepo),

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
                TransportFee = dto.TransportFee,

                NextStageId = dto.NextStageId,
                NextGradeId = dto.NextGradeId,
                NextSchoolId = dto.NextSchoolId,
                PromotionType = dto.PromotionType,

                IsExit = dto.IsExit,

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
            entity.TransportFee = dto.TransportFee;

            entity.NextStageId = dto.NextStageId;
            entity.NextGradeId = dto.NextGradeId;
            entity.NextSchoolId = dto.NextSchoolId;
            entity.PromotionType = dto.PromotionType;

            entity.IsExit = dto.IsExit;

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
                x.GradesNm.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
        }

        public async Task<bool> IsEnglishNameUniqueAsync(string name, int? excludeId = null)
        {
            var all = await GradesRepo.GetAllAsync();

            return !all.Any(x =>
                x.GradesNm_E.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
        }

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
