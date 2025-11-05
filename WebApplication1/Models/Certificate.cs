using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
   
public class Certificate : BaseData
    {
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Certificate Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Url]
        [StringLength(500)]
        [Display(Name = "Certificate URL")]
        public string CertificateUrl { get; set; }

        [Range(0,4)]
        [Display(Name = "GPA")]
        public decimal? GPA { get; set; }




    }
}
