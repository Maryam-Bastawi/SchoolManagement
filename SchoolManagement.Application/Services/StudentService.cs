using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.Student;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }   

        private IGenericRepository<Student, int> StudentRepo =>
            _unitOfWork.Repository<Student, int>();

        public async Task<List<CreateStudentDto>> GetAllStudentsAsync()
        {
            var students = await StudentRepo.GetAllAsync();

            return students.Select(s => new CreateStudentDto
            {
                Id = s.Id,
                FullName = s.FullName,
                EnglishName = s.EnglishName,
                Gender = s.Gender,
                NationalId = s.NationalId,
                SectionId = s.SectionId,
                RegisterNextYear = s.RegisterNextYear,
                DebtAmount = s.DebtAmount,
                StudentImagePath = s.StudentImagePath,
                ResponseName = s.ResponseName,
                WorkDate = s.WorkDate,
                HomePhone = s.HomePhone,
                WorkPhone = s.WorkPhone,
                Mobile = s.Mobile,
                Address = s.Address,
                AreaId = s.AreaId,
                IdNumber = s.IdNumber,
                IssuePlace = s.IssuePlace,
                IssueDate = s.IssueDate,
                ExpiryDate = s.ExpiryDate,
                SchoolId = s.SchoolId,
                StagesId = s.StagesId,
                GradesId = s.GradesId,
                ClassroomId = s.ClassroomId,
                StudentStatusId = s.StudentStatusId,
                TransferTypeId = s.TransferTypeId,
                VehicleId = s.VehicleId,
                Discounttypeid = s.Discounttypeid,
                Notes = s.Notes,
                Notes2 = s.Notes2,
                PassportNumber = s.PassportNumber,
                RecordNumber = s.RecordNumber,
                BirthDate = s.BirthDate,
                BirthPlace = s.BirthPlace,
                ContractDate = s.ContractDate,
                IsTaxable = s.IsTaxable,
                IsGraduate = s.IsGraduate,
                IsFileWithdrawn = s.IsFileWithdrawn,
                WithdrawDate = s.WithdrawDate
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
                FullName = student.FullName,
                EnglishName = student.EnglishName,
                Gender = student.Gender,
                NationalId = student.NationalId,
                SectionId = student.SectionId,
                RegisterNextYear = student.RegisterNextYear,
                DebtAmount = student.DebtAmount,
                StudentImagePath = student.StudentImagePath,
                ResponseName = student.ResponseName,
                WorkDate = student.WorkDate,
                HomePhone = student.HomePhone,
                WorkPhone = student.WorkPhone,
                Mobile = student.Mobile,
                Address = student.Address,
                AreaId = student.AreaId,
                IdNumber = student.IdNumber,
                IssuePlace = student.IssuePlace,
                IssueDate = student.IssueDate,
                ExpiryDate = student.ExpiryDate,
                SchoolId = student.SchoolId,
                StagesId = student.StagesId,
                GradesId = student.GradesId,
                ClassroomId = student.ClassroomId,
                StudentStatusId = student.StudentStatusId,
                TransferTypeId = student.TransferTypeId,
                VehicleId = student.VehicleId,
                Discounttypeid = student.Discounttypeid,
                Notes = student.Notes,
                Notes2 = student.Notes2,
                PassportNumber = student.PassportNumber,
                RecordNumber = student.RecordNumber,
                BirthDate = student.BirthDate,
                BirthPlace = student.BirthPlace,
                ContractDate = student.ContractDate,
                IsTaxable = student.IsTaxable,
                IsGraduate = student.IsGraduate,
                IsFileWithdrawn = student.IsFileWithdrawn,
                WithdrawDate = student.WithdrawDate
            };
        }

        public async Task<int> CreateAsync(CreateStudentDto dto, IFormFile? imageFile = null)
        {
            // معالجة الصورة إذا وجدت
            if (imageFile != null)
            {
                dto.StudentImagePath = await SaveStudentImageAsync(imageFile);
            }

            var student = new Student
            {
                FullName = dto.FullName,
                EnglishName = dto.EnglishName,
                Gender = dto.Gender,
                NationalId = dto.NationalId,
                SectionId = dto.SectionId,
                RegisterNextYear = dto.RegisterNextYear,
                DebtAmount = dto.DebtAmount,
                StudentImagePath = dto.StudentImagePath,
                ResponseName = dto.ResponseName,
                WorkDate = dto.WorkDate,
                HomePhone = dto.HomePhone,
                WorkPhone = dto.WorkPhone,
                Mobile = dto.Mobile,
                Address = dto.Address,
                AreaId = dto.AreaId,
                IdNumber = dto.IdNumber,
                IssuePlace = dto.IssuePlace,
                IssueDate = dto.IssueDate,
                ExpiryDate = dto.ExpiryDate,
                SchoolId = dto.SchoolId,
                StagesId = dto.StagesId,
                GradesId = dto.GradesId,
                ClassroomId = dto.ClassroomId,
                StudentStatusId = dto.StudentStatusId,
                TransferTypeId = dto.TransferTypeId,
                VehicleId = dto.VehicleId,
                Discounttypeid = dto.Discounttypeid,
                Notes = dto.Notes,
                Notes2 = dto.Notes2,
                PassportNumber = dto.PassportNumber,
                RecordNumber = dto.RecordNumber,
                BirthDate = dto.BirthDate,
                BirthPlace = dto.BirthPlace,
                ContractDate = dto.ContractDate,
                IsTaxable = dto.IsTaxable,
                IsGraduate = dto.IsGraduate,
                IsFileWithdrawn = dto.IsFileWithdrawn,
                WithdrawDate = dto.WithdrawDate
            };

            await StudentRepo.AddAsync(student);
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
            student.Gender = dto.Gender;
            student.NationalId = dto.NationalId;
            student.SectionId = dto.SectionId;
            student.RegisterNextYear = dto.RegisterNextYear;
            student.DebtAmount = dto.DebtAmount;
            student.StudentImagePath = dto.StudentImagePath;
            student.ResponseName = dto.ResponseName;
            student.WorkDate = dto.WorkDate;
            student.HomePhone = dto.HomePhone;
            student.WorkPhone = dto.WorkPhone;
            student.Mobile = dto.Mobile;
            student.Address = dto.Address;
            student.AreaId = dto.AreaId;
            student.IdNumber = dto.IdNumber;
            student.IssuePlace = dto.IssuePlace;
            student.IssueDate = dto.IssueDate;
            student.ExpiryDate = dto.ExpiryDate;
            student.SchoolId = dto.SchoolId;
            student.StagesId = dto.StagesId;
            student.GradesId = dto.GradesId;
            student.ClassroomId = dto.ClassroomId;
            student.StudentStatusId = dto.StudentStatusId;
            student.TransferTypeId = dto.TransferTypeId;
            student.VehicleId = dto.VehicleId;
            student.Discounttypeid = dto.Discounttypeid;
            student.Notes = dto.Notes;
            student.Notes2 = dto.Notes2;
            student.PassportNumber = dto.PassportNumber;
            student.RecordNumber = dto.RecordNumber;
            student.BirthDate = dto.BirthDate;
            student.BirthPlace = dto.BirthPlace;
            student.ContractDate = dto.ContractDate;
            student.IsTaxable = dto.IsTaxable;
            student.IsGraduate = dto.IsGraduate;
            student.IsFileWithdrawn = dto.IsFileWithdrawn;
            student.WithdrawDate = dto.WithdrawDate;

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


        public async Task<List<SelectListItem>> GetStagesListAsync()
        {
            var stages = await _unitOfWork.Repository<Stages, int>().GetAllAsync();
            var list = stages.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.StageNM // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر المرحلة الدراسية ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetGradesListAsync()
        {
            var grades = await _unitOfWork.Repository<Grades, int>().GetAllAsync();
            var list = grades.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.GradesNm // الاسم بالعربي (افتراضي)
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر الصف ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetClassroomsListAsync()
        {
            var classrooms = await _unitOfWork.Repository<Class, int>().GetAllAsync();
            var list = classrooms.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.ClassNm // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر الفصل ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetSchoolsListAsync()
        {
            var schools = await _unitOfWork.Repository<School, int>().GetAllAsync();
            var list = schools.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.SchoolNm // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر المدرسة ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetNationsListAsync()
        {
            var nations = await _unitOfWork.Repository<Nation, int>().GetAllAsync();
            var list = nations.Select(n => new SelectListItem
            {
                Value = n.Id.ToString(),
                Text = n.NationNm // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر الجنسية ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetSectionsListAsync()
        {
            var sections = await _unitOfWork.Repository<Section, int>().GetAllAsync();
            var list = sections.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.SectionName // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر القسم ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetAreasListAsync()
        {
            var areas = await _unitOfWork.Repository<Area, int>().GetAllAsync();
            var list = areas.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AreaNm // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر الحي ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetStudentStatusesListAsync()
        {
            var statuses = await _unitOfWork.Repository<StudentStatus, int>().GetAllAsync();
            var list = statuses.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.StatusName // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر حالة الطالب ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetTransferTypesListAsync()
        {
            var types = await _unitOfWork.Repository<TransferType, int>().GetAllAsync();
            var list = types.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Route // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر نوع الانتقال ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetVehiclesListAsync()
        {
            var vehicles = await _unitOfWork.Repository<Vehicle, int>().GetAllAsync();
            var list = vehicles.Select(v => new SelectListItem
            {
                Value = v.Id.ToString(),
                Text = v.CarName // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر الحافلة ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetDiscountsListAsync()
        {
            var discounts = await _unitOfWork.Repository<Discount, int>().GetAllAsync();
            var list = discounts.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.DescountNm // الاسم بالعربي
            }).ToList();

            list.Insert(0, new SelectListItem { Value = "", Text = "--- اختر نوع الخصم ---" });
            return list;
        }

        public async Task<List<SelectListItem>> GetGendersListAsync()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Male", Text = "ذكر" },
                new SelectListItem { Value = "Female", Text = "أنثى" }
            };
        }

        // دالة حفظ الصورة
        public async Task<string?> SaveStudentImageAsync(IFormFile? imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            // التحقق من نوع الملف
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
                throw new Exception("صيغة الصورة غير مدعومة. يرجى اختيار JPG, PNG أو GIF");

            // التحقق من الحجم (2MB)
            if (imageFile.Length > 2 * 1024 * 1024)
                throw new Exception("حجم الصورة كبير جداً. الحد الأقصى 2MB");

            // إنشاء اسم فريد للصورة
            var fileName = $"student_{Guid.NewGuid()}{extension}";
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "students");

            // التأكد من وجود المجلد
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // حفظ الصورة
            var filePath = Path.Combine(uploadsFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return $"/uploads/students/{fileName}";
        }

        // دالة حذف الصورة
        public async Task DeleteStudentImageAsync(string? imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return;

            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            await Task.CompletedTask;
        }

    }
}