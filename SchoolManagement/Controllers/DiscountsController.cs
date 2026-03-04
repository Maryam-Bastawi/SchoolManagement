using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Discount;
using SchoolManagement.Application.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        // GET: Discount
        public async Task<IActionResult> Index()
        {
            var discounts = await _discountService.GetAllAsync();
            return View(discounts);
        }

        // GET: Discount/Create
        public IActionResult Create()
        {
            return View(new CreateDiscountDto());
        }

        // POST: Discount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDiscountDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _discountService.CreateAsync(model);
                TempData["Success"] = "تم إضافة الخصم بنجاح";
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

            return View(model);
        }
       
        // GET: Discount/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var discount = await _discountService.GetByIdAsync(id);
                if (discount == null)
                {
                    TempData["Error"] = $"الخصم برقم {id} غير موجود";
                    return RedirectToAction(nameof(Index));
                }

                var updateDto = new UpdateDiscountDto
                {
                    Id = discount.Id,
                    DescountNm = discount.DescountNm,
                    DescountNm_E = discount.DescountNm_E,
                    DiscVal = discount.DiscVal,
                    DiscPer = discount.DiscPer,
                    DiscVal2 = discount.DiscVal2
                };

                return View(updateDto);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "حدث خطأ أثناء تحميل البيانات: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Discount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateDiscountDto model)
        {
            if (id != model.Id)
            {
                return BadRequest("معرف الخصم غير متطابق");
            }

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _discountService.UpdateAsync(model);
                TempData["Success"] = "تم تحديث الخصم بنجاح";
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException ex)
            {
                TempData["Error"] = ex.Message;
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

            return RedirectToAction(nameof(Index));
        }

        // GET: Discount/
        // /5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var discount = await _discountService.GetByIdAsync(id);
                if (discount == null)
                {
                    TempData["Error"] = $"الخصم برقم {id} غير موجود";
                    return RedirectToAction(nameof(Index));
                }

                return View(discount);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "حدث خطأ أثناء تحميل البيانات: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

    // POST: Discount/DeleteConfirmed/5 (AJAX Version Only)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _discountService.DeleteAsync(id);
            return Json(new { success = true, message = "تم الحذف بنجاح" });
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
}