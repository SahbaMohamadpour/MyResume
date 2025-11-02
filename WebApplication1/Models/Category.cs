using System.ComponentModel.DataAnnotations;
using static WebApplication1.Models.Skills;

namespace WebApplication1.Models
{
    public class Category
    {
        
            public int Id { get; set; }

            [Required]
            [Display(Name = "Category Name")]
          
            public string Name { get; set; }

            [Display(Name = "Description")]
            [DataType(DataType.MultilineText)]
            [StringLength(500)]
            public string Description { get; set; }

            

            [Display(Name = "Icon Class")]
            [StringLength(50)]
            public string IconClass { get; set; } 

            [Display(Name = "Is Active")]
            public bool IsActive { get; set; } = true;

            [Display(Name = "Start Date ")]
            public DateTime StartDate { get; set; } = DateTime.Now;

         
            public virtual ICollection<Skill> Skills { get; set; }

          
            
    }
}
