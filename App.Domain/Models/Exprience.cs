using App.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
    public class Exprience : BaseData
    {
        [Required(ErrorMessage = "Job Title is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Job Title must be between 2 and 100 characters")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Company Name must be between 2 and 100 characters")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Remote Position")]
        public bool IsRemote { get; set; }

      
        [Display(Name = "Employment Type")]
        public EmploymentType EmploymentType { get; set; }
    }
}
