using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.StuStatus;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class StudentStatusController : Controller
    {
        private readonly IStudentStatusService _studentStatusService;

        public StudentStatusController(IStudentStatusService studentStatusService)
        {
            _studentStatusService = studentStatusService;
        }

        // GET: StudentStatus
        public async Task<IActionResult> Index()
        {
            var statuses = await _studentStatusService.GetAllAsync();
            return View(statuses);
        }

        // GET: StudentStatus/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var status = await _studentStatusService.GetByIdAsync(id);
            if (status == null) return NotFound();
            return View(status);
        }

        // GET: StudentStatus/Create
        public IActionResult Create()
        {
            return View(new CreateStudentStatusDto());
        }

        // POST: StudentStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentStatusDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            try
            {
                var id = await _studentStatusService.CreateAsync(dto);
                TempData["SuccessMessage"] = $"✅ تم إضافة حالة الطالب بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: StudentStatus/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _studentStatusService.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: StudentStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateStudentStatusDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _studentStatusService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل حالة الطالب بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: StudentStatus/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentStatusService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف حالة الطالب بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
