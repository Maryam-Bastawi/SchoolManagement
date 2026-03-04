using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.TransferType;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class TransferTypeController : Controller
    {
        private readonly ITransferTypeService _service;

        public TransferTypeController(ITransferTypeService service)
        {
            _service = service;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
        }

        // GET: Details
        public async Task<IActionResult> Details(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return View(item);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTransferTypeDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _service.CreateAsync(dto);
            TempData["Success"] = "تم إضافة نوع التحويل بنجاح";
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _service.GetByIdAsync(id);
            var dto = new UpdateTransferTypeDto
            {
                Id = item.Id,
                Route = item.Route,
                RouteEng = item.RouteEng,
                Exmount1 = item.Exmount1,
                Exmount2 = item.Exmount2
            };
            return View(dto);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateTransferTypeDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _service.UpdateAsync(dto);
            TempData["Success"] = "تم تعديل نوع التحويل بنجاح";
            return RedirectToAction(nameof(Index));
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            TempData["Success"] = "تم حذف نوع التحويل بنجاح";
            return RedirectToAction(nameof(Index));
        }
    }
}
