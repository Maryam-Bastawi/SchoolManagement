using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.Application.DTOs.Grades;
using SchoolManagement.Application.ServicesInterfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Interface;

namespace SchoolManagement.Controllers
{
    public class GradesController : Controller
    {
        private readonly IGradesService _gradesService;
        private readonly IUnitOfWork _unitOfWork;

        public GradesController(IGradesService gradesService, IUnitOfWork unitOfWork)
        {
            _gradesService = gradesService;
            _unitOfWork = unitOfWork;
        }

        // GET: Grades/Index
        public async Task<IActionResult> Index()
        {
            var grades = await _gradesService.GetAllAsync();
            return View(grades);
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var grade = await _gradesService.GetByIdAsync(id);
            if (grade == null)
                return NotFound();
            return View(grade);
        }

        // GET: Grades/Create
        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();
            return View();
        }

        // POST: Grades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGradesDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _gradesService.CreateAsync(dto);
                    TempData["Success"] = "تم إضافة الصف بنجاح";
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

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var grade = await _gradesService.GetByIdAsync(id);
            if (grade == null)
                return NotFound();

            var updateDto = new UpdateGradesDto
            {
                Id = grade.Id,
                GradesNm = grade.GradesNm,
                GradesNm_E = grade.GradesNm_E,
                StagesId = grade.StagesId,
                SchoolId = grade.SchoolId,
                CostCenterId = grade.CostCenterId,
                TransCostId = grade.TransCostId,
                Term1Fee = grade.Term1Fee,
                Term2Fee = grade.Term2Fee,
                RegistrationFee = grade.RegistrationFee,
                BookFee = grade.BookFee,
                OtherFee = grade.OtherFee,
                NextStageId = grade.NextStageId,
                NextGradeId = grade.NextGradeId,
                NextSchoolId = grade.NextSchoolId,
                studStatusId = grade.studStatusId
            };

            await LoadDropdowns();
            return View(updateDto);
        }

        // POST: Grades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateGradesDto dto)
        {
            if (id != dto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _gradesService.UpdateAsync(dto);
                    TempData["Success"] = "تم تحديث الصف بنجاح";
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

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var grade = await _gradesService.GetByIdAsync(id);
            if (grade == null)
                return NotFound();
            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _gradesService.DeleteAsync(id);
                TempData["Success"] = "تم حذف الصف بنجاح";
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
            var stagesRepo = _unitOfWork.Repository<Stages, int>();
            var schoolsRepo = _unitOfWork.Repository<School, int>();
            var costCentersRepo = _unitOfWork.Repository<CostCenter, int>();
            var transCostsRepo = _unitOfWork.Repository<TransCost, int>();
            var studentStatusesRepo = _unitOfWork.Repository<StudentStatus, int>();
            var gradesRepo = _unitOfWork.Repository<Grades, int>();

            var stages = await stagesRepo.GetAllAsync();
            var schools = await schoolsRepo.GetAllAsync();
            var costCenters = await costCentersRepo.GetAllAsync();
            var transCosts = await transCostsRepo.GetAllAsync();
            var studentStatuses = await studentStatusesRepo.GetAllAsync();
            var grades = await gradesRepo.GetAllAsync();

            ViewBag.Stages = new SelectList(stages.OrderBy(x => x.StageNM), "Id", "StageNM");
            ViewBag.Schools = new SelectList(schools.OrderBy(x => x.SchoolNm), "Id", "SchoolNm");
            ViewBag.CostCenters = new SelectList(costCenters.OrderBy(x => x.CostNm), "Id", "CostNm");
            ViewBag.TransCosts = new SelectList(transCosts, "Id", "Id"); // تعديل حسب الخاصية الموجودة
            ViewBag.StudentStatuses = new SelectList(studentStatuses.OrderBy(x => x.StatusName), "Id", "StatusName");
            ViewBag.Grades = new SelectList(grades.OrderBy(x => x.GradesNm), "Id", "GradesNm");
            ViewBag.StagesForNext = new SelectList(stages.OrderBy(x => x.StageNM), "Id", "StageNM");
            ViewBag.GradesForNext = new SelectList(grades.OrderBy(x => x.GradesNm), "Id", "GradesNm");
            ViewBag.SchoolsForNext = new SelectList(schools.OrderBy(x => x.SchoolNm), "Id", "SchoolNm");
        }
    }
}
