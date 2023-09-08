using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WarbyApp.UI.ViewModels
{
    public class ColorEdit_VM
    {
        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string ColorName { get; set; }
        public IFormFile ColorImage { get; set; }
    }
}
