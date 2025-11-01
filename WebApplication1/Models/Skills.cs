using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Skills
    {
        public class Skill
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [Display(Name = "Skill Name")]
            public string Name { get; set; }

            [Display(Name = "Proficiency Level")]
            [Range(1, 100)]
            public int Proficiency { get; set; }

            [Required]
            [Display(Name = "Category")]
            public string Category { get; set; }

            [Display(Name = "Display Order")]
            public int DisplayOrder { get; set; }

            [DataType(DataType.MultilineText)]
            public string Description { get; set; }

            [Display(Name = "Years of Experience")]
            public double YearsOfExperience { get; set; }

            [Display(Name = "Last Used")]
            public DateTime? LastUsed { get; set; }

            [Display(Name = "Skill Level")]
            public SkillLevel Level { get; set; }

            [Display(Name = "Featured Skill")]
            public bool IsFeatured { get; set; }

            public int ResumeId { get; set; }
            
        }

        public enum SkillLevel
        {
            Beginner = 1,
            Intermediate = 2,
            Advanced = 3,
            Expert = 4
        }
    }
}
