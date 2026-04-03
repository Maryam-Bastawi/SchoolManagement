using SchoolManagement.Domain.Enums.Gender;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        // بيانات الطالب
        public string FullName { get; set; }           // الاسم
        public string EnglishName { get; set; }        // الاسم لاتيني
        public GenderType Gender { get; set; }         // النوع

        public int? NationalId { get; set; }           // الجنسية
        public Nation? National { get; set; }

        public int? SectionId { get; set; }            // القسم
        public Section? section { get; set; }

        public bool? RegisterNextYear { get; set; }    // تسجيل للعام القادم
        public decimal? DebtAmount { get; set; }        // رصيد الدين
        public string? StudentImagePath { get; set; }   // صورة الطالب

       
        public string? ResponseName { get; set; }       //  الشخص المسؤول 
        public string? WorkDate { get; set; }           // بيانات العمل  
        public string? HomePhone { get; set; }          // رقم المنزل 
        public string? WorkPhone { get; set; }          // رقم العمل 
        public string? Mobile { get; set; }             // جوال 
        public string? Address { get; set; }            // العنوان

        public int? AreaId { get; set; }               // الحي / المنطقة
        public Area? Area { get; set; }

        // الهوية
        public string? IdNumber { get; set; }           // رقم الحفيظة
        public string? IssuePlace { get; set; }         // مصدرها
        public DateTime? IssueDate { get; set; }       // تاريخ الإصدار
        public DateTime? ExpiryDate { get; set; }      // تاريخ الانتهاء

        // بيانات دراسية
        public int? SchoolId { get; set; }             // المدرسة
        public School? School { get; set; }

        public int? StagesId { get; set; }             // المرحلة الدراسية
        public Stages? stages { get; set; }

        public int? GradesId { get; set; }             // الصف
        public Grades? Grades { get; set; }

        public int? ClassroomId { get; set; }          // الفصل
        public Class? Classroom { get; set; }

        // الحالة
        public int? StudentStatusId { get; set; }      // مستجد / منتظم
        public StudentStatus? StudentStatuses { get; set; }

        public int? TransferTypeId { get; set; }       // نوع الانتقال
        public TransferType? TransferType { get; set; }

        public int? VehicleId { get; set; }            // الحافلة 
        public Vehicle? Vehicle { get; set; }

        public int? Discounttypeid { get; set; }      // نوع الخصم
        public Discount? Discounttype { get; set; }

        // ملاحظات
        public string? Notes { get; set; }
        public string? Notes2 { get; set; }

        // بيانات شخصية إضافية
        public string? PassportNumber { get; set; }     // رقم جواز السفر
        public string? RecordNumber { get; set; }       // رقم السجل 

        public DateTime? BirthDate { get; set; }       // تاريخ الميلاد
        public string? BirthPlace { get; set; }         // مكان الميلاد
        public DateTime? ContractDate { get; set; }    // تاريخ الالتحاق

        // الضريبة
        public bool? IsTaxable { get; set; }            // خاضع للضريبة / غير خاضع
        public bool? IsGraduate { get; set; }          // هل تخرج؟

        // سحب الملف
        public bool? IsFileWithdrawn { get; set; }      // هل تم سحب ملف الطالب
        public DateTime? WithdrawDate { get; set; }    // تاريخ السحب
    }
}