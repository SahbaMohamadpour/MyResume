using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Comments
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "What people say about me?")]
        public string Comment { get; set; }
    }
}
