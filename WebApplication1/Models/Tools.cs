using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Tools
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tool name is required")]
        [Display(Name = "Tool Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public string Category { get; set; } 

        [Display(Name = "Years of Experience")]
        public int? YearsOfExperience { get; set; }


        [Display(Name = "Show on Resume")]
        public bool ShowOnResume { get; set; } = true;

        public enum ProficiencyLevel
        {
            Beginner = 1,
            Intermediate = 2,
            Advanced = 3,
            Expert = 4
        }

    }
}
