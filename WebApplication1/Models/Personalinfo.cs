using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Personalinfo : BaseData
    {
      

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "image")]
        public string? Image { get; set; }

        [Display(Name = "position")]
        public string Position { get; set; }

        [Display(Name = "About")]
        public string About { get; set; } 

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Why am a here?")]
        public string Manifesto { get; set; }


        [Display(Name = "Country")]

        public string Country { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "LinkedIn")]
        public string LinkedIn { get; set; }


        [Display(Name = "GitHub ")]
        public string GitHub { get; set; }



    }
}
