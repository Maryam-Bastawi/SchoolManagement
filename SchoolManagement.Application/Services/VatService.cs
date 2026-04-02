using SchoolManagement.Application.DTOs.Discount;
using SchoolManagement.Application.DTOs.Vat;
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
    public class VatService : IVatService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VatService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IGenericRepository<Vat, int> VatRepo =>
            _unitOfWork.Repository<Vat, int>();

        // ================= CREATE =================
        public async Task<int> CreateAsync(CreateVatDto dto)
        {
            var entity = new Vat
            {
                VATNM = dto.VATNM,
                VATNM_E = dto.VATNM_E,
                NOTES = dto.NOTES,
                VAT_PERCENT = dto.VAT_PERCENT,
                IS_DEFUALT = dto.IS_DEFUALT
            };

            await VatRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return entity.Id;
        }

        // ================= UPDATE =================
        public async Task UpdateAsync(UpdateVatDto dto)
        {
            var entity = await VatRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new Exception("Vat not found");

            entity.Id = dto.Id;
            entity.VATNM = dto.VATNM;
            entity.VATNM_E = dto.VATNM_E;
            entity.NOTES = dto.NOTES;
            entity.VAT_PERCENT = dto.VAT_PERCENT;
            entity.IS_DEFUALT = dto.IS_DEFUALT;

            VatRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        // ================= DELETE =================
        public async Task DeleteAsync(int id)
        {
            var entity = await VatRepo.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Vat not found");

            VatRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        // ================= GET BY ID =================
        public async Task<GetVatDto?> GetByIdAsync(int id)
        {
            var entity = await VatRepo.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetVatDto
            {
                Id = entity.Id,
                VATNM = entity.VATNM,
                VATNM_E = entity.VATNM_E,
                NOTES = entity.NOTES,
                VAT_PERCENT = entity.VAT_PERCENT,
                IS_DEFUALT = entity.IS_DEFUALT
            };
        }

        // ================= GET ALL =================
        public async Task<List<GetVatDto>> GetAllAsync()
        {
            var list = await VatRepo.GetAllAsync();

            return list.Select(x => new GetVatDto
            {
                Id = x.Id,
                VATNM = x.VATNM,
                VATNM_E = x.VATNM_E,
                NOTES = x.NOTES,
                VAT_PERCENT = x.VAT_PERCENT,
                IS_DEFUALT = x.IS_DEFUALT
            }).ToList();
        }
    }
}