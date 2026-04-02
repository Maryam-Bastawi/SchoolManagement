using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.StudyYear;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class StudyYearController : Controller
    {
        private readonly IStudyYearService _studyYearService;

        public StudyYearController(IStudyYearService studyYearService)
        {
            _studyYearService = studyYearService;
        }

        // GET: StudyYear
        public async Task<IActionResult> Index()
        {
            var studyYears = await _studyYearService.GetAllAsync();
            return View(studyYears);
        }

        // GET: StudyYear/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var studyYear = await _studyYearService.GetByIdAsync(id);
            if (studyYear == null) return NotFound();
            return View(studyYear);
        }

        // GET: StudyYear/Create
        public IActionResult Create()
        {
            return View(new CreateStudyYearDto());
        }

        // POST: StudyYear/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudyYearDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _studyYearService.CreateAsync(dto);
                TempData["SuccessMessage"] = $"✅ تم إضافة السنة الدراسية بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: StudyYear/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // جلب السنة الدراسية من الخدمة
            var dto = await _studyYearService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            // إنشاء DTO للتحديث وملء كل الحقول
            var updateDto = new UpdateStudyYearDto
            {
                Id = dto.Id,
                StudyYearsNm = dto.StudyYearsNm,
                StudyYearsNm_E = dto.StudyYearsNm_E,
                FromDate = dto.FromDate,
                ToDate = dto.ToDate,
                IsClosed = dto.IsClosed,
                IsNewYear = dto.IsNewYear,
                IsDefault = dto.IsDefault
            };

            return View(updateDto); // إرسال DTO المعدل للـ View
        }

        // POST: StudyYear/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateStudyYearDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _studyYearService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل السنة الدراسية بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: StudyYear/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studyYearService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف السنة الدراسية بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
