using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Oishi.Shared.ViewModels.Account
{
    public class AccountEditViewModel
    {
        [DisplayName("Nome de utilizador")]
        [Required(ErrorMessage = "Insira o seu nome de utilizador")]
        [MinLength(3)]
        [MaxLength(48)]
        public string Username { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Insira um email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [MaxLength(320)]
        public string Email { get; set; }

        [DisplayName("Telemóvel")]
        [Phone(ErrorMessage = "Number invalid")]
        [MinLength(9)]
        [MaxLength(13)]
        public string? Phone { get; set; }

        [DisplayName("Palavra-passe")]
        [MinLength(8)]
        [MaxLength(32)]
        public string? Password { get; set; }
    }
}