using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.Application.DTOs.Student;
using SchoolManagement.Application.ServicesInterfaces;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index(string search, int page = 1)
        {
            var students = await _studentService.GetAllStudentsAsync();

            if (!string.IsNullOrEmpty(search))
            {
                students = students
                    .Where(s => s.FullName != null && s.FullName.Contains(search))
                    .ToList();
            }

            int pageSize = 10;

            var pagedStudents = students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)students.Count / pageSize);
            ViewBag.Search = search;

            return View(pagedStudents);
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // GET: Student/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new StudentFormViewModel
            {
                Student = new CreateStudentDto(),
                Stages = await _studentService.GetStagesListAsync(),
                Grades = await _studentService.GetGradesListAsync(),
                Classrooms = await _studentService.GetClassroomsListAsync(),
                Schools = await _studentService.GetSchoolsListAsync(),
                Nations = await _studentService.GetNationsListAsync(),
                Sections = await _studentService.GetSectionsListAsync(),
                Areas = await _studentService.GetAreasListAsync(),
                StudentStatuses = await _studentService.GetStudentStatusesListAsync(),
                TransferTypes = await _studentService.GetTransferTypesListAsync(),
                Vehicles = await _studentService.GetVehiclesListAsync(),
                Discounts = await _studentService.GetDiscountsListAsync(),
                Genders = await _studentService.GetGendersListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentFormViewModel viewModel, IFormFile? StudentImage)
        {
            if (!ModelState.IsValid)
            {
                // إعادة تحميل القوائم في حالة وجود خطأ
                await ReloadDropdowns(viewModel);
                return View(viewModel);
            }

            try
            {
                // ✅ تمرير الصورة إلى الـ Service
                var id = await _studentService.CreateAsync(viewModel.Student, StudentImage);

                TempData["SuccessMessage"] = $"✅ تم إضافة الطالب بنجاح بالرقم: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");

                // إعادة تحميل القوائم
                await ReloadDropdowns(viewModel);
                return View(viewModel);
            }
        }

        // دالة مساعدة لإعادة تحميل القوائم (لتجنب تكرار الكود)
        private async Task ReloadDropdowns(StudentFormViewModel viewModel)
        {
            viewModel.Stages = await _studentService.GetStagesListAsync();
            viewModel.Grades = await _studentService.GetGradesListAsync();
            viewModel.Classrooms = await _studentService.GetClassroomsListAsync();
            viewModel.Schools = await _studentService.GetSchoolsListAsync();
            viewModel.Nations = await _studentService.GetNationsListAsync();
            viewModel.Sections = await _studentService.GetSectionsListAsync();
            viewModel.Areas = await _studentService.GetAreasListAsync();
            viewModel.StudentStatuses = await _studentService.GetStudentStatusesListAsync();
            viewModel.TransferTypes = await _studentService.GetTransferTypesListAsync();
            viewModel.Vehicles = await _studentService.GetVehiclesListAsync();
            viewModel.Discounts = await _studentService.GetDiscountsListAsync();
            viewModel.Genders = await _studentService.GetGendersListAsync();
        }
        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            var viewModel = new StudentFormViewModel
            {
                Student = student,
                Stages = await _studentService.GetStagesListAsync(),
                Grades = await _studentService.GetGradesListAsync(),
                Classrooms = await _studentService.GetClassroomsListAsync(),
                Schools = await _studentService.GetSchoolsListAsync(),
                Nations = await _studentService.GetNationsListAsync(),
                Sections = await _studentService.GetSectionsListAsync(),
                Areas = await _studentService.GetAreasListAsync(),
                StudentStatuses = await _studentService.GetStudentStatusesListAsync(),
                TransferTypes = await _studentService.GetTransferTypesListAsync(),
                Vehicles = await _studentService.GetVehiclesListAsync(),
                Discounts = await _studentService.GetDiscountsListAsync(),
                Genders = await _studentService.GetGendersListAsync()
            };

            return View(viewModel);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentFormViewModel viewModel)
        {
            if (id != viewModel.Student.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                // إعادة تحميل القوائم
                viewModel.Stages = await _studentService.GetStagesListAsync();
                viewModel.Grades = await _studentService.GetGradesListAsync();
                viewModel.Classrooms = await _studentService.GetClassroomsListAsync();
                viewModel.Schools = await _studentService.GetSchoolsListAsync();
                viewModel.Nations = await _studentService.GetNationsListAsync();
                viewModel.Sections = await _studentService.GetSectionsListAsync();
                viewModel.Areas = await _studentService.GetAreasListAsync();
                viewModel.StudentStatuses = await _studentService.GetStudentStatusesListAsync();
                viewModel.TransferTypes = await _studentService.GetTransferTypesListAsync();
                viewModel.Vehicles = await _studentService.GetVehiclesListAsync();
                viewModel.Discounts = await _studentService.GetDiscountsListAsync();
                viewModel.Genders = await _studentService.GetGendersListAsync();

                return View(viewModel);
            }

            try
            {
                await _studentService.UpdateAsync(viewModel.Student);

                TempData["SuccessMessage"] = "✅ تم تعديل بيانات الطالب بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");

                // إعادة تحميل القوائم
                viewModel.Stages = await _studentService.GetStagesListAsync();
                viewModel.Grades = await _studentService.GetGradesListAsync();
                viewModel.Classrooms = await _studentService.GetClassroomsListAsync();
                viewModel.Schools = await _studentService.GetSchoolsListAsync();
                viewModel.Nations = await _studentService.GetNationsListAsync();
                viewModel.Sections = await _studentService.GetSectionsListAsync();
                viewModel.Areas = await _studentService.GetAreasListAsync();
                viewModel.StudentStatuses = await _studentService.GetStudentStatusesListAsync();
                viewModel.TransferTypes = await _studentService.GetTransferTypesListAsync();
                viewModel.Vehicles = await _studentService.GetVehiclesListAsync();
                viewModel.Discounts = await _studentService.GetDiscountsListAsync();
                viewModel.Genders = await _studentService.GetGendersListAsync();

                return View(viewModel);
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.DeleteAsync(id);
                TempData["SuccessMessage"] = "✅ تم حذف الطالب بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"❌ حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }


    }
}