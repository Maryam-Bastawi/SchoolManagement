using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Nation;
using SchoolManagement.Application.ServicesInterfaces;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Controllers
{
    public class NationController : Controller
    {
        private readonly INationService _nationService;

        public NationController(INationService nationService)
        {
            _nationService = nationService;
        }

        // GET: Nation
        public async Task<IActionResult> Index()
        {
            var nations = await _nationService.GetAllAsync(); // بيرجع List<GetNationDto>
            return View(nations);
        }

        // GET: Nation/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var nation = await _nationService.GetByIdAsync(id); // بيرجع GetNationDto أو null
            if (nation == null) return NotFound();
            return View(nation);
        }

        // GET: Nation/Create
        public IActionResult Create()
        {
            return View(new CreateNationDto());
        }

        // POST: Nation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNationDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _nationService.CreateAsync(dto); // بيرجع Id جاهز
                TempData["SuccessMessage"] = $"✅ تم إضافة الجنسية بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Nation/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _nationService.GetByIdAsync(id); // بيرجع UpdateNationDto جاهز
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: Nation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateNationDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _nationService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل بيانات الجنسية بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Nation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _nationService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف الجنسية بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}