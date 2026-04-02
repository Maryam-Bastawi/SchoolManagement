using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Vat;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class VatController : Controller
    {
        private readonly IVatService _vatService;

        public VatController(IVatService vatService)
        {
            _vatService = vatService;
        }

        // GET: Vat
        public async Task<IActionResult> Index()
        {
            var vats = await _vatService.GetAllAsync(); // بيرجع List<GetVatDto> جاهز
            return View(vats);
        }

        // GET: Vat/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vat = await _vatService.GetByIdAsync(id); // بيرجع GetVatDto أو null
            if (vat == null) return NotFound();
            return View(vat);
        }

        // GET: Vat/Create
        public IActionResult Create()
        {
            return View(new CreateVatDto());
        }

        // POST: Vat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVatDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _vatService.CreateAsync(dto); // بيرجع Id جاهز
                TempData["SuccessMessage"] = $"✅ تم إضافة ضريبة القيمة المضافة بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Vat/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _vatService.GetByIdAsync(id); // بيرجع GetVatDto
            if (data == null) return NotFound();

            var dto = new UpdateVatDto
            {
                Id = data.Id,
                VATNM = data.VATNM,
                VATNM_E = data.VATNM_E,
                NOTES = data.NOTES,
                VAT_PERCENT = data.VAT_PERCENT,
                IS_DEFUALT = data.IS_DEFUALT
            };
            return View(dto);
        }

        // POST: Vat/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateVatDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _vatService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل بيانات ضريبة القيمة المضافة بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Vat/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vatService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف ضريبة القيمة المضافة بنجاح!";
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
