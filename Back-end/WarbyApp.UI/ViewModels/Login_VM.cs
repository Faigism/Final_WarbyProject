using System.ComponentModel.DataAnnotations;

namespace WarbyApp.UI.ViewModels
{
    public class Login_VM
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
