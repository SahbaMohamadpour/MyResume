using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Hobbies
    {
        [Key]
        
        [Display(Name = "Hobby ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hobby name is required")]
        [Display(Name = "Hobby Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Skill Level")]
        [StringLength(20)]
        public string SkillLevel { get; set; } 

        [Display(Name = "Years of Experience")]
        public int? YearsOfExperience { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Reference URL")]
        public string ReferenceUrl { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; } 

    }
}
