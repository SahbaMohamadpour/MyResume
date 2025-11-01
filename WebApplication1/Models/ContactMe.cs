using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactMe
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = " Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = " Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = " phone")]
        public string Phone { get; set; }

        [Display(Name = " Address")]
        public string Address { get; set; }

        [Display(Name = " City")]
        public string City { get; set; }

        [Display(Name = " PostalCode")]
        public string PostalCode { get; set; } = string.Empty;

        [Display(Name = " Country")]
        public string Country { get; set; }

        [Display(Name = " PhoneNumber")]
        public string PhoneNumber { get; set; }
        
    }
}
