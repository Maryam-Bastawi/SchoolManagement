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
        [Key]
        public int Id { get; set; }

        // العلاقة مع الطالب
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

        // العلاقة مع العام الدراسي
        public int StudyYearId { get; set; }
        [ForeignKey("StudyYearId")]
        public StudyYear? StudyYear { get; set; }

        // الرسوم الدراسية
        public decimal? FirstSemesterFees { get; set; }      // رسوم دراسية ترم 1
        public decimal? SecondSemesterFees { get; set; }     // رسوم دراسية ترم 2
        public decimal? FirstSemesterTransferFees { get; set; }  // قيمة انتقال ترم اول
        public decimal? SecondSemesterTransferFees { get; set; } // قيمة انتقال ترم تانى
        public decimal? RegistrationFees { get; set; }       // رسوم التسجيل
        public decimal? BooksFees { get; set; }              // كتب دراسية
        public decimal? OtherFees { get; set; }              // اخري

        // الخصم (من جدول الطالب - يتم جلبها وجلبها هنا للتسجيل)
        public int? DiscountTypeId { get; set; }             // نوع الخصم
        public decimal? DiscountValue { get; set; }          // قيمة الخصم
        public decimal? DiscountPercentage { get; set; }     // نسبة الخصم

        // المبالغ
        public decimal? TotalAmount { get; set; }            // اجمالى المبلغ قبل الخصم
        public decimal? AmountAfterDiscount { get; set; }    // المبلغ بعد الخصم

        // نوع الانتقال والحافلة (من جدول الطالب)
        public int? TransferTypeId { get; set; }
        public int? VehicleId { get; set; }

        // الملاحظات
        public string? Notes { get; set; }                   // ملاحظات 1
        public string? Notes2 { get; set; }                  // ملاحظات 2

        // بيانات إضافية للتسجيل
        public DateTime? RegistrationDate { get; set; }      // تاريخ التسجيل
        public int? CostCenterId { get; set; }               // مركز التكلفة
        public bool IsPaid { get; set; }                     // هل تم الدفع؟
        public DateTime? CreatedAt { get; set; }             // تاريخ الإنشاء
        public int? CreatedBy { get; set; }                  // من قام بالتسجيل

    }

}
