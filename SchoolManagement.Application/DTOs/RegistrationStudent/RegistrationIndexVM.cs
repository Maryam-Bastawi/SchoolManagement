using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.RegistrationStudent
{
    public class RegistrationIndexVM
    {
        // قائمة التسجيلات (للعرض)
        public List<SchoolManagement.Domain.Entities.RegistrationStudent> Registrations { get; set; }

        // قوائم دروب داون للتسجيل الجديد
        public List<SelectListItem> StudentsList { get; set; }
        public int? SelectedStudentId { get; set; }

        public List<SelectListItem> StudyYearsList { get; set; }
        public int? SelectedStudyYearId { get; set; }
    }

    public class RegistrationCreateVM
    {
        // بيانات الطالب (للقراءة فقط - تيجي من جدول الطالب)
        public int StudentId { get; set; }
        public string? StudentFullName { get; set; }
        public string? SchoolName { get; set; }
        public string? StageName { get; set; }
        public string? GradeName { get; set; }
        public string? ClassName { get; set; }
        public string? StudentStatusName { get; set; }
        public string? TransferTypeName { get; set; }
        public string? VehicleName { get; set; }
        public string? DiscountTypeName { get; set; }

        // بيانات العام الدراسي
        public int StudyYearId { get; set; }
        public string? StudyYearName { get; set; }

        // بيانات التسجيل
        public decimal? FirstSemesterFees { get; set; }
        public decimal? SecondSemesterFees { get; set; }
        public decimal? FirstSemesterTransferFees { get; set; }
        public decimal? SecondSemesterTransferFees { get; set; }
        public decimal? RegistrationFees { get; set; }
        public decimal? BooksFees { get; set; }
        public decimal? OtherFees { get; set; }

        // الخصم (يتم جلبها من الطالب لكن يمكن تعديلها)
        public int? DiscountTypeId { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? DiscountPercentage { get; set; }

        // محسوبة تلقائياً
        public decimal? TotalAmount { get; set; }           // مجموع كل الرسوم
        public decimal? AmountAfterDiscount { get; set; }   // بعد الخصم

        // مركز التكلفة
        public int? CostCenterId { get; set; }

        // ملاحظات
        public string? Notes { get; set; }
        public string? Notes2 { get; set; }

        // قوائم دروب داون
        public List<SelectListItem> CostCentersList { get; set; }
        public List<SelectListItem> DiscountTypesList { get; set; }
    }
}
