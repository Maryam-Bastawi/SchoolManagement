using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Stages;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class StagesController : Controller
    {
        private readonly IStagesService _stagesService;

        public StagesController(IStagesService stagesService)
        {
            _stagesService = stagesService;
        }

        // GET: Stages
        public async Task<IActionResult> Index()
        {
            var stages = await _stagesService.GetAllAsync();
            return View(stages);
        }

        // GET: Stages/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var stage = await _stagesService.GetByIdAsync(id);
            if (stage == null) return NotFound();

            return View(stage);
        }

        // GET: Stages/Create
        public IActionResult Create()
        {
            return View(new CreateStagesDto());
        }

        // POST: Stages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStagesDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _stagesService.CreateAsync(dto);
                TempData["SuccessMessage"] = $"✅ تم إضافة المرحلة بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Stages/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _stagesService.GetByIdAsync(id);
            if (dto == null) return NotFound();
            var dto1 = new UpdateStagesDto
            {
                Id = dto.Id,
                StageNM = dto.StageNM,
                StageNM_E = dto.StageNM_E

            };
            return View(dto1);
        }

        // POST: Stages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateStagesDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _stagesService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل المرحلة بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Stages/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _stagesService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف المرحلة بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
