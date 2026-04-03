using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Student
{ 
    public class StudentFormViewModel
    {
        public CreateStudentDto Student { get; set; } = new CreateStudentDto();

        public List<SelectListItem> Stages { get; set; } = new();
        public List<SelectListItem> Grades { get; set; } = new();
        public List<SelectListItem> Classrooms { get; set; } = new();
        public List<SelectListItem> Schools { get; set; } = new();
        public List<SelectListItem> Nations { get; set; } = new();
        public List<SelectListItem> Sections { get; set; } = new();
        public List<SelectListItem> Areas { get; set; } = new();
        public List<SelectListItem> StudentStatuses { get; set; } = new();
        public List<SelectListItem> TransferTypes { get; set; } = new();
        public List<SelectListItem> Vehicles { get; set; } = new();
        public List<SelectListItem> Discounts { get; set; } = new();
        public List<SelectListItem> Genders { get; set; } = new();
    }
}
