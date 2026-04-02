using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Grades
    {
        public int Id { get; set; }
        public string? GradesNm { get; set; }
        public string? GradesNm_E { get; set; }
        public int? StagesId { get; set; }
        public Stages? stages { get; set; }
        public int? SchoolId { get; set; }
        public School? School { get; set; }
        public int? CostCenterId { get; set; }
        public CostCenter? CostCenter { get; set; }
        //قيمه المصروفات
        public decimal? Term1Fee { get; set; }
        public decimal? Term2Fee { get; set; }
        public decimal? RegistrationFee { get; set; }
        public decimal? BookFee { get; set; }
        public decimal? OtherFee { get; set; }
        public int? TransCostId { get; set; } 
        public TransCost? TransCost { get; set; }
        // تصعيد الطلاب
        public int? NextStageId { get; set; }
        public Stages? NextStage { get; set; }
        public int? NextGradeId { get; set; }
        public Grades? NextGrade { get; set; } 
        public int? NextSchoolId { get; set; }
        public School? NextSchool { get; set; }
        //حالة الطالب (متخرج)
        public StudentStatus? studentStatus { get; set; }
        public int? studStatusId { get; set; }
    }
}
