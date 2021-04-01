using System.ComponentModel.DataAnnotations;

namespace Milieu.ClientModels.Web
{
    public class RegisterApiRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
