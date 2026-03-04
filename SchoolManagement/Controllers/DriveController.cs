using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Drive;
using SchoolManagement.Application.ServicesInterfaces;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Controllers
{
    public class DriveController : Controller
    {
        private readonly IDriveService _driveService;

        public DriveController(IDriveService driveService)
        {
            _driveService = driveService;
        }

        // GET: Drive
        public async Task<IActionResult> Index()
        {
            var drives = await _driveService.GetAllAsync(); // بيرجع List<GetDriveDto>
            return View(drives);
        }

        // GET: Drive/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var drive = await _driveService.GetByIdAsync(id); // بيرجع GetDriveDto أو null
            if (drive == null) return NotFound();
            return View(drive);
        }

        // GET: Drive/Create
        public IActionResult Create()
        {
            return View(new CreateDriveDto());
        }

        // POST: Drive/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDriveDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _driveService.CreateAsync(dto); // بيرجع Id جاهز
                TempData["SuccessMessage"] = $"✅ تم إضافة السائق بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Drive/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _driveService.GetByIdAsync(id); // بيرجع UpdateDriveDto جاهز
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: Drive/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateDriveDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _driveService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل بيانات السائق بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Drive/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _driveService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف السائق بنجاح!";
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