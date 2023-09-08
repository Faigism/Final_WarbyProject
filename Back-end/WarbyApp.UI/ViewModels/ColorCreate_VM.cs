using System.ComponentModel.DataAnnotations;

namespace WarbyApp.UI.ViewModels
{
    public class ColorCreate_VM
    {
        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string ColorName { get; set; }
        [Required]
        public IFormFile ColorImage { get; set; }
    }
}
