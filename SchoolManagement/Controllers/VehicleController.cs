using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.Application.DTOs.Vehicle;
using SchoolManagement.Application.ServicesInterfaces;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: Vehicle
        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            return View(vehicles);
        }

        // GET: Vehicle/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var vehicle = await _vehicleService.GetByIdAsync(id);
                return View(vehicle);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: Vehicle/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Drivers = await GetDriversSelectList();
            return View(new CreateVehicleDto());
        }

        // POST: Vehicle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVehicleDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Drivers = await GetDriversSelectList();
                return View(dto);
            }

            try
            {
                var id = await _vehicleService.CreateAsync(dto);
                TempData["Success"] = "تم إضافة المركبة بنجاح";
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "حدث خطأ غير متوقع: " + ex.Message);
            }

            ViewBag.Drivers = await GetDriversSelectList();
            return View(dto);
        }

        // GET: Vehicle/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var vehicle = await _vehicleService.GetByIdAsync(id);

                var updateDto = new UpdateVehicleDto
                {
                    Id = vehicle.Id,
                    CarName = vehicle.CarName,
                    CarNameEn = vehicle.CarNameEn,
                    InStock = vehicle.InStock,
                    PlateNum = vehicle.PlateNum,
                    Color = vehicle.Color,
                    Model = vehicle.Model,
                    Chasee = vehicle.Chasee,
                    LicIssueDate = vehicle.LicIssueDate,
                    LicEndDate = vehicle.LicEndDate,
                    DriveId = vehicle.DriveId
                };

                ViewBag.Drivers = await GetDriversSelectList(vehicle.DriveId);
                return View(updateDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Vehicle/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateVehicleDto dto)
        {
            if (id != dto.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Drivers = await GetDriversSelectList(dto.DriveId);
                return View(dto);
            }

            try
            {
                await _vehicleService.UpdateAsync(dto);
                TempData["Success"] = "تم تحديث بيانات المركبة بنجاح";
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "حدث خطأ غير متوقع: " + ex.Message);
            }

            ViewBag.Drivers = await GetDriversSelectList(dto.DriveId);
            return View(dto);
        }

        // POST: Vehicle/Delete/5 (AJAX Version)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _vehicleService.DeleteAsync(id);
                return Json(new { success = true, message = "تم حذف المركبة بنجاح" });
            }
            catch (KeyNotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "حدث خطأ أثناء الحذف: " + ex.Message });
            }
        }

        // Helper method to get drivers select list
        private async Task<List<SelectListItem>> GetDriversSelectList(int? selectedDriverId = null)
        {
            var drivers = await _vehicleService.GetAvailableDriversAsync();

            var list = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-- اختر السائق --" }
            };

            list.AddRange(drivers.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.DrvNm + (d.Mobil != null ? $" - {d.Mobil}" : ""),
                Selected = d.Id == selectedDriverId
            }));

            return list;
        }
    }
}