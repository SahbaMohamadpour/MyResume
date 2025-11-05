using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class Exprience : BaseData
    {
        [Display(Name = "JobTitle")]
        public string JobTitle { get; set; }

        [Display(Name = "CompanyName")]
        public string CompanyName { get; set; }

        [Display(Name = "IsRemote")]
        public bool IsRemote { get; set; }

        [Display(Name = "EmploymentType")]
        public EmploymentType EmploymentType { get; set; }
    }
}
