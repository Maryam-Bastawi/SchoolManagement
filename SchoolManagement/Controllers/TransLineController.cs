using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.TransLine;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class TransLineController : Controller
    {
  
            private readonly ITransLineService _transLineService;

            public TransLineController(ITransLineService transLineService) // ✔ ده صح
            {
                _transLineService = transLineService;
            }



        // GET: TransLine
        public async Task<IActionResult> Index()
            {
                var lines = await _transLineService.GetAllAsync();
                return View(lines);
            }

            // GET: TransLine/Details/5
            public async Task<IActionResult> Details(int id)
            {
                var line = await _transLineService.GetByIdAsync(id);
                if (line == null) return NotFound();
                return View(line);
            }

            // GET: TransLine/Create
            public IActionResult Create()
            {
                return View(new CreateTransLineDto());
            }

            // POST: TransLine/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(CreateTransLineDto dto)
            {
                if (!ModelState.IsValid)
                    return View(dto);

                try
                {
                    var id = await _transLineService.CreateAsync(dto);
                    TempData["SuccessMessage"] = $"✅ تم إضافة خط النقل بنجاح بالكود: {id}";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                    return View(dto);
                }
            }

            // GET: TransLine/Edit/5
            public async Task<IActionResult> Edit(int id)
            {
                var dto = await _transLineService.GetByIdAsync(id);
                if (dto == null) return NotFound();
            var data = new UpdateTransLineDto
            {
                Id = dto.Id,
                TransLineName = dto.TransLineName,
                TransLineNameEn = dto.TransLineNameEn,
                Responsible = dto.Responsible
            };
                return View(data);
            }

            // POST: TransLine/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, UpdateTransLineDto dto)
            {
                if (id != dto.Id) return NotFound();
                if (!ModelState.IsValid) return View(dto);

                try
                {
                    await _transLineService.UpdateAsync(dto);
                    TempData["SuccessMessage"] = "تم تعديل خط النقل بنجاح!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                    return View(dto);
                }
            }

            // POST: TransLine/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    await _transLineService.DeleteAsync(id);
                    TempData["SuccessMessage"] = "تم حذف خط النقل بنجاح!";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
                }

                return RedirectToAction(nameof(Index));
            }
        }
}
