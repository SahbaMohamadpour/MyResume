using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
   
public class Certificate : BaseData
    {
        [Required(ErrorMessage = "Certificate Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Certificate Name must be between 2 and 100 characters")]
        [Display(Name = "Certificate Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Organization is required")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Organization must be between 2 and 200 characters")]
        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL for the certificate")]
        [StringLength(500, ErrorMessage = "Certificate URL cannot be longer than 500 characters")]
        [Display(Name = "Certificate URL")]
        public string CertificateUrl { get; set; }

        [Range(0, 4, ErrorMessage = "Rate must be between 0 and 4")]
        [Display(Name = "Rate")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal? Rate { get; set; }




    }
}
