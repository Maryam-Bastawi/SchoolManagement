using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.CostCenter;
using SchoolManagement.Application.Services;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class CostCenterController : Controller
    {
        private readonly ICostCenterService _costCenterService;

        public CostCenterController(ICostCenterService costCenterService)
        {
            _costCenterService = costCenterService;
        }

        // GET: CostCenter
        public async Task<IActionResult> Index()
        {
            var costCenters = await _costCenterService.GetAllAsync();
            return View(costCenters);
        }

        // GET: CostCenter/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var costCenter = await _costCenterService.GetByIdAsync(id);
            if (costCenter == null) return NotFound();
            return View(costCenter);
        }

        // GET: CostCenter/Create
        public IActionResult Create()
        {
            return View(new CreateCostCenterDto());
        }

        // POST: CostCenter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCostCenterDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _costCenterService.CreateAsync(dto);
                TempData["SuccessMessage"] = $"✅ تم إضافة مركز التكلفة بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: CostCenter/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _costCenterService.GetByIdAsync(id);
            if (dto == null) return NotFound();
            var data = new UpdateCostCenterDto
            {
                Id = dto.Id,
                CostNm = dto.CostNm,
                CostNme = dto.CostNme
            };
            return View(data);
        }

        // POST: CostCenter/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateCostCenterDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _costCenterService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل مركز التكلفة بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: CostCenter/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _costCenterService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف مركز التكلفة بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
