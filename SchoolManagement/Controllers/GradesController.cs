using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Grades;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class GradesController : Controller
    {
        private readonly IGradesService _gradesService;

        public GradesController(IGradesService gradesService)
        {
            _gradesService = gradesService;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
            var grades = await _gradesService.GetAllAsync();
            return View(grades);
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var grade = await _gradesService.GetByIdAsync(id);
            if (grade == null) return NotFound();

            return View(grade);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            return View(new CreateGradesDto());
        }

        // POST: Grades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGradesDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _gradesService.CreateAsync(dto);
                TempData["SuccessMessage"] = $"✅ تم إضافة الصف بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _gradesService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            return View(dto);
        }

        // POST: Grades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateGradesDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _gradesService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل الصف بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Grades/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _gradesService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف الصف بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
