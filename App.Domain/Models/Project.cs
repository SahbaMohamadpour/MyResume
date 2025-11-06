using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class skills
    {
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project name is required")]
        [StringLength(100, ErrorMessage = "Project name cannot exceed 100 characters")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [StringLength(100, ErrorMessage = "Technologies used cannot exceed 100 characters")]
        [Display(Name = "Technologies Used")]
        public string TechnologiesUsed { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL")]
        [Display(Name = "Project URL")]
        public string ProjectUrl { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL")]
        [Display(Name = "GitHub Repository")]
        public string GitHubUrl { get; set; }

        [StringLength(50, ErrorMessage = "Project type cannot exceed 50 characters")]
        [Display(Name = "Project Type")]
        public string ProjectType { get; set; }
    }
}
