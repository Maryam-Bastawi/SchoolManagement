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

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //public async Task<IActionResult> Create(CreateStudentDto dto)
        //{

        //}
    } 
}