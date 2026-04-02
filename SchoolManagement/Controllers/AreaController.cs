using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Areas;
using SchoolManagement.Application.DTOs.Schoool;
using SchoolManagement.Application.ServicesInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManagement.Controllers
{
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        // GET: Area
        public async Task<IActionResult> Index()
        {
            var areas = await _areaService.GetAllAsync(); // بيرجع List<GetAreaDto>
            return View(areas);
        }

        // GET: Area/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var area = await _areaService.GetByIdAsync(id); // بيرجع GetAreaDto أو null
            if (area == null) return NotFound();
            return View(area);
        }

        // GET: Area/Create
        public IActionResult Create()
        {
            return View(new CreateAreaDto());
        }

        // POST: Area/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAreaDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _areaService.CreateAsync(dto); // بيرجع Id جاهز
                TempData["SuccessMessage"] = $"✅ تم إضافة المنطقة بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Area/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _areaService.GetByIdAsync(id); // بيرجع UpdateAreaDto جاهز
            if (data == null) return NotFound();
            var dto = new UpdateAreaDto
            {
                Id = data.Id,
                AreaNm = data.AreaNm,
                AreaNm_E = data.AreaNm_E,
                Resp = data.Resp

            };
            return View(dto);
        }

        // POST: Area/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateAreaDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _areaService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل بيانات المنطقة بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Area/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _areaService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف المنطقة بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
