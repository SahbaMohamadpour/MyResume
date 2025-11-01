using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Personalinfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "JobTitle")]
        public string JobTitle { get; set; }

        [Display(Name = "JobDescription")]
        public string JobDescription { get; set; } = string.Empty;

        [Display(Name = "Education")]
        public int Education { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Language")]
        public string Language { get; set; }




    }
}
