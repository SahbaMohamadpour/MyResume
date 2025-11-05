using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class Skills
    {
        public class Skill : BaseData
        {
          
            [Required]
            [Display(Name = "Skill Name")]
            public string Name { get; set; }

            [Display(Name = "")]
            [Range(1,5)]
            public int Rate { get; set; }

            [Display(Name = "Display Order")]
            public int DisplayOrder { get; set; }


            [Display(Name = "Skill Level")]
            public SkillLevel Level { get; set; }

            
        }

    }
}
