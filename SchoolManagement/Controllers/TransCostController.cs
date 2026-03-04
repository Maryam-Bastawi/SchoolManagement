using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.TransCost;
using SchoolManagement.Application.Services;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class TransCostController : Controller
    {
        private readonly ITransCostService _transCostService;

        public TransCostController(ITransCostService transCostService)
        {
            _transCostService = transCostService;
        }

        // GET: TransCost
        public async Task<IActionResult> Index()
        {
            var costs = await _transCostService.GetAllAsync(); // بيرجع List<GetTransCostDto>
            return View(costs);
        }

        // GET: TransCost/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cost = await _transCostService.GetByIdAsync(id); // بيرجع GetTransCostDto أو null
            if (cost == null) return NotFound();
            return View(cost);
        }

        // GET: TransCost/Create
        public IActionResult Create()
        {
            return View(new CreateTransCostDto());
        }

        // POST: TransCost/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTransCostDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _transCostService.CreateAsync(dto);
                TempData["SuccessMessage"] = $"✅ تم إضافة تكلفة النقل بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: TransCost/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _transCostService.GetByIdAsync(id); // بيرجع UpdateTransCostDto جاهز
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: TransCost/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateTransCostDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _transCostService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل تكلفة النقل بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: TransCost/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _transCostService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف تكلفة النقل بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
