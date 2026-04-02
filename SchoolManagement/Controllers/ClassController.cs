using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.Application.DTOs.Class;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Interface;

namespace SchoolManagement.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly IUnitOfWork _unitOfWork;

        public ClassController(IClassService classService, IUnitOfWork unitOfWork)
        {
            _classService = classService;
            _unitOfWork = unitOfWork;
        }

        // GET: Class/Index
        public async Task<IActionResult> Index()
        {
            var classes = await _classService.GetAllAsync();
            ViewData["Title"] = "قائمة الفصول";
            return View(classes);
        }

        // GET: Class/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var classEntity = await _classService.GetByIdAsync(id);
            if (classEntity == null)
                return NotFound();
            ViewData["Title"] = "تفاصيل الفصل";
            return View(classEntity);
        }

        // GET: Class/Create
        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();
            ViewData["Title"] = "إضافة فصل جديد";
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClassDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _classService.CreateAsync(dto);
                    TempData["Success"] = "تم إضافة الفصل بنجاح";
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            await LoadDropdowns();
            return View(dto);
        }

        // GET: Class/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var classEntity = await _classService.GetByIdAsync(id);
            if (classEntity == null)
                return NotFound();

            var updateDto = new UpdateClassDto
            {
                Id = classEntity.Id,
                ClassNm = classEntity.ClassNm,
                ClassNmEn = classEntity.ClassNmEn,
                GradeId = classEntity.GradeId
            };

            await LoadDropdowns();
            ViewData["Title"] = "تعديل الفصل";
            return View(updateDto);
        }

        // POST: Class/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateClassDto dto)
        {
            if (id != dto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _classService.UpdateAsync(dto);
                    TempData["Success"] = "تم تحديث الفصل بنجاح";
                    return RedirectToAction(nameof(Index));
                }
                catch (KeyNotFoundException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            await LoadDropdowns();
            return View(dto);
        }

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var classEntity = await _classService.GetByIdAsync(id);
            if (classEntity == null)
                return NotFound();
            ViewData["Title"] = "حذف الفصل";
            return View(classEntity);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _classService.DeleteAsync(id);
                TempData["Success"] = "تم حذف الفصل بنجاح";
            }
            catch (KeyNotFoundException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // دالة تحميل الـ Dropdown Lists
        private async Task LoadDropdowns()
        {
            var gradesRepo = _unitOfWork.Repository<Grades, int>();
            var grades = await gradesRepo.GetAllAsync();

            ViewBag.Grades = new SelectList(grades.OrderBy(x => x.GradesNm), "Id", "GradesNm");
        }

        // AJAX Check for Unique Names
        [HttpGet]
        public async Task<IActionResult> CheckNameUnique(string name, int? excludeId = null)
        {
            var isUnique = await _classService.IsNameUniqueAsync(name, excludeId);
            return Json(isUnique);
        }

        [HttpGet]
        public async Task<IActionResult> CheckEnglishNameUnique(string name, int? excludeId = null)
        {
            var isUnique = await _classService.IsEnglishNameUniqueAsync(name, excludeId);
            return Json(isUnique);
        }
    }
}
