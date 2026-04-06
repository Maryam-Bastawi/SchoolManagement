using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.RegistrationStudent;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Infrastructure.Context;
using System.Security.Claims;

namespace SchoolManagement.Web.Controllers
{
    public class RegistrationStudentController : Controller
    {
        private readonly IRegistrationStudentService _registrationService;
        private readonly ApplicationDbContext _context;

        public RegistrationStudentController(
          IRegistrationStudentService registrationService,
          ApplicationDbContext context)
        {
            _registrationService = registrationService;
            _context = context;
        }

        // GET: RegistrationStudent/Index
        public async Task<IActionResult> Index()
        {
            var model = new RegistrationIndexVM
            {
                Registrations = await _registrationService.GetAllRegistrationsAsync(),
                // لا تجلب الطلاب هنا - خليها فاضية
                StudentsList = new List<SelectListItem>(),
                StudyYearsList = (await _registrationService.GetRegistrationIndexDataAsync()).StudyYearsList
            };

            return View(model);
        }
        public async Task<RegistrationIndexVM> GetRegistrationIndexDataAsync(int? studyYearId = null)
        {
            // جلب السنوات الدراسية المفتوحة
            var studyYears = await _context.StudyYears
                .Where(y => !y.IsClosed)
                .ToListAsync();

            // إذا لم يتم تحديد سنة، أرجع قائمة طلاب فاضية
            if (!studyYearId.HasValue || studyYearId.Value == 0)
            {
                return new RegistrationIndexVM
                {
                    StudentsList = new List<SelectListItem>(),
                    StudyYearsList = studyYears.Select(y => new SelectListItem
                    {
                        Value = y.Id.ToString(),
                        Text = y.StudyYearsNm
                    }).ToList()
                };
            }

            // جلب جميع الطلاب
            var allStudents = await _context.Students
                .Include(s => s.School)
                .ToListAsync();

            // جلب IDs الطلاب المسجلين في هذه السنة
            var registeredStudentIds = await _context.RegistrationStudents
                .Where(r => r.StudyYearId == studyYearId.Value)
                .Select(r => r.StudentId)
                .ToListAsync();

            // جلب الطلاب غير المسجلين
            var availableStudents = allStudents
                .Where(s => !registeredStudentIds.Contains(s.Id))
                .ToList();

            return new RegistrationIndexVM
            {
                StudentsList = availableStudents.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.FullName} - {(s.School != null ? s.School.SchoolNm : "بدون مدرسة")}"
                }).ToList(),

                StudyYearsList = studyYears.Select(y => new SelectListItem
                {
                    Value = y.Id.ToString(),
                    Text = y.StudyYearsNm
                }).ToList()
            };
        }

        // POST: RegistrationStudent/Index - بدء تسجيل جديد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegistrationIndexVM model)
        {
            if (model.SelectedStudyYearId == null || model.SelectedStudyYearId == 0)
            {
                TempData["Error"] = "⚠️ الرجاء اختيار العام الدراسي أولاً";
                return RedirectToAction("Index");
            }

            if (model.SelectedStudentId == null || model.SelectedStudentId == 0)
            {
                TempData["Error"] = "⚠️ الرجاء اختيار الطالب";
                return RedirectToAction("Index");
            }

            // التحقق الإضافي - تأكد إن الطالب مش مسجل (لأمان إضافي)
            var isRegistered = await _registrationService.IsStudentAlreadyRegisteredAsync(
                model.SelectedStudentId.Value,
                model.SelectedStudyYearId.Value);

            if (isRegistered)
            {
                TempData["Error"] = "⚠️ هذا الطالب مسجل بالفعل في هذا العام الدراسي";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create", new
            {
                studentId = model.SelectedStudentId.Value,
                studyYearId = model.SelectedStudyYearId.Value
            });
        }
        // GET: RegistrationStudent/Create
        public async Task<IActionResult> Create(int studentId, int studyYearId)
        {
            var isRegistered = await _registrationService.IsStudentAlreadyRegisteredAsync(studentId, studyYearId);
            if (isRegistered)
            {
                TempData["Error"] = "⚠️ هذا الطالب مسجل بالفعل في هذا العام الدراسي";
                return RedirectToAction("Index");
            }

            var model = await _registrationService.GetStudentForRegistrationAsync(studentId, studyYearId);

            if (model == null)
            {
                TempData["Error"] = "⚠️ الطالب أو العام الدراسي غير موجود";
                return RedirectToAction("Index");
            }

            // تأكد إنك بترجع الـ View الصحيحة
            return View("Create", model);  // اضيف "Create" صراحة
        }

        // POST: RegistrationStudent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationCreateVM model)
        {
            // إزالة التحقق من ModelState مؤقتاً للتجربة
            // if (ModelState.IsValid)
            // {
            try
            {
                var userId = 1;
                var result = await _registrationService.CreateRegistrationAsync(model, userId);

                if (result)
                {
                    TempData["Success"] = "✅ تم تسجيل الطالب بنجاح";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "❌ حدث خطأ أثناء حفظ التسجيل، أو الطالب مسجل مسبقاً";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ خطأ: {ex.Message}";
            }
            // }

            // في حالة الخطأ، إعادة تحميل القوائم
            var studentData = await _registrationService.GetStudentForRegistrationAsync(model.StudentId, model.StudyYearId);
            if (studentData != null)
            {
                model.CostCentersList = studentData.CostCentersList;
                model.DiscountTypesList = studentData.DiscountTypesList;
            }

            return View("Create", model);
        }

        // GET: RegistrationStudent/StudentRegistrations/5
        public async Task<IActionResult> StudentRegistrations(int studentId)
        {
            var registrations = await _registrationService.GetStudentRegistrationsAsync(studentId);
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);

            ViewBag.StudentName = student?.FullName;
            ViewBag.StudentId = studentId;

            return View(registrations);
        }

        // GET: RegistrationStudent/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var registration = await _registrationService.GetRegistrationByIdAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: RegistrationStudent/AllRegistrations
        public async Task<IActionResult> AllRegistrations()
        {
            var registrations = await _registrationService.GetAllRegistrationsAsync();
            return View(registrations);
        }

        // POST: RegistrationStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _registrationService.DeleteRegistrationAsync(id);

            if (result)
            {
                TempData["Success"] = "✅ تم حذف التسجيل بنجاح";
            }
            else
            {
                TempData["Error"] = "❌ حدث خطأ أثناء حذف التسجيل";
            }

            return RedirectToAction("AllRegistrations");
        }
        // GET: RegistrationStudent/GetUnregisteredStudents
        [HttpGet]
        public async Task<IActionResult> GetUnregisteredStudents(int studyYearId)
        {
            var allStudents = await _context.Students
                .Include(s => s.School)
                .ToListAsync();

            var registeredStudentIds = await _context.RegistrationStudents
                .Where(r => r.StudyYearId == studyYearId)
                .Select(r => r.StudentId)
                .ToListAsync();

            var availableStudents = allStudents
                .Where(s => !registeredStudentIds.Contains(s.Id))
                .Select(s => new {
                    value = s.Id,
                    text = $"{s.FullName} - {(s.School != null ? s.School.SchoolNm : "بدون مدرسة")}"
                })
                .ToList();

            return Ok(availableStudents);
        }
    }
}