using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class Language:BaseData
    {
        [Required(ErrorMessage = "Language name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Language name must be between 2 and 50 characters")]
        [Display(Name = "Language Name")]
      
        public string languageName { get; set; }

        [Required(ErrorMessage = "Language level is required")]
        [Display(Name = "Language Level")]
        [EnumDataType(typeof(LanguageLevel), ErrorMessage = "Please select a valid language level")]
        public LanguageLevel LangLevel { get; set; }



    }
}
