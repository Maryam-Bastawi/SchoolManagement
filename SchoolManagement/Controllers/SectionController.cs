using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Sections;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        // GET: Section
        public async Task<IActionResult> Index()
        {
            var sections = await _sectionService.GetAllAsync();
            return View(sections);
        }

        // GET: Section/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var section = await _sectionService.GetByIdAsync(id);
            if (section == null) return NotFound();
            return View(section);
        }

        // GET: Section/Create
        public IActionResult Create()
        {
            return View(new CreateSectionDto());
        }

        // POST: Section/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSectionDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            try
            {
                var id = await _sectionService.CreateAsync(dto);
                TempData["SuccessMessage"] = $"✅ تم إضافة القسم بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _sectionService.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: Section/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateSectionDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _sectionService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل بيانات القسم بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Section/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sectionService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف القسم بنجاح!";
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
