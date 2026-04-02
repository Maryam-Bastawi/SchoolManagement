using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Bank;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.Services;
using SchoolManagement.Application.ServicesInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManagement.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        // GET: Branch
        public async Task<IActionResult> Index()
        {
            var branches = await _branchService.GetAllAsync();
            return View(branches);
        }

        // GET: Branch/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var branch = await _branchService.GetByIdAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // GET: Branch/Create
        public IActionResult Create()
        {
            return View(new CreateBranchDto());
        }

        // POST: Branch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBranchDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _branchService.CreateAsync(dto);
                TempData["SuccessMessage"] = $"✅ تم إضافة الفرع بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Branch/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _branchService.GetByIdAsync(id);
            if (data == null) return NotFound();
            var dto = new UpdateBranchDto
            {
                Id = data.Id,
                BRNNM = data.BRNNM,
                BRNNM_E = data.BRNNM_E,
                RESP = data.RESP
            };

            return View(dto);
        }

        // POST: Branch/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateBranchDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _branchService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل بيانات الفرع بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Branch/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _branchService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف الفرع بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
