using SchoolManagement.Domain.Enums.Gender;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.DTOs.Student
{
    public class CreateStudentDto
    {
        public int Id { get; set; }

        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }

        [Display(Name = "الاسم باللاتينية")]
        public string EnglishName { get; set; } 

        [Display(Name = "النوع")]
        public GenderType Gender { get; set; }

        [Display(Name = "الجنسية")]
        public int? NationalId { get; set; }

        [Display(Name = "القسم")]
        public int? SectionId { get; set; }

        [Display(Name = "تسجيل للعام القادم")]
        public bool? RegisterNextYear { get; set; }

        [Display(Name = "رصيد الدين")]
        public decimal? DebtAmount { get; set; }

        [Display(Name = "صورة الطالب")]
        public string? StudentImagePath { get; set; }

        [Display(Name = "الشخص المسؤول")]
        public string ResponseName { get; set; }

        [Display(Name = "تاريخ العمل")]
        public string? WorkDate { get; set; }

        [Display(Name = "الجوال")]
        public string? Mobile { get; set; }

        [Display(Name = "رقم المنزل")]
        public string? HomePhone { get; set; }

        [Display(Name = "رقم العمل")]
        public string? WorkPhone { get; set; }


        [Display(Name = "العنوان")]
        public string? Address { get; set; }

        [Display(Name = "الحي / المنطقة")]
        public int? AreaId { get; set; }

        [Display(Name = "رقم الهوية / الحفيظة")]
        public string? IdNumber { get; set; }

        [Display(Name = "جهة الإصدار")]
        public string? IssuePlace { get; set; }

        [Display(Name = "تاريخ الإصدار")]
        public DateTime? IssueDate { get; set; }

        [Display(Name = "تاريخ الانتهاء")]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "المدرسة")]
        public int? SchoolId { get; set; }

        [Display(Name = "المرحلة الدراسية")]
        public int? StagesId { get; set; }

        [Display(Name = "الصف")]
        public int? GradesId { get; set; }

        [Display(Name = "الفصل")]
        public int? ClassroomId { get; set; }

        [Display(Name = "حالة الطالب")]
        public int? StudentStatusId { get; set; }

        [Display(Name = "نوع الانتقال")]
        public int? TransferTypeId { get; set; }

        [Display(Name = "الحافلة")]
        public int? VehicleId { get; set; }

        [Display(Name = "نوع الخصم")]
        public int? Discounttypeid { get; set; }

        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        [Display(Name = "ملاحظات إضافية")]
        public string? Notes2 { get; set; }

        [Display(Name = "رقم جواز السفر")]
        public string? PassportNumber { get; set; }

        [Display(Name = "رقم السجل")]
        public string? RecordNumber { get; set; }

        [Display(Name = "تاريخ الميلاد")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "مكان الميلاد")]
        public string? BirthPlace { get; set; }

        [Display(Name = "تاريخ الالتحاق")]
        public DateTime? ContractDate { get; set; }

        [Display(Name = "خاضع للضريبة")]
        public bool? IsTaxable { get; set; }

        [Display(Name = "هل تخرج؟")]
        public bool? IsGraduate { get; set; }

        [Display(Name = "تم سحب الملف")]
        public bool? IsFileWithdrawn { get; set; }

        [Display(Name = "تاريخ السحب")]
        public DateTime? WithdrawDate { get; set; }
    }
}