    using System;
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
    using System.Threading.Tasks;

    namespace SchoolManagement.Application.DTOs.Student
    {
        public class CreateStudentDto
        {
        [Display(Name = "معرف الطالب")]
        public int Id { get; set; }
        public string DisplayCode { get; set; } = string.Empty; // <-- هنا

        [Display(Name = "الاسم الكامل")]
        public string? FullName { get; set; }

        [Display(Name = "الاسم الإنجليزي")]
        public string? EnglishName { get; set; }
        [Display(Name = "جنس الطالب")]
        public string? StudentSex { get; set; }
        [Display(Name = "الجنسيه")]
        public int? NationalId { get; set; }
        [Display(Name = "مكان الميلاد")]
        public string? BirthPlace { get; set; }
        [Display(Name = "صورة الطالب")]
        public string? ImgName { get; set; }
        [Display(Name = "تاريخ الميلاد")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "جواز السفر")]
        public string? Passport { get; set; }

        [Display(Name = "رقم حفيظة الطالب")]
        public string? StudentIdNumber { get; set; }
        [Display(Name = "ولي الامر")]
        public string? Respons { get; set; }
        [Display(Name = "الجوال 1")]
        public string? Mobile1 { get; set; }

        [Display(Name = "الجوال 2")]
        public string? Mobile2 { get; set; }

        [Display(Name = "الهاتف")]
        public string? Phone { get; set; }
        [Display(Name = "رقم الحفيظه ولي الامر ")]
        public string? IdNumber { get; set; }

        [Display(Name = "تاريخ إصدار الحفيظه")]
        public DateTime? IdIssueDate { get; set; }

        [Display(Name = "تاريخ انتهاء الحفيظه")]
        public DateTime? IdEndDate { get; set; }

        [Display(Name = "مكان إصدار الحفيظه")]
        public string? IdPlace { get; set; }

        [Display(Name = "العنوان")]
        public string? Location { get; set; }

        [Display(Name = "المنطقة")]
        public int? AreaId { get; set; }


        [Display(Name = "المدرسة")]
        public int? SchoolId { get; set; }

        [Display(Name = "المدرسة السابقة")]
        public string? PreviousSchool { get; set; }
        [Display(Name = "تاريخ الالتحاق")]
        public DateTime? EnrollmentDate { get; set; }
        [Display(Name = "المرحلة")]
        public int? StagesId { get; set; }

        [Display(Name = "الصف")]
        public int? GradesId { get; set; }

        [Display(Name = "القسم")]
        public int? SectionId { get; set; }



        [Display(Name = "الفصل الدراسي")]
        public int? ClassroomId { get; set; }
        [Display(Name = "الحافله")]
        public int? VehicleId { get; set; }
        [Display(Name = "نوع الانتقال")]
        public int? TransferTypeId { get; set; }
        [Display(Name = "نوع الخصم")]
        public int? Discounttypeid { get; set; }
        [Display(Name = "حالة الطالب")]
        public int? StudentStatusId { get; set; }
        public int? CREDIT_LIMIT { get; set; }
        [Display(Name = "حالة الضريبة")]
        public string? TaxStatus { get; set; }


        [Display(Name = "إيقاف الرسائل")]
        public bool? StopSms { get; set; }
        [Display(Name = "إيقاف الترقية التلقائية")]
        public bool StopAutoPromotion { get; set; }

        [Display(Name = "خريج")]
        public bool? IsGraduate { get; set; }
        [Display(Name = "تاريخ التخرج")]
        public DateTime? GraduateDate { get; set; }

        [Display(Name = "ملاحظات 1")]
        public string? Note { get; set; }

        [Display(Name = "ملاحظات 2")]
        public string? Note2 { get; set; }
        public bool ISNEWYEAR { get; set; }

        public bool SUSPIND_AC { get; set; }
        public DateTime? SuspenDate { get; set; } //تاريخ السحب











    }
}
