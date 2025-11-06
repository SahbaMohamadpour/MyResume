using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Hobbies : BaseData
    {
      

        [Required(ErrorMessage = "Hobby name is required")]
        [Display(Name = "Hobby Name")]
        public string Name { get; set; }


    }
}
