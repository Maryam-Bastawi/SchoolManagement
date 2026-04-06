using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class RegistrationStudent
    {
        // بيانات التسجيل الأساسية
        public int Id { get; set; }
        [Display(Name = "التاريخ الهجري")]
        public string? HijriDate { get; set; }

        [Display(Name = "التاريخ الميلادي")]
        public DateTime? GregorianDate { get; set; }

        [Required(ErrorMessage = "الطالب مطلوب")]
        [Display(Name = "الطالب")]
        public int StudentId { get; set; }

        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        [Display(Name = "ملاحظات إضافية")]
        public string? Notes2 { get; set; }

        [Display(Name = "الفصل الدراسي الأول")]
        public bool FirstTerm { get; set; }

        [Display(Name = "الفصل الدراسي الثاني")]
        public bool SecondTerm { get; set; }

        [Display(Name = "رسوم الدراسة الترم الأول")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? FirstTermStudyFees { get; set; }

        [Display(Name = "رسوم الدراسة الترم الثاني")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SecondTermStudyFees { get; set; }

        [Display(Name = "قيمة الانتقال ترم أول")]
        public int? transCost_value_sem1Id { get; set; }

        [Display(Name = "قيمة الانتقال ترم ثاني")]
        public int? transCost_value_sem2Id { get; set; }

        [Display(Name = "العام الدراسي")]
        public int? StudyYearId { get; set; }

        [Display(Name = "رسوم التسجيل")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? FirstTermRegistrationFees { get; set; }

        [Display(Name = "رسوم الكتب")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? FirstTermBooksFees { get; set; }

        [Display(Name = "رسوم أخرى")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? other { get; set; }

        [Display(Name = "إجمالي بعد الخصم")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPaid { get; set; }

    }
}
