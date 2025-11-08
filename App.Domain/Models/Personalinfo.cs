using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
    public class Personalinfo : BaseData
    {


        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        [Url(ErrorMessage = "Please enter a valid URL for the image")]
        [StringLength(500, ErrorMessage = "Image URL cannot be longer than 500 characters")]
        public string? Image { get; set; }

        [Display(Name = "Position")]
        [StringLength(100, ErrorMessage = "Position cannot be longer than 100 characters")]
        public string Position { get; set; }

        [Display(Name = "About")]
        [StringLength(1000, ErrorMessage = "About cannot be longer than 1000 characters")]
        public string About { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string Email { get; set; }

        [Display(Name = "Why am I here?")]
        [StringLength(500, ErrorMessage = "Manifesto cannot be longer than 500 characters")]
        public string Manifesto { get; set; }

        [Display(Name = "Country")]
        [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters")]
        public string Country { get; set; }

        [Display(Name = "Website")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [StringLength(200, ErrorMessage = "Website URL cannot be longer than 200 characters")]
        public string Website { get; set; }

        [Display(Name = "LinkedIn")]
        [Url(ErrorMessage = "Please enter a valid LinkedIn URL")]
        [StringLength(200, ErrorMessage = "LinkedIn URL cannot be longer than 200 characters")]
        public string LinkedIn { get; set; }

        [Display(Name = "GitHub")]
        [Url(ErrorMessage = "Please enter a valid GitHub URL")]
        [StringLength(200, ErrorMessage = "GitHub URL cannot be longer than 200 characters")]
        public string GitHub { get; set; }



    }
}
