using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Schoool;
using SchoolManagement.Application.ServicesInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManagement.Controllers
{
    public class SchoolsController : Controller
    {
        private readonly ISchoolService _schoolService;

        public SchoolsController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        // GET: Schools
        public async Task<IActionResult> Index()
        {
            var schools = await _schoolService.GetAllAsync(); // بيرجع List<GetSchoolDto> جاهز
            return View(schools);
        }

        // GET: Schools/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var school = await _schoolService.GetByIdAsync(id); // بيرجع GetSchoolDto أو null
            if (school == null) return NotFound();
            return View(school);
        }

        // GET: Schools/Create
        public IActionResult Create()
        {
            return View(new CreateSchoolDto());
        }

        // POST: Schools/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSchoolDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _schoolService.CreateAsync(dto); // بيرجع Id جاهز
                TempData["SuccessMessage"] = $"✅ تمت إضافة المدرسة بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Schools/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _schoolService.GetByIdAsync(id); // السيرفس بيرجع UpdateSchoolDto جاهز
            if (data == null) return NotFound();
            var dto = new UpdateSchoolDto
            {
                Id = data.Id,
                SchoolNm = data.SchoolNm,
                SchoolNmEn = data.SchoolNmEn
           
            };
            return View(dto);
        }

        // POST: Schools/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateSchoolDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _schoolService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل بيانات المدرسة بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Schools/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _schoolService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف المدرسة بنجاح!";
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
