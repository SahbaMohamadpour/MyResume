using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class Language:BaseData
    {
        [Display(Name = "languageName")]
        public string languageName { get; set; }

        [Display(Name = "LangLevel")]
        public LanguageLevel LangLevel { get; set; }

        

    }
}
