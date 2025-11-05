using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class Skills
    {
        public class Skill : BaseData
        {

            [Required(ErrorMessage = "Skill Name is required")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Skill Name must be between 2 and 50 characters")]
            [Display(Name = "Skill Name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Skill rating is required")]
            [Display(Name = "Skill Rating")]
            [Range(1, 5, ErrorMessage = "Skill rating must be between 1 and 5")]
            public int Rate { get; set; }

            [Required(ErrorMessage = "Display order is required")]
            [Display(Name = "Display Order")]
            [Range(0, 100, ErrorMessage = "Display order must be between 0 and 100")]
            public int DisplayOrder { get; set; }

            [Required(ErrorMessage = "Skill level is required")]
            [Display(Name = "Skill Level")]
            [EnumDataType(typeof(SkillLevel), ErrorMessage = "Please select a valid skill level")]
            public SkillLevel Level { get; set; }


        }

    }
}
