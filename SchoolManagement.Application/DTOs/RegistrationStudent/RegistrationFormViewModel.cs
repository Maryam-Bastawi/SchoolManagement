using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.RegistrationStudent
{
    public class RegistrationFormViewModel
    {
        // بيانات التسجيل (قابلة للتعديل)
        public RegistrationStudentDto Registration { get; set; } = new RegistrationStudentDto();

        // بيانات الطالب (Read-Only - تظهر تلقائياً)
        [Display(Name = "اسم الطالب")]
        public string? StudentName { get; set; }

        [Display(Name = "الاسم بالإنجليزي")]
        public string? StudentEnglishName { get; set; }

        // البيانات الدراسية (Read-Only)
        [Display(Name = "المدرسة")]
        public string? SchoolName { get; set; }

        [Display(Name = "المرحلة الدراسية")]
        public string? StageName { get; set; }

        [Display(Name = "الصف الدراسي")]
        public string? GradeName { get; set; }

        [Display(Name = "الفصل")]
        public string? ClassName { get; set; }

        // ===============================
        // بيانات المواصلات (Read-Only)
        // ===============================
        [Display(Name = "نوع الانتقال")]
        public string? TransferTypeName { get; set; }

        [Display(Name = "الحافلة")]
        public string? VehicleName { get; set; }

        // ===============================
        // بيانات الخصم (Read-Only)
        // ===============================
        [Display(Name = "نوع الخصم")]
        public string? DiscountName { get; set; }

        [Display(Name = "قيمة الخصم")]
        public decimal? DiscountValue { get; set; }

        [Display(Name = "نسبة الخصم")]
        public decimal? DiscountPercentage { get; set; }




        // ===============================
        // قوائم Dropdown
        // ===============================
        public IEnumerable<SelectListItem> StudentsList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> StudyYearsList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> SchoolList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> GradesList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> StagesList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> ClassList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> DiscountList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> StudentStatusesList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> TransferTypesList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> VehiclesList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> TransCostsList { get; set; } = new List<SelectListItem>();

        // ===============================
        // المفاتيح المختارة (Hidden Fields)
        // ===============================
        public int SelectedStudentId { get; set; }
        public int? SelectedSchoolId { get; set; }
        public int? SelectedStageId { get; set; }
        public int? SelectedGradeId { get; set; }
        public int? SelectedClassId { get; set; }
        public int? SelectedVehicleId { get; set; }
        public int? SelectedTransferTypeId { get; set; }
        public int? SelectedDiscountId { get; set; }
        public int? SelectedStudentStatusId { get; set; }





    }
}
