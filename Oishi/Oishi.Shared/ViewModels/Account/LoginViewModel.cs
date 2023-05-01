using System.ComponentModel.DataAnnotations;

namespace Oishi.Shared.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Insira um email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [MaxLength(320)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira uma senha")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}