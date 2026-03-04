using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Supervisor;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class SupervisorController : Controller
    {
        private readonly ISupervisorService _supervisorService;

        public SupervisorController(ISupervisorService supervisorService)
        {
            _supervisorService = supervisorService;
        }

        // GET: Supervisor
        public async Task<IActionResult> Index()
        {
            var supervisors = await _supervisorService.GetAllAsync(); // بيرجع List<GetSupervisorDto>
            return View(supervisors);
        }

        // GET: Supervisor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var supervisor = await _supervisorService.GetByIdAsync(id); // بيرجع GetSupervisorDto أو null
            if (supervisor == null) return NotFound();
            return View(supervisor);
        }

        // GET: Supervisor/Create
        public IActionResult Create()
        {
            return View(new CreateSupervisorDto());
        }

        // POST: Supervisor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSupervisorDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _supervisorService.CreateAsync(dto); // بيرجع Id جاهز
                TempData["SuccessMessage"] = $"✅ تم إضافة المشرف بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Supervisor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _supervisorService.GetByIdAsync(id); // بيرجع UpdateSupervisorDto جاهز
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: Supervisor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateSupervisorDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _supervisorService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل بيانات المشرف بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Supervisor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _supervisorService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف المشرف بنجاح!";
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
