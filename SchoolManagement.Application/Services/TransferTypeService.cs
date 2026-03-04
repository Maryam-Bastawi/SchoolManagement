using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.TransferType;
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
    public class TransferTypeService : ITransferTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransferTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IGenericRepository<TransferType, int> TransferTypeRepo =>
            _unitOfWork.Repository<TransferType, int>();

        public async Task<int> CreateAsync(CreateTransferTypeDto dto)
        {
            var allTransferType = await TransferTypeRepo.GetAllAsync();

            int nextNumber = 1;

            if (allTransferType.Any())
            {
                nextNumber = allTransferType.Max(s => s.Id) + 1;
            }
            var entity = new TransferType
            {
                Route = dto.Route,
                RouteEng = dto.RouteEng,
                Exmount1 = dto.Exmount1,
                Exmount2 = dto.Exmount2
            };

            await TransferTypeRepo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            string displayCode = $"Vehicle-{entity.Id:D3}";

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateTransferTypeDto dto)
        {
            var entity = await TransferTypeRepo.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new Exception("Transfer Type not found");

            entity.Route = dto.Route;
            entity.RouteEng = dto.RouteEng;
            entity.Exmount1 = dto.Exmount1;
            entity.Exmount2 = dto.Exmount2;

            TransferTypeRepo.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await TransferTypeRepo.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Transfer Type not found");

            TransferTypeRepo.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetTransferTypeDto> GetByIdAsync(int id)
        {
            var entity = await TransferTypeRepo.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Transfer Type not found");

            return new GetTransferTypeDto
            {
                Id = entity.Id,
                Route = entity.Route!,
                RouteEng = entity.RouteEng!,
                Exmount1 = entity.Exmount1,
                Exmount2 = entity.Exmount2
            };
        }

        public async Task<List<GetTransferTypeDto>> GetAllAsync()
        {
            var entities = await TransferTypeRepo.GetAllAsync();
            return entities.Select(x => new GetTransferTypeDto
            {
                Id = x.Id,
                Route = x.Route!,
                RouteEng = x.RouteEng!,
                Exmount1 = x.Exmount1,
                Exmount2 = x.Exmount2
            }).ToList();
        }
    }
}

