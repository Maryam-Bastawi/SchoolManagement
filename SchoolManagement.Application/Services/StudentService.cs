using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.Student;
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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IGenericRepository<Student, int> StudentRepo =>
            _unitOfWork.Repository<Student, int>();


        public async Task<List<CreateStudentDto>> GetAllStudentsAsync()
        {
            var students = await StudentRepo.GetAllAsync();

            return students.Select(s => new CreateStudentDto
            {
                Id = s.Id,
                DisplayCode = s.DisplayCode,
                FullName = s.FullName,
                EnglishName = s.EnglishName,
                StudentSex = s.StudentSex,
                NationalId = s.NationalId,
                BirthPlace = s.BirthPlace,
                ImgName = s.ImgName,
                BirthDate = s.BirthDate,
                Passport = s.Passport,
                StudentIdNumber = s.StudentIdNumber,
                Respons = s.Respons,
                Mobile1 = s.Mobile1,
                Mobile2 = s.Mobile2,
                Phone = s.Phone,
                IdNumber = s.IdNumber,
                IdIssueDate = s.IdIssueDate,
                IdEndDate = s.IdEndDate,
                IdPlace = s.IdPlace,
                Location = s.Location,
                AreaId = s.AreaId,
                SchoolId = s.SchoolId,
                PreviousSchool = s.PreviousSchool,
                EnrollmentDate = s.EnrollmentDate,
                StagesId = s.StagesId,
                GradesId = s.GradesId,
                SectionId = s.SectionId,
                ClassroomId = s.ClassroomId,
                VehicleId = s.VehicleId,
                TransferTypeId = s.TransferTypeId,
                Discounttypeid = s.Discounttypeid,
                StudentStatusId = s.StudentStatusId,
                TaxStatus = s.TaxStatus,
                StopSms = s.StopSms,
                StopAutoPromotion = s.StopAutoPromotion,
                IsGraduate = s.IsGraduate,
                GraduateDate = s.GraduateDate,
                Note = s.Note,
                Note2 = s.Note2,
                SUSPIND_AC = s.SUSPIND_AC,
                SuspenDate = s.SuspenDate
            }).ToList();
        }


        public async Task<CreateStudentDto?> GetByIdAsync(int id)
        {
            var student = await StudentRepo.GetByIdAsync(id);

            if (student == null)
                return null;

            return new CreateStudentDto
            {
                Id = student.Id,
                DisplayCode = student.DisplayCode,
                FullName = student.FullName,
                EnglishName = student.EnglishName,
                StudentSex = student.StudentSex,
                NationalId = student.NationalId,
                BirthPlace = student.BirthPlace,
                ImgName = student.ImgName,
                BirthDate = student.BirthDate,
                Passport = student.Passport,
                StudentIdNumber = student.StudentIdNumber,
                Respons = student.Respons,
                Mobile1 = student.Mobile1,
                Mobile2 = student.Mobile2,
                Phone = student.Phone,
                IdNumber = student.IdNumber,
                IdIssueDate = student.IdIssueDate,
                IdEndDate = student.IdEndDate,
                IdPlace = student.IdPlace,
                Location = student.Location,
                AreaId = student.AreaId,
                SchoolId = student.SchoolId,
                PreviousSchool = student.PreviousSchool,
                EnrollmentDate = student.EnrollmentDate,
                StagesId = student.StagesId,
                GradesId = student.GradesId,
                SectionId = student.SectionId,
                ClassroomId = student.ClassroomId,
                VehicleId = student.VehicleId,
                TransferTypeId = student.TransferTypeId,
                Discounttypeid = student.Discounttypeid,
                StudentStatusId = student.StudentStatusId,
                TaxStatus = student.TaxStatus,
                StopSms = student.StopSms,
                StopAutoPromotion = student.StopAutoPromotion,
                IsGraduate = student.IsGraduate,
                GraduateDate = student.GraduateDate,
                Note = student.Note,
                Note2 = student.Note2,
                SUSPIND_AC = student.SUSPIND_AC,
                SuspenDate = student.SuspenDate
            };
        }


        public async Task<int> CreateAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                EnglishName = dto.EnglishName,
                StudentSex = dto.StudentSex,
                NationalId = dto.NationalId,
                BirthPlace = dto.BirthPlace,
                ImgName = dto.ImgName,
                BirthDate = dto.BirthDate,
                Passport = dto.Passport,
                StudentIdNumber = dto.StudentIdNumber,
                Respons = dto.Respons,
                Mobile1 = dto.Mobile1,
                Mobile2 = dto.Mobile2,
                Phone = dto.Phone,
                IdNumber = dto.IdNumber,
                IdIssueDate = dto.IdIssueDate,
                IdEndDate = dto.IdEndDate,
                IdPlace = dto.IdPlace,
                Location = dto.Location,
                AreaId = dto.AreaId,
                SchoolId = dto.SchoolId,
                PreviousSchool = dto.PreviousSchool,
                EnrollmentDate = dto.EnrollmentDate,
                StagesId = dto.StagesId,
                GradesId = dto.GradesId,
                SectionId = dto.SectionId,
                ClassroomId = dto.ClassroomId,
                VehicleId = dto.VehicleId,
                TransferTypeId = dto.TransferTypeId,
                Discounttypeid = dto.Discounttypeid,
                StudentStatusId = dto.StudentStatusId,
                TaxStatus = dto.TaxStatus,
                StopSms = dto.StopSms,
                StopAutoPromotion = dto.StopAutoPromotion,
                IsGraduate = dto.IsGraduate,
                GraduateDate = dto.GraduateDate,
                Note = dto.Note,
                Note2 = dto.Note2,
                SUSPIND_AC = dto.SUSPIND_AC,
                SuspenDate = dto.SuspenDate,
                CreatedDate = DateTime.Now
            };

            await StudentRepo.AddAsync(student);
            await _unitOfWork.CompleteAsync();

            student.DisplayCode = $"Student-{student.Id:D3}";
            await _unitOfWork.CompleteAsync();

            return student.Id;
        }


        public async Task UpdateAsync(CreateStudentDto dto)
        {
            var student = await StudentRepo.GetByIdAsync(dto.Id);

            if (student == null)
                throw new Exception("Student not found");

            student.FullName = dto.FullName;
            student.EnglishName = dto.EnglishName;
            student.StudentSex = dto.StudentSex;
            student.NationalId = dto.NationalId;
            student.BirthPlace = dto.BirthPlace;
            student.ImgName = dto.ImgName;
            student.BirthDate = dto.BirthDate;
            student.Passport = dto.Passport;
            student.StudentIdNumber = dto.StudentIdNumber;
            student.Respons = dto.Respons;
            student.Mobile1 = dto.Mobile1;
            student.Mobile2 = dto.Mobile2;
            student.Phone = dto.Phone;
            student.IdNumber = dto.IdNumber;
            student.IdIssueDate = dto.IdIssueDate;
            student.IdEndDate = dto.IdEndDate;
            student.IdPlace = dto.IdPlace;
            student.Location = dto.Location;
            student.AreaId = dto.AreaId;
            student.SchoolId = dto.SchoolId;
            student.PreviousSchool = dto.PreviousSchool;
            student.EnrollmentDate = dto.EnrollmentDate;
            student.StagesId = dto.StagesId;
            student.GradesId = dto.GradesId;
            student.SectionId = dto.SectionId;
            student.ClassroomId = dto.ClassroomId;
            student.VehicleId = dto.VehicleId;
            student.TransferTypeId = dto.TransferTypeId;
            student.Discounttypeid = dto.Discounttypeid;
            student.StudentStatusId = dto.StudentStatusId;
            student.TaxStatus = dto.TaxStatus;
            student.StopSms = dto.StopSms;
            student.StopAutoPromotion = dto.StopAutoPromotion;
            student.IsGraduate = dto.IsGraduate;
            student.GraduateDate = dto.GraduateDate;
            student.Note = dto.Note;
            student.Note2 = dto.Note2;
            student.SUSPIND_AC = dto.SUSPIND_AC;
            student.SuspenDate = dto.SuspenDate;

            StudentRepo.Update(student);
            await _unitOfWork.CompleteAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var student = await StudentRepo.GetByIdAsync(id);

            if (student == null)
                throw new Exception("Student not found");

            StudentRepo.Delete(student);
            await _unitOfWork.CompleteAsync();
        }
    }
}
