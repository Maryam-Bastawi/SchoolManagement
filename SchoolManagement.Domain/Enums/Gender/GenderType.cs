using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain.Enums.Gender
{
    public enum GenderType
    {
        [Display(Name = "ذكر")]
        Male = 1,

        [Display(Name = "أنثى")]
        Female = 2
    }
}