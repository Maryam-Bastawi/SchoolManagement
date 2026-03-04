using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string DisplayCode { get; set; } = string.Empty; // <-- هنا
        public string? FullName { get; set; }
        public string? EnglishName { get; set; }
        public string? Email { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Phone { get; set; }
        //العنوان 
        public string? Location { get; set; }
        //نوع اخصم
        public int? Discounttypeid { get; set; }
        public Discount? Discounttypes { get; set; }
        //نوع الانتقال 
        public int? TransferTypeId { get; set; }
        public TransferType? TransferTypes { get; set; }
        public string? Respons { get; set; }
        public bool? SuspendAccount { get; set; }
        public string? IdNumber { get; set; }
        public DateTime? IdIssueDate { get; set; }
        public DateTime? IdEndDate { get; set; }
        public string? IdPlace { get; set; }
        public int? NationalId { get; set; }
        public Nation? Nations { get; set; }
        public string? ImgName { get; set; }
        //الحافله
        public int? VehicleId { get; set; }
        public Vehicle? Vehicles { get; set; }
        public int? StagesId { get; set; }
        public Stages? stages { get; set; }
        public int? GradesId { get; set; }
        public Grades? Grades { get; set; }
        public int? SectionId { get; set; }
        public Section? section { get; set; }
        public StudentStatus? StudentStatuses { get; set; }
        public int? StudentStatusId { get; set; }
        public int? ClassroomId { get; set; }
        public Class? Classrooms { get; set; }
        //الحي والمنطقه
        public int? AreaId { get; set; }
        public Area? Areas { get; set; }
        public int? SchoolId { get; set; }
        public School? Schools { get; set; }
        public string? PreviousSchool { get; set; }
        public bool? StopSms { get; set; }
        public string? StudentSex { get; set; }
        //رقم حفيظه الطالب
        public string? StudentIdNumber { get; set; }
        public bool? IsGraduate { get; set; }
        public string? Passport { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Note { get; set; }
        public string? Note2 { get; set; }
        public bool StopAutoPromotion { get; set; }
        public string? BirthPlace { get; set; }
        public DateTime? SuspenDate { get; set; } //تاريخ السحب
        public DateTime? GraduateDate { get; set; }
        // حالة الضريبة
        public string? TaxStatus { get; set; }
        public DateTime? EnrollmentDate { get; set; }   // تاريخ الالتحاق
        public DateTime? CreatedDate { get; set; } = DateTime.Now;



    }
}
