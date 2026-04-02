using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Bank;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        // GET: Bank
        public async Task<IActionResult> Index()
        {
            var banks = await _bankService.GetAllAsync(); // بيرجع List<GetBankDto>
            return View(banks);
        }

        // GET: Bank/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var bank = await _bankService.GetByIdAsync(id); // بيرجع GetBankDto أو null
            if (bank == null) return NotFound();
            return View(bank);
        }

        // GET: Bank/Create
        public IActionResult Create()
        {
            return View(new CreateBankDto());
        }

        // POST: Bank/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBankDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _bankService.CreateAsync(dto); // بيرجع Id جاهز
                TempData["SuccessMessage"] = $"✅ تم إضافة البنك بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message;
                ModelState.AddModelError("", $"Error: {inner ?? ex.Message}");
                return View(dto);
            }
        }

        // GET: Bank/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _bankService.GetByIdAsync(id); // بيرجع GetBankDto

            if (data == null) return NotFound();

            // تحويل صريح لـ UpdateBankDto
            var dto = new UpdateBankDto
            {
                Id = data.Id,
                BankName = data.BankName,
                BankNameEn = data.BankNameEn,
                Responsible = data.Responsible
            };

            return View(dto); // هنا النوع صحيح
        }
        // POST: Bank/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateBankDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _bankService.UpdateAsync(dto);
                TempData["SuccessMessage"] = "تم تعديل بيانات البنك بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
            }
        }

        // POST: Bank/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bankService.DeleteAsync(id);
                TempData["SuccessMessage"] = "تم حذف البنك بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
