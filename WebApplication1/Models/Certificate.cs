using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
   
public class Certificate
    {
        [Key]
        
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Certificate Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Certificate Number")]
        public string CertificateNumber { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

       
        [Display(Name = "Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [StringLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Url]
        [StringLength(500)]
        [Display(Name = "Certificate URL")]
        public string CertificateUrl { get; set; }

        [StringLength(100)]
        [Display(Name = "Credential ID")]
        public string CredentialId { get; set; }

        [StringLength(200)]
        [Display(Name = "Skills")]
        public string Skills { get; set; }

        [Range(0, 20)]
        [Display(Name = "Score")]
        public decimal? Score { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Status")]
        public string Status { get; set; } = "Active"; 

        [StringLength(100)]
        [Display(Name = "Category")]
        public string Category { get; set; }

        
        [Display(Name = "Duration")]
        public string Duration { get; set; }

        [StringLength(500)]
        [Display(Name = "Verification URL")]
        [Url]
        public string VerificationUrl { get; set; }



    }
}
