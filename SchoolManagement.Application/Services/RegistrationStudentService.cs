using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.RegistrationStudent;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Context;

namespace SchoolManagement.Application.Services.Implementations
{
    public class RegistrationStudentService : IRegistrationStudentService
    {
        private readonly ApplicationDbContext _context; // اسم الـ DbContext بتاعك

        public RegistrationStudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RegistrationIndexVM> GetRegistrationIndexDataAsync(int? studyYearId = null)
        {
            // جلب جميع الطلاب
            var allStudents = await _context.Students
                .Include(s => s.School)
                .ToListAsync();

            // جلب السنوات الدراسية المفتوحة
            var studyYears = await _context.StudyYears
                .Where(y => !y.IsClosed)
                .ToListAsync();

            // إذا تم تحديد سنة دراسية، قم بتصفية الطلاب غير المسجلين فيها
            List<Student> availableStudents = new List<Student>();

            if (studyYearId.HasValue && studyYearId.Value > 0)
            {
                // جلب IDs الطلاب المسجلين في هذه السنة
                var registeredStudentIds = await _context.RegistrationStudents
                    .Where(r => r.StudyYearId == studyYearId.Value)
                    .Select(r => r.StudentId)
                    .ToListAsync();

                // جلب الطلاب غير المسجلين
                availableStudents = allStudents
                    .Where(s => !registeredStudentIds.Contains(s.Id))
                    .ToList();
            }
            else
            {
                availableStudents = allStudents;
            }

            return new RegistrationIndexVM
            {
                StudentsList = availableStudents.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.FullName}"
                }).ToList(),

                StudyYearsList = studyYears.Select(y => new SelectListItem
                {
                    Value = y.Id.ToString(),
                    Text = y.StudyYearsNm
                }).ToList()
            };
        }

        public async Task<RegistrationCreateVM> GetStudentForRegistrationAsync(int studentId, int studyYearId)
        {
            // جلب بيانات الطالب بكل العلاقات
            var student = await _context.Students
                .Include(s => s.School)
                .Include(s => s.stages)
                .Include(s => s.Grades)
                .Include(s => s.Classroom)
                .Include(s => s.StudentStatuses)
                .Include(s => s.TransferType)
                .Include(s => s.Vehicle)
                .Include(s => s.Discounttype)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
                return null;

            var studyYear = await _context.StudyYears
                .FirstOrDefaultAsync(y => y.Id == studyYearId);

            var costCenters = await _context.CostCenters.ToListAsync();

            var discountTypes = await _context.Discounts.ToListAsync();

            return new RegistrationCreateVM
            {
                StudentId = student.Id,
                StudentFullName = student.FullName,
                SchoolName = student.School?.SchoolNm,
                StageName = student.stages?.StageNM,
                GradeName = student.Grades?.GradesNm,
                ClassName = student.Classroom?.ClassNm,
                StudentStatusName = student.StudentStatuses?.StatusName,
                TransferTypeName = student.TransferType?.Route,
                VehicleName = student.Vehicle?.CarName,
                DiscountTypeName = student.Discounttype?.DescountNm,
                DiscountTypeId = student.Discounttypeid,
                DiscountPercentage = student.Discounttype?.DiscPer ?? 0,

                StudyYearId = studyYearId,
                StudyYearName = studyYear?.StudyYearsNm,

                CostCentersList = costCenters.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CostNm
                }).ToList(),

                DiscountTypesList = discountTypes.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.DescountNm
                }).ToList()
            };
        }

        public async Task<bool> CreateRegistrationAsync(RegistrationCreateVM model, int userId)
        {
            try
            {
                // التحقق من عدم وجود تسجيل مسبق
                var existing = await IsStudentAlreadyRegisteredAsync(model.StudentId, model.StudyYearId);
                if (existing)
                    return false;

                // حساب الإجمالي (تأكد من القيم)
                decimal firstSemFee = model.FirstSemesterFees ?? 0;
                decimal secondSemFee = model.SecondSemesterFees ?? 0;
                decimal firstTransFee = model.FirstSemesterTransferFees ?? 0;
                decimal secondTransFee = model.SecondSemesterTransferFees ?? 0;
                decimal regFee = model.RegistrationFees ?? 0;
                decimal booksFee = model.BooksFees ?? 0;
                decimal otherFee = model.OtherFees ?? 0;

                decimal total = firstSemFee + secondSemFee + firstTransFee + secondTransFee + regFee + booksFee + otherFee;

                // حساب المبلغ بعد الخصم
                decimal amountAfterDiscount = total;
                decimal discountValue = model.DiscountValue ?? 0;
                decimal discountPercentage = model.DiscountPercentage ?? 0;

                if (discountValue > 0)
                {
                    amountAfterDiscount = total - discountValue;
                }
                else if (discountPercentage > 0)
                {
                    amountAfterDiscount = total - (total * discountPercentage / 100);
                }

                // التأكد من عدم وجود قيم null
                var registration = new RegistrationStudent
                {
                    StudentId = model.StudentId,
                    StudyYearId = model.StudyYearId,
                    FirstSemesterFees = firstSemFee,
                    SecondSemesterFees = secondSemFee,
                    FirstSemesterTransferFees = firstTransFee,
                    SecondSemesterTransferFees = secondTransFee,
                    RegistrationFees = regFee,
                    BooksFees = booksFee,
                    OtherFees = otherFee,
                    DiscountTypeId = model.DiscountTypeId,
                    DiscountValue = discountValue > 0 ? discountValue : null,
                    DiscountPercentage = discountPercentage > 0 ? discountPercentage : null,
                    TotalAmount = total,
                    AmountAfterDiscount = amountAfterDiscount,
                    Notes = model.Notes,
                    Notes2 = model.Notes2,
                    CostCenterId = model.CostCenterId,
                    RegistrationDate = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    CreatedBy = userId,
                    IsPaid = false
                };

                await _context.RegistrationStudents.AddAsync(registration);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in CreateRegistrationAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> IsStudentAlreadyRegisteredAsync(int studentId, int studyYearId)
        {
            return await _context.RegistrationStudents
                .AnyAsync(r => r.StudentId == studentId && r.StudyYearId == studyYearId);
        }

        public async Task<List<RegistrationStudent>> GetStudentRegistrationsAsync(int studentId)
        {
            return await _context.RegistrationStudents
                .Include(r => r.StudyYear)
                .Include(r => r.Student)
                .Where(r => r.StudentId == studentId)
                .OrderByDescending(r => r.StudyYear.FromDate)
                .ToListAsync();
        }

        public async Task<RegistrationStudent> GetRegistrationByIdAsync(int id)
        {
            return await _context.RegistrationStudents
                .Include(r => r.Student)
                    .ThenInclude(s => s.School)
                .Include(r => r.Student)
                    .ThenInclude(s => s.stages)
                .Include(r => r.Student)
                    .ThenInclude(s => s.Grades)
                .Include(r => r.StudyYear)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> UpdateRegistrationAsync(RegistrationCreateVM model)
        {
            try
            {
                var registration = await _context.RegistrationStudents
                    .FirstOrDefaultAsync(r => r.Id == model.StudentId); // انتبه: لازم يكون عندك RegistrationId في الـ VM

                if (registration == null)
                    return false;

                // إعادة حساب الإجمالي
                decimal total = (model.FirstSemesterFees ?? 0) +
                               (model.SecondSemesterFees ?? 0) +
                               (model.FirstSemesterTransferFees ?? 0) +
                               (model.SecondSemesterTransferFees ?? 0) +
                               (model.RegistrationFees ?? 0) +
                               (model.BooksFees ?? 0) +
                               (model.OtherFees ?? 0);

                decimal amountAfterDiscount = total;
                if (model.DiscountValue.HasValue && model.DiscountValue > 0)
                {
                    amountAfterDiscount = total - model.DiscountValue.Value;
                }
                else if (model.DiscountPercentage.HasValue && model.DiscountPercentage > 0)
                {
                    amountAfterDiscount = total - (total * model.DiscountPercentage.Value / 100);
                }

                registration.FirstSemesterFees = model.FirstSemesterFees;
                registration.SecondSemesterFees = model.SecondSemesterFees;
                registration.FirstSemesterTransferFees = model.FirstSemesterTransferFees;
                registration.SecondSemesterTransferFees = model.SecondSemesterTransferFees;
                registration.RegistrationFees = model.RegistrationFees;
                registration.BooksFees = model.BooksFees;
                registration.OtherFees = model.OtherFees;
                registration.DiscountTypeId = model.DiscountTypeId;
                registration.DiscountValue = model.DiscountValue;
                registration.DiscountPercentage = model.DiscountPercentage;
                registration.TotalAmount = total;
                registration.AmountAfterDiscount = amountAfterDiscount;
                registration.Notes = model.Notes;
                registration.Notes2 = model.Notes2;
                registration.CostCenterId = model.CostCenterId;

                _context.RegistrationStudents.Update(registration);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRegistrationAsync(int id)
        {
            try
            {
                var registration = await _context.RegistrationStudents
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (registration == null)
                    return false;

                _context.RegistrationStudents.Remove(registration);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<RegistrationStudent>> GetRegistrationsByStudyYearAsync(int studyYearId)
        {
            return await _context.RegistrationStudents
                .Include(r => r.Student)
                .Include(r => r.StudyYear)
                .Where(r => r.StudyYearId == studyYearId)
                .ToListAsync();
        }

        public async Task<List<RegistrationStudent>> GetAllRegistrationsAsync()
        {
            return await _context.RegistrationStudents
                .Include(r => r.Student)
                    .ThenInclude(s => s.School)
                .Include(r => r.Student)
                    .ThenInclude(s => s.stages)
                .Include(r => r.Student)
                    .ThenInclude(s => s.Grades)
                .Include(r => r.StudyYear)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }
    }
}