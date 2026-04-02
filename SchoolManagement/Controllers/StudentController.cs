using Microsoft.AspNetCore.Mvc;
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

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View(new CreateStudentDto());
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var id = await _studentService.CreateAsync(dto);

                TempData["SuccessMessage"] = $"✅ تم إضافة الطالب بنجاح بالكود: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء الإضافة: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _studentService.GetByIdAsync(id);

            if (dto == null)
                return NotFound();

            return View(dto);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateStudentDto dto)
        {
            if (id != dto.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                await _studentService.UpdateAsync(dto);

                TempData["SuccessMessage"] = "تم تعديل بيانات الطالب بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء التعديل: {ex.Message}");
                return View(dto);
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

                TempData["SuccessMessage"] = "تم حذف الطالب بنجاح!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء الحذف: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    } 
}