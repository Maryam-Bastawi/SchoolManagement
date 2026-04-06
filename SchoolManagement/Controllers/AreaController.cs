using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Areas;
using SchoolManagement.Application.DTOs.Schoool;
using SchoolManagement.Application.Services;
using SchoolManagement.Application.ServicesInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManagement.Controllers
{
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly PaginationService _paginationService;

        public AreaController(IAreaService areaService, PaginationService paginationService)
        {
            _areaService = areaService;
            _paginationService = paginationService;

        }

        // GET: Area

        public async Task<IActionResult> Index(string search, int page = 1, int pageSize = 10)
        {
            // جلب جميع المناطق من الخدمة
            var areas = await _areaService.GetAllAsync();

            // فلترة حسب البحث (إن وجد)
            if (!string.IsNullOrEmpty(search))
            {
                areas = areas
                    .Where(a => a.AreaNm != null && a.AreaNm.Contains(search, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // حساب العدد الإجمالي للعناصر بعد الفلترة
            var totalCount = areas.Count;

            // جلب البيانات الخاصة بالصفحة الحالية فقط (Pagination)
            var pagedAreas = _paginationService.GetPagedData(areas, page, pageSize);

            // إنشاء نموذج Pagination لعرضه في الـ View
            var paginationModel = _paginationService.GetPaginationModel(page, totalCount, pageSize, "Index", search);

            // تخزين الـ Pagination في ViewBag لاستخدامه في الـ View
            ViewBag.Pagination = paginationModel;

            // إرجاع البيانات للـ View
            return View(pagedAreas);
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
            if (ModelState.IsValid)
            {
                await _areaService.CreateAsync(dto);
                TempData["Success"] = "تم إضافة المنطقة بنجاح!";

                // حساب الصفحة التي سيظهر فيها العنصر الجديد
                var allAreas = await _areaService.GetAllAsync();
                int pageSize = 10;
                int newItemIndex = allAreas.Count();
                int targetPage = (int)System.Math.Ceiling((double)newItemIndex / pageSize);

                return RedirectToAction(nameof(Index), new { page = targetPage, pageSize = 10 });
            }

            return View(dto);
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
